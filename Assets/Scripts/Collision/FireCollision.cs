using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    private int groundTagHash;
    private int playerTagHash;

    private void Awake()
    {
        groundTagHash = "Ground".GetHashCode();
        playerTagHash = "Player".GetHashCode();
    }

    int score = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionTagHash = collision.gameObject.tag.GetHashCode();

        if (collisionTagHash == playerTagHash)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.TakeDamage();
            Destroy(this.gameObject);
        }

        else if (collisionTagHash == groundTagHash)
        {
            Score.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }
}
