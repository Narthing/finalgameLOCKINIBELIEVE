using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenDelete : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(waitthendelete());
    }
    IEnumerator waitthendelete()
    {
        if (gameObject.CompareTag("NormalExplosion"))
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        Destroy(gameObject);
    }
}
