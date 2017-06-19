using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
	private PlayerController PC;
	private void Start()
	{
		PC = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	public void GoRight()
	{
		PC.keyInput[0] = true;
		Debug.Log("가!");
	}

	public void StopGoRight()
	{
		PC.keyInput[0] = false;
		Debug.Log("그만 가!");
	}

	public void GoLeft()
	{
		PC.keyInput[1] = true;
	}

	public void StopGoLeft()
	{
		PC.keyInput[1] = false;
	}

	public void Jump()
	{
		PC.keyInput[2] = true;
	}

	public void StopJump()
	{
		PC.keyInput[2] = false;
	}

	public void ReverseGravity()
	{
		PC.keyInput[3] = true;
	}

	public void SpaceTrans()
	{
		PC.keyInput[4] = true;
	}

	public void Retry()
	{
		PC.keyInput[5] = true;
	}
}