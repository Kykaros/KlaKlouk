using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : GameElement
{

    private void Ctr_MakeResults()
    {
        Dictionary<string, int> Result = app.GModel.logicgame.MakeResults();
        int Result_Dice1 = Functions.GetResultDice((int)Defines.NumbDice.DICE1, Result);
        int Result_Dice2 = Functions.GetResultDice((int)Defines.NumbDice.DICE2, Result);
        int Result_Dice3 = Functions.GetResultDice((int)Defines.NumbDice.DICE3, Result);
        
        app.GView.UIDice.DisplayDice1(Result_Dice1);
        app.GView.UIDice.DisplayDice2(Result_Dice2);
        app.GView.UIDice.DisplayDice3(Result_Dice3);

    }

    private void Ctr_ShowResult()
    {
        if (app.GModel.data.IsFirstFrame == true)
            return;
        app.GView.board.ChangeGreenColor_Mascot(app.GModel.data.DataDice_1);
        app.GView.board.ChangeGreenColor_Mascot(app.GModel.data.DataDice_2);
        app.GView.board.ChangeGreenColor_Mascot(app.GModel.data.DataDice_3);
    }

    private void Ctr_IsBetting()
    {
        app.GModel.data.IsBetting = true;
    }

    private void Ctr_StopBetting()
    {
        app.GModel.data.IsBetting = false;
    }

    private void Ctr_IsShaking()
    {
        app.GModel.data.IsShaking = true;
    }

    private void Ctr_StopShaking()
    {
        app.GModel.data.IsShaking = false;
    }

    public bool Ctr_IsShake()
    {
        return app.GModel.data.IsShaking;
    }

    public bool Ctr_CheckBettingState()
    {
        return app.GModel.data.IsBetting;
    }

    private void Ctr_InitGameSate()
    {
        app.GModel.data.IsFirstFrame = true;
    }

    private void Ctr_StartedGame()
    {
        app.GModel.data.IsFirstFrame = false;
    }
    public bool Ctr_CheckStateGame()
    {
        return app.GModel.data.IsFirstFrame;
    }
    public ulong Ctr_LoadChip()
    {
        return app.GModel.chipdata.CurrentChip();
    }
    public void Ctr_SaveChip()
    {
        app.GModel.chipdata.Save();
    }
    public void Ctr_AddChip(ulong among)
    {
        ulong currentChip = app.GModel.chipdata.CurrentChip();
        app.GView.UIChip.IncreaseMoney(currentChip,among);
        app.GModel.chipdata.Add(among);
    }
    public void Ctr_SubChip(ulong among)
    {
        ulong currentChip = app.GModel.chipdata.CurrentChip();
        app.GView.UIChip.DecreaseMoney(currentChip, among);
        app.GModel.chipdata.Sub(among);
    }
    public bool Ctr_CheckWin()
    {
        return app.GModel.logicgame.IsWin();
    }
    public void Ctr_ChooseMascot(int MascotID)
    {
        app.GModel.logicgame.ChooseMascot(MascotID);
    }
    public void Ctr_ResetData()
    {
        app.GModel.data.CleanPlayerChoice();
    }
    public void CTR_ResetChipData()
    {
        app.GModel.chipdata.ResetChipEMascots();
    }

    private void Ctr_SaveChipAtTurn()
    {
        app.GModel.chipdata.SetChipAtTurn();
    }

    //Support for algorithm - pending
    private void Ctr_TotalChipBet()
    {
        //Debug.Log(app.GModel.chipdata.TotalBetting());
    }

    public void Ctr_AddChipEMas(int MasID,ulong value)
    {
        app.GModel.chipdata.AddChipForMascot(MasID, value);
    }

    public ulong Ctr_Prize()
    {
        int D1 = app.GModel.data.DataDice_1;
        int D2 = app.GModel.data.DataDice_2;
        int D3 = app.GModel.data.DataDice_3;

        return app.GModel.chipdata.CalculatePrize(D1, D2, D3);
    }

    public bool Ctr_CheckMoney()
    {
        return app.GModel.logicgame.ChkCanCnt();
    }

    private void Ctr_TriggerPot()
    {
        app.GView.potCoins.Trigger_EventPotCoins();
    }

    private void Ctr_WinEvent()
    {
        app.GView.events.Win();
    }

    private void Ctr_CloseEvent()
    {
        app.GView.events.Close();
    }

    private void Ctr_KickPlayer()
    {
        app.GView.events.KickPlayer();
    }

    private void Ctr_PlayerTakeChip()
    {
        int D1 = app.GModel.data.DataDice_1;
        int D2 = app.GModel.data.DataDice_2;
        int D3 = app.GModel.data.DataDice_3;
        
        app.GView.Chip.MoveChip2Player(D1);
        app.GView.Chip.MoveChip2Player(D2);
        app.GView.Chip.MoveChip2Player(D3);
    }

    private void Ctr_DealerTakeChip()
    {
        app.GView.Chip.MoveChip2Dealer();
    }

    private void Ctr_PayChip2Player()
    {
        app.GView.Chip.PayChip2Player();
    }

    public void OnNotification(string p_event_path,Object p_target,params object[] p_data)
    {
        switch(p_event_path)
        {
            case DefineNotification.MAKERESULT:
                Ctr_MakeResults();
                break;
            case DefineNotification.SHOWRESULT:
                Ctr_ShowResult();
                break;
            case DefineNotification.ISBETTING:
                Ctr_IsBetting();
                break;
            case DefineNotification.STOPBETTING:
                Ctr_StopBetting();
                break;
            case DefineNotification.INITGAMESTATE:
                Ctr_InitGameSate();
                break;
            case DefineNotification.STARTEDGAME:
                Ctr_StartedGame();
                break;
            case DefineNotification.SAVECHIP:
                Ctr_SaveChip();
                break;
            case DefineNotification.SAVECHIPATTURN:
                Ctr_SaveChipAtTurn();
                break;
            case DefineNotification.TOTALCHIPBET:
                Ctr_TotalChipBet();
                break;
            case DefineNotification.TRIGGEREVENTSPOT:
                Ctr_TriggerPot();
                break;
            case DefineNotification.WINEVENT:
                Ctr_WinEvent();
                break;
            case DefineNotification.CLOSEEVENT:
                Ctr_CloseEvent();
                break;
            case DefineNotification.KICKPLAYER:
                Ctr_KickPlayer();
                break;
            case DefineNotification.PLAYERTAKECHIP:
                Ctr_PlayerTakeChip();
                break;
            case DefineNotification.DEALERTAKECHIP:
                Ctr_DealerTakeChip();
                break;
            case DefineNotification.PAYCHIP2PLAYER:
                Ctr_PayChip2Player();
                break;
            case DefineNotification.ISSHAKING:
                Ctr_IsShaking();
                break;
            case DefineNotification.STOPSHAKING:
                Ctr_StopShaking();
                break;
            default:
                Debug.LogWarning("No case match for " + p_event_path);
                break;
        }
    }

}
