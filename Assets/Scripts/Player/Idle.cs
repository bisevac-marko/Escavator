using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{

    public Idle (Digger digger) : base(digger) 
    {

    }

    public override void Loop()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            digger.SetState(new Moving(digger));
        }
    }
}
