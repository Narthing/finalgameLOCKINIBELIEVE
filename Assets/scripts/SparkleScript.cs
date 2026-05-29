using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleScript : MonoBehaviour
{
    public Transform sparkleholder;
    

    private void FixedUpdate()
    {
        Vector3 rot = sparkleholder.eulerAngles;

        transform.rotation = Quaternion.Euler(rot.x, rot.y, transform.eulerAngles.z);
    }
}
