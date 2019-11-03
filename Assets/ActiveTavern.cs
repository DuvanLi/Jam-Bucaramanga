using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTavern : MonoBehaviour
{
    public DialogSystem dialogsys;
    private bool once = false;
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<movementController>() != null && !once)
        {

            dialogsys.gameObject.SetActive(true);
            once = true;
        }
            
    }
}
