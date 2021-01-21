using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Transform firePoint;

    public float attackRange = 0.5f;
    public float attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    float comboTime = 1f;
    float lastClickedTime = -1000f;

    [SerializeField]
    private GameObject fireball;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.SetTrigger("Attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        attackDamage = GetComponent<UI>().level * 20 + 20;

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Pirmas X");
            lastClickedTime = Time.time;
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && comboTime >= Time.time - lastClickedTime)
        {
            Debug.Log("Pirmas i apacia");
            lastClickedTime = Time.time;
            
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && comboTime >= Time.time - lastClickedTime)
        {
            Debug.Log("ir rodykle");
            anim.SetTrigger("Fireball");
            lastClickedTime = 0;
        }
    }

    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy")
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            else if (enemy.tag == "FireEnemy")
                enemy.GetComponent<FireEnemy>().TakeDamage(attackDamage);
            else if (enemy.tag == "Boss")
                enemy.GetComponent<Boss>().TakeDamage(attackDamage);
        }
    }

    public void Fireball()
    {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
