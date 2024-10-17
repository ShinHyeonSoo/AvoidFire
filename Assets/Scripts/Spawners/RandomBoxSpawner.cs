using System.Collections;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject closedBoxPrefab;
    [SerializeField] private float spawnInterval = 30f;
    [SerializeField] private float spawnXMin = -6f;
    [SerializeField] private float spawnXMax = 8f;
    [SerializeField] private Transform spawnPoint;

    private GameObject _currentBox;

    private void Start()
    {
        StartCoroutine(SpawnRandomBox());
    }

    private IEnumerator SpawnRandomBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBox();
        }
    }

    private void SpawnBox()
    {
        if (_currentBox == null)
        {
            _currentBox = Instantiate(closedBoxPrefab, spawnPoint.position, Quaternion.identity);
            float randomXPosition = Random.Range(spawnXMin, spawnXMax);
            _currentBox.transform.position = new Vector2(randomXPosition, spawnPoint.position.y);

            // 생성된 CloseBox의 Interaction에 현재 박스 전달
            RandomBoxInteraction interaction = _currentBox.GetComponent<RandomBoxInteraction>();
            interaction.SetCurrentBox(_currentBox);
        }
    }
}
