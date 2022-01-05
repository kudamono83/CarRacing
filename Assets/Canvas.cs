using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Canvas : MonoBehaviour
{
    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //targetCamera1 = GameObject.Find ("MainCamera").GetComponent<Camera> ();
        //GameObject.Find("Canvas").GetComponent<Canvas>().worldCamera = targetCamera;
        //CanvasSituation.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Main Camera").camera;
        //Canvas canvas = gameObject.GetComponent<Canvas>();
        //canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(WaitSignal(4, () =>
        //{
            //if (Input.GetKeyDown(KeyCode.Alpha1))
            //{
                //CanvasSituation.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Main Camera").camera;
            //}

            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
                //CanvasSituation.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Camera2").camera;
            //}

           // if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
                //CanvasSituation.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Camera3").camera;
            //}

            //if (Input.GetKeyDown(KeyCode.Alpha4))
            //{
                //CanvasSituation.GetComponent<Canvas> ().worldCamera = GameObject.Find ("Camera4").camera;
            //}
        //}));
    }
}
