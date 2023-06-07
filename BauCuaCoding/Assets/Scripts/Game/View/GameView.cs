using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : GameElement
{
    public UI_Dice UIDice;
    public AnimDisk AnDisk;
    public Board board;
    public Chips Chip;
    public UI_Chip UIChip;
    public PotCoins potCoins;
    public Events events;

    private void Start()
    {
        app.Notify(DefineNotification.INITGAMESTATE,this);
    }
}
