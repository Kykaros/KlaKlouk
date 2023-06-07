using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppServer : MonoBehaviour
{
    public ServerModel Ser_Model;
    public ServerController Ser_Controller;
    public ServerView Ser_View;
}

public class AppElement : MonoBehaviour
{
    public AppServer Ser_App
    {
        get
        {
            return GameObject.FindObjectOfType<AppServer>();
        }
    }
}
