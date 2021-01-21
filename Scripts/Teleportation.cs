using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    public AudioSource audio;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Teleport());
            }
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        audio.Play();
        Player.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
