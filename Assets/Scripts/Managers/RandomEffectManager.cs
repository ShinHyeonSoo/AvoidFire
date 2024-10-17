using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RandomEffectManager : MonoBehaviour
{
    private Player player;
    private PlayerController controller;

    private string originalPlayerTag;

    [SerializeField] private float magnetRadius = 10f;
    [SerializeField] private float magnetPullForce = 30f;

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
            controller = playerObject.GetComponent<PlayerController>();
            originalPlayerTag = playerObject.tag;
        }
    }

    public void ApplyRandomEffect()
    {
        int randomEffect = Random.Range(1, 4);

        switch (randomEffect)
        {
            case 1:
                StartCoroutine(ApplyTimeSlowAndSpeedUp());
                break;
            case 2:
                StartCoroutine(ActivateMagnet(15f));
                break;
            case 3:
                IncreasePlayerHealth();
                break;
        }
    }

    private IEnumerator ApplyTimeSlowAndSpeedUp()
    {
        Time.timeScale = 0.5f;
        player.speed *= 1.5f;

        yield return new WaitForSecondsRealtime(5f);

        Time.timeScale = 1f;
        player.speed /= 1.5f;
    }

    private void IncreasePlayerHealth()
    {
        controller.TakeHeal();
    }

    private IEnumerator ActivateMagnet(float duration)
    {
        player.gameObject.tag = "Ground";

        float elapsedTime = 0f;
        
        while (elapsedTime < duration)
        {
            Collider2D[] fireObjects = Physics2D.OverlapCircleAll(player.transform.position, magnetRadius);

            foreach (Collider2D fireObject in fireObjects)
            {
                if (fireObject.CompareTag("Fire"))
                {
                    Vector2 directionToPlayer = (player.transform.position - fireObject.transform.position).normalized;
                    fireObject.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * magnetPullForce);
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.gameObject.tag = originalPlayerTag;
    }

}
