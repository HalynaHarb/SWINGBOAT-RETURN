using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : Enemy
{
    protected Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void JumpedOn()
    {
        animator.SetTrigger("Death");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
