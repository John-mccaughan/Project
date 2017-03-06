using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGen : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColorMap, Mesh};
	public DrawMode drawMode;

	const int mapChunkSize = 100;
	[Range(0,6)]
	public int levelOfDetail;
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

	public GameObject hexObj1;
	public GameObject hexObj2;
	public GameObject hexObj3;

	float offRowXOffSet = 1.519f;
	float offRowZOffSet = 1.315f;

	GameObject tiles;

	public void GenerateMap()
	{
		tiles = new GameObject();
		tiles.transform.SetParent(this.transform);
		float[,] noiseMap = Noise.GenNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colormap = new Color[mapChunkSize * mapChunkSize];
		for (int y = 0; y < mapChunkSize; y++) {
			for (int x = 0; x < mapChunkSize; x++) {
				float currentHeight = TileHeightCurve.Evaluate(noiseMap[x,y]) * TileHeightMultiplier;
				print (currentHeight);
				float xPos = x * offRowXOffSet;
				if(y % 2 == 1)
				{
					xPos += offRowXOffSet/2f;
				}
				if (noiseMap[x,y] < .2f) {
					GameObject hex_goWater = (GameObject)Instantiate (hexObj2, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
					hex_goWater.name = "WaterHex_" + x + "_" + y;
					hex_goWater.transform.SetParent (tiles.transform);
					hex_goWater.isStatic = true;
				}
				else if (noiseMap[x,y] < .39f && noiseMap[x,y] > .15f) {
					GameObject hex_goWater1 = (GameObject)Instantiate (hexObj3, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
					hex_goWater1.name = "WaterHex_" + x + "_" + y;
					hex_goWater1.transform.SetParent (tiles.transform);
					hex_goWater1.isStatic = true;
				} else {

					GameObject hex_go1 = (GameObject)Instantiate (hexObj1, new Vector3 (xPos, currentHeight, y * offRowZOffSet), Quaternion.identity);
					hex_go1.name = "Hex1_" + x + "_" + y;
					hex_go1.transform.SetParent (tiles.transform);
					hex_go1.isStatic = true;
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