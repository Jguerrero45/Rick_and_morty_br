using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas : MonoBehaviour
{
    // Este método se llama cuando otro Collider2D sale del trigger
    private void OnCollisionExit2D(Collision2D Toco)
    {
        if (Toco.gameObject.CompareTag("Player"))
        {
            // Desactiva la plataforma después de que el jugador se baje
            StartCoroutine(DeactivatePlatform());
        }
    }

    private IEnumerator DeactivatePlatform()
    {
        // Espera un tiempo antes de desactivar
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        Debug.Log("Plataforma desactivada."); // Mensaje de depuración
    }
}


