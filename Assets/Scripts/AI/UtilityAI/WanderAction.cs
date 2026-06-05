using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    [CreateAssetMenu(fileName = "WanderAction", menuName = "EnchantedForest/Actions/Wander")]
    public class WanderAction : UtilityAction
    {
        public override float EvaluateScore(Entities.AnimalBase animal)
        {
            return 1f - Mathf.Max(animal.hunger, animal.thirst, animal.fear);
        }

        public override void Execute(Entities.AnimalBase animal)
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            animal.Move(direction);
        }
    }
}
