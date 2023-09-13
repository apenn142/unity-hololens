using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

    [SerializeField] public Text text;
    [SerializeField] private GameObject timerOptionsPanel;
    [SerializeField] private GameObject myNewTimerPanel;
    [SerializeField] private TimerHandler th;
    public bool paused = false;
    public MyTime time;
    public int startTime = 0;
    public void start()
    {
        
        Debug.Log(timerOptionsPanel);
        Debug.Log(timerOptionsPanel);
    }
    void OnSelect()
    {
        Debug.Log("clicked on a  timer");
        timerOptionsPanel.SetActive(true);
        myNewTimerPanel.SetActive(false);
        th.toggleSettings(gameObject);
    }
    public void startTimer()
    {
        bool restart = time.m_seconds <= 0;
        
        time.m_seconds = startTime;

        if (restart)
            StartCoroutine(countDown());
    }
    public void startTimer(string numSeconds)
    {
        time = MyTime.parse(numSeconds);
        startTime = time.m_seconds;
        StartCoroutine(countDown());
        
    }

    IEnumerator countDown()
    {
        text.color = Color.red;
        while (time.m_seconds > 0)
        {
            text.text = time.toString();
            Debug.Log(paused);
            if (!paused)
                time.m_seconds--;
            yield return new WaitForSeconds(1f);
        }
       
        gameObject.GetComponent<AudioSource>().Play();
        text.text = "00:00:00";
        text.color = Color.black;
    }
}

public class MyTime
{
    public int m_seconds;

    public MyTime(int seconds)
    {
        m_seconds = seconds;
    }
    public static MyTime parse(string time)
    {
        string[] splitTime = time.Split(':');
        int hours = int.Parse(splitTime[0]);
        int min = int.Parse(splitTime[1]);
        int sec = int.Parse(splitTime[2]);

        return new MyTime(sec + min * 60 + hours * 60 * 60);
    }

    public string toString()
    {
        string time = "";

        int hours = m_seconds / (60 * 60);
        if (hours > 99)
            hours = 99;
        else if (hours < 10)
            time += "0" + hours;
        else
            time += "" + hours;

        time += ":";

        int min = m_seconds / 60;
        if (min % 60 < 10)
            time += "0" + min % 60;
        else
            time += "" + min % 60;

        time += ":";

        int sec = m_seconds % 60;
        if (sec < 10)
            time += "0" + sec;
        else
            time += "" + sec;



        return time;
    }
}
