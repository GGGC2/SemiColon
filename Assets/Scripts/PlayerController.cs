using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	private int jumpTime;
	private int flipTime;
	private int spaceTime;
	private int flipped;
	private int turned;

	private void Start()
	{
		moveSpeed = 3;
		jumpHeight = 4;
		jumpTime = 0;
		flipTime = 0;
		spaceTime = 0;
		flipped = 0;
		turned = 0;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.D)) //오른쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			turned = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, turned);
		}
		else if (Input.GetKey(KeyCode.A)) //왼쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			turned = 180;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, turned);
        }

		if ((Input.GetKeyUp (KeyCode.D))||(Input.GetKeyUp (KeyCode.A))) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKeyDown(KeyCode.Space) && jumpTime == 0) //점프 횟수는 1번, 바닥에 착지하면 초기화, x방향 이동속도 그대로 유지
		{
			jumpTime++;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
		
		if (Input.GetKeyDown(KeyCode.K) && flipTime == 0) //중력 반전 횟수 1번, 바닥에 착지하면 초기화
		{
			flipTime++;
			FlipMethod ();
        }

		if (Input.GetKeyDown(KeyCode.J)) //공간 반전 횟수 무제한(아님), x나 y 방향 이동속도는 부호만 바뀌고 그대로 유지
		{
			if (spaceTime < 2) {
				transform.position = new Vector3 (transform.position.x,-1 * transform.position.y, 0);
				FlipMethod ();
				spaceTime++;
			}
		}
		if (Input.GetKeyDown(KeyCode.R)) //재시작 메소드
		{
			Scene_manager.Instance.Reload_this_scene ();
			Time.timeScale = 1;
		}
	}

	private void OnCollisionEnter2D(Collision2D coll) //바닥에 착지하는 것을 감지, 점프나 중력 반전 횟수 초기화 시켜야함
	{
		if (coll.gameObject.tag == "Ground") {
			jumpTime = 0;
			flipTime = 0;
			spaceTime = 0;
		}
		if (coll.gameObject.tag == "Key") {
			Debug.Log (coll.gameObject.tag);
			Destroy (coll.gameObject);

		}
		if (coll.gameObject.tag == "Door") {
			Debug.Log (coll.gameObject.tag);

		}
		if (coll.gameObject.tag == "Dead") {
			Debug.Log ("You are died!");
			Dead ();
		}
	}

	
	public void Dead(){
		Time.timeScale = 0;
		deathUI.SetActive (true);
	}

	private void FlipMethod(){ //반전을 시키는 메소드
		jumpHeight = -jumpHeight;
		if (GetComponent<Rigidbody2D>().gravityScale == 1)
		{
			GetComponent<Rigidbody2D>().gravityScale = -1f;
			flipped = 180;
			Rotate (flipped, turned);
		}
		else if (GetComponent<Rigidbody2D>().gravityScale == -1)
		{
			GetComponent<Rigidbody2D>().gravityScale = 1f;
			flipped = 0;
			Rotate (flipped, turned);
		}
	}

	private void Rotate(int x, int y){ //캐릭터를 돌리는 메소드
		transform.rotation = Quaternion.Euler (x, y, 0);
	}

	public	GameObject deathUI;
}