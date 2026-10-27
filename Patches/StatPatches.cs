using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using RoR2;
using UnityEngine;

namespace KarmaMithrixTweaks.Patches
{
    public static class StatPatches
    {
        public static float GetKarma8HealthMultiplier()
        {
            return Mathf.Clamp(ModConfig.Karma8HealthMultiplier.Value, 1.0f, 3.0f);
        }

        public static float GetKarma2SpeedMultiplier()
        {
            return ModConfig.Karma2StatBuffEnabled.Value ? 1.3f : 1.0f;
        }

        public static double GetKarma7DamageScaling()
        {
            return ModConfig.Karma7DamageScalingEnabled.Value ? 0.01 : 0.0;
        }

        [HarmonyPatch(typeof(CharacterBody), nameof(CharacterBody.RecalculateStats))]
        [HarmonyTranspiler]
        public static IEnumerable<CodeInstruction> RecalculateStatsTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            var matcher = new CodeMatcher(instructions);

            var maxKarmaField = AccessTools.Field(typeof(KarmaManager), nameof(KarmaManager.maxKarma));
            if (maxKarmaField == null)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Failed to find KarmaManager.maxKarma field!");
                return instructions;
            }

            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldsfld, maxKarmaField));
            if (matcher.IsInvalid)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Could not find KarmaManager.maxKarma in RecalculateStats IL!");
                return instructions;
            }

            int maxKarmaPos = matcher.Pos;

            matcher.MatchForward(false, new CodeMatch(OpCodes.Ldc_R4, 1.5f));
            if (matcher.IsInvalid)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Could not find health 1.5f in RecalculateStats IL!");
                return instructions;
            }
            matcher.SetInstruction(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StatPatches), nameof(GetKarma8HealthMultiplier))));

            matcher.Start().Advance(maxKarmaPos);
            matcher.MatchBack(false, new CodeMatch(OpCodes.Ldc_R4, 1.3f));
            if (matcher.IsInvalid)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Could not find attackSpeed 1.3f in RecalculateStats IL!");
                return instructions;
            }
            matcher.SetInstruction(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StatPatches), nameof(GetKarma2SpeedMultiplier))));

            matcher.MatchBack(false, new CodeMatch(OpCodes.Ldc_R4, 1.3f));
            if (matcher.IsInvalid)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Could not find moveSpeed 1.3f in RecalculateStats IL!");
                return instructions;
            }
            matcher.SetInstruction(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StatPatches), nameof(GetKarma2SpeedMultiplier))));

            matcher.MatchBack(false, new CodeMatch(OpCodes.Ldc_R8, 0.01));
            if (matcher.IsInvalid)
            {
                KarmaMithrixTweaksPlugin.Log.LogError("StatPatches: Could not find damage scaling 0.01 in RecalculateStats IL!");
                return instructions;
            }
            matcher.SetInstruction(new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(StatPatches), nameof(GetKarma7DamageScaling))));

            return matcher.InstructionEnumeration();
        }
    }
}
