using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Chip : GameElement
{
    public Text Money;

    private void Start()
    {
        Money.text = app.GController.Ctr_LoadChip().ToString();
    }

    //Controller call this function
    public void IncreaseMoney(ulong Current,ulong Inc_value)
    {
        //TODO: animation logic
        ulong Result = Current + Inc_value;
        Money.text = Result.ToString();
    }
    //Controller call this function
    public void DecreaseMoney(ulong Current, ulong Decr_value)
    {
        //TODO: animation logic
        if(Current < Decr_value)
        {
            Money.text = "0";
        }
        else
        {
            ulong Result = Current - Decr_value;
            Money.text = Result.ToString();
        }
    }
}
