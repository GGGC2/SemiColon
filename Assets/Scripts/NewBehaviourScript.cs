using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	public bool fade=false;
	public float gameTime=0f;
	public float speed = 0f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(fade){
			gameTime = gameTime + Time.deltaTime;
			GetComponent<Image> ().color = new Color (0, 0, 0, gameTime);
		}
	}
}
