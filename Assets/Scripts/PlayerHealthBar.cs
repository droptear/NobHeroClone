using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healhScale;
    [SerializeField] private PlayerHealth _playerHealth;

    private float _currentHealth;
    private float _maxHealth;
    private float _visualUpdateTime = 1.0f;

    private void OnEnable()
    {
        _playerHealth.OnHealthChange += UpdateHealthData;
    }

    private void Update()
    {
        //_healhScale.fillAmount = Mathf.Lerp(_healhScale.fillAmount, _currentHealth / _maxHealth, Time.deltaTime);
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChange -= UpdateHealthData;
    }

    private void UpdateHealthData(float currentHealth, float maxHealth)
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
        StartCoroutine(nameof(UpdateHealthBarVisual));
    }

    private IEnumerator UpdateHealthBarVisual()
    {
        for (float t = 0; t < _visualUpdateTime; t += 0.01f)
        {
            _healhScale.fillAmount = Mathf.Lerp(_healhScale.fillAmount, _currentHealth / _maxHealth, t);
            yield return null;
        }
        _healhScale.fillAmount = _currentHealth / _maxHealth;
    }
}
