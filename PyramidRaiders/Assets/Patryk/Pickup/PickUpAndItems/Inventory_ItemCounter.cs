using System.Collections.Generic;
using UnityEngine;

public class Inventory_ItemCounter : MonoBehaviour
{
    [SerializeField] private List<ItemsSO> items = new(); // Lista przedmiot�w

    // Dodaj przedmiot do listy
    public void AddItem(ItemsSO item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            Debug.Log($"Dodano przedmiot: {item.itemName}");
        }
        else
        {
            Debug.Log($"Przedmiot {item.itemName} ju� istnieje w ekwipunku.");
        }
    }

    // Usu� przedmiot z listy
    public void RemoveItem(ItemsSO item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Usuni�to przedmiot: {item.itemName}");
        }
        else
        {
            Debug.Log($"Przedmiot {item.itemName} nie istnieje w ekwipunku.");
        }
    }

    // Wy�wietl wszystkie przedmioty
    public void DisplayItems()
    {
        Debug.Log("Lista przedmiot�w w ekwipunku:");
        foreach (var item in items)
        {
            Debug.Log($"- {item.itemName}: {item.description}");
        }
    }
}
