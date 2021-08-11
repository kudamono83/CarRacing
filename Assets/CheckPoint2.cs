using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint2 : MonoBehaviour
{

    //public CarMove carMove;
    //int CheckPointpassed2;


    // Start is called before the first frame update
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.3f;
        gameObject.GetComponent<Renderer>().material.color = color;

        //CheckPointpassed2 = carMove.CheckPointNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log ("車を感知");
            //Pass1 = 1;

            GetComponent<Renderer>().material.color = Color.green;

            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0.4f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
