using UnityEngine;

namespace EnchantedForest.AI.Emotions
{
    public enum EmotionalState { Calm, Anxious, Afraid, Happy, Hungry }

    public class EmotionSystem : MonoBehaviour
    {
        [Header("Current State")]
        public EmotionalState currentState = EmotionalState.Calm;
        public float mood = 0.5f;

        [Header("Thresholds")]
        public float fearThreshold = 0.7f;
        public float hungerThreshold = 0.8f;
        public float anxiousThreshold = 0.5f;
        public float happyThreshold = 0.8f;

        private Entities.AnimalBase animal;

        private void Awake()
        {
            animal = GetComponent<Entities.AnimalBase>();
        }

        private void Update()
        {
            if (animal == null) return;
            UpdateMood();
            UpdateEmotionalState();
        }

        private void UpdateMood()
        {
            mood = 1f - ((animal.hunger + animal.thirst + animal.fear) / 3f);
            mood = Mathf.Clamp01(mood);
            animal.mood = mood;
        }

        private void UpdateEmotionalState()
        {
            if (animal.fear >= fearThreshold)
                currentState = EmotionalState.Afraid;
            else if (animal.hunger >= hungerThreshold)
                currentState = EmotionalState.Hungry;
            else if (animal.fear >= anxiousThreshold)
                currentState = EmotionalState.Anxious;
            else if (mood >= happyThreshold)
                currentState = EmotionalState.Happy;
            else
                currentState = EmotionalState.Calm;
        }

        public EmotionalState GetState() => currentState;
        public float GetMood() => mood;
    }
}