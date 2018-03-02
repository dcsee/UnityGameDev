using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenVoxelGeneration : MonoBehaviour {

    public void LoadByIndex() {

        //this opens Scene 1 from the build settings, which is the Perlin Noise Voxel Generation scene
        SceneManager.LoadScene((int) 1);
    }

}
