using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRanking : MonoBehaviour
{
    private RectTransform _rectTrans;

    private float _StartPosY;
    private float _duration = 1f;
    

    private void Start()
    {
        _rectTrans = GetComponent<RectTransform>();
        _StartPosY = _rectTrans.localPosition.y;

        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);

        _rectTrans.DOAnchorPosY(0f, _duration);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
