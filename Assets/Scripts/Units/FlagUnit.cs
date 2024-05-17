using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlagUnit : Unit
{
    public Animator animator;

    private bool won;

    public override void Die()
    {
        if (dead) return;

        dead = true;

        Destroy(gameObject);
    }

    public void Win()
    {
        won = true;

        animator.SetTrigger("Idle");

        Debug.Log("Level cleared!");
    }

    public override void MoveForward()
    {
        if(won) return;

        transform.position += transform.right * speed * Time.deltaTime;
    }
}
