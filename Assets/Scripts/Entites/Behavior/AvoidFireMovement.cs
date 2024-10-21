using UnityEngine;

public class AvoidFireMovement : MonoBehaviour
{
    private AvoidFireController controller;
    private Rigidbody2D movementRigidbody;
    private Player player;
    private SpriteRenderer spriteRenderer;

    private Vector2 movementDirection = Vector2.zero;
    public bool isGrounded = true;

    private void Awake()
    {
        controller = GetComponent<AvoidFireController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
    }

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        // 물리 업데이트에서 움직임 적용
        // FixedUpdate는 물리업데이트 관련
        // rigidebody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);

        if (!isGrounded)
        {
            ApplyBetterJumpPhysics(); // 향상된 중력 적용 함수 호출
        }

    }

    private void Move(Vector2 direction)
    {
        // 이동방향만 정해두고 실제로 움직이지는 않음.
        // 움직이는 것은 물리 업데이트에서 진행(rigidbody가 물리니까)
        movementDirection = direction;
    }

    private void Jump(bool isJump)
    {
        if (isGrounded && isJump)
        {
            // X축 방향도 영향을 주도록 Vector2에 X축 방향 추가
            Vector2 jumpDirection = new Vector2(movementDirection.x * player.speed * 10 , player.jumpPower);
            movementRigidbody.AddForce(jumpDirection, ForceMode2D.Impulse); // 점프 힘 설정
            isGrounded = false; // 점프 후에는 공중 상태로 설정
            SoundManager.Instance.Play("jump", Sound.Sfx, 0.5f);
        }
    }


    private void ApplyMovement(Vector2 direction)
    {
        Vector2 velocity = movementRigidbody.velocity;

        // 지면에 있을 때와 공중에 있을 때의 X축 속도 처리
        if (isGrounded)
        {
            velocity.x = direction.x * player.speed; // 지면에서의 X축 속도
        }
        else
        {
            // 공중에 있을 때 X축 속도 유지 (air control)
            velocity.x = direction.x * (player.speed / 3) * 2; // 공중 제어 속도 설정
        }

        movementRigidbody.velocity = velocity; // 속도 적용
        Flip(direction); // 캐릭터 방향 전환
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅에 닿았을 때 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground")) // Ground라는 태그를 가진 오브젝트에 닿으면
        {
            isGrounded = true;
        }
    }

    private void ApplyBetterJumpPhysics()
    {
        if (movementRigidbody.velocity.y < 0) // 하강 중일 때
        {
            movementRigidbody.gravityScale *= 1.06f; // 하강 중에는 강한 중력
        }
        else
        {
            movementRigidbody.gravityScale = 3f;
        }
    }

    private void Flip(Vector2 direction)
    {
        if (!player.isDead)
        {
            if (direction.x > 0)
                spriteRenderer.flipX = false;
            else if (direction.x < 0)
                spriteRenderer.flipX = true;
        }
    }
}
