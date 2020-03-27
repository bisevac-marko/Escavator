using UnityEngine;

public class GameManager : MonoBehaviour
{
	private GridManager gridManager;
	private NodeGenerator nodeGenerator;

	private void Awake()
	{
		gridManager = GetComponent<GridManager>();
		nodeGenerator = new NodeGenerator();
	}

	private void Start()
	{
		gridManager.GenerateGrid(nodeGenerator);
	}
}
