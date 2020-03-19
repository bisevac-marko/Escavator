using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Digger digger;

    public State(Digger digger)
    {
        this.digger = digger;
    }
    public abstract void Loop();

    public virtual void FixedLoop() { }
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

}
