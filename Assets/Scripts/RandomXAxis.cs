using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXAxis : MonoBehaviour
{
	public bool isDown = true; //If the wall starts down, if not you must modify to false
	public bool isRandom = true; //If you want that the wall go down random
	public float speed = 2f;

	private float width; 
	private float posXDown; 
	private bool isWaiting = false; 
	private bool canChange = true; //If the wall is thinking if should go down or not

	void Awake()
	{
		//Platform height and start coord
		width = transform.localScale.x / 1.5f;
		if (isDown)
			posXDown = transform.position.x;
		else
			posXDown = transform.position.x - width;
	}

	// Update is called once per frame
	void Update()
	{
		//If the wall is waiting up or down
		if (isDown)
		{
			if (transform.position.x < posXDown + width)
			{
				transform.position += Vector3.right * Time.deltaTime * speed;
			}
			else if (!isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
		else
		{
			if (!canChange)
				return;

			if (transform.position.x > posXDown)
			{
				transform.position -= Vector3.right * Time.deltaTime * speed;
			}
			else if (!isWaiting)
				StartCoroutine(WaitToChange(0.25f));
		}
	}

	//Wait before go down or up
	IEnumerator WaitToChange(float time)
	{
		isWaiting = true;
		yield return new WaitForSeconds(time);
		isWaiting = false;
		isDown = !isDown;

		if (isRandom && !isDown) //If is wall up and is random
		{
			int num = Random.Range(0, 2);
			//Debug.Log(num);
			if (num == 1)
				StartCoroutine(Retry(1.5f));
		}
	}

	//Checks every 1.25secs if can go down the wall
	IEnumerator Retry(float time)
	{
		canChange = false;
		yield return new WaitForSeconds(time);
		int num = Random.Range(0, 2);
		//Debug.Log("2-"+num);
		if (num == 1)
			StartCoroutine(Retry(1.25f));
		else
			canChange = true;
	}
}
