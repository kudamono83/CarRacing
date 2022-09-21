using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    public GameObject car;
    CarMove carMove;
    int BombNumber;
    public GameObject obj;
    Exploder exploder;
 
    // Start is called before the first frame update
    void Start()
    {
        carMove = car.GetComponent<CarMove>();
        obj.SetActive(false);
        //StartCoroutine("SphereAppear");
        //obj.SetActive(true);  
	    //Destroy(obj); 
    }

    //IEnumerator Appear()
    //{
        //obj.SetActive(true);
    //}

    // Update is called once per frame
    void Update()
    {
        BombNumber = carMove.ItemNumber;

        if ((Input.GetKey(KeyCode.I)) && (BombNumber == 6))
        {
            obj.SetActive(true);
            obj.transform.position = new Vector3(15.20303f,4.0f,97.06855f);
            //StartCoroutine("Appear");
        }
    }

    
}
