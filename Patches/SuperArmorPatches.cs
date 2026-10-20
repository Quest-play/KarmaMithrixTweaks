using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using RoR2;
using UnityEngine;

namespace KarmaMithrixTweaks.Patches
{
    public static class SuperArmorPatches
    {
        [HarmonyPatch(typeof(BrotherSuperArmorController), "OnDamageDealtServer")]
        [HarmonyPrefix]
        public static bool OnDamageDealtServerPrefix(BrotherSuperArmorController __instance, DamageReport dmgReport)
        {
            int phase = PhaseCounter.instance ? PhaseCounter.instance.phase : 1;
            if (__instance.gameObject != null && __instance.gameObject.name.Contains("BrotherHurt"))
            {
                phase = 4;
            }

            bool isEnabled = phase switch
            {
                1 => ModConfig.SuperArmorPhase1Enabled.Value,
                3 => ModConfig.SuperArmorPhase3Enabled.Value,
                4 => ModConfig.SuperArmorPhase4Enabled.Value,
                _ => true
            };

            if (!isEnabled)
            {
                return false;
            }

            __instance.buffDuration = ModConfig.SuperArmorBuffDuration.Value;
            __instance.healthThreshold = ModConfig.SuperArmorHealthThreshold.Value;

            return true;
        }

        [HarmonyPatch(typeof(HealthComponent), nameof(HealthComponent.TakeDamage))]
        [HarmonyPrefix]
        public static void TakeDamagePrefix(HealthComponent __instance, DamageInfo damageInfo)
        {
            if (damageInfo == null || __instance == null || __instance.body == null)
            {
                return;
            }

            CharacterBody body = __instance.body;
            if (BrotherKarmaUtils.IsBrother(body) || body.name.Contains("Brother"))
            {
                if (body.HasBuff(DLC4Content.Buffs.DamageReduction))
                {
                    float targetMultiplier = Mathf.Clamp(ModConfig.SuperArmorDamageMultiplier.Value, 0.01f, 1.0f);
                    if (Mathf.Abs(targetMultiplier - 0.10f) > 0.001f)
                    {
                        damageInfo.damage *= (targetMultiplier / 0.10f);
                    }
                }
            }
        }
    }
}
