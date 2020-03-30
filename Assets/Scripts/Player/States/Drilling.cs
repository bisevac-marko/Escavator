using UnityEngine;

public class Drilling : State
{
	private Vector2Int dir;
    private Vector3Int nextNodePos;

	public Drilling(Player player, Vector2Int direction) : base(player) 
	{
		dir = direction;
	}

    public override void Loop()
    {
        if (!ReachedNode())
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, nextNodePos, player.drillingSpeed * Time.deltaTime);
        }
        else
        {
            player.SetState(new Idle(player));
        }
        player.DrainFuel(35f);
    }

    private bool ReachedNode()
    {
        return Vector3.Distance(player.transform.position, nextNodePos)  < .05f;
    }

    public override void OnStateEnter()
    {
        if (dir.y == -1)
        {
            player.colider.enabled = false;
        }

        //Set next node pos
        nextNodePos = new Vector3Int(player.x + dir.x, player.y + dir.y, 0);
        //Destory next node
        GridManager.Instance.DrillNode(nextNodePos.x, nextNodePos.y);
        Physics2D.gravity = Vector2.zero;
        player.rb.velocity = Vector2.zero;
    }

    public override void OnStateExit()
    {
        Physics2D.gravity = new Vector2(0, -9.8f);
        player.transform.position = nextNodePos;
        player.colider.enabled = true;
    }
}
