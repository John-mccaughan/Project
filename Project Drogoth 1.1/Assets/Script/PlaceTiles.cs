using UnityEngine;
using System.Collections;

public class PlaceTiles : MonoBehaviour {

	public GameObject hexObj1;
	public int width = 20;
	public int height = 20;

	public int uppermax;

	float offRowXOffSet = 1.519f;
	float offRowZOffSet = 1.315f;
	float offRowYOffSet = 0f;
	int count;
	int chestcount;

	public bool autoUpdate = true;

	GameObject tiles;

    public void TilePlace () {
		tiles = new GameObject();
		tiles.transform.SetParent(this.transform);
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				float xPos = x * offRowXOffSet;
				if(y % 2 == 1)
				{
					xPos += offRowXOffSet/2f;
				}
				GameObject hex_go1 = (GameObject)Instantiate(hexObj1, new Vector3(xPos, Random.Range(0f,1f), y * offRowZOffSet), Quaternion.identity);

				hex_go1.name = "Hex1_" + x + "_" + y;
				hex_go1.transform.SetParent(tiles.transform);
				hex_go1.isStatic = true;
			}

		}

	}

	public void DestroyChildren()
	{
		DestroyImmediate (tiles);
	}
}