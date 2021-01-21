using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSounds : MonoBehaviour
{
    public AudioSource player;
    public AudioClip fireball;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip walk;

    public void AttackSound()
    {
        player.clip = attack;
        player.Play();
    }

    public void DeathSound()
    {
        player.clip = death;
        player.Play();
    }

    public void FireballSound()
    {
        player.clip = fireball;
        player.Play();
    }

    public void WalkingSound()
    {
        player.clip = walk;
        player.Play();
    }
}
