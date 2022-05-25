using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainSceneHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buildingNumber;
    [SerializeField] private TextMeshProUGUI score;

    public void LoadHUD()
    {
        buildingNumber.text = SaveSystem.userData.boughtBuildings.Count.ToString();
        score.text = SaveSystem.userData.coins.ToString();
    }
    public void UpdateScoreValue(float value)
    {
        score.text = value.ToString();
    }

    public void UpdateBuildingNumber(int number)
    {
        buildingNumber.text = number.ToString();
    }
}
