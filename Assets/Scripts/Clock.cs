using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMP_Text dateUI;
    public TMP_Text clockUI;
    public GameObject date;
    string today_M = "";
    string today_D = "";
    string today_W = "";
    float currentTime_H = 0;
    float currentTime_M = 0;
    float currentTime_S = 0;

    void Start()
    {
        dateUI = date.GetComponent<TextMeshProUGUI>();
        clockUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        StartCoroutine(ClockWorking());
    }

    IEnumerator ClockWorking()
    { if (this.gameObject != null && date !=null) {
            today_M = DateTime.Now.Month.ToString();
            today_D = DateTime.Now.Day.ToString();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                today_W = "월요일";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                today_W = "화요일";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                today_W = "수요일";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                today_W = "목요일";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                today_W = "금요일";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                today_W = "토요일";
            }
            else
            {
                today_W = "일요일";
            }
            currentTime_H = DateTime.Now.Hour;
            currentTime_M = DateTime.Now.Minute;
            currentTime_S = DateTime.Now.Second;

            dateUI.text = today_M + "월 " + today_D + "일 " + today_W;
            clockUI.text = currentTime_H + ":" + currentTime_M + ":" + currentTime_S;

            yield return new WaitForSeconds(1);
        }
    } 
}
