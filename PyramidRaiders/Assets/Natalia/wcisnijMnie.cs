using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            getInventrory Get = other.GetComponent<getInventrory>();
            inventoryCounter = Get.GetInventory();
            inventoryCounter.SaveInventoryData(); //zapisuje dane
            Debug.Log("uruchomiono przycisk, koniec gry!");
            SceneManager.LoadScene(2);
        }
        
    }
}
