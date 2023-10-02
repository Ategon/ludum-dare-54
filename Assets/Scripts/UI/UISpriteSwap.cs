using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteSwap : MonoBehaviour
{
    public EventSignals signals;

    private Image image;

    [Header("Attributes")]
    [SerializeField] private Sprite disabledSprite;
    [SerializeField] private Sprite enabledSprite;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = disabledSprite;
    }

    private void OnEnable()
    {
        image.sprite = disabledSprite;
        signals.onSelect += OnSelect;
        signals.onDeselect += OnDeselect;
    }

    private void OnDestroy()
    {
        signals.onSelect -= OnSelect;
        signals.onDeselect -= OnDeselect;
    }

    private void OnDisable()
    {
        signals.onSelect -= OnSelect;
        signals.onDeselect -= OnDeselect;
    }

    private void OnSelect()
    {
        image.sprite = enabledSprite;
    }

    private void OnDeselect()
    {
        image.sprite = disabledSprite;
    }
}
