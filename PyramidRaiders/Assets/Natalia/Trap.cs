using UnityEngine;

public class Trap : MonoBehaviour
{
    public TrapManager manager; // Referencja do managera pu�apek
    public int trapIndex; // Indeks tej zapadni w rz�dzie

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.CheckTrap(trapIndex, other.gameObject);
        }
    }
}