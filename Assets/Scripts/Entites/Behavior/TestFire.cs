using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TestFire : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;

    private int groundTagHash;
    private int playerTagHash;

    int score = 1;

    private void Awake()
    {
        groundTagHash = "Ground".GetHashCode();
        playerTagHash = "Player".GetHashCode();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌대상 해쉬값 가져오고
        int collisionTagHash = collision.gameObject.tag.GetHashCode();

        if (collisionTagHash == groundTagHash)
        {
            // TODO : 땅과 불 충돌
            Score.Instance.AddScore(score);
            Destroy(gameObject);
        }
        else if (collisionTagHash == playerTagHash)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage();
            }
            Destroy(gameObject);
        }

        // TODO : 이펙트 생성

    }
    public float FallSpeed
    {
        get { return fallSpeed; }
        set { fallSpeed = value; }
    }
}
