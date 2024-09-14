using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int currentHealth;
    void Start()
    {
        healthText.text = currentHealth.ToString();
    }

    
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        healthText.transform.position = screenPos;

    }

    public void PlayerDie()
    {
        Destroy(gameObject);
    }

    public void PlayerKills(int enemyhealth)
    {
        currentHealth += enemyhealth;
        healthText.text = currentHealth.ToString();
    }
}
