using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] private Image warningImage;
    [SerializeField] private TweenScreen tweenScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        if (PlayerInformManager.instance.playerId != -1)
        {
            tweenScreen.Close("Game");
        }
        else
        {
            warningImage.gameObject.SetActive(true);
        }
        SoundManager.Instance.Play("select", Sound.Sfx);
    }
}
