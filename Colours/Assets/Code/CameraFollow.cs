using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement target;
    public float HorizontalDstX;
    public float VerticalDstX;
    public float HorizontalSmoothTime;
    public float verticalSmoothTime;
    public Vector2 focusAreaSize;
    public Transform levelBLCorner;
    public Transform levelTRCorner;

    FocusArea focusArea;
    LevelArea levelArea;

    float currentHorizontalX;
    float currentVerticalX;
    float targetHorizontalX;
    float targetVerticalX;
    float HorizontalDirX;
    float VerticalDirX;
    float smoothLookVelocityX;
    float smoothLookVelocityY;

    bool lookAheadStopped;


    private void Start()
    {
        focusArea = new FocusArea(target.c2d.bounds, focusAreaSize);
        levelArea = new LevelArea(levelBLCorner.position, levelTRCorner.position);
    }

    private void LateUpdate()
    {
        focusArea.Update(target.c2d.bounds);

        Vector2 focusPostion = focusArea.center;

        if (focusArea.velocity.x != 0)
        {
            HorizontalDirX = Mathf.Sign(focusArea.velocity.x);
            if (Mathf.Sign(target.inputDirection.x) == Mathf.Sign(focusArea.velocity.x) && target.inputDirection.x != 0)
            {
                lookAheadStopped = false;
                targetHorizontalX = HorizontalDirX * HorizontalDstX;
            }
            else
            {
                if (!lookAheadStopped)
                {
                    lookAheadStopped = true;
                    targetHorizontalX = currentHorizontalX + (HorizontalDirX * HorizontalDstX - currentHorizontalX) / 4f;
                }
            }
        }

        if (focusArea.velocity.y != 0)
        {
            VerticalDirX = Mathf.Sign(focusArea.velocity.y);
            if (Mathf.Sign(target.inputDirection.y) == Mathf.Sign(focusArea.velocity.y) && target.inputDirection.y != 0)
            {
                lookAheadStopped = false;
                targetVerticalX = VerticalDirX * VerticalDstX;
            }
            else
            {
                if (!lookAheadStopped)
                {
                    lookAheadStopped = true;
                    targetVerticalX = currentVerticalX + (VerticalDirX * VerticalDstX - currentVerticalX) / 4f;
                }
            }
        }

        currentHorizontalX = Mathf.SmoothDamp(currentHorizontalX, targetHorizontalX, ref smoothLookVelocityX, HorizontalSmoothTime);
        currentVerticalX = Mathf.SmoothDamp(currentVerticalX, targetVerticalX, ref smoothLookVelocityY, verticalSmoothTime);

        focusPostion += new Vector2(1 * currentHorizontalX, 1 * currentVerticalX);

        //transform.position = (Vector3)focusPostion + Vector3.forward * -10;
        transform.position = new Vector3(Mathf.Clamp(focusPostion.x, levelArea.left + 3.5f, levelArea.right - 3.5f), Mathf.Clamp(focusPostion.y, levelArea.bottom + 5f, levelArea.top - 5f ), -10);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(0, 0, 1, 0.5f);
    //    Gizmos.DrawCube(focusArea.center, focusAreaSize);
    //    Gizmos.DrawLine((Vector3)levelArea.topLeftCorner, (Vector3)levelArea.bottomLeftCorner);
    //    Gizmos.DrawLine((Vector3)levelArea.bottomRightCorner, (Vector3)levelArea.bottomLeftCorner);
    //    Gizmos.DrawLine((Vector3)levelArea.bottomRightCorner, (Vector3)levelArea.topRightCorner);
    //    Gizmos.DrawLine((Vector3)levelArea.topLeftCorner, (Vector3)levelArea.topRightCorner);
    //}

    struct FocusArea
    {
        public Vector2 center;
        public Vector2 velocity;
        float left, right;
        float top, bottom;


        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = targetBounds.center.x + size.x / 2;
            bottom = targetBounds.center.x - size.x / 2;
            top = targetBounds.center.x + size.x / 2;

            velocity = Vector2.zero;
            center = new Vector2((left + right) / 2, (top + bottom) / 2);
        }

        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            bottom += shiftY;
            top += shiftY;
            center = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = new Vector2(shiftX, shiftY);
        }
    }

    struct LevelArea
    {
        public float left, right;
        public float top, bottom;
        public Vector2 topLeftCorner;
        public Vector2 topRightCorner;
        public Vector2 bottomRightCorner;
        public Vector2 bottomLeftCorner;
        public LevelArea(Vector2 bLCorner,  Vector2 tRCorner)
        {
            left = bLCorner.x;
            right = tRCorner.x;
            bottom = bLCorner.y;
            top = tRCorner.y;
            topLeftCorner = new Vector2(left, top);
            topRightCorner = tRCorner;
            bottomRightCorner = new Vector2(right, bottom);
            bottomLeftCorner = bLCorner;
        }
    }
}
