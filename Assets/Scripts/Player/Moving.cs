using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : State
{

    private Vector2Int direction;

    public Moving(Digger digger) : base(digger) { }

    public override void Loop()
    {

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
            MoveOrDrillInDir(direction);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            MoveOrDrillInDir(direction);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
            MoveOrDrillInDir(direction);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            MoveOrDrillInDir(direction);
        }
        direction = Vector2Int.zero;
    }

    public override void OnStateEnter()
    {
        direction = Vector2Int.zero;
    }
    private void MoveOrDrillInDir(Vector2Int dir)
    {
        if (GameManager.CanMove(Digger.posX, Digger.posY, dir))
        {
            digger.SetState(new MoveInDirection(digger, dir));
        }
        else
        {
            digger.SetState(new Drilling(digger, dir));
        }
    }
}
