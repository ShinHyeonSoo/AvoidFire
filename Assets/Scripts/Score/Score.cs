using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public Text totalScoreTxt;

    int totalScore;

    public void AddScore(int score)
    {
        totalScore += score;
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
            Destroy(gameObject); // 이미 인스턴스가 있다면 새로운 인스턴스를 파괴
        }
    }
    public void CallUpdateScores()
    {
        ScoreManager.Instance.UpdateScores(totalScore);
    }
}
