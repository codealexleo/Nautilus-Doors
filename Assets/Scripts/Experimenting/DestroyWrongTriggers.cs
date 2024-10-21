using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWrongTriggers : MonoBehaviour
{
    [SerializeField] GameObject[] triggers;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(triggers[0]);
            Destroy(triggers[1]);
            Destroy(triggers[2]);
        }
    }
}
