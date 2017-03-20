using UnityEngine;
using System.Collections;

public class MouseMan : MonoBehaviour {

    private Renderer rend;

    public float tileX;
    public float tileY;
    public Place map;


	void Start()
	{
		rend = GetComponent<Renderer>();
		rend.material.color = Color.black;
	}

    void OnMouseUp()
    {
        map.MoveSelectUnitTo(tileX, tileY);
    }

    void OnMouseEnter()
    {
        rend.material.color = Color.red;
    }

    void OnMouseExit()
    {
        rend.material.color = Color.black;
    }
}
