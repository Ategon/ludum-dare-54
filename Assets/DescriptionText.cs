using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Auboreal
{
    public class DescriptionText : MonoBehaviour
    {
        private TextMeshProUGUI text;

        void OnEnable()
        {
            EventManager.Global.OnMicroGameSceneSwitch += onMicrogameSwitched;
            text = GetComponent<TextMeshProUGUI>();
        }

        void OnDisable()
        {
            EventManager.Global.OnMicroGameSceneSwitch -= onMicrogameSwitched;
        }

        void OnDestroy()
        {
            EventManager.Global.OnMicroGameSceneSwitch -= onMicrogameSwitched;
        }

        void onMicrogameSwitched(PersistentData.MicroGame microGame)
        {
            text.text = microGame.instructions;
            text.DOFade(1, 0.5f);
            text.DOFade(0, 1.0f).SetDelay(3.0f);
        }
    }
}
