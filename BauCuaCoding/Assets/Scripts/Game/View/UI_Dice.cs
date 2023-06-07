using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dice : GameElement
{
    [SerializeField] private Image Dice_1;
    [SerializeField] private Image Dice_2;
    [SerializeField] private Image Dice_3;

    public List<Sprite> AllFace;
    public void DisplayDice1(int IdxDice)
    {
        Dice_1.sprite = AllFace[IdxDice];
    }

    public void DisplayDice2(int IdxDice)
    {
        Dice_2.sprite = AllFace[IdxDice];
    }

    public void DisplayDice3(int IdxDice)
    {
        Dice_3.sprite = AllFace[IdxDice];
    }
}
