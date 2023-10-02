using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Auboreal
{
    public class GetReadyText : MonoBehaviour
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
            text.DOFade(1, 0.5f);
            text.DOFade(0, 0.5f).SetDelay(2.5f);
        }
    }
}
