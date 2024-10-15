using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : AvoidFireController
{
    protected override void Awake()
    {
        base.Awake(); // 부모 클래스의 Awake 함수를 실행토록 함
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnJump(InputValue value)
    {
        IsJump = value.isPressed;
        // 입력에 따라 Jump 여부 설정
        CallLookEvent(IsJump);
    }
}
