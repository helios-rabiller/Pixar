using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tirer : MonoBehaviour
{
   public GameObject projectilePrefab;
   public Transform shootPoint;
   public float bulletforce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.up * bulletforce, ForceMode2D.Impulse);
        Destroy(projectile, 5.0f);
    }
}
