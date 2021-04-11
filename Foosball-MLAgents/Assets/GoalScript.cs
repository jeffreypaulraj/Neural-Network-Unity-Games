using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class GoalScript : Agent
{
    public GameObject goalie;
    public GameObject rowOne_One;
    public GameObject rowOne_Two;
    public GameObject rowTwo_One;
    public GameObject rowTwo_Two;
    public GameObject rowTwo_Three;
    public GameObject rowThree_One;
    public GameObject rowThree_Two;
    public GameObject rowThree_Three;
    public GameObject rowThree_Four;
    public GameObject rowThree_Five;
    public GameObject ball;
    public int multiplier;
    public BallMove scriptB;
    public BallAgent ballBrainScript;
    int count = 10000;
    int collisionCount = 0;

    public override void OnActionReceived(float[] vectorAction)
    {
        if (count > 0)
        {
            if (goalie.transform.position.z <= 7.5f && goalie.transform.position.z >= -7.5f)
            {
                goalie.transform.Translate(Vector3.forward * vectorAction[0] * Time.deltaTime);
            }
            else
            {
                Debug.Log("Wall hit 1");
                collisionCount = scriptB.getCollisionCount();
                SetReward(-1 * multiplier * ball.transform.position.x + 10*collisionCount);
                EndEpisode();

            }

            if (rowOne_One.transform.position.z <= 7.5f && rowOne_Two.transform.position.z >= -7.5f)
            {
                rowOne_One.transform.Translate(Vector3.forward * vectorAction[1] * Time.deltaTime);
                rowOne_Two.transform.Translate(Vector3.forward * vectorAction[1] * Time.deltaTime);
            }
            else
            {
                Debug.Log("Wall hit 2");
                collisionCount = scriptB.getCollisionCount();
                SetReward(-1 * multiplier * ball.transform.position.x + 10 * collisionCount - count);
                EndEpisode();

            }

            if (rowTwo_One.transform.position.z <= 7.5f && rowTwo_Three.transform.position.z >= -7.5f)
            {
                rowTwo_One.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
                rowTwo_Two.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
                rowTwo_Three.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
            }
            else
            {
                Debug.Log("Wall hit 3");
                collisionCount = scriptB.getCollisionCount();
                SetReward(-1 * multiplier * ball.transform.position.x + 10 * collisionCount - count);
                EndEpisode();
            }

            if (rowThree_One.transform.position.z <= 7.5f && rowThree_Five.transform.position.z >= -7.5f)
            {
                rowThree_One.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
                rowThree_Two.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
                rowThree_Three.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
                rowThree_Four.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
                rowThree_Five.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
            }
            else
            {
                Debug.Log("Wall hit 4");
                collisionCount = scriptB.getCollisionCount();
                SetReward(-1 * multiplier * ball.transform.position.x + 10 * collisionCount - count);
                EndEpisode();
            }
            count--;
        }
        else
        {
            collisionCount = scriptB.getCollisionCount();
            SetReward(-1 * multiplier * ball.transform.position.x + 10 * collisionCount - count);
            EndEpisode();
        }

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(ball.transform.position);
        sensor.AddObservation(goalie.transform.position);
        sensor.AddObservation(rowOne_One.transform.position);
        sensor.AddObservation(rowOne_Two.transform.position);
        sensor.AddObservation(rowTwo_One.transform.position);
        sensor.AddObservation(rowTwo_Two.transform.position);
        sensor.AddObservation(rowTwo_Three.transform.position);
        sensor.AddObservation(rowThree_One.transform.position);
        sensor.AddObservation(rowThree_Two.transform.position);
        sensor.AddObservation(rowThree_Three.transform.position);
        sensor.AddObservation(rowThree_Four.transform.position);
        sensor.AddObservation(rowThree_Five.transform.position);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            SetReward(-1000);

            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        count = 20000;
        scriptB = (BallMove)ball.GetComponent(typeof(BallMove));
        scriptB.resetCollisions();

        ballBrainScript = (BallAgent)ball.GetComponent(typeof(BallAgent));
        //ballBrainScript.RestartGame();

        //ball.transform.position = new Vector3(0, 0, 0);
        //float directionX = Random.Range(-10.0f, 0.0f);
        //float directionZ = Random.Range(-10.0f, 10.0f);
        //ball.GetComponent<Rigidbody>().AddForce(new Vector3(5*directionX, 0, 5*directionZ));

        goalie.transform.position = new Vector3(multiplier * 16, 0, 0);

        rowOne_One.transform.position = new Vector3(multiplier * 12, 0, 2.5f);
        rowOne_Two.transform.position = new Vector3(multiplier * 12, 0, -2.5f);

        rowTwo_One.transform.position = new Vector3(multiplier * 7, 0, 5.0f);
        rowTwo_Two.transform.position = new Vector3(multiplier * 7, 0, 0f);
        rowTwo_Three.transform.position = new Vector3(multiplier * 7, 0, -5.0f);

        rowThree_One.transform.position = new Vector3(multiplier * 2.3f, 0, 6.0f);
        rowThree_Two.transform.position = new Vector3(multiplier * 2.3f, 0, 3.0f);
        rowThree_Three.transform.position = new Vector3(multiplier * 2.3f, 0, 0f);
        rowThree_Four.transform.position = new Vector3(multiplier * 2.3f, 0, -3.0f);
        rowThree_Five.transform.position = new Vector3(multiplier * 2.3f, 0, -6.0f);

        rowOne_One.transform.eulerAngles = new Vector3(0, 0, 0);
        rowOne_Two.transform.eulerAngles = new Vector3(0, 0, 0);

        rowTwo_One.transform.eulerAngles = new Vector3(0,0,0);
        rowTwo_Two.transform.eulerAngles = new Vector3(0, 0, 0);
        rowTwo_Three.transform.eulerAngles = new Vector3(0, 0, 0);

        rowThree_One.transform.eulerAngles = new Vector3(0, 0, 0);
        rowThree_Two.transform.eulerAngles = new Vector3(0, 0, 0);
        rowThree_Three.transform.eulerAngles = new Vector3(0, 0, 0);
        rowThree_Four.transform.eulerAngles = new Vector3(0, 0, 0);
        rowThree_Five.transform.eulerAngles = new Vector3(0, 0, 0);

    }

    public void GoalEndGame()
    {
        AddReward(-200);
        EndEpisode();
    }
}
