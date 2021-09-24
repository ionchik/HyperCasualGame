using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SwipeDetector _swipeDetector;
    [SerializeField] private float _xPositionLimit;

    public delegate void EnterEventHandler(int score);
    public event EnterEventHandler OnAccent;

    private void OnEnable()
    {
        _swipeDetector.OnSwipe += Move;
    }

    private void OnDisable()
    {
        _swipeDetector.OnSwipe -= Move;
    }

    private void Move(float xPosition)
    {
        if(Mathf.Abs(xPosition) >= _xPositionLimit) return;
        transform.position = new Vector3(xPosition, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out DroppingBall droppingBall))
        {
            OnAccent?.Invoke(droppingBall.Score);
            Destroy(droppingBall.gameObject);
        }
    }
}
