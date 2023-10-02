using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auboreal;
using TMPro;
using DG.Tweening;

namespace Auboreal
{
    public class FasterText : MonoBehaviour
    {
        public TextMeshProUGUI text;

        void OnEnable()
        {
            EventManager.Gameplay.OnScoreChanged += onScoreChanged;
        }

        void OnDisable()
        {
            EventManager.Gameplay.OnScoreChanged -= onScoreChanged;
        }

        void OnDestroy()
        {
            EventManager.Gameplay.OnScoreChanged -= onScoreChanged;
        }

        void onScoreChanged(float amount)
        {
            if (amount % 4 == 0 && amount != 0)
            {
                text.transform.localPosition = new Vector3(51, 35, 0);
                text.transform.DOLocalMoveY(-97, 3f).SetEase(Ease.InBack);
                text.transform.DOLocalMoveX(-45, 3f);
                text.DOFade(1f, 0.5f);
                text.DOFade(0, 0.5f).SetDelay(2);
                if (Time.timeScale == 0) return;
                Time.timeScale += 0.1f;
            }
        }
    }
}
