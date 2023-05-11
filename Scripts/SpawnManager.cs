using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] pedestrianPrefabs;
	public GameObject powerupPrefab;
	private float spawnRange = 2;
	private float spawnRangeSide = -6;
	private float startDelay = 2;
	private float spawnInterval = 1.5f;
	private float spawnIntPower = 5;
	private PlayerController playerControllerScript;

	// Start is called before the first frame update
	void Start()
    {
		playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
		InvokeRepeating("SpawnPedestrian", startDelay, spawnInterval);
		InvokeRepeating("SpawnPowerup", startDelay, spawnIntPower);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	private Vector3 GenerateSpawnPosition()
	{
		float spawnPosZ = 8;
		Vector3 randomPos = new Vector3(Random.Range(spawnRangeSide, spawnRange), 0 ,spawnPosZ);
		return randomPos;
	}
	void SpawnPedestrian()
	{
		if (playerControllerScript.gameOver == false)
		{
			//pedestrians spawn at top of screen
			int pedestrianIndex = Random.Range(0, pedestrianPrefabs.Length);
			Instantiate(pedestrianPrefabs[pedestrianIndex], new Vector3(spawnRangeSide, 0, 8), pedestrianPrefabs[pedestrianIndex].transform.rotation); ;
		}
	}

	void SpawnPowerup()
	{
		if (playerControllerScript.gameOver == false)
		{
			Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
		}
	}
}
