using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenDelete : MonoBehaviour
{
    public Collider thiscollider;

    private void Start()
    {
        thiscollider = GetComponent<Collider>();
    }
    private void Awake()
    {
        StartCoroutine(waitthendelete());
        StartCoroutine(collideroneframe());
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
    IEnumerator collideroneframe()
    {
        
        yield return new WaitForEndOfFrame();
        thiscollider.enabled = false;
    }
}
