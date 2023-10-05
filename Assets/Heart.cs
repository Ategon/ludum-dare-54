using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Auboreal
{
    public class Heart : MonoBehaviour
    {
        public int index;
        public GameObject child;
        public Transform travellingHealth;

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
            if ((int)amount == index)
            {
                if (amount < oldAmount)
                {
                    if (index != 0)
                    {
                        //travellingHealth.position = child.transform.position;
                        //travellingHealth.DOMoveY(child.transform.position.y - (float)160 / 160 * Screen.width, 1.5f).SetEase(Ease.InBack);
                        //travellingHealth.DOMoveX(child.transform.position.x + (float)130 / 160 * Screen.width, 1.5f).SetEase(Ease.InQuad);
                    }
                    child.SetActive(false);
                }
            }

            //if ((int) oldAmount == index)
            //{
                if (amount > oldAmount && amount -1 >= index){
                    child.SetActive(true);
                }
            //}
        }
    }

}