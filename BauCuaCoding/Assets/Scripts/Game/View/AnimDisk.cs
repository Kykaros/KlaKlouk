using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDisk : GameElement
{
    [SerializeField] private GameObject Disk;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float TimeDuration;

    private bool isShaking = false;

    //private bool IsShaking { get => isShaking; set => isShaking = value; }

    private IEnumerator animShakeDisk()
    {
        app.Notify(DefineNotification.ISSHAKING, this);//prevent player open bowl before it stop shake
        iTween.ShakePosition(Disk, new Vector3(x, y, 0), TimeDuration);
        yield return new WaitForSeconds(TimeDuration);
        app.Notify(DefineNotification.STOPSHAKING, this);
    }
    public void ShakeDisk()
    {
        StartCoroutine(animShakeDisk());
    }

    private Animator _Animator = null;

    private void Start()
    {
        _Animator = this.gameObject.GetComponent<Animator>();
    }

    //TODO: Move this logic to another file contain logic events
    public void OpenDisk()
    {
        if (app.GController.Ctr_IsShake())
            return;

        _Animator.SetBool("CloseBowl", false);
        _Animator.SetBool("OpenBowl", true);
        //Make results data
        app.Notify(DefineNotification.MAKERESULT, this);
        //Check Win or close
        /*if win, add chips*/
        if (app.GController.Ctr_CheckWin())
        {
            app.Notify(DefineNotification.TRIGGEREVENTSPOT, this);
            //add chips
            ulong prize = app.GController.Ctr_Prize();
            app.GController.Ctr_AddChip(prize);
            //Player take chips win
            app.Notify(DefineNotification.PLAYERTAKECHIP, this);
            //Player take pay chips from dealer
            app.Notify(DefineNotification.PAYCHIP2PLAYER, this);
            //Event win
            app.Notify(DefineNotification.WINEVENT, this);
        }
        else 
        {
            if (app.GController.Ctr_CheckMoney())
            {
                app.Notify(DefineNotification.KICKPLAYER, this);
                return;
            }
            app.Notify(DefineNotification.CLOSEEVENT, this);
        }
        //Dealer take chips remain
        app.Notify(DefineNotification.DEALERTAKECHIP, this);
        //Support for algorithm
        app.Notify(DefineNotification.TOTALCHIPBET, this);
        app.Notify(DefineNotification.SAVECHIP, this);
    }

    //Call from animation even
    public void OpenDiskDone()
    {
        isShaking = false;
        app.Notify(DefineNotification.STOPBETTING, this);
    }

    //Call from animation even
    public void ShowResultOnBoard()
    {
        app.Notify(DefineNotification.SHOWRESULT, this);
    }

    public void CloseDiskAndShake()
    {
        if(isShaking == false)
        {
            _Animator.SetBool("OpenBowl", false);
            _Animator.SetBool("CloseBowl", true);
            isShaking = true;
        }
    }
}
