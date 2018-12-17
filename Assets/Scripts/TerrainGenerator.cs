using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainGenerator : MonoBehaviour
{
    public Gamemanager gm;
    public Texture2D image;
    public GameObject player;
    public GameObject pahis;

    private GameObject CubeManager;
    bool playerSpawned = false;

    int xLocation;
    int yLocation;

    void Start()
    {
        CubeManager = new GameObject(); 
        CubeManager.name = "CubeManager";
        GenerateMap();
    }

    void GenerateMap()                                          //Generates the map by inspecting the pixels in given image and creating objects based on the color of the pixel
    {
        for (int x = 0; x < image.width; x+= 4)
        {
            xLocation++;
            yLocation = 0;
            for (int y = 0; y < image.width; y+=4)
            {
                yLocation++;
                if (GetColor(x, y) == Color.white)              //White is left blank
                {
                    
                }
                else if(GetColor(x,y) == Color.black)           //Black creates the player, and enemies after player is spawned
                {
                    if (playerSpawned == false)
                    {
                        GameObject turret = Instantiate(player);
                        turret.transform.position = new Vector3(xLocation, yLocation, 1);
                        playerSpawned = true;
                    }
                    else
                    {
                        GameObject enemy = Instantiate(pahis);
                        enemy.transform.position = new Vector3(xLocation, yLocation, 1);
                    }
                }
                else
                {                                                //Creates destroyable block with the same color as the pixel
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.parent = CubeManager.transform;
                    cube.GetComponent<Renderer>().material.color = GetColor(x, y);
                    cube.transform.position = new Vector3(xLocation, yLocation, 1);
                }
            }
        }
        gm.CheckEnemies();
    }

    Color GetColor(int x, int y)                            //Get the color of the given pixel
    {
        x = Mathf.Clamp(x, 0, image.width);
        y = Mathf.Clamp(y, 0, image.height);
        return image.GetPixel(x, y);
    }
}
