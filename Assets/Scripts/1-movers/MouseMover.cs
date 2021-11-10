using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This components moves and directs the player via the mouse angle on the screen
 * It uses the camera and mouse position in order to calculate the moust angle.
 */
public class MouseMover : MonoBehaviour
{
    public const float zeroAngle = 0f;
    void Update()
    {
        Vector2 cameraPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float mouseAngle = AngleBetweenTwoPoints(cameraPosition, mousePosition);
        transform.rotation = Quaternion.Euler(new Vector3(zeroAngle, zeroAngle, mouseAngle));
    }

    float AngleBetweenTwoPoints(Vector3 angleA, Vector3 angleB)
    {
        return Mathf.Atan2(angleA.y - angleB.y, angleA.x - angleB.x) * Mathf.Rad2Deg;
    }
}
