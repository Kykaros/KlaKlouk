using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : GameElement
{
    [SerializeField] private GameObject frame;
    [SerializeField] private GameObject _ObjWin;
    [SerializeField] private GameObject _ObjClose;
    [SerializeField] private Animator _animaKick;

    private IEnumerator WinEvent()
    {
        //wait anim dealer get or pay money
        yield return new WaitForSeconds(3.0f);
        //enable black frame
        frame.SetActive(true);
        _ObjWin.SetActive(true);
        //show win event
        iTween.ScaleFrom(_ObjWin, new Vector3(0, 0, 0),1f);
    }

    private IEnumerator CloseEvent()
    {
        //wait anim dealer get or pay money
        yield return new WaitForSeconds(2.0f);
        //enable black frame
        frame.SetActive(true);
        _ObjClose.SetActive(true);
        //show close event
        iTween.ScaleFrom(_ObjClose, new Vector3(0, 0, 0), 1f);
    }

    private IEnumerator KickEvent()
    {
        yield return new WaitForSeconds(3.0f);
        //enable black frame
        frame.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        //run anim kick player
        _animaKick.SetBool("IsKick", true);
    }

    public void Win()
    {
        Debug.Log("Win !!!");
        StartCoroutine(WinEvent());
    }
    public void Close()
    {
        Debug.Log("Close !!!");
        StartCoroutine(CloseEvent());
    }

    public void KickPlayer()
    {
        Debug.Log("kick player !!!");
        StartCoroutine(KickEvent());
    }

    public void TurnOffFrame()
    {
        //disable win event
        ResetWinEvent();
        //disable close event
        ResetCloseEvent();
        //disable black frame
        frame.SetActive(false);
    }

    public void ResetWinEvent()
    {
        _ObjWin.SetActive(false);
    }

    public void ResetCloseEvent()
    {
        _ObjClose.SetActive(false);
    }

    //public void ResetKickEvent()
    //{
    //    _animatorKick.SetBool("IsKick", false);
    //}

    //private void Awake()
    //{
    //    ResetKickEvent();
    //}
}
