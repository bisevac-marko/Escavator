using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private Node[,] nodes;
    private float lineDuration = 30f;

    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;

        nodes = new Node[width, height];
        Vector2 from;
        Vector2 to;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                from = new Vector2(x + .5f, y + .5f);
                to = new Vector2(x + 1.5f, y + .5f);
                Debug.DrawLine(from , to, Color.gray, lineDuration);

                from = new Vector2(x + .5f, y + .5f);
                to = new Vector2(x + .5f, y + 1.5f);
                Debug.DrawLine(from, to, Color.gray, lineDuration);
                nodes[x, y] = new Node(x, y, true);
            }
        }
        Debug.DrawLine(new Vector2(width + .5f, height + .5f), new Vector2(width + .5f, 0.5f), Color.gray, lineDuration);
        Debug.DrawLine(new Vector2(0.5f, height + .5f), new Vector2(width + .5f, height + .5f), Color.gray, lineDuration);
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

