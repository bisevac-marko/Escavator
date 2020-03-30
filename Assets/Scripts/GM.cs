using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
	private GridManager gridManager;
	private List<GameObject> planetNodeAssets;
	private Transform deliveryShop;
	public static float fuelCost { get; private set; } = 20f;
	private void Awake()
	{
		gridManager = GetComponent<GridManager>();
		planetNodeAssets = new List<GameObject>();
		deliveryShop = GameObject.FindGameObjectWithTag("Delivery Shop").transform;
		LoadNodes();
		gridManager.GenerateGrid(planetNodeAssets);
		deliveryShop.position = new Vector3(0, gridManager.GetHeight() - .5f);
	}


	private void LoadNodes()
	{
		planetNodeAssets.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Dirt"));
		planetNodeAssets.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Aventurine"));
		planetNodeAssets.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Mythril"));
		planetNodeAssets.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Cobalt"));
		planetNodeAssets.Add(Resources.Load<GameObject>("Prefabs/Green Planet/Obsidian"));
	}
}
