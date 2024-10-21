using UnityEngine;

public class PlayerIsInRange : MonoBehaviour
{

    public bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            //Debug.Log("Player entered range");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            //Debug.Log("Player exited range");
        }
    }
}
