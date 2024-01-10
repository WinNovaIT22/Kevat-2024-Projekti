using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;

    public float zoomSpeed = 2f;
    public float minOrthoSize = 8.0f;
    public float maxOrthoSize = 9.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        cam1.orthographicSize = Mathf.Clamp(cam1.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
        cam2.orthographicSize = Mathf.Clamp(cam2.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
        cam3.orthographicSize = Mathf.Clamp(cam3.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
        cam4.orthographicSize = Mathf.Clamp(cam4.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);
    }
}
