using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer titleSpriteRenderer;
    [SerializeField] private float blinkSpeed = 1f;
    [SerializeField] private string characterSelectionSceneName = "CharacterSelection";  // TODO:: 캐릭터 선택 씬으로 수정할것
    private bool isBlinking = true;

    private void Start()
    {
        StartCoroutine(BlinkImage());
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            StopCoroutine(BlinkImage());

            SceneManager.LoadScene(characterSelectionSceneName);
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
