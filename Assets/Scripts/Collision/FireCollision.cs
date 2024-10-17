using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{   
    // �浹�� �ʿ��� ��ü: �÷��̾�� ��
    // �浹�� �Ͼ�� ���: �÷��̾��� ��Ʈ ����
    // �÷��̾��� ��Ʈ�� 0���� �Ǿ��� ���: �÷��̾ ����ϰ� ������ ����ȴ�.
    // �Ұ� �ٴ��� ������ ��� : ���� �ı��ȴ�.
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
