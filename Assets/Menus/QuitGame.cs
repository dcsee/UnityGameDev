using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour {

    public void QuitToDesktop()
    {
        //this is platform-specific compilation
        //if the game is running in the unity editor, just exit play mode
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        //otherwise, quit the game entirely
#else
        Application.Quit();
        #endif
    }
}
