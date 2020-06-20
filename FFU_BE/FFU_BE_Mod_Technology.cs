#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108

using MonoMod;
using System.Collections.Generic;
using UnityEngine;
using RST;
using HarmonyLib;
using FFU_Bleeding_Edge;
using System.Linq;
using RST.UI;
using System.Text;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Technology {
		public static void InstantiateNewModuleInSlot(ShipModule newModule, ModuleSlotRoot slotRoot) {
			Instantiate moduleCreator = slotRoot.ModuleCreator;
			moduleCreator.DoDestroy();
			moduleCreator.Prefab = newModule.gameObject;
			moduleCreator.DoInstantiate();
		}
		public static void ApplyInitialModuleTier(ShipModule shipModule) {
			int rolledTier = Random.Range(2, 6);
			Core.BonusMod rolledMod = GetInitialModuleModifier(shipModule);
			if (shipModule != null) if (shipModule.type == ShipModule.Type.Container) rolledMod = Core.BonusMod.Durable;
			if (shipModule != null) if (shipModule.type == ShipModule.Type.MaterialsConverter) rolledMod = Core.BonusMod.Enhanced;
			if (shipModule != null) if (shipModule.type == ShipModule.Type.MaterialsConverter || shipModule.type == ShipModule.Type.Container) rolledTier = 5;
			if (!shipModule.name.Contains("MK-") || !ModuleHasModifier(shipModule)) SetModuleModifier(shipModule, rolledTier, rolledMod);
			if (shipModule.name.Contains("MK-") && ModuleHasModifier(shipModule)) ApplyModuleModifiedStatsAndParameters(shipModule);
		}
		public static void ApplyPlayerModuleTier(ShipModule shipModule) {
			int rolledTier = Mathf.Clamp(GetCraftedTier(), 1, 10);
			Core.BonusMod rolledMod = GetPlayerModuleModifier(shipModule);
			if (!shipModule.name.Contains("MK-") || !ModuleHasModifier(shipModule)) SetModuleModifier(shipModule, rolledTier, rolledMod);
			if (shipModule.name.Contains("MK-") && ModuleHasModifier(shipModule)) ApplyModuleModifiedStatsAndParameters(shipModule);
		}
		public static void ApplySectorModuleTier(ShipModule shipModule) {
			int sectorTechLevel = GetSectorTechLevel();
			Core.BonusMod rolledMod = GetRandomModuleModifier(shipModule);
			int rolledTier = Mathf.Clamp(Random.Range(sectorTechLevel - 1, sectorTechLevel + 2), 1, 10);
			if (!shipModule.name.Contains("MK-") || !ModuleHasModifier(shipModule)) SetModuleModifier(shipModule, rolledTier, rolledMod);
			if (shipModule.name.Contains("MK-") && ModuleHasModifier(shipModule)) ApplyModuleModifiedStatsAndParameters(shipModule);
		}
		public static void ApplyEnemyModuleTier(ShipModule shipModule) {
			int enemyTechLevel = GetEnemyTechLevel();
			Core.BonusMod rolledMod = GetEnemyModuleModifier(shipModule);
			int rolledTier = Mathf.Clamp(Random.Range(enemyTechLevel - 1, enemyTechLevel + 2), 1, 10);
			if (!shipModule.name.Contains("MK-") || !ModuleHasModifier(shipModule)) SetModuleModifier(shipModule, rolledTier, rolledMod);
			if (shipModule.name.Contains("MK-") && ModuleHasModifier(shipModule)) ApplyModuleModifiedStatsAndParameters(shipModule);
		}
		public static void ApplyCustomModuleTier(ShipModule shipModule, int moduleTier = 1, Core.BonusMod moduleMod = Core.BonusMod.None) {
			SetModuleModifier(shipModule, moduleTier, moduleMod);
			ApplyModuleModifiedStatsAndParameters(shipModule);
		}
		public static Core.BonusMod GetInitialModuleModifier(ShipModule shipModule) {
			float initLimit = 0.50f;
			switch (FFU_BE_Defs.GetDifficultySetting()) {
				case 1: initLimit = 0.25f; break;
				case 2: initLimit = 0.50f; break;
				case 3: initLimit = 0.75f; break;
			}
			float rolledValue = RstRandom.Range(0f, 1f);
			if (rolledValue >= initLimit) return GetRandomPositiveBonus(shipModule);
			else return Core.BonusMod.None;
		}
		public static Core.BonusMod GetPlayerModuleModifier(ShipModule shipModule) {
			float negLimit = 0.25f;
			float posLimit = 0.50f;
			switch(FFU_BE_Defs.GetDifficultySetting()) {
				case 1: negLimit = 0.10f; posLimit = 0.25f; break;
				case 2: negLimit = 0.25f; posLimit = 0.50f; break;
				case 3: negLimit = 0.50f; posLimit = 0.75f; break;
			}
			float rolledValue = FFU_BE_Defs.GetModuleCraftingProficiency(shipModule) * 0.5f + RstRandom.Range(0f, 1f) * 0.5f;
			if (rolledValue >= 0f && rolledValue <= negLimit) return GetRandomNegativeBonus(shipModule);
			else if (rolledValue >= posLimit && rolledValue <= 1f) return GetRandomPositiveBonus(shipModule);
			else return Core.BonusMod.None;
		}
		public static Core.BonusMod GetRandomModuleModifier(ShipModule shipModule) {
			float rolledValue = RstRandom.Range(0f, 1f);
			if (rolledValue >= 0.0f && rolledValue <= 0.3f) return GetRandomNegativeBonus(shipModule);
			else if (rolledValue >= 0.7f && rolledValue <= 1.0f) return GetRandomPositiveBonus(shipModule);
			else return Core.BonusMod.None;
		}
		public static Core.BonusMod GetEnemyModuleModifier(ShipModule shipModule) {
			float negLimit = 0.35f;
			float posLimit = 0.75f;
			switch (FFU_BE_Defs.GetDifficultySetting()) {
				case 1: negLimit = 0.50f; posLimit = 0.90f; break;
				case 2: negLimit = 0.35f; posLimit = 0.75f; break;
				case 3: negLimit = 0.15f; posLimit = 0.15f; break;
			}
			int enemyTechLevel = GetEnemyTechLevel();
			int enemyForceLevel = FFU_BE_Defs.discoveryFleetsLevel + 1;
			int chosenTechLevel = enemyTechLevel > enemyForceLevel ? enemyTechLevel : enemyForceLevel;
			float rolledValue = RstRandom.Range(0f, 1f) * 0.5f + chosenTechLevel / 20f;
			if (rolledValue >= 0f && rolledValue <= negLimit) return GetRandomNegativeBonus(shipModule);
			else if (rolledValue >= posLimit && rolledValue <= 1f) return GetRandomPositiveBonus(shipModule);
			else return Core.BonusMod.None;
		}
		public static int GetPlayerTechLevel() {
			int techLevel = 1;
			float techPoints = FFU_BE_Defs.researchProgress;
			if (techPoints > FFU_BE_Defs.techLevel[1]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[2]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[3]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[4]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[5]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[6]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[7]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[8]) techLevel++;
			if (techPoints > FFU_BE_Defs.techLevel[9]) techLevel++;
			return techLevel;
		}
		public static int GetSectorTechLevel() {
			return Mathf.Clamp(Sector.Instance.number, 1, 10);
		}
		public static int GetEnemyTechLevel() {
			return (int)Mathf.Clamp(Mathf.Max((GetPlayerTechLevel() + GetSectorTechLevel()) / 2f + 0.49999f, FFU_BE_Defs.discoveryFleetsLevel + 1), 1f, 10f);
		}
		public static string GetCraftChanceText() {
			float researchValue = FFU_BE_Defs.researchProgress;
			if (researchValue > FFU_BE_Defs.techLevel[0] && researchValue <= FFU_BE_Defs.techLevel[1]) {
				return "MK-I: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-II: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[1] && researchValue <= FFU_BE_Defs.techLevel[2]) {
				return "MK-II: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-III: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[2] && researchValue <= FFU_BE_Defs.techLevel[3]) {
				return "MK-III: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-IV: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[3] && researchValue <= FFU_BE_Defs.techLevel[4]) {
				return "MK-IV: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-V: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[4] && researchValue <= FFU_BE_Defs.techLevel[5]) {
				return "MK-V: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-VI: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[5] && researchValue <= FFU_BE_Defs.techLevel[6]) {
				return "MK-VI: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-VII: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[6] && researchValue <= FFU_BE_Defs.techLevel[7]) {
				return "MK-VII: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-VIII: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[7] && researchValue <= FFU_BE_Defs.techLevel[8]) {
				return "MK-VIII: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-IX: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[8] && researchValue <= FFU_BE_Defs.techLevel[9]) {
				return "MK-IX: " + string.Format("{0:0}", GetPrevTierChance(researchValue) * 100f) + "% / " + "MK-X: " + string.Format("{0:0}", GetNextTierChance(researchValue) * 100f) + "%";
			} else if (researchValue > FFU_BE_Defs.techLevel[9]) return "MK-IX: 0% / MK-X: 100%";
			return "MK-I: 100% / MK-II: 0%";
		}
		public static float GetPrevTierChance(float researchValue) {
			if (researchValue > FFU_BE_Defs.techLevel[0] && researchValue <= FFU_BE_Defs.techLevel[1]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[0]) / (FFU_BE_Defs.techLevel[1] - FFU_BE_Defs.techLevel[0]);
			} else if (researchValue > FFU_BE_Defs.techLevel[1] && researchValue <= FFU_BE_Defs.techLevel[2]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[1]) / (FFU_BE_Defs.techLevel[2] - FFU_BE_Defs.techLevel[1]);
			} else if (researchValue > FFU_BE_Defs.techLevel[2] && researchValue <= FFU_BE_Defs.techLevel[3]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[2]) / (FFU_BE_Defs.techLevel[3] - FFU_BE_Defs.techLevel[2]);
			} else if (researchValue > FFU_BE_Defs.techLevel[3] && researchValue <= FFU_BE_Defs.techLevel[4]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[3]) / (FFU_BE_Defs.techLevel[4] - FFU_BE_Defs.techLevel[3]);
			} else if (researchValue > FFU_BE_Defs.techLevel[4] && researchValue <= FFU_BE_Defs.techLevel[5]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[4]) / (FFU_BE_Defs.techLevel[5] - FFU_BE_Defs.techLevel[4]);
			} else if (researchValue > FFU_BE_Defs.techLevel[5] && researchValue <= FFU_BE_Defs.techLevel[6]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[5]) / (FFU_BE_Defs.techLevel[6] - FFU_BE_Defs.techLevel[5]);
			} else if (researchValue > FFU_BE_Defs.techLevel[6] && researchValue <= FFU_BE_Defs.techLevel[7]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[6]) / (FFU_BE_Defs.techLevel[7] - FFU_BE_Defs.techLevel[6]);
			} else if (researchValue > FFU_BE_Defs.techLevel[7] && researchValue <= FFU_BE_Defs.techLevel[8]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[7]) / (FFU_BE_Defs.techLevel[8] - FFU_BE_Defs.techLevel[7]);
			} else if (researchValue > FFU_BE_Defs.techLevel[8] && researchValue <= FFU_BE_Defs.techLevel[9]) {
				return 1 - (researchValue - FFU_BE_Defs.techLevel[8]) / (FFU_BE_Defs.techLevel[9] - FFU_BE_Defs.techLevel[8]);
			} else if (researchValue > FFU_BE_Defs.techLevel[9]) return 0f;
			return 1f;
		}
		public static float GetNextTierChance(float researchValue) {
			if (researchValue > FFU_BE_Defs.techLevel[0] && researchValue <= FFU_BE_Defs.techLevel[1]) {
				return (researchValue - FFU_BE_Defs.techLevel[0]) / (FFU_BE_Defs.techLevel[1] - FFU_BE_Defs.techLevel[0]);
			} else if (researchValue > FFU_BE_Defs.techLevel[1] && researchValue <= FFU_BE_Defs.techLevel[2]) {
				return (researchValue - FFU_BE_Defs.techLevel[1]) / (FFU_BE_Defs.techLevel[2] - FFU_BE_Defs.techLevel[1]);
			} else if (researchValue > FFU_BE_Defs.techLevel[2] && researchValue <= FFU_BE_Defs.techLevel[3]) {
				return (researchValue - FFU_BE_Defs.techLevel[2]) / (FFU_BE_Defs.techLevel[3] - FFU_BE_Defs.techLevel[2]);
			} else if (researchValue > FFU_BE_Defs.techLevel[3] && researchValue <= FFU_BE_Defs.techLevel[4]) {
				return (researchValue - FFU_BE_Defs.techLevel[3]) / (FFU_BE_Defs.techLevel[4] - FFU_BE_Defs.techLevel[3]);
			} else if (researchValue > FFU_BE_Defs.techLevel[4] && researchValue <= FFU_BE_Defs.techLevel[5]) {
				return (researchValue - FFU_BE_Defs.techLevel[4]) / (FFU_BE_Defs.techLevel[5] - FFU_BE_Defs.techLevel[4]);
			} else if (researchValue > FFU_BE_Defs.techLevel[5] && researchValue <= FFU_BE_Defs.techLevel[6]) {
				return (researchValue - FFU_BE_Defs.techLevel[5]) / (FFU_BE_Defs.techLevel[6] - FFU_BE_Defs.techLevel[5]);
			} else if (researchValue > FFU_BE_Defs.techLevel[6] && researchValue <= FFU_BE_Defs.techLevel[7]) {
				return (researchValue - FFU_BE_Defs.techLevel[6]) / (FFU_BE_Defs.techLevel[7] - FFU_BE_Defs.techLevel[6]);
			} else if (researchValue > FFU_BE_Defs.techLevel[7] && researchValue <= FFU_BE_Defs.techLevel[8]) {
				return (researchValue - FFU_BE_Defs.techLevel[7]) / (FFU_BE_Defs.techLevel[8] - FFU_BE_Defs.techLevel[7]);
			} else if (researchValue > FFU_BE_Defs.techLevel[8] && researchValue <= FFU_BE_Defs.techLevel[9]) {
				return (researchValue - FFU_BE_Defs.techLevel[8]) / (FFU_BE_Defs.techLevel[9] - FFU_BE_Defs.techLevel[8]);
			} else if (researchValue > FFU_BE_Defs.techLevel[9]) return 1f;
			return 0f;
		}
		public static int GetCraftedTier() {
			float researchValue = FFU_BE_Defs.researchProgress;
			if (researchValue > FFU_BE_Defs.techLevel[0] && researchValue <= FFU_BE_Defs.techLevel[1]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[0]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[0]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 2 : 1;
			} else if (researchValue > FFU_BE_Defs.techLevel[1] && researchValue <= FFU_BE_Defs.techLevel[2]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[1]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[1]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 3 : 2;
			} else if (researchValue > FFU_BE_Defs.techLevel[2] && researchValue <= FFU_BE_Defs.techLevel[3]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[2]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[2]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 4 : 3;
			} else if (researchValue > FFU_BE_Defs.techLevel[3] && researchValue <= FFU_BE_Defs.techLevel[4]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[3]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[3]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 5 : 4;
			} else if (researchValue > FFU_BE_Defs.techLevel[4] && researchValue <= FFU_BE_Defs.techLevel[5]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[4]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[4]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 6 : 5;
			} else if (researchValue > FFU_BE_Defs.techLevel[5] && researchValue <= FFU_BE_Defs.techLevel[6]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[5]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[5]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 7 : 6;
			} else if (researchValue > FFU_BE_Defs.techLevel[6] && researchValue <= FFU_BE_Defs.techLevel[7]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[6]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[6]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 8 : 7;
			} else if (researchValue > FFU_BE_Defs.techLevel[7] && researchValue <= FFU_BE_Defs.techLevel[8]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[7]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[7]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 9 : 8;
			} else if (researchValue > FFU_BE_Defs.techLevel[8] && researchValue <= FFU_BE_Defs.techLevel[9]) {
				float prevTierChance = (researchValue - FFU_BE_Defs.techLevel[8]) * GetPrevTierChance(researchValue) * Random.Range(0f, 1f);
				float nextTierChance = (researchValue - FFU_BE_Defs.techLevel[8]) * GetNextTierChance(researchValue) * Random.Range(0f, 1f);
				return (nextTierChance > prevTierChance) ? 10 : 9;
			} else if (researchValue > FFU_BE_Defs.techLevel[9]) return 10;
			return 1;
		}
		public static void SetModuleModifier(ShipModule shipModule, int moduleTier, Core.BonusMod moduleMod = Core.BonusMod.None) {
			if (!FFU_BE_Defs.IsAllowedModuleCategory(shipModule)) return;
			if (!shipModule.name.Contains("MK-")) {
				if (moduleTier == 10) shipModule.name += "MK-X";
				else if (moduleTier == 9) shipModule.name += "MK-IX";
				else if (moduleTier == 8) shipModule.name += "MK-VIII";
				else if (moduleTier == 7) shipModule.name += "MK-VII";
				else if (moduleTier == 6) shipModule.name += "MK-VI";
				else if (moduleTier == 5) shipModule.name += "MK-V";
				else if (moduleTier == 4) shipModule.name += "MK-IV";
				else if (moduleTier == 3) shipModule.name += "MK-III";
				else if (moduleTier == 2) shipModule.name += "MK-II";
				else if (moduleTier == 1) shipModule.name += "MK-I";
				else shipModule.name += " " + "MK-I";
			}
			if (!ModuleHasModifier(shipModule)) switch (moduleMod) {
					case Core.BonusMod.None: shipModule.name += "(None)"; break;
					case Core.BonusMod.Sustained: shipModule.name += "(Sustained)"; break;
					case Core.BonusMod.Unstable: shipModule.name += "(Unstable)"; break;
					case Core.BonusMod.Reinforced: shipModule.name += "(Reinforced)"; break;
					case Core.BonusMod.Fragile: shipModule.name += "(Fragile)"; break;
					case Core.BonusMod.Efficient: shipModule.name += "(Efficient)"; break;
					case Core.BonusMod.Inefficient: shipModule.name += "(Inefficient)"; break;
					case Core.BonusMod.Precise: shipModule.name += "(Precise)"; break;
					case Core.BonusMod.Inhibited: shipModule.name += "(Inhibited)"; break;
					case Core.BonusMod.Rapid: shipModule.name += "(Rapid)"; break;
					case Core.BonusMod.Disrupted: shipModule.name += "(Disrupted)"; break;
					case Core.BonusMod.Enhanced: shipModule.name += "(Enhanced)"; break;
					case Core.BonusMod.Deficient: shipModule.name += "(Deficient)"; break;
					case Core.BonusMod.Durable: shipModule.name += "(Durable)"; break;
					case Core.BonusMod.Brittle: shipModule.name += "(Brittle)"; break;
					case Core.BonusMod.Persistent: shipModule.name += "(Persistent)"; break;
					case Core.BonusMod.Volatile: shipModule.name += "(Volatile)"; break;
					default: shipModule.name += "(None)"; break;
				}
		}
		public static bool ModuleHasModifier(ShipModule shipModule) {
			if (shipModule.name.Contains("(None)")) return true;
			else if (shipModule.name.Contains("(Sustained)")) return true;
			else if (shipModule.name.Contains("(Reinforced)")) return true;
			else if (shipModule.name.Contains("(Efficient)")) return true;
			else if (shipModule.name.Contains("(Precise)")) return true;
			else if (shipModule.name.Contains("(Rapid)")) return true;
			else if (shipModule.name.Contains("(Enhanced)")) return true;
			else if (shipModule.name.Contains("(Durable)")) return true;
			else if (shipModule.name.Contains("(Persistent)")) return true;
			else if (shipModule.name.Contains("(Unstable)")) return true;
			else if (shipModule.name.Contains("(Fragile)")) return true;
			else if (shipModule.name.Contains("(Inefficient)")) return true;
			else if (shipModule.name.Contains("(Inhibited)")) return true;
			else if (shipModule.name.Contains("(Disrupted)")) return true;
			else if (shipModule.name.Contains("(Deficient)")) return true;
			else if (shipModule.name.Contains("(Brittle)")) return true;
			else if (shipModule.name.Contains("(Volatile)")) return true;
			else return false;
		}
		public static Core.BonusMod GetModuleModifier(ShipModule shipModule) {
			if (shipModule.name.Contains("(None)")) return Core.BonusMod.None;
			else if (shipModule.name.Contains("(Sustained)")) return Core.BonusMod.Sustained;
			else if (shipModule.name.Contains("(Reinforced)")) return Core.BonusMod.Reinforced;
			else if (shipModule.name.Contains("(Efficient)")) return Core.BonusMod.Efficient;
			else if (shipModule.name.Contains("(Precise)")) return Core.BonusMod.Precise;
			else if (shipModule.name.Contains("(Rapid)")) return Core.BonusMod.Rapid;
			else if (shipModule.name.Contains("(Enhanced)")) return Core.BonusMod.Enhanced;
			else if (shipModule.name.Contains("(Durable)")) return Core.BonusMod.Durable;
			else if (shipModule.name.Contains("(Persistent)")) return Core.BonusMod.Persistent;
			else if (shipModule.name.Contains("(Unstable)")) return Core.BonusMod.Unstable;
			else if (shipModule.name.Contains("(Fragile)")) return Core.BonusMod.Fragile;
			else if (shipModule.name.Contains("(Inefficient)")) return Core.BonusMod.Inefficient;
			else if (shipModule.name.Contains("(Inhibited)")) return Core.BonusMod.Inhibited;
			else if (shipModule.name.Contains("(Disrupted)")) return Core.BonusMod.Disrupted;
			else if (shipModule.name.Contains("(Deficient)")) return Core.BonusMod.Deficient;
			else if (shipModule.name.Contains("(Brittle)")) return Core.BonusMod.Brittle;
			else if (shipModule.name.Contains("(Volatile)")) return Core.BonusMod.Volatile;
			else return Core.BonusMod.None;
		}
		public static Core.BonusTier GetModuleTier(ShipModule shipModule) {
			if (shipModule.name.Contains("MK-X")) return Core.BonusTier.MK_X;
			else if (shipModule.name.Contains("MK-IX")) return Core.BonusTier.MK_IX;
			else if (shipModule.name.Contains("MK-VIII")) return Core.BonusTier.MK_VIII;
			else if (shipModule.name.Contains("MK-VII")) return Core.BonusTier.MK_VII;
			else if (shipModule.name.Contains("MK-VI")) return Core.BonusTier.MK_VI;
			else if (shipModule.name.Contains("MK-V")) return Core.BonusTier.MK_V;
			else if (shipModule.name.Contains("MK-IV")) return Core.BonusTier.MK_IV;
			else if (shipModule.name.Contains("MK-III")) return Core.BonusTier.MK_III;
			else if (shipModule.name.Contains("MK-II")) return Core.BonusTier.MK_II;
			else if (shipModule.name.Contains("MK-I")) return Core.BonusTier.MK_I;
			else return Core.BonusTier.NONE;
		}
		public static string GetModuleTierText(ShipModule shipModule) {
			if (shipModule.name.Contains("MK-X")) return "MK-X";
			else if (shipModule.name.Contains("MK-IX")) return "MK-IX";
			else if (shipModule.name.Contains("MK-VIII")) return "MK-VIII";
			else if (shipModule.name.Contains("MK-VII")) return "MK-VII";
			else if (shipModule.name.Contains("MK-VI")) return "MK-VI";
			else if (shipModule.name.Contains("MK-V")) return "MK-V";
			else if (shipModule.name.Contains("MK-IV")) return "MK-IV";
			else if (shipModule.name.Contains("MK-III")) return "MK-III";
			else if (shipModule.name.Contains("MK-II")) return "MK-II";
			else if (shipModule.name.Contains("MK-I")) return "MK-I";
			else return "";
		}
		public static string GetModuleModColoredText(ShipModule shipModule) {
			Core.BonusMod moduleMod = GetModuleModifier(shipModule);
			switch (moduleMod) {
				case Core.BonusMod.Sustained: return "<color=lime>(S↑)</color> ";
				case Core.BonusMod.Unstable: return "<color=red>(S↓)</color> ";
				case Core.BonusMod.Reinforced: return "<color=lime>(H↑)</color> ";
				case Core.BonusMod.Fragile: return "<color=red>(H↓)</color> ";
				case Core.BonusMod.Efficient: return "<color=lime>(R↑)</color> ";
				case Core.BonusMod.Inefficient: return "<color=red>(R↓)</color> ";
				case Core.BonusMod.Precise: return "<color=lime>(A↑)</color> ";
				case Core.BonusMod.Inhibited: return "<color=red>(A↓)</color> ";
				case Core.BonusMod.Rapid: return "<color=lime>(F↑)</color> ";
				case Core.BonusMod.Disrupted: return "<color=red>(F↓)</color> ";
				case Core.BonusMod.Enhanced: return "<color=lime>(E↑)</color> ";
				case Core.BonusMod.Deficient: return "<color=red>(E↓)</color> ";
				case Core.BonusMod.Durable: return "<color=lime>(C↑)</color> ";
				case Core.BonusMod.Brittle: return "<color=red>(C↓)</color> ";
				case Core.BonusMod.Persistent: return "<color=lime>(P↑)</color> ";
				case Core.BonusMod.Volatile: return "<color=red>(P↓)</color> ";
				default: return "";
			}
		}
		public static string GetTierCodeText(int moduleTier) {
			switch (moduleTier) {
				case 1: return "MK-I";
				case 2: return "MK-II";
				case 3: return "MK-III";
				case 4: return "MK-IV";
				case 5: return "MK-V";
				case 6: return "MK-VI";
				case 7: return "MK-VII";
				case 8: return "MK-VIII";
				case 9: return "MK-IX";
				case 10: return "MK-X";
				default: return "MK-I";
			}
		}
		public static Core.BonusMod GetRandomPositiveBonus(ShipModule shipModule) {
			List<Core.BonusMod> posModsList = new List<Core.BonusMod>();
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Precise);
				posModsList.Add(Core.BonusMod.Rapid);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.Weapon_Nuke:
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Enhanced);
				posModsList.Add(Core.BonusMod.Durable);
				break;
				case ShipModule.Type.PointDefence:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Rapid);
				break;
				case ShipModule.Type.Bridge:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				break;
				case ShipModule.Type.Engine:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.Warp:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Rapid);
				break;
				case ShipModule.Type.Reactor:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.Container:
				case ShipModule.Type.Integrity:
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Durable);
				break;
				case ShipModule.Type.ShieldGen:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Rapid);
				posModsList.Add(Core.BonusMod.Persistent);
				break;
				case ShipModule.Type.Sensor:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.StealthDecryptor:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.PassiveECM:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Rapid);
				break;
				case ShipModule.Type.Cryosleep:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				case ShipModule.Type.ResearchLab:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				break;
				case ShipModule.Type.Garden:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				break;
				case ShipModule.Type.MaterialsConverter:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Enhanced);
				break;
				default:
				posModsList.Add(Core.BonusMod.Sustained);
				posModsList.Add(Core.BonusMod.Reinforced);
				posModsList.Add(Core.BonusMod.Efficient);
				posModsList.Add(Core.BonusMod.Precise);
				posModsList.Add(Core.BonusMod.Rapid);
				posModsList.Add(Core.BonusMod.Enhanced);
				posModsList.Add(Core.BonusMod.Durable);
				posModsList.Add(Core.BonusMod.Persistent);
				posModsList = new List<Core.BonusMod>();
				break;
			}
			return Core.RandomItemFromList(posModsList, Core.BonusMod.None);
		}
		public static Core.BonusMod GetRandomNegativeBonus(ShipModule shipModule) {
			List<Core.BonusMod> negModsList = new List<Core.BonusMod>();
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Inhibited);
				negModsList.Add(Core.BonusMod.Disrupted);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.Weapon_Nuke:
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Deficient);
				negModsList.Add(Core.BonusMod.Brittle);
				break;
				case ShipModule.Type.PointDefence:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Disrupted);
				break;
				case ShipModule.Type.Bridge:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				break;
				case ShipModule.Type.Engine:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.Warp:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Disrupted);
				break;
				case ShipModule.Type.Reactor:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.Container:
				case ShipModule.Type.Integrity:
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Brittle);
				break;
				case ShipModule.Type.ShieldGen:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Disrupted);
				negModsList.Add(Core.BonusMod.Volatile);
				break;
				case ShipModule.Type.Sensor:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.StealthDecryptor:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.PassiveECM:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Disrupted);
				break;
				case ShipModule.Type.Cryosleep:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				case ShipModule.Type.ResearchLab:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				break;
				case ShipModule.Type.Garden:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				break;
				case ShipModule.Type.MaterialsConverter:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Deficient);
				break;
				default:
				negModsList.Add(Core.BonusMod.Unstable);
				negModsList.Add(Core.BonusMod.Fragile);
				negModsList.Add(Core.BonusMod.Inefficient);
				negModsList.Add(Core.BonusMod.Inhibited);
				negModsList.Add(Core.BonusMod.Disrupted);
				negModsList.Add(Core.BonusMod.Deficient);
				negModsList.Add(Core.BonusMod.Brittle);
				negModsList.Add(Core.BonusMod.Volatile);
				negModsList = new List<Core.BonusMod>();
				break;
			}
			return Core.RandomItemFromList(negModsList, Core.BonusMod.None);
		}
		public static void ApplyModuleModifiedStatsAndParameters(ShipModule shipModule) {
			if (!FFU_BE_Defs.IsAllowedModuleCategory(shipModule)) return;
			Core.BonusTier moduleTier = GetModuleTier(shipModule);
			Core.BonusMod moduleMofidier = GetModuleModifier(shipModule);
			ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			shipModule.displayName = GetModuleModColoredText(shipModule) + refModule.displayName + " " + GetModuleTierText(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
					Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Average)), 1);
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
					Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default)), 1);
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
					Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default)), 1);
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
					Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default)), 1);
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
					Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default)), 1);
				if (refModule.Weapon.resourcesPerShot.organics > 0) shipModule.Weapon.resourcesPerShot.organics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.organics / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.resourcesPerShot.fuel > 0) shipModule.Weapon.resourcesPerShot.fuel = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.fuel / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.resourcesPerShot.metals > 0) shipModule.Weapon.resourcesPerShot.metals = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.metals / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.resourcesPerShot.synthetics > 0) shipModule.Weapon.resourcesPerShot.synthetics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.synthetics / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.resourcesPerShot.explosives > 0) shipModule.Weapon.resourcesPerShot.explosives = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.explosives / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.resourcesPerShot.exotics > 0) shipModule.Weapon.resourcesPerShot.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				if (refModule.Weapon.overrideProjectileHealth > 0) shipModule.Weapon.overrideProjectileHealth = Mathf.RoundToInt(refModule.Weapon.overrideProjectileHealth * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.reloadInterval > 0) shipModule.Weapon.reloadInterval = Mathx.RoundToFloat(refModule.Weapon.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Reduced), 1);
				if (refModule.Weapon.magazineSize > 0) shipModule.Weapon.magazineSize = Mathf.RoundToInt(refModule.Weapon.magazineSize * GetTierBonus(moduleTier, Core.BonusType.Average));
				if (refModule.Weapon.accuracy > 0) shipModule.Weapon.accuracy = Mathf.RoundToInt(refModule.Weapon.accuracy * GetTierBonus(moduleTier, Core.BonusType.Average));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.Weapon.resourcesPerShot.organics > 0) shipModule.Weapon.resourcesPerShot.organics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.organics / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.fuel > 0) shipModule.Weapon.resourcesPerShot.fuel = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.fuel / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.metals > 0) shipModule.Weapon.resourcesPerShot.metals = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.metals / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.synthetics > 0) shipModule.Weapon.resourcesPerShot.synthetics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.synthetics / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.explosives > 0) shipModule.Weapon.resourcesPerShot.explosives = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.explosives / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.exotics > 0) shipModule.Weapon.resourcesPerShot.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.Weapon.resourcesPerShot.organics > 0) shipModule.Weapon.resourcesPerShot.organics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.organics / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.fuel > 0) shipModule.Weapon.resourcesPerShot.fuel = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.fuel / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.metals > 0) shipModule.Weapon.resourcesPerShot.metals = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.metals / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.synthetics > 0) shipModule.Weapon.resourcesPerShot.synthetics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.synthetics / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.explosives > 0) shipModule.Weapon.resourcesPerShot.explosives = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.explosives / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					if (refModule.Weapon.resourcesPerShot.exotics > 0) shipModule.Weapon.resourcesPerShot.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.Weapon.resourcesPerShot.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
					break;
					case Core.BonusMod.Enhanced:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Average) * 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f), 1);
					break;
					case Core.BonusMod.Deficient:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Average) / 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f), 1);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
						Mathf.Max(Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f), 1);
					break;
					case Core.BonusMod.Precise: if (refModule.Weapon.accuracy > 0) shipModule.Weapon.accuracy = Mathf.RoundToInt(refModule.Weapon.accuracy * GetTierBonus(moduleTier, Core.BonusType.Average)) * 2; break;
					case Core.BonusMod.Inhibited: if (refModule.Weapon.accuracy > 0) shipModule.Weapon.accuracy = Mathf.RoundToInt(refModule.Weapon.accuracy * GetTierBonus(moduleTier, Core.BonusType.Average)) / 2; break;
					case Core.BonusMod.Rapid: if (refModule.Weapon.reloadInterval > 0) shipModule.Weapon.reloadInterval = Mathx.RoundToFloat(refModule.Weapon.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f, 1); break;
					case Core.BonusMod.Disrupted: if (refModule.Weapon.reloadInterval > 0) shipModule.Weapon.reloadInterval = Mathx.RoundToFloat(refModule.Weapon.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f, 1); break;
				}
				break;
				case ShipModule.Type.Weapon_Nuke:
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius =
					Mathx.RoundToFloat(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * GetTierBonus(moduleTier, Core.BonusType.Average), 2);
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
					Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
					Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
					Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
					Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
					Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Weapon.overrideProjectileHealth > 0) shipModule.Weapon.overrideProjectileHealth = Mathf.RoundToInt(refModule.Weapon.overrideProjectileHealth * GetTierBonus(moduleTier, Core.BonusType.Average));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius =
						Mathx.RoundToFloat(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * GetTierBonus(moduleTier, Core.BonusType.Average) * 1.2f, 2);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius =
						Mathx.RoundToFloat(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * GetTierBonus(moduleTier, Core.BonusType.Average) / 1.2f, 2);
					break;
					case Core.BonusMod.Enhanced:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					break;
					case Core.BonusMod.Deficient:
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0) shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg =
						Mathf.RoundToInt(refModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					break;
					case Core.BonusMod.Durable: if (refModule.Weapon.overrideProjectileHealth > 0) shipModule.Weapon.overrideProjectileHealth = Mathf.RoundToInt(refModule.Weapon.overrideProjectileHealth * GetTierBonus(moduleTier, Core.BonusType.Average) * 2f); break;
					case Core.BonusMod.Brittle: if (refModule.Weapon.overrideProjectileHealth > 0) shipModule.Weapon.overrideProjectileHealth = Mathf.RoundToInt(refModule.Weapon.overrideProjectileHealth * GetTierBonus(moduleTier, Core.BonusType.Average) / 2f); break;
				}
				break;
				case ShipModule.Type.PointDefence:
				if (refModule.PointDefence.coverRadius > 0) shipModule.PointDefence.coverRadius = Mathx.RoundToFloat(refModule.PointDefence.coverRadius * GetTierBonus(moduleTier, Core.BonusType.Reduced), 1);
				if (refModule.PointDefence.reloadInterval > 0) shipModule.PointDefence.reloadInterval = Mathx.RoundToFloat(refModule.PointDefence.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.asteroidDeflectionPercentAdd > 0) shipModule.asteroidDeflectionPercentAdd = Mathf.RoundToInt(refModule.asteroidDeflectionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Reduced));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient: if (refModule.PointDefence.coverRadius > 0) shipModule.PointDefence.coverRadius = Mathx.RoundToFloat(refModule.PointDefence.coverRadius * GetTierBonus(moduleTier, Core.BonusType.Reduced) * 1.2f, 1); break;
					case Core.BonusMod.Inefficient: if (refModule.PointDefence.coverRadius > 0) shipModule.PointDefence.coverRadius = Mathx.RoundToFloat(refModule.PointDefence.coverRadius * GetTierBonus(moduleTier, Core.BonusType.Reduced) / 1.2f, 1); break;
					case Core.BonusMod.Rapid: if (refModule.PointDefence.reloadInterval > 0) shipModule.PointDefence.reloadInterval = Mathx.RoundToFloat(refModule.PointDefence.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2); break;
					case Core.BonusMod.Disrupted: if (refModule.PointDefence.reloadInterval > 0) shipModule.PointDefence.reloadInterval = Mathx.RoundToFloat(refModule.PointDefence.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2); break;
				}
				break;
				case ShipModule.Type.Bridge:
				if (refModule.shipAccuracyPercentAdd > 0) shipModule.shipAccuracyPercentAdd = Mathf.RoundToInt(refModule.shipAccuracyPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Default));
				break;
				case ShipModule.Type.Engine:
				var refEngineConsPerDist = AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(refModule.Engine, "consumedPerDistance");
				if (refEngineConsPerDist.organics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").organics = Mathx.RoundToFloat(refEngineConsPerDist.organics / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refEngineConsPerDist.fuel > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").fuel = Mathx.RoundToFloat(refEngineConsPerDist.fuel / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refEngineConsPerDist.metals > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").metals = Mathx.RoundToFloat(refEngineConsPerDist.metals / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refEngineConsPerDist.synthetics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").synthetics = Mathx.RoundToFloat(refEngineConsPerDist.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refEngineConsPerDist.explosives > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").explosives = Mathx.RoundToFloat(refEngineConsPerDist.explosives / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refEngineConsPerDist.exotics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").exotics = Mathx.RoundToFloat(refEngineConsPerDist.exotics / GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.asteroidDeflectionPercentAdd > 0) shipModule.asteroidDeflectionPercentAdd = Mathf.RoundToInt(refModule.asteroidDeflectionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Minimal));
				if (refModule.shipEvasionPercentAdd > 0) shipModule.shipEvasionPercentAdd = Mathf.RoundToInt(refModule.shipEvasionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Minimal));
				if (refModule.starmapSpeedAdd > 0) shipModule.starmapSpeedAdd = Mathf.RoundToInt(refModule.starmapSpeedAdd * GetTierBonus(moduleTier, Core.BonusType.Reduced));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refEngineConsPerDist.organics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").organics = Mathx.RoundToFloat(refEngineConsPerDist.organics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refEngineConsPerDist.fuel > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").fuel = Mathx.RoundToFloat(refEngineConsPerDist.fuel / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refEngineConsPerDist.metals > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").metals = Mathx.RoundToFloat(refEngineConsPerDist.metals / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refEngineConsPerDist.synthetics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").synthetics = Mathx.RoundToFloat(refEngineConsPerDist.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refEngineConsPerDist.explosives > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").explosives = Mathx.RoundToFloat(refEngineConsPerDist.explosives / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refEngineConsPerDist.exotics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").exotics = Mathx.RoundToFloat(refEngineConsPerDist.exotics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					break;
					case Core.BonusMod.Inefficient:
					if (refEngineConsPerDist.organics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").organics = Mathx.RoundToFloat(refEngineConsPerDist.organics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refEngineConsPerDist.fuel > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").fuel = Mathx.RoundToFloat(refEngineConsPerDist.fuel / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refEngineConsPerDist.metals > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").metals = Mathx.RoundToFloat(refEngineConsPerDist.metals / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refEngineConsPerDist.synthetics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").synthetics = Mathx.RoundToFloat(refEngineConsPerDist.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refEngineConsPerDist.explosives > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").explosives = Mathx.RoundToFloat(refEngineConsPerDist.explosives / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refEngineConsPerDist.exotics > 0) AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance").exotics = Mathx.RoundToFloat(refEngineConsPerDist.exotics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					break;
					case Core.BonusMod.Enhanced: if (refModule.starmapSpeedAdd > 0) shipModule.starmapSpeedAdd = Mathf.RoundToInt(refModule.starmapSpeedAdd * GetTierBonus(moduleTier, Core.BonusType.Reduced) * 1.2f); break;
					case Core.BonusMod.Deficient: if (refModule.starmapSpeedAdd > 0) shipModule.starmapSpeedAdd = Mathf.RoundToInt(refModule.starmapSpeedAdd * GetTierBonus(moduleTier, Core.BonusType.Reduced) / 1.2f); break;
				}
				break;
				case ShipModule.Type.Warp:
				if (refModule.Warp.activationFuel > 0) shipModule.Warp.activationFuel = Mathf.RoundToInt(refModule.Warp.activationFuel / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Warp.reloadInterval > 0) shipModule.Warp.reloadInterval = Mathf.RoundToInt(refModule.Warp.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Average));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient: if (refModule.Warp.activationFuel > 0) shipModule.Warp.activationFuel = Mathf.RoundToInt(refModule.Warp.activationFuel / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f); break;
					case Core.BonusMod.Inefficient: if (refModule.Warp.activationFuel > 0) shipModule.Warp.activationFuel = Mathf.RoundToInt(refModule.Warp.activationFuel / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f); break;
					case Core.BonusMod.Rapid: if (refModule.Warp.reloadInterval > 0) shipModule.Warp.reloadInterval = Mathf.RoundToInt(refModule.Warp.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Average) / 2f); break;
					case Core.BonusMod.Disrupted: if (refModule.Warp.reloadInterval > 0) shipModule.Warp.reloadInterval = Mathf.RoundToInt(refModule.Warp.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Average) * 2f); break;
				}
				break;
				case ShipModule.Type.Reactor:
				if (refModule.Reactor.overchargePowerCapacityAdd > 0) shipModule.Reactor.overchargePowerCapacityAdd = Mathf.RoundToInt(refModule.Reactor.overchargePowerCapacityAdd * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Reactor.powerCapacity > 0) shipModule.Reactor.powerCapacity = Mathf.RoundToInt(refModule.Reactor.powerCapacity * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.overchargeSeconds > 0) shipModule.overchargeSeconds = Mathf.RoundToInt(refModule.overchargeSeconds * GetTierBonus(moduleTier, Core.BonusType.Default));
				switch (moduleMofidier) {
					case Core.BonusMod.Sustained:
					if (refModule.Reactor.overchargePowerCapacityAdd > 0) shipModule.Reactor.overchargePowerCapacityAdd = Mathf.RoundToInt(refModule.Reactor.overchargePowerCapacityAdd * GetTierBonus(moduleTier, Core.BonusType.Default) * 1.5f);
					if (refModule.overchargeSeconds > 0) shipModule.overchargeSeconds = Mathf.RoundToInt(refModule.overchargeSeconds * GetTierBonus(moduleTier, Core.BonusType.Default) * 3f);
					break;
					case Core.BonusMod.Unstable:
					if (refModule.Reactor.overchargePowerCapacityAdd > 0) shipModule.Reactor.overchargePowerCapacityAdd = Mathf.RoundToInt(refModule.Reactor.overchargePowerCapacityAdd * GetTierBonus(moduleTier, Core.BonusType.Default) / 1.5f);
					if (refModule.overchargeSeconds > 0) shipModule.overchargeSeconds = Mathf.RoundToInt(refModule.overchargeSeconds * GetTierBonus(moduleTier, Core.BonusType.Default) / 3f);
					break;
					case Core.BonusMod.Enhanced: if (refModule.Reactor.powerCapacity > 0) shipModule.Reactor.powerCapacity = Mathf.RoundToInt(refModule.Reactor.powerCapacity * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f); break;
					case Core.BonusMod.Deficient: if (refModule.Reactor.powerCapacity > 0) shipModule.Reactor.powerCapacity = Mathf.RoundToInt(refModule.Reactor.powerCapacity * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f); break;
				}
				break;
				case ShipModule.Type.Container:
				if (refModule.Container.MaxOrganics > 0) shipModule.Container.MaxOrganics = Mathf.RoundToInt(refModule.Container.MaxOrganics * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				if (refModule.Container.MaxFuel > 0) shipModule.Container.MaxFuel = Mathf.RoundToInt(refModule.Container.MaxFuel * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				if (refModule.Container.MaxMetals > 0) shipModule.Container.MaxMetals = Mathf.RoundToInt(refModule.Container.MaxMetals * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				if (refModule.Container.MaxSynthetics > 0) shipModule.Container.MaxSynthetics = Mathf.RoundToInt(refModule.Container.MaxSynthetics * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				if (refModule.Container.MaxExplosives > 0) shipModule.Container.MaxExplosives = Mathf.RoundToInt(refModule.Container.MaxExplosives * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				if (refModule.Container.MaxExotics > 0) shipModule.Container.MaxExotics = Mathf.RoundToInt(refModule.Container.MaxExotics * GetTierBonus(moduleTier, Core.BonusType.Extreme));
				switch (moduleMofidier) {
					case Core.BonusMod.Durable:
					if (refModule.Container.MaxOrganics > 0) shipModule.Container.MaxOrganics = Mathf.RoundToInt(refModule.Container.MaxOrganics * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					if (refModule.Container.MaxFuel > 0) shipModule.Container.MaxFuel = Mathf.RoundToInt(refModule.Container.MaxFuel * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					if (refModule.Container.MaxMetals > 0) shipModule.Container.MaxMetals = Mathf.RoundToInt(refModule.Container.MaxMetals * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					if (refModule.Container.MaxSynthetics > 0) shipModule.Container.MaxSynthetics = Mathf.RoundToInt(refModule.Container.MaxSynthetics * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					if (refModule.Container.MaxExplosives > 0) shipModule.Container.MaxExplosives = Mathf.RoundToInt(refModule.Container.MaxExplosives * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					if (refModule.Container.MaxExotics > 0) shipModule.Container.MaxExotics = Mathf.RoundToInt(refModule.Container.MaxExotics * GetTierBonus(moduleTier, Core.BonusType.Extreme) * 2f);
					break;
					case Core.BonusMod.Brittle:
					if (refModule.Container.MaxOrganics > 0) shipModule.Container.MaxOrganics = Mathf.RoundToInt(refModule.Container.MaxOrganics * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					if (refModule.Container.MaxFuel > 0) shipModule.Container.MaxFuel = Mathf.RoundToInt(refModule.Container.MaxFuel * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					if (refModule.Container.MaxMetals > 0) shipModule.Container.MaxMetals = Mathf.RoundToInt(refModule.Container.MaxMetals * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					if (refModule.Container.MaxSynthetics > 0) shipModule.Container.MaxSynthetics = Mathf.RoundToInt(refModule.Container.MaxSynthetics * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					if (refModule.Container.MaxExplosives > 0) shipModule.Container.MaxExplosives = Mathf.RoundToInt(refModule.Container.MaxExplosives * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					if (refModule.Container.MaxExotics > 0) shipModule.Container.MaxExotics = Mathf.RoundToInt(refModule.Container.MaxExotics * GetTierBonus(moduleTier, Core.BonusType.Extreme) / 2f);
					break;
				}
				break;
				case ShipModule.Type.Integrity:
				if (refModule.maxHealthAdd > 0) shipModule.maxHealthAdd = Mathf.RoundToInt(refModule.maxHealthAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted));
				if (refModule.asteroidDeflectionPercentAdd > 0) shipModule.asteroidDeflectionPercentAdd = Mathf.RoundToInt(refModule.asteroidDeflectionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Reduced));
				switch (moduleMofidier) {
					case Core.BonusMod.Durable: if (refModule.maxHealthAdd > 0) shipModule.maxHealthAdd = Mathf.RoundToInt(refModule.maxHealthAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted) * 2f); break;
					case Core.BonusMod.Brittle: if (refModule.maxHealthAdd > 0) shipModule.maxHealthAdd = Mathf.RoundToInt(refModule.maxHealthAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted) / 2f); break;
				}
				break;
				case ShipModule.Type.ShieldGen:
				if (refModule.ShieldGen.reloadInterval > 0) shipModule.ShieldGen.reloadInterval = Mathx.RoundToFloat(refModule.ShieldGen.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default), 1);
				if (refModule.ShieldGen.maxShieldAdd > 0) shipModule.ShieldGen.maxShieldAdd = Mathf.RoundToInt(refModule.ShieldGen.maxShieldAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted));
				switch (moduleMofidier) {
					case Core.BonusMod.Rapid: if (refModule.ShieldGen.reloadInterval > 0) shipModule.ShieldGen.reloadInterval = Mathx.RoundToFloat(refModule.ShieldGen.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 1); break;
					case Core.BonusMod.Disrupted: if (refModule.ShieldGen.reloadInterval > 0) shipModule.ShieldGen.reloadInterval = Mathx.RoundToFloat(refModule.ShieldGen.reloadInterval / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 1); break;
					case Core.BonusMod.Persistent: if (refModule.ShieldGen.maxShieldAdd > 0) shipModule.ShieldGen.maxShieldAdd = Mathf.RoundToInt(refModule.ShieldGen.maxShieldAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted) * 2f); break;
					case Core.BonusMod.Volatile: if (refModule.ShieldGen.maxShieldAdd > 0) shipModule.ShieldGen.maxShieldAdd = Mathf.RoundToInt(refModule.ShieldGen.maxShieldAdd * GetTierBonus(moduleTier, Core.BonusType.Boosted) / 2f); break;
				}
				break;
				case ShipModule.Type.Sensor:
				if (refModule.Sensor.sectorRadarRange > 0) shipModule.Sensor.sectorRadarRange = Mathf.RoundToInt(refModule.Sensor.sectorRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.Sensor.starmapRadarRange > 0) shipModule.Sensor.starmapRadarRange = Mathf.RoundToInt(refModule.Sensor.starmapRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.shipAccuracyPercentAdd > 0) shipModule.shipAccuracyPercentAdd = Mathf.RoundToInt(refModule.shipAccuracyPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Minimal));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient: if (refModule.Sensor.sectorRadarRange > 0) shipModule.Sensor.sectorRadarRange = Mathf.RoundToInt(refModule.Sensor.sectorRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced) * 1.5f); break;
					case Core.BonusMod.Inefficient: if (refModule.Sensor.sectorRadarRange > 0) shipModule.Sensor.sectorRadarRange = Mathf.RoundToInt(refModule.Sensor.sectorRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced) / 1.5f); break;
					case Core.BonusMod.Enhanced: if (refModule.Sensor.starmapRadarRange > 0) shipModule.Sensor.starmapRadarRange = Mathf.RoundToInt(refModule.Sensor.starmapRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced) * 1.5f); break;
					case Core.BonusMod.Deficient: if (refModule.Sensor.starmapRadarRange > 0) shipModule.Sensor.starmapRadarRange = Mathf.RoundToInt(refModule.Sensor.starmapRadarRange * GetTierBonus(moduleTier, Core.BonusType.Reduced) / 1.5f); break;
				}
				break;
				case ShipModule.Type.StealthDecryptor:
				if (refModule.shipAccuracyPercentAdd > 0) shipModule.shipAccuracyPercentAdd = Mathf.RoundToInt(refModule.shipAccuracyPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Default));
				switch (moduleMofidier) {
					case Core.BonusMod.Enhanced: if (refModule.shipAccuracyPercentAdd > 0) shipModule.shipAccuracyPercentAdd = Mathf.RoundToInt(refModule.shipAccuracyPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Default) * 1.1f); break;
					case Core.BonusMod.Deficient: if (refModule.shipAccuracyPercentAdd > 0) shipModule.shipAccuracyPercentAdd = Mathf.RoundToInt(refModule.shipAccuracyPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Default) / 1.1f); break;
				}
				break;
				case ShipModule.Type.PassiveECM:
				if (refModule.shipEvasionPercentAdd > 0) shipModule.shipEvasionPercentAdd = Mathf.RoundToInt(refModule.shipEvasionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Average));
				switch (moduleMofidier) {
					case Core.BonusMod.Enhanced: if (refModule.shipEvasionPercentAdd > 0) shipModule.shipEvasionPercentAdd = Mathf.RoundToInt(refModule.shipEvasionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Average) * 2f); break;
					case Core.BonusMod.Deficient: if (refModule.shipEvasionPercentAdd > 0) shipModule.shipEvasionPercentAdd = Mathf.RoundToInt(refModule.shipEvasionPercentAdd * GetTierBonus(moduleTier, Core.BonusType.Average) / 2f); break;
				}
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				if (refModule.Medbay.secondsPerHp > 0) shipModule.Medbay.secondsPerHp = Mathx.RoundToFloat(refModule.Medbay.secondsPerHp / GetTierBonus(moduleTier, Core.BonusType.Default), 1);
				if (refModule.Medbay.resourcesPerHp.organics > 0) shipModule.Medbay.resourcesPerHp.organics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.organics / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Medbay.resourcesPerHp.fuel > 0) shipModule.Medbay.resourcesPerHp.fuel = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.fuel / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Medbay.resourcesPerHp.metals > 0) shipModule.Medbay.resourcesPerHp.metals = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.metals / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Medbay.resourcesPerHp.synthetics > 0) shipModule.Medbay.resourcesPerHp.synthetics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Medbay.resourcesPerHp.explosives > 0) shipModule.Medbay.resourcesPerHp.explosives = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.explosives / GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Medbay.resourcesPerHp.exotics > 0) shipModule.Medbay.resourcesPerHp.exotics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.exotics / GetTierBonus(moduleTier, Core.BonusType.Default));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.Medbay.resourcesPerHp.organics > 0) shipModule.Medbay.resourcesPerHp.organics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.organics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Medbay.resourcesPerHp.fuel > 0) shipModule.Medbay.resourcesPerHp.fuel = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.fuel / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Medbay.resourcesPerHp.metals > 0) shipModule.Medbay.resourcesPerHp.metals = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.metals / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Medbay.resourcesPerHp.synthetics > 0) shipModule.Medbay.resourcesPerHp.synthetics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Medbay.resourcesPerHp.explosives > 0) shipModule.Medbay.resourcesPerHp.explosives = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.explosives / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Medbay.resourcesPerHp.exotics > 0) shipModule.Medbay.resourcesPerHp.exotics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.exotics / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.Medbay.resourcesPerHp.organics > 0) shipModule.Medbay.resourcesPerHp.organics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.organics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Medbay.resourcesPerHp.fuel > 0) shipModule.Medbay.resourcesPerHp.fuel = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.fuel / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Medbay.resourcesPerHp.metals > 0) shipModule.Medbay.resourcesPerHp.metals = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.metals / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Medbay.resourcesPerHp.synthetics > 0) shipModule.Medbay.resourcesPerHp.synthetics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.synthetics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Medbay.resourcesPerHp.explosives > 0) shipModule.Medbay.resourcesPerHp.explosives = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.explosives / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Medbay.resourcesPerHp.exotics > 0) shipModule.Medbay.resourcesPerHp.exotics = Mathx.RoundToFloat(refModule.Medbay.resourcesPerHp.exotics / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					break;
					case Core.BonusMod.Rapid: if (refModule.Medbay.secondsPerHp > 0) shipModule.Medbay.secondsPerHp = Mathx.RoundToFloat(refModule.Medbay.secondsPerHp / GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 1); break;
					case Core.BonusMod.Disrupted: if (refModule.Medbay.secondsPerHp > 0) shipModule.Medbay.secondsPerHp = Mathx.RoundToFloat(refModule.Medbay.secondsPerHp / GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 1); break;
				}
				break;
				case ShipModule.Type.Cryosleep:
				if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.minValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.minValue * GetTierBonus(moduleTier, Core.BonusType.Default));
				if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.maxValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.maxValue * GetTierBonus(moduleTier, Core.BonusType.Default));
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.minValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.minValue * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.maxValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.maxValue * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.minValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.minValue * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.creditsPerDream.maxValue = Mathf.RoundToInt(refModule.Cryosleep.creditsPerDream.maxValue * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f);
					break;
					case Core.BonusMod.Enhanced:
					if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
					if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
					break;
					case Core.BonusMod.Deficient:
					if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
					if (refModule.Cryosleep.healOneCrewHp) shipModule.Cryosleep.healOneCrewHpDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.healOneCrewHpDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.minValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.minValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
					if (refModule.Cryosleep.genDreamCredits) shipModule.Cryosleep.genDreamCreditsDistance.maxValue = Mathf.RoundToInt(refModule.Cryosleep.genDreamCreditsDistance.maxValue / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
					break;
				}
				break;
				case ShipModule.Type.ResearchLab:
				if (refModule.Research.producedPerSkillPoint.organics > 0) shipModule.Research.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.Research.producedPerSkillPoint.fuel > 0) shipModule.Research.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.Research.producedPerSkillPoint.metals > 0) shipModule.Research.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.Research.producedPerSkillPoint.synthetics > 0) shipModule.Research.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.Research.producedPerSkillPoint.explosives > 0) shipModule.Research.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.Research.producedPerSkillPoint.exotics > 0) shipModule.Research.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.Research.producedPerSkillPoint.organics > 0) shipModule.Research.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.fuel > 0) shipModule.Research.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.metals > 0) shipModule.Research.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.synthetics > 0) shipModule.Research.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.explosives > 0) shipModule.Research.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.exotics > 0) shipModule.Research.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.Research.producedPerSkillPoint.credits > 0) shipModule.Research.producedPerSkillPoint.credits = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.credits * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.Research.producedPerSkillPoint.organics > 0) shipModule.Research.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.fuel > 0) shipModule.Research.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.metals > 0) shipModule.Research.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.synthetics > 0) shipModule.Research.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.explosives > 0) shipModule.Research.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.exotics > 0) shipModule.Research.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.Research.producedPerSkillPoint.credits > 0) shipModule.Research.producedPerSkillPoint.credits = Mathx.RoundToFloat(refModule.Research.producedPerSkillPoint.credits * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					break;
				}
				break;
				case ShipModule.Type.Garden:
				if (refModule.GardenModule.producedPerSkillPoint.organics > 0) shipModule.GardenModule.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.GardenModule.producedPerSkillPoint.fuel > 0) shipModule.GardenModule.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.GardenModule.producedPerSkillPoint.metals > 0) shipModule.GardenModule.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.GardenModule.producedPerSkillPoint.synthetics > 0) shipModule.GardenModule.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.GardenModule.producedPerSkillPoint.explosives > 0) shipModule.GardenModule.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				if (refModule.GardenModule.producedPerSkillPoint.exotics > 0) shipModule.GardenModule.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default), 2);
				switch (moduleMofidier) {
					case Core.BonusMod.Efficient:
					if (refModule.GardenModule.producedPerSkillPoint.organics > 0) shipModule.GardenModule.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.fuel > 0) shipModule.GardenModule.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.metals > 0) shipModule.GardenModule.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.synthetics > 0) shipModule.GardenModule.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.explosives > 0) shipModule.GardenModule.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.exotics > 0) shipModule.GardenModule.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.credits > 0) shipModule.GardenModule.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f, 2);
					break;
					case Core.BonusMod.Inefficient:
					if (refModule.GardenModule.producedPerSkillPoint.organics > 0) shipModule.GardenModule.producedPerSkillPoint.organics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.organics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.fuel > 0) shipModule.GardenModule.producedPerSkillPoint.fuel = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.fuel * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.metals > 0) shipModule.GardenModule.producedPerSkillPoint.metals = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.metals * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.synthetics > 0) shipModule.GardenModule.producedPerSkillPoint.synthetics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.synthetics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.explosives > 0) shipModule.GardenModule.producedPerSkillPoint.explosives = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.explosives * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.exotics > 0) shipModule.GardenModule.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					if (refModule.GardenModule.producedPerSkillPoint.credits > 0) shipModule.GardenModule.producedPerSkillPoint.exotics = Mathx.RoundToFloat(refModule.GardenModule.producedPerSkillPoint.exotics * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f, 2);
					break;
				}
				break;
				case ShipModule.Type.MaterialsConverter:
				//if (refModule.MaterialsConverter.consume.credits > 0) shipModule.MaterialsConverter.consume.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.organics > 0) shipModule.MaterialsConverter.consume.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.fuel > 0) shipModule.MaterialsConverter.consume.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.metals > 0) shipModule.MaterialsConverter.consume.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.synthetics > 0) shipModule.MaterialsConverter.consume.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.explosives > 0) shipModule.MaterialsConverter.consume.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced));
				//if (refModule.MaterialsConverter.consume.exotics > 0) shipModule.MaterialsConverter.consume.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.MaterialsConverter.consume.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced)), 1f);
				//if (refModule.MaterialsConverter.produce.credits > 0) shipModule.MaterialsConverter.produce.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.organics > 0) shipModule.MaterialsConverter.produce.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.fuel > 0) shipModule.MaterialsConverter.produce.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.metals > 0) shipModule.MaterialsConverter.produce.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.synthetics > 0) shipModule.MaterialsConverter.produce.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.explosives > 0) shipModule.MaterialsConverter.produce.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//if (refModule.MaterialsConverter.produce.exotics > 0) shipModule.MaterialsConverter.produce.exotics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.exotics * GetTierBonus(moduleTier, Core.BonusType.Maximal));
				//switch (moduleMofidier) {
				//	case Core.BonusMod.Efficient:
				//	if (refModule.MaterialsConverter.consume.credits > 0) shipModule.MaterialsConverter.consume.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.organics > 0) shipModule.MaterialsConverter.consume.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.fuel > 0) shipModule.MaterialsConverter.consume.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.metals > 0) shipModule.MaterialsConverter.consume.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.synthetics > 0) shipModule.MaterialsConverter.consume.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.explosives > 0) shipModule.MaterialsConverter.consume.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.exotics > 0) shipModule.MaterialsConverter.consume.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.MaterialsConverter.consume.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
				//	break;
				//	case Core.BonusMod.Inefficient:
				//	if (refModule.MaterialsConverter.consume.credits > 0) shipModule.MaterialsConverter.consume.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.organics > 0) shipModule.MaterialsConverter.consume.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.fuel > 0) shipModule.MaterialsConverter.consume.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.metals > 0) shipModule.MaterialsConverter.consume.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.synthetics > 0) shipModule.MaterialsConverter.consume.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.explosives > 0) shipModule.MaterialsConverter.consume.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.exotics > 0) shipModule.MaterialsConverter.consume.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.MaterialsConverter.consume.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
				//	break;
				//	case Core.BonusMod.Enhanced:
				//	if (refModule.MaterialsConverter.consume.credits > 0) shipModule.MaterialsConverter.consume.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.organics > 0) shipModule.MaterialsConverter.consume.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.fuel > 0) shipModule.MaterialsConverter.consume.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.metals > 0) shipModule.MaterialsConverter.consume.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.synthetics > 0) shipModule.MaterialsConverter.consume.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.explosives > 0) shipModule.MaterialsConverter.consume.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f);
				//	if (refModule.MaterialsConverter.consume.exotics > 0) shipModule.MaterialsConverter.consume.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.MaterialsConverter.consume.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f), 1f);
				//	if (refModule.MaterialsConverter.produce.credits > 0) shipModule.MaterialsConverter.produce.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.organics > 0) shipModule.MaterialsConverter.produce.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.fuel > 0) shipModule.MaterialsConverter.produce.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.metals > 0) shipModule.MaterialsConverter.produce.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.synthetics > 0) shipModule.MaterialsConverter.produce.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.explosives > 0) shipModule.MaterialsConverter.produce.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	if (refModule.MaterialsConverter.produce.exotics > 0) shipModule.MaterialsConverter.produce.exotics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.exotics * GetTierBonus(moduleTier, Core.BonusType.Maximal) * 2f);
				//	break;
				//	case Core.BonusMod.Deficient:
				//	if (refModule.MaterialsConverter.consume.credits > 0) shipModule.MaterialsConverter.consume.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.organics > 0) shipModule.MaterialsConverter.consume.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.fuel > 0) shipModule.MaterialsConverter.consume.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.metals > 0) shipModule.MaterialsConverter.consume.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.synthetics > 0) shipModule.MaterialsConverter.consume.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.explosives > 0) shipModule.MaterialsConverter.consume.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.consume.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f);
				//	if (refModule.MaterialsConverter.consume.exotics > 0) shipModule.MaterialsConverter.consume.exotics = Mathf.Max(Mathx.RoundToFloat(refModule.MaterialsConverter.consume.exotics / GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f), 1f);
				//	if (refModule.MaterialsConverter.produce.credits > 0) shipModule.MaterialsConverter.produce.credits = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.credits * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.organics > 0) shipModule.MaterialsConverter.produce.organics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.organics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.fuel > 0) shipModule.MaterialsConverter.produce.fuel = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.fuel * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.metals > 0) shipModule.MaterialsConverter.produce.metals = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.metals * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.synthetics > 0) shipModule.MaterialsConverter.produce.synthetics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.synthetics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.explosives > 0) shipModule.MaterialsConverter.produce.explosives = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.explosives * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	if (refModule.MaterialsConverter.produce.exotics > 0) shipModule.MaterialsConverter.produce.exotics = Mathx.RoundToFloat(refModule.MaterialsConverter.produce.exotics * GetTierBonus(moduleTier, Core.BonusType.Maximal) / 2f);
				//	break;
				//}
				break;
				case ShipModule.Type.Decoy: break;
				default: return;
			}
			var refModuleMaxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			var healthLossModifier =  Mathf.Max(Mathf.Pow(1 - FFU_BE_Defs.permanentModuleDamagePercent * FFU_BE_Defs.GetDifficultyModifier(), shipModule.MaxHealthLostCount), 0.05f);
			if (shipModule.powerConsumed > 0) shipModule.powerConsumed = Mathf.RoundToInt(refModule.powerConsumed * GetTierBonus(moduleTier, Core.BonusType.Reduced));
			if (!FFU_BE_Defs.IsStaticModuleType(shipModule)) AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(refModuleMaxHealth * GetTierBonus(moduleTier, Core.BonusType.Default) * healthLossModifier);
			switch (moduleMofidier) {
				case Core.BonusMod.Sustained: if (shipModule.powerConsumed > 0) shipModule.powerConsumed = Mathf.RoundToInt(refModule.powerConsumed * GetTierBonus(moduleTier, Core.BonusType.Reduced) / 2f); break;
				case Core.BonusMod.Unstable: if (shipModule.powerConsumed > 0) shipModule.powerConsumed = Mathf.RoundToInt(refModule.powerConsumed * GetTierBonus(moduleTier, Core.BonusType.Reduced) * 2f); break;
				case Core.BonusMod.Reinforced: if (!FFU_BE_Defs.IsStaticModuleType(shipModule)) AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(refModuleMaxHealth * GetTierBonus(moduleTier, Core.BonusType.Default) * 2f * healthLossModifier); break;
				case Core.BonusMod.Fragile: if (!FFU_BE_Defs.IsStaticModuleType(shipModule)) AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(refModuleMaxHealth * GetTierBonus(moduleTier, Core.BonusType.Default) / 2f * healthLossModifier); break;
			}
			if (FFU_BE_Defs.IsStaticModuleType(shipModule)) AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = refModuleMaxHealth;
			shipModule.costCreditsInShop = Mathf.RoundToInt(refModule.costCreditsInShop * GetTierBonus(moduleTier, Core.BonusType.Extreme));
		}
		public static float GetTierBonus(Core.BonusTier bonusTier, Core.BonusType bonusType) {
			switch (bonusType) {
				case Core.BonusType.Default:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.10001f;
					case Core.BonusTier.MK_III: return 1.20001f;
					case Core.BonusTier.MK_IV: return 1.35001f;
					case Core.BonusTier.MK_V: return 1.50001f;
					case Core.BonusTier.MK_VI: return 1.70001f;
					case Core.BonusTier.MK_VII: return 1.90001f;
					case Core.BonusTier.MK_VIII: return 2.10001f;
					case Core.BonusTier.MK_IX: return 2.30001f;
					case Core.BonusTier.MK_X: return 2.50001f;
					default: return 1f;
				}
				case Core.BonusType.Average:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.05001f;
					case Core.BonusTier.MK_III: return 1.10001f;
					case Core.BonusTier.MK_IV: return 1.20001f;
					case Core.BonusTier.MK_V: return 1.30001f;
					case Core.BonusTier.MK_VI: return 1.400001f;
					case Core.BonusTier.MK_VII: return 1.55001f;
					case Core.BonusTier.MK_VIII: return 1.70001f;
					case Core.BonusTier.MK_IX: return 1.85001f;
					case Core.BonusTier.MK_X: return 2.00001f;
					default: return 1f;
				}
				case Core.BonusType.Reduced:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.05001f;
					case Core.BonusTier.MK_III: return 1.10001f;
					case Core.BonusTier.MK_IV: return 1.15001f;
					case Core.BonusTier.MK_V: return 1.20001f;
					case Core.BonusTier.MK_VI: return 1.25001f;
					case Core.BonusTier.MK_VII: return 1.30001f;
					case Core.BonusTier.MK_VIII: return 1.35001f;
					case Core.BonusTier.MK_IX: return 1.40001f;
					case Core.BonusTier.MK_X: return 1.50001f;
					default: return 1f;
				}
				case Core.BonusType.Minimal:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.02001f;
					case Core.BonusTier.MK_III: return 1.04001f;
					case Core.BonusTier.MK_IV: return 1.07001f;
					case Core.BonusTier.MK_V: return 1.10001f;
					case Core.BonusTier.MK_VI: return 1.13001f;
					case Core.BonusTier.MK_VII: return 1.16001f;
					case Core.BonusTier.MK_VIII: return 1.19001f;
					case Core.BonusTier.MK_IX: return 1.22001f;
					case Core.BonusTier.MK_X: return 1.25001f;
					default: return 1f;
				}
				case Core.BonusType.Boosted:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.20001f;
					case Core.BonusTier.MK_III: return 1.40001f;
					case Core.BonusTier.MK_IV: return 1.70001f;
					case Core.BonusTier.MK_V: return 2.00001f;
					case Core.BonusTier.MK_VI: return 2.30001f;
					case Core.BonusTier.MK_VII: return 2.60001f;
					case Core.BonusTier.MK_VIII: return 2.90001f;
					case Core.BonusTier.MK_IX: return 3.20001f;
					case Core.BonusTier.MK_X: return 3.50001f;
					default: return 1f;
				}
				case Core.BonusType.Extreme:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.40001f;
					case Core.BonusTier.MK_III: return 1.80001f;
					case Core.BonusTier.MK_IV: return 2.20001f;
					case Core.BonusTier.MK_V: return 2.60001f;
					case Core.BonusTier.MK_VI: return 3.00001f;
					case Core.BonusTier.MK_VII: return 3.50001f;
					case Core.BonusTier.MK_VIII: return 4.00001f;
					case Core.BonusTier.MK_IX: return 4.50001f;
					case Core.BonusTier.MK_X: return 5.00001f;
					default: return 1f;
				}
				case Core.BonusType.Immense:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 1.80001f;
					case Core.BonusTier.MK_III: return 2.40001f;
					case Core.BonusTier.MK_IV: return 3.00001f;
					case Core.BonusTier.MK_V: return 3.70001f;
					case Core.BonusTier.MK_VI: return 4.40001f;
					case Core.BonusTier.MK_VII: return 5.10001f;
					case Core.BonusTier.MK_VIII: return 5.90001f;
					case Core.BonusTier.MK_IX: return 6.70001f;
					case Core.BonusTier.MK_X: return 7.50001f;
					default: return 1f;
				}
				case Core.BonusType.Maximal:
				switch (bonusTier) {
					case Core.BonusTier.MK_II: return 2.00001f;
					case Core.BonusTier.MK_III: return 3.00001f;
					case Core.BonusTier.MK_IV: return 4.00001f;
					case Core.BonusTier.MK_V: return 5.00001f;
					case Core.BonusTier.MK_VI: return 6.00001f;
					case Core.BonusTier.MK_VII: return 7.00001f;
					case Core.BonusTier.MK_VIII: return 8.00001f;
					case Core.BonusTier.MK_IX: return 9.00001f;
					case Core.BonusTier.MK_X: return 10.00001f;
					default: return 1f;
				}
				default: return 1f;
			}
		}
		public static void RotateResearchListForward() {
			int firstAfterInProgress = FFU_BE_Defs.unresearchedModuleIDs[1];
			FFU_BE_Defs.unresearchedModuleIDs.RemoveAt(1);
			FFU_BE_Defs.unresearchedModuleIDs.Add(firstAfterInProgress);
		}
		public static void RotateResearchListBackward() {
			int firstAfterInProgress = FFU_BE_Defs.unresearchedModuleIDs.Last();
			FFU_BE_Defs.unresearchedModuleIDs.Remove(FFU_BE_Defs.unresearchedModuleIDs.Last());
			FFU_BE_Defs.unresearchedModuleIDs.Insert(1, firstAfterInProgress);
		}
	}
}

