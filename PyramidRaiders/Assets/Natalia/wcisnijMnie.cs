using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wcisnijMnie : MonoBehaviour
{
    bool active = false;
    [SerializeField] private Inventory_ItemCounter inventoryCounter;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !active)
        {
            active = true;
            inventoryCounter.SaveInventoryData(); //zapisuje dane
            Debug.Log("uruchomiono przycisk, koniec gry!");
            SceneManager.LoadScene("EndScene");
        }
        
    }
}
