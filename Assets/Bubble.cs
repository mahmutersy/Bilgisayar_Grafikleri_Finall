using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    public GameObject bubbleFragmentPrefab; 
    public int fragmentsCount = 2; 
    private bool isOnGround = false; 
    public bool isFragment = false; 

    public GameObject panel; 
    public GameObject bubblePrefab; 
    public float spawnInterval = 20f; 
    public Transform spawnPoint; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (!isFragment)
        {
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 2f)) * speed;
        }

        rb.sharedMaterial = new PhysicsMaterial2D
        {
            friction = 0f,
            bounciness = 0.8f
        };

        if (!isFragment)
        {
            InvokeRepeating(nameof(SpawnBubble), spawnInterval, spawnInterval);
        }
    }

    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }

        if (!isOnGround && transform.position.y <= -5f)
        {
            isOnGround = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFragment && collision.gameObject.CompareTag("Shot"))
        {
            Destroy(gameObject);
            SpawnFragments();
            Destroy(collision.gameObject);
        }
        else if (isFragment && collision.gameObject.CompareTag("Shot"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (panel != null)
            {
                panel.SetActive(true);
                Debug.Log("Game Over Panel Açýldý!");
            }

            Time.timeScale = 0f;
        }
    }

    void SpawnFragments()
    {
        for (int i = 0; i < fragmentsCount; i++)
        {
            GameObject fragment = Instantiate(bubbleFragmentPrefab, transform.position, Quaternion.identity);
            Bubble fragmentScript = fragment.GetComponent<Bubble>();

            Rigidbody2D fragmentRb = fragment.GetComponent<Rigidbody2D>();
            fragmentRb.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(1f, 3f)) * speed;

            fragmentScript.isFragment = true;

            fragmentRb.sharedMaterial = new PhysicsMaterial2D
            {
                friction = 0f,
                bounciness = 1f
            };
        }
    }

    void SpawnBubble()
    {
        if (spawnPoint != null)
        {
            Instantiate(bubblePrefab, new Vector3(Random.Range(-7f, 7f), spawnPoint.position.y, 0), Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Spawn Point atanmamýþ. Lütfen sahnede bir Transform objesi belirleyin.");
        }
    }
}
