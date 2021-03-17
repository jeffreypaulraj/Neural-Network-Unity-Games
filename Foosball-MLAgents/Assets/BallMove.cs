﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Team 1"))
        {
            Debug.Log("Team One Hit");
            float directionZ = Random.Range(-10.0f, 10.0f);
            float directionX = Random.Range(2.0f, 8.0f);
            rb.AddForce(new Vector3(directionX, 0, directionZ));
        }
        else
        {
            Debug.Log("Team Two Hit");
            float directionZ = Random.Range(-10.0f, 10.0f);
            float directionX = Random.Range(-8.0f, -2.0f);
            rb.AddForce(new Vector3(directionX, 0, directionZ));
        }
    }
}
