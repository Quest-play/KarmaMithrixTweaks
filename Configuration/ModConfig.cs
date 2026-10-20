using BepInEx.Configuration;

namespace KarmaMithrixTweaks.Configuration
{
    public static class ModConfig
    {
        // Karma 1
        public static ConfigEntry<bool> SuperArmorPhase1Enabled { get; private set; }
        public static ConfigEntry<bool> SuperArmorPhase3Enabled { get; private set; }
        public static ConfigEntry<bool> SuperArmorPhase4Enabled { get; private set; }
        public static ConfigEntry<float> SuperArmorBuffDuration { get; private set; }
        public static ConfigEntry<float> SuperArmorHealthThreshold { get; private set; }
        public static ConfigEntry<float> SuperArmorDamageMultiplier { get; private set; }

        // Karma 2
        public static ConfigEntry<bool> Karma2StatBuffEnabled { get; private set; }
        public static ConfigEntry<bool> SkyLeapGravZoneEnabled { get; private set; }
        public static ConfigEntry<bool> SkyLeapCardinalBombsEnabled { get; private set; }
        public static ConfigEntry<bool> SlideSpikeCrystalsEnabled { get; private set; }
        public static ConfigEntry<bool> Phase2ThroneGiftItemsEnabled { get; private set; }

        // Karma 3
        public static ConfigEntry<bool> Phase2DeathPizzasEnabled { get; private set; }

        // Karma 4
        public static ConfigEntry<bool> PassiveMobileUltPhase1Enabled { get; private set; }
        public static ConfigEntry<bool> PassiveMobileUltPhase3Enabled { get; private set; }
        public static ConfigEntry<bool> PassiveHurtUltPhase4Enabled { get; private set; }

        // Karma 5
        public static ConfigEntry<int> MaxKarmicSpires { get; private set; }
        public static ConfigEntry<bool> SpiresCastPizzaDuringUlt { get; private set; }
        public static ConfigEntry<bool> SpiresCrippleAuraEnabled { get; private set; }

        // Karma 6
        public static ConfigEntry<bool> SlideHomingBombsEnabled { get; private set; }

        // Karma 7
        public static ConfigEntry<bool> Karma7DamageScalingEnabled { get; private set; }

        // Karma 8
        public static ConfigEntry<float> Karma8HealthMultiplier { get; private set; }

