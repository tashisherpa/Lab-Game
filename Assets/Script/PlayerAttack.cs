using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public  Transform firePosition;
    public GameObject projectile;

   

    // Update is called once per frame
    void Update()
    {
        //get an input from the player
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation);
        }
        //spawn a projectile, where to spawn it?
    }
}
