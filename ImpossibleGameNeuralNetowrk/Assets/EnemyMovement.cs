using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool left;
    public int startX;
    // Start is called before the first frame update
    void Start()
    {
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= startX)
        {
            left = true;
        }
        else if(transform.position.x <= startX-8)
        {
            left = false;
        }

        if (left)
        {
            transform.Translate(Vector3.left/40);
        }
        else
        {
            transform.Translate(Vector3.right/40);
        }

    }
}
