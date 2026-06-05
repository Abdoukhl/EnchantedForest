using UnityEngine;
using UnityEngine.UI;

namespace EnchantedForest.UI
{
    public class EcosystemUI : MonoBehaviour
    {
        [Header("UI Elements")]
        public Text populationText;
        public Text avgMoodText;
        public Text avgHungerText;
        public Text avgFearText;

        private void Update()
        {
            if (Core.EcosystemManager.Instance == null) return;

            var eco = Core.EcosystemManager.Instance;

            if (populationText) populationText.text = $"Population: {eco.totalPopulation}";
            if (avgMoodText) avgMoodText.text = $"Avg Mood: {eco.averageMood:F2}";
            if (avgHungerText) avgHungerText.text = $"Avg Hunger: {eco.averageHunger:F2}";
            if (avgFearText) avgFearText.text = $"Avg Fear: {eco.averageFear:F2}";
        }
    }
}