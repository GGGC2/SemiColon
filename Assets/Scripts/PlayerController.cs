using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;
	public float jumpHeight = 3;
	private int jumpTime;

	private void Start()
	{

	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.RightArrow)) //오른쪽으로 이동, y 방향 이동속도는 그대로 유지
		{

		}
		else if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽으로 이동, y 방향 이동속도는 그대로 유지
		{

		}

		if (Input.GetKeyDown(KeyCode.Space)) //점프 횟수는 1번, 바닥에 착지하면 초기화, x방향 이동속도 그대로 유지
		{
			if (jumpTime == 0) {
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
				jumpTime++;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Z)) //중력 반전 횟수 1번, 바닥에 착지하면 초기화
		{

		}

		if (Input.GetKeyDown(KeyCode.X)) //공간 반전 횟수 무제한, x나 y 방향 이동속도는 부호만 바뀌고 그대로 유지
		{

		}
	}

	private void OnCollisionEnter2D(Collision2D coll) //바닥에 착지하는 것을 감지, 점프나 중력 반전 횟수 초기화 시켜야함
	{
		if (coll.gameObject.tag == "Ground") {
			jumpTime = 0;
		}
	}
}