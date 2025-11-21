using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Joueur : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;
    public Vector2 movement;
    public Vector2 mousePos;

    public int maxPV = 100;
    public int currentPV;

    public Health_system healthSystem;

    public GameObject GameOverScreen;

    void Start()
    {
        currentPV = maxPV;
        healthSystem.SetMaxHealth(maxPV);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (currentPV <= 0)
        {
            GameOverScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    void TakeDamage(int damage)
    {
        currentPV -= damage;
        healthSystem.SetHealth(currentPV);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20); 
        }
    }
}
