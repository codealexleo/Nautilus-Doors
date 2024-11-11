using UnityEngine;
using System.Collections;

public class MoveDownOnTrigger : MonoBehaviour
{
    [SerializeField] float moveAmount = 1f;
    [SerializeField] float moveDuration = 1f;
    [SerializeField] GameObject greenLock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start moving down over time
            StartCoroutine(MoveDownOverTime());
            Invoke("DestroyLock", 2);
        }
    }

    private IEnumerator MoveDownOverTime()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition - new Vector3(0, moveAmount, 0);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
    private IEnumerator MoveLeftOverTime()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition - new Vector3(0, 0, moveAmount);

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }

    private void DestroyLock()
    { 
        Destroy(greenLock);
    }

}
