using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvoidFireController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<bool> OnJumpEvent;

    protected bool IsJump { get; set; }
    protected virtual void Awake()
    {
    }

    public void CallMoveEvent(Vector2 direction)
    {
        // A D �¿� �̵�
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(bool isJump)
    {
        // �����̽� ����
        OnJumpEvent?.Invoke(isJump);
    }
}
