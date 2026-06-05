using UnityEngine;

namespace EnchantedForest.Core
{
    public class AnimalSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        public GameObject rabbitPrefab;
        public int maxRabbits = 5;
        public float spawnInterval = 8f;

        private float timer = 0f;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnRabbit();
            }
        }

        private void SpawnRabbit()
        {
            if (EcosystemManager.Instance == null) return;

            int current = 0;
            foreach (var a in EcosystemManager.Instance.animals)
                if (a is Entities.Rabbit) current++;

            if (current >= maxRabbits) return;

            float x = Random.Range(-7f, 7f);
            float y = Random.Range(-3f, 3f);
            Instantiate(rabbitPrefab, new Vector3(x, y, 0), Quaternion.identity);
            Debug.Log("Spawned a new Rabbit!");
        }
    }
}