using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreenManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _startingScreen;

    

    private void Start()
    {
        _startingScreen?.SetActive(true);
    }

    public void DisableScreen()
    {
        _startingScreen?.SetActive(false);
    }

}
