using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject panel;
    
    void Update()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontal, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        
        if (horizontal > 0f)
        {
            
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontal < 0f)
        {
            
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        
        if (collision.gameObject.CompareTag("MiniBallon"))
        {
            if (panel != null)
            {
                panel.SetActive(true);
                Debug.Log("Game Over Panel Açýldý!");
            }

            Time.timeScale = 0f; 

        }
    }
}
