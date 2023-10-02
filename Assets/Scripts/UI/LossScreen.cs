using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Auboreal
{
    public class LossScreen : MonoBehaviour
    {
        public GameObject child;

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
            if (amount == 0)
            {
                Time.timeScale = 0;
                child.SetActive(true);
            }
        }
    }
}
