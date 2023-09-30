using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;
using DG.Tweening;

public class PromptTrigger : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private Vector2 direction;
    [SerializeField] private float cooldown = 0.1f;

    private InputHandler inputs;
    private SpriteRenderer sr;
    private bool triggered = false;
    private float cooldownTimer = 0;

    private void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (
            ((direction.x > 0 || direction.x < 0) && Mathf.Sign(inputs.Input.x) == Mathf.Sign(direction.x) && inputs.Input.x != 0
            || (direction.y > 0 || direction.y < 0) && Mathf.Sign(inputs.Input.y) == Mathf.Sign(direction.y) && inputs.Input.y != 0)
        )
        {
            if (!triggered)
            {
                DOTween.Kill(sr);
                DOTween.Kill(transform);
                sr.DOFade(1, 0.5f);
                transform.DOPunchScale(Vector3.one * 1.05f, 0.25f, 2, 0.05f);
                triggered = true;
            }

            cooldownTimer = cooldown;
        }

        if (triggered && cooldownTimer > cooldown)
        {
            DOTween.Kill(sr);
            DOTween.Kill(transform);
            sr.DOFade(0.2f, 0.5f);
            transform.DOScale(Vector3.one, 0.25f);
            triggered = false;
        }
    }
}
