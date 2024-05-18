using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Needs to exists in every scene.
    // Prefab exists free to use

    // Usage:
    // E.g attach to a button, script or other --> Call a function and enter correct scene name.

    int level;
    public void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);

    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

