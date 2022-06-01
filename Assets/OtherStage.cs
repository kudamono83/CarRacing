﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherStage : MonoBehaviour
{
    public GameObject car;
    CarMove carMove;
    int Number;
    Color color;
    //MeshRenderer Color;

    // Start is called before the first frame update
    void Start()
    {
        carMove = car.GetComponent<CarMove>();
        color = gameObject.GetComponent<Renderer>().material.color;
        //color.a = 1.0f;
        //gameObject.GetComponent<Renderer>().material.color = color;
        //Color.material.color = Color.material.color + new Color32(0,0,0,127);
    }

    // Update is called once per frame
    void Update()
    {
        Number = carMove.UseItem;

        if (Number == 14)
        {
            color.a = 0.5f;
            gameObject.GetComponent<Renderer>().material.color = color;
        
        }
        else
        {
            color.a = 0.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        //else
        //{
            //color.a = 1.0f;
            //gameObject.GetComponent<Renderer>().material.color = color;
        //}
    }
}