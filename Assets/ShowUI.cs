using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject UI;

    public void EnableUI()
    {
        if (UI.activeSelf) return;
        UI.SetActive(true);
    }
}
