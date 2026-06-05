using System.Collections.Generic;

namespace EnchantedForest.AI.BehaviorTree
{
    public class BTSequence : BTNode
    {
        private List<BTNode> children = new List<BTNode>();

        public BTSequence(List<BTNode> children)
        {
            this.children = children;
        }

        public override BTStatus Evaluate(Entities.AnimalBase animal)
        {
            foreach (var child in children)
            {
                var status = child.Evaluate(animal);
                if (status != BTStatus.Success) return status;
            }
            return BTStatus.Success;
        }
    }
}