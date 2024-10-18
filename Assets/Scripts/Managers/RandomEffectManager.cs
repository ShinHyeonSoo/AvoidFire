using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomEffectManager : MonoBehaviour
{
    private Player player;
    private PlayerController controller;
    private AvoidFireAutoMovement avoidFireAutoMovement;
    private AvoidFireMovement avoidFireMovement;

    private string originalPlayerTag;

    [SerializeField] private float magnetRadius = 10f;
    [SerializeField] private float magnetPullForce = 30f;
    [SerializeField] private TextMeshProUGUI effectMessageText;
    [SerializeField] private float messageDisplayTime = 2f;
    [SerializeField] private float avoidFireDuration = 10f;

    private void Awake()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.GetComponent<Player>();
            controller = playerObject.GetComponent<PlayerController>();
            originalPlayerTag = playerObject.tag;

            avoidFireAutoMovement = playerObject.GetComponent<AvoidFireAutoMovement>();
            avoidFireMovement = playerObject. GetComponent<AvoidFireMovement>();
        }
        effectMessageText.gameObject.SetActive(false);
    }

    public void ApplyRandomEffect()
    {
        int randomEffect = Random.Range(1, 5);

        switch (randomEffect)
        {
            case 1:
                StartCoroutine(ApplyTimeSlowAndSpeedUp());
                ShowMessage("��� �ð��� �������� ! �����ǰ�..?");
                break;
            case 2:
                StartCoroutine(ActivateMagnet(15f));
                ShowMessage("���� ��Ȧ�� ������ ! ��Ȧ�� ���� ������ ������ �ι�� ��� !");
                break;
            case 3:
                IncreasePlayerHealth();
                ShowMessage("ü���� 1 �����߾�� !");
                break;
            case 4:
                StartCoroutine(ActivateAvoidFireEffect());
                StartCoroutine(AutoModeTimer());
                break;
        }
    }

    private IEnumerator ApplyTimeSlowAndSpeedUp()
    {
        Time.timeScale = 0.5f;
        player.speed *= 1.5f;

        yield return new WaitForSecondsRealtime(8f);

        Time.timeScale = 1f;
        player.speed /= 1.5f;
    }

    private IEnumerator ActivateAvoidFireEffect()
    {
        avoidFireMovement.enabled = false;
        avoidFireAutoMovement.enabled = true;

        player.gameObject.tag = "Ground";
        yield return new WaitForSeconds(avoidFireDuration);
        player.gameObject.tag = originalPlayerTag;

        avoidFireAutoMovement.enabled = false;
        avoidFireMovement.enabled = true;
    }

    private void IncreasePlayerHealth()
    {
        controller.TakeHeal();
    }

    private IEnumerator ActivateMagnet(float duration)
    {
        player.gameObject.tag = "Magnet";

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

    private void ShowMessage(string message)
    {
        effectMessageText.gameObject.SetActive(true);
        effectMessageText.text = message;

        StartCoroutine(HideMessageAfterTime());
    }

    private IEnumerator HideMessageAfterTime()
    {
        yield return new WaitForSeconds(messageDisplayTime);

        effectMessageText.gameObject.SetActive(false);
    }

    private IEnumerator AutoModeTimer()
    {
        effectMessageText.gameObject.SetActive(true);

        for (int i = 10; i > 0; i--)
        {
            effectMessageText.text = $"�ڵ���� ������ �����ð� : {i}";
            yield return new WaitForSeconds(1);
        }
        effectMessageText.gameObject.SetActive(false);
    }
}
