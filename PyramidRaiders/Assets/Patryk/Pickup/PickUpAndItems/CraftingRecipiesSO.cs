using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "ItemsObject/Recipe")]
public class CraftingRecipe : ScriptableObject
{
    public ItemsSO resultItem;       // Przedmiot, który powstanie
    public ItemsSO[] ingredients;    // Sk³adniki potrzebne do stworzenia przedmiotu
    public int[] ingredientCounts; // Iloœæ ka¿dego sk³adnika (odpowiada `ingredients`)
}
