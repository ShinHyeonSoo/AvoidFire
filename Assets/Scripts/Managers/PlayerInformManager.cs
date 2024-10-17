using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformManager : MonoBehaviour
{
    public static PlayerInformManager instance;
    private InputPlayerInform inputInform;

    public int playerId;
    public string playerName;

    public Transform PlayerTransform { get; private set; } // 플레이어 transform

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        playerId = 0;
    }

    private void Start()
    {
        inputInform = GetComponent<InputPlayerInform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {

        // TODO : 게임 시작시 플레이어 세팅값 전달

        SceneManagement.LoadScene("Game");
    }

    public void SetId(int id)
    {
        playerId = id;
    }
}
