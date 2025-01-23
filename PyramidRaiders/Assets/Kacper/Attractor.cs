using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float attractionRange = 10f;    // Zasięg przyciągania
    public float attractionSpeed = 5f;     // Prędkość przyciągania

    private void Update()
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
                // Oblicz kierunek przyciągania
                Vector3 direction = (transform.position - player.transform.position).normalized;

                // Przemieść gracza w kierunku przyciągającego obiektu
                player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, attractionSpeed * Time.deltaTime);
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
