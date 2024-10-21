using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] private int _type;
    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(OnValueChangedVolume);
        SoundManager.Instance.InitSlider(_type, gameObject);
    }

    public void OnValueChangedVolume(float value)
    {
        SoundManager.Instance.SetVolume(_type, gameObject);
    }
}
