using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Auboreal;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        FindObjectOfType<MicroGameFlowManager>().StartMicroGame(PersistentData.Instance.GetRandomMicroGame());
    }

    public void QuitGame()
    {

    }

    public void Leaderboard()
    {

    }

    public void Credits()
    {

    }

    public void Options()
    {

    }
}