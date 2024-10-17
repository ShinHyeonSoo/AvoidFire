using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{   
    // 충돌이 필요한 객체: 플레이어와 불
    // 충돌이 일어났을 경우: 플레이어의 하트 감소
    // 플레이어의 하트가 0개가 되었을 경우: 플레이어가 사망하고 게임이 종료된다.
    // 불과 바닥이 만났을 경우 : 불이 파괴된다.
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    int score = 1;

    public void Start() 
    { 
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage();
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            Score.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
