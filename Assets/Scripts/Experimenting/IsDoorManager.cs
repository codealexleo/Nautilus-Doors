using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDoorManager : MonoBehaviour
{
    public GameObject[] doors;
    //public bool canBeOpened = true;

    private void Start()
    {
        
    }

    private void Update()
    {
        bool doorFound = false;

        if (doors != null && doors.Length > 0)
        {
            foreach (var door in doors)
            {
                if (door != null && door.CompareTag("DoorOpen"))
                {
                    doorFound = true;
                    break;
                }
            }

            if (doorFound)
            {
                foreach (var door in doors)
                {
                    if (door != null)
                    {
                        door.tag = "DoorOpen";
                    }
                }
            }
        }
    }
}