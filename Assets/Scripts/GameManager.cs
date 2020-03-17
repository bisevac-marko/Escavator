using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static List<Grid> activeGrids;
    private int gridWidth = 50;
    private int gridHeight = 20;
    private int depthY = 0;

    private void Start()
    {
        activeGrids = new List<Grid>();
        Grid grid1 = new Grid(gridWidth, gridHeight, depthY);
        depthY += gridHeight;
        Grid grid2 = new Grid(gridWidth, gridHeight, depthY);
        activeGrids.Add(grid1);
    }

    private void Update()
    {
        
    }

    public static bool CanMove(int posX, int posY, Vector2Int dir)
    {
        foreach(Grid grid in activeGrids)
        {
            if (grid.NodeOccupied(posX + dir.x, posY + dir.y))
            {
                return false;
            }
        }
        return true;
    }
    public static void SetIsDrilled(int posX, int posY)
    {
        foreach (Grid grid in activeGrids)
        {
            grid.SetNodeDrilled(posX, posY);
        }
    }
    public static void DrawGrid(Node[,] nodes)
    {
        GameObject nodePrefab = Resources.Load<GameObject>("Prefabs/Node");
        Transform parent = FindObjectOfType<ParentTag>().transform;
        foreach (Node node in nodes)
        {
            Instantiate(nodePrefab, new Vector3(node.xPos, node.yPos), Quaternion.identity, parent);
        }
    }
}
