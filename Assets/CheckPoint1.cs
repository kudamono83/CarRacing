using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : MonoBehaviour
{

    public CarMove carMove;
    int CheckPointpassed1;


    // Start is called before the first frame update
    void Start()
    {
        CheckPointpassed1 = carMove.CheckPointNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
