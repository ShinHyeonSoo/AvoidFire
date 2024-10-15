using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    private static EffectManager _instance;
    private ObjectPool _effectPool;

    public static EffectManager Instance { get { return _instance; } }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _effectPool = GetComponent<ObjectPool>();
    }

    public void Explosion(Vector3 pos)
    {
        GameObject effect = _effectPool.SpawnFromPool("explosion");
        effect.transform.position = pos;
    }
}
