using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int gridWidth = 20;
    private int gridHeight = 100;
    private const float floatOffset = .03f;

    private GameObject worldTextParent;
    private GameObject nodeParent;
    private Grid grid;
    private List<GameObject> planetNodeAssets;
    public static GridManager Instance { get; private set; }
    private Player player;
    public delegate void OnNodeDrilled(int score);
    public event OnNodeDrilled onNodeDrilled;

    public void GenerateGrid(List<GameObject> nodeAssets)
    {
        Instance = this;
        worldTextParent = new GameObject("World Text");
        nodeParent = new GameObject("World Nodes");
        player = FindObjectOfType<Player>();
        planetNodeAssets = nodeAssets;
        grid = new Grid(gridWidth, gridHeight);
    }

    public GameObject CreateWorldNode(int nodeType, int x, int y)
    {
        GameObject obj = Instantiate(planetNodeAssets[nodeType], new Vector3(x, y), Quaternion.identity, nodeParent.transform);
        CreateWorldText(x + ", " + y, x, y);
        return obj;
    }
    public void DrillNode(int nodeX, int nodeY)
    {
        Node node = grid.GetNode(nodeX, nodeY);
        // if not a dirt node
        if (node.type >= 1)
        {
            // add node to backpack
            player.AddToBackpack(node);
        }
        //Update Score
        onNodeDrilled?.Invoke(node.type);
        //Destroy Node
        Destroy(grid.GetNode(nodeX, nodeY).nodeObj);
        grid.DestroyNode(nodeX, nodeY);
    }
    public bool CanDrill(Vector2Int dir)
    {
        return player.IsGrounded() && grid.NodeExists(player.x + dir.x, player.y + dir.y) && TouchingNode(dir);
    }
    private bool TouchingNode(Vector2Int dir)
    {
        if (dir.x == 1)
        {
            return player.transform.position.x >= player.x - floatOffset;
        }
        else if (dir.x == -1)
        {
            return player.transform.position.x <= player.x + floatOffset;
        }
        
        if (dir.y == -1)
        {
            return player.transform.position.y <= player.y + floatOffset;
        }
        else if (dir.y == 1)
        {
            return player.transform.position.y >= player.y - floatOffset;
        }
        return false;
    }
    public void CreateWorldText(string text, int x, int y)
    {
        GameObject go = new GameObject("World_Text", typeof(TextMesh));
        go.transform.position = new Vector3(x, y);
        go.transform.SetParent(worldTextParent.transform);
        TextMesh textMesh = go.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.characterSize = 0.1f;
        textMesh.fontSize = 14;
        textMesh.color = Color.white;
    }
    public int GetHeight()
    {
        return this.gridHeight;
    }

}
