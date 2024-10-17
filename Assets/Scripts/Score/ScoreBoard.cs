using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text highScoreText;
    public Text lastScoreText;

    void Start()
    {
        highScoreText.text = "최고 점수: " + ScoreManager.Instance.highScore;
        lastScoreText.text = "내 점수: " + ScoreManager.Instance.lastScore;
    }
}

