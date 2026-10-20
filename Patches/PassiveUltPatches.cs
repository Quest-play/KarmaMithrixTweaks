using HarmonyLib;
using KarmaMithrixTweaks.Configuration;
using RoR2;

namespace KarmaMithrixTweaks.Patches
{
    public static class PassiveUltPatches
    {
        [HarmonyPatch(typeof(EntityStates.BrotherMonster.Weapon.Idle), nameof(EntityStates.BrotherMonster.Weapon.Idle.FixedUpdate))]
        [HarmonyPrefix]
        public static bool WeaponIdleFixedUpdatePrefix()
        {
            int phase = PhaseCounter.instance ? PhaseCounter.instance.phase : 1;
            if (phase == 1 && !ModConfig.PassiveMobileUltPhase1Enabled.Value)
            {
                return false;
            }

            if (phase == 3 && !ModConfig.PassiveMobileUltPhase3Enabled.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(EntityStates.BrotherMonster.Weapon.IdleHurt), nameof(EntityStates.BrotherMonster.Weapon.IdleHurt.FixedUpdate))]
        [HarmonyPrefix]
        public static bool WeaponIdleHurtFixedUpdatePrefix()
        {
            if (!ModConfig.PassiveHurtUltPhase4Enabled.Value)
            {
                return false;
            }

            return true;
        }
    }
}
