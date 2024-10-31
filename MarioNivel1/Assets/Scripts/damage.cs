using System.Collections;
using UnityEngine;


public class damage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el enemigo toca al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Animator enemyAnimator = GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                bool isIdle = enemyAnimator.GetBool("idle");
                bool isIdlero = enemyAnimator.GetBool("idlero");

                // Si el enemigo está en estado Idle o Idlero, inicia la destrucción
                if (isIdle || isIdlero)
                {
                    Debug.Log("El enemigo está en estado Idle o Idlero y será destruido.");
                    StartCoroutine(DestroyEnemy());
                }
                else
                {
                    Debug.Log("El enemigo no está en estado Idle o Idlero.");
                }
                enemyAnimator.SetBool("Salto",false);
            }
        }
    }

    private IEnumerator DestroyEnemy()
    {
        // Cambia el color del enemigo a blanco
        SpriteRenderer enemyRenderer = GetComponent<SpriteRenderer>();
        if (enemyRenderer != null)
        {
            enemyRenderer.color = Color.black;
        }
        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            enemyCollider.isTrigger = true;
        }

        // Espera 1 segundo antes de destruir el enemigo
        yield return new WaitForSeconds(1f);

        // Desactiva el collider
        

        Destroy(gameObject); // Destruye el enemigo
    }
}
