using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfCircle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CubeMovement>();
        if (player !=null)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
