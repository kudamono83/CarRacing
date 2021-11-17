﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarMove : MonoBehaviour
{
    const float ACCELERATION = 0.00025f;
    const float DECELERATION = -0.001f;
    const float BACKACCELERATION = 0.00015f;
    const float BACKDECELERATION = -0.00075f;
    const float MAX_SPEED = 0.25f;
    const float MAX_BREAK_SPEED = -1.0f;
    const float MAX_BACK_SPEED = 0.125f;
    const float ROT_SPEED = 1.0f;

    int CheckPointNumber;
    //int OldCheckPointNumber;
    int TextOnOff;

    int Stop;

    //[SerializeField]
    public GameObject Text;

    //[SerializeField]
    public GameObject GoalText;

    public Text SpeedText;

    //public Camera mainCamera;
    //public Camera subCamera;

    //public Text ReverseRunText;
    //public int CheckPointNumberPublic
    //{
    //    get{ return this.CheckPointNumber; }
    //    private set{ this.CheckPointNumber = value; }
    //}

    Rigidbody rb;
    float speed;
    float breakSpeed;
    float backSpeed;
    //int kph;
    //float bendSpeed;
    //float reallybackSpeed;
    Vector3 move;

    Vector3 tmp;
    double y;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        breakSpeed = 0;
        backSpeed = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();

        CheckPointNumber = 0;
        //Text.SetActive(false);
        //OldCheckPointNumber = -1;
        TextOnOff = 0;

        GoalText.SetActive(false);

        //tmp = gameObject.GetComponent<Transform>().position;
        //y = tmp.y;

        transform.position = new Vector3(15,1,97);
        
        Stop = 0;

        //mainCamera = GameObject.Find("MainCamera");
        //subCamera = GameObject.Find("SubCamera");

        //subCamera.enabled(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log ();

        int kph = Mathf.RoundToInt(500 * (speed + breakSpeed + backSpeed));
        SpeedText.text = kph.ToString("000");

        Transform myTransform = this.transform;
        Vector3 worldAngle = myTransform.eulerAngles;
        float world_angle_x = worldAngle.x;
        float world_angle_y = worldAngle.y;
        float world_angle_z = worldAngle.z;
        //worldAngle.x = -90.0f; 
        //worldAngle.y = 0.0f;
        //worldAngle.z = -1.0f;
        //myTransform.eulerAngles = worldAngle;

        //チートコマンド、CPのあたりにワープ
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = new Vector3(-95,21,-95);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = -181.0f;
            myTransform.eulerAngles = worldAngle;
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.position = new Vector3(-90,31,95);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = -91.0f;
            myTransform.eulerAngles = worldAngle;
        }

        if (Input.GetKey(KeyCode.V))
        {
            transform.position = new Vector3(95,32,30);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = -1.0f;
            myTransform.eulerAngles = worldAngle;
        }

        if (Input.GetKey(KeyCode.B))
        {
            transform.position = new Vector3(-6,42,5);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = 89.0f;
            myTransform.eulerAngles = worldAngle;
        }

        if (Input.GetKey(KeyCode.N))
        {
            transform.position = new Vector3(6,43,-2);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = 89.0f;
            myTransform.eulerAngles = worldAngle;
        }


        tmp = gameObject.GetComponent<Transform>().position;
        y = tmp.y;

        //if (TextOnOff == 0)
        //{
            //ReverseRunText.text.SetActive(false);
        //}

        //if (TextOnOff == 1)
        //{
            //ReverseRunText.text.SetActive(true);
        //}


        StartCoroutine(WaitSignal(4, () =>
        {
            if (Input.GetKey(KeyCode.UpArrow) && speed < MAX_SPEED) 
            {
                speed += ACCELERATION;
            }
            else 
            {
                if (speed > 0 ) 
                {
                    speed += DECELERATION;
                }
                else 
                {
                    speed = 0;
                }
            }

            if (Input.GetKey(KeyCode.DownArrow) && backSpeed < MAX_BACK_SPEED) 
            {
                backSpeed -= BACKACCELERATION;
            }
            else 
            {
                if (backSpeed < 0 ) 
                {
                    backSpeed -= BACKDECELERATION;
                }
                else 
                {
                    backSpeed = 0;
                }
            }

            //if (Input.GetKey(KeyCode.DownArrow) && speed < MAX_BACK_SPEED) 
            //{
                //backSpeed += BACKACCELERATION;
            //}
            //else 
            //{
                //if (backSpeed < 0 ) 
                //{
                    //backSpeed += BACKDECELERATION;
                //}
                //else 
                //{
                //backSpeed = 0;
                //}
            //}

            if (Input.GetKey(KeyCode.Space) && breakSpeed < MAX_BREAK_SPEED) 
            {
                breakSpeed += DECELERATION;
            }
            else 
            {
                if (breakSpeed < 0 ) 
                {
                    breakSpeed += ACCELERATION;
                }
                else 
                {
                    breakSpeed = 0;
                }
            }

            if (Input.GetKey(KeyCode.RightArrow)) 
            {
                Quaternion turnRotation = Quaternion.Euler(0f, 0f, ROT_SPEED);
                rb.MoveRotation(rb.rotation * turnRotation);
            }

            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                Quaternion turnRotation = Quaternion.Euler(0f, 0f, -ROT_SPEED);
                rb.MoveRotation(rb.rotation * turnRotation);
            }


            //if(Input.GetKey(KeyCode.C))
            //{
                //if(mainCamera.enabled(true))
                //{
                    //mainCamera.enabled(false);
                    //subCamera.enabled(true);
                //}

                //if(subCamera.enabled(true))
                //{
                    //mainCamera.enabled(true);
                    //subCamera.enabled(false);
                //}
            //}


            //reallybackSpeed = backSpeed / backSpeed * 2;

            move = transform.up * (speed + breakSpeed + backSpeed);

            rb.MovePosition(rb.position + move);

        }));

        if ((Input.GetKey(KeyCode.R)) || (y <= -10))
        {
            Stop = 1;
            speed = 0;
            breakSpeed = 0;
            backSpeed = 0;

            if (CheckPointNumber == 0)
            {
                transform.position = new Vector3(15,1,97);
                worldAngle.x = -90.0f; 
                worldAngle.y = 0.0f;
                worldAngle.z = -1.0f;
                myTransform.eulerAngles = worldAngle;
            }

            if (CheckPointNumber == 1)
            {
                transform.position = new Vector3(-95,21,-86);
                worldAngle.x = -90.0f; 
                worldAngle.y = 0.0f;
                worldAngle.z = -181.0f;
                myTransform.eulerAngles = worldAngle;
            }

            if (CheckPointNumber == 2)
            {
                transform.position = new Vector3(-81,31,95);
                worldAngle.x = -90.0f; 
                worldAngle.y = 0.0f;
                worldAngle.z = -91.0f;
                myTransform.eulerAngles = worldAngle;
            }

            if (CheckPointNumber == 3)
            {
                transform.position = new Vector3(95,32,24);
                worldAngle.x = -90.0f; 
                worldAngle.y = 0.0f;
                worldAngle.z = -1.0f;
                myTransform.eulerAngles = worldAngle;
            }

            if (CheckPointNumber == 4)
            {
                transform.position = new Vector3(-10,42,5);
                worldAngle.x = -90.0f; 
                worldAngle.y = 0.0f;
                worldAngle.z = 89.0f;
                myTransform.eulerAngles = worldAngle;
            }
        }

        if (Stop == 1)
        {
            speed = 0.0f;

            Stop = 0;
        }

        if (TextOnOff == 0)
        {
            Text.SetActive(false);
        }
        if (TextOnOff == 1)
        {
            Text.SetActive(true);

            if (Input.GetKey(KeyCode.R))
            {
                TextOnOff = 0;
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint") && (y <= 25))
            {

                if (CheckPointNumber <= 1)
                //if (OldCheckPointNumber == -1)
                {
                    CheckPointNumber = 1;
                    //TextOnOff = 0;
                    //OldCheckPointNumber = 0;
                }
                else
                {
                    //if ((Input.GetKey(KeyCode.R)) || (other.CompareTag("CheckPoint") && (y >= 26)))
                    //{
                        //Text.SetActive(false);
                    //}
                    //else
                    //{
                        //Text.SetActive(true);
                        TextOnOff = 1;
                        
                    //}
                     //Debug.Log("逆走しているよ！");
                     //transform.position = new Vector3(0,-10,0);
                }

                

            //if (Input.GetKey(KeyCode.R))
            //{
                //transform.position = new Vector3(-95,21,-86);
                //transform.Rotate(0,180,0);
            //}
            }

        if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
            {
                if (CheckPointNumber <= 2)
                //if (OldCheckPointNumber == 0)
                {
                    CheckPointNumber = 2;
                    //TextOnOff = 0;
                    //OldCheckPointNumber = 1;
                }
                else
                {
                    TextOnOff = 1;
                    //if ((Input.GetKey(KeyCode.R)) || (other.CompareTag("CheckPoint") && (y >= 31.5)))
                    //{
                        //Text.SetActive(false);
                    //}
                    //else
                    //{
                        //Text.SetActive(true);
                    //}
                    //Debug.Log("逆走しているよ！");
                    //transform.position = new Vector3(0,-10,0);
                }
            }

        if (other.CompareTag("CheckPoint") && (y >= 31.5))
            {
                //if (OldCheckPointNumber == 1)
                //{
                    CheckPointNumber = 3;
                    //TextOnOff = 0;
                    //OldCheckPointNumber = 2;
                //}
                //else
                //{
                    //Debug.Log("逆走しているよ！");
                    //transform.position = new Vector3(0,-10,0);
                //}
            }
        
        if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
        {
            if (CheckPointNumber == 2)
            {
                if (TextOnOff == 1)
                {
                    TextOnOff = 0;
                }
            }
        }

        if (other.CompareTag("CheckPoint") && (y >= 31.5))
        {
            if (CheckPointNumber == 3)
            {
                if (TextOnOff == 1)
                {
                    TextOnOff = 0;
                }
            }
        }

        if (other.CompareTag("Finish"))
        {
            GoalText.SetActive(true);
            CheckPointNumber = 4;
        }


        //

        //if (CheckPointNumber == 0)
        //{
            //if (other.CompareTag("CheckPoint") && (y <= 25))
            //{
                //CheckPointNumber = 1;

            //if (Input.GetKey(KeyCode.R))
            //{
                //transform.position = new Vector3(-95,21,-86);
                //transform.Rotate(0,180,0);
            //}
            //}
        //}

        //if (CheckPointNumber == 1)
        //{
            //if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
            //{
                //CheckPointNumber = 2;
            //}
        //}

        //if (CheckPointNumber == 2)
        //{
            //if (other.CompareTag("CheckPoint") && (y >= 31.5))
            //{
                //CheckPointNumber = 3;
            //}
        //}
    }

    //void OnTriggerExit(Collider other)
    //{
        //if (other.CompareTag("CheckPoint") && (y <= 25))
        //{
            //if (CheckPointNumber == 1)
            //{
                //CheckPointNumber = 1;
                // OldCheckPointNumber = 0;
                //TextOnOff = 0;
            //}
            //else
            //{
                //Debug.Log("逆走しているよ！");
                //TextOnOff = 1;
                //transform.position = new Vector3(0,-10,0);
            //}
        //}

        //if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
        //{
            //if (CheckPointNumber == 2)
            //{
                //CheckPointNumber = 2;
                //OldCheckPointNumber = 1;
                //TextOnOff = 0;
            //}
            //else
            //{
                //Debug.Log("逆走しているよ！");
                //TextOnOff = 1;
                //transform.position = new Vector3(0,-10,0);
            //}
        //}

        //if (other.CompareTag("CheckPoint") && (y >= 31.5))
        //{
            //if (CheckPointNumber == 3)
            //{
                //CheckPointNumber = 3;
                //OldCheckPointNumber = 2;
                //TextOnOff = 0;
            //}
            //else
            //{
                //Debug.Log("逆走しているよ！");
                //TextOnOff = 1;
                //transform.position = new Vector3(0,-10,0);
            //}
        //}
    //}

    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}

//メモ
//次回やること：時速表示
//その先　　　：・カメラ視点変更　・モブ、アイテム　・最終的にはオンライン、対戦など
//参考URL 　 ：https://knb-mayumi.com/unity-camerachange/ でできるはず

//時速表示メモ：車の全長が6mmの時、コースの幅は77mm　現実はこの800倍、よって480cmの時、6160cmになる
//　　　　　　：多分これ使わない


//CP場所記録　CP1 -95, 21,-86 180度回転
//　　　  　　CP2 -81, 31, 95 初期向きから左に90度回転
//　　  　　　CP3  95, 32, 24 0度