using UnityEngine;

namespace EnchantedForest.Entities
{
    public class Rabbit : AnimalBase
    {
        [Header("Rabbit Settings")]
        public float fleeSpeed = 4f;
        public float fleeDistance = 3f;

        private Vector2 wanderTarget;
        private float wanderTimer = 0f;
        private float wanderInterval = 3f;

        protected override void Awake()
        {
            base.Awake();
            animalName = "Rabbit";
            animalType = AnimalType.Herbivore;
            moveSpeed = 2f;
            SetNewWanderTarget();
        }

        protected override void Update()
        {
            base.Update();
            Wander();
        }

        private void Wander()
        {
            wanderTimer += Time.deltaTime;

            if (wanderTimer >= wanderInterval)
            {
                SetNewWanderTarget();
                wanderTimer = 0f;
            }

            Vector2 direction = (wanderTarget - (Vector2)transform.position).normalized;
            Move(direction);
        }

        private void SetNewWanderTarget()
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(-4f, 4f);
            wanderTarget = new Vector2(x, y);
            wanderInterval = Random.Range(2f, 5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, fleeDistance);
        }
    }
}