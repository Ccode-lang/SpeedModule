using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Crafting;
using Nautilus.Extensions;
using System.Collections.Generic;
using UnityEngine;
using Ingredient = CraftData.Ingredient;

namespace SeamothSpeedModule.Items.Modules
{
    public static class SeamothSpeedModulePrefab
    {
        public static void Register()
        {
            // Set item info and icon.
            var prefabInfo = PrefabInfo.WithTechType("SeamothSpeedModule", "Seamoth Speed Module", "Go two times faster with your Seamoth.")
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
                .WithOnModuleAdded((Vehicle vehicleInstance, int slotId) =>
                {
                    vehicleInstance.forwardForce = 26f;
                    vehicleInstance.backwardForce = 10f;
                    vehicleInstance.sidewardForce = 23f;
                    vehicleInstance.verticalForce = 22f;
                }).WithOnModuleRemoved((Vehicle vehicleInstance, int slotId) =>
                {
                    vehicleInstance.forwardForce = 13f;
                    vehicleInstance.backwardForce = 5f;
                    vehicleInstance.sidewardForce = 11.5f;
                    vehicleInstance.verticalForce = 11f;
                });
            // Register prefab
            prefab.Register();
        }
    }
}