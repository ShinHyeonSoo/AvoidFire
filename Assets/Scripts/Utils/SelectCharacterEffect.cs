using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterEffect : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
