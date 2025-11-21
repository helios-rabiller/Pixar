using UnityEngine;

public class Tirer : MonoBehaviour
{
    public GameObject projectilePrefab;
    
    public Transform[] shootPoints; 
    
    public float bulletforce = 20f;
    public float Cadence = 0.8f; 
    private float nextFireTime = 0f;

    void Update()
    {   
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + Cadence;
        }
    }

    void Shoot()
    {
        foreach (Transform point in shootPoints)
        {
           
            if (point != null) 
            {
                GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
                
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null) 
                {
                    rb.AddForce(point.up * bulletforce, ForceMode2D.Impulse);
                }
                
                Destroy(projectile, 2.0f);
            }
        }
    }
}