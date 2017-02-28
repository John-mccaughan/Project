using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGen))]
public class MapGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        MapGen mapg = (MapGen)target;
        

		if (DrawDefaultInspector ()) {
			if (mapg.autoUpdate) {
				mapg.GenerateMap();
			}
		}
        if (GUILayout.Button("Generate"))
        {
            mapg.GenerateMap();
        }


    }
}
