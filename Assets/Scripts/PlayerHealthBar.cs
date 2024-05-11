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
    private float _visualUpdateTime = 0.6f;

    private void OnEnable()
    {
        _playerHealth.OnHealthChange += UpdateHealthData;
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
        float currentHealthbarValue = _healhScale.fillAmount;
        float targetHealthbarValue = _currentHealth / _maxHealth;
        for (float t = 0; t < _visualUpdateTime; t += Time.deltaTime)
        {
            _healhScale.fillAmount = Mathf.Lerp(currentHealthbarValue, targetHealthbarValue, t / _visualUpdateTime);
            yield return null;
        }
        _healhScale.fillAmount = _currentHealth / _maxHealth;
    }
}
