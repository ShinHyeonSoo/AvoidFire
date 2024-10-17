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
        // TODO : 하트 개수 변경 (예림) - 완료
        currentHealth = player.HP;
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
            controller.DeadAnim();
            GameOver();
        }

        controller.HitAnim();
        // TODO : 플레이어 피격 (예림) - 완료 + 죽는 모션
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
