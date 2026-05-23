using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realexplosionscript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddExplosionForce(14, transform.position, 4.9f, 1, ForceMode.VelocityChange);
        if (other.gameObject.CompareTag("Enemy"))
        {

        }
    }
    public float blastradius = 4f;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, blastradius);

    }
}
