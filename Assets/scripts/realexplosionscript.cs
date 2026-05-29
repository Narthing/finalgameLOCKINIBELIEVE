using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realexplosionscript : MonoBehaviour
{
    public GameObject mcamera;
    public GameObject Player;
    public Rigidbody Playerrb;

    public float blastradius = 4.9f;
    public float blastkb = 16.8f;

    private void Awake()
    {
        mcamera = GameObject.Find("Main Camera");
        Player = GameObject.Find("Player");
        Playerrb = Player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("BackfireExplosion"))
        {
            other.attachedRigidbody.AddExplosionForce(blastkb, transform.position, blastradius, 1.1f, ForceMode.VelocityChange);
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }
        else if (gameObject.CompareTag("BackfireExplosion"))
        {
            Quaternion rot = mcamera.transform.rotation;
            Vector3 velocity = Playerrb.velocity;

            velocity -= Playerrb.transform.right * Vector3.Dot(velocity, Playerrb.transform.right);

            velocity -= -Playerrb.transform.forward * Vector3.Dot(velocity, -Playerrb.transform.forward);

            velocity += mcamera.transform.forward * 30;

            Playerrb.velocity = velocity;

            other.attachedRigidbody.AddExplosionForce(blastkb, transform.position, blastradius, 0f, ForceMode.VelocityChange);
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, blastradius);
    }
}
