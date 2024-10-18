using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private float blinkSpeed = 1f;
    [SerializeField] private string characterSelectionSceneName = "CharacterSelect";  // TODO:: 캐릭터 선택 씬으로 수정할것
    [SerializeField] private TweenScreen tweenScreen;
    private bool isBlinking = true;

    public bool IsTween { get; set; }

    private void Start()
    {
        IsTween = false;
        StartCoroutine(BlinkImage());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StopCoroutine(BlinkImage());
            tweenScreen.Close(characterSelectionSceneName);
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
