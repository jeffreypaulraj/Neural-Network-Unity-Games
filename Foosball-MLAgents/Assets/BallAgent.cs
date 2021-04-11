using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class BallAgent : Agent
{
    int collisionCount;
    public GameObject goal;
    public GoalScript goalScript;
    int count;
    public override void OnActionReceived(float[] vectorAction)
    {
        if(transform.position.x > 2)
        {
            SetReward(-100);
            EndEpisode();
        }
        transform.Translate(2*vectorAction[0]*Time.deltaTime, 0, 2*vectorAction[1]*Time.deltaTime);
        count++;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        Vector3 newVector = (goal.transform.position - transform.position).normalized;
        sensor.AddObservation(newVector.x);
        sensor.AddObservation(newVector.z);
    }

    public void OnCollisionEnter(Collision collision)
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        if (collision.gameObject.name.Contains("Goal"))
        {
            AddReward(1000 - count/10);
            goalScript.GoalEndGame();
            EndEpisode();
        }
        else
        {
            collisionCount++;
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;
        actionsOut[1] = 0f;
        //Debug.Log("Heuristic Called");
        if (Input.GetKey(KeyCode.DownArrow))
        {
            actionsOut[1] = -1f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[1] = 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[0] = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[0] = 1f;
        }
    }

    public override void OnEpisodeBegin()
    {
        count = 0;
        collisionCount = 0;
        goalScript = (GoalScript)goal.GetComponent(typeof(GoalScript));
        transform.position = new Vector3(0, 0, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public void RestartGame()
    {
        AddReward(-1*transform.position.x);
        goalScript.GoalEndGame();
        EndEpisode();
    }
}
