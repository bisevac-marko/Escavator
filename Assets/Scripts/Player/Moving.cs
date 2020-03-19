using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : State
{

    private Vector2Int dir;
    private Rigidbody2D rb;
    private float moveSpeed = 3f;

    public Moving(Digger digger) : base(digger) 
    {

    }

    public override void Loop()
    {
        
    }

    public override void FixedLoop()
    {
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            MoveInDirection(dir);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            if (GridManager.Instance.NodeExists(Digger.X + dir.x, Digger.Y) && digger.IsGrounded())
            {
                digger.SetState(new Drilling(digger, dir));
            }
            MoveInDirection(dir);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            if (GridManager.Instance.NodeExists(Digger.X, Digger.Y + dir.y) && digger.IsGrounded())
            {
                digger.SetState(new Drilling(digger, dir));
            }
            MoveInDirection(dir);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            if (GridManager.Instance.NodeExists(Digger.X + dir.x, Digger.Y) && digger.IsGrounded())
            {
                digger.SetState(new Drilling(digger, dir));
            }
            MoveInDirection(dir);
        }
        else
        {
            digger.SetState(new Idle(digger));
        }
        dir = Vector2Int.zero;
    }
    private void MoveInDirection(Vector2Int direction)
    {
        rb.MovePosition(rb.position + (Vector2)direction * moveSpeed * Time.fixedDeltaTime);
    }
    public override void OnStateEnter()
    {
        rb = digger.GetComponent<Rigidbody2D>();
        dir = Vector2Int.zero;
    }

    public override void OnStateExit()
    {

    }
}
