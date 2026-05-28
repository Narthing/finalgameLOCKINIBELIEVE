using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenDelete : MonoBehaviour
{
    public Collider thiscollider;

    
    private void Awake()
    {
        if (gameObject.CompareTag("NormalExplosion")) //if its an explosion then get its collider
        {thiscollider = gameObject.GetComponent<Collider>();}

        StartCoroutine(waitthendelete());

        if (gameObject.CompareTag("NormalExplosion")) //if its an explosion then have its collider only run for a small moment
        {StartCoroutine(collideroneframe());}
    }
    IEnumerator waitthendelete()
    {
        if (gameObject.CompareTag("NormalExplosion"))
        {
            yield return new WaitForSeconds(1f);
        }
        else if(gameObject.CompareTag("RpgParticle"))
        {
            yield return new WaitForSeconds(0.2f);
        }
        else if (gameObject.CompareTag("Goldparticle"))
        {
            yield return new WaitForSeconds(4);
        }

            Destroy(gameObject);
    }
    IEnumerator collideroneframe()
    {
        thiscollider.enabled = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.1f);
        thiscollider.enabled = false;
    }
}
