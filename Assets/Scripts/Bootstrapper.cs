using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] GameStateManager _gameStateManager;
    [SerializeField] PlayerHealth _playerHealth;
    [SerializeField] RigidbodyMove _rigidbodyMove;

    private void Awake()
    {
        _gameStateManager.Init();
        _playerHealth.Init(_gameStateManager);
        _rigidbodyMove.Init(_playerHealth);
    }
}