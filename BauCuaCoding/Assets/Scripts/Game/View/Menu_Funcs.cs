using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Funcs : MonoBehaviour
{
    public void Load_GamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Back2Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void CommingSoon()
    {
        SceneManager.LoadScene("ComingSoon");
    }
}
