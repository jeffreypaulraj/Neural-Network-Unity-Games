using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class PlayerMovement : Agent
{
    int count = 8000;
    public GameObject goal;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject enemyThree;
    public GameObject enemyFour;

    public float playerStartX;
    public float playerStartZ;
    public float enemyStartX;
    public float enemyStartZ;

    public override void OnActionReceived(float[] vectorAction)
    {
        count--;
        if(count <= 0)
        {
            SetReward( -420 + transform.position.z*10);
            EndEpisode();
        }
        transform.Translate(new Vector3(vectorAction[0] * Time.deltaTime, 0, vectorAction[1] * Time.deltaTime));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Vector3.Dot(transform.position, goal.transform.position));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Enemy")
        {
            SetReward(-1500 + transform.position.z * 10);
            EndEpisode();
        }
        if (other.gameObject.tag == "Goal")
        {
            SetReward(10000);
            EndEpisode();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Hit");
    //    if(collision.gameObject.tag == "Enemy")
    //    {
    //        SetReward(-200 + transform.position.z * 10);
    //        EndEpisode();
    //    }
    //    else
    //    {
    //        SetReward(10000);
    //        EndEpisode();
    //    }
    //}
    
    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(playerStartX, 0.5f, playerStartZ);
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        enemyOne.transform.position = new Vector3(enemyStartX, 0.5f, enemyStartZ);
        enemyTwo.transform.position = new Vector3(enemyStartX-8, 0.5f, enemyStartZ+3);
        enemyThree.transform.position = new Vector3(enemyStartX, 0.5f, enemyStartZ+6);
        enemyFour.transform.position = new Vector3(enemyStartX-8, 0.5f, enemyStartZ+9);
        count = 8000;
        Debug.Log("started");
    }
}
