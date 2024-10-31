using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour // Cambié el nombre de la clase
{
    public GameObject roca1; // Corrige el tipo de GameObject
    public GameObject roca2; // Corrige el tipo de GameObject
    public GameObject roca3; // Corrige el tipo de GameObject

    void Awake()
    {
        StartCoroutine(limitador());
    }

    IEnumerator limitador()
    {
        yield return new WaitForSeconds(1f);
        roca1.SetActive(true);
        yield return new WaitForSeconds(7f);
        roca2.SetActive(true);
        yield return new WaitForSeconds(7f);
        roca3.SetActive(true);
    }
}

