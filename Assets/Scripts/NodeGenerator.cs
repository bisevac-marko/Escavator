using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator
{
	//Prefabs
	private List<GameObject> planetNodes;

	public NodeGenerator()
	{
		planetNodes = new List<GameObject>();
		planetNodes.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Dirt"));
		planetNodes.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Aventurine"));
		planetNodes.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Mythril"));
		planetNodes.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Cobalt"));
	}
	public GameObject GetRandom(int currentHeight)
	{
		int rand = Mathf.RoundToInt(Random.Range(0, 10));

		if (currentHeight > 150 && currentHeight < 200)
		{
			if(rand > 0)
			{
				return planetNodes[0];
			}
			return planetNodes[1];
		}
		else if (currentHeight > 100 && currentHeight < 150)
		{
			if(rand > 0)
			{
				return planetNodes[0];
			}
				int randNode = Mathf.RoundToInt(Random.Range(1, 3));
				return planetNodes[randNode];
		}
		else if (currentHeight > 0 && currentHeight < 100)
		{
			if(rand > 0)
			{
				return planetNodes[0];
			}
			int randNode = Mathf.RoundToInt(Random.Range(2, 4));
			return planetNodes[randNode];
		}
		return planetNodes[0];
	}
}
