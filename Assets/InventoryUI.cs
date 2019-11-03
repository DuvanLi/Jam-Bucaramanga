using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image[] image;
     public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
