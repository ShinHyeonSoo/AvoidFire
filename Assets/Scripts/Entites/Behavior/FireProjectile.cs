using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 5f;

    private int groundTagHash;
    private int playerTagHash;
    private int playerMagnetHash;

    private readonly float Distance = 0.25f;

    int score = 1;
    int magnetScore = 2;

    private void Awake()
    {
        groundTagHash = "Ground".GetHashCode();
        playerTagHash = "Player".GetHashCode();
        playerMagnetHash = "Magnet".GetHashCode();
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void CreateEffect(Collision2D collision)
    {
        Vector3 fireColliderCenter = GetComponent<Collider2D>().bounds.center;
        Vector3 groundColliderCenter = collision.gameObject.GetComponent<Collider2D>().bounds.center;

        Vector3 dir = (fireColliderCenter - groundColliderCenter).normalized;

        Vector3 hitPos = fireColliderCenter - dir * Distance;

        EffectManager.Instance.ShotEffect("explosion", hitPos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
            return;
        }

        // 충돌대상 해쉬값 가져오고
        int collisionTagHash = collision.gameObject.tag.GetHashCode();

        if (collisionTagHash == groundTagHash)
        {
            // TODO : 땅과 불 충돌
            Score.Instance.AddScore(score);
            CreateEffect(collision);
            Destroy(gameObject);
        }
        else if (collisionTagHash == playerTagHash)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage();
            }
            CreateEffect(collision);
            Destroy(gameObject);
        }
        else if (collisionTagHash == playerMagnetHash)
        {
            Score.Instance.AddScore(magnetScore);
            Destroy(gameObject);
        }
    }
    public float FallSpeed
    {
        get { return fallSpeed; }
        set { fallSpeed = value; }
    }
}
