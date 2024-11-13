using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongDoor3 : MonoBehaviour
{
    private bool hasAlreadyPassed = false;
    [SerializeField] AudioSource srcaudio;
    [SerializeField] GameObject[] correctTrigger;

    void Start()
    {

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player") && !hasAlreadyPassed)
        {
            Destroy(correctTrigger[0]);

            Invoke("PlayGunshot", 2);
            Invoke("Die", 3);

            hasAlreadyPassed = true;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("Die Scene 3");
    }

    private void PlayGunshot()
    {
        srcaudio.Play();
    }
}
