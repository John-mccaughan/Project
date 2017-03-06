using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileMapGen))]
public class TilePlaceEditor : Editor {

	public override void OnInspectorGUI()
	{
		TileMapGen tile = (TileMapGen)target;
		if (DrawDefaultInspector())
		{
			if (tile.autoUpdate)
			{
				tile.DestroyChildren();
				tile.GenerateMap();
			}
		}
		if (GUILayout.Button("Generate"))
		{
			tile.DestroyChildren();
			tile.GenerateMap();
		}
	}
}