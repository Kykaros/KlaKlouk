using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Functions
{
    public static int RandomMascot()
    {
        return Random.Range(0, 6);
    }

    public static int GetResultDice(int numberDice,Dictionary<string, int> resultdata)
    {
        if (resultdata.Count < 3)
            //Raise error !
            Debug.LogError("[Functions][GetResultDice] size data result wrong !, size:" + resultdata.Count.ToString());
        if (numberDice < 0 || numberDice > 2)
            //Raise error !
            Debug.LogError("[Functions][GetResultDice] number dice out of range !, index:" + numberDice.ToString());
        
        List<string> DefineDiceKey = new List<string>() { "D1", "D2", "D3" };
        
        if(!resultdata.ContainsKey(DefineDiceKey[numberDice]))
            //Raise error !
            Debug.LogError("[Functions][GetResultDice] Dice doesn't exit in data result !, key:" + DefineDiceKey[numberDice]);

        return resultdata[DefineDiceKey[numberDice]];
    }
    public static bool CheckResultInChoice(int mascotID,List<int> choices)
    {
        if (choices.Count <= 0)
            Debug.LogError("[Functions][CheckResultInChoice] Player no choice !, size choice data error:" + choices.Count);

        if (choices.Contains(mascotID))
            return true;
        return false;
    }
}
