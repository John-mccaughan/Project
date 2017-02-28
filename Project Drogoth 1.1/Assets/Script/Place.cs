using UnityEngine;
using System.Collections;

public class Place : MonoBehaviour {

    public GameObject hexObj1;
    public GameObject hexObj2;
    public GameObject hexObj3;
    public GameObject hexObj4;
    public GameObject hexObj5;
    public GameObject hexObj6;
    public GameObject hexObj7;
    public GameObject hexObj8;
    public int width = 20;
    public int height = 20;

    public int uppermax;
    public float max;

    float offRowXOffSet = 1.519f;
    float offRowZOffSet = 1.315f;
    float offRowYOffSet = 0f;
    int count;
    int chestcount;

	Node[,] grid;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	public LayerMask unwalkableMask;

    public bool autoUpdate = true;
	GameObject tiles;

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
	}

    public void PlaceTile() {

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


                int randomnum = Random.Range(1, uppermax);
                if (randomnum == 1 || randomnum >= 8)
                {
                    GameObject hex_go1 = (GameObject)Instantiate(hexObj1, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                    hex_go1.name = "Hex1_" + x + "_" + y;
					hex_go1.transform.SetParent(tiles.transform);
                    hex_go1.isStatic =true;
                }
                else if (randomnum == 2)
                {
                    GameObject hex_go2 = (GameObject)Instantiate(hexObj2, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                    hex_go2.name = "Hex2_" + x + "_" + y;
					hex_go2.transform.SetParent(tiles.transform);
                    hex_go2.isStatic = true;
                    count++;
                }
                else if (randomnum == 3 && count < 4)
                {
                    GameObject hex_go3 = (GameObject)Instantiate(hexObj3, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                    hex_go3.name = "Hex3_" + x + "_" + y;
					hex_go3.transform.SetParent(tiles.transform);
                    hex_go3.isStatic = true;
                }
                else if (randomnum == 4 || randomnum == 3 && count >= 4)
                {
                    GameObject hex_go4 = (GameObject)Instantiate(hexObj4, new Vector3(xPos, Random.Range(0f, 0), y * offRowZOffSet), Quaternion.identity);
                    hex_go4.name = "Hex4_" + x + "_" + y;
					hex_go4.transform.SetParent(tiles.transform);
                    hex_go4.isStatic = true;
                }
                else if (randomnum == 5)
                {
                    GameObject hex_go5 = (GameObject)Instantiate(hexObj5, new Vector3(xPos, Random.Range(0f, 0), y * offRowZOffSet), Quaternion.identity);
                    hex_go5.name = "Hex5_" + x + "_" + y;
					hex_go5.transform.SetParent(tiles.transform);
                    hex_go5.isStatic = true;
                }
                else if (randomnum == 6)
                {
                    GameObject hex_go6 = (GameObject)Instantiate(hexObj6, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                    hex_go6.name = "Hex6_" + x + "_" + y;
					hex_go6.transform.SetParent(tiles.transform);
                    hex_go6.isStatic = true;
                }
                else if (randomnum == 7)
                {
                    if (chestcount <= 6)
                    {
                        GameObject hex_go7 = (GameObject)Instantiate(hexObj7, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                        hex_go7.name = "Hex7_" + x + "_" + y;
						hex_go7.transform.SetParent(tiles.transform);
                        hex_go7.isStatic = true;
                        chestcount++;
                    }

                    else
                    {

                        GameObject hex_go8 = (GameObject)Instantiate(hexObj8, new Vector3(xPos, Random.Range(0f, max), y * offRowZOffSet), Quaternion.identity);
                        hex_go8.name = "Hex8_" + x + "_" + y;
						hex_go8.transform.SetParent(tiles.transform);
                        hex_go8.isStatic = true;
                    }
                }
            }

        }
	}

    public void DestroyChildren()
    {
		DestroyImmediate (tiles);
    }
}
