using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TimerView view = null;
    [SerializeField] private bool restTimer = false;
    [SerializeField] private float timeInit = 0;
    [SerializeField] TypeTimer timerType = TypeTimer.seconds;
    public static event Action OnTimeUp;
    float timerCount = 0;
    private bool stoped = false;
    private void Start()
    {
        timerCount = timeInit;
    }

    private void Update()
    {
        if (stoped)
            return;
        SumTime();
        var str = GetTimeFormat(timerCount);
        view.DisplayTimer(str);
        CheckTimeUp();
    }

    private void CheckTimeUp()
    {
        if (timerCount < 0)
        {
            OnTimeUp?.Invoke();
            timerCount = 0;
        }
    }

    private void SumTime()
    {
        if (restTimer)
            timerCount -= Time.deltaTime;
        else
            timerCount += Time.deltaTime;
    }

    public string GetTimeFormat(double cronoTime)
    {
        int hours = (int)Math.Floor(cronoTime / 3600);
        int minutes = (int)Math.Floor(cronoTime / 60) - (hours * 60);
        int seconds = (int)Math.Floor(cronoTime % 60);

        switch (timerType)
        {
            case TypeTimer.miliseconds:
                break;
            case TypeTimer.seconds:
                return $"{seconds:00}";
                break;
            case TypeTimer.minutes:
                return $"{minutes:00}:{seconds:00}";
                break;
            case TypeTimer.hours:
                return $"{hours:00}:{minutes:00}:{seconds:00}";
                break;
            default:
                break;
        }
        return $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    public void StopTimer() => stoped = true;

    public void PlayTimer() => stoped = false;

    [System.Serializable]
    public class TimerView 
    {
        [SerializeField] private Text textTimer = null;

        public void DisplayTimer(string str)
        {
            textTimer.text = str;
        }
    }

    public enum TypeTimer 
    {
        miliseconds,
        seconds,
        minutes,
        hours
    }
}
