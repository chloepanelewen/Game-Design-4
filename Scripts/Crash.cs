using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private Rigidbody personRb;
    private Animator personAnim;

    // Start is called before the first frame update
    void Start()
    {
        personRb = GetComponent<Rigidbody>();
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        personAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {

        }
    }
}
