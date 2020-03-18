using UnityEngine;
using System.Collections.Generic;

public class Grid
{
    private int width;
    private int height;
    private Node[,] nodes;
    private Vector2Int origin;
    private int currentYIndex;
    public Grid(int width, int height, Vector2Int origin)
    {
        this.origin = origin;
        this.width = width;
        this.height = height;
        currentYIndex = height - 1;

        nodes = new Node[width, height];

        InitializeNodes(20);
        InitializeNodes(50);
    }
    public void InitializeNodes(int rowsCount)
    {
        //For every row from top till rowCount
        for (int y = currentYIndex; y >= (currentYIndex - rowsCount); y--)
        {
            for (int x = 0; x < width; x++)
            {
                //Debug.LogError(x + "," + y);
                nodes[x, y] = new Node(x + origin.x, y + origin.y, true);

                Debug.DrawLine(new Vector3(x - .5f, y - .5f), new Vector3(x + .5f, y - .5f), Color.white, Mathf.Infinity);
                Debug.DrawLine(new Vector3(x - .5f, y - .5f), new Vector3(x - .5f, y + .5f), Color.white, Mathf.Infinity);
                GameManager.CreateWorldText("(" + x + ", " + y + ")", new Vector3(x, y));
            }
        }
        currentYIndex -= rowsCount;
    }
    public void SetNodeDrilled(int nodeX, int nodeY)
    {
        //Debug.Log(nodeX + ", " + nodeY);
        nodes[nodeX - origin.x, nodeY - origin.y].isOccupied = false;
    }
    public bool IsNodeOccupied(int posX, int posY)
    {
        int indexPosX = posX - origin.x;
        int indexPosY = posY - origin.y;

        if(indexPosX < width && indexPosX >= 0 && indexPosY < height && indexPosY >= 0)
        {
            return nodes[indexPosX, indexPosY].isOccupied;
        }
        return false;
    }
}

