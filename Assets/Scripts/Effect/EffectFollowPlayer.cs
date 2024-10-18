using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFollowPlayer : MonoBehaviour
{
    private ParticleSystem _particle;
    private GameObject _player;

    private float _offset;
    private bool _isOn = false;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _offset = GetComponent<Transform>().position.y;
    }

    private void Update()
    {
        if (_isOn && _player != null)
            transform.position = new Vector3(_player.transform.position.x, 
                _player.transform.position.y - _offset, _player.transform.position.z);

        if (!_particle.IsAlive())
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _isOn = true;
    }

    private void OnDisable()
    {
        _isOn = false;
    }

    public void SetPlayer(GameObject player)
    {
        _player = player;
    }
}
