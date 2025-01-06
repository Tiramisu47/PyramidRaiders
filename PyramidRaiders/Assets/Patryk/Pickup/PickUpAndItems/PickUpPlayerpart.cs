using TMPro;
using UnityEngine;

public class PickUpPlayerpart : MonoBehaviour
{
    [SerializeField] public GameObject pickupHintUI; // Obiekt UI do wyœwietlania podpowiedzi
    [SerializeField] public TextMeshProUGUI hintText; // Tekst w UI
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Inventory_ItemCounter inventoryCounter;
    [SerializeField] private string pickupKey ="F";
    [SerializeField] private float pickupRange = 5.0f;
  
    void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, pickupRange))
        {
            ItemToPickup pickupItem = hit.collider.GetComponent<ItemToPickup>();
            if (pickupItem != null)
            {
                // W³¹cz UI i wyœwietl nazwê przedmiotu
                pickupHintUI.SetActive(true);
                hintText.text = $"Naciœnij {pickupKey}, aby podnieœæ {pickupItem.item.itemName}";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventoryCounter.AddItem(pickupItem.item);
                    Destroy(hit.collider.gameObject);
                    pickupHintUI.SetActive(false);
                }
            }
            else
            {
                pickupHintUI.SetActive(false);
            }
        }
        else
        {
            pickupHintUI.SetActive(false);
        }
    }
}
