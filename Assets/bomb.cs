using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject ExploadObj;
    public GameObject ExploadPos;
    CarMove carMove;

    Vector3 tmp;
    public GameObject car;
    int BombNumber;
    // Start is called before the first frame update
    void Start()
    {
        carMove = ExploadPos.GetComponent<CarMove>();
        tmp = car.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        BombNumber = carMove.ItemNumber;

        if ((Input.GetKeyDown(KeyCode.I)) && (BombNumber == 6))
        {
            myTransform.position = tmp;
            Instantiate (ExploadObj, ExploadPos.transform.position, Quaternion.identity);
        }
    }
}
