﻿using System;
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
            movementRigidbody.AddForce(new Vector2(0, player.jumpPower)); // 점프 힘 설정
            isGrounded = false; // 점프 후에는 공중 상태로 설정
        }
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * player.speed;

        movementRigidbody.velocity = direction;

        Flip(direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 땅에 닿았을 때 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground")) // Ground라는 태그를 가진 오브젝트에 닿으면
        {
            isGrounded = true;
        }
    }
    private void Flip(Vector2 direction)
    {
        if (direction.x > 0)
            spriteRenderer.flipX = false;
        else if(direction.x < 0)
            spriteRenderer.flipX = true;
    }
}
