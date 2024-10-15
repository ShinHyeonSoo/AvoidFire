using System.Collections;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float spawnXMin = -7f;
    [SerializeField] private float spawnXMax = 7f;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnFire());
    }

    private IEnumerator SpawnFire()
    {
        while (true)
        {
            float randomXPosition = Random.Range(spawnXMin, spawnXMax);
            Vector3 spawnPosition = new Vector3(randomXPosition, spawnPoint.position.y, 0f);

            Instantiate(firePrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
