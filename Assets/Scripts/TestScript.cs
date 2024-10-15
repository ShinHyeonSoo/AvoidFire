using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private readonly float Distance = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO : ground 와 player 일때만 실행되도록 조건달기
        Vector3 fireColliderCenter = GetComponent<Collider2D>().bounds.center;
        Vector3 groundColliderCenter = collision.bounds.center;

        Vector3 dir = (fireColliderCenter - groundColliderCenter).normalized;

        Vector3 hitPos = fireColliderCenter - dir * Distance;

        EffectManager.Instance.Explosion(hitPos);
        Destroy(gameObject);
    }
}
