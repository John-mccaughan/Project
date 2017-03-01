using UnityEngine;
using System.Collections;

public class MouseMan : MonoBehaviour {

    private Color basicColor = Color.green;
    private Color hoverColor = Color.red;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.black;
    }

    void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.black;
    }
}
