using UnityEngine;

public class Moving : State
{
    float airTime = 1f;
    public Moving(Player player) : base(player) 
    {
    }
    
    public override void FixedLoop()
    {
        if (player.rb.velocity == Vector2.zero)
        {
            player.SetState(new Idle(player));
        }
        if (!player.IsGrounded())
        {
            airTime += Time.fixedDeltaTime;
        }
        else
        {
            if (airTime > 2)
            {
                float impact = player.rb.velocity.y;
                Debug.Log(impact);
                if (impact >= -13.8f && impact < -13f)
                {
                    player.TakeDamage(10);
                }
                else if (impact >= -14.3f && impact < -13.8f)
                {
                    player.TakeDamage(20);
                }
                else if (impact >= -14.6f && impact < -14.3f)
                {
                    player.TakeDamage(45);
                }
                else if (impact < -14.6f)
                {
                    player.TakeDamage(100);
                }
            }
            airTime = 1;

        }

        if (GridManager.Instance.CanDrill(player.moveInput))
        {
            Drill();
        }
        float liftOfMultiplyer = Mathf.Clamp(airTime, 1, 1.5f);
        Vector2 move = new Vector2(player.moveInput.x * player.horizontalSpeed, Mathf.Clamp(player.moveInput.y, 0, 1) * (player.verticalSpeed * liftOfMultiplyer));
        player.rb.AddForce(move);

        player.DrainFuel(30f);

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
