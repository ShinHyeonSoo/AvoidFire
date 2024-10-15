using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   
    // 충돌이 필요한 객체: 플레이어와 불
    // 충돌이 일어났을 경우: 플레이어의 하트 감소
    // 플레이어의 하트가 0개가 되었을 경우: 플레이어가 사망하고 게임이 종료된다.
    // 불과 바닥이 만났을 경우 : 불이 파괴된다.
    private Rigidbody2D rigidbody2D;
    private int heart = 3; // 플레이어의 초기 하트 수

    public void Start() 
    { 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            heart--;
            // 1. 플레이어가 넉백된다.(0.1~0.5초 정도 경직)
            // 2. 플레이어가 맞아서 하트가 감소했다는 리액션(문구 등)
            if (heart <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("플레이어가 사망하였습니다.");
        }
    }
}
