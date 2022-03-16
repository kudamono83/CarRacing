using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private GameObject car;
    int LaserNumber;
    CarMove carMove;

    int HowManyTimes2;

    MeshRenderer mesh;

    Vector3 tmp;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find ("Car");
        carMove = car.GetComponent<CarMove>();

        //float x = tmp.x;
        //float y = tmp.y;
        //float z = tmp.z;
        tmp = car.transform.position;
        dir = car.transform.eulerAngles;

        //this.gameObject.SetActive(false);

        transform.position = new Vector3(15,-1,95);

        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = mesh.material.color - new Color32(0,0,0,255);

        HowManyTimes2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LaserNumber = carMove.ItemNumber;

        //Debug.Log ("AaAaAaAaAa");
        //Debug.Log (LaserNumber);

        if ((Input.GetKeyDown(KeyCode.I)) && (LaserNumber == 4))
        {
            HowManyTimes2 += 1;

            if (HowManyTimes2 == 3)
            {
                carMove.ItemNumber = 0;
                HowManyTimes2 = 0;
            }

            Debug.Log ("dekitemasu");
            mesh.material.color = mesh.material.color + new Color32(0,0,0,255);
            //transform.position = new Vector3 (x,y,z)
            transform.position = tmp;
            //this.gameObject.SetActive(true);
            //レーザーを動かすスクリプト
        }
    }
}
