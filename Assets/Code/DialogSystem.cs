using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public delegate void Finish();

public class DialogSystem : MonoBehaviour
{
    public Finish finish;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text OptionA;
    [SerializeField] private TMP_Text OptionX;
    [SerializeField] private TMP_Text OptionY;
    [SerializeField] private TMP_Text OptionB;
    [SerializeField] private Conversation firtsConversation;
    [SerializeField] private List<Conversation> conversations;
    private bool _currDialogFinish;
    private bool _textHasOption;


    /*private void Start()
    {
        _finish += Finish;
        NextDialog(dialogs);
    }

    private void Update()
    {
        if (_textHasOption)
        {
            foreach (var option in _currDialog.option)
            {
                if (option != null && Input.GetButton(option.ButtonName))
                {
                    NextDialog(option.dialog);
                    _textHasOption = false;
                }
            }

            return;
        }

        if (_currDialogFinish && Input.GetButtonDown("Jump"))
        {
            text.text = "";
            NextDialog(_currDialog.nextDialog);
            _currDialogFinish = false;
        }
    }


    private void Finish()
    {
        if (_currDialog != null)
            _currDialogFinish = true;
    }

    private void NextDialog(Dialog nextDialogName)
    {
        if (nextDialogName == null)
        {
            Debug.Log("No More Dialog");
            Finish();
            return;
        }
        _currDialog = nextDialogName;
        if (nextDialogName.option.Any())
        {
            _textHasOption = true;
        }

        DisplayDialog(nextDialogName.text);
    }*/

    private void DisplayDialog(string dialog)
    {
        StartCoroutine(Type(dialog, 0.2f));
    }

    private IEnumerator Type(string dialog, float typeSpeed)
    {
        foreach (var letter in dialog)
        {
            yield return new WaitForSeconds(typeSpeed);
            text.text += letter;
        }

        finish?.Invoke();
    }
}