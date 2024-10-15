using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public DataManager _dataManager;

    public static GameManager Instance { get { return _instance; } }

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

        // Manager 추가
        _dataManager = GetComponent<DataManager>();

        DontDestroyOnLoad(gameObject);
    }
}
