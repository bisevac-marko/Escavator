
public class Idle : State
{
    public Idle (Player player) : base(player) 
    {

    }

    public override void Loop()
    {
        if (player.moveInput.sqrMagnitude != 0)
        {
            player.SetState(new Moving(player));
        }
    }

}
