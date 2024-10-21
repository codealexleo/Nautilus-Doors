using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLookAtTarget : MonoBehaviour
{
    private Transform target;
    [SerializeField] PlayerIsInRange playerIsInRange;

    private Quaternion initialRotation;
    private float resetDuration = 1f;

    void Start()
    {
        initialRotation = transform.rotation;

        Camera mainCamera = Camera.main;

        target = mainCamera.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && playerIsInRange.playerInRange)
        {
            // Make the turret look at the target
            transform.LookAt(target, Vector3.back + Vector3.left);
        }
        else if (target != null && !playerIsInRange.playerInRange)
        {
            // Start the coroutine to reset to the initial rotation
            StartCoroutine(ResetToDefaultPosition());
        }
    }

    // Coroutine to reset the turret's rotation smoothly to its initial rotation
    private IEnumerator ResetToDefaultPosition()
    {
        float timeElapsed = 0f;
        Quaternion startingRotation = transform.rotation;  // Capture the current rotation

        while (timeElapsed < resetDuration)
        {
            float t = timeElapsed / resetDuration;
            // Smoothly interpolate between current rotation and initial rotation
            transform.rotation = Quaternion.Slerp(startingRotation, initialRotation, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the rotation is exactly set to the initial rotation at the end
        transform.rotation = initialRotation;
    }
}
