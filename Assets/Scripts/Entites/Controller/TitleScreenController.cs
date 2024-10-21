using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private float blinkSpeed = 1f;
    [SerializeField] private string characterSelectionSceneName = "CharacterSelect";
    [SerializeField] private TweenScreen tweenScreen;
    private bool isBlinking = true;

    public bool IsTween { get; set; }

    private void Start()
    {
        IsTween = false;
        StartCoroutine(BlinkImage());
        SoundManager.Instance.Play("title", Sound.Bgm);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StopCoroutine(BlinkImage());
            tweenScreen.Close(characterSelectionSceneName);
            SoundManager.Instance.Play("select", Sound.Sfx);
        }
    }

    private IEnumerator BlinkImage()
    {
        while (isBlinking)
        {
            while (titleSpriteRenderer.color.a < 1f)
            {
                Color newColor = titleSpriteRenderer.color;
                newColor.a += Time.deltaTime * blinkSpeed; 
                titleSpriteRenderer.color = newColor;
                yield return null;
            }

            while (titleSpriteRenderer.color.a > 0f)
            {
                Color newColor = titleSpriteRenderer.color;
                newColor.a -= Time.deltaTime * blinkSpeed;
                titleSpriteRenderer.color = newColor;
                yield return null;
            }
        }
    }
}
