using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlaceTiles))]
public class TilePlaceEditor : Editor {

	public override void OnInspectorGUI()
	{
		PlaceTiles tile = (PlaceTiles)target;
		if (DrawDefaultInspector())
		{
			if (tile.autoUpdate)
			{
				tile.DestroyChildren();
				tile.TilePlace();
			}
		}
		if (GUILayout.Button("Generate"))
		{
			tile.DestroyChildren();
			tile.TilePlace();
		}
	}
}
