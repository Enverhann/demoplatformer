using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate platform z axis
        transform.Rotate(0, 0, speed * Time.deltaTime / 0.01f, Space.Self);
    }
}
