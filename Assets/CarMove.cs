using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CarMove : MonoBehaviour
{
    const float ACCELERATION = 0.00075f;
    const float DECELERATION = -0.001f;
    const float DECELERATION2 = -0.0003f;
    const float BACKACCELERATION = 0.0002f;
    const float BACKDECELERATION = -0.001f;
    const float BACKDECELERATION2 = -0.0003f;
    const float MAX_SPEED = 0.5f;
    const float MAX_BREAK_SPEED = -1.0f;
    const float MAX_BACK_SPEED = 0.125f;
    const float ROT_SPEED = 1.0f;

    const float SPACCELERATION = 0.00225f;
    const float SPDECELERATION = -0.003f;
    const float SPMAX_SPEED = 1.5f;
    const float SPMAX_BREAK_SPEED = -3.0f;

    int CheckPointNumber;
    //int OldCheckPointNumber;
    int TextOnOff;

    int Stop;

    //[SerializeField]
    public GameObject Text;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;

    //[SerializeField]
    public GameObject GoalText;
    public GameObject GoalText2;
    public GameObject GoalText3;
    public GameObject GoalText4;

    public Text SpeedText1;
    public Text SpeedText2;
    public Text SpeedText3;
    public Text SpeedText4;
    Canvas CameraCanvas;
    public GameObject Canvas;
    //public Camera MainCamera;
    public GameObject MainCamera;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

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
    int ItemNumber;
    //int kph;
    //float bendSpeed;
    //float reallybackSpeed;
    Vector3 move;

    Vector3 tmp;
    double y;

    int kph;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        breakSpeed = 0;
        backSpeed = 0;
        ItemNumber = 0;
        move = Vector3.zero;
        rb = GetComponent<Rigidbody>();

        CheckPointNumber = 0;
        //Text.SetActive(false);
        //OldCheckPointNumber = -1;
        TextOnOff = 0;

        GoalText.SetActive(false);
        GoalText2.SetActive(false);
        GoalText3.SetActive(false);
        GoalText4.SetActive(false);

        //tmp = gameObject.GetComponent<Transform>().position;
        //y = tmp.y;

        transform.position = new Vector3(15,1,97);
        
        Stop = 0;

        //MainCamera = GameObject.Find("MainCamera");
        //Camera2 = GameObject.Find("Camera2");
        //Camera3 = GameObject.Find("Camera3");
        //Camera4 = GameObject.Find("Camera4");

        Camera2.SetActive(false);
        Camera3.SetActive(false);
        Camera4.SetActive(false);
        MainCamera.SetActive(true);

        //mainCamera = GameObject.Find("MainCamera");
        //subCamera = GameObject.Find("SubCamera");

        //subCamera.enabled(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log ();
        if (ItemNumber == 0)
        {
            kph = Mathf.RoundToInt(300 * (speed + backSpeed));
        }

        if (ItemNumber == 1)
        {
            kph = Mathf.RoundToInt(900 * (speed + backSpeed));
        }

        //int kph = Mathf.RoundToInt(300 * (speed + backSpeed));
        SpeedText1.text = kph.ToString("000");
        SpeedText2.text = kph.ToString("000");
        SpeedText3.text = kph.ToString("000");
        SpeedText4.text = kph.ToString("000");

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
            if (ItemNumber == 0)
            {
                if (Input.GetKey(KeyCode.UpArrow) && speed < MAX_SPEED) 
                {
                    speed += ACCELERATION;
                }
                else 
                {
                    if (speed > 0 ) 
                    {
                        speed += DECELERATION2;
                    }   
                    else 
                    {
                        speed = 0;
                    }
                }

                if (Input.GetKey(KeyCode.Space) && breakSpeed > MAX_BREAK_SPEED) 
                {
                    if (speed > 0)
                    {
                        speed += DECELERATION;
                    }

                    if (backSpeed < 0)
                    {
                        backSpeed -= BACKDECELERATION;
                    }
                }
            }


            if (ItemNumber == 1)
            {
                if (Input.GetKey(KeyCode.UpArrow) && speed < SPMAX_SPEED) 
                {
                    speed += SPACCELERATION;
                }
                else 
                {
                    if (speed > 0 ) 
                    {
                        speed += DECELERATION2;
                    }
                    else 
                    {
                        speed = 0;
                    }
                }

                if (Input.GetKey(KeyCode.Space) && breakSpeed > SPMAX_BREAK_SPEED) 
                {
                    if (speed > 0)
                    {
                        speed += SPDECELERATION;
                    }

                    if (backSpeed < 0)
                    {
                        backSpeed -= BACKDECELERATION;
                    }
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
                    backSpeed -= BACKDECELERATION2;
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

            //else 
            //{
                
                //if (breakSpeed < 0 ) 
                //{
                    //breakSpeed += ACCELERATION;
                    //speed += DECELERATION2;
                //}
                //else 
                //{
                    //speed = 0;
                //}
            //}

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

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //CameraCanvas = Canvas.GetComponent<Canvas>();
                //Debug.Log(CameraCanvas.isRootCanvas);
                //Canvas.GetComponent<Canvas>().worldCamera = MainCamera;

                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
                MainCamera.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Camera2.SetActive(true);
                Camera3.SetActive(false);
                Camera4.SetActive(false);
                MainCamera.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Camera2.SetActive(false);
                Camera3.SetActive(true);
                Camera4.SetActive(false);
                MainCamera.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Camera2.SetActive(false);
                Camera3.SetActive(false);
                Camera4.SetActive(true);
                MainCamera.SetActive(false);
            }

            //reallybackSpeed = backSpeed / backSpeed * 2;

            if (ItemNumber == 0)
            {
                move = transform.up * (speed + backSpeed);
            }

            if (ItemNumber == 1)
            {
                move = 3 * transform.up * (speed + backSpeed);

            }
            //move = transform.up * (speed + backSpeed);

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
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
        }
        if (TextOnOff == 1)
        {
            Text.SetActive(true);
            Text2.SetActive(true);
            Text3.SetActive(true);
            Text4.SetActive(true);

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
            GoalText2.SetActive(true);
            GoalText3.SetActive(true);
            GoalText4.SetActive(true);
            CheckPointNumber = 4;
        }

        if (other.CompareTag("Item1"))
        {
            ItemNumber = 1;
            //Debug.Log("わーい");
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
//リスポーン時間、作ってもいいかも。一定時間orキー連打でリスポーン早くなるとか
//作るなら、リスポーン時間短縮などのアイテムを追加するのもあり。
//次回以降やること：アイテム作成。いろいろ作っていこう！
//その先　　　：・モブ　＊出来れば・CPUと対戦　・オンライン対戦　＊最終的には・unityroomで公開
//参考URL 　 ：なし


//CP場所記録　CP1 -95, 21,-86 180度回転
//　　　  　　CP2 -81, 31, 95 初期向きから左に90度回転
//　　  　　　CP3  95, 32, 24 0度

//?アイテム
//1・タイヤ強化：20秒間、通常時より全ての性能が1.2倍。
//2・加速強化：15秒間、通常時より加速と最高時速が1.5倍、ブレーキが0.75倍
//3・ハンドル強化：20秒間、通常時より回転速度が1.4倍
//4・レーザー：3回分。ロックオンなし。当たると一定時間動けない。
//5・ロケット：1回。ロックオンあり。当たると一定時間動けない。
//6・爆弾：1回分。ロックオンなし。当たると一定時間動けない。自爆あり。20秒間持っていると自爆。地面についた3秒後に爆発。
//7・鎧：20秒間、攻撃を無効化。一定以上ダメージを食らうと鎧は壊れる。

//!アイテム
//11・タイヤ超強化：15秒間、通常時より全ての性能が2倍。
//12・加速強化：10秒間、通常時より加速と最高時速が3倍、ブレーキが1.5倍
//13・ハンドル強化：15秒間、通常時より回転速度が2倍
//14・ワープ：レースの場所のどこかにワープする。
//15・魔法の杖：自分の姿が見えなくなり、敵から攻撃されなくなる。自分もどこを走っているか見えない。
//16・危ない爆弾：1回分。ロックオンなし。当たると一定時間動けない。5秒間持っていると自爆。それ以外は自爆なし。地面についた1秒後に広範囲爆発。
//17・レーザーマシン：自分の向いている方向の90°に発射。ロックオンなし。当たると一定時間動けない。
//18・火の玉：3回同時発射。ロックオンあり。当たると一定時間動けない。
//19・シールド：10秒間、全ての攻撃を無効化。ダメージを食らっても壊れない。

//21・パンクタイヤ：15秒間、通常時より全ての性能が0.5倍
//22・減速強化：10秒間、通常時より加速と最高時速が0.3倍、ブレーキが3倍。
//23・ハンドル故障：15秒間、通常時より回転速度が0.5倍

//31・ワープ：レースの場所のどこかにワープする。
//32・魔法の杖：自分の姿が見えなくなり、敵から攻撃されなくなる。自分もどこを走っているか見えない。
//33・空き缶：効果なし。損得なし。

//!アイテムの確率は、得42.5%,損42.5%,中15%、その中で確率は均等に。　?アイテムの確率は、それぞれ均等に。