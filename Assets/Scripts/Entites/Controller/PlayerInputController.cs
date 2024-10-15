using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : AvoidFireController
{
    protected override void Awake()
    {
        base.Awake(); // �θ� Ŭ������ Awake �Լ��� ������� ��
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnJump(InputValue value)
    {
        IsJump = value.isPressed;
        // �Է¿� ���� Jump ���� ����
        CallLookEvent(IsJump);
    }
}
