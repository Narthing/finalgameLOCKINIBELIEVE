using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()                       //add baldi enemy to game
    {
        transform.LookAt(player);
        rb.AddForce(transform.forward * 0.4f, ForceMode.VelocityChange);
    }
}
