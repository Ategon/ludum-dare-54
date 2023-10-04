using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Auboreal
{
    public class Xmark : MonoBehaviour
    {
        public Image child;

        void OnEnable()
        {
            EventManager.Gameplay.OnHealthChanged += onHealthChanged;
        }

        void OnDisable()
        {
            EventManager.Gameplay.OnHealthChanged -= onHealthChanged;
        }

        void OnDestroy()
        {
            EventManager.Gameplay.OnHealthChanged -= onHealthChanged;
        }

        void onHealthChanged(float amount, float oldAmount)
        {
            if (amount < oldAmount && amount != 0)
            {
                child.DOFade(1, 0.5f);
                child.DOFade(0, 0.5f).SetDelay(1.5f);
            }
        }
    }
}
