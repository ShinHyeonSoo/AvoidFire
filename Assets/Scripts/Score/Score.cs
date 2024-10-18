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
            Destroy(gameObject); // �̹� �ν��Ͻ��� �ִٸ� ���ο� �ν��Ͻ��� �ı�
        }
    }
    public void CallUpdateScores()
    {
        ScoreManager.Instance.UpdateScores(totalScore);
    }
}
