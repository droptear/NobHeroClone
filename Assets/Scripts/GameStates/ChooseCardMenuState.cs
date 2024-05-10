using UnityEngine;

public class ChooseCardMenuState : GameState
{
    [SerializeField] private RigidbodyMove _rigidbodyMove;

    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0.0f;
        _rigidbodyMove.SetMoveability(false);
    }

    public override void Exit()
    {
        base.Exit();
        Time.timeScale = 1.0f;
        _rigidbodyMove.SetMoveability(true);
    }
}