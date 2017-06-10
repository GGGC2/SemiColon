using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScript : MonoBehaviour {

	public bool Getkey;
	// Use this for initialization
	void Start () {
		Getkey = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	private void OnTriggerEnter2D(Collider2D coll) //바닥에 착지하는 것을 감지, 점프나 중력 반전 횟수 초기화 시켜야함
	{
		if (coll.gameObject.tag == "Key") {
			Getkey = true;
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Door") {
            Debug.Log("ee");
			if (Getkey) {
				Debug.Log ("Clear");
				Scene_manager.Instance.Scene_change ();
			}
		}
	}
}
