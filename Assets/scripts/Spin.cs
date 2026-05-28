using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public RectTransform rtransform;

    // Start is called before the first frame update
    void Start()
    {
        rtransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rtransform.rotation *= Quaternion.Euler(0, 0, 15);
    }
}
