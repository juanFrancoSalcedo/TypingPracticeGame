using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLoseController : MonoBehaviour
{
    [SerializeField] private SummaryController summaryController = null;
    private void OnEnable() => TimerController.OnTimeUp += TimeUp;
    private void OnDisable() => TimerController.OnTimeUp -= TimeUp;
    private void TimeUp() => summaryController.GameOver();
}
