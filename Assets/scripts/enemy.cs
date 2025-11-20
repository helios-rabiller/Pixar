using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public Transform player;
    public float enemyPv;
    
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            // 1. Calculer le vecteur direction vers le joueur
            Vector2 direction = (player.position - transform.position).normalized;
            
            // 2. Calculer l'angle en degrés
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f); 
            // 3. Déplacer l'ennemi vers le joueur
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }

        if (enemyPv <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            enemyPv --;
            Destroy(collision.gameObject); 
        }
    }
}