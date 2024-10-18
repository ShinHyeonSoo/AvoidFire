using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text curScoreText;
    public Text highScoreText;

    void Start()
    {
        curScoreText.text = "" + ScoreManager.Instance.curScore;
        highScoreText.text = "" + ScoreManager.Instance.highScore;
        ScoreManager.Instance.scoreEvent += UpdateUi;
    }
    void UpdateUi(int a, int b)
    {
        curScoreText.text = a.ToString();
        highScoreText.text = b.ToString();
    }
}