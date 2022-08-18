using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;
    public int diet;
    private int hit;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        hit = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameManager.isGameOver)
        {
            Destroy(other.gameObject);
            ++hit;
            if (hit == diet)
            {
                Destroy(gameObject);
                gameManager.UpdateScore(diet);
            }
        }
    }
}
