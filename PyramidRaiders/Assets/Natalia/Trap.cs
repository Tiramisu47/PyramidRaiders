using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapManager manager; // Referencja do managera pu³apek
    public int trapIndex; // Indeks tej zapadni w rzêdzie

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.CheckTrap(trapIndex, other.gameObject);
        }
    }
}