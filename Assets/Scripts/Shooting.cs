using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public Transform shootingPoint;      
    public float shootingForce = 15f;    

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        
        rb.velocity = new Vector2(0f, shootingForce);

        
        Destroy(projectile, 2f);
    }
}
