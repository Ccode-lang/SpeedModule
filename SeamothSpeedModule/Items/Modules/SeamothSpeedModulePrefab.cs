using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using System.Collections.Generic;

namespace SpeedModule.Items.Modules
{
    public static class SeamothSpeedModulePrefab
    {
        public static void Register()
        {
            // Set item info and icon.
            var prefabInfo = PrefabInfo.WithTechType("SeamothSpeedModule", "Seamoth Speed Module", "Go 2 times faster with your Seamoth.")
                .WithIcon(SpriteManager.Get(TechType.VehicleHullModule3));
            CustomPrefab prefab = new CustomPrefab(prefabInfo);

            // Set the object model
            var clone = new CloneTemplate(prefabInfo, TechType.VehicleHullModule3);
            prefab.SetGameObject(clone);

            // Set crafting recipe
            prefab.SetRecipe(new Nautilus.Crafting.RecipeData()
            {
                craftAmount = 1,
                Ingredients = new List<CraftData.Ingredient>()
                {
                    new CraftData.Ingredient(TechType.Titanium, 6),
                }
            })
            .WithFabricatorType(CraftTree.Type.SeamothUpgrades);

            // Module settings
            prefab.SetVehicleUpgradeModule(EquipmentType.SeamothModule, QuickSlotType.Passive)
                // Reset depth upgrade
                .WithDepthUpgrade(200f, true)
                .WithOnModuleAdded(SpeedModule.Utils.SeamothSpeed)
                .WithOnModuleRemoved(SpeedModule.Utils.ResetSpeed);
            // Register prefab
            prefab.Register();
        }
    }
}