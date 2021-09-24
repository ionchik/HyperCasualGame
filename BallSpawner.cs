using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private DroppingBall _ball;
    [SerializeField] private Vector2 _xPositionLimits;
    [SerializeField] private Vector2 _timeLimits;
    [SerializeField] private AnimationCurve _timeChangingOnGame;
    [SerializeField] private int _scoreAtMinTime;
    [SerializeField] private ScoreHandler _scoreHandler;
    private WaitForSeconds _timeBetweenSpawn;

    private void OnEnable()
    {
        _scoreHandler.OnAcountChange += ChangeTime;
    }

    private void OnDisable()
    {
        _scoreHandler.OnAcountChange -= ChangeTime;
    }

    private void Start()
    {
        _timeBetweenSpawn = new WaitForSeconds(_timeLimits.x);
        StartCoroutine(SpawnOnTime());
    }

    private IEnumerator SpawnOnTime()
    {
        while(true)
        {
            yield return _timeBetweenSpawn;
            Instantiate(_ball, new Vector2(Random.Range(_xPositionLimits.x, _xPositionLimits.y), transform.position.y), Quaternion.identity);
        }
    }

    private void ChangeTime(int score)
    {
        float accountRatio = (float)(score) / (float)(_scoreAtMinTime);
        float difference = (_timeLimits.x - _timeLimits.y) * _timeChangingOnGame.Evaluate(accountRatio);
        float time = _timeLimits.x - difference;
        _timeBetweenSpawn = new WaitForSeconds(time);
    }
}
