using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenManager : MonoBehaviour
{
    private Text _gameOverScreenText;

    [SerializeField]
    private GameObject _gameOverScreen;

    private string _winText;
    private string _losetext;



    private void Awake()
    {
        _gameOverScreenText = _gameOverScreen?.transform.GetComponentInChildren<Text>();
        

        _winText = "¬—® œ–¿¬»À‹ÕŒ!";
        _losetext = "Õ≈”ƒ¿◊¿!";

        Init();
    }

    public void Init()
    {        
        _gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.GameOver += DisplayGameOverScreen;
    }

    private void OnDisable()
    {
        GameManager.GameOver -= DisplayGameOverScreen;
    }

    private void DisplayGameOverScreen(bool haveWon)
    {
        _gameOverScreenText.text = haveWon ? _winText : _losetext;
        _gameOverScreen.SetActive(true);
    }

}
