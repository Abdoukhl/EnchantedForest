using System.Collections.Generic;
using UnityEngine;

namespace EnchantedForest.AI.UtilityAI
{
    public class UtilityEvaluator
    {
        public UtilityAction Evaluate(List<UtilityAction> actions, Entities.AnimalBase animal)
        {
            UtilityAction bestAction = null;
            float bestScore = float.MinValue;

            foreach (var action in actions)
            {
                float score = action.EvaluateScore(animal) * action.weight;
                if (score > bestScore)
                {
                    bestScore = score;
                    bestAction = action;
                }
            }

            return bestAction;
        }
    }
}