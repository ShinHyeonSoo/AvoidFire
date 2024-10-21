using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    public GameObject playerObject;

    private int currentHealth;
    private int maxHealth;
    private bool isActiveShield = false;

    private HealthUIManager healthUIManager;
    private SpriteRenderer _spriteRenderer;
    AvoidFireAnimationController controller;
    AvoidFireMovement movement;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        controller = GetComponent<AvoidFireAnimationController>();
        movement = GetComponent<AvoidFireMovement>();
    }

    private void Start()
    {
        currentHealth = player.HP;
        maxHealth = currentHealth;
        healthUIManager = FindObjectOfType<HealthUIManager>();
        healthUIManager.InitializeHealthUI(currentHealth);
    }

    public void TakeDamage()
    {
        if (isActiveShield == false)
        {
            currentHealth--;
            healthUIManager.UpdateHealthUI(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Score.Instance.CallUpdateScores();
            DeadSet();
            GameOver();
            SoundManager.Instance.Play("bomb", Sound.Sfx);
        }
        else
        {
            SoundManager.Instance.Play("damage", Sound.Sfx);
            EffectManager.Instance.ShotEffect("hurt", transform.position);
            controller.HitAnim();
        }

        
    }

    public void TakeHeal()
    {
        currentHealth++;
        //UI업데이트
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

    private void DeadSet()
    {
        controller.DeadAnim();

        StartCoroutine(WaitForGrounded());
    }

    IEnumerator WaitForGrounded()
    {
        // 땅에 착지 할 때까지 기다림
        while (!movement.isGrounded)
        {
            Debug.Log(movement.isGrounded);
            yield return null; // 한 프레임 대기
        }

        Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }

        Collider2D playerCollider = playerObject.GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        _spriteRenderer.flipX = false;
        player.isDead = true;
    }

}
