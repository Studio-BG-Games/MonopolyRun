using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour, IPicker
{
    public Action OnDown;
    public Action<int> OnChangeBoundary;
    public void CollectBuilbings(string complexName, string name,int cost)
    {
        SaveSystem.ToBuyBuilding(complexName ,name, cost);
    }

    public void CollectMoney(int incom)
    {
        SaveSystem.ToCollectMoney(incom);
    }

    public void LooseMoney(int loss)
    {
        SaveSystem.ToLooseMoney(loss);
    }

    public void UseMetro(Transform metroOut,int boundaryNumber)
    {
        StartCoroutine(ToUseMetro(metroOut, boundaryNumber));
    }
    private IEnumerator ToUseMetro(Transform metroOut, int boundaryNumber)
    {
        OnDown?.Invoke(); 
        yield return new WaitForSeconds(1f);

        OnChangeBoundary?.Invoke(boundaryNumber);
        this.gameObject.transform.position = metroOut.position;
        this.gameObject.transform.rotation = metroOut.transform.rotation;
    }
}
