using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private EndOfCircle endOfCircle;
    [SerializeField] private BuildingController buildingController;
    [SerializeField] private BuildingRepo buildingRepo;
    [SerializeField] private PoliceSpawner policeSpawner;
    [SerializeField] private PlayersFixation fixation;
    [SerializeField] private CubeMovement player;
    [SerializeField] private MainSceneHUD hud;
    [Space]
    [SerializeField] private Metro metro;
    [SerializeField] private Transform metroOut;
    [SerializeField] private int boundaryNumber;
    [Space]
    [SerializeField] private int policeLoss;
    private void Awake()
    {
        //SaveSystem.Clear();

        LoadScene();
    }
    void Start()
    {
        LoadEnvironment();
    }

    private void LoadScene()
    {
        SaveSystem.LoadUserData();

        buildingController.CollectBuilding();
        endOfCircle.OnReloadScene += ReloadScene;

        SaveSystem.OnUpdateScore += hud.UpdateScoreValue;
        SaveSystem.OnUpdateBuilds += hud.UpdateBuildingNumber;

        fixation.FillList();
    }

    private void LoadEnvironment()
    {
        buildingController.SetBuildings(buildingRepo);

        policeSpawner.PoliceGenerator(fixation, policeLoss);
        hud.LoadHUD();
        player.Initialize(fixation);

        metro.MetroOut = metroOut;
        metro.BoundaryNumber = boundaryNumber;

        StartCoroutine(OnEndOfCircle());
    }
    private IEnumerator OnEndOfCircle()
    {
        yield return new WaitForSeconds(5f);
        endOfCircle.gameObject.SetActive(true);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void OnDestroy()
    {
        endOfCircle.OnReloadScene -= ReloadScene;
        SaveSystem.OnUpdateScore -= hud.UpdateScoreValue;
        SaveSystem.OnUpdateBuilds -= hud.UpdateBuildingNumber;
    }
}
