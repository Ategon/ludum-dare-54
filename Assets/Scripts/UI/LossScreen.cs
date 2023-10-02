using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Auboreal
{
    public class LossScreen : MonoBehaviour
    {
        public GameObject child;
        private float timer = 0;
        private bool dead = false;

        public GameObject UI;

        private bool started = false;

        void OnEnable()
        {
            EventManager.Gameplay.OnHealthChanged += onHealthChanged;
            EventManager.Input.OnAnyInputPressed += OnAnyInputPressed;
        }

        void OnDisable()
        {
            EventManager.Gameplay.OnHealthChanged -= onHealthChanged;
            EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
        }

        void OnDestroy()
        {
            EventManager.Gameplay.OnHealthChanged -= onHealthChanged;
            EventManager.Input.OnAnyInputPressed -= OnAnyInputPressed;
        }

        private void OnAnyInputPressed()
        {
            if (!dead) return;
            if (timer > 0.5f)
            {
                Time.timeScale = 1;
                dead = false;
                timer = 0;
                UI.SetActive(false);
                StartGame();
            }
        }

        private void Update()
        {
            if (!dead) return;
            timer += Time.unscaledDeltaTime;
        }

        void onHealthChanged(float amount, float oldAmount)
        {
            if (amount == 0)
            {
                dead = true;
                Time.timeScale = 0;
                started = false;
                child.SetActive(true);
            }
        }

        

        public void StartGame()
        {
            if (started) return;
            started = true;
            FindObjectOfType<MicroGameFlowManager>()
                .StartMicroGame(PersistentData.Instance.GetRandomMicroGame(), isComingFromMenu: true);
        }
    }
}
