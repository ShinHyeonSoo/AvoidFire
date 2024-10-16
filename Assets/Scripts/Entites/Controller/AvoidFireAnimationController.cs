using System;
using UnityEngine;

public class AvoidFireAnimationController : AnimationController
{
    private static readonly int isRun = Animator.StringToHash("isRun");
    private static readonly int isJump = Animator.StringToHash("isJump");
    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int isDead = Animator.StringToHash("isDead");

    private readonly float magnituteThreshold = 0.1f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        controller.OnMoveEvent += MoveAnim;
        controller.OnJumpEvent += JumpAnim;
        
    }

    private void Update()
    {
        if (movement.isGrounded)
            animator.SetBool(isJump, false);
    }

    private void MoveAnim(Vector2 vector)
    {
        animator.SetBool(isRun, vector.magnitude > magnituteThreshold);
    }
    private void JumpAnim(bool obj)
    {
        animator.SetBool(isJump, obj);
    }

    public void HitAnim()
    {
        animator.SetBool(isHit, true);
    }
    public void DeadAnim()
    {
        animator.SetBool(isDead, true);
    }
}
