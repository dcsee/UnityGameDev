using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelManager
{

    public static IEnumerable<T> generate<T>(GameObject chunk, Material mat, int dimensions) where T : Voxel, new()
    {

        //		Debug.Log ("Generating Voxels");

        List<T> voxels = new List<T>();

        for (int x = 0; x < dimensions; x++)
        {   //these loops generate all the voxels
            for (int z = 0; z < dimensions; z++)
            {

                if (typeof(T).IsSubclassOf(typeof(Voxel)))
                {
                    T voxel = new T();
                    voxel.setInfo(x, z, mat, chunk);
                    voxels.Add(voxel);
                    //					Debug.Log ("Initializing voxel of type: " + typeof(T));
                    voxel.initialize();
                }
            }
        }
        return voxels;
    }
}