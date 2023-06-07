using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotCoins : GameElement
{
    private GameObject _PotCoins = null;

    private void Start()
    {
        _PotCoins = this.gameObject;
    }

    public void Trigger_EventPotCoins()
    {
        StartCoroutine(Event_Pot_Coins());
    }

    private IEnumerator Event_Pot_Coins()
    {
        //Data config time
        yield return new WaitForSeconds(3f);
        ParticleSystem.EmissionModule _Emission = _PotCoins.GetComponent<ParticleSystem>().emission;
        _Emission.enabled = true;
        yield return new WaitForSeconds(1f);
        _Emission.enabled = false;
    }
}
