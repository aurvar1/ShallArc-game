using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    public float fireballSpeed;

    [SerializeField]
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UI>().TakeDamage(50);
            Destroy(gameObject);
        }
        else if (collision.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }

    

}
