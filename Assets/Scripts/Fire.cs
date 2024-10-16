using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string fireobj;
        public GameObject fireobjPrefab;
        public int count;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    Rigidbody2D rb2D;
    float size;

    // Start is called before the first frame update

    // Update is called once per frame
    void Awake()
    {

        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        //FindObjectOfType<Fire>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.count; i++)
            {

                GameObject obj = Instantiate(pool.fireobjPrefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.fireobj, objectPool);
        }
    }

    public GameObject SpawnFromPool(string fireobj)
    {
        if (!PoolDictionary.ContainsKey(fireobj))
        {
            return null;
        }

        GameObject obj = PoolDictionary[fireobj].Dequeue();
        PoolDictionary[fireobj].Enqueue(obj);

        obj.SetActive(true);
        return obj;
    }

    void Start()
    {
        Debug.Log("Start 함수 실행");
        Spawnfire();
    }

    public void Setfire()
    {
        GameObject fire = SpawnFromPool("fire");

        if (fire != null)
        {
            float x = Random.Range(-9f, 9f);
            fire.transform.localPosition = new Vector2(x, 5);
        }


        rb2D = fire.GetComponent<Rigidbody2D>();

        int Randomtype = Random.Range(1, 4);

        switch (Randomtype)
        {
            case 1:
                size = 1.5f;
                rb2D.gravityScale = Randomtype;
                break;
            case 2:
                size = 2f;
                rb2D.gravityScale = Randomtype;
                break;
            case 3:
                size = 3f;
                rb2D.gravityScale = Randomtype;
                break;

        }
        fire.transform.localScale = new Vector2(size, size);
    }
    public void Spawnfire()
    {
        InvokeRepeating("Setfire", 0f, .3f);
    }
}
