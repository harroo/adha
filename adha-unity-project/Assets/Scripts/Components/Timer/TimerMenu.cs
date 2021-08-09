
using System;

using UnityEngine;
using UnityEngine.UI;

public class TimerMenu : MonoBehaviour {

    public Text countDown;

    public InputField hours, minutes, seconds;

    public void OnEndEdit () {

        totalSecondsDown = 0;

        totalSecondsDown += hours.text == "" ? 0 : ulong.Parse(hours.text) * 3600;
        totalSecondsDown += minutes.text == "" ? 0 : ulong.Parse(minutes.text) * 60;
        totalSecondsDown += seconds.text == "" ? 0 : ulong.Parse(seconds.text);
    }

    private ulong totalSecondsDown;

    private System.Diagnostics.Stopwatch stopWatch
        = new System.Diagnostics.Stopwatch();

    public void SStart () { stopWatch.Start(); OnEndEdit(); counting = true; }
    public void Stop () { stopWatch.Stop(); counting = false; }
    public void Reset () { Stop(); stopWatch.Reset(); hours.text=""; minutes.text=""; seconds.text=""; }
    public void Restart () { stopWatch.Restart(); counting = true; }

    private bool counting = false;

    private void Update () {

        ulong newpoch = totalSecondsDown - (ulong)stopWatch.Elapsed.TotalSeconds;

        Int32 minutes = 0, hours = 0, days = 0;

        while (newpoch >= 60) {

            minutes++; newpoch -= 60;
        }

        while (minutes >= 60) {

            hours++; minutes -= 60;
        }

        while (hours >= 24) {

            days++; hours -= 24;
        }

        countDown.text =
            days.ToString() + ", " + (hours < 10 ? "0" : "") +
            hours.ToString() + ":" + (minutes < 10 ? "0" : "") +
            minutes.ToString() + ":" + (newpoch < 10 ? "0" : "") +
            newpoch.ToString() + ":" +
            (counting ? UnityEngine.Random.Range(111, 999) : 0).ToString()
        ;

        if (totalSecondsDown - (ulong)stopWatch.Elapsed.TotalSeconds <= 0 && counting) {

            Stop();

            alarmPopup.SetActive(true);
        }
    }

    public GameObject alarmPopup;
}
