using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongDoor : MonoBehaviour
{
    private bool hasAlreadyPassed = false;
    [SerializeField] GameObject[] correctTrigger;
    [SerializeField] AudioSource srcaudio;

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
        SceneManager.LoadScene("Die Scene 1");
    }

    private void PlayGunshot()
    {
        srcaudio.Play();
    }
}
