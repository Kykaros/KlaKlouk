using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public GameApp app
    {
        get
        {
            return GameObject.FindObjectOfType<GameApp>();
        }
    }
}
