using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClickButtonStart);
    }

    public void OnClickButtonStart()
    {
        PlayerInformManager.instance.GameStart();
    }
}
