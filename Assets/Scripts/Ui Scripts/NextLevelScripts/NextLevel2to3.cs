using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel2to3 : MonoBehaviour
{
    private void Start()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level 3");
    }
}