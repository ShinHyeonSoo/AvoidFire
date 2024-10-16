using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenButton : MonoBehaviour
{
    [Header("Popup")]
    public TweenPopup _popup;

    public void OnButtonClose()
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().SetUpdate(true).OnComplete(() => { _popup.Hide(); });
    }

    public void OnButtonClose(GameObject obj)
    {
        _popup = obj.GetComponent<TweenPopup>();

        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().SetUpdate(true).OnComplete(() => { _popup.Hide(); });
    }

    public void OnButtonOpen()
    {
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().SetUpdate(true).OnComplete(() => { _popup.Show(); });
    }

    public void OnButtonOpen(GameObject obj)
    {
        _popup = obj.GetComponent<TweenPopup>();

        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));
        seq.Play().SetUpdate(true).OnComplete(() => { _popup.Show(); });
    }
}
