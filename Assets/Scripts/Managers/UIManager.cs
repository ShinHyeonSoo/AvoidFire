using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Text")]
    [SerializeField] private Text scoreText;
    [Header("Panel")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TweenScreen _tweenScreen;

    private TweenButton tweenButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void TweenScreenClose(string sceneName)
    {
        _tweenScreen.Close(sceneName);
        Time.timeScale = 1f;
    }

    IEnumerator CoroutineResume()
    {
        yield return new WaitUntil(() => !pausePanel.activeSelf);
        Time.timeScale = 1f;
    }
}
