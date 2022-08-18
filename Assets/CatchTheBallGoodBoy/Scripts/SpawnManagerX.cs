using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    private GameManagerX gameManager;
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();

        StartCoroutine(SpawnBall());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        if (!gameManager.isGameOver)
        {
            // Generate random ball index and random spawn position
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int ballIndex = Random.Range(0, ballPrefabs.Length);

            // instantiate ball at random spawn location
            Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
        }
    }

    IEnumerator SpawnBall()
    {
        while (!gameManager.isGameOver)
        {
            spawnInterval = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(spawnInterval);
            SpawnRandomBall();
        }
    }

}
