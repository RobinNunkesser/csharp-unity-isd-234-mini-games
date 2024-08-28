using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;

    public float speed;
    public Rigidbody rb;
    public Vector3 startPosition;

    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        } else {
            movement = Input.GetAxisRaw("Vertical2");
        }
        
        rb.velocity = new Vector3(0, movement * speed, 0);
    }
    
    public void Reset()
    {
        rb.velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
