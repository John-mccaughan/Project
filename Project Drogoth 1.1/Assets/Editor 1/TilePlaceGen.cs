using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Place))]
public class TilePlaceGen : Editor
{
    public override void OnInspectorGUI()
    {
        Place tiles = (Place)target;
        if (DrawDefaultInspector())
        {
            if (tiles.autoUpdate)
            {
				tiles.DestroyChildren();
                tiles.PlaceTile();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            tiles.DestroyChildren();
            tiles.PlaceTile();
        }
    }
	
}
