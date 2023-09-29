using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PersistentData : MonoBehaviour
{
    public static PersistentData instance = null;

    public delegate void OnHealthChanged(float amount);
    public delegate void OnScoreChanged(float amount);
    public event OnHealthChanged HealthChanged;
    public event OnScoreChanged ScoreChanged;

    [Header("Objects")]
    public MicroGame[] microgames;

    [Header("Attributes")]
    public int maxHealth = 3;

    [Header("Values")]
    private int currentMicrogame = -1;
    private int score = 0;
    private int health = 0;

    public int Score
    {
        get => score;
        set {
            score = value;
            ScoreChanged?.Invoke(value);
        }
    }
    public int Health
    {
        get => health;
        set
        {
            health = value;
            HealthChanged?.Invoke(value);
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        health = maxHealth;
    }

    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    [System.Serializable]
    public class MicroGame
    {
        [Header("Attributes")]
        public string name;
        public string instructions;
        public string sceneName;
        public bool disabled = false;

        [Header("Values")]
        public bool dead = false;
    }
}
