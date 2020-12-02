using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_PassiveECMs {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 236853983) return idx; idx++; //ECM 0 DIY
			if (moduleID == 1717910481) return idx; idx++; //ECM 0 terran old
			if (moduleID == 1078640904) return idx; idx++; //ECM 0 ancient
			if (moduleID == 178792571) return idx; idx++; //ECM 03 insectoid
			if (moduleID == 738383848) return idx; idx++; //ECM 01 terran
			if (moduleID == 1804253033) return idx; idx++; //ECM 03 biotech
			if (moduleID == 738383845) return idx; idx++; //ECM 02 terran
			if (moduleID == 1754358032) return idx; idx++; //ECM 04 spideraa
			if (moduleID == 738383846) return idx; idx++; //ECM 03 terran
			return idx + 100;
		}
		public static void UpdateCountermeasureModule(ShipModule shipModule, bool initItemData) {
			string colorCounter = "4dd2ff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (shipModule.PrefabId) {
				case 236853983: //ECM 0 DIY
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -8.0f);
				shipModule.displayName = "Makeshift <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array that was made from salvage and scrap materials. Although has very questionable quality, still manages somewhat to disrupt hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 200f, synthetics = 50f, exotics = 1f };
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 2;
				shipModule_maxHealth = 15;
				break;
				case 1717910481: //ECM 0 terran old
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -8.2f);
				shipModule.displayName = "Ancient <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Was manufactured centuries ago and used in every imaginable war and military operation. Heavily wearied down, but still can disrupt hostile targeting systems to certain extent.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 300f, synthetics = 75f, exotics = 2f };
				shipModule.shipEvasionPercentAdd = 2;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 3;
				shipModule_maxHealth = 18;
				break;
				case 1078640904: //ECM 0 ancient
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -8.4f);
				shipModule.displayName = "Imperial <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "A rare case of technology that was designed and manufactured by Rat Empire from scratch. Has mediocre quality, but still can be used to disrupt hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 500f, synthetics = 125f, exotics = 3f };
				shipModule.shipEvasionPercentAdd = 3;
				shipModule.powerConsumed = 2;
				shipModule.maxHealthAdd = 4;
				shipModule_maxHealth = 20;
				break;
				case 178792571: //ECM 03 insectoid
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -8.6f);
				shipModule.displayName = "Velocity <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Created by marauders and pirates from various salvaged parts of other ECM arrays, but with professional touch. Has average jamming efficiency of hostile targeting systems.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 700f, synthetics = 175f, exotics = 4f };
				shipModule.shipEvasionPercentAdd = 4;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 22;
				break;
				case 738383848: //ECM 01 terran
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -8.8f);
				shipModule.displayName = "Reflector <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Manufactured with specialized mirror array that constantly emits ship's reflections that has some chance to fool enemy targeting systems with decent efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1000f, synthetics = 250f, exotics = 5f };
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 6;
				shipModule_maxHealth = 24;
				break;
				case 1804253033: //ECM 03 biotech
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -9.0f);
				shipModule.displayName = "Bionic <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array or organic origin. Grown up in special environment and contains all ports for proper interfacing. Has good jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, organics = 1300f, synthetics = 325f, exotics = 7f };
				shipModule.shipEvasionPercentAdd = 6;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 7;
				shipModule_maxHealth = 27;
				break;
				case 738383845: //ECM 02 terran
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -9.2f);
				shipModule.displayName = "Prismatic <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array with built-in prismatic emitters that literally blind hostile targeting systems and sensors. Has very good jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1700f, synthetics = 425f, exotics = 10f };
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 8;
				shipModule_maxHealth = 31;
				break;
				case 1754358032: //ECM 04 spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -9.4f);
				shipModule.displayName = "Repulsor <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "Electronic countermeasure array that uses kinetic energy and unknown principles to disrupt hostile targeting systems and sensors. Has great jamming efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 2500f, synthetics = 625f, exotics = 15f };
				shipModule.shipEvasionPercentAdd = 8;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 9;
				shipModule_maxHealth = 35;
				break;
				case 738383846: //ECM 03 terran
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -9.6f);
				shipModule.displayName = "Quantum <color=#" + colorCounter + "ff>ECM Array</color>";
				shipModule.description = "This electronic countermeasure array constantly produces quantum chaff with intangibility effect that disrupts hostile targeting systems and sensors with excellent efficiency.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 4000f, synthetics = 1000f, exotics = 25f };
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 40;
				break;
				case 355331213: //ECM 02.2 ancient artifact, slicer dicer
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, -9.0f);
				shipModule.displayName = "ECM Array Artifact";
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW ECM] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(ECM) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
