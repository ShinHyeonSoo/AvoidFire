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
        // TODO : 하트 개수 변경 (예림)
        currentHealth = maxHealth;
        healthUIManager = FindObjectOfType<HealthUIManager>();
        healthUIManager.InitializeHealthUI(currentHealth);
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;//중복방지

        currentHealth--;
        healthUIManager.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }

        // TODO : 플레이어 피격 (예림)
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
