using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterEffect : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Select()
    {
        animator.SetBool("isSelect", true);
    }

    public void NotSelect()
    {
        animator.SetBool("isSelect", false);
    }
}
