using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Auboreal
{
    public class GlobalPlacement : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(PersistentData.Instance.Get());
        }

        void OnEnable()
        {
            EventManager.Global.OnPlacementLoaded += onPlacementLoaded;
        }

        void OnDisable()
        {
            EventManager.Global.OnPlacementLoaded -= onPlacementLoaded;
        }

        void OnDestroy()
        {
            EventManager.Global.OnPlacementLoaded -= onPlacementLoaded;
        }

        private void onPlacementLoaded (int place, int scores)
        {
            int best = PersistentData.Instance.GetMax();
            int bestPlacement = PersistentData.Instance.GetGlobalScoresAbove(best);
            GetComponent<TextMeshProUGUI>().text = $"(Top {bestPlacement * 100/(scores + 1)}%) #{bestPlacement} :Best\n(Top {place*100/(scores+1)}%)  #{place} :Global";
            StartCoroutine(PersistentData.Instance.Upload());
        }
    }
}