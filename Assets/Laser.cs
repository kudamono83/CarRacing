using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    GameObject Car;
    int LaserNumber;
    CarMove script;

    // Start is called before the first frame update
    void Start()
    {
        Car = GameObject.Find ("Car");
        script = Car.GetComponent<CarMove>();

        Vector3 tmp = Car.transform.position;
        Vector3 dir = Car.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        LaserNumber = script.UseItem;

        //Debug.Log (LaserNumber);

        if ((Input.GetKeyDown(KeyCode.I)) && (LaserNumber == 4))
        {
            //レーザーを動かすスクリプト
        }
    }
}
