using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireEnemy : MonoBehaviour
{

    Animator anim;
    public AudioSource audio;

    private Transform target;
    public Transform firePoint;

    public float maxHealth = 200;
    public int touchDamage = 30;
    float nextAttackTime = 0f;
    public float attackRate = 2f;

    public float currentHealth;


    [Header("Unity Stuff")]
    public Image healthBar;

    [SerializeField]
    private GameObject fireball;
    void Start()
    {

        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) <= 20)
        {
            if (Time.time >= nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;
                Fireball();
                audio.Play();

            }
        }
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            target.gameObject.GetComponent<UI>().IncreasePoints(50);
            Die();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<UI>().TakeDamage(touchDamage);
        }
    }

    public void Fireball()
    {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }

    void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("Enemy died.");
    }

}
