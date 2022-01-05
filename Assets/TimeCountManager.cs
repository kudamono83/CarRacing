using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCountManager : MonoBehaviour
{
    public float timeCount;
    public Text countDownText;
    public Text countDownText2;
    public Text countDownText3;
    public Text countDownText4;
    public int minutes;
    public float seconds;

    public GameObject GoalText;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitSignal(4, () =>
        {
            if(GoalText.activeSelf)
            {
                
            }
            else
            {
                timeCount += Time.deltaTime;
            }
        }));
            minutes = (int)timeCount / 60;
            seconds = timeCount % 60.0f;

            countDownText.text = "Time　" + minutes.ToString("0") + " : " + seconds.ToString("00.0");
            countDownText2.text = "Time　" + minutes.ToString("0") + " : " + seconds.ToString("00.0");
            countDownText3.text = "Time　" + minutes.ToString("0") + " : " + seconds.ToString("00.0");
            countDownText4.text = "Time　" + minutes.ToString("0") + " : " + seconds.ToString("00.0");
    }
    
    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

}
