using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobby : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Start()
    {
        _anim.SetBool("IsExit", false);
    }
    
    public void CancelExit()
    {
        _anim.SetBool("IsExit", false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            _anim.SetBool("IsExit", true);
        }
    }
}
