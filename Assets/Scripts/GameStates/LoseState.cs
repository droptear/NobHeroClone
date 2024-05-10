using UnityEngine;

public class LoseState : GameState
{
    [SerializeField] private LoseScreen _loseScreen;

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0.0f;
        _loseScreen.Show();
    }

    public override void Exit()
    {
        Time.timeScale = 1.0f;
    }
}
