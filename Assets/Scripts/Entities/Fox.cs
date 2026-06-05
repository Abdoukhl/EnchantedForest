using UnityEngine;

namespace EnchantedForest.Entities
{
    public class Fox : AnimalBase
    {
        [Header("Fox Settings")]
        public float huntRadius = 6f;
        public float huntSpeed = 4f;

        private Transform prey;
        private Vector2 wanderTarget;
        private float wanderTimer = 0f;
        private float wanderInterval = 3f;

        protected override void Awake()
        {
            base.Awake();
            animalName = "Fox";
            animalType = AnimalType.Carnivore;
            moveSpeed = 3f;
            SetNewWanderTarget();
        }

        protected override void Update()
        {
            base.Update();

            if (hunger > 0.6f)
                Hunt();
            else
                Wander();
        }

        private void Hunt()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, huntRadius);
            prey = null;

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<Rabbit>(out _))
                {
                    prey = hit.transform;
                    break;
                }
            }

            if (prey != null)
            {
                Vector2 direction = ((Vector2)prey.position - (Vector2)transform.position).normalized;
                Move(direction * huntSpeed / moveSpeed);
                Debug.Log($"{animalName} is hunting!");
            }
            else
            {
                Wander();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<Rabbit>(out Rabbit rabbit))
            {
                hunger -= 0.5f;
                hunger = Mathf.Clamp01(hunger);
                Debug.Log($"{animalName} ate a rabbit! Hunger: {hunger:F2}");
                rabbit.Die();
            }
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
            wanderTarget = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            wanderInterval = Random.Range(2f, 5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, huntRadius);
        }
    }
}