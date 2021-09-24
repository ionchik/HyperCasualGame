using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChecker : MonoBehaviour
{
    [SerializeField] private float _sleepTime;
    public delegate void EndEventHandler();
    public event EndEventHandler OnFinish;

    private IEnumerator Finish()
    {
        OnFinish?.Invoke();
        yield return new WaitForSeconds(_sleepTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out DroppingBall droppingBall))
        {
            StartCoroutine(Finish());
        }
    }    
}
