using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoves : MonoBehaviour
{
    public float runSpeed = 1f;
    private Rigidbody2D rb2D;
    public SpriteRenderer spriteRenderer;
    public bool isMoving = true; // Controla el movimiento

    public Transform abajoder;  // Transform para abajo derecha
    public Transform abajoizq;  // Transform para abajo izquierda
    public Transform arribader;  // Transform para arriba derecha
    public Transform arribaizq;  // Transform para arriba izquierda

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb2D && isMoving) // Solo se mueve si isMoving es true
        {
            if (spriteRenderer.flipX == false)
            {
                rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            }
        }
        else if (rb2D) // Detiene el movimiento si isMoving es false
        {
            rb2D.velocity = Vector2.zero; // Asegúrate de que la velocidad se detenga
        }
    }

    private void OnTriggerEnter2D(Collider2D coso)
    {
        if (coso.CompareTag("Portal"))
        {

            if (abajoder != null && arribader != null && abajoizq != null && arribaizq != null)
            {
                if (coso.transform == abajoder)
                {
                    transform.position = arribader.position;
                    spriteRenderer.flipX = false;
                    
                }


                else if (coso.transform == abajoizq)
                {
                    transform.position = arribaizq.position;
                    spriteRenderer.flipX = true;
                   
                }
            }
            else
            {
                
            }
        }
    }
}
