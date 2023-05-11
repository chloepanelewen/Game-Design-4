using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public GameObject player;
    public ParticleSystem explosionParticle;
    private AudioSource playerAudio;
    private bool hasPowerup;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent‹AudioSource > ();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(Background.GetComponent<MoveDown>().Powerup());
else if (other.CompareTag("Pedestrian"))
            {
                gameManager.GameOver();
                explosionParticle.Play();
                playerAudio.PlayOneShot(crashSound, 1.0f);
            }

        }
    }

}
