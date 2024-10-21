using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public Text totalScoreTxt;
    public RankingManager rankingManager;
    public int totalScore;

    public void AddScore(int score)
    {
        if (GameManager.Instance.IsGameOver == false)
        {
            totalScore += score;
        }
        totalScoreTxt.text = totalScore.ToString();
    }
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
    public void CallUpdateScores()
    {
        string playerName = PlayerInformManager.instance.playerName;
        if (playerName == null)
        {
            playerName = "이름없음";
        }
        rankingManager.AddNewScore(playerName, totalScore);
        ScoreManager.Instance.UpdateScores(totalScore);
    }
}
