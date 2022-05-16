using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfCircle : MonoBehaviour
{
    public Action OnReloadScene; 
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<CubeMovement>();
        if (player !=null)
        {
            OnReloadScene?.Invoke();
        }
    }
}
