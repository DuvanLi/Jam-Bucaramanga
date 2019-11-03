using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject imageofItem;


    public void Start()
    {
        DontDestroyOnLoad(imageofItem);
    }
}
