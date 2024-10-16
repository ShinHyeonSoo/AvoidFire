using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    protected AvoidFireController controller;
    protected AvoidFireMovement movement;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<AvoidFireController>();
        movement = GetComponentInChildren<AvoidFireMovement>();
    }
}