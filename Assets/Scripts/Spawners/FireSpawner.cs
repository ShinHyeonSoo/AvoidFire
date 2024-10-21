using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private float spawnInterval = 0.3f;
    [SerializeField] private float spawnXMin = -9f;
    [SerializeField] private float spawnXMax = 9f;
    [SerializeField] private Transform spawnPoint;

    private int checkScore = 100;
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
            if (Score.Instance != null)
            {
                if (Score.Instance.totalScore >= checkScore) //100점단위일때만 계산
                {
                    checkScore += 100;
                }
            }
        }
    }

    public void SetFire()
    {
        GameObject fire = Instantiate(firePrefab, spawnPoint.position, Quaternion.Euler(0, 0, 180));
        Rigidbody2D rb2D = fire.GetComponent<Rigidbody2D>();
        FireProjectile fireProjectile = fire.GetComponent<FireProjectile>();
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
        fire.transform.SetParent(transform);
        fire.transform.localScale = new Vector2(size, size);
        if (SceneManager.GetActiveScene().name == "Title")
        {
            TitleFireSetting(fireProjectile, rb2D);
        }
        else
        {
            Difficultylevel(fireProjectile, rb2D);
        }
    }
     void Difficultylevel(FireProjectile fireProjectile, Rigidbody2D rb2D)
    {
        if (Score.Instance.totalScore >= 250)
        {
            spawnInterval = 0.1f;
            fireProjectile.FallSpeed = 15;
            rb2D.gravityScale = 4f;
        }
        else if (Score.Instance.totalScore >= 200)
        {
            spawnInterval = 0.14f;
            fireProjectile.FallSpeed = 10f;
            rb2D.gravityScale = 3f;
        }
        else if (Score.Instance.totalScore >= 150)
        {
            spawnInterval = 0.18f;
            fireProjectile.FallSpeed = 8f;
            rb2D.gravityScale = 2.5f;
        }
        else if (Score.Instance.totalScore >= 100)
        {
            spawnInterval = 0.22f;
            fireProjectile.FallSpeed = 7f;
            rb2D.gravityScale = 2f;
        }
        else if (Score.Instance.totalScore >= 50)
        {
            spawnInterval = 0.26f;
            fireProjectile.FallSpeed = 6f;
            rb2D.gravityScale = 1.5f;
        }
    }

    private void TitleFireSetting(FireProjectile fireProjectile, Rigidbody2D rb2D)
    {
        spawnInterval = 0.26f;
        fireProjectile.FallSpeed = 6f;
        rb2D.gravityScale = 1.5f;
    }
}
