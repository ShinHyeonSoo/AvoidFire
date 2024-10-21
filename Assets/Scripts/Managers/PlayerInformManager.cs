using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformManager : MonoBehaviour
{
    [SerializeField] private Image warningImage;
    [SerializeField] private TweenScreen tweenScreen;
    public static PlayerInformManager instance;
    private InputPlayerInform inputInform;

    public int playerId;
    public string playerName;

    public Transform PlayerTransform { get; private set; } // 플레이어 transform

    private void Awake()
    { 
        if (instance != null) Destroy(gameObject);
        instance = this;
        playerId = -1;
    }

    private void Start()
    {
        inputInform = GetComponent<InputPlayerInform>();
    }

    public void GameStart()
    {
        if(playerId != -1)
        {
            tweenScreen.Close("Game");
        }
        else
        {
            warningImage.gameObject.SetActive(true);
        }
        SoundManager.Instance.Play("select", Sound.Sfx);
    }

    public void SetId(int id)
    {
        playerId = id;
    }
}
