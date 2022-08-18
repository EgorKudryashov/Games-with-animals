using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private GameManagerX gameManager;
    public GameObject dogPrefab;
    private float timeSpam;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerX>();
    }

    void Update()
    {
        if (!gameManager.isGameOver)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space) && (Time.time - timeSpam) > 0.7f)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                timeSpam = Time.time;
            }
        }
    }
}
