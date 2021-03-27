using HarmonyLib;
using RST;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_CryoBays {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 1290558229) return idx; idx++; //dream recorder 1 DIY
			if (moduleID == 1018033786) return idx; idx++; //dream recorder 1 rats
			if (moduleID == 1813199311) return idx; idx++; //dream recorder 2
			if (moduleID == 1484543824) return idx; idx++; //dream recorder 4x weird biotech
			if (moduleID == 41460892) return idx; idx++; //cryosleep 6x human standard
			if (moduleID == 1398713621) return idx; idx++; //cryosleep 1 DIY
			if (moduleID == 41460888) return idx; idx++; //cryosleep 2x human small
			if (moduleID == 623034016) return idx; idx++; //cryosleep 3x rats armor
			if (moduleID == 703894034) return idx; idx++; //cryosleep 3x medical
			if (moduleID == 2091145418) return idx; idx++; //cryosleep 4x alien family
			if (moduleID == 2059107150) return idx; idx++; //cryosleep 8x insect
			return idx + 100;
		}
		public static void UpdateCryosleepModule(ShipModule shipModule, bool initItemData) {
			string colorDream = "d966ff";
			string colorSleep = "ff66d9";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 1290558229: //dream recorder 1 DIY
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorDream}ff>Cryodream Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this makeshift cryodream recorder requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, organics = 200f, metals = 150f, synthetics = 100f, exotics = 1f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 300f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 800f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 200f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 500f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 5;
				break;
				case 1018033786: //dream recorder 1 rats
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Imperial <color=#{colorDream}ff>Cryodream Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this armored cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, organics = 350f, metals = 350f, synthetics = 250f, exotics = 2f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 200f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 600f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 350f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case 1813199311: //dream recorder 2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Standard <color=#{colorDream}ff>Cryodream Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this low capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 750f, metals = 500f, synthetics = 350f, exotics = 3f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 150f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 400f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 250f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 15;
				break;
				case 1484543824: //dream recorder 4x weird biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Advanced <color=#{colorDream}ff>Cryodream Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this medium capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, organics = 1500f, metals = 1250f, synthetics = 750f, exotics = 5f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 250f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 100f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 200f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 20;
				break;
				case 41460892: //cryosleep 6x human standard
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryodream].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Exploration <color=#{colorDream}ff>Cryodream Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this high capacity cryodream recorder bay requires no organics. In addition, during interstellar travel crew might recover health and record their dreams as xenodata.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, organics = 2500f, metals = 2000f, synthetics = 1500f, exotics = 10f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.genDreamCredits = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 150f;
				shipModule.Cryosleep.genDreamCreditsDistance.minValue = 100f;
				shipModule.Cryosleep.genDreamCreditsDistance.maxValue = 150f;
				shipModule.Cryosleep.creditsPerDream.minValue = 10f;
				shipModule.Cryosleep.creditsPerDream.maxValue = 100f;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 30;
				break;
				case 1398713621: //cryosleep 1 DIY
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this makeshift cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, organics = 150f, metals = 125f, synthetics = 75f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 250f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 700f;
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 5;
				break;
				case 41460888: //cryosleep 2x human small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Standard <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this low capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, organics = 300f, metals = 250f, synthetics = 150f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 175f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 500f;
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case 623034016: //cryosleep 3x rats armor
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Imperial <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this armored medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, organics = 500f, metals = 350f, synthetics = 250f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 150f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 450f;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case 703894034: //cryosleep 3x medical
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6, 7, 8);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Medical <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this medical medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, organics = 1000f, metals = 350f, synthetics = 250f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 10f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 50f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 15;
				break;
				case 2091145418: //cryosleep 4x alien family
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Luxurious <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this luxurious medium capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, organics = 750f, metals = 500f, synthetics = 350f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 100f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 200f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 20;
				break;
				case 2059107150: //cryosleep 8x insect
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryobay].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Contains(shipModule.PrefabId)) FFU_BE_Defs.economyTypeIDs[Core.EconomyType.Cryosleep].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Military <color=#{colorSleep}ff>Cryosleep Bay</color>");
				shipModule.description = Core.TT($"Crew sleeping in this military high capacity cryosleep bay requires no organics. In addition, during interstellar travel crew might recover health.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, organics = 1000f, metals = 750f, synthetics = 500f };
				shipModule.Cryosleep.healOneCrewHp = true;
				shipModule.Cryosleep.healOneCrewHpDistance.minValue = 50f;
				shipModule.Cryosleep.healOneCrewHpDistance.maxValue = 100f;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 40;
				break;
				default:
				Debug.LogWarning($"[NEW CRYOBAY] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(CRYOBAY) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}