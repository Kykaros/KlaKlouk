using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : GameElement
{
    private List<GameObject> MascotBtn = new List<GameObject>();

    private int CountBet = 1;
    private void Start()
    {
        MascotBtn.Add(this.gameObject.transform.GetChild(0).gameObject);//Nai
        MascotBtn.Add(this.gameObject.transform.GetChild(1).gameObject);//Bau
        MascotBtn.Add(this.gameObject.transform.GetChild(4).gameObject);//Ca
        MascotBtn.Add(this.gameObject.transform.GetChild(5).gameObject);//Cua
        MascotBtn.Add(this.gameObject.transform.GetChild(2).gameObject);//Ga
        MascotBtn.Add(this.gameObject.transform.GetChild(3).gameObject);//Tom
    }

    private void ChangeChoiceColor(GameObject Obj)
    {
        Obj.GetComponent<Image>().color = Color.yellow;
    }

    private void ChangeResultColor(GameObject Obj)
    {
        Obj.GetComponent<Image>().color = Color.green;
    }

    public void ResetColorbtn()
    {
        foreach(GameObject item in MascotBtn)
        {
            item.GetComponent<Image>().color = Color.white;
        }
    }

    private void btnShake()
    {
        if(app.GController.Ctr_CheckBettingState() == false)
        {
            //TODO: move it to another file contain logic game
            //reset color
            ResetColorbtn();
            //change state to be betting
            app.Notify(DefineNotification.ISBETTING, this);
            //clean chips
            app.GView.Chip.CleanChips();
            //reset number beting
            app.GView.board.Reset();
            //clean data
            app.GController.Ctr_ResetData();
            //reset prize
            app.GController.CTR_ResetChipData();
        }
        //logic for show result
        if (app.GController.Ctr_CheckStateGame() == true)
            app.Notify(DefineNotification.STARTEDGAME,this);
        app.GView.AnDisk.CloseDiskAndShake();
    }

    private bool CheckMaxBet()
    {
        if (CountBet > app.GView.Chip.MaxBets && app.GController.Ctr_CheckBettingState())
            return true;
        return false;
    }

    private void BtnChoiceAct(int MascotID)
    {
        if(app.GController.Ctr_CheckMoney())
        {
            Debug.LogWarning("[Board][BtnChoiceAct]: No Money !");
            return;
        }

        if (CheckMaxBet())
        {
            Debug.LogWarning("[Board][BtnChoiceAct]: Number betting is Maximum !");
            return;
        }

        //Trigger shake disk
        btnShake();
        ChangeChoiceColor(MascotBtn[MascotID]);

        if (CountBet <= 1)
            //Save chip at this turn
            app.Notify(DefineNotification.SAVECHIPATTURN, this);
        //Animate for chip
        GameObject Target = MascotBtn[MascotID].transform.GetChild(0).gameObject;
        app.GView.Chip.Move_Chip_To_Obj(Target, MascotID);
        //Sub Chip
        ulong BetMoney = app.GView.Chip.GetCurrentCost();
        app.GController.Ctr_SubChip(BetMoney);
        //Chips each Mascot
        app.GController.Ctr_AddChipEMas(MascotID, BetMoney);
        /*Logic Game*/
        app.GController.Ctr_ChooseMascot(MascotID);
        /*Code Here*/
        CountBet++;
    }

    //MascotID: 0
    public void btnChoiceNai()
    {
        BtnChoiceAct(0);
    }
    //MascotID: 1
    public void btnChoiceBau()
    {
        BtnChoiceAct(1);
    }
    //MascotID: 4
    public void btnChoiceGa()
    {
        BtnChoiceAct(4);
    }
    //MascotID: 5
    public void btnChoiceTom()
    {
        BtnChoiceAct(5);
    }
    //MascotID: 2
    public void btnChoiceCa()
    {
        BtnChoiceAct(2);
    }
    //MascotID: 3
    public void btnChoiceCua()
    {
        BtnChoiceAct(3);
    }
    //Display Result
    public void ChangeGreenColor_Mascot(int idx)
    {
        ChangeResultColor(MascotBtn[idx]);
    }

    public void Reset()
    {
        CountBet = 1;
    }
}
