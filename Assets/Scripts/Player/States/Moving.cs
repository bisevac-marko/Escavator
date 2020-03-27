using UnityEngine;

public class Moving : State
{

    private float moveSpeed = 5f;

    public Moving(Player player) : base(player) 
    {

    }
    
    public override void FixedLoop()
    {
        //If can drill - drill
        if (GridManager.Instance.CanDrill(player.moveInput))
        {
            //Debug.Log("Drilling");
            if (player.moveInput.x == 1)
            {
                player.SetState(new Drilling(player, Vector2Int.right));
            }
            else if (player.moveInput.x == -1)
            {
                player.SetState(new Drilling(player, Vector2Int.left));
            }
            else if (player.moveInput.y == -1)
            {
                player.SetState(new Drilling(player, Vector2Int.down));
            }
        }
        // If not grounded or moving up, setstate to flying
        else if (!player.IsGrounded() || player.moveInput.y == 1)
        {
            player.SetState(new Flying(player));
        }
        // if pressing movement buttons, move
        else if (player.moveInput.sqrMagnitude != 0)
        {
            Vector2 move = new Vector2(player.moveInput.x, Mathf.Clamp(player.moveInput.y, 0, 1));
            player.rb.MovePosition(player.rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            player.SetState(new Idle(player));
        }
        player.DrainFuel(1f);
    }

}
