using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIJump : MonoBehaviour
{
    public EventSignals signals;

    [Header("Attributes")]
    [SerializeField] private float jumpAmount = 20f;
    [SerializeField] private float jumpUpTime = 0.1f;
    [SerializeField] private float jumpDownTime = 0.2f;

    private Coroutine lastCoroutine;
    private Vector3 position;

    private void Awake()
    {
        position = transform.localPosition;
    }

    private void OnEnable()
    {
        transform.localPosition = position;
        transform.localScale = new Vector3(1, 1, 1);
        signals.onSelect += OnSelect;
        signals.onSubmit += OnSubmit;
    }

    private void OnDestroy()
    {
        signals.onSelect -= OnSelect;
        signals.onSubmit -= OnSubmit;
    }

    private void OnDisable()
    {
        signals.onSelect -= OnSelect;
        signals.onSubmit -= OnSubmit;
    }

    private void OnSelect()
    {
        if (lastCoroutine != null) StopCoroutine(lastCoroutine);
        transform.localPosition = position;
        lastCoroutine = StartCoroutine(JumpUp());
    }

    private void OnSubmit()
    {
        if (lastCoroutine != null) StopCoroutine(lastCoroutine);
        transform.localPosition = position;
        lastCoroutine = StartCoroutine(JumpUp());
    }

    private IEnumerator JumpUp()
    {
        transform.DOScale(1.2f, jumpUpTime).SetEase(Ease.OutBack).SetUpdate(true);
        transform.DOLocalMoveY(position.y + jumpAmount, jumpUpTime).SetUpdate(true);
        yield return new WaitForSecondsRealtime(jumpUpTime);
        transform.DOScale(1f, jumpDownTime).SetEase(Ease.OutBack).SetUpdate(true);
        transform.DOLocalMoveY(position.y, jumpDownTime).SetUpdate(true);
        yield return new WaitForSecondsRealtime(jumpDownTime);
    }
}
