using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public Rigidbody rb;
    public bool ishoming = false;

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
        /*
        if (!collision.gameObject.CompareTag("Missile") || !collision.gameObject.CompareTag("Homing"))
        {
            Instantiate(explosionprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
        */

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 11, ForceMode.VelocityChange);
        if (gameObject.CompareTag("Homing") && starthoming) //FIX HOMING to make it not indefinitely spin out also a smoke trail
        {
            transform.LookAt(Target.position);
        }
        if(rb.velocity.magnitude > 200)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 200);
        }
    }

    IEnumerator waitthendelete()
    {
        if (gameObject.CompareTag("Homing"))
        {
            yield return new WaitForSeconds(15f);
        }
        else
        {
            yield return new WaitForSeconds(5f);
        }

        Destroy(gameObject);
    }
    IEnumerator Starthoming()
    {
        yield return new WaitForSeconds(0.3f);
        starthoming = true;
        yield return new WaitForSeconds(3.4f);
        rb.AddForce(transform.forward * 11, ForceMode.VelocityChange);
    }
}