        public static void Init(ConfigFile config)
        {
            SuperArmorPhase1Enabled = config.Bind(
                "Karma 1",
                "SuperArmor_Phase1_Enabled",
                true,
                "Enable Super-Armor shell during Phase 1. In vanilla, taking 10% max HP damage grants a 5-second DamageReduction shell."
            );

            SuperArmorPhase3Enabled = config.Bind(
                "Karma 1",
                "SuperArmor_Phase3_Enabled",
                true,
                "Enable Super-Armor shell during Phase 3."
            );

            SuperArmorPhase4Enabled = config.Bind(
                "Karma 1",
                "SuperArmor_Phase4_Enabled",
                false,
                "Enable Super-Armor shell during Phase 4."
            );

            SuperArmorBuffDuration = config.Bind(
                "Karma 1",
                "SuperArmor_BuffDuration",
                2.0f,
                new ConfigDescription(
                    "Duration (in seconds) of the DamageReduction buff when triggered. Vanilla is 5.0 seconds.",
                    new AcceptableValueRange<float>(0.1f, 10.0f)
                )
            );

            SuperArmorHealthThreshold = config.Bind(
                "Karma 1",
                "SuperArmor_HealthThreshold",
                0.20f,
                new ConfigDescription(
                    "Fraction of total HP Mithrix must lose before triggering Super-Armor. 0.20 = 20% max HP. Vanilla is 0.10 (10%).",
                    new AcceptableValueRange<float>(0.01f, 1.0f)
                )
            );

            SuperArmorDamageMultiplier = config.Bind(
                "Karma 1",
                "SuperArmor_DamageMultiplier",
                0.50f,
                new ConfigDescription(
                    "Incoming damage multiplier while Super-Armor buff is active. 0.50 = -50% damage taken. In vanilla this is 0.10 (-90% damage taken)",
                    new AcceptableValueRange<float>(0.05f, 1.0f)
                )
            );

            Karma2StatBuffEnabled = config.Bind(
                "Karma 2",
                "StatBuff_SpeedAttack_Enabled",
                true,
                "If true, Mithrix gains +30% movement speed and +30% attack speed at Karma 2 or higher. Set to false to remove this speed increase."
            );

            SkyLeapGravZoneEnabled = config.Bind(
                "Karma 2",
                "SkyLeap_GravZone_Enabled",
                true,
                "If true, Sky Leap generates a gravity vortex pulling players towards the center. Vanilla is true."
            );

            SkyLeapCardinalBombsEnabled = config.Bind(
                "Karma 2",
                "SkyLeap_CardinalBombs_Enabled",
                true,
                "If true, Sky Leap places delayed bombs that detonate into shockwave rings. Vanilla is true."
            );

            SlideSpikeCrystalsEnabled = config.Bind(
                "Karma 2",
                "Slide_SpikeCrystals_Enabled",
                true,
                "If true, Mithrix leaves crystal spikes behind his slide dash. Vanilla is true."
            );

            Phase2ThroneGiftItemsEnabled = config.Bind(
                "Karma 2",
                "Phase2_ThroneGiftItems_Enabled",
                true,
                "If true, the throne gifts items to living monsters. Vanilla is true."
            );

            Phase2DeathPizzasEnabled = config.Bind(
                "Karma 3",
                "Phase2_DeathPizzas_Enabled",
                false,
                "If true, every Lunar Chimera killed in Phase 2 detonates at its death position. Vanilla is true."
            );

            PassiveMobileUltPhase1Enabled = config.Bind(
                "Karma 4",
                "PassiveMobileUlt_Phase1_Enabled",
                false,
                "If true, Mithrix can passively charge and cast his Ultimate while running around in Phase 1. Vanilla is true."
            );

            PassiveMobileUltPhase3Enabled = config.Bind(
                "Karma 4",
                "PassiveMobileUlt_Phase3_Enabled",
                false,
                "If true, Mithrix can passively charge and cast his Ultimate while running around in Phase 3 Vanilla is true."
            );

            PassiveHurtUltPhase4Enabled = config.Bind(
                "Karma 4",
                "PassiveHurtUlt_Phase4_Enabled",
                false,
                "If true, Mithrix can passively charge and cast his Ultimate while crawling in Phase 4 when below low HP threshold. Vanilla is true."
            );

            MaxKarmicSpires = config.Bind(
                "Karma 5",
                "MaxKarmicSpires",
                3,
                new ConfigDescription(
                    "Maximum number of Karmic Spires that Mithrix can deploy at start of Phase 3 / after Pizza. Vanilla is 6.",
                    new AcceptableValueRange<int>(0, 12)
                )
            );

            SpiresCastPizzaDuringUlt = config.Bind(
                "Karma 5",
                "SpiresCastPizzaDuringUlt",
                false,
                "If true, active Karmic Spires cast stationary pizza waves."
            );

            SpiresCrippleAuraEnabled = config.Bind(
                "Karma 5",
                "SpiresCrippleAura_Enabled",
                true,
                "If true, Karmic Spires project a widening Cripple aura"
            );

            SlideHomingBombsEnabled = config.Bind(
                "Karma 6",
                "Slide_HomingBombs_Enabled",
                true,
                "If true, Mithrix launches a 500% damage homing bomb upon performing a slide dash. Vanilla is true."
            );

            Karma7DamageScalingEnabled = config.Bind(
                "Karma 7",
                "DamageScaling_Enabled",
                true,
                "If true, Mithrix gains +1% bonus damage per Karma level."
            );

            Karma8HealthMultiplier = config.Bind(
                "Karma 8",
                "HealthBonus_Multiplier",
                1.50f,
                new ConfigDescription(
                    "Max HP multiplier for Mithrix at Karma 8. Vanilla is 1.50 (+50% health). Set to 1.0 for no health increase.",
                    new AcceptableValueRange<float>(1.0f, 3.0f)
                )
            );
        }
    }
}
