using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public Animator Animator;
    public int vidas = 3; // Vidas del objeto que colisiona
    public GameObject plataforma;
    public GameObject vida1;
    public GameObject vida2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.CompareTag("Enemy"))
        {
            Animator enemyAnimator3 = collision.transform.GetComponent<Animator>();
            if (enemyAnimator3 != null && !enemyAnimator3.GetBool("idle") && !enemyAnimator3.GetBool("idlero"))
            {
                Animator.SetBool("Muerte", true);
                Animator.SetBool("Salto", false);
                Animator.SetBool("Corriendo", false);
                Animator.SetBool("Idle", false);

                // Obtén el script de movimiento del enemigo
                MonsterMoves enemyMovement = collision.transform.GetComponent<MonsterMoves>();

                if (enemyMovement != null)
                {
                    StartCoroutine(HandleDamage(enemyMovement));
                }
            }
        }   
    }

    private IEnumerator HandleDamage(MonsterMoves enemyMovement)
    {
        // Desactiva el movimiento del enemigo
        enemyMovement.isMoving = false;

        // Resta una vida
        vidas--;
        Debug.Log("Vidas restantes: " + vidas); // Mensaje de depuración

        // Actualiza la visualización de las vidas
        if (vidas == 2)
        {
            Debug.Log("2 vidas");
            Destroy(vida1);
        }
        else if (vidas == 1)
        {
            Debug.Log("1 vida");
            Destroy(vida2);
        }

        // Espera un segundo
        yield return new WaitForSeconds(1f);
        TeleportToCenter();

        // Reactiva el movimiento del enemigo
        enemyMovement.isMoving = true;

        // Verifica si ha perdido todas las vidas
        if (vidas <= 0)
        {
            
            Destroy(gameObject); // Destruye este objeto
            Debug.Log("Objeto destruido."); // Mensaje de depuración
        }
    }

    private void TeleportToCenter()
    {
        transform.position = new Vector2(0.14f, 1.96f);
        Animator.SetBool("Muerte", false);
        Animator.SetBool("Idle", true);
        Debug.Log("Objeto teletransportado al centro."); // Mensaje de depuración
        plataforma.SetActive(true); 
    }
}
