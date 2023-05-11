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
    private object playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //background scrolls
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.y / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < startPos.y - repeatWidth)
        {
            transform.position = startPos;
        }
    }

// speed up if have powerup
    public IEnumerator Powerup()
    {
            speed = boostSpeed;
        yield return new WaitForSeconds(boostDuration);
            speed = normalSpeed;
    }

}
