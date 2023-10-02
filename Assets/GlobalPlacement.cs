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

        private void onPlacementLoaded (int place)
        {
            GetComponent<TextMeshProUGUI>().text = $"#{place} :Global";
            StartCoroutine(PersistentData.Instance.Upload());
        }
    }
}
