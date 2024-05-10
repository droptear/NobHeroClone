using UnityEngine;
using UnityEngine.UI;

public class MainMenuState : GameState
{
    [SerializeField] private Button _tapToStartButton;
    [SerializeField] private GameObject _startMenuObject;

    public override void Init(GameStateManager gameStateManager)
    {
        base.Init(gameStateManager);
        _tapToStartButton.onClick.AddListener(gameStateManager.SetActionState);
    }

    public override void Enter()
    {
        base.Enter();
        _startMenuObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        _startMenuObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
