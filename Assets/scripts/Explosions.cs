using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public Rigidbody rb;
    public bool ishoming = false;
    public bool SpamLaunched = false;

    public Transform Target;

    public GameObject explosionprefab;

    public bool starthoming = false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(waitthendelete()); 
        Target = GameObject.Find("Enemy").transform;
        StartCoroutine(Starthoming());
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!collision.gameObject.CompareTag("Missile") && !collision.gameObject.CompareTag("Homing") && !collision.gameObject.CompareTag("Player"))
        {
            if (!ishoming)
            {
                Instantiate(explosionprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Enemy"))
            {
                Instantiate(explosionprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 44, ForceMode.VelocityChange); //make it go
        if (gameObject.CompareTag("Homing") && starthoming) 
        {
            transform.LookAt(Target.position);
        }
        if(rb.velocity.magnitude > 80) //cap velocity
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 80);
        }
        //Debug.Log(rb.velocity.magnitude);
    }

    IEnumerator waitthendelete()
    {
        if (gameObject.CompareTag("Homing"))
        {
            yield return new WaitForSeconds(60f);
        }
        else
        {
            yield return new WaitForSeconds(5f);
        }

        Destroy(gameObject);
    }
    IEnumerator Starthoming()
    {
        yield return new WaitForSeconds(0.1f);
        starthoming = true;
        while (true) //stop rockets from getting stuck circling something
        {
            yield return new WaitForSeconds(3f);
            Vector3 velocity = rb.velocity;
            velocity -= transform.right * Vector3.Dot(velocity, transform.right); //remove all velocity going sideways
            velocity += transform.forward * 200; //give 200 force forwards
            rb.velocity = velocity;
        }
    }
}
