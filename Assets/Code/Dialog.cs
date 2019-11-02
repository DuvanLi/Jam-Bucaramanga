
using System.Globalization;
using UnityEngine;

public class Dialog: MonoBehaviour
{
    public new string name;
    [TextArea]public string text;
    public Dialog nextDialog;
    
    [Space]
   public Option[] option;
}