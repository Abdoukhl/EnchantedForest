using System.Collections.Generic;
using UnityEngine;

namespace EnchantedForest.Core
{
    public class EcosystemManager : MonoBehaviour
    {
        public static EcosystemManager Instance { get; private set; }

        [Header("Population")]
        public List<Entities.AnimalBase> animals = new List<Entities.AnimalBase>();

        [Header("Metrics")]
        public float averageMood;
        public float averageHunger;
        public float averageFear;
        public int totalPopulation;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Update()
        {
            UpdateMetrics();
        }

        public void RegisterAnimal(Entities.AnimalBase animal)
        {
            if (!animals.Contains(animal))
                animals.Add(animal);
        }

        public void UnregisterAnimal(Entities.AnimalBase animal)
        {
            animals.Remove(animal);
        }

        private void UpdateMetrics()
        {
            totalPopulation = animals.Count;
            if (totalPopulation == 0) return;

            float mood = 0f, hunger = 0f, fear = 0f;
            foreach (var a in animals)
            {
                mood += a.mood;
                hunger += a.hunger;
                fear += a.fear;
            }

            averageMood = mood / totalPopulation;
            averageHunger = hunger / totalPopulation;
            averageFear = fear / totalPopulation;
        }
    }
}