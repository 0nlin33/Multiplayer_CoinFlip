using UnityEngine;
using System.Collections;

public class CoinModelController : MonoBehaviour
{
    public float headsAngle = 180f;
    public float tailsAngle = 0f;
    private bool isRotating = false;
    private float rotatingSpeed = 150f;

    private static CoinModelController instance;

    public static CoinModelController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CoinModelController>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("CoinModelController");
                    instance = singletonObject.AddComponent<CoinModelController>();
                }
            }

            return instance;
        }
    }

    public void StartRotation(float targetAngle)
    {
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

