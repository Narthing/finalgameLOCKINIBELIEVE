using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realexplosionscript : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject mcamera;
    public GameObject Player;
    public Rigidbody Playerrb;

    public float blastradius = 4.9f;
    public float blastkb = 16.8f;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

        mcamera = gameManager.gmcamera;
        Player = gameManager.gmplayer;
        Playerrb = gameManager.gmplayerrb;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("trigger entered");

        if (!gameObject.CompareTag("BackfireExplosion"))
        {
            other.attachedRigidbody.AddExplosionForce(blastkb, transform.position, blastradius, 1.7f, ForceMode.VelocityChange);
            if (other.gameObject.CompareTag("Enemy"))
            {

            }
        }
        else if (gameObject.CompareTag("BackfireExplosion"))
        {

            if (other.gameObject.CompareTag("MainPlayer"))
            {
                

                Quaternion rot = mcamera.transform.rotation;
                Vector3 velocity = Playerrb.velocity;

                velocity -= Playerrb.transform.right * Vector3.Dot(velocity, Playerrb.transform.right);

                velocity -= -Playerrb.transform.forward * Vector3.Dot(velocity, -Playerrb.transform.forward);

                velocity += mcamera.transform.forward * 30;

                Playerrb.velocity = velocity;




                Playerrb.AddExplosionForce(blastkb, transform.position, blastradius, 0f, ForceMode.VelocityChange);

                //Debug.Log("Player hit");

                if (other.gameObject.CompareTag("Enemy"))
                {

                }
            }
            else
            {
                //Debug.Log("player not hit");
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, blastradius);
    }
}
