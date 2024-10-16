using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text scoreText;
    [Header("Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    private TweenButton tweenButton;

    private void Start()
    {
        tweenButton = GetComponent<TweenButton>();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        //UpdateScore(0);

        SoundManager.Instance.Play("bgm_blues_guitar1", Sound.Bgm);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ShowGameOver()
    {
        tweenButton.OnButtonOpen(gameOverPanel);
    }

    public void PasueGame()
    {
        Time.timeScale = 0f;
        tweenButton.OnButtonOpen(pausePanel);
    }

    public void ResumeGame()
    {
        StartCoroutine(CoroutineResume());
    }

    IEnumerator CoroutineResume()
    {
        yield return new WaitUntil(() => !pausePanel.activeSelf);
        Time.timeScale = 1f;
    }
}
