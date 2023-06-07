using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : GameElement
{
    private bool isBetting = false;
    public bool IsBetting { get => isBetting; set => isBetting = value; }

    private bool isShaking = false;
    public bool IsShaking { get => isShaking; set => isShaking = value; }

    private int dataDice_1 = -1;
    private int dataDice_2 = -1;
    private int dataDice_3 = -1;

    public int DataDice_1 { get => dataDice_1; set => dataDice_1 = value; }
    public int DataDice_2 { get => dataDice_2; set => dataDice_2 = value; }
    public int DataDice_3 { get => dataDice_3; set => dataDice_3 = value; }

    private bool isFirstFrame = true;
    public bool IsFirstFrame { get => isFirstFrame; set => isFirstFrame = value; }

    private List<int> PlayerChoice = new List<int>();
    public void AddPlayerChoice(int value)
    {
        PlayerChoice.Add(value);
    }
    public void CleanPlayerChoice()
    {
        PlayerChoice.Clear();
    }
    public List<int> GetPlayerChoice()
    {
        return PlayerChoice;
    }

    private int countMascotWin = 0;
    public int CountMascotWin { get => countMascotWin; set => countMascotWin = value; }
}
