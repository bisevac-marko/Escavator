
public abstract class State
{
    protected Player player;

    public State(Player player)
    {
        this.player = player;
    }
    public virtual void Loop() { }

    public virtual void FixedLoop() { }
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}
