using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Auboreal
{
    public class LocalPlacement : MonoBehaviour
    {
        private void Start()
        {
            int score = PersistentData.Instance.Score;
            int scoresAbove = PersistentData.Instance.GetLocalScoresAbove(score);
            GetComponent<TextMeshProUGUI>().text = $"Local: #{scoresAbove + 1}";

            PersistentData.Instance.localScores.Add(score);
        }
    }
}
