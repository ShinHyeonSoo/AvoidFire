using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int life = 5;
    private bool isGameOver = false;

    public void TakeDamage()
    {
        if (isGameOver) return;

        life--;
        Debug.Log("Player Life: " + life);

        if (life <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        GameManager.Instance.GameOver();
    }
}
