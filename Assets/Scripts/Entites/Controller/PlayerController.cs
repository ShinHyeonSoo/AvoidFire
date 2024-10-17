using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player player;
    private int currentHealth;
    private HealthUIManager healthUIManager;

    AvoidFireAnimationController controller;

    private void Awake()
    {
        player = GetComponent<Player>();
        controller = GetComponent<AvoidFireAnimationController>();
    }

    private void Start()
    {
        // TODO : ��Ʈ ���� ���� (����) - �Ϸ�
        currentHealth = player.HP;
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
            controller.DeadAnim();
            GameOver();
        }

        controller.HitAnim();
        // TODO : �÷��̾� �ǰ� (����) - �Ϸ� + �״� ���
    }

    public void TakeHeal()
    {
        currentHealth++;
    }

    private void GameOver()
    {
        GameManager.Instance.GameOver();
    }

    public void ActivateShield(int index)
    {

    }
}
