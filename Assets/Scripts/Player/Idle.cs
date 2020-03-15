using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle (Digger digger) : base(digger) { }

    public override void Loop()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            digger.SetState(new Moving(digger));
        }
    }
}
