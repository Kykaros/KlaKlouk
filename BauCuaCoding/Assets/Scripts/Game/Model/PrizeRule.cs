using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PrizeConfig", menuName = "Create/PrizeConfig", order = 1)]
public class PrizeRule : ScriptableObject
{
    //Normal Prize
    [SerializeField] private int NormalPrize = 0;
}
