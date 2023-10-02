using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShowUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<ShowUI>().EnableUI();
    }
}
