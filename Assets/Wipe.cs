using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wipe : MonoBehaviour
{
    private void Start()
    {
        transform.DOLocalMoveX(0, 1f);
        transform.DOLocalMoveX(-200, 1f).SetDelay(3f);
    }
}
