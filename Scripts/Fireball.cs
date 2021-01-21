using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float fireballSpeed;

    private Rigidbody2D rigidbody;

    private float timeAlive = 10f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * fireballSpeed;
        timeAlive = Time.time;
    }

    private void Update()
    {
        if (Time.time - timeAlive > 10f)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(100);
            Destroy(gameObject);

        }
        if (collision.tag == "FireEnemy")
        {
            collision.gameObject.GetComponent<FireEnemy>().TakeDamage(100);
            Destroy(gameObject);
        }

        if (collision.tag == "Boss")
        {
            collision.gameObject.GetComponent<Boss>().TakeDamage(100);
            Destroy(gameObject);
        }
        else if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }

}
