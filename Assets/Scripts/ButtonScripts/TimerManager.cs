using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerManager : MonoBehaviour {
   private int timeToCount;
    [SerializeField] private Transform timerSpawnPoint;
    [SerializeField] private GameObject timerPrefab;
    [SerializeField] private GameObject parentPanel;
    //[SerializeField] GameObject timerEndSound;
    [SerializeField] AudioSource audioManager;
    
    private int count = 0;
	// Use this for initialization
	void Start () {
	
	}
    public void CallStartTimer(int mytime)
    {
        timeToCount = mytime;
        if (count == 0) {
            Debug.Log("started 1");
            StartCoroutine("StartATimer");
            count++;
        }  
        else if (count == 1)
        {
            Debug.Log("started 2");
            StartCoroutine("StartATimer2");
            count++;
        }
        else if (count == 2)
        {
            Debug.Log("started 3");
            StartCoroutine("StartATimer3");
            count++;
        }
        else if (count == 3)
        {
            Debug.Log("started 4");
            StartCoroutine("StartATimer4");
            count++;
        }
        
    }
           
    IEnumerator StartATimer()
    {
       int personalCountTime = timeToCount;
         float increment = .078f;
        GameObject myTimerPrefab = Instantiate(timerPrefab, timerSpawnPoint);
        myTimerPrefab.transform.parent = parentPanel.transform;
        myTimerPrefab.transform.localScale = new Vector3(6.9f, 1.6f, 1.1f);
        
        myTimerPrefab.transform.position = new Vector3(myTimerPrefab.transform.position.x + increment, myTimerPrefab.transform.position.y, myTimerPrefab.transform.position.z);
       // timerSpawnPoint.position = new Vector3(timerSpawnPoint.position.x + .1f, timerSpawnPoint.position.y, timerSpawnPoint.position.z);
         
       
           
      
        increment +=.02f;
        while (personalCountTime > 0)
        {
            yield return new WaitForSeconds(1);
            personalCountTime--;
            myTimerPrefab.GetComponentInChildren<Text>().text = personalCountTime.ToString();
        }
        count--;
        audioManager.clip = (Resources.Load<AudioClip>("mixkit-waiting-ringtone-1354"));
        audioManager.Play();
    }
    IEnumerator StartATimer2()
    {
        int personalCountTime2 = timeToCount;
        float increment = .194f;
        GameObject myTimerPrefab = Instantiate(timerPrefab, timerSpawnPoint);
        myTimerPrefab.transform.parent = parentPanel.transform;
        myTimerPrefab.transform.localScale = new Vector3(6.9f, 1.6f, 1.1f);

        myTimerPrefab.transform.position = new Vector3(myTimerPrefab.transform.position.x + increment, myTimerPrefab.transform.position.y, myTimerPrefab.transform.position.z);
      //  timerSpawnPoint.position = new Vector3(timerSpawnPoint.position.x + .1f, timerSpawnPoint.position.y, timerSpawnPoint.position.z);




       
        while (personalCountTime2 > 0)
        {
            yield return new WaitForSeconds(1);
            personalCountTime2--;
            myTimerPrefab.GetComponentInChildren<Text>().text = personalCountTime2.ToString();
        }
        count--;
        audioManager.clip = (Resources.Load<AudioClip>("mixkit-waiting-ringtone-1354"));
        audioManager.Play();
    }
    IEnumerator StartATimer3()
    {
        int personalCountTime3 = timeToCount;
        float increment = .078f;
        GameObject myTimerPrefab = Instantiate(timerPrefab, timerSpawnPoint);
        myTimerPrefab.transform.parent = parentPanel.transform;
        myTimerPrefab.transform.localScale = new Vector3(6.9f, 1.6f, 1.1f);

        myTimerPrefab.transform.position = new Vector3(myTimerPrefab.transform.position.x + increment, myTimerPrefab.transform.position.y-.078f, myTimerPrefab.transform.position.z);
      //  timerSpawnPoint.position = new Vector3(timerSpawnPoint.position.x + .1f, timerSpawnPoint.position.y, timerSpawnPoint.position.z);




      
        while (personalCountTime3 > 0)
        {
            yield return new WaitForSeconds(1);
            personalCountTime3--;
            myTimerPrefab.GetComponentInChildren<Text>().text = personalCountTime3.ToString();
        }
        count--;
        audioManager.clip = (Resources.Load<AudioClip>("mixkit-waiting-ringtone-1354"));
        audioManager.Play();
    }
    IEnumerator StartATimer4()
    {
        int personalCountTime4 = timeToCount;
        float increment = .198f;
        GameObject myTimerPrefab = Instantiate(timerPrefab, timerSpawnPoint);
        myTimerPrefab.transform.parent = parentPanel.transform;
        myTimerPrefab.transform.localScale = new Vector3(6.9f, 1.6f, 1.1f);

        myTimerPrefab.transform.position = new Vector3(myTimerPrefab.transform.position.x + increment, myTimerPrefab.transform.position.y-.078f, myTimerPrefab.transform.position.z);
      //  timerSpawnPoint.position = new Vector3(timerSpawnPoint.position.x + .1f, timerSpawnPoint.position.y, timerSpawnPoint.position.z);




        
        while (personalCountTime4 > 0)
        {
            yield return new WaitForSeconds(1);
            personalCountTime4--;
            myTimerPrefab.GetComponentInChildren<Text>().text = personalCountTime4.ToString();
        }
        count--;
        audioManager.clip = (Resources.Load<AudioClip>("mixkit-waiting-ringtone-1354"));
        audioManager.Play();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
