using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableTopBar : MonoBehaviour {
	GameObject AllPanelObject;
	private bool isMoving;
	GameObject myCamera;
	Transform temp ;
	private int counter = 0;
	 GameObject cursor; // needed because clicks are happening twice
	// Use this for initialization
	void Start () {
		
		isMoving = false;
		//Debug.Log("start?");
		AllPanelObject = GameObject.FindGameObjectWithTag("AllPanelObject");
		myCamera = GameObject.FindGameObjectWithTag("MainCamera");
		cursor = GameObject.FindGameObjectWithTag("Cursor");
		//AllPanelObject.transform.position = new Vector3(myCamera.transform.position.x , myCamera.transform.position.y , );
		//AllPanelObject.transform.rotation = Quaternion.Euler(myCamera.transform.rotation.eulerAngles.x, myCamera.transform.rotation.eulerAngles.y, myCamera.transform.rotation.eulerAngles.z);
	}
	void OnSelect()
    {
		//Debug.Log("in on select");
		//Debug.Log(isMoving);
		if (!isMoving && counter < 1)
        {
			isMoving = true;
			Transform temp = cursor.transform;

		}
		else if(isMoving && counter < 1)
        {
			isMoving = false;
			
        }
		counter++;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log(cursor.transform.position + "/" + AllPanelObject.transform.position);
		if (counter > 1)
			counter = 0;
		//Debug.Log(isMoving);
		if (isMoving)
		{
			AllPanelObject.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y-.3f, myCamera.transform.position.z) + myCamera.transform.forward * 1;
			//Debug.Log("moving");
			//AllPanelObject.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, 0);
			AllPanelObject.transform.rotation = Quaternion.Euler(myCamera.transform.rotation.eulerAngles.x, myCamera.transform.rotation.eulerAngles.y, 0);
		}
	}
}
