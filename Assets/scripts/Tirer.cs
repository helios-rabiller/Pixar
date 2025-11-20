using UnityEngine;

public class Tirer : MonoBehaviour
{
    public GameObject projectilePrefab;
    
    // CHANGEMENT ICI : On met des crochets [] pour dire "plusieurs points"
    public Transform[] shootPoints; 
    
    public float bulletforce = 20f;
    public float Cadence = 0.8f; // Cadence plus lente pour un fusil à pompe
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
        // CHANGEMENT ICI : On boucle sur chaque point de tir
        foreach (Transform point in shootPoints)
        {
            // On utilise "point" au lieu de "shootPoint"
            if (point != null) // Sécurité au cas où un point est vide
            {
                GameObject projectile = Instantiate(projectilePrefab, point.position, point.rotation);
                
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                if (rb != null) 
                {
                    // IMPORTANT : La balle part dans la direction du point spécifique (point.up)
                    // C'est ça qui permet de faire l'effet de dispersion (spread)
                    rb.AddForce(point.up * bulletforce, ForceMode2D.Impulse);
                }
                
                Destroy(projectile, 2.0f);
            }
        }
    }
}