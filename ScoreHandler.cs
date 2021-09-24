using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EndChecker _endChecker;

    public delegate void AccountEventHandler(int currentScore);
    public event AccountEventHandler OnAcountChange;
    public event AccountEventHandler OnStart;

    private int _account;
    private int _bestAccount;

    private void OnEnable()
    {
        _player.OnAccent += AddScore;
        _endChecker.OnFinish += SaveProgress;
    }

    private void OnDisable()
    {
        _player.OnAccent -= AddScore;
        _endChecker.OnFinish -= SaveProgress;
    }

    private void Start()
    {
        _bestAccount = PlayerPrefs.GetInt("Score", 0);
        OnStart?.Invoke(_bestAccount);
    }

    private void AddScore(int score)
    {
        if(score < 1) return;
        _account += score;
        OnAcountChange?.Invoke(_account);
    }

    private void SaveProgress()
    {
        if(_bestAccount < _account)
        {
            PlayerPrefs.SetInt("Score", _account);
        }
    }
}
