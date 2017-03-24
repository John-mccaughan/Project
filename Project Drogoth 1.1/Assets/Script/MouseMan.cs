using UnityEngine;
using System.Collections;

public class MouseMan : MonoBehaviour {

	private Renderer rend;

	public float tileX;
	public float tileY;
	public float tileZ;
	public TileMapGen map;
	GameObject tile;
	public Color color;

	void Start()
	{
		rend = GetComponent<Renderer>();
		color = rend.material.color;
	}

	void OnMouseUp()
	{
		map.MoveSelectUnitTo(tileX, tileY, tileZ);
	}

	void OnMouseEnter()
	{
		rend.material.color = Color.red;
	}

	void OnMouseExit()
	{
		rend.material.color = color;
	}
}