using UnityEngine;
public class Idle : State
{
    public Idle (Player player) : base(player) 
    {

    }

    public override void Loop()
    {
        if (player.moveInput.x != 0 || player.moveInput.y != 0 || player.rb.velocity != Vector2.zero)
        {
            if (GridManager.Instance.CanDrill(player.moveInput))
            {
                Drill();
            }
            else 
            {
                player.SetState(new Moving(player));
            }
        }
        player.DrainFuel(15f);
    }

    private void Drill()
    {
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
}
