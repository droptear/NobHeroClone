using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardManager : MonoBehaviour
{
    public UnityEvent CardНasBeenPicked;

    [SerializeField] private GameObject _cardParent;
    [SerializeField] private Card[] _effectCards;
    [SerializeField] private EffectsManager _effectsManager;

    private void Awake()
    {
        for (int i = 0; i < _effectCards.Length; i++)
        {
            _effectCards[i].Init(_effectsManager, this);
        }
    }

    public void ShowCard(List<Effect> effects)
    {
        _cardParent.SetActive(true);
        for (int i = 0; i < effects.Count; i++)
        {
            _effectCards[i].Show(effects[i]);
        }
    }

    public void HideCards()
    {
        _cardParent.SetActive(false);
    }
}