using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score = 0;
    private bool isGameOver = false;

    public DataManager _dataManager; // GetComponent 지웠습니다. 사용시 다시 설정해주세요.

    private void Awake()
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

    public void StartGame()
    {
        score = 0;
        isGameOver = false;
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        //UIManager.Instance.ShowGameOver();  //TODO:: UI매니저 인스턴스화
    }

    public void RestartGame()
    {
        //TODO :: 게임 재시작 로직
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }
}