namespace RST {
	public class patch_ModuleSlot : ModuleSlot {
		[MonoModReplace] public bool DoCraft(ShipModule prefab) {
			if (!CanCraft(prefab)) return false;
			ModuleSlotRoot moduleSlotRoot = ModuleSlotRoot;
			Instantiate moduleCreator = moduleSlotRoot.ModuleCreator;
			moduleCreator.DoDestroy();
			moduleCreator.Prefab = prefab.gameObject;
			moduleCreator.DoInstantiate();
			ShipModule module = moduleSlotRoot.Module;
			if (!FFU_BE_Defs.IsCraftedToStorage(module)) module.Pack();
			if (!FFU_BE_Defs.IsCraftedToStorage(module)) module.StartUnpacking(true);
			FFU_BE_Mod_Modules.ApplyModuleEffects(module);
			FFU_BE_Mod_Technology.ApplyPlayerModuleTier(module);
			FFU_BE_Mod_Modules.ApplyMaxNewHealth(module);
			if (FFU_BE_Defs.IsCraftedToStorage(module)) {
				var shipStorage = PlayerDatas.Me.Flagship.Modules.Find(x => x.type == ShipModule.Type.Storage);
				if (shipStorage != null && shipStorage.Storage != null && !shipStorage.Storage.IsFull) shipStorage.Storage.AddToStorage(module.gameObject);
			}
			StringBuilder newlyCraftedItemDeployedMessage = RstShared.StringBuilder;
			string craftingConsumedResources = ""
				+ (module.craftCost.organics > 0 ? "-" + module.craftCost.organics + " organics " : "")
				+ (module.craftCost.fuel > 0 ? "-" + module.craftCost.fuel + " fuel " : "")
				+ (module.craftCost.metals > 0 ? "-" + module.craftCost.metals + " metals " : "")
				+ (module.craftCost.synthetics > 0 ? "-" + module.craftCost.synthetics + " synthetics " : "")
				+ (module.craftCost.explosives > 0 ? "-" + module.craftCost.explosives + " explosives " : "")
				+ (module.craftCost.exotics > 0 ? "-" + module.craftCost.exotics + " exotics " : "");
			if (module.craftCost.IsEmpty) craftingConsumedResources = "nothing";
			newlyCraftedItemDeployedMessage.AppendFormat(MonoBehaviourExtended.TT("Crafted {0}. Used {1}"), module.DisplayNameLocalized, craftingConsumedResources);
			StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, newlyCraftedItemDeployedMessage.ToString());
			if (FFU_BE_Defs.debugMode) Debug.LogWarning("Crafted: " + module.name + " [" + module.PrefabId + "]");
			if (prefab.Effects.unpackedPrefab != null) UnityEngine.Object.Instantiate(prefab.Effects.unpackedPrefab, base.transform.position, base.transform.rotation);
			FFU_BE_Defs.AddModuleCraftingProficiency(module);
			return true;
		}
	}
	public class patch_AddResourcesToShip : AddResourcesToShip {
		public bool DoAfterShipSpawn(Ship ship) {
		/// Apply Modified Ship Parameters on Spawn
			if (ship == null || !CheckIfConditionSatisfied(condition, ship)) return false;
			if (ship != null && ship.Ownership.GetOwner() == Ownership.Owner.Me && !FFU_BE_Defs.updatedShips.Contains(ship.InstanceId)) {
				Debug.LogWarning("Player ship spawned: [" + ship.InstanceId + "] " + ship.displayName + "! Applying initial tier upgrades...");
				foreach (Door shipDoor in ship.Doors) {
					if (FFU_BE_Defs.shipPrefabsDoorName.ContainsKey(ship.PrefabId))
						shipDoor.displayName = FFU_BE_Defs.shipPrefabsDoorName[ship.PrefabId];
					if (FFU_BE_Defs.shipPrefabsDoorHealth.ContainsKey(ship.PrefabId)) {
						AccessTools.FieldRefAccess<Door, int>(shipDoor, "maxHealth") = FFU_BE_Defs.shipPrefabsDoorHealth[ship.PrefabId];
						AccessTools.FieldRefAccess<Door, int>(shipDoor, "health") = FFU_BE_Defs.shipPrefabsDoorHealth[ship.PrefabId];
					}
				}
				foreach (ShipModule shipModule in ship.Modules) {
					if (shipModule.InstanceId > 0) {
						float healthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(shipModule);
						FFU_BE_Mod_Modules.ApplyModuleEffects(shipModule);
						FFU_BE_Mod_Modules.ApplyModuleChanges(shipModule);
						FFU_BE_Mod_Technology.ApplyInitialModuleTier(shipModule);
						FFU_BE_Mod_Modules.ApplyRelativeNewHealth(shipModule, healthPercent);
						if (shipModule.Storage != null) {
							if (FFU_BE_Defs.shipPrefabsStorageSize.ContainsKey(ship.PrefabId)) {
								FFU_BE_Defs.shipCurrentStorageCap = FFU_BE_Defs.shipPrefabsStorageSize[ship.PrefabId];
								shipModule.Storage.slotCount = FFU_BE_Defs.shipPrefabsStorageSize[ship.PrefabId];
							}
							foreach (Transform item in shipModule.Storage.storage) {
								if (FFU_BE_Defs.debugMode) Debug.LogWarning("Initial Stored Module: " + item.name);
								if (item.GetComponent<ShipModule>() != null) {
									float storedHealthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(item.GetComponent<ShipModule>());
									FFU_BE_Mod_Modules.ApplyModuleEffects(item.GetComponent<ShipModule>());
									FFU_BE_Mod_Modules.ApplyModuleChanges(item.GetComponent<ShipModule>());
									FFU_BE_Mod_Technology.ApplyInitialModuleTier(item.GetComponent<ShipModule>());
									FFU_BE_Mod_Modules.ApplyRelativeNewHealth(item.GetComponent<ShipModule>(), storedHealthPercent);
								}
							}
						}
					}
				}
				FFU_BE_Defs.researchProgress = 0f;
				FFU_BE_Defs.discoveryScanLevel = 0;
				FFU_BE_Defs.moduleResearchGoal = 0f;
				FFU_BE_Defs.discoveryFleetsLevel = 0;
				FFU_BE_Defs.moduleResearchProgress = 0f;
				FFU_BE_Defs.unresearchedModuleIDs = new List<int>();
				if (!FFU_BE_Defs.perkModuleBlueprintIDs.IsEmpty())
					foreach (int moduleID in FFU_BE_Defs.perkModuleBlueprintIDs)
						if (!FFU_BE_Defs.discoveredModuleIDs.Contains(moduleID))
							FFU_BE_Defs.unresearchedModuleIDs.Add(moduleID);
				if (FFU_BE_Defs.moduleResearchGoal == 0 && FFU_BE_Defs.unresearchedModuleIDs.Count > 0) {
					ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
					FFU_BE_Defs.moduleResearchGoal = refModule.costCreditsInShop / 10 * (refModule.type == ShipModule.Type.Weapon_Nuke || refModule.displayName.Contains("Cache") ? 10 : 1);
				}
				PlayerData pData = PlayerDatas.Get(ship.Ownership.GetOwner());
				pData.Organics.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.organics), null);
				pData.Fuel.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.fuel), null);
				pData.Metals.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.metals), null);
				pData.Synthetics.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.synthetics), null);
				pData.Explosives.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.explosives), null);
				pData.Exotics.Add(Mathf.RoundToInt(FFU_BE_Defs.initialResources.exotics), null);
				pData.Credits += Mathf.RoundToInt(FFU_BE_Defs.initialResources.credits);
				FFU_BE_Defs.updatedShips.Add(ship.InstanceId);
				return true;
			}
			if (ship != null && ship.Ownership.GetOwner() == Ownership.Owner.Enemy && !FFU_BE_Defs.updatedShips.Contains(ship.InstanceId)) {
				int enemyTechLevel = FFU_BE_Mod_Technology.GetEnemyTechLevel();
				int newDoorHealth = (int)(35 * FFU_BE_Defs.GetDifficultyModifier() * enemyTechLevel);
				foreach (Door shipDoor in ship.Doors) {
					shipDoor.displayName = "Sturdy Door " + FFU_BE_Mod_Technology.GetTierCodeText(enemyTechLevel);
					AccessTools.FieldRefAccess<Door, int>(shipDoor, "maxHealth") = newDoorHealth;
					AccessTools.FieldRefAccess<Door, int>(shipDoor, "health") = newDoorHealth;
				}
				Debug.LogWarning("Enemy ship spawned: [" + ship.InstanceId + "] " + ship.displayName + "! Applying tier upgrades in " + 
					FFU_BE_Mod_Technology.GetTierCodeText(Mathf.Clamp(enemyTechLevel - 1, 1, 10)) + " ~ " + 
					FFU_BE_Mod_Technology.GetTierCodeText(Mathf.Clamp(enemyTechLevel + 1, 1, 10)) + " range...");
				ship.MaxHealthAdd = Mathf.RoundToInt(ship.MaxHealthAdd * FFU_BE_Defs.enemyShipHullHealthMult * (Sector.Instance != null ? 0.5f + enemyTechLevel / 2f : 1f));
				if (Sector.Instance != null) {
					int currentSector = Sector.Instance.number;
					bool shipHasShieldGen = ship.Modules.Find(x => x.type == ShipModule.Type.ShieldGen && x.displayName.Contains("Generator")) != null ? true : false;
					bool shipHasPointDef = ship.Modules.Find(x => x.type == ShipModule.Type.PointDefence) != null ? true : false;
					bool shipHasECM = ship.Modules.Find(x => x.type == ShipModule.Type.PassiveECM) != null ? true : false;
					bool shipHasAccuracy = ship.Modules.Find(x => x.type == ShipModule.Type.StealthDecryptor) != null ? true : false;
					bool shipHasLab = ship.Modules.Find(x => x.type == ShipModule.Type.ResearchLab) != null ? true : false;
					bool shipHasGarden = ship.Modules.Find(x => x.type == ShipModule.Type.Garden) != null ? true : false;
					bool shipHasCryoBay = ship.Modules.Find(x => x.type == ShipModule.Type.Cryosleep) != null ? true : false;
					bool shipHasHealthBay = ship.Modules.Find(x => x.type == ShipModule.Type.Dronebay || x.type == ShipModule.Type.Medbay) != null ? true : false;
					bool shipHasFactory = ship.Modules.Find(x => x.type == ShipModule.Type.MaterialsConverter) != null ? true : false;
					foreach (ModuleSlotRoot moduleSlotRoot in ship.ModuleSlotRoots.ToList()) {
						if (FFU_BE_Defs.visualDebug) moduleSlotRoot.Slot.displayName = ship.ModuleSlotRoots.ToList().IndexOf(moduleSlotRoot) + ": " + moduleSlotRoot.Slot.displayName;
						if (moduleSlotRoot.Module != null) {
							if (!FFU_BE_Defs.ModuleViableForSector(moduleSlotRoot.Module, currentSector)) {
								int prevTier = (int)FFU_BE_Mod_Technology.GetModuleTier(moduleSlotRoot.Module);
								var replacementModulePrefab = FFU_BE_Defs.GetReplacementModule(moduleSlotRoot.Module, currentSector);
								if (replacementModulePrefab != null) {
									moduleSlotRoot.Module.gameObject.Destroy();
									FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(replacementModulePrefab, moduleSlotRoot);
								}
							}
						} else {
							List<string> AuxTypesList = new List<string>();
							if (!shipHasECM) AuxTypesList.Add("ECM");
							if (!shipHasAccuracy) AuxTypesList.Add("Accuracy");
							if (!shipHasLab) AuxTypesList.Add("Lab");
							if (!shipHasGarden) AuxTypesList.Add("Garden");
							if (!shipHasCryoBay) AuxTypesList.Add("CryoBay");
							if (!shipHasHealthBay) AuxTypesList.Add("Health");
							if (!shipHasFactory) AuxTypesList.Add("Factory");
							AuxTypesList.Add("Shield");
							AuxTypesList.Add("Armor");
							var rolledAuxType = Core.RandomItemFromList(AuxTypesList, "Armor");
							if (moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Weapon_Nuke)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Weapon_Nuke, currentSector);
								if (newModulePrefab != null) FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot);
							} else if (moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Weapon)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Weapon, currentSector);
								if (newModulePrefab != null) FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot);
							} else if (!shipHasPointDef && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.PointDefence)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.PointDefence, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasPointDef = true; }
							} else if (!shipHasShieldGen && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.ShieldGen)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.ShieldGen, currentSector, "Generator");
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasShieldGen = true; }
							} else if (rolledAuxType == "ECM" && !shipHasECM && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.PassiveECM)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.PassiveECM, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasECM = true; }
							} else if (rolledAuxType == "Accuracy" && !shipHasAccuracy && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.StealthDecryptor)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.StealthDecryptor, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasAccuracy = true; }
							} else if (rolledAuxType == "Lab" && !shipHasLab && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.ResearchLab)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.ResearchLab, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasLab = true; }
							} else if (rolledAuxType == "Garden" && !shipHasGarden && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Garden)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Garden, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasGarden = true; }
							} else if (rolledAuxType == "CryoBay" && !shipHasCryoBay && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Cryosleep)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Cryosleep, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasCryoBay = true; }
							} else if (rolledAuxType == "Health" && !shipHasHealthBay && (moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Medbay) || moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Dronebay))) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Medbay, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasHealthBay = true; }
							} else if (rolledAuxType == "Factory" && !shipHasFactory && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.MaterialsConverter)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.MaterialsConverter, currentSector);
								if (newModulePrefab != null) { FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot); shipHasFactory = true; }
							} else if (rolledAuxType == "Shield" && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.ShieldGen)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.ShieldGen, currentSector, "Capacitor");
								if (newModulePrefab != null) FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot);
							} else if (rolledAuxType == "Armor" && moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Integrity)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Integrity, currentSector);
								if (newModulePrefab != null) FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot);
							} else if (moduleSlotRoot.Slot.acceptedModuleTypes.Contains(ShipModule.Type.Storage)) {
								var newModulePrefab = FFU_BE_Defs.GetRandomModuleType(ShipModule.Type.Other, currentSector);
								if (newModulePrefab != null) FFU_BE_Mod_Technology.InstantiateNewModuleInSlot(newModulePrefab, moduleSlotRoot);
							}
						}
					}
				}
				bool shipLacksOrganics = false;
				bool shipLacksFuel = false;
				bool shipLacksSynthetics = false;
				bool shipLacksMetals = false;
				bool shipLacksExplosives = false;
				bool shipLacksExotics = false;
				if (ship.MaxOrganics == 0) shipLacksOrganics = true;
				if (ship.MaxFuel == 0) shipLacksFuel = true;
				if (ship.MaxSynthetics == 0) shipLacksSynthetics = true;
				if (ship.MaxMetals == 0) shipLacksMetals = true;
				if (ship.MaxExplosives == 0) shipLacksExplosives = true;
				if (ship.MaxExotics == 0) shipLacksExotics = true;
				foreach (ShipModule shipModule in ship.Modules.ToList()) {
					if (shipModule.InstanceId > 0) {
						float healthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(shipModule);
						FFU_BE_Mod_Modules.ApplyModuleEffects(shipModule);
						FFU_BE_Mod_Modules.ApplyModuleChanges(shipModule);
						FFU_BE_Mod_Technology.ApplyEnemyModuleTier(shipModule);
						FFU_BE_Mod_Modules.ApplyRelativeNewHealth(shipModule, healthPercent);
						if (shipModule.Ownership.GetOwner() == Ownership.Owner.Enemy && shipModule.type == ShipModule.Type.Weapon) shipModule.Weapon.reloadTimer.Restart(shipModule.Weapon.reloadInterval);
						if (shipModule.Ownership.GetOwner() == Ownership.Owner.Enemy && shipModule.type == ShipModule.Type.Reactor) {
							shipModule.Reactor.powerCapacity += shipModule.Reactor.overchargePowerCapacityAdd;
							shipModule.displayName += " (Overcharged)";
						}
						if (ship.Ownership.GetOwner() == Ownership.Owner.Enemy && shipModule.type == ShipModule.Type.Container && (shipLacksOrganics || shipLacksFuel || shipLacksSynthetics || shipLacksMetals || shipLacksExplosives || shipLacksExotics)) {
							if (shipLacksOrganics) {
								Debug.LogWarning("No organics on ship! Adding lacking storage...");
								shipModule.Container.MaxOrganics = 8500;
								shipLacksOrganics = false;
							}
							if (shipLacksFuel) {
								Debug.LogWarning("No starfuel on ship! Adding lacking storage...");
								shipModule.Container.MaxFuel = 8500;
								shipLacksFuel = false;
							}
							if (shipLacksSynthetics) {
								Debug.LogWarning("No synthetics on ship! Adding lacking storage...");
								shipModule.Container.MaxSynthetics = 8500;
								shipLacksSynthetics = false;
							}
							if (shipLacksMetals) {
								Debug.LogWarning("No metals on ship! Adding lacking storage...");
								shipModule.Container.MaxMetals = 8500;
								shipLacksMetals = false;
							}
							if (shipLacksExplosives) {
								Debug.LogWarning("No explosives on ship! Adding lacking storage...");
								shipModule.Container.MaxExplosives = 8500;
								shipLacksExplosives = false;
							}
							if (shipLacksExotics) {
								Debug.LogWarning("No exotics on ship! Adding lacking storage...");
								shipModule.Container.MaxExotics = 850;
								shipLacksExotics = false;
							}
						}
						if (shipModule.Ownership.GetOwner() == Ownership.Owner.Enemy) {
							shipModule.turnedOn = true;
							shipModule.IsPowered = true;
							shipModule.turnedOn = true;
							shipModule.IsPowered = true;
						}
						if (FFU_BE_Defs.visualDebug) Debug.Log(ship.displayName + ": #" + ship.ModuleSlotRoots.ToList().IndexOf(shipModule.ModuleSlotRoot) + " " + shipModule.ModuleSlotRoot.Slot.displayName + " " + shipModule.name);
						if (FFU_BE_Defs.visualDebug) shipModule.displayName = ship.ModuleSlotRoots.ToList().IndexOf(shipModule.ModuleSlotRoot) + ": " + shipModule.displayName;
					}
				}
				ship.Organics += Mathf.RoundToInt((ship.MaxOrganics - ship.Organics) * Random.Range(0.45f, 0.85f));
				ship.Fuel += Mathf.RoundToInt((ship.MaxFuel - ship.Fuel) * Random.Range(0.45f, 0.85f));
				ship.Synthetics += Mathf.RoundToInt((ship.MaxSynthetics - ship.Synthetics) * Random.Range(0.45f, 0.85f));
				ship.Metals += Mathf.RoundToInt((ship.MaxMetals - ship.Metals) * Random.Range(0.45f, 0.85f));
				ship.Explosives += Mathf.RoundToInt((ship.MaxExplosives - ship.Explosives) * Random.Range(0.45f, 0.85f));
				ship.Exotics += Mathf.RoundToInt((ship.MaxExotics - ship.Exotics) * Random.Range(0.45f, 0.85f));
				if (ship.Organics < ship.MaxOrganics * 0.6f) ship.Organics = Mathf.RoundToInt(Random.Range(ship.MaxOrganics * 0.6f, ship.MaxOrganics * 0.9f));
				if (ship.Fuel < ship.MaxFuel * 0.6f) ship.Fuel = Mathf.RoundToInt(Random.Range(ship.MaxFuel * 0.6f, ship.MaxFuel * 0.9f));
				if (ship.Metals < ship.MaxMetals * 0.6f) ship.Metals = Mathf.RoundToInt(Random.Range(ship.MaxMetals * 0.6f, ship.MaxMetals * 0.9f));
				if (ship.Synthetics < ship.MaxSynthetics * 0.6f) ship.Synthetics = Mathf.RoundToInt(Random.Range(ship.MaxSynthetics * 0.6f, ship.MaxSynthetics * 0.9f));
				if (ship.Explosives < ship.MaxExplosives * 0.6f) ship.Explosives = Mathf.RoundToInt(Random.Range(ship.MaxExplosives * 0.6f, ship.MaxExplosives * 0.9f));
				if (ship.Exotics < ship.MaxExotics * 0.6f) ship.Exotics = Mathf.RoundToInt(Random.Range(ship.MaxExotics * 0.6f, ship.MaxExotics * 0.9f));
				//foreach (ModuleSlotRoot moduleSlotRoot in ship.ModuleSlotRoots.ToList()) { /* Something Will Happen Here. Eventually. */ }
				if (ship.shield != null && ship.shield.MaxShieldPoints > 0) ship.shield.ShieldPoints = ship.shield.MaxShieldPoints;
				FFU_BE_Defs.updatedShips.Add(ship.InstanceId);
				return true;
			}
			return false;
		}
	}
}

