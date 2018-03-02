using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandVoxel : Voxel
{

    protected const float xzScale = 10.0f;      //a scale parameter for the Perlin function
    protected const float yScale = 3.0f;        //a scale factor for the voxel's final height

    override public void initialize()
    {
        //creates a height based on the current X and Y position, using the Perlin noise function
        float perlinHeight = Mathf.PerlinNoise(volumetricShape.transform.position.x / xzScale,
            volumetricShape.transform.position.z / xzScale);

        int y = Mathf.RoundToInt(computeHeight(perlinHeight, yScale, offsetHeight));                    //the final y/height value for this voxel

        Vector3 newPosition = new Vector3(volumetricShape.transform.position.x,
            y, volumetricShape.transform.position.z);               //the starting position in 3D space for this voxel

        volumetricShape.transform.position = newPosition;

        //assign texture to shape
//        Texture2D texture = Resources.Load("GrassRockyAlbedo") as Texture2D;


        //assigns colors to this voxel
        Renderer renderer = volumetricShape.GetComponent<Renderer>();
        Color c = renderer.material.color;
        c.a = perlinHeight;
        c.b = perlinHeight;
        c.g = perlinHeight;
        c.r = perlinHeight;
        renderer.material.color = c;
//        volumetricShape.GetComponent<Renderer>().material.color = new Color(perlinHeight, perlinHeight, perlinHeight, perlinHeight);
    }
}
