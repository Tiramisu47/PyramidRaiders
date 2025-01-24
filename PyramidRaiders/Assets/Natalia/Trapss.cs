using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapss : MonoBehaviour
{
    private bool isTrap; // Czy zapadnia jest aktywna
    private bool triggered = false; // Czy zapadnia zosta�a ju� wyzwolona

    private void Start()
    {
        // Losujemy, czy zapadnia jest pu�apk� (33% szans)
        isTrap = Random.value <= 0.33f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            if (isTrap)
            {
                Debug.Log("Zapadnia si� otwiera!");
                OpenTrap();
            }
            else
            {
                Debug.Log("Bezpieczna zapadnia.");
            }
        }
    }

    private void OpenTrap()
    {
        // Animacja otwarcia zapadni (np. opadni�cie)
        transform.Translate(0, -2f, 0); // Przesuwa w d� dla prostego efektu
        Destroy(gameObject, 2f); // Usuwa zapadni� po czasie
    }
}