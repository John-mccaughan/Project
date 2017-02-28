using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {


    public float speed = 10;

    Vector3 velocity;

    public float mass = 1;


    void Update()
    {
        transform.localScale = new Vector3(mass, mass, mass);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , 0);

        //Vector3 input2 = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
        
        Vector3 direction = input.normalized;

        velocity = direction * speed;
    }

    void FixedUpdate()
    {
        transform.Translate(velocity * Time.deltaTime);
    }
}