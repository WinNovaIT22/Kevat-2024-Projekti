using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenCameras : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;

    // Start is called before the first frame update
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cam1"))
        {
            SwitchCamera(cam1, cam2, cam3, cam4);
        }
        else if (collision.gameObject.CompareTag("Cam2"))
        {
            SwitchCamera(cam2, cam1, cam3, cam4);
        }
        else if (collision.gameObject.CompareTag("Cam3"))
        {
            SwitchCamera(cam3, cam1, cam2, cam4);
        }
        else if (collision.gameObject.CompareTag("Cam4"))
        {
            SwitchCamera(cam4, cam1, cam2, cam3);
        }
    }

    // Function to switch cameras
    private void SwitchCamera(Camera enableCam, Camera disableCam1, Camera disableCam2, Camera disableCam3)
    {
        if (!enableCam.enabled)
        {
            Debug.Log("Switching Camera");
            enableCam.enabled = true;
            disableCam1.enabled = false;
            disableCam2.enabled = false;
            disableCam3.enabled = false;
        }
    }
}
