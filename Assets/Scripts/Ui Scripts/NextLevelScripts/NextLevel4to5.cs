using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel4to5 : MonoBehaviour
{
    private void Start()
    {

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level 5");
    }
}