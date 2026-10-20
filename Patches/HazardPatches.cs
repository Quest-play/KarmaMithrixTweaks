using EntityStates.BrotherMonster;
using HarmonyLib;
using KarmaMithrixTweaks.Configuration;

namespace KarmaMithrixTweaks.Patches
{
    public static class HazardPatches
    {
        [HarmonyPatch(typeof(BaseSlideState), "AttemptFireHomingBombAuthority")]
        [HarmonyPrefix]
        public static bool SlideHomingBombPrefix()
        {
            if (!ModConfig.SlideHomingBombsEnabled.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(BaseSlideState), "AttemptFireCrystalsAuthority")]
        [HarmonyPrefix]
        public static bool SlideSpikeCrystalsPrefix()
        {
            if (!ModConfig.SlideSpikeCrystalsEnabled.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(EnterSkyLeap), "AttemptFireGravZoneAuthority")]
        [HarmonyPrefix]
        public static bool SkyLeapGravZonePrefix()
        {
            if (!ModConfig.SkyLeapGravZoneEnabled.Value)
            {
                return false;
            }

            return true;
        }

        [HarmonyPatch(typeof(EnterSkyLeap), "AttemptFireSkyLeapBombsAuthority")]
        [HarmonyPrefix]
        public static bool SkyLeapCardinalBombsPrefix()
        {
            if (!ModConfig.SkyLeapCardinalBombsEnabled.Value)
            {
                return false;
            }

            return true;
        }
    }
}
