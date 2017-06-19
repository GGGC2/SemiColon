using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight;
	public Sprite Lucyblack;
	public Sprite Lucywhite;
	public bool[] keyInput;
	private GameObject deathUI;
	private int jumpTime;
	private int flipTime;
	private int spaceTime;
	private int flipped;
	private int turned;
	private Animator anim;

	private void Start()
	{
		keyInput = new bool[6] {false, false, false, false, false, false};
		moveSpeed = 3;
		jumpHeight = 4;
		jumpTime = 0;
		flipTime = 0;
		spaceTime = 0;
		flipped = 0;
		turned = 0;

		deathUI = GameObject.Find("Death Text");
		deathUI.SetActive(false);

		anim = GetComponent<Animator>();
		anim.SetBool("IsBlack", true);
		anim.SetBool("IsJump", false);
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.D) || keyInput[0] == true) //오른쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			turned = 0;
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, turned);
		}
		else if (Input.GetKey(KeyCode.A) || keyInput[1] == true) //왼쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			turned = 180;
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, turned);
        }

		if ((Input.GetKeyUp (KeyCode.D)) || (Input.GetKeyUp (KeyCode.A)) || (keyInput[0] == false && keyInput[1] == false))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
		}
		if ((Input.GetKeyDown(KeyCode.Space) || keyInput[2] == true) && jumpTime == 0) //점프 횟수는 1번, 바닥에 착지하면 초기화, x방향 이동속도 그대로 유지
		{
			anim.SetBool("IsJump", true);
			jumpTime++;
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}
		
		if ((Input.GetKeyDown(KeyCode.K) || keyInput[3] == true) && flipTime == 0) //중력 반전 횟수 1번, 바닥에 착지하면 초기화
		{
			flipTime++;
			FlipMethod ();
			anim.SetBool("IsJump", true);
			
			keyInput[3] = false;
        }

		if (Input.GetKeyDown(KeyCode.J) || keyInput[4] == true) //공간 반전 횟수 무제한(아님), x나 y 방향 이동속도는 부호만 바뀌고 그대로 유지
		{
			Debug.Log("공간반전");
			if (spaceTime < 2) {
				transform.position = new Vector3 (transform.position.x,-1 * transform.position.y, 0);
				if (transform.position.y < 0f) {
					GetComponent<SpriteRenderer> ().sprite = Lucywhite;
					anim.SetBool("IsBlack", false);
				}
				else if (transform.position.y > 0f) {
					GetComponent<SpriteRenderer> ().sprite = Lucyblack;
					anim.SetBool("IsBlack", true);
				}
				FlipMethod ();
				spaceTime++;
			}
			keyInput[4] = false;
		}
		if (Input.GetKeyDown(KeyCode.R) || keyInput[5] == true) //재시작 메소드
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
			anim.SetBool("IsJump", false);
		}
		if (coll.gameObject.tag == "Key") {
			Debug.Log ("ee");
		}
		if (coll.gameObject.tag == "Door") {
			Debug.Log (coll.gameObject.tag);

		}
		if (coll.gameObject.tag == "Dead")
		{
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
}