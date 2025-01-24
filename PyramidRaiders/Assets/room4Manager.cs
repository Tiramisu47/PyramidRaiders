using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room4Manager : MonoBehaviour
{
    public GameObject trapPrefab;
    public Transform[] rows;

    private void Start()
    {
        foreach (Transform row in rows)
        {
            SetupRow(row);
        }
    }

    private void SetupRow(Transform row)
    {
        int trapIndex = Random.Range(0, row.childCount); // Wybór jednej pu³apki

        for (int i = 0; i < row.childCount; i++)
        {
            GameObject trap = Instantiate(trapPrefab, row.GetChild(i).position, Quaternion.identity, row);
            trap.name = i == trapIndex ? "Trap" : "Safe";
        }
    }
}
