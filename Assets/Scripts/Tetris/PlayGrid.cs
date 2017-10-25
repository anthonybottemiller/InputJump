using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGrid : MonoBehaviour {
    public static int width = 10;
    public static int height = 20;
    public static Transform[,] grid = new Transform[width, height];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Vector2 RoundVector2(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }

    public static bool IsInsideBorder(Vector2 position)
    {
        return ((int)position.x >= 0 && 
                (int)position.x < width && 
                (int)position.y >= 0);
    }

    public static void DeleteRow(int y)
    {
        for (var x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public static void DropRow(int y)
    {
        for (var x = 0; x < width; ++x)
        {
            if (grid[x,y] != null)
            {
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void DropRowsAbove(int y)
    {
        for (var i = y; i < height; ++i)
        {
            DropRow(i);
        }
    }

    public static bool IsRowFull(int y)
    {
        for ( var x = 0; x < width; ++x)
        {
            if (grid[x,y] == null) { return false; }
        }
        return true;
    }

    public static void DeleteFullRows()
    {
        for ( var y = 0; y < height; ++y)
        {
            if (IsRowFull(y))
            {
                IncreaseLineScore();
                DeleteRow(y);
                DropRowsAbove(y + 1);
                --y;
            }
        }
    }

    public static void IncreaseLineScore()
    {
        GameObject FlightInterface = GameObject.Find("FlightInterface");
        CoolDownPanel coolDownPanel = FlightInterface.GetComponent<CoolDownPanel>();
        coolDownPanel.IncreaseScore();
    }

    public static void QuitGame()
    {
        GameObject FlightInterface = GameObject.Find("FlightInterface");
        CoolDownPanel coolDownPanel = FlightInterface.GetComponent<CoolDownPanel>();
        coolDownPanel.StopCoolGame();
    }
}
