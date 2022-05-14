using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour, IPicker
{
    public void CollectBuilbings(string name,int cost)
    {
        SaveSystem.ToBuyBuilding(name, cost);
    }

    public void CollectMoney(int incom)
    {
        SaveSystem.ToCollectMoney(incom);
    }
}
