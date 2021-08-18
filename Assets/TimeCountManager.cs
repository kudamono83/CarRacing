using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCountManager : MonoBehaviour
{
    public float timeCount;
    public Text countDownText;
    public int minutes;
    public float seconds;

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
            timeCount += Time.deltaTime;
        }));
            minutes = (int)timeCount / 60;
            seconds = timeCount % 60.0f;

            countDownText.text = "Time　" + minutes.ToString("0") + " : " + seconds.ToString("00.0");
    }
    
    private IEnumerator WaitSignal(float waitTime, Action action) 
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

}
