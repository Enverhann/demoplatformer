using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex;
    private float minDistance = 0.1f;
    private float lastWaypointIndex;
    private Animator m_Animator;
    public float movementSpeed = 1.41f;
    private float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance
        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        //Play jump and play idle animation at finish
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 26;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
        if(targetWaypointIndex == 7)
        {
            m_Animator.Play("Jump");
        }
        if (targetWaypointIndex == 19)
        {
            m_Animator.Play("Jump");
        }
        if(targetWaypointIndex == 26)
        {
            m_Animator.Play("Idle");
        }
    }

   
    
}
