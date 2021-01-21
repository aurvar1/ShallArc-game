using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    public Animator animator;
    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        animator.SetTrigger("Touch");
    }

    public void Trekst()
    {
        audio.Play();
    }
}
