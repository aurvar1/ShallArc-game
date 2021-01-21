using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{

    public Animator anim;
    void Update()
    {
        if (this.gameObject.transform.position.y < 1)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.Play("platform_shake");
            StartCoroutine(Action());
        }

    }

    IEnumerator Action()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("Shook", true);
    }
}
