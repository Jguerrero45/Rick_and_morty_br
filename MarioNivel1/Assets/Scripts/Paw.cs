using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paw : MonoBehaviour
{
    public bool pordebajo;
    public Animator animatormap;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pow"))
        {
            Debug.Log("toco");
            pordebajo = true; // Se establece en true al tocar el Pow
            StartCoroutine(movimientopaw());
            StartCoroutine(HandleEnemiesIdle());
        }
        if(collision.gameObject.CompareTag("Mapa"))
        {
            Debug.Log("Tocando el techo");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pow"))
        {
            pordebajo = false; // Se establece en false al dejar de tocar el Pow
        }
    }

    private IEnumerator HandleEnemiesIdle()
    {
        // Encuentra todos los enemigos activos
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Cambia la animación de los enemigos a "Idle" y desactiva su movimiento
        foreach (GameObject enemy in enemies)
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            MonsterMoves enemyMovement = enemy.GetComponent<MonsterMoves>();
            if (enemyAnimator != null && enemyMovement != null)
            {
                enemyAnimator.SetBool("idle", true);
                enemyAnimator.SetBool("caminaro", false);
                enemyMovement.isMoving = false;
            }
        }

        // Espera 8 segundos
        yield return new WaitForSeconds(8f);

        // Reactiva la animación de caminar y movimiento de los enemigos
        foreach (GameObject enemy in enemies)
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            MonsterMoves enemyMovement = enemy.GetComponent<MonsterMoves>();
            if (enemyAnimator != null && enemyMovement != null)
            {
                enemyAnimator.SetBool("idle", false);
                enemyAnimator.SetBool("caminaro", true);
                enemyMovement.runSpeed = 2;
                enemyMovement.isMoving = true;
            }
        }

    }

    private IEnumerator movimientopaw()
    {
        animatormap.enabled = true;
        yield return new WaitForSeconds(1f);
        animatormap.enabled = false;
    }

    
}
