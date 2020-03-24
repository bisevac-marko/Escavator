using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : State
{

    private Vector2Int moveInput;
    private float moveSpeed = 5f;

    public Moving(Digger digger) : base(digger) 
    {

    }

    public override void Loop()
    {
        
    }
    public override void FixedLoop()
    {

        moveInput.x = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
        moveInput.y = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

        if (GridManager.Instance.CanDrill(moveInput))
        {
            if (moveInput.x == 1)
            {
                digger.SetState(new Drilling(digger, Vector2Int.right));
            }
            else if (moveInput.x == -1)
            {
                digger.SetState(new Drilling(digger, Vector2Int.left));
            }
            else if (moveInput.y == -1)
            {
                digger.SetState(new Drilling(digger, Vector2Int.down));
            }
        }
        else if (moveInput.y == 1)
        {
            digger.SetState(new Flying(digger));
        }
        else
        {
            Vector2 move = new Vector2(moveInput.x, Mathf.Clamp(moveInput.y, 0, 1));
            Digger.rb.MovePosition(Digger.rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
        


    }

}
