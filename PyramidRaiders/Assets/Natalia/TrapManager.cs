using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject[] traps; // Tablica z zapadniami w rzêdzie
    private int safeIndex; // Indeks bezpiecznej zapadni

    void Start()
    {
        // Wybierz losowo jedn¹ bezpieczn¹ zapadniê
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
            Debug.Log("Pu³apka!");
        }

        // Ukryj wszystkie zapadnie poza bezpieczn¹
        for (int i = 0; i < traps.Length; i++)
        {
            if (i != safeIndex)
            {
                traps[i].SetActive(false);
            }
        }
    }
}
