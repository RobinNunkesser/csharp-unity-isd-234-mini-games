using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }


    // Update is called once per frame
    void Update()
    {  
        if (Math.Abs(rb.velocity.x) == 0.0f)
        {
            rb.velocity = new Vector3(0.1f, rb.velocity.y,rb.velocity.z);
        }
        if (Math.Abs(rb.velocity.y) == 0.0f)
        {
            rb.velocity = new Vector3(rb.velocity.x,0.1f, rb.velocity.z);
        }
        if (Math.Abs(rb.velocity.x) < 1.5f)
        {
            rb.velocity = new Vector3(2 * rb.velocity.x, rb.velocity.y,rb.velocity.z);
        }
        if (Math.Abs(rb.velocity.y) < 1.5f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 2 * rb.velocity.y,rb.velocity.z);
        }
    }
    
    private void Launch()
    {
        var x = Random.Range(0, 2) == 0 ? -1 : 1;
        var y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, speed * y, 0);
        Debug.Log("Current velocity: " + rb.velocity);
    }

    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPosition;
        Launch();
    }
    
}