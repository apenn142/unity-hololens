using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour {
    [SerializeField] private Transform spawnStartPoint;
    [SerializeField] private GameObject timerPrefab;
    [SerializeField] private GameObject parentPanel;
    private List<GameObject> timers;
    private int maxTimers = 9;
    private GameObject activeTimer = null;
   // private Transform permPos;
    private void Start()
    {
        timers = new List<GameObject>();
        //permPos = spawnStartPoint;
    }

    private void Update()
    {
        
        Debug.Log("timers count: " + timers.Count);
        for (int i = 0; i < timers.Count; i++)
        {
            //spawnStartPoint = permPos;
            timers[i].transform.localPosition = new Vector3(spawnStartPoint.localPosition.x + 500f * (i % 3), spawnStartPoint.localPosition.y - 80f * (i / 3), spawnStartPoint.localPosition.z - 20);
            if (activeTimer != null)
            {
               parentPanel.transform.Find("ActiveNumbers").GetComponent<Text>().text = activeTimer.GetComponent<Timer>().text.text;
                parentPanel.transform.Find("ActiveNumbers").GetComponent<Text>().color = activeTimer.GetComponent<Timer>().text.color;
            }
        }
    }
    public void toggleSettings(GameObject timer)
    {
        
        activeTimer = timer;

        if (activeTimer != null)
        {
            Debug.Log("not null timer");
        }
        else
        {
            Debug.Log("null timer");
        }
    }
    public void pauseTimer()
    {
        Debug.Log(activeTimer.GetComponent<Timer>().paused);
        activeTimer.GetComponent<Timer>().paused = !activeTimer.GetComponent<Timer>().paused;
        Debug.Log(activeTimer.GetComponent<Timer>().paused);
    }
    public void AddTimer(string time)
    {
        if (maxTimers <= timers.Count)
            return;
        Debug.Log("Spawned a new timer");
       // spawnStartPoint = permPos;
        GameObject newTimer = Instantiate(timerPrefab, Vector3.zero, Quaternion.identity, spawnStartPoint);
        //newTimer.transform.rotation = spawnStartPoint.transform.rotation;
       // newTimer.transform.parent = spawnStartPoint.transform;
        newTimer.transform.rotation = spawnStartPoint.transform.rotation;
        //newTimer.transform.position= new Vector3(newTimer.transform.position.x, newTimer.transform.position.y, newTimer.transform.position.z);
        newTimer.GetComponent<Timer>().startTimer(time);

        timers.Add(newTimer);
    }
    public void resetTimer()
    {
        if (activeTimer != null)
            activeTimer.GetComponent<Timer>().startTimer();
    }
    public void deleteTimer()
    {
        if (activeTimer != null)
        {
            timers.Remove(activeTimer);
            Destroy(activeTimer);
            parentPanel.SetActive(false);
        }
    }
}
