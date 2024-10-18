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
            DeadSet();
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

    private void DeadSet()
    {
        Collider2D playerCollider = playerObject.GetComponent<Collider2D>();
        if (playerCollider != null)
        {
            playerCollider.enabled = false;  // �ݶ��̴� ��Ȱ��ȭ
        }

        Rigidbody2D playerRigidbody = playerObject.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }

        _spriteRenderer.flipX = false;
        player.isDead = true;
    }
    
}
