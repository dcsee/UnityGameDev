using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralToolkit.Examples.Primitives;


public class LavaVoxel : AnimatedVoxel
{

    protected const float xzScale = 50.0f;      //a scale parameter for the Perlin function
    protected const float yScale = 5.0f;        //a scale factor for the voxel's final height
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
//        volumetricShape.transform.GetComponent<Renderer>().material.color = new Color(perlinHeighAbs, 0, perlinHeighAbs, 0);
        Renderer renderer = volumetricShape.transform.GetComponent<Renderer>();
        Color c = renderer.material.color;
        c.r= perlinHeighAbs;
        c.b = perlinHeighAbs;
        renderer.material.color = c;
        
        //updates the cube's position to be the new height
        Vector3 newPosition = volumetricShape.transform.position;
        newPosition.y = newHeight;
        volumetricShape.transform.position = newPosition;

        //spins the cube
        volumetricShape.transform.Rotate(perlinHeighAbs / 10, (5 * perlinHeighAbs) / 10, (3 * perlinHeighAbs) / 10);
    }

    override public void setInfo(int x, int z, Material mat, GameObject chunkObject)
    {
        GameObject obj = new GameObject();
        obj.AddComponent(typeof(Dodecahedron));
        this.volumetricShape = obj;

        volumetricShape.transform.parent = chunkObject.transform;               //set the shape's parent

        //set the shape's position
        volumetricShape.transform.position =
            new Vector3(x + chunkObject.transform.position.x,
                chunkObject.transform.position.y, z + chunkObject.transform.position.z);

        //calculate shapeId here using sadzinsky thing
        offsetHeight = chunkObject.transform.position.y;

        //set the material
        //assigns material to this voxel
        Renderer renderer = volumetricShape.GetComponent<Renderer>();
        renderer.material = mat;
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
        volumetricShape.GetComponent<Renderer>().material.color = new Color(y, 0, y, 1);
    }
}
