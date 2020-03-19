﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    private Vector2 dir;
    private Vector3 startingPos;
    private Vector3 nextNodePos;
    private float moveSpeed = 1.5f;

    public Move(Digger digger, Vector2Int dir) : base(digger) 
    {
        this.dir = dir;
    }

    public override void Loop()
    {
        if (!ReachedNode())
        {
            digger.transform.Translate(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            digger.transform.position = nextNodePos;
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
    }
}