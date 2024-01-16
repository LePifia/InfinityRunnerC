using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

 
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }


    public void Crouch()
    {
        animator.SetTrigger("crouch");
    }

    public void Dead()
    {
        animator.SetTrigger("dead");
    }
}
