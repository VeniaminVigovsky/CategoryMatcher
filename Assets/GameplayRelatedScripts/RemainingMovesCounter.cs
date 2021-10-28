using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingMovesCounter : MonoBehaviour
{
    private Text _moveCountText;
    private string _initText;

    private void Awake()
    {
        _moveCountText = GetComponent<Text>();
        _initText = _moveCountText?.text;
    }

    private void OnEnable()
    {
        GameManager.RemainingMovesCountChanged += DisplayCount;
    }

    private void OnDisable()
    {
        GameManager.RemainingMovesCountChanged -= DisplayCount;
    }

    private void DisplayCount(int count)
    {
        _moveCountText.text = _initText + count;
    }

}
