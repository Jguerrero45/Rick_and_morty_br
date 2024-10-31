using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemiesflip : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
           
            
        }
    }
}
