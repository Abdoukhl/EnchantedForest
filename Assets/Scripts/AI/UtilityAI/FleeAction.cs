using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    [CreateAssetMenu(fileName = "FleeAction", menuName = "EnchantedForest/Actions/Flee")]
    public class FleeAction : UtilityAction
    {
        public override float EvaluateScore(Entities.AnimalBase animal)
        {
            return animal.fear;
        }

        public override void Execute(Entities.AnimalBase animal)
        {
            Vector2 fleeDirection = Random.insideUnitCircle.normalized;
            animal.Move(fleeDirection * 2f);
            Debug.Log($"{animal.animalName} is fleeing! Fear: {animal.fear:F2}");
        }
    }
}