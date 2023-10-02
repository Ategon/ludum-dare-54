using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wipe : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        transform.DOLocalMoveX(0, 1f);
        transform.DOLocalMoveX(-200, 0.25f).SetDelay(3f).OnComplete(() =>
        {
            Destroy(transform.parent.gameObject);
        });
    }
}
