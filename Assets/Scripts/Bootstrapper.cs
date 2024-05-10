using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] GameStateManager _gameStateManager;
    [SerializeField] PlayerHealth _playerHealth;

    private void Awake()
    {
        _gameStateManager.Init();
        _playerHealth.Init(_gameStateManager);
    }
}