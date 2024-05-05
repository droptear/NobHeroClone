using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ExperienceManager : MonoBehaviour
{
    public UnityEvent LevelUpEvent;
    public UnityEvent EffectAddedEvent;

    [SerializeField] private float _experience = 0.0f;
    [SerializeField] private float _nextExperienceLevel;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Image _experienceScale;
    [SerializeField] private EffectsManager _effectsManager;
    [SerializeField] private AnimationCurve _experienceCurve;

    private int _level;

    private void Awake()
    {
        _effectsManager.EffectHasBeenAdded.AddListener(OnEffectAdded);
        _nextExperienceLevel = _experienceCurve.Evaluate(0);
    }

    private void Update()
    {
        DisplayExperience();
    }

    public void AddExperience(int value)
    {
        _experience += value;
        if(_experience >= _nextExperienceLevel)
        {
            UpLevel();
            LevelUpEvent.Invoke();
        }
    }

    private void UpLevel()
    {
        _level++;
        _experience = 0.0f;
        _nextExperienceLevel = _experienceCurve.Evaluate(_level);
        _levelText.text = $"{_level}";

        _effectsManager.ShowCardsWithDelay();
    }

    private void DisplayExperience()
    {
        _experienceScale.fillAmount = Mathf.Lerp( _experienceScale.fillAmount, _experience / _nextExperienceLevel, Time.deltaTime * 4.5f);
    }

    private void OnEffectAdded()
    {
        EffectAddedEvent.Invoke();
    }
}