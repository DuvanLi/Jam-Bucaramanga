using System;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    [SerializeField] private string question;
    [SerializeField]private Dialog[] Dialog;
    private int currDialogIndex = 0;
    private void Start()
    {
       
        FindObjectOfType<DialogSystem>().finish += Reset;
        currDialogIndex = 0;
    }

    public void NextDialog()
    {
        currDialogIndex++;
    }

    private void Reset()
    {
        currDialogIndex = 0;
    }

    public Dialog GetCurrentDialog()
    {
        return Dialog[currDialogIndex];
    }
    public Dialog GetCurrentDialog(int index)
    {
        return Dialog[index];
    }
    
}