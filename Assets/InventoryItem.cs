using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public int index;

    public void OnTriggerEnter2D(Collider2D col)
    {
        print("dTRIGGER");
        if (col.gameObject.GetComponent<movementController>() != null)
        {
            FindObjectOfType<InventoryUI>().image[index].sprite = item.image;
        Destroy(gameObject);
        }
    }
}
