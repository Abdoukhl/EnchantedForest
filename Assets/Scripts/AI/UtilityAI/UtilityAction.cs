using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    public abstract class UtilityAction : ScriptableObject
    {
        public string actionName;
        [Range(0f, 1f)] public float weight = 1f;

        public abstract float EvaluateScore(Entities.AnimalBase animal);
        public abstract void Execute(Entities.AnimalBase animal);
    }
}