using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public int curScore;
    public int highScore;


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

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }

        if (newScore > highScore)
        {
            highScore = newScore;
        }

        PlayerPrefs.SetInt("HighScore", highScore);

        currentScoreText.text = curScore.ToString();
        bestScoreText.text = highScore.ToString();
    }
}
