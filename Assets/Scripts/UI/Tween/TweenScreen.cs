using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TweenScreen : MonoBehaviour
{
    private RectTransform _rectTrans;
    [SerializeField]private RectTransform _rectTransMon;
    [SerializeField] private Animator _animatorMon;

    private float _targetPosX = 0;
    private float _duration = 1f;

    void Start()
    {
        DOTween.Init();
        _rectTrans = GetComponent<RectTransform>();

        var mon = transform.GetChild(0).gameObject;
        _rectTransMon = mon.GetComponent<RectTransform>();
        _animatorMon = mon.GetComponent<Animator>();

        Open();
    }

    public void Close(string sceneName)
    {
        var seq = DOTween.Sequence();
        
        seq.Append(_rectTransMon.DOAnchorPosY(_targetPosX, _duration * 1.2f).SetEase(Ease.OutCirc));
        seq.Play().SetUpdate(true).OnComplete(() => { LoadScene(sceneName); });
    }

    public void Open()
    {
        var seq = DOTween.Sequence();

        seq.Append(_rectTrans.DOAnchorPosX(_targetPosX, _duration).SetEase(Ease.OutCirc));
        seq.Append(_rectTrans.DOAnchorPosX(-1920, _duration * 0.5f));

        seq.Play().SetUpdate(true);
    }

    private void LoadScene(string sceneName)
    {
        
        _animatorMon.SetTrigger("Start");
        var seq = DOTween.Sequence();
        seq.Append(_rectTrans.DOAnchorPosX(_targetPosX, _duration * 1.5f).SetEase(Ease.OutCirc));
        seq.Play().SetUpdate(true).OnComplete(() => 
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(sceneName); 
        });
    }
}
