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
    public movementController controller;
    public Finish finish;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text currTalker;

    [SerializeField] private Conversation firtsConversation;
    [SerializeField] private Option OptionA;
    [SerializeField] private Option OptionX;
    [SerializeField] private Option OptionY;
    [SerializeField] private string ButtonExit;
    private Conversation _currConversation;
    private bool _currDialogFinish;
    private bool _conversationFinish;
    private bool _textHasOption;
    private bool _wait;
    private bool once;
    public Transform targetPlayerPos;

    void Awake()
    {
        this.gameObject.SetActive(  false);
    }
    void OnEnable()
    {
        controller.rb.velocity = Vector2.zero;
        controller.enabled = false;
    }
    void OnDisable()
    {
        controller.enabled = true;
    }
    private void Start()
    {
        finish += ConversationEnd;
        InitConversation(firtsConversation);
        OptionA.OptionText.text = "";
        OptionX.OptionText.text = "";
        OptionY.OptionText.text = "";
    }

    private void Update()
    {
        if (!_wait)
        {
            if (_currDialogFinish && !_conversationFinish)
            {
                if (Input.GetButtonDown(OptionA.ButtonName))
                {
                    NextConversation();
                    _currDialogFinish = false;
                }
            }

            if (!_conversationFinish) return;
            OptionA.OptionText.text = OptionA.conversation.question;
            OptionX.OptionText.text = OptionX.conversation.question;
            OptionY.OptionText.text = OptionY.conversation.question;

            if (Input.GetButtonDown(OptionA.ButtonName))
            {
                InitConversation(OptionA.conversation);
                _currDialogFinish = false;
            }
            else if (Input.GetButtonDown(ButtonExit))
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
        _wait = true;
        StartCoroutine(Wait());
        Debug.Log("Final");
        _conversationFinish = true;
        _currDialogFinish = true;
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
        {
            DisplayDialog(nextDialogName.text);
            currTalker.text = nextDialogName.name;
        }
    }

    private void DisplayDialog(string dialog)
    {
        StartCoroutine(Type(dialog, 0.05f));
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        _wait = false;
    }

    private IEnumerator Type(string dialog, float typeSpeed)
    {
        if (!once)
        {
            once = true;
            text.text = ""+"";
            foreach (var letter in dialog)
            {
                yield return new WaitForSeconds(typeSpeed);
                text.text += letter;
            }

            once = false;
            _currDialogFinish = true;
        }
    }
}