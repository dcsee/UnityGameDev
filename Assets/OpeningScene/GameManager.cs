using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameManager() { }

    List<AnimatedVoxel> animatedVoxels;

    private void initialize(){

        //initialize v chunk lists

        animatedVoxels = new List<AnimatedVoxel>();

        GameObject landChunk = makeGameObjectWithPosition(new Vector3(0, 0, 0));
        landChunk.name = "landChunk";

        GameObject waterChunk = makeGameObjectWithPosition(new Vector3(0, 5, 10));
        waterChunk.name = "waterChunk";

        GameObject lavaChunk = makeGameObjectWithPosition(new Vector3(50, 5, 50));
        lavaChunk.name = "lavaChunk";

        animatedVoxels = new List<AnimatedVoxel>();

        Material lavaMat = Resources.Load("LavaVoxelMat") as Material;
        Material landMat = Resources.Load("LandVoxelMat") as Material;


        IEnumerable<LandVoxel> lv = VoxelManager.generate<LandVoxel>(landChunk, landMat, 100);
        IEnumerable<WaterVoxel> wv = VoxelManager.generate<WaterVoxel>(waterChunk, lavaMat, 10);
        IEnumerable<LavaVoxel> lvv = VoxelManager.generate<LavaVoxel>(lavaChunk, lavaMat, 10);

        foreach (WaterVoxel v in wv)
        {
            animatedVoxels.Add(v);
        }

        foreach (LavaVoxel l in lvv)
        {
            animatedVoxels.Add(l);
        }

    }

    // Use this for initialization
    //called once, period
    void Start()
    {
        Debug.Log("Starting script");
        initialize();
    }

    GameObject makeGameObjectWithPosition(Vector3 position)
    {
        GameObject gameObject = new GameObject();
        gameObject.transform.position = position;
        return gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //for each GameObject in the animated lists, go over the voxels in its list and call their update method
        //but should call the Update in the Voxel class, not the MonoDevelop update
        //so Voxel should not inherit from MonoDevelop, so its Update is not always called once per frame

        foreach (AnimatedVoxel animated in animatedVoxels)
        {
            animated.animate();
        }
    }
}
