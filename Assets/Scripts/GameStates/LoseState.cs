using System.Collections;
using UnityEngine;

public class LoseState : GameState
{
    [SerializeField] private LoseScreen _loseScreen;
    [SerializeField] private float _delayOfApperance;

    public override void Enter()
    {
        base.Enter();
        StartCoroutine(ShowWithDelay(_delayOfApperance));
    }

    private void SetTimeScaleToZero()
    {
        Time.timeScale = 0.0f;
    }

    private IEnumerator ShowWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        _loseScreen.Show();
        SetTimeScaleToZero();
    }

    public override void Exit()
    {
        Time.timeScale = 1.0f;
    }
}
