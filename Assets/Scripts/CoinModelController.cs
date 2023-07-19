using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinModelController : MonoBehaviour
{
    public float headsAngle = 180f;
    public float tailsAngle = 0f;
    private bool isRotating = false;
    private float rotatingSpeed = 150f;

    public void StartRotation(float targetAngle)
    {
        // Ensure the rotation is stopped before starting a new rotation
        if (!isRotating)
        {
            StartCoroutine(RotateToTargetAngle(targetAngle));
        }
    }

    private IEnumerator RotateToTargetAngle(float targetAngle)
    {
        isRotating = true;

        while (Mathf.Abs(transform.eulerAngles.y - targetAngle) > 0.1f)
        {
            float step = rotatingSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), step);
            yield return null;
        }

        isRotating = false;
    }
}
