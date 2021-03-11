﻿using System.Collections;
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

    public override void OnActionReceived(float[] vectorAction)
    {
        if(goalie.transform.position.z <= 7.5f && goalie.transform.position.z >- -7.5f)
        {
            goalie.transform.Translate(Vector3.forward * vectorAction[0] * Time.deltaTime);
        }

        if(rowOne_One.transform.position.z <= 7.5f && rowOne_Two.transform.position.z >= -7.5f)
        {
            rowOne_One.transform.Translate(Vector3.forward * vectorAction[1] * Time.deltaTime);
            rowOne_Two.transform.Translate(Vector3.forward * vectorAction[1] * Time.deltaTime);
        }

        if(rowTwo_One.transform.position.z <= 7.5f && rowTwo_Three.transform.position.z >= -7.5f)
        {
            rowTwo_One.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
            rowTwo_Two.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
            rowTwo_Three.transform.Translate(Vector3.forward * vectorAction[2] * Time.deltaTime);
        }

        if (rowThree_One.transform.position.z <= 7.5f && rowThree_Five.transform.position.z >= -7.5f)
        {
            rowThree_One.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
            rowThree_Two.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
            rowThree_Three.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
            rowThree_Four.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
            rowThree_Five.transform.Translate(Vector3.forward * vectorAction[3] * Time.deltaTime);
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
            SetReward(1000);
            EndEpisode();
        }
    }

    public override void OnEpisodeBegin()
    {
        ball.transform.position = new Vector3(0, 0, 0);
        float directionX = Random.Range(-4.0f, 4.0f);
        float directionZ = Random.Range(-4.0f, 4.0f);

        ball.GetComponent<Rigidbody>().AddForce(new Vector3(directionX, 0, directionZ));
    }
}
