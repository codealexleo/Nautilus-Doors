using System.Collections;
using UnityEngine;

//public static class Globals { public static bool isAlreadyOpen = false; };

public class PressE : MonoBehaviour
{
    [SerializeField] float openDuration = 1f;
    [SerializeField] float openAngle = 90f;
    private Quaternion targetRotation;
    IsDoorManager isDoorManager;

    //public bool isAlreadyOpen = false;

    private void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f, LayerMask.GetMask("Default"), QueryTriggerInteraction.Collide))
            {
                if (hit.transform.CompareTag("Door"))
                {
                    targetRotation = hit.transform.rotation * Quaternion.Euler(0f, openAngle, 0f);
                    StartCoroutine(OpenDoorSmooth(hit.transform));
                    //isAlreadyOpen = true;
                    hit.transform.tag = "DoorOpen";

                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2.0f, Color.red, 1.0f);
        }
    }

    private IEnumerator OpenDoorSmooth(Transform doorTransform)
    {
        float timeElapsed = 0f;
        Quaternion startingRotation = doorTransform.rotation;

        while (timeElapsed < openDuration)
        {
            timeElapsed += Time.deltaTime;
            float t = Mathf.Clamp01(timeElapsed / openDuration);
            doorTransform.rotation = Quaternion.Slerp(startingRotation, targetRotation, t);
            yield return null;
        }

        doorTransform.rotation = targetRotation;
    }
}
