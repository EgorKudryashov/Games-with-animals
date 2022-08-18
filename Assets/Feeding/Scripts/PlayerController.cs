using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    private float xRange = 15.0f;
    private float zRange = 8.0f;

    private int score;
    private int lives;


    public GameObject projectilePrefab;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver)
        {
            PlayerMovement();
            ShootProjectile();
        }
    }

    private void PlayerMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
    }

    private void ShootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public void Score(int addScore)
    {
        score+=addScore;
        Debug.Log("Score =" + score);
    }

    public void MinusLive()
    {
        --lives;
        if (lives > 0)
        {
            Debug.Log("Current Live: " + lives);
        }
        if (lives == 0)
        {
            Debug.LogWarning("Game_Over");
        }
        if (lives < 0)
        {
            Debug.Log("Current Live: 0");
        }

    }
    
}
