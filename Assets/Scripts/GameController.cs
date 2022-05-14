using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EndOfCircle endOfCircle;
    [SerializeField] private BuildingController buildingController;
    [SerializeField] private BuildingRepo buildingRepo;

    private void Awake()
    {
        SaveSystem.LoadUserData();
        buildingController.CollectBuilding();
    }
    void Start()
    {
        buildingController.SetBuildings(buildingRepo);
        //SaveSystem.Clear();
        StartCoroutine(OnEndOfCircle());
    }

    private IEnumerator OnEndOfCircle()
    {
        yield return new WaitForSeconds(5f);
        endOfCircle.gameObject.SetActive(true);
    }
}
