using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam1;
    public Transform target;
    public float smoothing;

    public Vector2 maxPos;
    public Vector2 minPos;

    public float zoomSpeed = 2f;
    public float minOrthoSize = 8.0f;
    public float maxOrthoSize = 9.0f;


    // Start is called before the first frame update
    void Start()
    {
        cam1 = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        cam1.orthographicSize = Mathf.Clamp(cam1.orthographicSize - scroll * zoomSpeed, minOrthoSize, maxOrthoSize);

        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        }

    }
}
