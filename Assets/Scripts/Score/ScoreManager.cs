using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int highScore;
    public int lastScore;

    void Awake()
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

    public void UpdateScores(int newScore)
    {
        lastScore = newScore;
        if (newScore > highScore)
        {
            highScore = newScore;
        }
    }
    public void GoToScoreboard()
    {
        SceneManager.LoadScene("ScoreboardScene");
    }
}
