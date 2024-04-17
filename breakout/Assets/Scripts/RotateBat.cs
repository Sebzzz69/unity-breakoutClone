using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBat : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float rotateDuration = 3f; // Duration in seconds for each rotation
    public float targetRotationAngle = 45f; // Target rotation angle in degrees

    private Quaternion originalRotation;
    private bool isRotating = false;


    void Start()
    {
        originalRotation = transform.rotation;
        //StartCoroutine(RotateObject());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isRotating)
        {
            StartCoroutine(RotateObject());
            Debug.Log("space");
        }
    }

    IEnumerator RotateObject()
    {   
            if (!isRotating)
            {
                isRotating = true;
                Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 0, targetRotationAngle); // Rotate to target angle
                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime / rotateDuration;
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, t);
                    yield return null;
                }
                transform.rotation = targetRotation; // Ensure final rotation is exact

                yield return new WaitForSeconds(0.3f); // Wait for a second

                // Rotate back to original position
                t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime / rotateDuration;
                    transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, t);
                    yield return null;
                }
                transform.rotation = originalRotation; // Ensure final rotation is exact

                isRotating = false;
            }
            yield return null;
    }
}
