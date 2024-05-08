using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action<float, float> OnHealthChange;
    public event Action OnDie;

    private void Start()
    {
        SetHealth(_maxHealth);
    }

    public void TakeDamage(float value)
    {
        float newHealth = Mathf.Max(_currentHealth - value, 0.0f);
        SetHealth(newHealth);
        if (newHealth == 0.0f)
        {
            Die();
        }
    }

    private void SetHealth(float value)
    {
        _currentHealth = value;
        OnHealthChange?.Invoke(_currentHealth, _maxHealth);
    }

    private void Die()
    {
        OnDie?.Invoke();
        SetHealth(_maxHealth);
        Debug.Log("Sorry, mate. You dead.");
    }
} 