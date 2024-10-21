using UnityEngine;
using TMPro;

public class RandomBoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject openBoxPrefab;
    [SerializeField] private TextMeshProUGUI pressGMessage;
    private RandomEffectManager effectManager;

    private bool _isPlayerNearby = false;
    private GameObject _currentBox;

    private void Awake()
    {
        pressGMessage = GameObject.Find("ScoreCanvas").transform.Find("RandomBoxInteractionText").GetComponent<TextMeshProUGUI>();
        effectManager = FindObjectOfType<RandomEffectManager>();  // RandomEffectManager�� ������ ã��
    }

    private void Update()
    {
        if (_isPlayerNearby && Input.GetKeyDown(KeyCode.G))
        {
            OpenBox();
        }
    }

    private void OpenBox()
    {
        if (_currentBox != null)
        {
            _currentBox.SetActive(false);
            GameObject openBox = Instantiate(openBoxPrefab, _currentBox.transform.position, Quaternion.identity);

            // ���� ȿ�� ����
            effectManager.ApplyRandomEffect();

            Destroy(openBox, 3f);
            Destroy(_currentBox, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = true;
            pressGMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = false;
            pressGMessage.gameObject.SetActive(false);
        }
    }

    public void SetCurrentBox(GameObject box)
    {
        _currentBox = box;
    }
}
