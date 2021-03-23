using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
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
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && count > 1) {
            count--;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && count < 4){
            count++;
        }

        if(count == 1){
            if (Input.GetKeyDown(KeyCode.UpArrow) && goalie.transform.position.z <= 7.5f )
            {
                goalie.transform.Translate(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && goalie.transform.position.z >= -7.5f)
            {
                goalie.transform.Translate(Vector3.back);
            }
        }
        else if (count == 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && rowOne_One.transform.position.z <= 7.5f)
            {
                rowOne_One.transform.Translate(Vector3.forward);
                rowOne_Two.transform.Translate(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rowOne_Two.transform.position.z >= -7.5f)
            {
                rowOne_One.transform.Translate(Vector3.back);
                rowOne_Two.transform.Translate(Vector3.back);
            }
        }
        else if(count == 3)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && rowTwo_One.transform.position.z <= 7.5f)
            {
                rowTwo_One.transform.Translate(Vector3.forward);
                rowTwo_Two.transform.Translate(Vector3.forward);
                rowTwo_Three.transform.Translate(Vector3.forward);

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rowTwo_Three.transform.position.z >= -7.5f)
            {
                rowTwo_One.transform.Translate(Vector3.back);
                rowTwo_Two.transform.Translate(Vector3.back);
                rowTwo_Three.transform.Translate(Vector3.back);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && rowThree_One.transform.position.z <= 7.5f)
            {
                rowThree_One.transform.Translate(Vector3.forward);
                rowThree_Two.transform.Translate(Vector3.forward);
                rowThree_Three.transform.Translate(Vector3.forward);
                rowThree_Four.transform.Translate(Vector3.forward);
                rowThree_Five.transform.Translate(Vector3.forward);

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && rowThree_Five.transform.position.z >= -7.5f)
            {
                rowThree_One.transform.Translate(Vector3.back);
                rowThree_Two.transform.Translate(Vector3.back);
                rowThree_Three.transform.Translate(Vector3.back);
                rowThree_Four.transform.Translate(Vector3.back);
                rowThree_Five.transform.Translate(Vector3.back);
            }
        }
        Debug.Log(count);
    }
}
