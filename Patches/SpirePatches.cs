using EntityStates.BrotherMonster;
using EntityStates.BrotherMonster.KarmaSpire;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using RoR2;
using UnityEngine;

namespace KarmaMithrixTweaks.Patches
{
    public static class SpirePatches
    {
        [HarmonyPatch(typeof(CharacterMaster), nameof(CharacterMaster.GetDeployableSameSlotLimit))]
        [HarmonyPostfix]
        public static void GetDeployableLimitPostfix(DeployableSlot slot, ref int __result)
        {
            if (slot == DeployableSlot.BrotherKarmaSpire)
            {
                __result = Mathf.Max(0, ModConfig.MaxKarmicSpires.Value);
            }
        }

        [HarmonyPatch(typeof(UltChannelState), "FireWave")]
        [HarmonyPrefix]
        public static bool FireWavePrefix(bool useStationary)
        {
            if (useStationary && !ModConfig.SpiresCastPizzaDuringUlt.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(SpireBaseState), nameof(SpireBaseState.OnEnter))]
        [HarmonyPostfix]
        public static void SpireBaseStateOnEnterPostfix(SpireBaseState __instance)
        {
            if (!ModConfig.SpiresCrippleAuraEnabled.Value)
            {
                BuffWard ward = __instance.outer != null ? __instance.outer.GetComponent<BuffWard>() : null;
                if (ward != null)
                {
                    ward.Networkradius = 0f;
                    ward.enabled = false;
                }
            }
        }
    }
}
