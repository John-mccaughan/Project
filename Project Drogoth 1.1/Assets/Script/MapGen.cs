using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour {

	public enum DrawMode {NoiseMap, ColorMap, Mesh};
	public DrawMode drawMode;

	const int mapChunkSize = 241;
	[Range(0,6)]
	public int levelOfDetail;
    public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public float meshHeightMultiplier;
	public AnimationCurve MeshHeightCurve;

	public bool autoUpdate = true;

	public TarrainType[] regions;

    public void GenerateMap()
    {
		float[,] noiseMap = Noise.GenNoiseMap(mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colormap = new Color[mapChunkSize * mapChunkSize];
		for (int y = 0; y < mapChunkSize; y++) {
			for (int x = 0; x < mapChunkSize; x++) {
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (currentHeight <= regions [i].height) {
						colormap [y * mapChunkSize + x] = regions [i].color;
						break;
					}
				}
			}

			MapDisplay display = FindObjectOfType<MapDisplay> ();
			if (drawMode == DrawMode.NoiseMap) {
				display.DrawTexture (TextureGen.TextureFromHeightMap (noiseMap));
			} else if (drawMode == DrawMode.ColorMap) {
				display.DrawTexture (TextureGen.TextureFromColorMap (colormap, mapChunkSize, mapChunkSize));
			} else if (drawMode == DrawMode.Mesh) {
				display.DrawMesh (MeshGen.GenerateTerrainMesh (noiseMap, meshHeightMultiplier, MeshHeightCurve, levelOfDetail), TextureGen.TextureFromColorMap (colormap, mapChunkSize, mapChunkSize));
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
}

[System.Serializable]
public struct TarrainType {
	public string name;
	public float height;
	public Color color;
	}