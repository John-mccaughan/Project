using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour {

    public Renderer txtRend;
	public MeshFilter meshFilter;
	public MeshRenderer meshRender;

	public void DrawTexture(Texture2D texture)
    {
        txtRend.sharedMaterial.mainTexture = texture;
		txtRend.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

	public void DrawMesh(MeshData meshdata, Texture2D texture) {
		meshFilter.sharedMesh = meshdata.CreateMesh ();
		meshRender.sharedMaterial.mainTexture = texture;
		
	}
}
