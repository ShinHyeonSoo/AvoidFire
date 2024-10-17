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
        highScoreText.text = "�ְ� ����: " + ScoreManager.Instance.highScore;
        lastScoreText.text = "�� ����: " + ScoreManager.Instance.lastScore;
    }
}