namespace RST.PlaymakerAction {
	public class patch_SavegameActions : SavegameActions {
		private extern void orig_Load();
		private void Load() {
		/// Validate Modified Loaded Data & Parameters
			orig_Load();
			if (FFU_BE_Defs.firstInst) {
				if (!FFU_BE_Defs.allModulesCraftable) {
					ModuleSlotActionsPanel.altCraftableModulePrefabs = new List<ShipModule>();
					foreach (int discoveredModuleID in FFU_BE_Defs.discoveredModuleIDs.ToList()) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == discoveredModuleID));
					ModuleSlotActionsPanel.altCraftableModulePrefabs.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				}
				foreach (Fleet fleet in Resources.FindObjectsOfTypeAll<Fleet>().ToList()) {
					if (fleet.name.Contains("MustExpireAfterMeeting")) {
						fleet.speed = 60f;
						break;
					}
				}
				FFU_BE_Defs.firstInst = false;
			}
			Debug.LogWarning("Game loaded! Applying tiered module parameters...");
			foreach (Ship spaceShip in PerFrameCache.CachedShips) {
				if (spaceShip.Ownership.GetOwner() == Ownership.Owner.Me) {
					if (FFU_BE_Defs.prefabShipsList.Find(x => x.PrefabId == spaceShip.PrefabId) != null)
						if (FFU_BE_Defs.prefabShipsList.Find(x => x.PrefabId == spaceShip.PrefabId).MaxHealthAdd > spaceShip.MaxHealthAdd)
							spaceShip.MaxHealthAdd = FFU_BE_Defs.prefabShipsList.Find(x => x.PrefabId == spaceShip.PrefabId).MaxHealthAdd;
					foreach (Door shipDoor in spaceShip.Doors) {
						if (FFU_BE_Defs.shipPrefabsDoorName.ContainsKey(spaceShip.PrefabId)) shipDoor.displayName = FFU_BE_Defs.shipPrefabsDoorName[spaceShip.PrefabId];
						if (FFU_BE_Defs.shipPrefabsDoorHealth.ContainsKey(spaceShip.PrefabId)) AccessTools.FieldRefAccess<Door, int>(shipDoor, "maxHealth") = FFU_BE_Defs.shipPrefabsDoorHealth[spaceShip.PrefabId];
					}
				}
				if (spaceShip.Ownership.GetOwner() == Ownership.Owner.Enemy) {
					int enemyTechLevel = FFU_BE_Mod_Technology.GetEnemyTechLevel();
					int newDoorHealth = (int)(35 * FFU_BE_Defs.GetDifficultyModifier() * enemyTechLevel);
					foreach (Door shipDoor in spaceShip.Doors) {
						shipDoor.displayName = $"Section Door {FFU_BE_Mod_Technology.GetTierCodeText(enemyTechLevel)}";
						AccessTools.FieldRefAccess<Door, int>(shipDoor, "maxHealth") = newDoorHealth;
					}
				}
			}
			foreach (ShipModule shipModule in PerFrameCache.CachedModules) {
				if (shipModule.InstanceId > 0) {
					float healthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(shipModule);
					FFU_BE_Mod_Modules.ApplyModuleEffects(shipModule);
					FFU_BE_Mod_Modules.ApplyModuleChanges(shipModule);
					FFU_BE_Mod_Technology.ApplyInitialModuleTier(shipModule);
					FFU_BE_Mod_Modules.ApplyRelativeNewHealth(shipModule, healthPercent);
					if (shipModule.Storage != null) {
						shipModule.Storage.slotCount = FFU_BE_Defs.shipCurrentStorageCap > 0 ? FFU_BE_Defs.shipCurrentStorageCap : shipModule.Storage.slotCount;
						foreach (Transform item in shipModule.Storage.storage) {
							if (FFU_BE_Defs.debugMode) Debug.LogWarning("Stored Module: " + item.name);
							if (item.GetComponent<ShipModule>() != null) {
								float storedHealthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(item.GetComponent<ShipModule>());
								FFU_BE_Mod_Modules.ApplyModuleEffects(item.GetComponent<ShipModule>());
								FFU_BE_Mod_Modules.ApplyModuleChanges(item.GetComponent<ShipModule>());
								FFU_BE_Mod_Technology.ApplyInitialModuleTier(item.GetComponent<ShipModule>());
								FFU_BE_Mod_Modules.ApplyRelativeNewHealth(item.GetComponent<ShipModule>(), storedHealthPercent);
							}
						}
					}
				}
				if (shipModule.displayName.Contains("bossweapon") && shipModule.InstanceId > 0 && shipModule.Ownership.GetOwner() == Ownership.Owner.Me) {
					shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
					shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0;
					shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
					shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
					shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				}
			}
			foreach (Crewmember cachedCrewmember in PerFrameCache.CachedCrewmembers) {
				if (cachedCrewmember.InstanceId > 0) {
					if (FFU_BE_Mod_Crewmembers.CrewLacksHealth(cachedCrewmember)) FFU_BE_Mod_Crewmembers.ApplyCrewChanges(cachedCrewmember);
					FFU_BE_Mod_Crewmembers.AddSkillPointsWithinLimits(cachedCrewmember);
				}
				if (FFU_BE_Defs.equippedCrewFirearms.ContainsKey(cachedCrewmember.InstanceId)) {
					HandWeapon refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.PrefabId == FFU_BE_Defs.equippedCrewFirearms[cachedCrewmember.InstanceId]);
					if (refWeapon != null) FFU_BE_Mod_Crewmembers.CrewmemberSetWeapon(cachedCrewmember, refWeapon);
					else Debug.LogWarning("Equipped weapon with Prefab ID [" + FFU_BE_Defs.equippedCrewFirearms[cachedCrewmember.InstanceId] + "] is not found!");
				}
			}
		}
	}
	public class patch_PoiWaitForPlayer : PoiWaitForPlayer {
		[MonoModIgnore] private POI poi;
		[MonoModReplace] private void TryToVisit() {
		/// Recalculate Black Market Module Price
			if (!RstMutexes.TryToLock(ref RstShared.eventLockHolder, poi)) return;
			POI.LockFleet(poi);
			poi.LongRangeScanned = true;
			poi.ScannedAndDiscovered = true;
			if (!poi.Visited && poi.isPlanet) {
				PlayerData me = PlayerDatas.Me;
				if (me != null) me.gameRunRecord.planetsVisited++;
			}
			if (poi.IsShop) {
				foreach (ShipModule shopModule in Resources.FindObjectsOfTypeAll<ShipModule>().Where(x => x.name.ToLower().Contains("clone") && x.Ownership.GetOwner() != Ownership.Owner.Me)) {
					if (Sector.Instance != null && FFU_BE_Defs.ModuleAvailableSector(shopModule) > Sector.Instance.number) {
						ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shopModule.PrefabId);
						shopModule.costCreditsInShop = Mathf.RoundToInt(refModule.costCreditsInShop * FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shopModule), Core.BonusType.Extreme) * FFU_BE_Defs.blackMarketMult);
						AccessTools.FieldRefAccess<ShipModule, int>(shopModule, "maxHealth") = Mathf.RoundToInt(AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth") * FFU_BE_Mod_Technology.GetTierBonus(FFU_BE_Mod_Technology.GetModuleTier(shopModule), Core.BonusType.Default));
					}
				}
			}
			poi.Visited = true;
			poi.visitIsPending = false;
			base.Fsm.Event(playerArrived);
		}
	}
}