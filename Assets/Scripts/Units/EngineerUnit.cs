using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerUnit : Unit
{
    public Animator animator;

    private bool working;

    private BarbedWire barbedWireWorkingOn;

    public override void BarbedWire(BarbedWire barbedWire)
    {
        animator.SetTrigger("Action");

        barbedWireWorkingOn = barbedWire;

        Invoke("CutBarbedWire", 2.5f);

        working = true;
    }

    public void RemoveLandMine(LandMineScript landmine)
    {
        animator.SetTrigger("Action");

        landmine.TriggerDisable();

        Invoke("TriggerWalk", 2.5f);

        working = true;
    }

    public override void MoveForward()
    {
        if (working) return;

        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void CutBarbedWire()
    {
        barbedWireWorkingOn.CutBarbedWire();

        animator.SetTrigger("Walk");

        working = false;
    }

    private void TriggerWalk()
    {
        animator.SetTrigger("Walk");

        working = false;
    }
}
