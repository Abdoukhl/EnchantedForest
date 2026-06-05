using System.Collections.Generic;
using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    public class UtilityController : MonoBehaviour
    {
        public List<UtilityAction> actions = new List<UtilityAction>();

        private UtilityEvaluator evaluator = new UtilityEvaluator();
        private Entities.AnimalBase animal;
        private float tickRate = 0.5f;
        private float timer = 0f;

        private void Awake()
        {
            animal = GetComponent<Entities.AnimalBase>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= tickRate)
            {
                timer = 0f;
                Tick();
            }
        }

        private void Tick()
        {
            if (animal == null || actions.Count == 0) return;
            UtilityAction best = evaluator.Evaluate(actions, animal);
            best?.Execute(animal);
        }
    }
}