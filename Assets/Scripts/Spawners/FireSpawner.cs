using System.Collections;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private float spawnInterval = 0.3f;
    [SerializeField] private float spawnXMin = -9f;
    [SerializeField] private float spawnXMax = 9f;
    [SerializeField] private int score; //일단 점수
    [SerializeField] private Transform spawnPoint;

    private int checkScore = 100;

    Rigidbody2D rb2D;

    private TestFire testFire;

    private void Start()
    {
        rb2D.gravityScale = 1f; // 중력
        StartCoroutine(SpawnFire());
    }

    private IEnumerator SpawnFire()
    {
        while (true)
        {
            SetFire();
            yield return new WaitForSeconds(spawnInterval);

            if (score > checkScore) //100점단위일때만 계산
            {
                Difficultylevel();
                checkScore += 100;
            }
        }
    }

    public void SetFire()
    {
        GameObject fire = Instantiate(firePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb2D = fire.GetComponent<Rigidbody2D>();
        float randomXPosition = Random.Range(spawnXMin, spawnXMax);
        fire.transform.position = new Vector2(randomXPosition, spawnPoint.position.y);
        int randomType = Random.Range(1, 5);
        float size = 1.5f;
 

        switch (randomType)
        {
            case 1:
                size = 1.5f;
                break;
            case 2:
                size = 3f;
                break;
            case 3:
                size = 5f;
                break;
            case 4:
                size = 8f;
                break;
        }
        //볼 크기설정
        fire.transform.localScale = new Vector2(size, size);
    }

    public void Difficultylevel()
    {
        if (score >= 100)
        {
            spawnInterval = 0.25f;
        }
        if (score >= 200)
        {
            spawnInterval = 0.2f;
            testFire.FallSpeed = 7f;
            rb2D.gravityScale = 2f;
        }
        if (score >= 300)
        {
            spawnInterval = 0.15f;
            testFire.FallSpeed = 9f;
        }
        if (score >= 500)
        {
            spawnInterval = 0.1f;
            testFire.FallSpeed = 12f;
            rb2D.gravityScale = 3f;
        }
    }
}
