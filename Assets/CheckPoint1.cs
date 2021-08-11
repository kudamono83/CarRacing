using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{
    //int Pass1;

    //public CarMove carMove;
    //int CheckPointpassed1;

    //Color color = gameObject.GetComponent<Renderer>().material.color;

    // Start is called before the first frame update
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.3f;
        gameObject.GetComponent<Renderer>().material.color = color;

        //Pass1 = 0;

        //CheckPointpassed1 = carMove.CheckPointNumber;
        //int CheckPointpassed1;
        //CheckPointpassed1 = carMove.CheckPointNumberPublic();
        //Debug.Log(CheckPointpassed1);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log (Pass1);
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
