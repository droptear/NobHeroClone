using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private GameStateManager _gameStateManager;
    private bool _isDead;

    public event Action<float, float> OnHealthChange;
    public event Action OnDie;

    public void Init(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
    }

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    public void TakeDamage(float value)
    {
        if(_isDead == false)
        {
            float newHealth = Mathf.Max(_currentHealth - value, 0.0f);
            SetHealth(newHealth);
            if (newHealth == 0.0f)
            {
                Die();
            }
        }
    }

    private void SetHealth(float value)
    {
        _currentHealth = value;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    private void Die()
    {
        _isDead = true;
        OnDie?.Invoke();
        _gameStateManager.SetLoseState();
    }
} 