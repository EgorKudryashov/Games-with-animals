using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs = new GameObject[3];
    private float spawnRangeX = 15.0f;
    private float spawnPositionZ = 20.0f;

    private float spawnRangeZ = 15.0f;
    private float spawnPositionX = 30.0f;

    private float leftRotation = 90.0f;
    private float rightRotation = 270.0f;

    private float spawnDelay = 2.0f;
    private float spawnInterval = 1.5f;
    private float spawnAgressiveDelay = 4.0f;
    private float spawnAgressiveInterval = 2.0f;
 
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAgressiveAnimal", spawnAgressiveDelay, spawnAgressiveInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAgressiveAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPositionLeft = new Vector3(-spawnPositionX, 0, Random.Range(3, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPositionLeft, Quaternion.Euler(0, leftRotation, 0));

        animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPositionRight = new Vector3(spawnPositionX, 0, Random.Range(3, spawnRangeZ));
        Instantiate(animalPrefabs[animalIndex], spawnPositionRight, Quaternion.Euler(0, rightRotation, 0));
    }
}
