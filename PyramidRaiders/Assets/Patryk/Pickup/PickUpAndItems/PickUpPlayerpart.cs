using TMPro;
using UnityEngine;

public class PickUpPlayerpart : MonoBehaviour
{
    [SerializeField] public GameObject pickupHintUI; // Obiekt UI do wy�wietlania podpowiedzi
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
                // W��cz UI i wy�wietl nazw� przedmiotu
                pickupHintUI.SetActive(true);
                hintText.text = $"Naci�nij {pickupKey}, aby podnie�� {pickupItem.item.itemName}";

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
