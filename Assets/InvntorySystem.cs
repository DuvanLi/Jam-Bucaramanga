using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvntorySystem : MonoBehaviour
{
    [SerializeField] private Dictionary<int, Item> inventory;

    private const int slots = 3;

    public void addToInventory(Item item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (!inventory.ContainsKey(i))
            {
                inventory.Add(i, item);
            }
        }
    }

    public void remove(Item item)
    {
        for (int i = 0; i < slots; i++)
        {
            if (!inventory.ContainsKey(i)) continue;
            if (inventory.ContainsValue(item))
                inventory.Remove(i);
        }
    }
}

[CreateAssetMenu(fileName = "Item", menuName= "Jam/item")]
public class Item : ScriptableObject
{
    public GameObject prefab;
    public string name;
    public Sprite image;
}