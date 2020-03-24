using UnityEngine;

public class Drilling : State
{
	private Vector2Int dir;
    private Vector3Int nextNodePos;
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
            digger.SetState(new Moving(digger));
        }
    }

    private bool ReachedNode()
    {
        return Vector3.Distance(digger.transform.position, nextNodePos)  < .01f;
    }

    public override void OnStateEnter()
    {
        
        if(dir.y == -1)
        {
            Digger.colider.enabled = false;
        }


        Digger.rb.gravityScale = 0;
        Physics2D.gravity = Vector2.zero;
        //Set next node pos
        nextNodePos = new Vector3Int(Digger.x + dir.x, Digger.y + dir.y, 0);
        //Destory next node
        Debug.Log(dir.x + " " + dir.y);
        GridManager.Instance.DestroyNode(nextNodePos.x, nextNodePos.y);
    }

    public override void OnStateExit()
    {
        Physics2D.gravity = new Vector2(0, -10);
        Digger.rb.gravityScale = 20;
        digger.transform.position = nextNodePos;

        Digger.colider.enabled = true;
    }
}
