using UnityEngine;

public class Drilling : State
{
	private Vector2Int dir;
    private Vector3Int nextNodePos;
    private Collider2D col;
    private float drillSpeed = 3f;

	public Drilling(Digger digger, Vector2Int direction) : base(digger) 
	{
		dir = direction;
	}


    public override void Loop()
    {
        if (!ReachedNode())
        {
            digger.transform.position = Vector3.MoveTowards(digger.transform.position, nextNodePos, drillSpeed * Time.deltaTime);
        }
        else
        {
            digger.transform.position = nextNodePos;
            digger.SetState(new Moving(digger));
        }
    }

    private bool ReachedNode()
    {
        return Vector3.Distance(digger.transform.position, nextNodePos)  < .01f;
    }

    public override void OnStateEnter()
    {
        //Set next node pos
        nextNodePos = new Vector3Int(Digger.X + dir.x, Digger.Y + dir.y, 0);
        //Destory next node
        GridManager.Instance.DestroyNode(nextNodePos.x, nextNodePos.y);
        col = digger.GetComponent<Collider2D>();
        col.enabled = false;
    }

    public override void OnStateExit()
    {
        col.enabled = true;
    }
}
