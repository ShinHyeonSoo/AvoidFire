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
    public int speed { get; set; }
    public int hp { get; set; }
    private float y;
    private int type;


    private void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, 5f);
    }

    public void SpawnMonster()
    {
        string tag = Random.Range(0, 2) == 0 ? "zombiePrefab" : "skeletonPrefab";
        GameObject monsterSpawn = objectPool.SpawnFromPool(tag);

        speed = 3;
        int randomX = Random.Range(0, 2);
        float spawnX = randomX == 0 ? minX : maxX;
        float spawnY = -2f;

        // 몬스터 위치 설정
        transform.position = new Vector2(spawnX, spawnY);
    }

    public void MonsterType()
    {
        if (tag == "zombie")
        {
            hp = 1;
            speed = 3;
        }
        else if (tag == "skeleton")
        {
            hp = 3;
            speed = 1;
        }
    }
}
