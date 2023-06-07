using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicGame : GameElement
{
    //for Console Log
    List<string> Mascot = new List<string>() { "Nai", "Bau", "Ca", "Cua", "Ga", "Tom" };
    public Dictionary<string,int> MakeResults()
    {
        int Result_Dice1 = -1;
        int Result_Dice2 = -1;
        int Result_Dice3 = -1;
        Result_Dice1 = Functions.RandomMascot();
        Result_Dice2 = Functions.RandomMascot();
        Result_Dice3 = Functions.RandomMascot();
        if (Result_Dice1 == -1 || Result_Dice2 == -1 || Result_Dice3 == -1)
        {
            Debug.LogError("Function RandomMascot() Error not detected !");
            return null;
        }

        Debug.Log("Dice 1: " + Mascot[Result_Dice1]);
        Debug.Log("Dice 2: " + Mascot[Result_Dice2]);
        Debug.Log("Dice 3: " + Mascot[Result_Dice3]);

        //store data in data object
        app.GModel.data.DataDice_1 = Result_Dice1;
        app.GModel.data.DataDice_2 = Result_Dice2;
        app.GModel.data.DataDice_3 = Result_Dice3;

        Dictionary<string, int> Results = new Dictionary<string, int>();
        Results.Add("D1", Result_Dice1);
        Results.Add("D2", Result_Dice2);
        Results.Add("D3", Result_Dice3);

        return Results;
    }

    public bool IsWin()
    {
        int D1 = app.GModel.data.DataDice_1;
        int D2 = app.GModel.data.DataDice_2;
        int D3 = app.GModel.data.DataDice_3;
        List<int> Temp = new List<int>();
        Temp.Add(D1);
        Temp.Add(D2);
        Temp.Add(D3);

        List<int> choices = app.GModel.data.GetPlayerChoice();

        int count = 0;
        foreach(int item in Temp)
        {
            if (Functions.CheckResultInChoice(item, choices))
                count++;
        }

        app.GModel.data.CountMascotWin = count;
        if (count == 0)
            return false;
        return true;
    }

    public bool ChkCanCnt()
    {
        //kick player
        if (app.GModel.chipdata.CurrentChip() < 10000)
            return true;
        return false;
    }

    public void ChooseMascot(int MascotID)
    {
        if(!app.GModel.data.GetPlayerChoice().Contains(MascotID))
            app.GModel.data.AddPlayerChoice(MascotID);
    }
}
