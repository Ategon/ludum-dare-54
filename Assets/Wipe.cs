using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wipe : MonoBehaviour
{
    public bool second = false;

    public void Play()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        transform.DOLocalMoveX(0, 1f);
        transform.DOLocalMoveX(-200, 0.25f).SetDelay(second ? 3f : 6f).OnComplete(() =>
        {
            Destroy(transform.parent.gameObject);
        });
    }
}
