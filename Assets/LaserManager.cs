using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject Laser;
    GameObject cloneObject;
    //public GameObject Launcher;
    //private Rigidbody rb;
    //private float speed;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Transform LasTransform = Laser.transform;
        Vector3 worldAngle = LasTransform.eulerAngles;
        Vector3 pos = LasTransform.position;

        if (Input.GetKeyDown(KeyCode.T))
        {
            cloneObject = Instantiate(Laser, pos, Quaternion.identity);
            cloneObject.transform.localScale = new Vector3(0.05f, 0.05f, 2.5f);
            cloneObject.transform.eulerAngles = worldAngle;
            //rb.velocity = cloneObject.transform.forward * speed;
            //cloneObject.GetComponent<Rigidbody> ().AddForce (transform.forward * -1000);
            //cloneObject.transform.parent = Launcher.transform;
            //cloneObject.transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
        }
        cloneObject.transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
    }
    
    
}
