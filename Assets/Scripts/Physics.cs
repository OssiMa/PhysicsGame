using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{

    public float gravitationalForce = -9.81f;

    protected Rigidbody rb;
    GameObject gm;
    public Vector2 velocity;

    void OnEnable()
    {
        gm = GameObject.FindGameObjectWithTag("Gamemanager");
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        velocity.y += gravitationalForce * Time.deltaTime;                  // Velocity = G * Time

        Vector3 deltaPosition = velocity * Time.deltaTime;                  //Location = Velocity*Time

        rb.position = rb.position + deltaPosition;                          //Add the change in the location to the prievious location
    }


    private void OnCollisionEnter(Collision collision)                      //Destroy the objects colliding with the bullet
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
        if (collision.transform.tag == "Enemy")
        {
            gm.GetComponent<Gamemanager>().DestoryEnemy();
        }
    }
}
