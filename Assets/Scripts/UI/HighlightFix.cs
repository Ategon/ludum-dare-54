using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Selectable))]
public class HighlightFix : MonoBehaviour
{
    public EventSignals signals;

    private void OnEnable()
    {
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

    }

    private void OnDeselect()
    {

    }

    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.instance.hovering = false;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        this.GetComponent<Selectable>().OnPointerExit(null);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (eventData.button == PointerEventData.InputButton.Left)
        //EventSystem.current.SetSelectedGameObject(this.gameObject);
    }*/
}
