using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel1to2 : MonoBehaviour
{
    private void Start()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level 2");
    }
}