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

        transform.position = new Vector3(14,1,97);
        transform.Rotate(0,0,0);


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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint") && (y <= 25))
        {
            CheckPointNumber = 1;

            if (Input.GetKey(KeyCode.R))
            {
                transform.position = new Vector3(-95,21,-86);
                transform.Rotate(0,180,0);
            }

            if (other.CompareTag("CheckPoint") && (y >= 26) && (y <= 31.4))
            {
                CheckPointNumber = 2;

                if (other.CompareTag("CheckPoint") && (y >= 31.5))
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
//次回やること：・半透明のやつの「車に触れたら透明度を変える」スクリプトを作る、チェックポイントの座標指定
//　　　　　　：・具体的に次やることをいうと、「Rを押したか、yが-10以下になったら、さらにもしチェックポイントナンバー=?ならどこにリスポーンする」をvoid Updateの中にいれる！座標をどうするかを下の仮記録に記入が先。
//その先　　　：・バックのプログラミングを作る or テキストの続きをやる or 時間計測
//透明の参考URL：https://kuroko-labo.com/オブジェクトをスクリプトで半透明にする/
//　　　　　　：https://toburau.hatenablog.jp/entry/20170731/1501518531

// チェックポイント　→　ゴール　→　時間・その他モブやアイテム　→　最終的な目標はオンラインで対戦など

//仮記録　1 -95,-86 180度回転
//　　　　2 
//　　　　3 
