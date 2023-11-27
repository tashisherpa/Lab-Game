using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject obstacle;
    private int currentWaypointIndex = 0;

    [SerializeField] private float SPEED = 2f;

   private void Update()
   {

        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (gameObject.CompareTag("Enemy"))
            {
                Flip();
            }
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position,Time.deltaTime*SPEED) ;
   }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
}
