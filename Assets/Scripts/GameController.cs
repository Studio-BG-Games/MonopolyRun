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

    [SerializeField] private int policeLoss;
    private void Awake()
    {
        //SaveSystem.Clear();

        SaveSystem.LoadUserData();
        buildingController.CollectBuilding();
        endOfCircle.OnReloadScene += ReloadScene;
        fixation.FillList();
    }
    void Start()
    {
        buildingController.SetBuildings(buildingRepo);

        policeSpawner.PoliceGenerator(fixation, policeLoss);
        player.Initialize(fixation);
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
    }
}
