using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Auboreal
{
    public class GetScore : MonoBehaviour
    {
        void OnEnable()
        {
            GetComponent<TextMeshProUGUI>().text = $"{PersistentData.Instance.Score-3} people saved";
        }
    }
}
