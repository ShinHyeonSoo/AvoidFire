using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 5;
    private int currentHealth;
    private HealthUIManager healthUIManager;

    private void Start()
    {
        currentHealth = maxHealth;
        healthUIManager = FindObjectOfType<HealthUIManager>();
        healthUIManager.InitializeHealthUI(currentHealth);
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;//�ߺ�����

        currentHealth--;
        healthUIManager.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
