using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // 점수판이 있어야 할 곳 : 인 게임 씬, 점수 씬
    public static Score Instance;
    public Text totalScoreTxt;

    int totalScore;

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
        Debug.Log(totalScore);
    }
}
