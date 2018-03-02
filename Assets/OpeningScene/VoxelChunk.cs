using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelChunk
{

    GameObject chunk;
    List<Voxel> voxelList;

    public VoxelChunk(Vector3 position)
    {
        chunk = new GameObject();
        chunk.transform.position = position;
        voxelList = new List<Voxel>();
    }

    public GameObject getChunk()
    {
        return chunk;
    }

    public void addVoxel(Voxel voxel)
    {
        voxelList.Add(voxel);
    }

    public IEnumerable<Voxel> getVoxels()
    {
        return voxelList;
    }
}
