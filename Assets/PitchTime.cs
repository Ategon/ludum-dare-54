using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Time.timeScale;
    }
}
