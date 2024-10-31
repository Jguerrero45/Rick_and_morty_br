using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed=2;
    public float JumpSpeed=3;

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;
    public Animator Animator;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            Animator.SetBool("Corriendo", true);
            Animator.SetBool("Salto",false);

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            Animator.SetBool("Corriendo", true);
            Animator.SetBool("Salto",false);
            Animator.SetBool("Idle",false);
        } 
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            if(CheckGround.isGrounded)
            {      
                Animator.SetBool("Corriendo", false);
                Animator.SetBool("Idle",true);
            }
        }
        if(Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
            Animator.SetBool("Salto", true);
            Animator.SetBool("Corriendo",false);
            Animator.SetBool("Idle",false);

        }
        if(CheckGround.isGrounded)
        {      
            Animator.SetBool("Salto", false);
            
            if (rb2D.velocity.x == 0)
            {
                Animator.SetBool("Idle", true);
            }
            else
            {
                Animator.SetBool("Idle", false);
            }
        }
        else
        {
            Animator.SetBool("Salto",true);
            Animator.SetBool("Corriendo",false);
            Animator.SetBool("Idle",false);
        }
    }
}
