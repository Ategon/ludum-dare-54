using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Auboreal
{
    public class TitleText : MonoBehaviour
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
            if (PersistentData.Instance.m_MicroGamesStates[microGame.gameType].GameState != MicroGamePersistentState.MicroGameState.FirstRun)
            {
                text.text = microGame.name;
                text.DOFade(1, 0.5f);
                text.DOFade(0, 0.5f).SetDelay(2.5f);
            }
            else
            {
                text.text = microGame.name;
                text.DOFade(1, 0.5f);
                text.DOFade(0, 0.5f).SetDelay(5.5f);
            }
        }
    }
}
