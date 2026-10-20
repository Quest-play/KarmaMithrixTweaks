# KarmaMithrixTweaks

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

**KarmaMithrixTweaks** is a customizable balance mod that provides individual configuration settings for each **Karma Level (1 to 8)**.

---

## Multiplayer: Host-Only & Vanilla Compatible

* **Host-Only:** The mod only needs to be installed by the player who **hosts (creates)** the lobby.
* **Vanilla Compatible:** Other players **do NOT need the mod** or BepInEx installed. They can join on a completely unmodified game, and all custom settings will apply to everyone in the lobby.

---

## ⚙️ Configuration

Generated after running the game once with the mod installed.

### `[Karma 1]`
In vanilla, taking 10% max HP damage grants a 5-second DamageReduction shell that reduces all incoming damage to 1.
* `SuperArmor_Phase1_Enabled` (`true`): Enable Super-Armor in Phase 1.
* `SuperArmor_Phase3_Enabled` (`true`): Enable Super-Armor in Phase 3.
* `SuperArmor_Phase4_Enabled` (`false`): Disabled Super-Armor in Phase 4.
* `SuperArmor_BuffDuration` (`2.0`, vanilla `5.0`): Duration of the shell in seconds.
* `SuperArmor_HealthThreshold` (`0.20`, vanilla `0.10`): Fraction of max HP lost to trigger armor (0.20 = 20%).
* `SuperArmor_DamageMultiplier` (`0.50`, vanilla `0.10`): Damage multiplier during shell.

### `[Karma 2]`
* `StatBuff_SpeedAttack_Enabled` (`true`): Mithrix gains +30% movement and attack speed.
* `SkyLeap_GravZone_Enabled` (`true`): Center gravity vortex during Sky Leap.
* `SkyLeap_CardinalBombs_Enabled` (`true`): Shockwave bombs on Sky Leap landing.
* `Slide_SpikeCrystals_Enabled` (`true`): Crystal spikes behind slide dash.
* `Phase2_ThroneGiftItems_Enabled` (`true`): Throne gifts items to living monsters.

### `[Karma 3]`
* `Phase2_DeathPizzas_Enabled` (`false`, vanilla `true`): Slain Lunar Chimeras in Phase 2 detonate at their death location.

### `[Karma 4]`
* `PassiveMobileUlt_Phase1_Enabled` (`false`, vanilla `true`): Mithrix charges and casts Ult on the move in Phase 1.
* `PassiveMobileUlt_Phase3_Enabled` (`false`, vanilla `true`): Mithrix charges and casts Ult on the move in Phase 3.
* `PassiveHurtUlt_Phase4_Enabled` (`false`, vanilla `true`): Mithrix passively charges and casts Ult while crawling in Phase 4.

### `[Karma 5]`
* `MaxKarmicSpires` (`3`, vanilla `6`): Maximum number of active Karmic Spires.
* `SpiresCastPizzaDuringUlt` (`false`, vanilla `true`): Controls whether living spires cast stationary pizza waves.
* `SpiresCrippleAura_Enabled` (`true`): Spires project a Cripple aura.

### `[Karma 6]`
* `Slide_HomingBombs_Enabled` (`true`): Mithrix fires a 500% damage homing bomb on slide dash.

### `[Karma 7]`
* `DamageScaling_Enabled` (`true`): Mithrix gains +1% bonus damage per Karma level.

### `[Karma 8]`
* `HealthBonus_Multiplier` (`1.50`, range `1.0 - 3.0`): Max HP multiplier for Mithrix at Karma 8 (1.50 = +50% health, set to 1.0 for vanilla base health).

---

## 📦 Installation

1. Install [BepInEx](https://thunderstore.io/package/bbepis/BepInExPack/).
2. Place `KarmaMithrixTweaks.dll` into your `Risk of Rain 2/BepInEx/plugins/` directory.
