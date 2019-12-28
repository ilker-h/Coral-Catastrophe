using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainFish : MonoBehaviour
{

    [SerializeField]
    private float jumpSpeed = 5;
    private Rigidbody2D rb;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;

    void Start()
    {
        // setting up rigid body
        rb = GetComponent<Rigidbody2D>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutines();
        }
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // jump - https://www.youtube.com/watch?time_continue=662&v=QGDeafTx5ug <== video for jump code and physics

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        // fish can't go above the screen, and dies if it goes below the screen 
        if (transform.position.y > 4.6f)
        {
            transform.position = new Vector3(transform.position.x, 4.6f, 0);
        }
        else if (transform.position.y < -5)
        {
            this.gameObject.SetActive(false);
            _uiManager.gameOver = true;
            _uiManager.ShowGameOverText();
            Destroy(this.gameObject);
        }
    }

    // when fish hits coral, it gets destroyed
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coral")
        {
            this.gameObject.SetActive(false);
            _uiManager.gameOver = true;
            _uiManager.ShowGameOverText();
            Destroy(this.gameObject);
        }
    }
}
