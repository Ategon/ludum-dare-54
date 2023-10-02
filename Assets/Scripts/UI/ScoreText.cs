using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auboreal;
using TMPro;

namespace Auboreal
{
    public class ScoreText : MonoBehaviour
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
            text.text = "Lv: " + amount;
        }
    }
}
