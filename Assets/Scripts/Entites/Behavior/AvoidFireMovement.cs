using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFireMovement : MonoBehaviour
{
    private AvoidFireController movementController;
    private Rigidbody2D movementRigidbody;
    private Player player;

    private Vector2 movementDirection = Vector2.zero;
    private bool isGrounded = true;

    private void Awake()
    {
        movementController = GetComponent<AvoidFireController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();

        movementController.OnMoveEvent += Move;
        movementController.OnJumpEvent += Jump;
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
            movementRigidbody.AddForce(new Vector2(0, 300f)); // ���� �� ����
            isGrounded = false; // ���� �Ŀ��� ���� ���·� ����
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 10f;

        movementRigidbody.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ����� �� isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground")) // Ground��� �±׸� ���� ������Ʈ�� ������
        {
            isGrounded = true;
        }
    }
}
