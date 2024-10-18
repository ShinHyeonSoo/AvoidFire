using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int curScore;
    public int highScore;

    public event Action<int, int> scoreEvent;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScores(int newScore)
    {
        curScore = newScore;
        if (newScore > highScore)
        {
            highScore = newScore;
        }
        scoreEvent?.Invoke(curScore, highScore);
    }
}
