using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ErrorID
{
    Err01
    ,Err02
    ,Err03
    ,Err04
    ,Err05
}

public class ManagerErr
{
    Dictionary<ErrorID, string> MessageError = new Dictionary<ErrorID, string>();

    //Define message here
}
