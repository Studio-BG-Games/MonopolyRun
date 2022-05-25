using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    [SerializeField] private FirstSceneHUD sceneHUD;

    private void Start()
    {
        sceneHUD.playBt.onClick.AddListener(LoadGame);
        sceneHUD.resetBt.onClick.AddListener(ResetGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ResetGame()
    {
        SaveSystem.Clear();
    }

    private void OnDisable()
    {
        sceneHUD.playBt.onClick.RemoveListener(LoadGame);
        sceneHUD.resetBt.onClick.RemoveListener(ResetGame);
    }
}
