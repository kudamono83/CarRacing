using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public GameObject Wall4;
    public GameObject Wall5;
    public GameObject Wall6;
    public GameObject Wall7;
    // Start is called before the first frame update
    void Start()
    {   	
        Wall4.SetActive (true);
        Wall5.SetActive (true);
        Wall6.SetActive (false);
        Wall7.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Wall6.SetActive (true);
            Wall7.SetActive (true);
            Wall4.SetActive (false);
            Wall5.SetActive (false);
        }
    }
}
