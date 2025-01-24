using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapss : MonoBehaviour
{
    private bool isTrap; // Czy zapadnia jest aktywna
    private bool triggered = false; // Czy zapadnia zosta³a ju¿ wyzwolona

    private void Start()
    {
        // Losujemy, czy zapadnia jest pu³apk¹ (33% szans)
        isTrap = Random.value <= 0.33f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;

            if (isTrap)
            {
                Debug.Log("Zapadnia siê otwiera!");
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
        // Animacja otwarcia zapadni (np. opadniêcie)
        transform.Translate(0, -2f, 0); // Przesuwa w dó³ dla prostego efektu
        Destroy(gameObject, 2f); // Usuwa zapadniê po czasie
    }
}