using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using System.Collections.Generic;

namespace SpeedModule.Items.Modules
{
    public static class PrawnSpeedModulePrefab
    {
        public static void Register()
        {
            // Set item info and icon.
            var prefabInfo = PrefabInfo.WithTechType("PrawnSpeedModule", "Prawn suit Speed Module", "Go two times faster with your Prawn suit.")
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
            prefab.SetVehicleUpgradeModule(EquipmentType.ExosuitModule, QuickSlotType.Passive)
                // Reset depth upgrade
                .WithDepthUpgrade(900f, true)
                .WithOnModuleAdded(SpeedModule.Utils.DoubleSpeed)
                .WithOnModuleRemoved(SpeedModule.Utils.ResetSpeed);
            // Register prefab
            prefab.Register();
        }
    }
}