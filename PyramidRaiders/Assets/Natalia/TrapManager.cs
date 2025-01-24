using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject[] traps; // Tablica z zapadniami w rz�dzie
    private int safeIndex; // Indeks bezpiecznej zapadni

    void Start()
    {
        // Wybierz losowo jedn� bezpieczn� zapadni�
        safeIndex = Random.Range(0, traps.Length);
    }

    public void CheckTrap(int trapIndex, GameObject player)
    {
        if (trapIndex == safeIndex)
        {
            Debug.Log("Bezpieczna zapadnia!");
        }
        else
        {
            Debug.Log("Pu�apka!");
        }

        // Ukryj wszystkie zapadnie poza bezpieczn�
        for (int i = 0; i < traps.Length; i++)
        {
            if (i != safeIndex)
            {
                traps[i].SetActive(false);
            }
        }
    }
}
