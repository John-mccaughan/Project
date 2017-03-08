using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGen : MonoBehaviour {

	//public enum DrawMode {NoiseMap, ColorMap, Mesh};
	//public DrawMode drawMode;

	const int mapChunkSize = 100;
	//[Range(0,6)]
	//public int levelOfDetail;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public float TileHeightMultiplier;
	public AnimationCurve TileHeightCurve;

	public bool autoUpdate = true;

	//public TarrainType[] regions;

	public GameObject GrassHexObj1;
	public GameObject WaterHexObj1;
	public GameObject WaterHexObj2;
	public GameObject SandHexObj;
	public GameObject treeHexObj1;
	public GameObject treeHexObj2;

	float offRowXOffSet = 1.519f;
	float offRowZOffSet = 1.315f;

	GameObject tiles;

	public void GenerateMap()
	{
		int num;
		tiles = new GameObject();
		tiles.transform.SetParent(this.transform);
		float[,] noiseMap = Noise.GenNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colormap = new Color[mapChunkSize * mapChunkSize];
		for (int y = 0; y < mapChunkSize; y++) {
			for (int x = 0; x < mapChunkSize; x++) {
				float currentHeight = TileHeightCurve.Evaluate(noiseMap[x,y]) * TileHeightMultiplier;
				//print (currentHeight);
				float xPos = x * offRowXOffSet;
				if(y % 2 == 1)
				{
					xPos += offRowXOffSet/2f;
				}
				if (noiseMap [x, y] < .2f) {
					GameObject hex_goWater = (GameObject)Instantiate (WaterHexObj1, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
					hex_goWater.name = "WaterHex_" + x + "_" + y;
					hex_goWater.transform.SetParent (tiles.transform);
					hex_goWater.isStatic = true;
				} else if (noiseMap [x, y] < .39f && noiseMap [x, y] > .15f) {
					GameObject hex_goWater1 = (GameObject)Instantiate (WaterHexObj2, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
					hex_goWater1.name = "WaterHex_" + x + "_" + y;
					hex_goWater1.transform.SetParent (tiles.transform);
					hex_goWater1.isStatic = true;
				}
					else if (noiseMap[x,y] < .45f && noiseMap[x,y] > .39f) {
						GameObject hex_goSand1 = (GameObject)Instantiate (SandHexObj, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
						hex_goSand1.name = "SandHex_" + x + "_" + y;
						hex_goSand1.transform.SetParent (tiles.transform);
						hex_goSand1.isStatic = true;
				} else {
					num = Random.Range (1, 50);
					print ("Num" + num);
					if(num == 1  && noiseMap [x, y] > .48f){ 
						GameObject hex_go2 = (GameObject)Instantiate (treeHexObj1, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
						hex_go2.name = "treeHex1_" + x + "_" + y;
						hex_go2.transform.SetParent (tiles.transform);
						hex_go2.isStatic = true;
					}
					else if(num == 2 && noiseMap [x, y] > .48f){ 
						GameObject hex_go3 = (GameObject)Instantiate (treeHexObj2, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
						hex_go3.name = "treeHex2_" + x + "_" + y;
						hex_go3.transform.SetParent (tiles.transform);
						hex_go3.isStatic = true;
					}
					else{
						GameObject hex_go1 = (GameObject)Instantiate (GrassHexObj1, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
						hex_go1.name = "Hex1_" + x + "_" + y;
						hex_go1.transform.SetParent (tiles.transform);
						hex_go1.isStatic = true;
					}

				}
			}
		}
	}

	void OnValidate() {
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves< 0) {
			octaves = 0;
		}
	}
	public void DestroyChildren()
	{
		DestroyImmediate (tiles);
	}
}
