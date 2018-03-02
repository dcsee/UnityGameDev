using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVoxel : AnimatedVoxel
{

    protected const float xzScale = 50.0f;      //a scale parameter for the Perlin function
    protected const float yScale = 1.0f;        //a scale factor for the voxel's final height
    private const float spinSpeed = 50f;        //the rotation speed for this voxel

    // Update is called once per frame
    override public void animate()
    {
        //makes a new height for this cube, to also change with time
        float perlinHeighAbs = Mathf.Abs(yScale * Mathf.PerlinNoise(
            Time.time + (volumetricShape.transform.position.x * xzScale),
            Time.time + (volumetricShape.transform.position.z * xzScale)));

        float newHeight = computeHeight(perlinHeighAbs, yScale, offsetHeight);

        //updates the child cube's color to change with the new height
        Renderer renderer = volumetricShape.transform.GetComponent<Renderer>();

        Color c = renderer.material.color;
        c.g = perlinHeighAbs;
        c.b = perlinHeighAbs;
        c.a = perlinHeighAbs;


        //updates the cube's position to be the new height
        Vector3 newPosition = volumetricShape.transform.position;
        newPosition.y = newHeight;
        volumetricShape.transform.position = newPosition;

        //spins the cube
        volumetricShape.transform.Rotate(perlinHeighAbs / 10, (5 * perlinHeighAbs) / 10, (3 * perlinHeighAbs) / 10);
    }

    override public void initialize()
    {
        //creates a height based on the current X and Y position, using the Perlin noise function
        float perlinHeight = Mathf.PerlinNoise(volumetricShape.transform.position.x / xzScale,
            volumetricShape.transform.position.z / xzScale);

        int y = Mathf.RoundToInt(computeHeight(perlinHeight, yScale, offsetHeight));    //the final y/height value for this voxel

        Vector3 newPosition = new Vector3(volumetricShape.transform.position.x,
            y, volumetricShape.transform.position.z);               //the starting position in 3D space for this voxel

        volumetricShape.transform.position = newPosition;

        //assigns colors to this voxel
        volumetricShape.GetComponent<Renderer>().material.color = new Color(0, y, y, 0.5f);
    }
}
