using UnityEngine;
using System.Collections.Generic;

public class Grid
{
    private int width;
    private int height;
    private Node[,] nodes;
    private int heightIndex;
    private GridManager gridManager;
    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        heightIndex = height - 1;
        nodes = new Node[width, height];
    }
    public void InitializeNodes(int rowCount)
    {
        //For every row from top till rowCount
        for (int y = heightIndex; y >= (heightIndex - rowCount); y--)
        {
            for (int x = 0; x < width; x++)
            {
                //Debug.LogError(x + "," + y);
                nodes[x, y] = new Node(x, y, true);
                VisualizeGridNode(x, y);
                GridManager.Instance.InstantiateNode(x, y);
            }
        }
        heightIndex -= rowCount;
    }

    private void VisualizeGridNode(int x, int y)
    {
        Debug.DrawLine(new Vector3(x - .5f, y - .5f), new Vector3(x + .5f, y - .5f), Color.white, Mathf.Infinity);
        Debug.DrawLine(new Vector3(x - .5f, y - .5f), new Vector3(x - .5f, y + .5f), Color.white, Mathf.Infinity);
        GridManager.Instance.CreateWorldText("(" + x + ", " + y + ")", new Vector3(x, y));
    }

}

