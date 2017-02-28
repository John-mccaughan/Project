using UnityEngine;
using System.Collections;

public class MouseMan : MonoBehaviour {



    void Start()
    {
		
    }
    //Update is called once per frame
    void Update () {

        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin,ray.direction);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)){
            GameObject hitObj = hitInfo.collider.transform.gameObject;
            if(hitObj.tag == "Ground")
           {
                MeshRenderer mr = hitObj.GetComponentInChildren<MeshRenderer>();
                mr.material.color = Color.red;
            }
        }

    }

    //void OnMouseEnter()
    //{
     //   renderer.material.color = Color.red;
    //}

    //void OnMouseExit()
    //{
       // renderer.material.color = Color.black;
   // }
}
