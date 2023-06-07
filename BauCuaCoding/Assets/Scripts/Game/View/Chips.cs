using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Chips : GameElement
{
    [SerializeField] private List<GameObject> _Chips = new List<GameObject>();
    [SerializeField] private List<Button> _BtnChips = new List<Button>();
    
    private List<ulong> _Cost = new List<ulong>() { 10000,20000,50000,100000,200000,500000};
    
    [SerializeField] private GameObject _UserPosition;
    [SerializeField] private GameObject _DealerPosition;
    [SerializeField] private float TimeRotate;
    [SerializeField] private float TimeMove;
    [SerializeField] private int MinCycleRotate;
    [SerializeField] private int MaxCycleRotate;
    private int _CurrentCost = -1;
    private int _LastCost = -1;
    [SerializeField] private iTween.EaseType _itweenType;
    public int MaxBets;

    //for chips object
    private List<GameObject> _chip_Isd_ID_0 = new List<GameObject>();
    private List<GameObject> _chip_Isd_ID_1 = new List<GameObject>();
    private List<GameObject> _chip_Isd_ID_2 = new List<GameObject>();
    private List<GameObject> _chip_Isd_ID_3 = new List<GameObject>();
    private List<GameObject> _chip_Isd_ID_4 = new List<GameObject>();
    private List<GameObject> _chip_Isd_ID_5 = new List<GameObject>();

    //for index chips number
    private List<int> _chip_Pay2_Player_0 = new List<int>();
    private List<int> _chip_Pay2_Player_1 = new List<int>();
    private List<int> _chip_Pay2_Player_2 = new List<int>();
    private List<int> _chip_Pay2_Player_3 = new List<int>();
    private List<int> _chip_Pay2_Player_4 = new List<int>();
    private List<int> _chip_Pay2_Player_5 = new List<int>();

    //list for collecting all chips for dealer
    private List<int> _idWins = new List<int>();

    private int SortingOrther = 0;

    public void btnChoiceChip(int idxcost)
    {
        _LastCost = _CurrentCost;
        _CurrentCost = idxcost;
        _BtnChips[idxcost].GetComponent<Image>().color = Color.gray;
        Debug.Log("Current cost:" + _CurrentCost);
    }

    public void btnTurnBackColor(int idxcost)
    {
        if(_LastCost != idxcost)
            _BtnChips[_LastCost].GetComponent<Image>().color = Color.white;
    }

    public ulong GetCurrentCost()
    {
        return _Cost[_CurrentCost];
    }

    private void FilterChips(GameObject _chip,int _id)
    {
        switch(_id)
        {
            case 0:
                _chip_Isd_ID_0.Add(_chip);
                break;
            case 1:
                _chip_Isd_ID_1.Add(_chip);
                break;
            case 2:
                _chip_Isd_ID_2.Add(_chip);
                break;
            case 3:
                _chip_Isd_ID_3.Add(_chip);
                break;
            case 4:
                _chip_Isd_ID_4.Add(_chip);
                break;
            case 5:
                _chip_Isd_ID_5.Add(_chip);
                break;
            default:
                Debug.LogError("[Chips][FilterChips]: Id "+ _id +" not match !");
                return;
        }
    }

    private void filterChipNumber(int Idx_Chip,int ID_Mascot)
    {
        switch (ID_Mascot)
        {
            case 0:
                _chip_Pay2_Player_0.Add(Idx_Chip);
                break;
            case 1:
                _chip_Pay2_Player_1.Add(Idx_Chip);
                break;
            case 2:
                _chip_Pay2_Player_2.Add(Idx_Chip);
                break;
            case 3:
                _chip_Pay2_Player_3.Add(Idx_Chip);
                break;
            case 4:
                _chip_Pay2_Player_4.Add(Idx_Chip);
                break;
            case 5:
                _chip_Pay2_Player_5.Add(Idx_Chip);
                break;
            default:
                Debug.LogError("[Chips][FilterChips]: Id " + ID_Mascot + " not match !");
                return;
        }
    }

    public void Move_Chip_To_Obj(GameObject Target,int ID)
    {
        if (_CurrentCost < 0 || _CurrentCost > 6)
            Debug.LogError("Current cost out of range !");
        Vector3 usePos = _UserPosition.transform.position;
        GameObject chip = Instantiate(_Chips[_CurrentCost], usePos, Quaternion.identity);
        //filter chips object
        FilterChips(chip,ID);
        //filter chips number
        filterChipNumber(_CurrentCost,ID);
        //Set order in player
        chip.GetComponent<SpriteRenderer>().sortingOrder = SortingOrther;
        SortingOrther++;
        Vector3 _Pos = new Vector3(Target.transform.position.x+Random.Range(-0.4f,0.4f), Target.transform.position.y+Random.Range(-0.4f,0.4f), 0);
        iTween.MoveTo(chip, _Pos, TimeMove);
        int CycleRotate = Random.Range(MinCycleRotate, MaxCycleRotate);
        iTween.RotateTo(chip, iTween.Hash("rotation", new Vector3(0, 0, CycleRotate*Random.Range(1,340)), "time", TimeRotate, "easetype", _itweenType)); ;
    }

    public void MoveChip2Player(int _idWin)
    {
        Vector3 usePos = _UserPosition.transform.position;
        List<GameObject> chips = new List<GameObject>();
        switch(_idWin)
        {
            case 0:
                chips = _chip_Isd_ID_0;
                break;
            case 1:
                chips = _chip_Isd_ID_1;
                break;
            case 2:
                chips = _chip_Isd_ID_2;
                break;
            case 3:
                chips = _chip_Isd_ID_3;
                break;
            case 4:
                chips = _chip_Isd_ID_4;
                break;
            case 5:
                chips = _chip_Isd_ID_5;
                break;
            default:
                Debug.LogError("[chips][MoveChip2Player]: ID win " + _idWin + "not match !");
                return;
        }

        _idWins.Add(_idWin);
        
        foreach(GameObject chip in chips)
        {
            iTween.MoveTo(chip, usePos, TimeMove);
        }
    }

    public void MoveChip2Dealer()
    {
        Vector3 dealerPos = _DealerPosition.transform.position;
        List<GameObject> chips = new List<GameObject>();
        for(int idx = 0;idx < 6;idx++)
        {
            if (_idWins.Contains(idx))
                continue;
            
            switch (idx)
            {
                case 0:
                    chips = _chip_Isd_ID_0;
                    break;
                case 1:
                    chips = _chip_Isd_ID_1;
                    break;
                case 2:
                    chips = _chip_Isd_ID_2;
                    break;
                case 3:
                    chips = _chip_Isd_ID_3;
                    break;
                case 4:
                    chips = _chip_Isd_ID_4;
                    break;
                case 5:
                    chips = _chip_Isd_ID_5;
                    break;
                default:
                    Debug.LogError("[chips][MoveChip2Player]: ID win " + idx + "not match !");
                    return;
            }

            foreach (GameObject chip in chips)
            {
                iTween.MoveTo(chip, dealerPos, TimeMove);
            }
        }
    }

    private IEnumerator AnimPayChip()
    {
        Vector3 DealerPos = _DealerPosition.transform.position;
        Vector3 UserPos = _UserPosition.transform.position;
        List<GameObject> chips = new List<GameObject>();//chips pay to player
        List<int> idx_Cost_2_Pay = new List<int>();
        
        for(int idx=0;idx<6;idx++)
        {
            if (!_idWins.Contains(idx))
                continue;
            switch(idx)
            {
                case 0:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_0);
                    break;
                case 1:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_1);
                    break;
                case 2:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_2);
                    break;
                case 3:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_3);
                    break;
                case 4:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_4);
                    break;
                case 5:
                    idx_Cost_2_Pay.AddRange(_chip_Pay2_Player_5);
                    break;
                default:
                    Debug.LogError("[chips][AnimPayChip]: idx " + idx + " not match !");
                    break;
            }
        }
        yield return new WaitForSeconds(1f);
        //make chips object
        foreach (int idx_cost in idx_Cost_2_Pay)
        {
            chips.Add(Instantiate(_Chips[idx_cost], DealerPos, Quaternion.identity));
        }
        //move chip to player
        foreach (GameObject chip in chips)
        {
            iTween.MoveTo(chip, UserPos, TimeMove);
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void PayChip2Player()
    {
        StartCoroutine(AnimPayChip());
    }

    public void CleanChips()
    {
        var Chips = GameObject.FindGameObjectsWithTag("Chip");
        foreach(GameObject chip in Chips)
        {
            Destroy(chip);
        }
        //reset sorting other
        SortingOrther = 0;
        //clear array chips for each mascot
        _chip_Isd_ID_0.Clear();
        _chip_Isd_ID_1.Clear();
        _chip_Isd_ID_2.Clear();
        _chip_Isd_ID_3.Clear();
        _chip_Isd_ID_4.Clear();
        _chip_Isd_ID_5.Clear();

        //clean ID mascot win
        _idWins.Clear();

        //clean idx cost
        _chip_Pay2_Player_0.Clear();
        _chip_Pay2_Player_1.Clear();
        _chip_Pay2_Player_2.Clear();
        _chip_Pay2_Player_3.Clear();
        _chip_Pay2_Player_4.Clear();
        _chip_Pay2_Player_5.Clear();
    }

    private void Start()
    {
        _CurrentCost = 0;
        _LastCost = 0;
        _BtnChips[_CurrentCost].GetComponent<Image>().color = Color.gray;
    }
    private void OnApplicationQuit()
    {
        CleanChips();
    }
}
