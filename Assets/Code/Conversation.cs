using System;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    public string question;
    [SerializeField] private Dialog[] Dialog;
    private int currDialogIndex = 0;
    public bool FinishConversation { get; private set; }

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
        try
        {
            return Dialog[currDialogIndex];
        }

        catch (IndexOutOfRangeException e)
        {
            FindObjectOfType<DialogSystem>().finish?.Invoke();
            return null;
        }
    }

    public string GetQuestion()
    {
        return question;
    }

    public Dialog GetCurrentDialog(int index)
    {
        return Dialog[index];
    }
}