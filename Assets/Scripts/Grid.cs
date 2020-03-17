using UnityEngine;
using System.Collections.Generic;

public class Grid
{
    private int width;
    private int height;
    private Node[,] nodes;
    private int startingY = 10000;
    public Grid(int width, int height, int depthY)
    {
        this.width = width;
        this.height = height;

        nodes = new Node[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                nodes[x, y] = new Node(x, y, true);
            }
        }
        GameManager.DrawGrid(nodes);
    }
    public void SetNodeDrilled(int posX, int posY)
    {
        Debug.Log(posX + ", " + posY);
        nodes[posX, posY].isOccupied = false;
    }
    public bool NodeOccupied(int posX, int posY)
    {
        if(posX < width && posX >= 0 && posY < height && posY >= 0)
        {
            return nodes[posX, posY].isOccupied;
        }
        return false;
    }
}

