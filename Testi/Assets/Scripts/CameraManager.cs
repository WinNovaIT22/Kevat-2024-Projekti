using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target; // Kamera seuraa t‰t‰ objektia
    public float smoothSpeed = 0.125f; // Sileyden m‰‰r‰ (suurempi arvo = suurempi sileyys)
    public Vector3 offset; // Kameran et‰isyys seurattavasta kohteesta
    public float zoomSpeed = 2f; // Zoomin nopeus
    public float minZoom = 8f; // Minimizoom
    public float maxZoom = 9f; // Maksimizoom

    void LateUpdate()
    {
        // Lasketaan haluttu kohdepaikka
        Vector3 desiredPosition = target.position + offset;
        // Lerp-funktio antaa sileyden
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Asetetaan kameran paikka
        transform.position = smoothedPosition;

        // Zoomaus
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        float newSize = Camera.main.orthographicSize - scrollWheel * zoomSpeed;
        newSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        Camera.main.orthographicSize = newSize;
    }
}