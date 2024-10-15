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
        // 물리 업데이트에서 움직임 적용
        // FixedUpdate는 물리업데이트 관련
        // rigidebody의 값을 바꾸니까 FixedUpdate
        ApplyMovement(movementDirection);

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
            // TODO : 점프 높이 테스트 해서 결정
            movementRigidbody.AddForce(new Vector2(0, 300f)); // 점프 힘 설정
            isGrounded = false; // 점프 후에는 공중 상태로 설정
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 10f;

        movementRigidbody.velocity = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅에 닿았을 때 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground")) // Ground라는 태그를 가진 오브젝트에 닿으면
        {
            isGrounded = true;
        }
    }
}
