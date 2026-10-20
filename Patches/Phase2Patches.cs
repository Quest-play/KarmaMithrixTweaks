using EntityStates.BrotherMonster;
using EntityStates.Missions.BrotherEncounter;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;

namespace KarmaMithrixTweaks.Patches
{
    public static class Phase2Patches
    {
        [HarmonyPatch(typeof(Phase2), "KarmaDeathPizza")]
        [HarmonyPrefix]
        public static bool KarmaDeathPizzaPrefix()
        {
            if (!ModConfig.Phase2DeathPizzasEnabled.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(GiftItem), "SendItemServer")]
        [HarmonyPrefix]
        public static bool GiftItemSendItemServerPrefix()
        {
            if (!ModConfig.Phase2ThroneGiftItemsEnabled.Value)
            {
                return false;
            }

            return true;
        }
    }
}
