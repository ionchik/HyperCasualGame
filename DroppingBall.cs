using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingBall : MonoBehaviour
{
    [SerializeField] private Vector2Int _scoreLimits;
    [SerializeField] private Vector2 _scaleLimits;
    public int Score => _score;
    private int _score;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _score = Random.Range(_scoreLimits.x, _scoreLimits.y);

        float scoreRatio = (float)(_score - _scoreLimits.x) / (float)(_scoreLimits.y - _scoreLimits.x);
        float scale = _scaleLimits.y + (_scaleLimits.x - _scaleLimits.y) * scoreRatio;
        transform.localScale = new Vector2(scale, scale);

        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = Vector2.down;
    }
}
