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
    [SerializeField] private Conversation firtsConversation;
    [SerializeField] private Option OptionA;
    [SerializeField] private Option OptionB;
    [SerializeField] private Option OptionX;
    [SerializeField] private Option OptionY;
    private Conversation _currConversation;
    private bool _currDialogFinish;
    private bool _conversationFinish;
    private bool _textHasOption;
    private bool _wait;


    private void Start()
    {
        finish += ConversationEnd;
        InitConversation(firtsConversation);
        OptionA.OptionText.text = "";
        OptionB.OptionText.text = "";
        OptionX.OptionText.text = "";
        OptionY.OptionText.text = "";
    }

    private void Update()
    {
        if (!_wait)
        {
            if (_currDialogFinish && !_conversationFinish)
            {
                if (Input.GetButtonDown("Button_A"))
                {
                    NextConversation();
                    _currDialogFinish = false;
                }
            }

            if (!_conversationFinish) return;
          

            if (Input.GetButtonDown(OptionA.ButtonName))
            {
                InitConversation(OptionA.conversation);
                _currDialogFinish = false;
            }
            else if (Input.GetButtonDown(OptionB.ButtonName))
            {
                _currDialogFinish = false;
                gameObject.SetActive(false); 
            }
            else if (Input.GetButtonDown(OptionX.ButtonName))
            {
                InitConversation(OptionX.conversation);

                _currDialogFinish = false;
            }
            else if (Input.GetButtonDown(OptionY.ButtonName))
            {
                InitConversation(OptionY.conversation);

                _currDialogFinish = false;
            }
        }
      
    }

    private void ConversationEnd()
    {
        StartCoroutine(Wait());
        _currDialogFinish = false;

    }

    private void NextConversation()
    {

        NextDialog(_currConversation.GetCurrentDialog());
        _currConversation.NextDialog();
    }

    private void InitConversation(Conversation conversation)
    {
        if (conversation.GetCurrentDialog() == null) return;
        NextDialog(conversation.GetCurrentDialog());
        conversation.NextDialog();
        _currConversation = conversation;
    }

    private void NextDialog(Dialog nextDialogName)
    {
        if (nextDialogName != null)
            DisplayDialog(nextDialogName.text);
    }

    private void DisplayDialog(string dialog)
    {
        StartCoroutine(Type(dialog, 0.2f));
    }

    private IEnumerator Wait()
    {
        _wait = true;
        OptionA.OptionText.text = OptionA.conversation.question;
        OptionB.OptionText.text = OptionB.conversation.question;
        OptionX.OptionText.text = OptionX.conversation.question;
        OptionY.OptionText.text = OptionY.conversation.question;
        yield return new WaitForSeconds(3f);
        _currDialogFinish = true;
        _conversationFinish = true;

        _wait = false;
    }
    
    private IEnumerator Type(string dialog, float typeSpeed)
    {
        text.text = "";
        foreach (var letter in dialog)
        {
            yield return new WaitForSeconds(typeSpeed);
            text.text += letter;
        }

        _currDialogFinish = true;
    }
}