using System.Collections;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnYMin = -2f;
    [SerializeField] private float spawnYMax = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float destroyXPosition = 13f;

    private void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            SpawnCloud();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnCloud()
    {
        float randomYPosition = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPosition = new Vector3(-10f, randomYPosition, 0f);
        GameObject cloudInstance = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        CloudMover cloudMover = cloudInstance.AddComponent<CloudMover>();
        cloudMover.Initialize(moveSpeed, destroyXPosition);
    }

}
