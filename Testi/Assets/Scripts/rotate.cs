using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class rotate : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public bool back = false;
    public bool forward = false;
    
    void Update()
    {
        if (back)
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (forward)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }


    }
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
