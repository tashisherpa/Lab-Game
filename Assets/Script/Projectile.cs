using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 3;
    public GameObject impactEffect;
    private Rigidbody2D rigid;
    [SerializeField] GameObject controller;
 
    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = transform.right * projectileSpeed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            controller.GetComponent<Scorekeeper>().AddPoints(3);
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
