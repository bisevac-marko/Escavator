using UnityEngine;

public class Node
{
	public int type;
	public int value;
	public GameObject nodeObj;
	public Node(int type, GameObject nodeObj)
	{
		this.nodeObj = nodeObj;
		this.type = type;
		switch (type)
		{
			case 0:
				value = 10;
				break;
			case 1:
				value = 500;
				break;
			case 2:
				value = 1700;
				break;
			case 3:
				value = 5000;
				break;
			case 4:
				value = 12000;
				break;
		}
	}
}
