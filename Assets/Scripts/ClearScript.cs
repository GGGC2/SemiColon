using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour {

	bool Getkey;
	// Use this for initialization
	void Start () {
		Getkey = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void OnTriggerEnter2D(Collider2D coll) //바닥에 착지하는 것을 감지, 점프나 중력 반전 횟수 초기화 시켜야함
	{
		Debug.Log ("whlkfds");
		if (coll.gameObject.tag == "Key") {
			Getkey = true;
			Debug.Log ("True!!");
		}

		if (coll.gameObject.tag == "Door") {
			if (Getkey) {
				Debug.Log ("Clear");
			}
		}
	}
}
