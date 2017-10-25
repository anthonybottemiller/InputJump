using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group : MonoBehaviour {

    float lastFall;

	// Use this for initialization
	void Start () {
		if (!IsValidGridPosition())
        {
            Debug.Log("Game Over Man!!!");
            Destroy(gameObject);
            QuitGame();
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localPosition += new Vector3(-1, 0, 0);

            if (IsValidGridPosition()) { UpdateGrid(); }
            else { transform.localPosition += new Vector3(1, 0, 0); }
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localPosition += new Vector3(1, 0, 0);

            if (IsValidGridPosition()) { UpdateGrid(); }

            else { transform.localPosition += new Vector3(-1, 0, 0); }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);

            if (IsValidGridPosition()) { UpdateGrid(); }
                
            else { transform.Rotate(0, 0, 90); }
                
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);
            //Debug.Log(transform.localPosition);
            if (IsValidGridPosition()) { UpdateGrid(); }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                PlayGrid.DeleteFullRows();

                FindObjectOfType<Spawner>().spawnNext();

                enabled = false;
            }

            lastFall = Time.time;
        }
    }

    bool IsValidGridPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 vector = PlayGrid.RoundVector2(child.position - transform.parent.localPosition);
            Debug.Log(vector);
            if (!PlayGrid.IsInsideBorder(vector)) {
                return false; }

            if (PlayGrid.grid[(int)vector.x, (int)vector.y] != null &&
                PlayGrid.grid[(int)vector.x, (int)vector.y].parent != transform)
            {

                return false;
            }
        }

        return true;
    }

    void UpdateGrid()
    {
        for (var y = 0; y < PlayGrid.height; ++y)
        {
            for(var x = 0; x < PlayGrid.width; ++x)
            {
                if(PlayGrid.grid[x,y] != null)
                {
                    if(PlayGrid.grid[x,y].parent == transform) { PlayGrid.grid[x, y] = null; }
                }
            }
        }
        foreach(Transform child in transform)
        {
            Vector2 vector;
            vector = PlayGrid.RoundVector2(child.position - transform.parent.localPosition);
            PlayGrid.grid[(int)vector.x, (int)vector.y] = child;
        }
    }
    public static void QuitGame()
    {
        GameObject FlightInterface = GameObject.Find("FlightInterface");
        CoolDownPanel coolDownPanel = FlightInterface.GetComponent<CoolDownPanel>();
        coolDownPanel.StopCoolGame();
    }

}
