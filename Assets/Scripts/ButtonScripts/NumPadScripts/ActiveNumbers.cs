using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ActiveNumbers : MonoBehaviour {
	//[SerializeField] private Text ActiveNumberText;
	public static string numberList = "";
	
	// Use this for initialization
	
	void Start () {
		
	}
	void increaseTimer(string numPressed)
    {
		//if(numberList.Length)
	}
	// Update is called once per frame
	void Update () {
		Debug.Log("number list length: " + numberList.Length);
		if(numberList.Length == 2 || numberList.Length == 5)
        {
			numberList += ":";

		}
		if (ActiveNumbers.numberList.Length <= 8)
		{
			gameObject.GetComponent<Text>().text = numberList;
		}
		
	}

	
}
