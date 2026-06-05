using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    [CreateAssetMenu(fileName = "EatAction", menuName = "EnchantedForest/Actions/Eat")]
    public class EatAction : UtilityAction
    {
        public override float EvaluateScore(Entities.AnimalBase animal)
        {
            return animal.hunger;
        }

        public override void Execute(Entities.AnimalBase animal)
        {
            animal.hunger -= 0.3f * Time.deltaTime;
            animal.hunger = Mathf.Clamp01(animal.hunger);
            Debug.Log($"{animal.animalName} is eating. Hunger: {animal.hunger:F2}");
        }
    }
}