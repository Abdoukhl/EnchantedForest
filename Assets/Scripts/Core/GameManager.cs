using UnityEngine;

namespace EnchantedForest.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Simulation Settings")]
        public float simulationSpeed = 1f;
        public bool isPaused = false;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                TogglePause();
        }

        public void TogglePause()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : simulationSpeed;
            Debug.Log(isPaused ? "Simulation Paused" : "Simulation Running");
        }

        public void SetSpeed(float speed)
        {
            simulationSpeed = speed;
            if (!isPaused) Time.timeScale = speed;
        }
    }
}