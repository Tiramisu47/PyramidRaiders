using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getInventrory : MonoBehaviour
{
    [SerializeField] private Inventory_ItemCounter ItemConunter;
    public Inventory_ItemCounter GetInventory()
    {
        return ItemConunter;
    }
}
