using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float attractionRange = 10f;    // Zasięg przyciągania
    public float attractionForce = 5f;     // Siła przyciągania

    private void FixedUpdate()
    {
        // Znajdź obiekt gracza po tagu "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Oblicz dystans między przyciągającym obiektem a graczem
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // Sprawdź, czy gracz znajduje się w zasięgu przyciągania
            if (distance <= attractionRange)
            {
                // Oblicz kierunek przyciągania w stronę obiektu
                Vector3 direction = (player.transform.position - transform.position).normalized;

                // Dodaj siłę przyciągania do gracza
                Rigidbody playerRb = player.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    // Dodaj siłę w kierunku gracza
                    playerRb.AddForce(direction * attractionForce, ForceMode.Force);
                }
            }
        }
    }

    // Opcjonalnie, aby zobaczyć zasięg przyciągania w edytorze Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRange);
    }
}
