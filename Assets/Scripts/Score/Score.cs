using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // �������� �־�� �� �� : �� ���� ��, ���� ��
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
