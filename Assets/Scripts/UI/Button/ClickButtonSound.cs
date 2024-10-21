using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClickButtonSound : MonoBehaviour
{
    [SerializeField] private string _soundStr;
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClickButtonSound);
    }

    public void OnClickButtonSound()
    {
        SoundManager.Instance.PlaySFX(_soundStr);
    }
}
