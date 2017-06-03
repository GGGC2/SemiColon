using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3;
	public float jumpHeight = 5;
	private int jumpTime = 0;
	private int flipTime = 0;
	private int flipped = 0;

	public GameObject Fade;

	private void Start()
	{

	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.D)) //오른쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, 0, 0);
		}
		else if (Input.GetKey(KeyCode.A)) //왼쪽으로 이동, y 방향 이동속도는 그대로 유지
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			Rotate (flipped, 180, 0);
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

		if (Input.GetKeyDown(KeyCode.J)) //공간 반전 횟수 무제한, x나 y 방향 이동속도는 부호만 바뀌고 그대로 유지
		{
			transform.position = new Vector3 (transform.position.x,-1 * transform.position.y, 0);
			FlipMethod ();
		}
	}

	private void OnCollisionEnter2D(Collision2D coll) //바닥에 착지하는 것을 감지, 점프나 중력 반전 횟수 초기화 시켜야함
	{
		if (coll.gameObject.tag == "Ground" || coll.gameObject.tag == "Wall Top") {
			Debug.Log (coll.gameObject.tag);
			jumpTime = 0;
			flipTime = 0;
		}
		if (coll.gameObject.tag == "Key") {
			Debug.Log (coll.gameObject.tag);
			Destroy (coll.gameObject);
			GetComponent<KeyScript> ().getkey();
		}
		if (coll.gameObject.tag == "Door") {
			Debug.Log (coll.gameObject.tag);
			Destroy (coll.gameObject);
			Fade.GetComponent<NewBehaviourScript>().fade = true;
		}
	}

	private void FlipMethod(){
		if (GetComponent<Rigidbody2D>().gravityScale == 1)
		{
			GetComponent<Rigidbody2D>().gravityScale = -1f;
			jumpHeight = -jumpHeight;
			Rotate (180, 0, 0);
			flipped = 180;
		}
		else if (GetComponent<Rigidbody2D>().gravityScale == -1)
		{
			GetComponent<Rigidbody2D>().gravityScale = 1f;
			jumpHeight = -jumpHeight;
			Rotate (0, 0, 0);
			flipped = 0;
		}
	}

	private void Rotate(int x, int y, int z){
		transform.rotation = Quaternion.Euler (x, y, z);
	}
}