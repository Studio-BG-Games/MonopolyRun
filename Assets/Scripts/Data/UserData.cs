using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{
    public string playerName;
    public int coins;
    public Dictionary<string, string> boughtBuildings;

    public UserData()
    {
        playerName = "MMM";
        coins = 10000;
        boughtBuildings = new Dictionary<string, string>();
    }
}
