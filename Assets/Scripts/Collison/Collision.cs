using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{   
    // �浹�� �ʿ��� ��ü: �÷��̾�� ��
    // �浹�� �Ͼ�� ���: �÷��̾��� ��Ʈ ����
    // �÷��̾��� ��Ʈ�� 0���� �Ǿ��� ���: �÷��̾ ����ϰ� ������ ����ȴ�.
    // �Ұ� �ٴ��� ������ ��� : ���� �ı��ȴ�.
    private Rigidbody2D rigidbody2D;
    private int heart = 3; // �÷��̾��� �ʱ� ��Ʈ ��

    public void Start() 
    { 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            heart--;
            // 1. �÷��̾ �˹�ȴ�.(0.1~0.5�� ���� ����)
            // 2. �÷��̾ �¾Ƽ� ��Ʈ�� �����ߴٴ� ���׼�(���� ��)
            if (heart <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            Debug.Log("�÷��̾ ����Ͽ����ϴ�.");
        }
    }
}
