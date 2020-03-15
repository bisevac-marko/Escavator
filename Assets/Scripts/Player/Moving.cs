using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : State
{
    private Vector2 moveInput;
    private Vector2Int direction;
    public Moving(Digger digger) : base(digger) { }

    public override void Loop()
    {

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
            if (GridManager.CanMove(Digger.posX, Digger.posY, direction))
            {
                digger.SetState(new MoveInDirection(digger, direction));
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
            if (GridManager.CanMove(Digger.posX, Digger.posY, direction))
            {
                digger.SetState(new MoveInDirection(digger, direction));
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
            if (GridManager.CanMove(Digger.posX, Digger.posY, direction))
            {
                digger.SetState(new MoveInDirection(digger, direction));
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            if (GridManager.CanMove(Digger.posX, Digger.posY, direction))
            {
                digger.SetState(new MoveInDirection(digger, direction));
            }
        }
        direction = Vector2Int.zero;
    }

    public override void OnStateEnter()
    {
        direction = Vector2Int.zero;
    }
}
