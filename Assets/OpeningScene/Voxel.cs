using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Voxel
{

    protected GameObject volumetricShape;
    protected int szudzikId;
    protected float offsetHeight;   //y position offset from y = 0

    public Voxel() {}

    public virtual void setInfo(int x, int z, Material mat, GameObject chunkObject)
    {

        //		Debug.Log ("Setting voxel info" + "\n\tPosition: " + position + "\n\tParent: " + voxelChunk.transform + 
        //			"\n\tbaseYPosition: " + position.y);

        this.volumetricShape = GameObject.CreatePrimitive(PrimitiveType.Cube);

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

    protected static float computeHeight(float perlinHeight, float yScale, float offsetHeight)
    {
        return perlinHeight * yScale + offsetHeight;
    }

    private int calculateSzudzikId()
    {
        /*
Look up the 2d Szudzik function here
accessing a vertical neighbor cube from a vector's position
Vector accessNeighbor(Vector thisCube){


	if(thisCube.x > thisCube.z){
		szudzikKey = z^2 + x;
	} else {
		szudzikKey = x^2 + x + z;
	}

	SzudzikMap level = this.szudzikMaps[thisCube.y + heightOffset];
	Vector neighbor = level.get(szudzikKey);
}

//accessing a horizontal neighbor cube from the vector
Vector accessNeighbor(Vector thisCube, int xOffset, int zOffset){


	if(thisCube.x + xOffset > thisCube.z + zOffset){
		neighborSzudzikKey = (thisCube.z + zOffset)^2 + (thisCube.x + xOffset)
	} else {
		neighborSzudzikKey = (thisCube.x + xOffset)^2 + (thisCube.x + xOffset) + (thisCube.z + zOffset);
	}

	SzudzikMap level = this.szudzikMaps[thisCube.y];	//get the current level

	//the szudzikMap is just a hashMap of int, Vector: HashMap<int, Vector>
	//it has a guaranteed 1:1 correspondence between the added ints and vectors
	//its size is only as big as the number of elements in it

	Vector neighbor = level.get(neighborSzudzikKey);
}



if x=max(x,y,z): V=x^3+z*(x+1)+y
if y=max(x,y,z): V=y^3+(y+1)^2+z*y+x
if z=max(x,y,z): V=z^3+(z+1)^2+z*(z+1)+y*z+x
*/
        return 0;
    }

    public virtual void initialize()
    {
        Debug.Log("This should never print");
    }
}
