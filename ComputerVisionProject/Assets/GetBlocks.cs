using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class GetBlocks : Agent
{
    public GameObject blockOne;
    public GameObject blockTwo;
    public GameObject blockThree;
    public GameObject blockFour;
    public GameObject blockFive;
    public GameObject blockSix;
    public GameObject blockSeven;
    public GameObject blockEight;
    public GameObject target;
    int count;
    int redCount;
    bool[] hitValues;

    public override void OnActionReceived(float[] vectorAction)
    {
        if(count > 0)
        {
            transform.Translate(new Vector3(vectorAction[0]*Time.deltaTime, 0, 0.2f*Time.deltaTime));
            transform.Rotate(new Vector3(0, 0, vectorAction[2] * Time.deltaTime));
            count--;
        }
        else
        {
            AddReward(-500);
            EndEpisode();
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(target.transform.position);
    }

    public override void OnEpisodeBegin()
    {
        count = 1500;
        hitValues = new bool[]{false,false,false,false};
        target.layer = 10;

        transform.position = new Vector3(0, 0.5f, -3f);
        blockOne.transform.position = new Vector3(1f, 1.5f, 2f);
        blockTwo.transform.position = new Vector3(4f, 1.5f, 2f);
        blockThree.transform.position = new Vector3(-2f, 1.5f, 2f);
        blockFour.transform.position = new Vector3(-5f, 1.5f, 2f);

        blockFive.transform.position = new Vector3(1f, 1.5f, -0.5f);
        blockSix.transform.position = new Vector3(4f, 1.5f, -0.5f);
        blockSeven.transform.position = new Vector3(-2f, 1.5f, -0.5f);
        blockEight.transform.position = new Vector3(-5f, 1.5f, -0.5f);

        target.transform.position = new Vector3(Random.Range(-4.0f,4.0f), 0.5f, 4.0f);

        transform.eulerAngles = new Vector3(0, 0, 0);
        blockOne.transform.eulerAngles = new Vector3(0, 0, 0);
        blockTwo.transform.eulerAngles = new Vector3(0, 0, 0);
        blockThree.transform.eulerAngles = new Vector3(0, 0, 0);
        blockFour.transform.eulerAngles = new Vector3(0, 0, 0);

        blockFive.transform.eulerAngles = new Vector3(0, 0, 0);
        blockSix.transform.eulerAngles = new Vector3(0, 0, 0);
        blockSeven.transform.eulerAngles = new Vector3(0, 0, 0);
        blockEight.transform.eulerAngles = new Vector3(0, 0, 0);

        changeColor(blockOne, false);
        changeColor(blockTwo, false);
        changeColor(blockThree, false);

        bool redExists = (redCount == 0);
        changeColor(blockFour, redExists);

        changeColor(blockFive, false);
        changeColor(blockSix, false);
        changeColor(blockSeven, false);

        redExists = (redCount == 1);
        changeColor(blockEight, redExists);

        redCount = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("Hit Red");
            AddReward(100 + count/2);
            collision.gameObject.transform.position = new Vector3(-30.0f, 1.5f, 2.0f);
        }
        else if(collision.gameObject.layer == 9)
        {
            Debug.Log("Hit Blue");
            SetReward(-500);
            EndEpisode();
        }
        else if(collision.gameObject.layer == 10)
        {
            Debug.Log("Hit Target");
            AddReward(700);
            EndEpisode();
        }
    }

    public void changeColor(GameObject block, bool redExists)
    {
        float random = Random.Range(-1.0f, 1.0f);
        if (random < 0 || redExists)
        {
            block.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            block.layer = 8;
            redCount++;
        }
        else
        {
            block.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            block.layer = 9;
        }
    }

}
