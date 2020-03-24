using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int gridWidth = 20;
    private int gridHeight = 200;

    private GameObject nodePrefab;
    private GameObject worldTextParent;
    private GameObject nodeParent;
    private GameObject[,] worldNodes;
    private LayerMask nodeLayer;

    private float floatOffset = .05f;
    public static GridManager Instance { get; private set; }
    private Digger digger;

    private void Start()
    {
        Instance = this;
        nodePrefab = Resources.Load<GameObject>("Prefabs/Node");
        worldTextParent = new GameObject("World Text");
        nodeParent = new GameObject("Nodes");
        digger = FindObjectOfType<Digger>();
        worldNodes = new GameObject[gridWidth, gridHeight];
        nodeLayer = LayerMask.GetMask("Node");

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                worldNodes[x, y] = Instantiate(nodePrefab, new Vector3(x, y), Quaternion.identity, nodeParent.transform);
                worldNodes[x, y].name = "World_Node " + x + ", " + y;
                CreateWorldText(x + ", " + y, x, y);
            }
        }
    }

    public void DestroyNode(int posX, int posY)
    {
        Destroy(worldNodes[posX, posY]);
        worldNodes[posX, posY] = null;
    }
    public bool DiggerIsGrounded()
    {
        return Physics2D.OverlapBox(digger.transform.position - new Vector3(0, .5f), new Vector2(.8f, floatOffset), 0, nodeLayer);
    }
    public bool CanDrill(Vector2Int dir)
    {
        return DiggerIsGrounded() && NodeExists(dir) && TouchingNode(dir);
    }
    private bool NodeExists(Vector2Int dir)
    {
        int nodeX = Digger.x + dir.x;
        int nodeY = Digger.y + dir.y;
        if (nodeX < gridWidth && nodeX >= 0 && nodeY < gridHeight && nodeY >= 0)
        {
            if (worldNodes[nodeX, nodeY] != null)
            {
                return true;
            }
        }
        return false;
    }
    private bool TouchingNode(Vector2Int dir)
    {
        if (dir.x == 1)
        {
            return digger.transform.position.x >= Digger.x - floatOffset;
        }
        else if (dir.x == -1)
        {
            return digger.transform.position.x <= Digger.x + floatOffset;
        }
        
        if (dir.y == -1)
        {
            return digger.transform.position.y <= Digger.y + floatOffset;
        }
        else if (dir.y == 1)
        {
            return digger.transform.position.y >= Digger.y + floatOffset;
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
}
