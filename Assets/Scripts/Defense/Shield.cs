using System.Collections;
using System.Collections.Generic;
using Auboreal;
using UnityEngine;
using DG.Tweening;

public class Shield : MonoBehaviour
{
    private InputHandler inputs;
    private ShieldState state = ShieldState.RIGHT;
    private float rotationTime = 0.25f;
    private float cooldown = 0.15f;
    private float cooldownTimer = 0;

    enum ShieldState
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    private void Start()
    {
        inputs = FindObjectOfType<InputHandler>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer < cooldown) return;

        if (inputs.Input.x > 0 && state != ShieldState.RIGHT)
        {
            DOTween.Kill(transform);
            transform.DORotate(new Vector3(0, 0, 0), rotationTime);
            state = ShieldState.RIGHT;
            cooldownTimer = 0;
        }
        else if (inputs.Input.x < 0 && state != ShieldState.LEFT)
        {
            DOTween.Kill(transform);
            transform.DORotate (new Vector3(0, 0, 180), rotationTime);
            state = ShieldState.LEFT;
            cooldownTimer = 0;
        }
        else if (inputs.Input.y > 0 && state != ShieldState.UP)
        {
            DOTween.Kill(transform);
            transform.DORotate(new Vector3(0, 0, 90), rotationTime);
            state = ShieldState.UP;
            cooldownTimer = 0;
        }
        else if (inputs.Input.y < 0 && state != ShieldState.DOWN)
        {
            DOTween.Kill(transform);
            transform.DORotate(new Vector3(0, 0, 270), rotationTime);
            state = ShieldState.DOWN;
            cooldownTimer = 0;
        }
    }

    
}
