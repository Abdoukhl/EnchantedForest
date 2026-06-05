using System.Collections.Generic;

namespace EnchantedForest.AI.BehaviorTree
{
    public class BTSelector : BTNode
    {
        private List<BTNode> children = new List<BTNode>();

        public BTSelector(List<BTNode> children)
        {
            this.children = children;
        }

        public override BTStatus Evaluate(Entities.AnimalBase animal)
        {
            foreach (var child in children)
            {
                var status = child.Evaluate(animal);
                if (status == BTStatus.Success) return BTStatus.Success;
            }
            return BTStatus.Failure;
        }
    }
}