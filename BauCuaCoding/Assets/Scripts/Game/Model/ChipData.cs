using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipData : GameElement
{
    private ulong chip = 0;

    private ulong ChipAtTurn = 0;

    private Dictionary<int, ulong> ChipEMascots = new Dictionary<int, ulong>()
    {
        {0,0},{1,0},{2,0},{3,0},{4,0},{5,0}
    };

    public void ResetChipEMascots()
    {
        ChipEMascots[0] = 0;
        ChipEMascots[1] = 0;
        ChipEMascots[2] = 0;
        ChipEMascots[3] = 0;
        ChipEMascots[4] = 0;
        ChipEMascots[5] = 0;
    }

    public void AddChipForMascot(int MasID,ulong value)
    {
        if (!ChipEMascots.ContainsKey(MasID))
        {
            Debug.LogError("[ChipData][AddChipForMascot]: MasID not found !");
            return;
        }

        if (ChipEMascots.TryGetValue(MasID, out ulong chip))
        {
            ChipEMascots[MasID] = value + chip;
        }
        else Debug.LogError("[Board][Board][BtnChoiceAct]: Error occur while get chip value each mascot !");
    }

    private ulong GetECMBet(int MascotID)
    {
        if (!ChipEMascots.ContainsKey(MascotID))
            Debug.LogError("[Chipdata][GetECMBet]: Mascot ID not exits " + MascotID);

        return ChipEMascots[MascotID];
    }

    private List<int> IDPast = new List<int>();
    private ulong GetBetOneTime(int MascotID)
    {
        if (!ChipEMascots.ContainsKey(MascotID))
            Debug.LogError("[Chipdata][GetECMBet]: Mascot ID not exits " + MascotID);

        if (!IDPast.Contains(MascotID))
        {
            IDPast.Add(MascotID);
            return ChipEMascots[MascotID];
        }

        return 0;
    }

    public ulong CalculatePrize(int D1,int D2,int D3)
    {
        //

        //Dealer have to pay to player
        ulong ChipWin_1 = GetECMBet(D1);
        ulong ChipWin_2 = GetECMBet(D2);
        ulong ChipWin_3 = GetECMBet(D3);
        
        //return bet to player
        ulong ChipBet_1 = GetBetOneTime(D1);
        ulong ChipBet_2 = GetBetOneTime(D2);
        ulong ChipBet_3 = GetBetOneTime(D3);

        ulong ChipWin = ChipWin_1 + ChipWin_2 + ChipWin_3;
        ulong ChipBet = ChipBet_1 + ChipBet_2 + ChipBet_3;

        Debug.Log("[ChipWin]:" + ChipWin);
        Debug.Log("[ChipBet]:" + ChipBet);
        Debug.Log("[Total]:" + (ChipWin + ChipBet).ToString());
        IDPast.Clear();

        return ChipWin + ChipBet;
    }

    public void SetChipAtTurn()
    {
        ChipAtTurn = chip;
    }
    public ulong CurrentChip()
    {
        return chip;
    }
    public void Add(ulong value)
    {
        chip += value;
    }

    public void Sub(ulong value)
    {
        if (chip < value)
            chip = 0;
        else chip -= value;
    }
    public void Mul(ulong value,int mul)
    {
        chip += ((ulong)mul * value);
    }

    public ulong TotalBetting()
    {
        return ChipAtTurn - chip;
    }
    public void Save()
    {
        PlayerPrefs.SetString("PlayerChip", chip.ToString());
        //PlayerPrefs.Save();
    }
    private ulong Load()
    {
        ulong result;
        if (!ulong.TryParse(PlayerPrefs.GetString("PlayerChip"), out result))
        {
            Debug.LogError("[ChipData][Load]: Loading chip error !");
            result = 10000000;
        }
        return result;
    }

    private void Awake()
    {
        chip = Load();
    }
}
