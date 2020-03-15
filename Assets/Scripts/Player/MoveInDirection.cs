using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : State
{
    private Vector2 dir;
    private Vector3 startingPos;
    private Vector3 nextNodePos;

    public MoveInDirection(Digger digger, Vector2Int dir) : base(digger) 
    {
        this.dir = dir;
    }

    public override void Loop()
    {
        if (!ReachedNode())
        {
            digger.transform.Translate(dir * 3f * Time.deltaTime);
        }
        else
        {
            digger.transform.position = nextNodePos;
            Debug.Log("Not Moving");
            digger.SetState(new Moving(digger));
        }
    }

    private bool ReachedNode()
    {
        return Vector3.Distance(digger.transform.position, nextNodePos) < 0.05f;
    }

    public override void OnStateEnter()
    {
        startingPos = digger.transform.position;
        nextNodePos = startingPos + new Vector3(dir.x, dir.y, 0);
        Debug.Log(nextNodePos);
        Debug.Log("Entered");
    }
}
