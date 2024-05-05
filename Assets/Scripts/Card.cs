using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _iconBackground;
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _button;

    [SerializeField] private Sprite _continuousEffectSprite;
    [SerializeField] private Sprite _oneTimeEffectSprite;

    private EffectsManager _effectManager;
    private CardManager _cardManager;

    private Effect _effect;

    public void Init(EffectsManager effectsManager, CardManager cardManager)
    {
        _effectManager = effectsManager;
        _cardManager = cardManager;
        _button.onClick.AddListener(Click);
    }

    public void Show(Effect effect)
    {
        _effect = effect;

        _nameText.text = effect.Name;
        _descriptionText.text = effect.Description;
        _levelText.text = $"LVL: {effect.Level + 1}";
        _iconImage.sprite = effect.Sprite;

        if(effect is ContinuousEffect)
        {
            _iconBackground.sprite = _continuousEffectSprite;
        }
        else if (effect is OneTimeEffect)
        {
            _iconBackground.sprite = _oneTimeEffectSprite;
        }
    }

    public void Click()
    {
        _effectManager.AddEffect(_effect);
        _cardManager.CardНasBeenPicked.Invoke();
        _cardManager.HideCards();
    }
}