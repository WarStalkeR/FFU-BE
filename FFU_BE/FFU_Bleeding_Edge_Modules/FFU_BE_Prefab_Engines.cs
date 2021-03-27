using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Engines {
		public static int SortModules(int moduleID) {
			int idx = 0;
			if (moduleID == 1284816050) return idx; idx++; //engine 0 diy
			if (moduleID == 1364709951) return idx; idx++; //engine 01 brittle
			if (moduleID == 497175846) return idx; idx++; //engine 01 primitive
			if (moduleID == 1708644704) return idx; idx++; //engine 2 rats
			if (moduleID == 533178690) return idx; idx++; //engine 2.5 classic
			if (moduleID == 245228012) return idx; idx++; //engine 2 floral
			if (moduleID == 362626339) return idx; idx++; //engine 01 tiger
			if (moduleID == 229499087) return idx; idx++; //engine 2.5 weird
			if (moduleID == 2023634410) return idx; idx++; //engine 2.5 terran
			if (moduleID == 84732634) return idx; idx++; //engine 03 emperor banks
			if (moduleID == 1131227094) return idx; idx++; //engine 04 red
			if (moduleID == 292475796) return idx; idx++; //engine 03 bioship
			if (moduleID == 1508923010) return idx; idx++; //engine 2 large robust
			if (moduleID == 1536420907) return idx; idx++; //engine 4 spideraa
			if (moduleID == 366713264) return idx; idx++; //engine 04 xblack
			if (moduleID == 1119228548) return idx; idx++; //engine 2 F-gulper
			return idx + 100;
		}
		public static void UpdateEngineModule(ShipModule shipModule, bool initItemData) {
			string colorEngine = "ffd24d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var shipModule_Engine_consumedPerDistance = AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance");
			switch (shipModule.PrefabId) {
				case 1284816050: //engine 0 diy
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 3.0f);
				shipModule.displayName = Core.TT($"Makeshift <color=#{colorEngine}ff>Chemical Engine</color>");
				shipModule.description = Core.TT($"Assembled from the metal plates, synthetic blocks and high-tech scrap. Good alternative solution in case if ship has no engine at all. Fragile and inefficient.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 75f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.75f };
				shipModule.Engine.overchargeEvasionAdd = 12;
				shipModule.asteroidDeflectionPercentAdd = 10;
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.overchargePowerNeed = 22;
				shipModule.overchargeSeconds = 45;
				shipModule.starmapSpeedAdd = 10;
				shipModule.powerConsumed = 3;
				shipModule_maxHealth = 10;
				break;
				case 1364709951: //engine 01 brittle
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.8f);
				shipModule.displayName = Core.TT($"Mass-Produced <color=#{colorEngine}ff>Chemical Engine</color>");
				shipModule.description = Core.TT($"Based on open-source blueprints and mass-produced. Questionable quality, low durability and completely inefficient fuel consumption leave much to be desired.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 200f, synthetics = 150f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.71f };
				shipModule.Engine.overchargeEvasionAdd = 13;
				shipModule.asteroidDeflectionPercentAdd = 11;
				shipModule.shipEvasionPercentAdd = 1;
				shipModule.overchargePowerNeed = 21;
				shipModule.overchargeSeconds = 60;
				shipModule.starmapSpeedAdd = 11;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 15;
				break;
				case 497175846: //engine 01 primitive
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.7f);
				shipModule.displayName = Core.TT($"Ancient <color=#{colorEngine}ff>Fission Engine</color>");
				shipModule.description = Core.TT($"One of the first fission engines ever created. Constant usage of couple past centuries wearied it down considerably. Has somewhat mediocre performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 300f, synthetics = 275f, exotics = 1f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.67f };
				shipModule.Engine.overchargeEvasionAdd = 14;
				shipModule.asteroidDeflectionPercentAdd = 12;
				shipModule.shipEvasionPercentAdd = 2;
				shipModule.overchargePowerNeed = 23;
				shipModule.overchargeSeconds = 60;
				shipModule.starmapSpeedAdd = 12;
				shipModule.powerConsumed = 3;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 20;
				break;
				case 1708644704: //engine 2 rats
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.6f);
				shipModule.displayName = Core.TT($"Imperial <color=#{colorEngine}ff>Fission Engine</color>");
				shipModule.description = Core.TT($"The only engine ever developed by the Rat Empire. It was designed after failing attempts to reverse salvaged fission engines. Has average performance at best.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 500f, synthetics = 350f, exotics = 2f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.63f };
				shipModule.Engine.overchargeEvasionAdd = 15;
				shipModule.asteroidDeflectionPercentAdd = 13;
				shipModule.shipEvasionPercentAdd = 3;
				shipModule.overchargePowerNeed = 20;
				shipModule.overchargeSeconds = 75;
				shipModule.starmapSpeedAdd = 13;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 25;
				break;
				case 533178690: //engine 2.5 classic
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.5f);
				shipModule.displayName = Core.TT($"Modern <color=#{colorEngine}ff>Fission Engine</color>");
				shipModule.description = Core.TT($"Most commonly manufactured fission engine. Installed on almost all decent ships. Has decent performance, decent fuel efficiency and decent durability.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 750f, synthetics = 500f, exotics = 3f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.59f };
				shipModule.Engine.overchargeEvasionAdd = 16;
				shipModule.asteroidDeflectionPercentAdd = 14;
				shipModule.shipEvasionPercentAdd = 4;
				shipModule.overchargePowerNeed = 22;
				shipModule.overchargeSeconds = 90;
				shipModule.starmapSpeedAdd = 14;
				shipModule.powerConsumed = 4;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 30;
				break;
				case 245228012: //engine 2 floral
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.4f);
				shipModule.displayName = Core.TT($"Organic <color=#{colorEngine}ff>Biochemical Engine</color>");
				shipModule.description = Core.TT($"Organic engine that uses unique biochemical reaction that rivals fission energy emission to generate thrust. Has very decent performance and fuel efficiency.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, organics = 1000f, synthetics = 750f, exotics = 4f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.55f };
				shipModule.Engine.overchargeEvasionAdd = 18;
				shipModule.asteroidDeflectionPercentAdd = 16;
				shipModule.shipEvasionPercentAdd = 5;
				shipModule.overchargePowerNeed = 18;
				shipModule.overchargeSeconds = 120;
				shipModule.starmapSpeedAdd = 15;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 30;
				break;
				case 362626339: //engine 01 tiger
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.3f);
				shipModule.displayName = Core.TT($"Industrial <color=#{colorEngine}ff>Fusion Engine</color>");
				shipModule.description = Core.TT($"Heavy fusion engine that mostly installed on big industrial ships that require a lot of thrust power to move. Has good performance and high durability.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1250f, synthetics = 875f, exotics = 5f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.52f };
				shipModule.Engine.overchargeEvasionAdd = 20;
				shipModule.asteroidDeflectionPercentAdd = 18;
				shipModule.shipEvasionPercentAdd = 6;
				shipModule.overchargePowerNeed = 27;
				shipModule.overchargeSeconds = 60;
				shipModule.starmapSpeedAdd = 16;
				shipModule.powerConsumed = 5;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 35;
				break;
				case 229499087: //engine 2.5 weird
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.2f);
				shipModule.displayName = Core.TT($"Exotic <color=#{colorEngine}ff>Biochemical Engine</color>");
				shipModule.description = Core.TT($"Organic engine with built-in exotic material matrix uses unique biochemical reaction that rivals fusion energy emission to generate thrust. Has good performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, organics = 1500f, synthetics = 1000f, exotics = 7f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.49f };
				shipModule.Engine.overchargeEvasionAdd = 22;
				shipModule.asteroidDeflectionPercentAdd = 20;
				shipModule.shipEvasionPercentAdd = 7;
				shipModule.overchargePowerNeed = 20;
				shipModule.overchargeSeconds = 80;
				shipModule.starmapSpeedAdd = 17;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 5;
				shipModule_maxHealth = 35;
				break;
				case 2023634410: //engine 2.5 terran
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.1f);
				shipModule.displayName = Core.TT($"Military Navy <color=#{colorEngine}ff>Fusion Engine</color>");
				shipModule.description = Core.TT($"Very heavy and durable fusion engine that commonly utilized by serious military organizations, especially Terran Navy. Very good performance and great durability.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 800f, metals = 2000f, synthetics = 1375f, exotics = 9f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.46f };
				shipModule.Engine.overchargeEvasionAdd = 25;
				shipModule.asteroidDeflectionPercentAdd = 22;
				shipModule.shipEvasionPercentAdd = 8;
				shipModule.overchargePowerNeed = 25;
				shipModule.overchargeSeconds = 145;
				shipModule.starmapSpeedAdd = 18;
				shipModule.powerConsumed = 6;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 40;
				break;
				case 84732634: //engine 03 emperor banks
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 2.0f);
				shipModule.displayName = Core.TT($"Commercial <color=#{colorEngine}ff>Plasma Engine</color>");
				shipModule.description = Core.TT($"Engine that was developed for sake of profit and is sold to anybody who can afford it. Private manufacturing will lead to breach of copyright agreement and lawsuit.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2500f, synthetics = 1750f, exotics = 11f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.43f };
				shipModule.Engine.overchargeEvasionAdd = 28;
				shipModule.asteroidDeflectionPercentAdd = 24;
				shipModule.shipEvasionPercentAdd = 9;
				shipModule.overchargePowerNeed = 30;
				shipModule.overchargeSeconds = 135;
				shipModule.starmapSpeedAdd = 19;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 40;
				break;
				case 1131227094: //engine 04 red
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.9f);
				shipModule.displayName = Core.TT($"Interceptor <color=#{colorEngine}ff>Plasma Engine</color>");
				shipModule.description = Core.TT($"Can you imagine it? Somebody managed to properly reverse engineer commercial version and recreate even better engine that not within reach of these copyright agreements.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3000f, synthetics = 2250f, exotics = 13f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.40f };
				shipModule.Engine.overchargeEvasionAdd = 31;
				shipModule.asteroidDeflectionPercentAdd = 26;
				shipModule.shipEvasionPercentAdd = 10;
				shipModule.overchargePowerNeed = 28;
				shipModule.overchargeSeconds = 100;
				shipModule.starmapSpeedAdd = 20;
				shipModule.powerConsumed = 7;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 40;
				break;
				case 292475796: //engine 03 bioship
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.8f);
				shipModule.displayName = Core.TT($"Heavy Ion <color=#{colorEngine}ff>Prismatic Engine</color>");
				shipModule.description = Core.TT($"Houses set of prismatic mirrors that accelerate speed of ion energy emission to the levels that surpass plasma energy, thus generating high thrust with great efficiency.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 3750f, synthetics = 2750f, exotics = 15f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.37f };
				shipModule.Engine.overchargeEvasionAdd = 34;
				shipModule.asteroidDeflectionPercentAdd = 28;
				shipModule.shipEvasionPercentAdd = 11;
				shipModule.overchargePowerNeed = 24;
				shipModule.overchargeSeconds = 210;
				shipModule.starmapSpeedAdd = 22;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 45;
				break;
				case 1508923010: //engine 2 large robust
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.7f);
				shipModule.displayName = Core.TT($"Prototype <color=#{colorEngine}ff>Antimatter Engine</color>");
				shipModule.description = Core.TT($"Prototype engine with heavy armoring to ensure stability when using antimatter energy emission to generate thrust. Has great fuel efficiency and high durability.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 4500f, synthetics = 3250f, exotics = 20f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.34f };
				shipModule.Engine.overchargeEvasionAdd = 38;
				shipModule.asteroidDeflectionPercentAdd = 31;
				shipModule.shipEvasionPercentAdd = 12;
				shipModule.overchargePowerNeed = 40;
				shipModule.overchargeSeconds = 150;
				shipModule.starmapSpeedAdd = 24;
				shipModule.powerConsumed = 8;
				shipModule.maxHealthAdd = 15;
				shipModule_maxHealth = 45;
				break;
				case 1536420907: //engine 4 spideraa
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.6f);
				shipModule.displayName = Core.TT($"Repulsor <color=#{colorEngine}ff>Meta-Kinetic Engine</color>");
				shipModule.description = Core.TT($"Engine that uses kinetic energy and unknown principles that rival antimatter energy emission to generate thrust. Has great performance and amazing fuel efficiency.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 2000f, metals = 5750f, synthetics = 4000f, exotics = 25f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.31f };
				shipModule.Engine.overchargeEvasionAdd = 42;
				shipModule.asteroidDeflectionPercentAdd = 34;
				shipModule.shipEvasionPercentAdd = 13;
				shipModule.overchargePowerNeed = 32;
				shipModule.overchargeSeconds = 120;
				shipModule.starmapSpeedAdd = 26;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				case 366713264: //engine 04 xblack
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.5f);
				shipModule.displayName = Core.TT($"Assault <color=#{colorEngine}ff>Antimatter Engine</color>");
				shipModule.description = Core.TT($"Combat oriented engine that uses antimatter energy emission to generate thrust. Mostly installed on heavy ships that need to move fast. Has excellent performance.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 2500f, metals = 6500f, synthetics = 4500f, exotics = 35f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.28f };
				shipModule.Engine.overchargeEvasionAdd = 46;
				shipModule.asteroidDeflectionPercentAdd = 37;
				shipModule.shipEvasionPercentAdd = 14;
				shipModule.overchargePowerNeed = 36;
				shipModule.overchargeSeconds = 90;
				shipModule.starmapSpeedAdd = 28;
				shipModule.powerConsumed = 9;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				case 1119228548: //engine 2 F-gulper
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 9, 10);
				if (!FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Contains(shipModule.PrefabId)) FFU_BE_Defs.essentialTypeIDs[Core.EssentialType.Engine].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 1.4f);
				shipModule.displayName = Core.TT($"Particle-Folding <color=#{colorEngine}ff>Quantum Engine</color>");
				shipModule.description = Core.TT($"Experimental exploration engine that uses particle-folding quantum technology to move through interstellar void. Has amazing performance and perfect fuel efficiency.");
				shipModule.craftCost = new ResourceValueGroup { fuel = 3000f, metals = 7500f, synthetics = 5000f, exotics = 50f };
				shipModule_Engine_consumedPerDistance = new ResourceValueGroup { fuel = 0.25f };
				shipModule.Engine.overchargeEvasionAdd = 50;
				shipModule.asteroidDeflectionPercentAdd = 40;
				shipModule.shipEvasionPercentAdd = 15;
				shipModule.overchargePowerNeed = 30;
				shipModule.overchargeSeconds = 180;
				shipModule.starmapSpeedAdd = 30;
				shipModule.powerConsumed = 10;
				shipModule.maxHealthAdd = 10;
				shipModule_maxHealth = 50;
				break;
				default:
				Debug.LogWarning($"[NEW ENGINE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(ENGINE) {shipModule.name}";
				break;
			}
			AccessTools.FieldRefAccess<EngineModule, ResourceValueGroup>(shipModule.Engine, "consumedPerDistance") = shipModule_Engine_consumedPerDistance;
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}