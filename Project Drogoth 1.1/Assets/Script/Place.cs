using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

    
    public GameObject hexObj1;

    public float width = 20f;
    public float height = 20f;


    float offRowXOffSet = 1.519f;
    float offRowZOffSet = 1.315f;

    public bool autoUpdate = true;
	GameObject tiles;

    //public TileType[] tileType;
    public GameObject selectedUnit;
    public float xPos;

    public void PlaceTile() {

        tiles = new GameObject();
		tiles.transform.SetParent(this.transform);
        for (int x = 0; x < width; x++)
        {
            for (float y = 0; y < height; y++)
            {
                xPos = x * offRowXOffSet;
                    if(y % 2 == 1)
                {
                    xPos += offRowXOffSet/2f;
                }
                    GameObject hex_go1 = (GameObject)Instantiate(hexObj1, new Vector3(xPos, 0, y * offRowZOffSet), Quaternion.identity);
                    hex_go1.name = "Hex1_" + x + "_" + y;
					hex_go1.transform.SetParent(tiles.transform);
                    hex_go1.isStatic = true;
                    MouseMan ct = hex_go1.GetComponent<MouseMan>();
                    ct.tileX = xPos;
					ct.tileY = y * offRowZOffSet;
                    ct.map = this;
            }

        }
	}

    public void MoveSelectUnitTo(float x, float y)
    {
        Debug.Log(xPos + " " + y);
		selectedUnit.transform.position = new Vector3(x, 3f, y);
    }

	public void SelectUnitFollowMouse(Vector3 moveUnit)
	{
		selectedUnit.transform.position = moveUnit;
	}

    public void DestroyChildren()
    {
		DestroyImmediate (tiles);
    }
}
