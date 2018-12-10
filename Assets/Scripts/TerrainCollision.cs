using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainCollision : MonoBehaviour
{

    public Texture2D image;//Just assign your image in the inspector.
    private GameObject CubeManager;

    int xLocation;
    int yLocation;
    

    Color GetColor(int x, int y)
    { //Get the color at a specific coordinate
        x = Mathf.Clamp(x, 0, image.width);
        y = Mathf.Clamp(y, 0, image.height);
        return image.GetPixel(x, y);
    }
    void Start()
    {
        CubeManager = new GameObject(); //So your hierachy doesn't get flooded you make them a child of the CubeManager gameobject.
        CubeManager.name = "CubeManager";
        GenerateMap();
    }
    void GenerateMap()
    {
        for (int x = 0; x < image.width; x+= 4)
        {
            xLocation++;
            yLocation = 0;
            for (int y = 0; y < image.width; y+=4)
            {
                yLocation++;
                if (GetColor(x, y) == Color.white)
                {
                    
                }
                else
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.parent = CubeManager.transform;
                    cube.GetComponent<Renderer>().material.color = GetColor(x, y);
                    cube.transform.position = new Vector3(xLocation, yLocation, 1);
                }
            }
        }
    }
}
