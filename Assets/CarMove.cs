using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMove : MonoBehaviour
{
    const float ACCELERATION = 0.0005f;
    const float DECELERATION = -0.00125f;
    const float MAX_SPEED = 0.25f;
    const float MAX_BACK_SPEED = -1.0f;
    const float ROT_SPEED = 1.0f;

    int CheckPointNumber;

    int Stop;
    //public int CheckPointNumberPublic
    //{
    //    get{ return this.CheckPointNumber; }
    //    private set{ this.CheckPointNumber = value; }
    //}

    Rigidbody rb;
    float speed;
    float backSpeed;
    Vector3 move;

    Vector3 tmp;
    double y;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();

        CheckPointNumber = 0;

        //tmp = gameObject.GetComponent<Transform>().position;
        //y = tmp.y;

        transform.position = new Vector3(14,1,97);
        
        Stop = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 worldAngle = myTransform.eulerAngles;
        float world_angle_x = worldAngle.x;
        float world_angle_y = worldAngle.y;
        float world_angle_z = worldAngle.z;
        //worldAngle.x = -90.0f; 
        //worldAngle.y = 0.0f;
        //worldAngle.z = -1.0f;
        //myTransform.eulerAngles = worldAngle;

        //チートコマンド、CP1の前にワープ
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(-95,21,-95);
            worldAngle.x = -90.0f; 
            worldAngle.y = 0.0f;
            worldAngle.z = -181.0f;
            myTransform.eulerAngles = worldAngle;
        }


        tmp = gameObject.GetComponent<Transform>().position;
        y = tmp.y;

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

            if (Input.GetKey(KeyCode.Space) && backSpeed < MAX_BACK_SPEED) 
            {
                backSpeed += DECELERATION;
            }
            else 
            {
                if (backSpeed < 0 ) 
                {
                    backSpeed += ACCELERATION;
                }
                else 
                {
                backSpeed = 0;
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

            move = transform.up * (speed + backSpeed);

            rb.MovePosition(rb.position + move);

        }));

        if ((Input.GetKey(KeyCode.R)) || (y <= -10))
        {
            Stop = 1;

            if (CheckPointNumber == 0)
            {
                transform.position = new Vector3(14,1,97);
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
        }

        if (Stop == 1)
        {
            speed = 0.0f;

            Stop = 0;
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint") && (y <= 25))
        {
            CheckPointNumber = 1;

            //if (Input.GetKey(KeyCode.R))
            //{
                //transform.position = new Vector3(-95,21,-86);
                //transform.Rotate(0,180,0);
            //}
        }

        if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
        {
            CheckPointNumber = 2;
        }

        if (other.CompareTag("CheckPoint") && (y >= 31.5))
        {
            CheckPointNumber = 3;
        }
    }

    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}

//メモ
//次回やること：・時間表示において、大画面にするとテキストが見えなくなるのを直す
//その先　　　：・バックのプログラミングを作る or テキストの続きをやる
//参考URL 　 ：なし

// チェックポイント　→　ゴール　→　時間・その他モブやアイテム　→　最終的な目標はオンラインで対戦など



//CP場所記録　CP1 -95, 21,-86 180度回転
//　　　  　　CP2 -81, 31, 95 初期向きから左に90度回転
//　　  　　　CP3  95, 32, 24 0度
