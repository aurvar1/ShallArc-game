using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    AudioSource aud;

    Animator anim;

    private Transform target;

    public float maxHealth = 100;
    public int touchDamage = 10;
    public float speed = 1f;

    public float currentHealth;

    public GameObject slimeSplash;

    [Header("Unity Stuff")]
    public Image healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        aud = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) <= 20)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        slimeSplash.GetComponent<ParticleSystem>().Play();
        healthBar.fillAmount = currentHealth / maxHealth;
        aud.Play();
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2,2), ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            target.gameObject.GetComponent<UI>().IncreasePoints(25);
            anim.SetTrigger("Dead");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UI>().TakeDamage(touchDamage);
        }
    }

    public void SlimeJump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }
    void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("Enemy died.");
    }

}
