using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isDebugingMode = false;

    public static GameManager Instance { get; private set; }
    private int score = 0;
    public bool IsGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        score = 0;
        IsGameOver = false;
    }

    public void GameOver()
    {
        if (IsGameOver) return;
        DebugMode();
        IsGameOver = true;
        UIManager.Instance.ShowGameOver();
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    public void DebugMode()
    {
        if (isDebugingMode)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
