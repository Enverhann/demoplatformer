using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAfterFinish : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Transform player;
    private Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Wall").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        MoveCam();
    }
    // Update is called once per frame
    public void MoveCam()
    {
        //After finishing the game camera slowly pans to the wall
        Vector3 newPos = new Vector3(target.position.x, 3, 46);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
    }
}
