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
            EventManager.Gameplay.OnScoreChanged -= onScoreChanged;
        }

        void OnDisable()
        {
            EventManager.Gameplay.OnScoreChanged += onScoreChanged;
        }

        void OnDestroy()
        {
            EventManager.Gameplay.OnScoreChanged -= onScoreChanged;
        }

        void onScoreChanged(float amount)
        {
            if (amount % 4 == 0)
            {
                text.DOFade(1f, 0.5f).OnComplete(() => { text.DOFade(0, 0.5f); });
                Time.timeScale *= 1.25f;
            }
        }
    }
}
