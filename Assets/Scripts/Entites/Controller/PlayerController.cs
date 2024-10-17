using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;

    private int currentHealth;
    private int maxHealth;
    private bool isActiveShield = false;

    private HealthUIManager healthUIManager;
    private SpriteRenderer _spriteRenderer;
    AvoidFireAnimationController controller;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        controller = GetComponent<AvoidFireAnimationController>();
    }

    private void Start()
    {
        // TODO : ��Ʈ ���� ���� (����) - �Ϸ�
        currentHealth = player.HP;
        maxHealth = currentHealth;
        healthUIManager = FindObjectOfType<HealthUIManager>();
        healthUIManager.InitializeHealthUI(currentHealth);
    }

    public void TakeDamage()
    {
        if (currentHealth <= 0)
        {
            controller.DeadAnim();
            GameOver();
        }

        if (isActiveShield == false)
        {
            currentHealth--;
            healthUIManager.UpdateHealthUI(currentHealth);
        }

        controller.HitAnim();
        // TODO : �÷��̾� �ǰ� (����) - �Ϸ� + �״� ���
    }

    public void TakeHeal()
    {
        currentHealth++;
        //UI������Ʈ
        if (currentHealth > maxHealth)
        {
            maxHealth = currentHealth;
            healthUIManager.AddHeart();
        }

        healthUIManager.UpdateHealthUI(currentHealth);
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }
}
