public class Grid 
{
	private Node[,] nodes;
	private int width;
	private int height;
	NodeAlgorithm nodeGenerator;
	public Grid(int width, int height)
	{
		this.width = width;
		this.height = height;
		nodes = new Node[width, height];
		nodeGenerator = new NodeAlgorithm();

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				int nodeType = nodeGenerator.RandomizeType(y);
				if (nodeType == -1)
				{
					nodes[x, y] = null;
				}
				else
				{
					nodes[x, y] = new Node(nodeType, GridManager.Instance.CreateWorldNode(nodeType, x, y));
					
				}
			}
		}
	}
	public Node GetNode(int x, int y)
	{
		return nodes[x, y];
	}

	public bool NodeExists(int nodeX, int nodeY)
	{
		if (nodeX < width && nodeX >= 0 && nodeY < height && nodeY >= 0)
		{
			if (nodes[nodeX, nodeY] != null)
			{
				return true;
			}
		}
		return false;
	}
	public void DestroyNode(int x, int y)
	{
		nodes[x, y] = null;
	}
}
