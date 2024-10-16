using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFireMovement : MonoBehaviour
{
    private AvoidFireController controller;
    private Rigidbody2D movementRigidbody;
    private Player player;
    private SpriteRenderer spriteRenderer;

    private Vector2 movementDirection = Vector2.zero;
    public bool isGrounded = true;
    private bool isFacingRight = true;

    private void Awake()
    {
        controller = GetComponent<AvoidFireController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        controller.OnMoveEvent += Move;
        controller.OnJumpEvent += Jump;
    }

    void Start()
    {
    }

    private void FixedUpdate()
    {
        // ���� ������Ʈ���� ������ ����
        // FixedUpdate�� ����������Ʈ ����
        // rigidebody�� ���� �ٲٴϱ� FixedUpdate
        ApplyMovement(movementDirection);

    }

    private void Move(Vector2 direction)
    {
        // �̵����⸸ ���صΰ� ������ ���������� ����.
        // �����̴� ���� ���� ������Ʈ���� ����(rigidbody�� �����ϱ�)
        movementDirection = direction;
    }

    private void Jump(bool isJump)
    {
        if (isGrounded && isJump)
        {
            // TODO : ���� ���� �׽�Ʈ �ؼ� ����
            movementRigidbody.AddForce(new Vector2(0, 1000f)); // ���� �� ����
            isGrounded = false; // ���� �Ŀ��� ���� ���·� ����
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 10f;

        movementRigidbody.velocity = direction;

        Flip(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ����� �� isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground")) // Ground��� �±׸� ���� ������Ʈ�� ������
        {
            isGrounded = true;
        }
    }

    private void Flip(Vector2 direction)
    {
        if (direction.x >= 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
