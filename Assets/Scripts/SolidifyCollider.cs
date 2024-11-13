using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidifyCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider myCollider;

    private void Start()
    {
        // Get the collider component attached to this GameObject
        myCollider = GetComponent<Collider>();

        // Make sure the collider starts as a trigger
        myCollider.isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting is the player (or whichever object you want to check)
        if (other.CompareTag("Player"))
        {
            // Turn off the trigger, making it a regular collider
            myCollider.isTrigger = false;

            Debug.Log("Trigger is now a regular collider");
        }
    }
}
