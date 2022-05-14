using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePlayerPrefs 
{
    public static string UserSaver
    {
        get => PlayerPrefs.GetString(nameof(UserSaver), "");
        set => PlayerPrefs.SetString(nameof(UserSaver), value);
    }
}
