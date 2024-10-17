using System.Collections;
using UnityEngine;

public class RandomEffectManager : MonoBehaviour
{
    private Player player;
    private PlayerController controller;

    private void Awake()
    {
        player= GetComponent<Player>();
        controller = GetComponent<PlayerController>();
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
                ApplyShield();
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

    private void ApplyShield()
    {
        controller.ActivateShield(10f);
    }

    private void IncreasePlayerHealth()
    {
        controller.TakeHeal();
    }
}
