using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 6;
    public float negRange = 2;
    public GameObject player;
    public ParticleSystem explosionParticle;
    public ParticleSystem powerUpParticle;
    public ParticleSystem tireParticle;
    private AudioSource playerAudio;
    public bool hasPowerup;
    public bool gameOver = false;
    public AudioClip powerUpSound;
    public AudioClip crashSound;
    private GameManager gameManager;
    public GameObject ground;

	// Start is called before the first frame update
	void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        tireParticle.Play();
	} 

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x > negRange)
        {
            transform.position = new Vector3(negRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerUpParticle.Play();
			playerAudio.PlayOneShot(powerUpSound, 1.5f);
            Destroy(other.gameObject);
            StartCoroutine(ground.GetComponent<RepeatBackground>().Powerup());
        }
        else if (other.gameObject.CompareTag("Pedestrian"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            tireParticle.Stop();
            gameOver = true;
            gameManager.GameOver();
        }

        
    }
}
