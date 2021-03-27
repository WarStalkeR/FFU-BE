using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Drives {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 2136288774) return idx; idx++; //warp 0 DIY
			if (moduleID == 1503624866) return idx; idx++; //warp 01 greencrystal
			if (moduleID == 2005632838) return idx; idx++; //warp 05 spiralcrystal
			if (moduleID == 1346895691) return idx; idx++; //warp 02b small
			if (moduleID == 1622263161) return idx; idx++; //warp 02 bluecrystal
			if (moduleID == 458296297) return idx; idx++; //warp 03 neoncrystal
			if (moduleID == 2018774202) return idx; idx++; //warp 05 rotor metal
			if (moduleID == 38410223) return idx; idx++; //warp 10 chunky
			if (moduleID == 1951229269) return idx; idx++; //warp 04 emperorbanks
			if (moduleID == 45815679) return idx; idx++; //warp 06 rotor blue
			if (moduleID == 293119006) return idx; idx++; //warp 11 bluetec
			if (moduleID == 1528213811) return idx; idx++; //warp 09 spideraa
			if (moduleID == 1559705412) return idx; idx++; //warp 07 rotor glass
			return idx + 100;
		}
		public static void UpdateWarpDriveModule(ShipModule shipModule, bool initItemData) {
			string colorDrive = "b366ff";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			shipModule.maxHealthAdd = 0;
			switch (shipModule.PrefabId) {
				case 2136288774: //warp 0 DIY
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 3.2f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Made from spare exotics, high-tech scraps and salvaged power cores. Has very long spin-up time and horrible fuel consumption. Used, when there are no other alternatives.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 150f, synthetics = 150f, exotics = 1f };
				shipModule.Warp.activationFuel = 75;
				shipModule.Warp.reloadInterval = 50;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 20;
				break;
				case 1503624866: //warp 01 greencrystal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 3.0f);
				shipModule.displayName = Core.TT($"Fission <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Basic warp drive that uses fission energy to recharge warp coils in order to initiate jump. Spin-up time is still very long, but fuel consumption is a little bit better.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 300f, synthetics = 300f, exotics = 2f };
				shipModule.Warp.activationFuel = 65;
				shipModule.Warp.reloadInterval = 50;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 24;
				break;
				case 2005632838: //warp 05 spiralcrystal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.9f);
				shipModule.displayName = Core.TT($"Biochemical <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Organic warp drive that uses unidentified biochemical reactions to recharge warp coils for further jump initiation. Long spin-up time and mediocre fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, organics = 500f, synthetics = 500f, exotics = 3f };
				shipModule.Warp.activationFuel = 60;
				shipModule.Warp.reloadInterval = 45;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 26;
				break;
				case 1346895691: //warp 02b small
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.85f);
				shipModule.displayName = Core.TT($"Micro-Tech <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Improved minimized warp drive that uses fission energy for faster than light navigation. Size reduction made it more affordable and redundant, but less optimized and efficient. Civilian use mostly.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 600f, synthetics = 600f, exotics = 3f };
				shipModule.Warp.activationFuel = 58;
				shipModule.Warp.reloadInterval = 45;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 27;
				break;
				case 1622263161: //warp 02 bluecrystal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.8f);
				shipModule.displayName = Core.TT($"Immaterium <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Exotic warp drive that uses feeds on immaterium energy to recharge warp coils in order to initiate jump. Long spin-up time and better then average fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 750f, synthetics = 750f, exotics = 4f };
				shipModule.Warp.activationFuel = 55;
				shipModule.Warp.reloadInterval = 45;
				shipModule.powerConsumed = 5;
				shipModule_maxHealth = 28;
				break;
				case 458296297: //warp 03 neoncrystal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.7f);
				shipModule.displayName = Core.TT($"Prismatic <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that uses prismatic mirrors to concentrate energy in the warp coils to recharge them. Has decent spin-up time and decent fuel consumption efficiency.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 1250f, synthetics = 1250f, exotics = 5f };
				shipModule.Warp.activationFuel = 50;
				shipModule.Warp.reloadInterval = 40;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 30;
				break;
				case 2018774202: //warp 05 rotor metal
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.6f);
				shipModule.displayName = Core.TT($"Fusion <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that uses pure and unprocessed fusion energy to recharge warp coils for further jump initiation. Has good spin-up time and optimized fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 800f, metals = 1750f, synthetics = 1750f, exotics = 7f };
				shipModule.Warp.activationFuel = 45;
				shipModule.Warp.reloadInterval = 35;
				shipModule.powerConsumed = 7;
				shipModule_maxHealth = 33;
				break;
				case 38410223: //warp 10 chunky
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.55f);
				shipModule.displayName = Core.TT($"Multi-Layer <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Multi-layered warp drive that uses unknown, but pure energy to recharge warp coils for further jump initiation. Due to stability issues, space that could increase efficiency was used to ensure containment of the energy.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 900f, metals = 2000f, synthetics = 2000f, exotics = 8f };
				shipModule.Warp.activationFuel = 42;
				shipModule.Warp.reloadInterval = 35;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 35;
				break;
				case 1951229269: //warp 04 emperorbanks
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.5f);
				shipModule.displayName = Core.TT($"Commerical <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that was developed for sake of profit and is sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2250f, synthetics = 2250f, exotics = 10f };
				shipModule.Warp.activationFuel = 40;
				shipModule.Warp.reloadInterval = 30;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 36;
				break;
				case 45815679: //warp 06 rotor blue
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.4f);
				shipModule.displayName = Core.TT($"Antimatter <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that uses unstable antimatter energy to recharge warp coils for further jump initiation. Has great spin-up time and very optimized fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3000f, synthetics = 3000f, exotics = 15f };
				shipModule.Warp.activationFuel = 35;
				shipModule.Warp.reloadInterval = 25;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 39;
				break;
				case 293119006: //warp 11 bluetec
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.35f);
				shipModule.displayName = Core.TT($"Starlight <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that uses volatile compressed photon energy to recharge warp coils for further jump initiation. Its operational principles are still unknown as there are no cases of photons being volatile.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1350f, metals = 3500f, synthetics = 3500f, exotics = 17f };
				shipModule.Warp.activationFuel = 32;
				shipModule.Warp.reloadInterval = 25;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 40;
				break;
				case 1528213811: //warp 09 spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.3f);
				shipModule.displayName = Core.TT($"Repulsor <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"Warp drive that uses kinetic energy and unknown principles to recharge warp coils for further jumping. Has amazing spin-up time and near perfect fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4000f, synthetics = 4000f, exotics = 20f };
				shipModule.Warp.activationFuel = 30;
				shipModule.Warp.reloadInterval = 25;
				shipModule.powerConsumed = 9;
				shipModule_maxHealth = 41;
				break;
				case 1559705412: //warp 07 rotor glass
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Drive].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = Core.TT($"Quantum <color=#{colorDrive}ff>Warp Drive</color>");
				shipModule.description = Core.TT($"This warp drive is more a hyper-drive then just a warp drive. It uses quantum energy to fold space and move through it. Has near perfect spin-up time and excellent fuel consumption.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 5000f, synthetics = 5000f, exotics = 25f };
				shipModule.Warp.activationFuel = 25;
				shipModule.Warp.reloadInterval = 20;
				shipModule.powerConsumed = 10;
				shipModule_maxHealth = 45;
				break;
				default:
				Debug.LogWarning($"[NEW DRIVE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(DRIVE) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}