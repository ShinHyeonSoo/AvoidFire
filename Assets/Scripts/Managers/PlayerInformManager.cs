using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformManager : MonoBehaviour
{
    [SerializeField] private Image warningImage; 
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        if(playerId != -1)
        {
            SceneManagement.LoadScene("Game");
        }
        else
        {
            warningImage.gameObject.SetActive(true);
        }
    }

    public void SetId(int id)
    {
        playerId = id;
    }
}
