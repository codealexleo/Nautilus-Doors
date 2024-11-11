using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}
