using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Models/Building repository")]
public class BuildingRepo : ScriptableObject
{
    public List<BuildInfo> buildInfos = new List<BuildInfo>();

    public BuildInfo GetInfo(string _buildName)
    {
        return buildInfos.Where(x => x.buildName == _buildName).FirstOrDefault();
    }
}

[Serializable]
public class BuildInfo
{
    public string buildName;
    public int coast;
    public int incom;
    public float reducingKoef;
}