using System.Collections.Generic;
using UnityEngine;

public class NodeAlgorithm
{
	private int firstSpawn = 420;
	private int secondSpawn = 280;
	private int thirdSpawn = 150;
	private int forthSpawn = 80;

	private float nodeSpawnChance = .1f;
	private float empthyNodeChance = .01f;
	public NodeAlgorithm()
	{
		
	}
	public int RandomizeType(int currentHeight)
	{
		int rand = Mathf.RoundToInt(Random.Range(0, 10));
		float dice = Random.value;

		if (dice > nodeSpawnChance)
		{
			dice = Random.value;
			if (dice > empthyNodeChance)
			{
				return 0;
			}
			return -1;
		}
		else if (currentHeight > firstSpawn)
		{
			int randNode = Mathf.RoundToInt(Random.Range(1, 3));
			return randNode;
		}
		else if (currentHeight > secondSpawn)
		{
			int randNode = Mathf.RoundToInt(Random.Range(1, 4));
			return randNode;
		}
		else if (currentHeight > thirdSpawn)
		{
			int randNode = Mathf.RoundToInt(Random.Range(2, 4));
			return randNode;
		}
		else if (currentHeight > forthSpawn)
		{
			int randNode = Mathf.RoundToInt(Random.Range(3, 5));
			return randNode;
		}
		return 0;
	}
}
