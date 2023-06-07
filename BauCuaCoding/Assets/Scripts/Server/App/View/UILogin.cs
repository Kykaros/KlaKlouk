using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : AppElement
{
    public InputField ObjUserName;
    public InputField ObjPassWord;
    public void SetUserName()
    {
        //Ser_App.Ser_Controller;
        Debug.Log(ObjUserName.text);
    }

    public void SetPassWord()
    {

    }
}
