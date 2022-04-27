using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //public GameObject car;
    public GameObject Laser;

    // Start is called before the first frame update
    void Start()
    {
        

        //carMove = car.GetComponent<CarMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //LaserNumber = carMove.ItemNumber;

        //Transform myTransform = this.transform;
        //Vector3 worldAngle = transform.eulerAngles;

        //if ((Input.GetKeyDown(KeyCode.I)) && (LaserNumber == 4))
        if (Input.GetKeyDown(KeyCode.I))
        {
            Shot ();
        }
    }

    void Shot()
    {
        GameObject obj;
        obj = GameObject.Instantiate (Laser);
        //obj.transform.Rotate(new Vector3(90f, 90f, 90f));
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody> ().AddForce (transform.forward * -1000);
    }
}
