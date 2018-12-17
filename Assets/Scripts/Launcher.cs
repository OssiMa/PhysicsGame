using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public Vector2 bulletSpeed;
    public GameObject bulletPrefab;

    bool pressed = false;
    Vector2 direction;
    Vector2 turretPosition;

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))            //Spawn bullet when clicking
        {
            if (pressed == false)
            {
                pressed = true;
                Physics shot;
                GameObject bullet;
                bullet = Instantiate(bulletPrefab);
                bullet.transform.position = gameObject.transform.position;


                Vector2 klik = Input.mousePosition;                         //Get the location of the mouse click
                klik = Camera.main.ScreenToWorldPoint(klik);
                CreateVector(klik);

                shot = bullet.GetComponent<Physics>();
                shot.velocity = direction;                          //Set the bullet velocity to the right direction by using the vector calculated in CreateVector Method
            }

        }
        else if (pressed == true)
        {
            pressed = false;
        }
    }

    void CreateVector(Vector2 mousePos)                 //Create vector using the given click location by comparing it to the player location
    {
        turretPosition = transform.position;
        direction = mousePos - turretPosition;          //End Point - Start point = Vector between the points
        direction.Normalize();                          //Normalize the vector to get the unit vector
        direction = Vector2.Scale(direction, bulletSpeed);          //Multiply the unitvector with the bullet speed;
    }

}
