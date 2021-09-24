using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreHandler _scoreHandler;
    [SerializeField] private Text _scoreIndicator;
    [SerializeField] private Text _bestIndicator;

    private void OnEnable()
    {
        _scoreHandler.OnAcountChange += ChangeScoreDisplay;
        _scoreHandler.OnStart += ChangeBestDisplay;
    }

    private void OnDisable()
    {
        _scoreHandler.OnAcountChange -= ChangeScoreDisplay;
        _scoreHandler.OnStart -= ChangeBestDisplay;
    }

    private void ChangeScoreDisplay(int score)
    {
        _scoreIndicator.text = score.ToString();
    }

    private void ChangeBestDisplay(int best)
    {
        _bestIndicator.text = "Best:" + best.ToString();
    }
}
