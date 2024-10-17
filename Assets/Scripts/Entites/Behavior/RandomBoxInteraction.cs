using UnityEngine;

public class RandomBoxInteraction : MonoBehaviour
{
    [SerializeField] private GameObject openBoxPrefab;
    [SerializeField] private GameObject pressGMessage;
    private RandomEffectManager effectManager;

    private bool _isPlayerNearby = false;
    private GameObject _currentBox;

    private void Awake()
    {
        RandomEffectManager effectManager = GetComponent<RandomEffectManager>();
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

            effectManager.ApplyRandomEffect();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = true;
            pressGMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerNearby = false;
            pressGMessage.SetActive(false);
        }
    }

    public void SetCurrentBox(GameObject box)
    {
        _currentBox = box;
    }
}
