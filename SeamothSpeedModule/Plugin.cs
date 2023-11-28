using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SpeedModule.Items.Modules;
using System.Reflection;
using MoreCyclopsUpgrades.API;
using SpeedModule.Items.Handlers;


namespace SpeedModule
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    [BepInDependency("com.mrpurple6411.MoreCyclopsUpgrades", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        internal CyclopsSpeedModule CyclopsModule { get; private set; }

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {
            SeamothSpeedModulePrefab.Register();
            PrawnSpeedModulePrefab.Register();

            this.CyclopsModule = new CyclopsSpeedModule();
            this.CyclopsModule.Patch();
            MCUServices.Register.CyclopsUpgradeHandler((SubRoot cyclops) => new CyclopsSpeedModuleHandler(this.CyclopsModule.TechType, cyclops));
        }
    }
}