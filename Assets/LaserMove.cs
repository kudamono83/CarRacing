using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position -= this.gameObject.transform.forward;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "test")
        {
            Debug.Log("反応あり");
            Destroy(collision.gameObject);
        }
    }
}