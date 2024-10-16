using System.Collections;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private float spawnInterval = 0.3f;
    [SerializeField] private float spawnXMin = -9f;
    [SerializeField] private float spawnXMax = 9f;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnFire());
    }

    private IEnumerator SpawnFire()
    {
        while (true)
        {
            SetFire();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void SetFire()
    {
        GameObject fire = Instantiate(firePrefab, spawnPoint.position, Quaternion.identity);

        float randomXPosition = Random.Range(spawnXMin, spawnXMax);
        fire.transform.position = new Vector2(randomXPosition, spawnPoint.position.y);

        Rigidbody2D rb2D = fire.GetComponent<Rigidbody2D>();

        int randomType = Random.Range(1, 4);
        float size = 1.5f;

        switch (randomType)
        {
            case 1:
                size = 1.5f;
                rb2D.gravityScale = 1f; // 중력
                break;
            case 2:
                size = 2f;
                rb2D.gravityScale = 2f;
                break;
            case 3:
                size = 3f;
                rb2D.gravityScale = 3f;
                break;
        }
        //볼 크기설정
        fire.transform.localScale = new Vector2(size, size);
    }
}
