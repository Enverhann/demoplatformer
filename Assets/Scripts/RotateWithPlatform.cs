//couldn't make it work
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithPlatform : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Rigidbody rb;
    private ConstantForce force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        force = GetComponent<ConstantForce>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Make player child object of rotating platform
        if(collision.gameObject.tag.Equals("Player")) {
            player.transform.parent = transform;
            force.force = new Vector3(5, 0, 0);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //Unmake player child object of rotating platform
        if (collision.gameObject.tag.Equals("Player"))
        {
            player.transform.parent = null;
            transform.Rotate(0, 0, 0);
        }
    }
    private void FixedUpdate()
    {
       rb.AddRelativeForce(Vector3.right * speed);
    }
}