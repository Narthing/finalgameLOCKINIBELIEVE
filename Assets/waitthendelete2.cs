using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitthendelete2 : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(waitthendelete());
    }
    IEnumerator waitthendelete()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
