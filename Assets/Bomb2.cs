using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    public GameObject Obj;
    public GameObject car;
    Exploder exploder;
    CarMove carMove;

    // Start is called before the first frame update
    void Start()
    {
        carMove = car.GetComponent<CarMove>();
        exploder = Obj.GetComponent<Exploder>();
    }

    // Update is called once per frame
    void Update()
    {
        //tmp = car.transform.position;
        //Transform myTransform = this.transform;
        BombNumber = carMove.ItemNumber;

        if ((Input.GetKeyDown(KeyCode.I)) && (BombNumber == 6))
        {
            exploder.enabled  = true;
        }
    }
}
