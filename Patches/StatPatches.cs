using System;
using System.Reflection;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using RoR2;
using UnityEngine;

namespace KarmaMithrixTweaks.Patches
{
    public static class StatPatches
    {
        private static Action<CharacterBody, float> _setMaxHealth;
        private static Action<CharacterBody, float> _setMoveSpeed;
        private static Action<CharacterBody, float> _setAttackSpeed;
        private static Action<CharacterBody, float> _setDamage;

        static StatPatches()
        {
            var propMaxHealth = typeof(CharacterBody).GetProperty(nameof(CharacterBody.maxHealth), BindingFlags.Public | BindingFlags.Instance);
            if (propMaxHealth?.GetSetMethod(true) != null)
            {
                _setMaxHealth = (Action<CharacterBody, float>)Delegate.CreateDelegate(typeof(Action<CharacterBody, float>), propMaxHealth.GetSetMethod(true));
            }

            var propMoveSpeed = typeof(CharacterBody).GetProperty(nameof(CharacterBody.moveSpeed), BindingFlags.Public | BindingFlags.Instance);
            if (propMoveSpeed?.GetSetMethod(true) != null)
            {
                _setMoveSpeed = (Action<CharacterBody, float>)Delegate.CreateDelegate(typeof(Action<CharacterBody, float>), propMoveSpeed.GetSetMethod(true));
            }

            var propAttackSpeed = typeof(CharacterBody).GetProperty(nameof(CharacterBody.attackSpeed), BindingFlags.Public | BindingFlags.Instance);
            if (propAttackSpeed?.GetSetMethod(true) != null)
            {
                _setAttackSpeed = (Action<CharacterBody, float>)Delegate.CreateDelegate(typeof(Action<CharacterBody, float>), propAttackSpeed.GetSetMethod(true));
            }

            var propDamage = typeof(CharacterBody).GetProperty(nameof(CharacterBody.damage), BindingFlags.Public | BindingFlags.Instance);
            if (propDamage?.GetSetMethod(true) != null)
            {
                _setDamage = (Action<CharacterBody, float>)Delegate.CreateDelegate(typeof(Action<CharacterBody, float>), propDamage.GetSetMethod(true));
            }
        }

        [HarmonyPatch(typeof(CharacterBody), nameof(CharacterBody.RecalculateStats))]
        [HarmonyPostfix]
        public static void RecalculateStatsPostfix(CharacterBody __instance)
        {
            if (!BrotherKarmaUtils.IsBrother(__instance))
            {
                return;
            }

            int karma = KarmaManager.instance ? KarmaManager.instance.GetEffectiveKarma() : 0;
            if (karma <= 0)
            {
                return;
            }

            if (karma >= 2 && !ModConfig.Karma2StatBuffEnabled.Value)
            {
                if (_setMoveSpeed != null) _setMoveSpeed(__instance, __instance.moveSpeed / 1.3f);
                if (_setAttackSpeed != null) _setAttackSpeed(__instance, __instance.attackSpeed / 1.3f);
            }

            if (!ModConfig.Karma7DamageScalingEnabled.Value)
            {
                if (_setDamage != null) _setDamage(__instance, __instance.damage / (float)(1.0 + 0.01 * (double)karma));
            }

            if (karma >= 8 && _setMaxHealth != null)
            {
                float targetMult = Mathf.Clamp(ModConfig.Karma8HealthMultiplier.Value, 1.0f, 3.0f);
                if (Mathf.Abs(targetMult - 1.5f) > 0.01f)
                {
                    _setMaxHealth(__instance, (__instance.maxHealth / 1.5f) * targetMult);
                }
            }
        }
    }
}
