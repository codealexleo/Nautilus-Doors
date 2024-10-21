using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousScene : MonoBehaviour
{
    public int currentSceneIndex;
    public int lastSceneIndex;// Store the current scene index

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get the current scene index
    }

    // Method to get the next scene index
    public int GetNextSceneIndex()
    {
        return currentSceneIndex + 1; // Return the next scene index
    }
}
