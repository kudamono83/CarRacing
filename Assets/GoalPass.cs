using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = 0.3f;
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GetComponent<Renderer>().material.color = Color.red;

            Color color = gameObject.GetComponent<Renderer>().material.color;
            color.a = 0.4f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
