using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static List<Grid> activeGrids;
    private void Start()
    {
        activeGrids = new List<Grid>();
        Grid grid1 = new Grid(5, 5);
        activeGrids.Add(grid1);
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
}
