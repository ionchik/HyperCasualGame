using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetector : MonoBehaviour, IDragHandler
{
    public delegate void SwipeEventHandler(float xMovement);
    public event SwipeEventHandler OnSwipe;

    public void OnDrag(PointerEventData data)
    {
        Vector2 choosenPosition = Camera.main.ScreenToWorldPoint(data.position);
        OnSwipe?.Invoke(choosenPosition.x);
    }
}
