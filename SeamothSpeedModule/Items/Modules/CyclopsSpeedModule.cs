using MoreCyclopsUpgrades.API.Upgrades;
using Nautilus.Crafting;
using Nautilus.Handlers;
using System.Collections;
using UnityEngine;

namespace SpeedModule.Items.Modules
{
    internal class CyclopsSpeedModule : CyclopsUpgrade
    {
        public override CraftTree.Type FabricatorType { get; } = CraftTree.Type.CyclopsFabricator;
        public override IEnumerator GetGameObjectAsync(IOut<GameObject> gameObject)
        {
            TaskResult<GameObject> task = new TaskResult<GameObject>();
            yield return base.GetGameObjectAsync(task);
            GameObject obj = task.Get();
            gameObject.Set(obj);
            yield break;
        }
        public override TechType RequiredForUnlock { get; } = TechType.Cyclops;
        public override string[] StepsToFabricatorTab { get; } = new string[]
        {
            "CyclopsMenu"
        };

        protected override RecipeData GetBlueprintRecipe()
        {
            return new RecipeData
            {
                craftAmount = 1,
                Ingredients =
                {
                    new CraftData.Ingredient(TechType.PlasteelIngot, 2),
                    new CraftData.Ingredient(TechType.PowerCell, 1)
                }
            };
        }
        public override float CraftingTime
        {
            get
            {
                return 12f;
            }
        }
        internal CyclopsSpeedModule() : base("CyclopsSpeedModule", "Cyclops Speed Module", "Make your cyclops go 2 times faster.") {}
    }
}
