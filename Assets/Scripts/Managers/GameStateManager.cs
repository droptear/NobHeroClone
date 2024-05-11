using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private GameState _mainMenuState;
    [SerializeField] private GameState _chooseCardMenuState;
    [SerializeField] private GameState _actionState;
    [SerializeField] private GameState _pauseState;
    [SerializeField] private GameState _winState;
    [SerializeField] private GameState _loseState;

    private GameState _currentGameState;

    public void Init()
    {
        _mainMenuState.Init(this);
        _chooseCardMenuState.Init(this);
        _actionState.Init(this);
        _pauseState?.Init(this);
        _winState?.Init(this);
        _loseState.Init(this);

        SetGameState(_mainMenuState);
    }

    private void SetGameState(GameState gameState)
    {
        if (_currentGameState)
        {
            _currentGameState.Exit();
        }

        _currentGameState = gameState;
        gameState.Enter();
    }

    public void SetMainMenuState()
    {
        SetGameState(_mainMenuState);
    }

    public void SetChooseCardMenuState()
    {
        SetGameState(_chooseCardMenuState);
    }

    public void SetActionState()
    {
        SetGameState(_actionState);
    }

    public void SetPauseState()
    {
        SetGameState(_pauseState);
    }

    public void SetWinState()
    {
        SetGameState(_winState);
    }

    public void SetLoseState()
    {
        SetGameState(_loseState);
    }
}