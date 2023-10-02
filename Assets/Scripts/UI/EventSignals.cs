using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class EventSignals : MonoBehaviour, IDeselectHandler, ISelectHandler, ISubmitHandler, IPointerClickHandler
{
    public delegate void OnObjectSelect();
    public event OnObjectSelect onSelect;

    public delegate void OnObjectDeselect();
    public event OnObjectDeselect onDeselect;

    public delegate void OnObjectSubmit();
    public event OnObjectSubmit onSubmit;

    public void OnDeselect(BaseEventData eventData)
    {
        if (onDeselect != null) onDeselect();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (onSubmit != null) onSubmit();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null) onSubmit();
    }
}
