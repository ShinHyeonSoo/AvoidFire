using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int curScore;
    public int highScore;

    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

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
        currentScoreText.text = lastScore.ToString();
        bestScoreText.text = highScore.ToString();
    }
    public void GoToScoreboard()
    {
        SceneManager.LoadScene("ScoreboardScene");
    }
}
