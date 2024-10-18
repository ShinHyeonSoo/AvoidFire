using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TweenScreen : MonoBehaviour
{
    private RectTransform _rectTrans;

    private float _targetPosX = 0;
    private float _duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        _rectTrans = GetComponent<RectTransform>();

        if (SceneManager.GetActiveScene().name != "Title")
            Open();
    }

    public void Close(string sceneName)
    {
        var seq = DOTween.Sequence();

        seq.Append(_rectTrans.DOAnchorPosX(_targetPosX, _duration).SetEase(Ease.OutCirc));

        seq.Play().SetUpdate(true).OnComplete(() => { SceneManager.LoadScene(sceneName); });
    }

    public void Open()
    {
        var seq = DOTween.Sequence();

        seq.Append(_rectTrans.DOAnchorPosX(_targetPosX, _duration).SetEase(Ease.OutCirc));
        seq.Append(_rectTrans.DOAnchorPosX(-1920, _duration * 0.5f));

        seq.Play().SetUpdate(true);
    }
}
