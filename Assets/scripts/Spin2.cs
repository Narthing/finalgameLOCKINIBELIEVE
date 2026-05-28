using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spin2 : MonoBehaviour
{
    public float spinspeed = 15f;
    void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 0, spinspeed);
    }
}
