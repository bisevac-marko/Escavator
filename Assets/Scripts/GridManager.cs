using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int gridWidth = 50;
    private int gridHeight = 1000;
    private Grid grid;

    public static int startingHeight = 1000;
    private GameObject node;
    private GameObject worldTextParent;
    private GameObject nodeParent;
    private GameObject[,] worldNodes;
    public static GridManager Instance { get; private set; }
    private Digger digger;

    private void Start()
    {
        Instance = this;
        node = Resources.Load<GameObject>("Prefabs/Node");
        worldTextParent = new GameObject("World Text");
        nodeParent = new GameObject("Nodes");
        digger = FindObjectOfType<Digger>();
        worldNodes = new GameObject[gridWidth, gridHeight];
        grid = new Grid(gridWidth, gridHeight);
        grid.InitializeNodes(10);
    }
    public void DestroyNode(int posX, int posY)
    {
        Destroy(worldNodes[posX, posY]);
        worldNodes[posX, posY] = null;
    }
    public bool NodeExists(int x, int y)
    {
        if (x < gridWidth && x >= 0 && y < gridHeight && y >= 0)
        {
            if (worldNodes[x, y] != null && DiggerIsClose(x, y))
            {
                print("Node exists");
                return true;
            }
        }
        return false;
    }
    private bool DiggerIsClose(int x, int y)
    {
        float distance = Vector2.Distance(digger.transform.position, new Vector3(x, y));
        return  distance <= 1f;
    }
    public void CreateWorldText(string text, Vector3 position)
    {
        GameObject go = new GameObject("World_Text", typeof(TextMesh));
        go.transform.SetParent(worldTextParent.transform);
        go.transform.position = position;
        TextMesh textMesh = go.GetComponent<TextMesh>();
        textMesh.text = text;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.characterSize = 0.1f;
        textMesh.fontSize = 12;
        textMesh.color = Color.white;
    }
    public void InstantiateNode(int posX, int posY)
    {
        GameObject go = Instantiate(node, new Vector3(posX, posY), Quaternion.identity, nodeParent.transform);
        go.name = "Node" + ": " + posX + ", " + posY;
        worldNodes[posX, posY] = go;
    }
}
