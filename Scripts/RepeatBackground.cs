using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	public float speed;
	public float normalSpeed = 3;
	public float boostSpeed = 2;
	public float boostCooldown = 2;
	public float boostDuration = 5;
	public bool hasBoost;
	private Vector3 startPos;
	public float repeatWidth;
	private PlayerController playerControllerScript;

	// Start is called before the first frame update
	void Start()
    {
		startPos = transform.position;
		repeatWidth = GetComponent<BoxCollider>().size.z / 2;
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
		if (playerControllerScript.gameOver == false)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
		}

		if (transform.position.z < startPos.z - repeatWidth)
		{
			transform.position = startPos;
		}

	}
	public IEnumerator Powerup()
	{
		speed = boostSpeed;
		yield return new WaitForSeconds(boostDuration);
		speed = normalSpeed;
	}
}
