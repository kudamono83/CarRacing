using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject car;
    public GameObject Laser;
    CarMove carMove;
    int LaserNumber;
    float Rx;
    float Ry;
    float Rz;

    // Start is called before the first frame update
    void Start()
    {
        

        carMove = car.GetComponent<CarMove>();
    }

    // Update is called once per frame
    void Update()
    {
        LaserNumber = carMove.ItemNumber;

        Vector3 worldAngle = car.transform.eulerAngles;
        Rx = worldAngle.x;
        Ry = worldAngle.y;
        Rz = worldAngle.z;

        if ((Input.GetKeyDown(KeyCode.I)) && (LaserNumber == 4))
        //if (Input.GetKeyDown(KeyCode.I))
        {
            Shot ();
        }
    }

    void Shot()
    {
        GameObject obj;
        obj = GameObject.Instantiate (Laser);
        obj.transform.position = transform.position;
        obj.transform.Rotate(new Vector3(Rx+90.12f, Ry-6.70f, Rz+7.20f));
        obj.transform.localScale = new Vector3(0.02f, 0.02f, 3f);
        obj.GetComponent<Rigidbody> ().AddForce (transform.forward * -1000);
        
    }
}
