using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveSystem 
{
    public static UserData userData;

    
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

    public static void ToBuyBuilding(string buildName, int coast)
    {
        if (userData.boughtBuildings.FirstOrDefault(x => x == buildName) == null)
        {
            userData.boughtBuildings.Add(buildName);
            userData.coins -= coast;
            
            SaveUserData();
        }
    }
    public static void ToCollectMoney(int coast)
    {
        userData.coins += coast;
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
