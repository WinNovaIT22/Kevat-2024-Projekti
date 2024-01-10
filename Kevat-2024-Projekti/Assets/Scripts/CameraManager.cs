using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    public float zoomSpeed = 2f;
    public float minOrthoSize = 4.0f;
    public float maxOrthoSize = 8.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        cam1.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
        cam2.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
    }
}
