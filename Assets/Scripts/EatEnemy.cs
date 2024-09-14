using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatEnemy : MonoBehaviour
{
    public Health health;
    public GameOverScreen gameOverScreen;
    void Start()
    {
        Debug.Log("Player");
    }

    
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("trigger");
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (health.currentHealth > enemyHealth.currentHealth)
            {
                // Absorb enemy's health
                health.PlayerKills(enemyHealth.currentHealth);

                // Destroy enemy
                Destroy(collision.gameObject);
            }
            else if (health.currentHealth < enemyHealth.currentHealth)
            {
                health.PlayerDie();
                gameOverScreen.gameOver();
            }
        }
    }
}
