using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour, IPicker
{
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
}
