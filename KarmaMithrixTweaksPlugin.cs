using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using KarmaMithrixTweaks.Patches;

namespace KarmaMithrixTweaks
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class KarmaMithrixTweaksPlugin : BaseUnityPlugin
    {
        public const string PluginGUID = "ua.quest-play.karmamithrixtweaks";
        public const string PluginName = "KarmaMithrixTweaks";
        public const string PluginVersion = "1.0.0";

        public static ManualLogSource Log { get; private set; }
        private Harmony _harmony;

        private void Awake()
        {
            Log = Logger;

            ModConfig.Init(Config);

            Log.LogInfo($"Initializing {PluginName} v{PluginVersion}...");

            _harmony = new Harmony(PluginGUID);
            _harmony.PatchAll(typeof(SuperArmorPatches));
            _harmony.PatchAll(typeof(SpirePatches));
            _harmony.PatchAll(typeof(PassiveUltPatches));
            _harmony.PatchAll(typeof(Phase2Patches));
            _harmony.PatchAll(typeof(HazardPatches));
            _harmony.PatchAll(typeof(StatPatches));

            Log.LogInfo($"{PluginName} v{PluginVersion} loaded successfully with per-Karma-level customizations!");
        }

        private void OnDestroy()
        {
            _harmony?.UnpatchSelf();
        }
    }
}
