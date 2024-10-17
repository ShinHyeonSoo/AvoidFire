using System.Collections;
using UnityEngine;

public class RandomBoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject closedBoxPrefab;
    [SerializeField] private float spawnInterval = 30f;
    [SerializeField] private float spawnXMin = -9f;
    [SerializeField] private float spawnXMax = 9f;
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
        }
    }
}
