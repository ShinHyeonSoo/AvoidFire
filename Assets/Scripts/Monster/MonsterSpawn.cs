using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;

    float minX = -8f;
    float maxX = 8f;
    public int speed;

    private void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, 5f);
    }

    public void SpawnMonster()
    {
        string tag = Random.Range(0, 2) == 0 ? "zombiePrefab" : "skeletonPrefab";
        GameObject monsterSpawn = objectPool.SpawnFromPool(tag);
        SpriteRenderer spriteRenderer = monsterSpawn.GetComponent<SpriteRenderer>();
        speed = Random.Range(1, 10);
        int randomX = Random.Range(0, 2);
        float spawnX = randomX == 0 ? minX : maxX;

        if (spawnX == maxX)
            spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
        float spawnY = -2f;

        // 몬스터 위치 설정
        monsterSpawn.transform.position = new Vector2(spawnX, spawnY);
    }
}
