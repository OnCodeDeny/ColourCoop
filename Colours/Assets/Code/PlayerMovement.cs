using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float acceleration = 100f;

    [SerializeField]
    private float decelleration = 100f;

    private Rigidbody2D rb;
    public Collider2D c2d;
    private Vector3 eulerAngles;
    private Player player;
    private string horaxis;
    private string veraxis;
    public Vector2 inputDirection = Vector2.zero;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        c2d = GetComponent<Collider2D>();
        rb.freezeRotation = true;

        if(player.playerid == 1)
        {
            horaxis = "Horizontal1";
            veraxis = "Vertical1";
        }
        if (player.playerid == 2)
        {
            horaxis = "Horizontal2";
            veraxis = "Vertical2";
        }
    }

    private void FixedUpdate()
    {
        inputDirection = new Vector2(Input.GetAxisRaw(horaxis), Input.GetAxisRaw(veraxis));
        inputDirection = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * inputDirection;
        inputDirection.Normalize();

        float accel = inputDirection.sqrMagnitude > 0 ? acceleration : decelleration;
        rb.velocity = Vector3.Lerp(rb.velocity, inputDirection * speed, Time.fixedDeltaTime * accel);

        if (inputDirection.sqrMagnitude > 0)
        {
            Vector3 oldEulerAngles = transform.eulerAngles;
            Vector3 lookAtTransform = new Vector3(transform.position.x + inputDirection.x, 0, transform.position.y + inputDirection.y);
            transform.LookAt(lookAtTransform);
            eulerAngles.y = transform.eulerAngles.y;
            transform.eulerAngles = oldEulerAngles;
        }
    }

    private void Update()
    {
        Vector3 euler = transform.eulerAngles;
        euler.y = Mathf.LerpAngle(euler.y, eulerAngles.y, Time.deltaTime * 15f);
        transform.eulerAngles = euler;
    }

    public struct CollisionInfo
    {
        public bool north, south;
        public bool west, east;

        public Vector2Int faceDir;

        public void Reset()
        {
            north = south = false;
            west = east = false;

        }
    }
}
