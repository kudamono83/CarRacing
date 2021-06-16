using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Signal_3_Back_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSignal(0, () =>
        {
            transform.localScale = Vector3.zero;
        }));

        StartCoroutine(WaitSignal(1, () =>
        {
            transform.localScale = Vector3.one;
        }));

        StartCoroutine(WaitSignal(2, () =>
        {
            transform.localScale = Vector3.zero;
        }));

        StartCoroutine(WaitSignal(4, () =>
        {
            transform.localScale = Vector3.one;
        }));

        StartCoroutine(WaitSignal(6, () =>
        {
            transform.localScale = Vector3.zero;
        }));
    }
    
    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
