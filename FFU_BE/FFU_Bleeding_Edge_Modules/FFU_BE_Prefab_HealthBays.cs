using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_HealthBays {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName.Contains("dronebay 0 diy")) return idx; idx++;
			if (moduleName.Contains("dronebay 1 basic")) return idx; idx++;
			if (moduleName.Contains("medbay0 diy")) return idx; idx++;
			if (moduleName.Contains("medbay1 Rat")) return idx; idx++;
			if (moduleName.Contains("medbay2 startversion")) return idx; idx++;
			if (moduleName.Contains("medbay3 nanorepair")) return idx; idx++;
			if (moduleName.Contains("medbay5 biofluid bath")) return idx; idx++;
			if (moduleName.Contains("medbay6 biological")) return idx; idx++;
			if (moduleName.Contains("medbay4 stem celler")) return idx; idx++;
			return 999;
		}
		public static void UpdateHealthBayModule(ShipModule shipModule, bool initItemData) {
			string colorCrew = "ff668c";
			string colorDrone = "ff668c";
			string colorBoth = "ff668c";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "dronebay 0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Makeshift <color=#" + colorDrone + "ff>Drone Bay</color>";
				shipModule.Medbay.secondsPerHp = 5f;
				shipModule.Medbay.resourcesPerHp.synthetics = 15f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Drone };
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 1f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "dronebay 1 basic":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.1f);
				shipModule.displayName = "Industrial <color=#" + colorDrone + "ff>Drone Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.synthetics = 5f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Drone };
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, metals = 2000f, synthetics = 1250f, exotics = 10f };
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 40;
				break;
				case "medbay0 diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = "Makeshift <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 10f;
				shipModule.Medbay.resourcesPerHp.organics = 15f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 150f, exotics = 1f };
				shipModule.powerConsumed = 2;
				shipModule_maxHealth = 10;
				break;
				case "medbay1 Rat":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = "Ancient <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 7f;
				shipModule.Medbay.resourcesPerHp.organics = 15f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 750f, synthetics = 250f, exotics = 2f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 15;
				break;
				case "medbay2 startversion":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = "Nanite <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 5f;
				shipModule.Medbay.resourcesPerHp.organics = 12f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 500f, exotics = 4f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case "medbay3 nanorepair":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = "Modern <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 3f;
				shipModule.Medbay.resourcesPerHp.organics = 10f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 1250f, synthetics = 750f, exotics = 6f };
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 30;
				break;
				case "medbay5 biofluid bath":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = "Aura <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.organics = 7f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 1000f, exotics = 8f };
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 35;
				break;
				case "medbay6 biological":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.1f);
				shipModule.displayName = "Biotic <color=#" + colorCrew + "ff>Medical Bay</color>";
				shipModule.Medbay.secondsPerHp = 2f;
				shipModule.Medbay.resourcesPerHp.organics = 5f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet };
				shipModule.craftCost = new ResourceValueGroup { fuel = 350f, organics = 2000f, synthetics = 1250f, exotics = 10f };
				shipModule.powerConsumed = 0;
				shipModule_maxHealth = 25;
				break;
				case "medbay4 stem celler":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = "Genesis <color=#" + colorBoth + "ff>Restoration Bay</color>";
				shipModule.description = "Universal restoration bay that consumes synthetics and organics at the same time to replace damaged cells & mechanic components on subatomic levels.";
				shipModule.Medbay.secondsPerHp = 1f;
				shipModule.Medbay.resourcesPerHp.organics = 2f;
				shipModule.Medbay.resourcesPerHp.synthetics = 2f;
				shipModule.Medbay.acceptCrewTypes = new Crewmember.Type[] { Crewmember.Type.Regular, Crewmember.Type.Pet, Crewmember.Type.Drone };
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2500f, synthetics = 1500f, exotics = 15f };
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 40;
				break;
				default:
				Debug.LogWarning($"[NEW HEALBAY] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(HEALBAY) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
