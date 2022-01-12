using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Signal_1_Move : MonoBehaviour
{
    //[SerializeField]
    public GameObject StartText1;
    public GameObject StartText2;
    public GameObject StartText3;
    public GameObject StartText4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSignal(0, () =>
        {
            transform.localScale = Vector3.zero;
            StartText1.SetActive(false);
            StartText2.SetActive(false);
            StartText3.SetActive(false);
            StartText4.SetActive(false);
        }));

        StartCoroutine(WaitSignal(3, () =>
        {
            transform.localScale = Vector3.one;
        }));

        StartCoroutine(WaitSignal(4, () =>
        {
            transform.localScale = Vector3.zero;
            StartText1.SetActive(true);
            StartText2.SetActive(true);
            StartText3.SetActive(true);
            StartText4.SetActive(true);   
        }));

        StartCoroutine(WaitSignal(7, () =>
        {
            StartText1.SetActive(false);
            StartText2.SetActive(false);
            StartText3.SetActive(false);
            StartText4.SetActive(false);   
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
