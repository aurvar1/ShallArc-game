using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public BoxCollider2D boxCollider;
    private Animator anim;
    public float moveSpeed;
    public float jumpHeight;
    private bool facingRight = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        Flip(movement.x);

        if (!IsGrounded())
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        
    }

    void Jump()
    {
        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("takeOff");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float extraHeighText = .3f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeighText, groundLayerMask);
        return raycastHit.collider != null;
    }

    void Flip(float horizontal)
    {
        if(facingRight && horizontal < 0)
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if( !facingRight && horizontal > 0)
        {
            facingRight = !facingRight;
            transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }

    

   /* private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
            transform.parent = col.transform;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
            transform.parent = null;
    }
    */

}
