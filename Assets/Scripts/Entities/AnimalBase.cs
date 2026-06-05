using UnityEngine;

namespace EnchantedForest.Entities
{
    public abstract class AnimalBase : MonoBehaviour
    {
        [Header("Identity")]
        public string animalName;
        public AnimalType animalType;

        [Header("Stats")]
        [Range(0f, 1f)] public float hunger = 0.5f;
        [Range(0f, 1f)] public float thirst = 0.5f;
        [Range(0f, 1f)] public float energy = 1f;
        [Range(0f, 1f)] public float fear = 0f;

        [Header("Settings")]
        public float moveSpeed = 2f;
        public float detectionRadius = 5f;

        [Header("Emotion")]
        [Range(0f, 1f)] public float mood = 0.5f;

        protected Rigidbody2D rb;
        protected Animator animator;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            Core.EcosystemManager.Instance?.RegisterAnimal(this);
        }

        protected virtual void Update()
        {
            UpdateStats();
            UpdateMood();
        }

        private void UpdateStats()
        {
            hunger += 0.01f * Time.deltaTime;
            thirst += 0.008f * Time.deltaTime;
            energy -= 0.005f * Time.deltaTime;

            hunger = Mathf.Clamp01(hunger);
            thirst = Mathf.Clamp01(thirst);
            energy = Mathf.Clamp01(energy);
        }

        private void UpdateMood()
        {
            mood = 1f - ((hunger + thirst + fear) / 3f);
            mood = Mathf.Clamp01(mood);
        }

        public virtual void Move(Vector2 direction)
        {
            if (rb != null)
                rb.velocity = direction * moveSpeed;
        }

        public virtual void Die()
        {
            Core.EcosystemManager.Instance?.UnregisterAnimal(this);
            Debug.Log($"{animalName} has died.");
            Destroy(gameObject);
        }
    }

    public enum AnimalType { Herbivore, Carnivore, Omnivore }
}