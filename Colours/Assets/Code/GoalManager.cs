using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public Goal redGoal;
    public Goal blueGoal;
    public string SceneName;

    private void Update()
    {
        GoalCheck();    
    }
    void GoalCheck()
    {
        if (redGoal.isGoalReached == true && blueGoal.isGoalReached == true)
        {
            StartCoroutine("DelayLoadLevel");
        }
    }

    IEnumerator DelayLoadLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneName);
    }
}
