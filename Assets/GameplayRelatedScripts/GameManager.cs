using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private DatabaseTransferer _databaseTransferer;


    private bool _isGameOver;

    [SerializeField]
    private int MaxMoves;

    private int _movesRemain;

    private int _correctPlacementCount;

    private int _requiredCorrectPlacementsCount;

    public static Action<int> RemainingMovesCountChanged;

    public static Action<bool> GameOver;



    public static GameManager Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }


    public void Init()
    {
        _movesRemain = MaxMoves;
        _isGameOver = false;
        _requiredCorrectPlacementsCount = 3;
        _correctPlacementCount = 0;

        RemainingMovesCountChanged?.Invoke(_movesRemain);

        if (_databaseTransferer != null)
        {
            _databaseTransferer.Init();
        }
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();


    }


    public void MakeMove(bool correctPlacement)
    {
        _movesRemain--;

        RemainingMovesCountChanged?.Invoke(_movesRemain);

        _correctPlacementCount += correctPlacement ? 1 : 0;

        if (_correctPlacementCount >= _requiredCorrectPlacementsCount && !_isGameOver)
        {
            WinGame();
        }

        if (_movesRemain <= 0 && !_isGameOver)
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        _isGameOver = true;
        GameOver(true);
    }

    public void LoseGame()
    {
        _isGameOver = true;
        GameOver(false);
    }


}
