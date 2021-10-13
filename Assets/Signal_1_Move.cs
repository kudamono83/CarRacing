using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Signal_1_Move : MonoBehaviour
{
    [SerializeField]
    GameObject StartText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSignal(0, () =>
        {
            transform.localScale = Vector3.zero;
            StartText.SetActive(false);
        }));

        StartCoroutine(WaitSignal(3, () =>
        {
            transform.localScale = Vector3.one;
        }));

        StartCoroutine(WaitSignal(4, () =>
        {
            transform.localScale = Vector3.zero;
            StartText.SetActive(true);   
        }));

        StartCoroutine(WaitSignal(7, () =>
        {
            StartText.SetActive(false);   
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
        StartCoroutine(WaitSignal(0, () =>
        {
            //transform.localScale = Vector3.zero;
            //StartText.SetActive(false);
        }));

        //StartCoroutine(WaitSignal(3, () =>
        //{
            //transform.localScale = Vector3.one;
        //}));

        StartCoroutine(WaitSignal(4, () =>
        {
            //transform.localScale = Vector3.zero;
            //StartText.SetActive(true);   
        }));

        StartCoroutine(WaitSignal(7, () =>
        {
            //StartText.SetActive(false);   
        }));
    }
}
