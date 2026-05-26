using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y <= -15)
        {
            transform.position = new Vector3(-5.63f, 2.21f, -6.95f);
        }
    }
}
