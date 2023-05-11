using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] pedestrianPrefabs;
    public GameObject powerupPrefab;
    public float spawnPosZ = 20;
    private float spawnRange = 10;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(0, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnPedestrian()
    {
        //pedestrians spawn at top of screen
        int pedestrianIndex = UnityEngine.Random.Range(0, pedestrianPrefabs.Length);
        Instantiate(pedestrianPrefabs[pedestrianIndex], new Vector3(0, 0, 20), pedestrianPrefabs[pedestrianIndex].transform.rotation);
    }

}