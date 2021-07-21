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

    public int CheckPointNumber;

    Rigidbody rb;
    float speed;
    float backSpeed;
    Vector3 move;

    Vector3 tmp;
    float y;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();

        CheckPointNumber = 0;

        tmp = gameObject.GetComponent<Transform>().position;
        y = tmp.y;

    }

    // Update is called once per frame
    void Update()
    {
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
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.name == "CheckPoint") && (y <= 25))
        {
            CheckPointNumber = 1;

            if ((collision.gameObject.name == "CheckPoint") && (y >= 26) && (y <= 31.4))
            {
                CheckPointNumber = 2;

                if ((collision.gameObject.name == "CheckPoint") && (y >= 31.5))
                {
                    CheckPointNumber = 3;
                }
            }
        }
    }

    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}

//メモ
//次回やること：・半透明のやつの「車に触れたら透明度を変える」スクリプトを作る
//その先　　　：・バックのプログラミングを作る or テキストの続きをやる
//　  参考URL：https://kuroko-labo.com/オブジェクトをスクリプトで半透明にする/
//　　　　　　：https://toburau.hatenablog.jp/entry/20170731/1501518531

// チェックポイント　→　ゴール　→　時間・その他モブやアイテム　→　最終的な目標はオンラインで対戦など
