using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveSystem 
{
    public static UserData userData;

    public static Action<float> OnUpdateScore;
    public static Action<int> OnUpdateBuilds;

    public static void LoadUserData()
    {
        string usersJson = GamePlayerPrefs.UserSaver;
        if (string.IsNullOrEmpty(usersJson))
        {
            userData = new UserData();
            SaveUserData();
        }
        else
            userData = JsonConvert.DeserializeObject<UserData>(usersJson);

    }

    public static void SaveUserData()
    {
        GamePlayerPrefs.UserSaver = JsonConvert.SerializeObject(userData);
    }

    public static void ToBuyBuilding(string complexname,string buildName, int coast)
    {
        if (userData.boughtBuildings.ContainsKey(complexname))
        {
            if (!userData.boughtBuildings.ContainsValue(buildName) && buildName!=null)
            {
                userData.boughtBuildings[complexname] = buildName;
                userData.coins -= coast;
            }
        }
        else
        {
            userData.boughtBuildings.Add(complexname, buildName);
            userData.coins -= coast;
        }

        OnUpdateScore?.Invoke(userData.coins);
        OnUpdateBuilds?.Invoke(userData.boughtBuildings.Count);

        SaveUserData();
    }
    public static void ToCollectMoney(int coast)
    {
        userData.coins += coast;
        OnUpdateScore?.Invoke(userData.coins);
    }
    public static void ToLooseMoney(int coast)
    {
        userData.coins -= coast;
        OnUpdateScore?.Invoke(userData.coins);
    }

    public static void Clear()
    {
        userData = new UserData();
        SaveUserData();
    }

    public static void OnApplicationQuit()
    {
        SaveUserData();
    }
}
