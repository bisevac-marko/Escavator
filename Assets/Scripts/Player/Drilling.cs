using UnityEngine;

public class Drilling : State
{
	private Vector2 dir;
    private Vector3 nextNodePos;
    private Vector3 startingPos;

	public Drilling(Digger digger, Vector2Int direction) : base(digger) 
	{
		dir = direction;
	}


    public override void Loop()
    {
        if (!ReachedNode())
        {
            digger.transform.Translate(dir * .5f * Time.deltaTime);
        }
        else
        {
            digger.transform.position = nextNodePos;
            digger.SetState(new Moving(digger));
        }
    }

    private bool ReachedNode()
    {
        return Vector3.Distance(digger.transform.position, nextNodePos) < 0.05f;
    }

    public override void OnStateEnter()
    {
        startingPos = digger.transform.position;
        nextNodePos = startingPos + new Vector3(dir.x, dir.y, 0);
    }

    public override void OnStateExit()
    {
        int nodePosX = Mathf.RoundToInt(nextNodePos.x);
        int nodePosY = Mathf.RoundToInt(nextNodePos.y);
        GameManager.SetIsDrilled(nodePosX, nodePosY);
    }
}
