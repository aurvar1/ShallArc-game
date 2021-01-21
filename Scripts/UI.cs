using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Animator anim;
    public AudioSource audio;
    public AudioClip tuturu;
    public AudioClip oof;
    public GameObject deathScreen;
    public GameObject lvlUpScreen;
    public GameObject victoryScreen;

    public Text hp;
    public Text xp;
    public Text lvl;

    public Text lvlupHP;
    public Text lvlupDMG;

    public Slider hpBar;
    public Slider xpBar;
    public int level = 1;

    public float maxHealth = 100;
    public float maxXP = 100;
    public float currentHealth;
    public float currentXp;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        lvl.text = level.ToString();

    }

    void Update()
    {
        hp.text = currentHealth + "/" + maxHealth;
        hpBar.value = currentHealth / maxHealth * 100;

        xp.text = currentXp + "/" + maxXP;
        xpBar.value = currentXp / maxXP * 100;

        if (currentXp >= maxXP)
        {
            LevelUp();
        }

        if (gameObject.transform.position.y < -150)
        {
            anim.SetTrigger("isDead");
            deathScreen.SetActive(true);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    public void IncreasePoints(float points)
    {
            
        if (points == 500)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            currentXp += points;
        }
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            anim.SetTrigger("isDead");
            deathScreen.SetActive(true);
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            audio.clip = oof;
            audio.Play();
        }
    }

    public void LevelUp()
    {
        audio.clip = tuturu;
        audio.Play();
        level++;
        maxHealth = 80 + level * 20;
        currentHealth = maxHealth;
        currentXp = currentXp - maxXP;
        maxXP = level * 100;
        lvl.text = level.ToString();
        lvlupHP.text = maxHealth.ToString();
        lvlupDMG.text = (level * 20 + 20).ToString();

        lvlUpScreen.SetActive(true);
        Time.timeScale = 0f;

    }
}
