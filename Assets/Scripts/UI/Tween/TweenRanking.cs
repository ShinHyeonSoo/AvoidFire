using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRanking : MonoBehaviour
{
    private RectTransform _rectTrans;

    private float _startPosY;
    private float _targetPosY = 0;
    private float _targetOffset = 25f;
    private float _duration = 0.5f;
    private float _swingDuration = 0.2f;

    private void Start()
    {
        _rectTrans = GetComponent<RectTransform>();
        _startPosY = _rectTrans.localPosition.y;

        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);

        var seq = DOTween.Sequence();
        seq.Append(_rectTrans.DOAnchorPosY(_targetPosY - _targetOffset, _duration));
        seq.Append(_rectTrans.DOAnchorPosY(_targetPosY + _targetOffset, _swingDuration));
        seq.Append(_rectTrans.DOAnchorPosY(_targetPosY, _swingDuration));

        seq.Play().SetUpdate(true);
    }

    public void Close()
    {
        var seq = DOTween.Sequence();
        
        seq.Append(_rectTrans.DOAnchorPosY(_targetPosY - _targetOffset, _swingDuration));
        seq.Append(_rectTrans.DOAnchorPosY(_startPosY, _duration));

        seq.Play().SetUpdate(true).OnComplete(() => gameObject.SetActive(false));
    }
}
