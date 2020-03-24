using UnityEngine;
using System.Collections.Generic;

public class Grid
{
    private int width;
    private int height;
    private Node[,] nodes;
    private int heightIndex;
    public Grid(int width, int height)
    {
        this.width = width;
        this.height = height;
        heightIndex = height - 1;
        nodes = new Node[width, height];
    }


}

