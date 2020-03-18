using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int gridWidth = 50;
    private int gridHeight = 1000;
    private static Grid grid;
    public static int startingHeight = 1000;

    private static GameObject worldTextParent;
    private void Start()
    {
        worldTextParent = new GameObject("World Text");
        grid = new Grid(gridWidth, gridHeight, Vector2Int.zero);
    }
    public static bool CanMove(int posX, int posY, Vector2Int dir)
    {
        if (grid.IsNodeOccupied(posX + dir.x, posY + dir.y))
        {
            return false;
        }
        return true;
    }
    public static void SetIsDrilled(int posX, int posY)
    {
        grid.SetNodeDrilled(posX, posY);
    }

    public static void CreateWorldText(string text, Vector3 position)
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
}
