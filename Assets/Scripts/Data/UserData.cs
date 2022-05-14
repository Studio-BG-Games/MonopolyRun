using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{
    public string playerName;
    public int coins;
    public List<string> boughtBuildings;

    public UserData()
    {
        playerName = "MMM";
        coins = 10000;
        boughtBuildings = new List<string>();
    }
}
