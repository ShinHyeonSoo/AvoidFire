using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenPopup : MonoBehaviour
{
    // .SetUpdate(true) -> TimeScale 이 0 이여도 실행
    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
    }

    public void Show()
    {
        gameObject.SetActive(true);

        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().SetUpdate(true);
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.05f, 0.2f));

        seq.Play().SetUpdate(true).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
