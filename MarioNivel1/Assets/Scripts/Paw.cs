using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paw : MonoBehaviour
{
    public Animator animator; // Este Animator podría no ser necesario en este contexto
    public Animator animator2; // Si necesitas referenciar diferentes animadores, puedes mantenerlos
    public Animator animator3; // Se mantiene para la referencia
    public bool pordebajo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que sea el jugador
        {
            pordebajo = true;
            StartCoroutine(HandleEnemiesIdle());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Asegúrate de que sea el jugador
        {
            pordebajo = false;
        }
    }

    private IEnumerator HandleEnemiesIdle()
    {
        // Encuentra todos los enemigos activos
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        // Cambia la animación de los enemigos a "Idle"
        foreach (GameObject enemy in enemies)
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("Idle", true); // Cambia a la animación "Idle"
            }
        }

        // Espera 8 segundos
        yield return new WaitForSeconds(8f);
    
        // Cambia la animación de los enemigos a "Caminaro"
        foreach (GameObject enemy in enemies)
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                enemyAnimator.SetBool("Idle", false); // Cambia a la animación "Idle" a false
                enemyAnimator.SetBool("Caminaro", true); // Cambia a la animación "Caminaro"
                
                // Aquí se asume que el enemigo tiene un componente de movimiento
                MonsterMoves enemyMovement = enemy.GetComponent<MonsterMoves>();
                if (enemyMovement != null)
                {
                    enemyMovement.runSpeed = 2; // Cambia la velocidad del enemigo a 2
                    enemyMovement.isMoving = true; // Asegúrate de que el enemigo se mueva
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Verifica si el enemigo está en la animación "Idle" o "Idlero" antes de destruirlo
            Animator enemyAnimator = collision.GetComponent<Animator>();
            if (enemyAnimator != null)
            {
                if (enemyAnimator.GetBool("Idle") || enemyAnimator.GetBool("Idlero"))
                {
                    // Destruye el enemigo si está en la animación "Idle" o "Idlero"
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
