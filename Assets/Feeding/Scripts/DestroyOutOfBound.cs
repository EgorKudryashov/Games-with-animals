using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private GameManager gameManager;

    private float topBound = 30.0f;
    private float leftBound = -30.0f;
    private float rightBound = 30.0f;
    private float lowerBound = -10.0f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            gameManager.UpdateLives(-1);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }else if (transform.position.x > rightBound)
        {
            Destroy (gameObject);
        }
    }
}
