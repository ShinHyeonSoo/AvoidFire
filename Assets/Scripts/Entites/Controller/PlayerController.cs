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
        // TODO : ��Ʈ ���� ���� (����)
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

        // TODO : �÷��̾� �ǰ� (����)
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
