#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0436
#pragma warning disable CS0414
#pragma warning disable CS0108

using System;
using UnityEngine;
using MonoMod;
using RST.UI;
using System.Collections.Generic;
using RST;
using HarmonyLib;
using System.IO;
using FFU_Bleeding_Edge;
using System.Text;
using System.Linq;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Modules {
		public static List<ShipModule> originalList = new List<ShipModule>();
		public static void InitShipSlotsList() {
			try {
				foreach (ModuleSlot moduleSlot in Resources.FindObjectsOfTypeAll<ModuleSlot>()) {
					if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Interface: [{moduleSlot.name}] ({moduleSlot.PrefabId}) {moduleSlot.displayName} (H:{moduleSlot.shipMaxHealthAdd}/D:{moduleSlot.deflectChance})");
					ApplySlotChanges(moduleSlot);
					FFU_BE_Defs.prefabModdedSlotsList.Add(moduleSlot);
				}
			} catch (Exception ex) { Debug.LogError(ex); }
		}
		public static void ApplySlotChanges(ModuleSlot moduleSlot) {
			if (moduleSlot.name.Contains("Bridge slot")) {
				moduleSlot.displayName = "Bridge Interface";
				moduleSlot.description = "Allows installation and interfacing with Bridge-type modules that allow crewmembers to operate ship.";
				moduleSlot.shipMaxHealthAdd = 50;
			} else if (moduleSlot.name.Contains("Warp slot")) {
				moduleSlot.displayName = "FTL Interface";
				moduleSlot.description = "Allows installation and interfacing with Faster-Then-Light navigation modules such as Warp Drives and Hyper-Drives.";
				moduleSlot.shipMaxHealthAdd = 50;
			} else if (moduleSlot.name.Contains("Engine slot")) {
				moduleSlot.displayName = "Engine Interface";
				moduleSlot.description = "Allows installation and interfacing with Engine-type modules that generate thrust for efficient sub-light navigation.";
				moduleSlot.shipMaxHealthAdd = 50;
			} else if (moduleSlot.name.Contains("Weapon slot")) {
				moduleSlot.displayName = "Weapon Interface";
				moduleSlot.description = "Allows installation and interfacing with weapon and ordnance systems beside automated defenses and internal-type modules.";
				moduleSlot.shipMaxHealthAdd = 20;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 1500f, metals = 3750f, synthetics = 3750f, exotics = 20f };
				}
			} else if (moduleSlot.name.Contains("Hybrid slot")) {
				moduleSlot.displayName = "Hybrid Interface";
				moduleSlot.description = "Allows installation and interfacing with automated defenses and electronic warfare systems beside internal-type modules.";
				moduleSlot.shipMaxHealthAdd = 15;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 1000f, metals = 2625f, synthetics = 2625f, exotics = 10f };
					if (!upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 2500f, metals = 5000f, synthetics = 5000f, exotics = 50f };
				}
			} else if (moduleSlot.name.Contains("Internal core slot")) {
				moduleSlot.displayName = "Core Interface";
				moduleSlot.description = "Allows installation and interfacing with same internal-type modules, but at the same time reinforces ship's integrity.";
				moduleSlot.shipMaxHealthAdd = 10;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 500f, metals = 1875f, synthetics = 1875f, exotics = 5f };
					if (!upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 1500f, metals = 3500f, synthetics = 3500f, exotics = 25f };
				}
			} else if (moduleSlot.name.Contains("Internal slot")) {
				moduleSlot.displayName = "Internal Interface";
				moduleSlot.description = "Allows installation and interfacing with all internal-type modules such as reactors, shields, armors, greenhouses & etc.";
				moduleSlot.shipMaxHealthAdd = 5;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (!upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 750f, metals = 2500f, synthetics = 2500f, exotics = 10f };
				}
			} else if (moduleSlot.name.Contains("Storage slot")) {
				moduleSlot.displayName = "Storage Interface";
				moduleSlot.description = "Allows installation and interfacing with modular storage compartment. Has complex built-in module repackaging mechanism.";
				moduleSlot.shipMaxHealthAdd = 0;
			} else if (moduleSlot.name.Contains("Container slot")) {
				moduleSlot.displayName = "Container Interface";
				moduleSlot.description = "Allows installation and interfacing with basic container-type modules that doesn't require heavy processing power.";
				moduleSlot.shipMaxHealthAdd = 0;
			} else if (moduleSlot.name.Contains("Nuke launcher slot")) {
				moduleSlot.displayName = "Capital Ordnance Interface";
				moduleSlot.description = "Allows installation, operation and interfacing with massive single-use payloads with anti-capital capabilities.";
				moduleSlot.shipMaxHealthAdd = 0;
			} else if (moduleSlot.name.Contains("Undeveloped") && moduleSlot.name.Contains("nuke")) {
				moduleSlot.displayName = "Unfinished Ordnance Interface";
				moduleSlot.description = "Capital ordnance interface that was left unfinished and useless due to certain circumstances. Can be upgraded.";
				moduleSlot.shipMaxHealthAdd = 0;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (!upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 1000f, metals = 2500f, synthetics = 1500f, exotics = 10f };
				}
			} else if (moduleSlot.name.Contains("Undeveloped internal slot")) {
				moduleSlot.displayName = "Unfinished Internal Interface";
				moduleSlot.description = "Internal module interface that was left unfinished and useless due to certain circumstances. Can be upgraded.";
				moduleSlot.shipMaxHealthAdd = 0;
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					if (!upgrade.isDowngrade) upgrade.cost = new ResourceValueGroup { fuel = 500f, metals = 1250f, synthetics = 750f, exotics = 5f };
				}
			}
			if (moduleSlot.shipMaxHealthAdd > 0) moduleSlot.shipMaxHealthAdd = Mathf.RoundToInt(moduleSlot.shipMaxHealthAdd * FFU_BE_Defs.coreSlotsHealthMult);
			if (FFU_BE_Defs.moduleCraftingForFree) {
				foreach (ModuleSlot.Upgrade upgrade in moduleSlot.upgrades) {
					upgrade.cost.credits = 0f;
					upgrade.cost.exotics = 0f;
					upgrade.cost.explosives = 0f;
					upgrade.cost.fuel = 0f;
					upgrade.cost.metals = 0f;
					upgrade.cost.organics = 0f;
					upgrade.cost.synthetics = 0f;
				}
			}
		}
		public static void InitShipModulesList() {
			try {
				ModuleSlotActionsPanel.altCraftableModulePrefabs = new List<ShipModule>();
				originalList = new List<ShipModule>(Resources.FindObjectsOfTypeAll<ShipModule>());
				foreach (ShipModule shipModule in originalList) {
					if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Module, {GetModuleTypeName(shipModule)} [{shipModule.name}] ({shipModule.PrefabId}) {shipModule.displayName}");
					ApplyModuleEffects(shipModule, true);
					ApplyModuleChanges(shipModule, true);
					ApplyMaxCoreHealth(shipModule);
					if (FFU_BE_Defs.moduleCraftingForFree) AllowCraftForFree(shipModule);
					FFU_BE_Defs.prefabModdedModulesList.Add(shipModule);
				}
				UpdateModuleEffects(FFU_BE_Defs.prefabModdedModulesList);
				FFU_BE_Defs.prefabModdedModulesList.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				if (FFU_BE_Defs.allModulesCraftable) {
					foreach (ShipModule litedModule in FFU_BE_Defs.prefabModdedModulesList)
						if (FFU_BE_Defs.IsAllowedModuleCategory(litedModule)) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(litedModule);
						else if (!FFU_BE_Defs.IsAllowedModuleCategory(litedModule) && FFU_BE_Defs.allTypesCraftable) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(litedModule);
					ModuleSlotActionsPanel.altCraftableModulePrefabs.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				}
				if (FFU_BE_Defs.createModulesCSV) WeaponListCreateCSV(FFU_BE_Defs.prefabModdedModulesList);
				if (FFU_BE_Defs.showSortedList && FFU_BE_Defs.showPrefabIDs && FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name + " [" + shipModule.PrefabId + "]" + " (" + shipModule.displayName + ") {" + shipModule.description + "}");
				else if (FFU_BE_Defs.showSortedList && FFU_BE_Defs.showPrefabIDs && !FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name + " [" + shipModule.PrefabId + "]" + " (" + shipModule.displayName + ")");
				else if (FFU_BE_Defs.showSortedList && !FFU_BE_Defs.showPrefabIDs && !FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name);
				if (FFU_BE_Defs.dumpObjectLists) {
					foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList)
						if (shipModule.type == ShipModule.Type.Weapon_Nuke)
							if (shipModule.Weapon.ProjectileOrBeamPrefab.SpawnIntruderPrefab?.GetComponents<Crewmember>() != null) 
								foreach (Crewmember intruderCrew in shipModule.Weapon.ProjectileOrBeamPrefab.SpawnIntruderPrefab.GetComponents<Crewmember>())
									Debug.Log($"Intruder, {shipModule.name} [{shipModule.Weapon.ProjectileOrBeamPrefab.name}] {intruderCrew.name} ({intruderCrew.PrefabId}) {intruderCrew.displayName}");
				}
				originalList = null;
			} catch (Exception ex) { Debug.LogError(ex); }
		}
		public static void InitModuleMalfunctions() {
			try {
				foreach (SelfCombustible sMalfunction in Resources.FindObjectsOfTypeAll<SelfCombustible>()) {
					switch(sMalfunction.name) {
						case "reactor 12 custom old": sMalfunction.chance = 0; break;
						case "fuel combinator 1A old": sMalfunction.chance = 0; break;
						case "explosives combinator 1": sMalfunction.chance = 0; break;
						case "explosives combinator diy": sMalfunction.chance = 0; break;
						case "explosives combinator tiger": sMalfunction.chance = 0; break;
						case "reactor 4 diy 1": sMalfunction.chance = 0.0005f; break;
						case "reactor 5 diy 2 backup": sMalfunction.chance = 0.0005f; break;
						case "reactor 7 diy 3": sMalfunction.chance = 0.0005f; break;
						case "reactor 9 small old": sMalfunction.chance = 0.0003f; break;
						case "reactor 13 rats": sMalfunction.chance = 0.0001f; break;
						case "engine 01 primitive": sMalfunction.chance = 0.0001f; break;
						default: Debug.LogWarning($"[MALFUNCTION] {sMalfunction.name} {sMalfunction.chance}"); break;
					}
					FFU_BE_Defs.prefabMalfunctionsList.Add(sMalfunction);
				}
			} catch (Exception ex) { Debug.LogError(ex); }
		}
		public static void ApplyModuleEffects(ShipModule shipModule, bool initItemData = false) {
			switch (shipModule.PrefabId) {
				case 185094886: //weapon miscmissile x4
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "missile rats d2");
				break;
				case 1281856982: //weapon ATK-MK1
				case 1521997681: //weapon ATK-MK1 old
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Cannon projectile 1 d2");
				break;
				case 412909021: //weapon gatling Tiger
				case 1086561638: //weapon Segmented cannonx2 A
				case 1086561639: //weapon Segmented cannonx2 B
				case 1086561640: //weapon Segmented cannonx2 C
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Cannon projectile rocketsound d2");
				break;
				case 1316645801: //weapon cubecannon1
				case 1615383632: //weapon cubecannon1x3
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Cannon projectile2 d2");
				break;
				case 704483685: //weapon gatling RatA 14,4
				case 123083978: //weapon gatling RatB 15,5
				case 1092529672: //weapon gatling whiteA 13,4
				case 689245145: //weapon gatling whiteB 14,5
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Gatling projectile thin");
				break;
				case 1501025877: //weapon gatling ClawA 12,4
				case 1566651491: //weapon gatling ClawB 14,5
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Gatling projectile medium");
				break;
				case 1751631045: //weapon Sniper cannon 0 DIY
				case 514626098: //weapon Sniper cannon 0
				case 1499937036: //weapon Sniper cannon 2
				case 918537329: //weapon Sniper cannon 3
				case 1240034396: //weapon Sniper cannon 2 insectoid
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDamageDealersList.Find(prj => prj.name == "Gatling projectile thick");
				break;
				case 893617597: //0 DIY PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == "pointdef beam gatling single");
				break;
				case 687853920: //1 Rat PD
				case 106454213: //3 Rat PD 2
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef beam gatling" : "pointdef beam gatling single"));
				break;
				case 804479599: //6 Squid PD
				case 583909453: //4 Insectoid PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef beam" : "pointdef beam gatling"));
				break;
				case 1468502746: //5 Human PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef laser doubledam" : "pointdef beam gatling"));
				break;
				case 1381757148: //7 Red PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef laser doubledam" : "pointdef beam"));
				break;
				case 507685108: //8 Chunk PD
				case 1230723452: //10 laser PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef beam gatling doubledam" : "pointdef beam"));
				break;
				case 1495856276: //8 Crystal PD
				case 938711464: //2 Tiger PD
				shipModule.PointDefence.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == (FFU_BE_Defs.flagDLC_OldEnm ? "pointdef bluelaser doubledam" : "pointdef beam"));
				break;
				default: break;
			}
		}
		public static void UpdateModuleEffects(List<ShipModule> shipModules) {
			//Definitions
			var effectRailgun = shipModules.Find(x => x.PrefabId == 1086561640).Weapon.barrelTipExhaustPrefabRef; //weapon Segmented cannonx2 C
			var explosionEMP = shipModules.Find(x => x.PrefabId == 430038657).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef; //00 DIY EMP nuke launcher
			var explosionCHEM = shipModules.Find(x => x.PrefabId == 22001514).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef; //08c Green nuke launcher
			var explosionBIO = shipModules.Find(x => x.PrefabId == 141822690).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef; //07 Weirdship Minibio nuke launcher
			var spawnerMaggot = shipModules.Find(x => x.PrefabId == 1350933427).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef; //99 maggot spawner launcher
			var packImplants = shipModules.Find(x => x.PrefabId == 89687050).image; //medical pack organics, synth
			var packWeapons = shipModules.Find(x => x.PrefabId == 813048445).image; //explosives pack
			//Alterations
			shipModules.Find(x => x.PrefabId == 412909021).Weapon.barrelTipExhaustPrefabRef = effectRailgun; //weapon gatling Tiger
			shipModules.Find(x => x.PrefabId == 92356131).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionEMP; //00 DIY decoy nuke launcher
			shipModules.Find(x => x.PrefabId == 1771248833).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionCHEM; //04 DIY plastics launcher
			shipModules.Find(x => x.PrefabId == 955652403).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionCHEM; //07 DIY acid nuke launcher
			shipModules.Find(x => x.PrefabId == 1178343825).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionCHEM; //13 nanopellet nuke launcher
			shipModules.Find(x => x.PrefabId == 475763260).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionCHEM; //07 Weirdship Chem nuke launcher
			if (FFU_BE_Defs.flagDLC_SupPak) shipModules.Find(x => x.PrefabId == 1711403825).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionCHEM; //Tiger sharpnel nuke launcher
			shipModules.Find(x => x.PrefabId == 2053889862).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionBIO; //07 DIY bionuke launcher
			shipModules.Find(x => x.PrefabId == 1350933427).Weapon.ProjectileOrBeamPrefab.Effects.explosionPoolRef = explosionBIO; //99 maggot spawner launcher
			shipModules.Find(x => x.PrefabId == 2053889862).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef = spawnerMaggot; //07 DIY bionuke launcher
			shipModules.Find(x => x.PrefabId == 141822690).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef = spawnerMaggot; //07 Weirdship Minibio nuke launcher
			shipModules.Find(x => x.PrefabId == 1745395900).image = packWeapons; //artifactmodule tec 17 broken screen gizmo, data
			shipModules.Find(x => x.PrefabId == 179311957).image = packWeapons; //artifactmodule tec 25 broken screen gizmo
			shipModules.Find(x => x.PrefabId == 760711671).image = packWeapons; //artifactmodule tec 32 broken container gizmo
			shipModules.Find(x => x.PrefabId == 656277331).image = packWeapons; //artifactmodule tec 37 ripped quarter of a dome
			shipModules.Find(x => x.PrefabId == 760711667).image = packWeapons; //artifactmodule tec 36 broken gizmo
			shipModules.Find(x => x.PrefabId == 1279608160).image = packWeapons; //artifactmodule tec 34 data core grammofon
			shipModules.Find(x => x.PrefabId == 1316302015).image = packWeapons; //artifactmodule tec 35 data core makk
			shipModules.Find(x => x.PrefabId == 685017033).image = packImplants; //artifactmodule tec 33 biostasis nice worm
			shipModules.Find(x => x.PrefabId == 957508477).image = packImplants; //artifactmodule tec 11 biostasis
		}
		public static string GetModuleTypeName(ShipModule shipModule) {
			switch (shipModule.type) {
				case ShipModule.Type.Weapon: return "Weapon Armament";
				case ShipModule.Type.ResearchLab: return "Research Lab";
				case ShipModule.Type.Engine: return "Ship Engine";
				case ShipModule.Type.ResourcePack: return "Resource Pack";
				case ShipModule.Type.Sensor: return "Navigation Sensor";
				case ShipModule.Type.Bridge: return "Command Bridge";
				case ShipModule.Type.ShieldGen: return "Shield Generator";
				case ShipModule.Type.Warp: return "Warp Drive";
				case ShipModule.Type.Reactor: return "Energy Reactor";
				case ShipModule.Type.Medbay: return "Medical Bay";
				case ShipModule.Type.Weapon_Nuke: return "Capital Missile";
				case ShipModule.Type.MaterialsConverter: return "Materials Converter";
				case ShipModule.Type.Container: return "Storage Container";
				case ShipModule.Type.Cryosleep: return "Cryosleep Pod";
				case ShipModule.Type.Dronebay: return "Drone Repair Bay";
				case ShipModule.Type.Garden: return "Greenhouse/Growery";
				case ShipModule.Type.StealthDecryptor: return "Stealth Decryptor";
				case ShipModule.Type.PassiveECM: return "Passive ECM";
				case ShipModule.Type.Integrity: return "Integrity Armor";
				case ShipModule.Type.PointDefence: return "Point Defense";
				case ShipModule.Type.Decoy: return "Decoy Module";
				default: return "Unknown/Uncategorized";
			}
		}
		public static void ApplyModuleChanges(ShipModule shipModule, bool initItemData = false) {
			CraftCostFallback(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.ResourcePack: FFU_BE_Prefab_ResPacks.UpdateResourcePackModule(shipModule, initItemData); break;
				case ShipModule.Type.Weapon_Nuke: FFU_BE_Prefab_Nukes.UpdateNukeModule(shipModule, initItemData); break;
				case ShipModule.Type.Weapon: FFU_BE_Prefab_Weapons.UpdateWeaponModule(shipModule, initItemData); break;
				case ShipModule.Type.PointDefence: FFU_BE_Prefab_PointDefences.UpdatePointDefModule(shipModule, initItemData); break;
				case ShipModule.Type.Bridge: FFU_BE_Prefab_Bridges.UpdateBridgeModule(shipModule, initItemData); break;
				case ShipModule.Type.Engine: FFU_BE_Prefab_Engines.UpdateEngineModule(shipModule, initItemData); break;
				case ShipModule.Type.Warp: FFU_BE_Prefab_Drives.UpdateWarpDriveModule(shipModule, initItemData); break;
				case ShipModule.Type.Reactor: FFU_BE_Prefab_Reactors.UpdateReactorModule(shipModule, initItemData); break;
				case ShipModule.Type.Container: FFU_BE_Prefab_Storages.UpdateStorageModule(shipModule, initItemData); break;
				case ShipModule.Type.Integrity: FFU_BE_Prefab_Armors.UpdateArmorModule(shipModule, initItemData); break;
				case ShipModule.Type.ShieldGen: FFU_BE_Prefab_Shields.UpdateShieldModule(shipModule, initItemData); break;
				case ShipModule.Type.Sensor: FFU_BE_Prefab_Sensors.UpdateSensorModule(shipModule, initItemData); break;
				case ShipModule.Type.StealthDecryptor: FFU_BE_Prefab_Decryptors.UpdateDecryptorModule(shipModule, initItemData); break;
				case ShipModule.Type.PassiveECM: FFU_BE_Prefab_PassiveECMs.UpdateCountermeasureModule(shipModule, initItemData); break;
				case ShipModule.Type.Dronebay: FFU_BE_Prefab_HealthBays.UpdateHealthBayModule(shipModule, initItemData); break;
				case ShipModule.Type.Medbay: FFU_BE_Prefab_HealthBays.UpdateHealthBayModule(shipModule, initItemData); break;
				case ShipModule.Type.Cryosleep: FFU_BE_Prefab_CryoBays.UpdateCryosleepModule(shipModule, initItemData); break;
				case ShipModule.Type.ResearchLab: FFU_BE_Prefab_Laboratories.UpdateLaboratoryModule(shipModule, initItemData); break;
				case ShipModule.Type.Garden: FFU_BE_Prefab_Greenhouses.UpdateGreenhouseModule(shipModule, initItemData); break;
				case ShipModule.Type.MaterialsConverter: FFU_BE_Prefab_Converters.UpdateConverterModule(shipModule, initItemData); break;
				case ShipModule.Type.Decoy: FFU_BE_Prefab_Decoys.UpdateDecoyModule(shipModule, initItemData); break;
				default: FFU_BE_Prefab_Miscellaneous.UpdateMsicModule(shipModule, initItemData); break;
			}
		}
		private static void CraftCostFallback(ShipModule shipModule) {
			if (shipModule.scrapGet.exotics > shipModule.craftCost.exotics) shipModule.craftCost.exotics = shipModule.scrapGet.exotics * 5f;
			if (shipModule.scrapGet.explosives > shipModule.craftCost.explosives) shipModule.craftCost.explosives = shipModule.scrapGet.explosives * 5f;
			if (shipModule.scrapGet.fuel > shipModule.craftCost.fuel) shipModule.craftCost.fuel = shipModule.scrapGet.fuel * 5f;
			if (shipModule.scrapGet.metals > shipModule.craftCost.metals) shipModule.craftCost.metals = shipModule.scrapGet.metals * 5f;
			if (shipModule.scrapGet.organics > shipModule.craftCost.organics) shipModule.craftCost.organics = shipModule.scrapGet.organics * 5f;
			if (shipModule.scrapGet.synthetics > shipModule.craftCost.synthetics) shipModule.craftCost.synthetics = shipModule.scrapGet.synthetics * 5f;
		}
		private static void AllowCraftForFree(ShipModule shipModule) {
			shipModule.craftCost.credits = 0f;
			shipModule.craftCost.exotics = 0f;
			shipModule.craftCost.explosives = 0f;
			shipModule.craftCost.fuel = 0f;
			shipModule.craftCost.metals = 0f;
			shipModule.craftCost.organics = 0f;
			shipModule.craftCost.synthetics = 0f;
		}
		public static void UpdateCommonStats(ShipModule shipModule) {
			UpdateCommonStatsCore(shipModule);
			if (shipModule.type != ShipModule.Type.Integrity && !FFU_BE_Defs.IsUnusableModule(shipModule) && !shipModule.name.Contains("artifactmodule")) shipModule.maxHealthAdd = 0;
		}
		public static void UpdateCommonStatsCore(ShipModule shipModule) {
			RecalcModuleShopPrice(shipModule);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") * FFU_BE_Defs.shipModuleHealthMult);
			if ((shipModule.craftCost.fuel * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.fuel = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.fuel = shipModule.craftCost.fuel * FFU_BE_Defs.resourcesScrapFraction;
			if ((shipModule.craftCost.organics * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.organics = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.organics = shipModule.craftCost.organics * FFU_BE_Defs.resourcesScrapFraction;
			if ((shipModule.craftCost.synthetics * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.synthetics = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.synthetics = shipModule.craftCost.synthetics * FFU_BE_Defs.resourcesScrapFraction;
			if ((shipModule.craftCost.metals * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.metals = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.metals = shipModule.craftCost.metals * FFU_BE_Defs.resourcesScrapFraction;
			if ((shipModule.craftCost.explosives * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.explosives = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.explosives = shipModule.craftCost.explosives * FFU_BE_Defs.resourcesScrapFraction;
			if ((shipModule.craftCost.exotics * FFU_BE_Defs.resourcesScrapFraction) < 1f) shipModule.scrapGet.exotics = 0;
			else if (!shipModule.displayName.Contains("Cache")) shipModule.scrapGet.exotics = shipModule.craftCost.exotics * FFU_BE_Defs.resourcesScrapFraction;
			if (shipModule.type != ShipModule.Type.Weapon_Nuke) {
				if (!FFU_BE_Defs.fuelIsCraftingEnergy) shipModule.craftCost.fuel = 0;
				if (FFU_BE_Defs.fuelIsScrapRefunded) shipModule.scrapGet.fuel = 0;
			}
		}
		public static void RecalcModuleShopPrice(ShipModule shipModule) {
			shipModule.costCreditsInShop = Mathf.RoundToInt(shipModule.craftCost.organics + shipModule.craftCost.fuel + shipModule.craftCost.metals + shipModule.craftCost.synthetics + shipModule.craftCost.explosives + shipModule.craftCost.exotics * 30);
		}
		public static void ApplyMaxCoreHealth(ShipModule shipModule) {
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health") = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
		}
		public static void ApplyMaxNewHealth(ShipModule shipModule) {
			Core.BonusTier moduleTier = FFU_BE_Mod_Technology.GetModuleTier(shipModule);
			Core.BonusMod moduleModifier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			int refModuleMaxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			float healthModifier = moduleModifier == Core.BonusMod.Reinforced ? 2f : moduleModifier == Core.BonusMod.Fragile ? 0.5f : 1f;
			float maxHealth = Mathf.RoundToInt(refModuleMaxHealth * FFU_BE_Mod_Technology.GetTierBonus(moduleTier, Core.BonusType.Default) * healthModifier);
			if (FFU_BE_Defs.IsStaticModuleType(shipModule)) maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(maxHealth);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health") = Mathf.RoundToInt(maxHealth);
		}
		public static void ApplyRelativeNewHealth(ShipModule shipModule, float healthPercent) {
			Core.BonusTier moduleTier = FFU_BE_Mod_Technology.GetModuleTier(shipModule);
			Core.BonusMod moduleModifier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			int refModuleMaxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			float healthModifier = moduleModifier == Core.BonusMod.Reinforced ? 2f : moduleModifier == Core.BonusMod.Fragile ? 0.5f : 1f;
			float maxHealth = Mathf.RoundToInt(refModuleMaxHealth * FFU_BE_Mod_Technology.GetTierBonus(moduleTier, Core.BonusType.Default) * healthModifier);
			if (FFU_BE_Defs.IsStaticModuleType(shipModule)) maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = Mathf.RoundToInt(maxHealth);
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health") = Mathf.RoundToInt(maxHealth * healthPercent);
		}
		public static float GetRelativeHealth(ShipModule shipModule) {
			Core.BonusTier moduleTier = FFU_BE_Mod_Technology.GetModuleTier(shipModule);
			Core.BonusMod moduleModifier = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			int refModuleMaxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			float healthModifier = moduleModifier == Core.BonusMod.Reinforced ? 2f : moduleModifier == Core.BonusMod.Fragile ? 0.5f : 1f;
			float maxHealth = Mathf.RoundToInt(refModuleMaxHealth * FFU_BE_Mod_Technology.GetTierBonus(moduleTier, Core.BonusType.Default) * healthModifier);
			if (FFU_BE_Defs.IsStaticModuleType(shipModule)) maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(refModule, "maxHealth");
			int currHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "health");
			return Mathf.Min(1.0f, currHealth / maxHealth);
		}
		public static float GetRelativeHealth(Door door) {
			return Mathf.Min(1.0f, door.Health / door.MaxHealth);
		}
		private static void WeaponListCreateCSV(List<ShipModule> shipModulesList) {
			if (File.Exists(FFU_BE_Base.appDataPath + @"ModsConf\FFU_Bleeding_Edge_Weapons.csv")) File.Delete(FFU_BE_Base.appDataPath + @"ModsConf\FFU_Bleeding_Edge_Weapons.csv");
			using (StreamWriter shipModulesListFile = new StreamWriter(FFU_BE_Base.appDataPath + @"ModsConf\FFU_Bleeding_Edge_Weapons.csv")) {
				shipModulesListFile.Write("Unique Name,");
				shipModulesListFile.Write("Display Name,");
				shipModulesListFile.Write("Type,");
				shipModulesListFile.Write("Reload Time,");
				shipModulesListFile.Write("Ignition Time,");
				shipModulesListFile.Write("Accuracy,");
				shipModulesListFile.Write("Damage Radius,");
				shipModulesListFile.Write("Ignores Shields,");
				shipModulesListFile.Write("Never Deflects,");
				shipModulesListFile.Write("Salvo Size,");
				shipModulesListFile.Write("Module Damage,");
				shipModulesListFile.Write("Hull Damage,");
				shipModulesListFile.Write("Shield Damage,");
				shipModulesListFile.Write("Crew Damage,");
				shipModulesListFile.Write("Fire Chance,");
				shipModulesListFile.Write("EMP,");
				shipModulesListFile.Write("Organics/Shot,");
				shipModulesListFile.Write("Fuel/Shot,");
				shipModulesListFile.Write("Metals/Shot,");
				shipModulesListFile.Write("Synthetics/Shot,");
				shipModulesListFile.Write("Explosives/Shot,");
				shipModulesListFile.Write("Exotic/Shot,");
				shipModulesListFile.Write("Damage Dealer,");
				shipModulesListFile.Write("Damage Prefab,");
				shipModulesListFile.Write("Health,");
				shipModulesListFile.Write("Velocity,");
				shipModulesListFile.Write("Duration,");
				shipModulesListFile.Write("Point Defense Detection,");
				shipModulesListFile.Write("Point Defense Priority,");
				shipModulesListFile.Write("Deflection Angle,");
				shipModulesListFile.Write("Deflection Distance (Min),");
				shipModulesListFile.Write("Deflection Distance (Max),");
				shipModulesListFile.Write("Beam Deflection,");
				shipModulesListFile.Write("Expiration Time");
				shipModulesListFile.Write("\n");
				foreach (ShipModule shipModule in shipModulesList) {
					if (shipModule.type == ShipModule.Type.Weapon || shipModule.type == ShipModule.Type.Weapon_Nuke) {
						shipModulesListFile.Write(shipModule.name.Replace(",", " ") + ",");
						shipModulesListFile.Write(shipModule.displayName.Replace(",", " ") + ",");
						shipModulesListFile.Write((shipModule.type == ShipModule.Type.Weapon ? "Weapon" : (shipModule.type == ShipModule.Type.Weapon_Nuke ? "Nuke" : "???")) + ",");
						shipModulesListFile.Write((shipModule.Weapon.reloadInterval > 0 ? shipModule.Weapon.reloadInterval.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.preShootDelay > 0 ? shipModule.Weapon.preShootDelay.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.accuracy > 0 ? shipModule.Weapon.accuracy.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? string.Format("{0:0.###}", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius) : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? "Yes" : "No") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? "Yes" : "No") + ",");
						shipModulesListFile.Write((shipModule.Weapon.magazineSize > 0 ? shipModule.Weapon.magazineSize.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg.ToString() : "") + ",");
						shipModulesListFile.Write(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel.ToString() + ",");
						shipModulesListFile.Write(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel.ToString() + ",");
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.organics > 0 ? shipModule.Weapon.resourcesPerShot.organics.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.fuel > 0 ? shipModule.Weapon.resourcesPerShot.fuel.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.metals > 0 ? shipModule.Weapon.resourcesPerShot.metals.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.synthetics > 0 ? shipModule.Weapon.resourcesPerShot.synthetics.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.explosives > 0 ? shipModule.Weapon.resourcesPerShot.explosives.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.Weapon.resourcesPerShot.exotics > 0 ? shipModule.Weapon.resourcesPerShot.exotics.ToString() : "") + ",");
						shipModulesListFile.Write((shipModule.type == ShipModule.Type.Weapon ? ((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Projectile" : ((shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? "Beam" : "???")) : "Nuke") + ",");
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? shipModule.Weapon.ProjectileOrBeamPrefab.name.ToString() : ((shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? shipModule.Weapon.ProjectileOrBeamPrefab.name.ToString() : "???")) + ",");
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth").ToString() : "") + ",");
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed.ToString() : "") + ",");
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Beam).duration.ToString() : "") + ",");
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis") ? "Yes" : "No") : "") + ","); ;
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority").ToString() : "") + ","); ;
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectAngleRandom.ToString() : "") + ","); ;
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMin.ToString() : "") + ","); ;
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMax.ToString() : "") + ","); ;
						shipModulesListFile.Write(((shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? (AccessTools.FieldRefAccess<Beam, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Beam, "doDeflect") ? "Yes" : "No") : "") + ","); ;
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).selfDestructTime.ToString() : ""); ;
						shipModulesListFile.Write("\n");
					}
				}
			}
		}
	}
}

namespace RST {
	public class patch_ShipModule : ShipModule {
		[MonoModIgnore] private int maxHealth;
		[MonoModIgnore] private bool isPowered;
		[MonoModIgnore] private Ship cachedShip;
		[MonoModIgnore] private Ship cachedShip2;
		[MonoModIgnore] private void Unpack() { }
		[MonoModIgnore] private void EndOverload() { }
		[MonoModIgnore] private void UnpackShared() { }
		[MonoModIgnore] private void UpdateAppearance() { }
		[MonoModIgnore] private GameObject isJammedInstance;
		[MonoModIgnore] private SelfCombustible SelfCombustible;
		[MonoModIgnore] public float UnpackTime { get; private set; }
		[MonoModIgnore] public bool IsUnpacking { get; private set; }
		[MonoModIgnore] public int MaxHealthLostCount { get; private set; }
		[MonoModIgnore] private CountdownTimer unpackTimer = new CountdownTimer();
		[MonoModIgnore] private static void ScrapGetResources(PlayerResource resource, int amount, StringBuilder logLineSb) { }
		[MonoModIgnore] private static void ScrapGetCredits(PlayerData pd, int amount, StringBuilder logLineSb) { }
		[MonoModIgnore] public MaterialsConverterModule MaterialsConverter => GetCachedComponent<MaterialsConverterModule>(true);
		[MonoModReplace] [ContextMenu("Start unpacking")] public void StartUnpacking(bool useCraftTime) {
		/// Tactical Unpack Times
			UnpackShared();
			UnpackTime = useCraftTime ? FFU_BE_Defs.shipModuleCraftTime : FFU_BE_Defs.shipModuleUnpackTime;
			if (UnpackTime == 0f) { Unpack(); return; }
			IsUnpacking = true;
			unpackTimer.Restart(UnpackTime);
		}
		public void BuyableAssignToStore(Shop shop) {
		/// Update Module Parameters Assigned to Store
			Ownership.SetOwner(Ownership.Owner.None);
			float healthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(this);
			FFU_BE_Mod_Technology.ApplySectorModuleTier(this);
			FFU_BE_Mod_Modules.ApplyRelativeNewHealth(this, healthPercent);
			if (Sector.Instance != null) if (FFU_BE_Defs.ModuleAvailableSector(this) > Sector.Instance.number) costCreditsInShop *= FFU_BE_Defs.blackMarketMult;
			base.transform.SetParent(shop.buyableModulesContainer.transform);
			Pack();
			base.transform.position = new Vector3(10000f, 0f, 0f);
		}
		public void TakeDamage(ShootAtDamageDealer.Damage dd, Vector2 hitPos) {
		/// Do Permanent Damage to Module on Higher Difficulties
			if (IsImmortal) { TryCauseOverload(Mathf.Clamp(dd.moduleDmg + (dd.moduleOverloadSeconds > 0 ? dd.moduleOverloadSeconds : 0), WorldRules.Instance.immortalModuleHitOverloadTime, 60)); return; }
			TakeDamage(dd.moduleDmg);
			if (dd.moduleOverloadSeconds > 0) TryCauseOverload(dd.moduleOverloadSeconds);
			if (dd.moduleDmg > 0 && Health > 0 && FFU_BE_Defs.GetDifficultyAllowCrits() && Ownership.GetOwner() == Ownership.Owner.Me && RstRandom.value < (FFU_BE_Defs.permanentModuleDamageChance * FFU_BE_Defs.GetDifficultyFloatValue())) {
				int permanentDamage = Mathf.CeilToInt(maxHealth * FFU_BE_Defs.permanentModuleDamagePercent);
				if (permanentDamage > 0) {
					int damageAmount = (permanentDamage >= Health) ? (Health - 1) : permanentDamage;
					TakeDamage(damageAmount);
					maxHealth -= permanentDamage;
					StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, string.Format(MonoBehaviourExtended.TT("Critical module damage! {0} max hitpoints reduced by {1}"), DisplayNameLocalized, permanentDamage));
					MaxHealthLostCount++;
				}
			}
		}
		[MonoModReplace] public void Scrap(PlayerData resourcesGoTo, bool addLogLine) {
		/// Multiple Features Implementations on Scrap Module
			float moduleHealthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(this);
			if (resourcesGoTo != null) {
				scrapGet *= moduleHealthPercent;
				StringBuilder stringBuilder = null;
				if (addLogLine) {
					stringBuilder = RstShared.StringBuilder;
					stringBuilder.AppendFormat(MonoBehaviourExtended.TT("Scrapped {0}. Got"), DisplayNameLocalized);
				}
				ScrapGetResources(resourcesGoTo.Organics, (int)scrapGet.organics, stringBuilder);
				ScrapGetResources(resourcesGoTo.Fuel, (int)scrapGet.fuel, stringBuilder);
				ScrapGetResources(resourcesGoTo.Metals, (int)scrapGet.metals, stringBuilder);
				ScrapGetResources(resourcesGoTo.Synthetics, (int)scrapGet.synthetics, stringBuilder);
				ScrapGetResources(resourcesGoTo.Explosives, (int)scrapGet.explosives, stringBuilder);
				ScrapGetResources(resourcesGoTo.Exotics, (int)scrapGet.exotics, stringBuilder);
				ScrapGetCredits(resourcesGoTo, (int)scrapGet.credits, stringBuilder);
				if (addLogLine) {
					if (scrapGet.IsEmpty) stringBuilder.Append(' ').Append(MonoBehaviourExtended.TT("nothing"));
					StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, stringBuilder.ToString());
				}
			}
			if (type != ShipModule.Type.ResourcePack && !name.Contains("artifact")) FFU_BE_Defs.researchProgress += costCreditsInShop * moduleHealthPercent / 1000f;
			if (name.Contains("artifact") && displayName.Contains("Cache")) FFU_BE_Mod_Crewmembers.ApplyCacheToCrewInRange(this);
			else if (name.Contains("artifact") && !displayName.Contains("Cache")) FFU_BE_Defs.researchProgress += (costCreditsInShop + scrapGet.credits) * moduleHealthPercent / 40f;
			if (FFU_BE_Defs.IsAllowedModuleCategory(this) && !FFU_BE_Defs.discoveredModuleIDs.Contains(PrefabId) && !FFU_BE_Defs.unresearchedModuleIDs.ToList().Contains(PrefabId)) {
				FFU_BE_Defs.unresearchedModuleIDs.Add(PrefabId);
				if (FFU_BE_Defs.moduleResearchGoal == 0 && FFU_BE_Defs.unresearchedModuleIDs.Count > 0) {
					ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
					FFU_BE_Defs.moduleResearchGoal = refModule.costCreditsInShop / 10 * (refModule.type == ShipModule.Type.Weapon_Nuke || refModule.displayName.Contains("Cache") ? 10 : 1);
				}
				StringBuilder newItemInResearchQueueMessage = RstShared.StringBuilder;
				newItemInResearchQueueMessage.AppendFormat(MonoBehaviourExtended.TT("{0} is not listed in crafting database! Adding to reverse engineering queue..."), FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == PrefabId).DisplayNameLocalized);
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, newItemInResearchQueueMessage.ToString());
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Discovered new module: [" + PrefabId + "] " + FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == PrefabId).name + "! Adding to reverse engineering queue...");
			}
			if (Container != null) PlayerResource.RedistributeAllTo(Container, Ownership.GetOwner());
			base.enabled = false;
			UnityEngine.Object.Destroy(base.gameObject);
			GameObject gameObject = (!IsPacked) ? Effects.scrappedPrefabRef.Prefab : ((!InStorage) ? Effects.scrappedPackedPrefabRef.Prefab : null);
			if (gameObject != null) UnityEngine.Object.Instantiate(gameObject, base.transform.position, base.transform.rotation);
		}
		[MonoModReplace] public bool StartOvercharge() {
		/// Extensive Damage from Overcharge
			if (!OverchargeAvailable) return false;
			WorldRules instance = WorldRules.Instance;
			if (RstRandom.value <= instance.moduleOverchargeDamageChance) TakeDamage(UnityEngine.Random.Range(1, MaxHealth / 3 + 1));
			if (RstRandom.value <= instance.moduleOverchargeOverloadChance) TryCauseOverload(UnityEngine.Random.Range(1f, 60f));
			if (RstRandom.value <= instance.moduleOverchargeFireChance) if (Ship != null && Ship.Fire != null) Ship.Fire.SetFireAt(base.transform.position, 1.1f, 0.4f);
			overchargeTimer.Restart(overchargeSeconds);
			if (type == Type.Engine) if (Ship != null) UnityEngine.Object.Instantiate(VisualSettings.Instance.shipDodgeEffectPrefabRef.Prefab, Ship.transform);
			return true;
		}
		public bool IsOperatableNow {
		/// Damaged Module Still is Operable
			get {
				if (!FFU_BE_Defs.DamagedButWorking(this) || IsPacked) return false;
				return CurrentLocalOpsCount < operatorSpots.Length;
			}
		}
		public bool RequestsPower {
		/// Damaged Module Consumes Power
			get {
				if (HasFullHealth)
					return turnedOn && !IsPacked && EnoughOps && EnoughResources && Ship != null;
				else if (FFU_BE_Defs.DamagedButWorking(this))
					return turnedOn && !IsPacked && EnoughOps && EnoughResources && Ship != null;
				return false;
			}
		}
		public bool IsWorking {
		/// Damaged Module Continues to Work
			get {
				if (HasFullHealth)
					return !IsPacked && IsPowered && !IsOverloaded && !IsJammed && EnoughOps && EnoughResources;
				else if (FFU_BE_Defs.DamagedButWorking(this))
					return !IsPacked && IsPowered && !IsOverloaded && !IsJammed && EnoughOps && EnoughResources;
				return false;
			}
		}
		public bool IsRemotelyOperated {
		/// Damaged Module is Remotely Operated
			get {
				if (HasFullHealth)
					return turnedOn && !IsPacked && (operatorSpots.Length != 0 || type == Type.Weapon_Nuke) && CurrentLocalOpsWithSkillCount <= 0 && RemoteBridge != null;
				else if (FFU_BE_Defs.DamagedButWorking(this))
					return turnedOn && !IsPacked && (operatorSpots.Length != 0 || type == Type.Weapon_Nuke) && CurrentLocalOpsWithSkillCount <= 0 && RemoteBridge != null;
				return false;
			}
		}
		public bool IsAutoOperated {
		/// Nukes Operated Remotely via Bridge
			get {
				return turnedOn && !IsPacked && operatorSpots.Length == 0 && type != Type.Weapon_Nuke;
			}
		}
		public bool EnoughOps {
		/// Nukes Operated Remotely via Bridge
			get {
				if (operatorSpots.Length != 0) return CurrentOpsWithSkillCount > 0;
				return type != Type.Weapon_Nuke || (type == Type.Weapon_Nuke && RemoteBridge != null);
			}
		}
		public bool TurnedOnAndIsWorking {
		/// Nukes Operated Remotely via Bridge
			get {
				if (turnedOn) {
					if (type == Type.Weapon_Nuke) return RemoteBridge != null;
					return IsWorking;
				}
				return false;
			}
		}
		public bool IsPowered {
		/// Nukes Operated Remotely via Bridge
			get {
				if (powerConsumed > 0) return isPowered;
				if (type == Type.Weapon_Nuke) return RemoteBridge != null;
				return true;
			}
			set {
				isPowered = value;
			}
		}
		public int ShipEvasionPercentBonus {
		/// Reduced Evasion Bonuses from Damaged Modules
			get {
				if (type == Type.Bridge) {
					if (!TurnedOnAndIsWorking) return 0;
					if (HasFullHealth) return shipEvasionPercentAdd + WorldRules.Instance.bridgeSkillEffects.EffectiveSkillBonusPercent(this);
					else return Mathf.CeilToInt((shipEvasionPercentAdd + WorldRules.Instance.bridgeSkillEffects.EffectiveSkillBonusPercent(this)) * FFU_BE_Defs.GetHealthPercent(this));
				}
				if (type == Type.Engine) {
					if (!TurnedOnAndIsWorking) return 0;
					if (HasFullHealth) return shipEvasionPercentAdd + (IsOvercharged ? Engine.overchargeEvasionAdd : 0);
					else return Mathf.CeilToInt((shipEvasionPercentAdd + (IsOvercharged ? Engine.overchargeEvasionAdd : 0)) * FFU_BE_Defs.GetHealthPercent(this));
				}
				if (shipEvasionPercentAdd == 0 || !TurnedOnAndIsWorking) return 0;
				if (HasFullHealth) return shipEvasionPercentAdd;
				else return Mathf.CeilToInt(shipEvasionPercentAdd * FFU_BE_Defs.GetHealthPercent(this));
			}
		}
		[MonoModReplace] public bool CanOperate(Crewmember crew, bool now) {
		/// Crew Can Operate Damaged Module
			if (now) {
				if (!EnoughResources || IsPacked || IsOverloaded || IsJammed || CurrentLocalOpsCount >= operatorSpots.Length) return false;
				if (!FFU_BE_Defs.DamagedButWorking(this)) return false;
				if (crew.IsDead) return false;
			}
			if (type == Type.Medbay || type == Type.Dronebay) {
				if (Medbay.CanAccept(crew.type)) {
					if (now) return !crew.HasFullHealth;
					return true;
				}
				return false;
			}
			if (type == Type.Cryosleep) return CryosleepModule.CanAccept(crew.type);
			return crew.HasSkill(GetRequiredCrewSkillType());
		}
		[MonoModReplace] private bool GetSelectedPlayerCrewThatCanOperateThis(List<Crewmember> outList) {
		/// Crew Can Operate THIS Damaged Module
			outList?.Clear();
			if (!FFU_BE_Defs.DamagedButWorking(this)) return false;
			if ((HoverPanel.ChosenCrewCommand == Crewmember.Command.None && Ownership.GetOwner() == Ownership.Owner.Me) || HoverPanel.ChosenCrewCommand == Crewmember.Command.Operate) {
				foreach (GameObject item in SelectionManager.Selection) {
					Crewmember crewmember = (item != null && item.CompareTag("Crewmember")) ? item.GetComponent<Crewmember>() : null;
					if (crewmember != null && crewmember.Ownership.GetOwner() == Ownership.Owner.Me && crewmember.CanAcceptCommand(Crewmember.Command.Operate, base.gameObject)) {
						if (outList == null) return true;
						outList.Add(crewmember);
					}
				}
			}
			if (outList != null) return outList.Count > 0;
			return false;
		}
		[MonoModReplace] private void Update() {
		/// Trigger Module Changes from Damage + Malfunction Chance
			UpdateRegistrationWithParent<Ship, ShipModule>(ref cachedShip);
			UpdateRegistrationWithParent<Ship, IRepairable>(ref cachedShip2);
			if (IsUnpacking) {
				float speedMultiplier = PerFrameCache.IsGoodSituation ? WorldRules.Instance.moduleUnpackAndCraftTimeDividerIfGood : 1f;
				if (unpackTimer.Update(speedMultiplier)) {
					Unpack();
					IsUnpacking = false;
				}
			}
			if (OverchargePossible) {
				if (IsOvercharged) {
					if (!TurnedOnAndIsWorking) {
						overchargeTimer.value = 0f;
						overchargeCooldownTimer.Restart(WorldRules.Instance.moduleOverchargeCooldownSeconds);
					}
					if (overchargeTimer.Update(1f)) overchargeCooldownTimer.Restart(WorldRules.Instance.moduleOverchargeCooldownSeconds);
				} else overchargeCooldownTimer.Update(1f);
			}
			if (!overloadTimer.ReachedZero && overloadTimer.Update(PerFrameCache.IsGoodSituation ? 10f : 1f)) EndOverload();
			if (IsPacked && IsOverloaded) EndOverload();
			if (!RstTime.IsPaused && Effects.jammedPrefabRef.Prefab != null) {
				bool isJammed = IsJammed;
				if (isJammed && isJammedInstance == null) isJammedInstance = UnityEngine.Object.Instantiate(Effects.jammedPrefabRef.Prefab, base.transform.position, base.transform.rotation, base.transform.parent);
				else if (!isJammed && isJammedInstance != null) UnityEngine.Object.Destroy(isJammedInstance);
			}
			SelfCombustible selfCombustible = SelfCombustible;
			if (selfCombustible != null) {
				bool isWorking = IsWorking;
				if (selfCombustible.enabled != isWorking) selfCombustible.enabled = isWorking;
			}
			if (!HasFullHealth && Time.deltaTime < 0.2f && FFU_BE_Defs.CanMalfunction(this) && TurnedOnAndIsWorking && FFU_BE_Defs.DamagedButWorking(this)) {
				float fireChance = FFU_BE_Defs.GetHealthEffect(this, 0.01f * FFU_BE_Defs.moduleFireStartChance);
				if (Ship != null && Ship.Fire != null && RstRandom.value < fireChance * Time.deltaTime) {
					Ship.Fire.SetFireAt(base.transform.position, 1.1f, 0.7f);
					StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, $"{DisplayNameLocalized} {Core.TT("malfunctioned and started fire")}");
				}
			}
			if (IsDead && type != Type.Weapon_Nuke) {
				GameObject gameObject = PrefabPool.TakeRandomPrefab<GameObject>(this.Effects.explosionPoolRef.Prefab);
				if (gameObject != null) Explosion.InstantiateExplosion(gameObject, base.transform, base.transform.parent);
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, (Ownership.GetOwner() == Ownership.Owner.Enemy) ? 
					string.Format(MonoBehaviourExtended.TT("Enemy module {0} destroyed"), DisplayNameLocalized) : 
					string.Format(MonoBehaviourExtended.TT("{0} destroyed"), DisplayNameLocalized));
				UnityEngine.Object.Destroy(base.gameObject);
			}
			Animator animator = Animator;
			if (animator != null) animator.SetBool("operational", (type != Type.Warp) ? 
				(TurnedOnAndIsWorking && (!OpAnimNeedsWeaponShootingSync || !Weapon.inShootSequence || !Weapon.shotMade)) : 
				(FFU_BE_Defs.DamagedButWorking(this) && EnoughOps && EnoughResources && !IsPacked));
			UpdateAppearance();
			OutlineHoverAndSelect outlineHoverAndSelect = OutlineHoverAndSelect;
			if (outlineHoverAndSelect != null && outlineHoverAndSelect.outlineDrawer != null) {
				bool flag = !PopupControls.PowerManagementMode;
				if (outlineHoverAndSelect.outlineDrawer.gameObject.activeSelf != flag) {
					outlineHoverAndSelect.outlineDrawer.gameObject.SetActive(flag);
				}
			}
		}
		public string GetStatusStringLocalized() {
		/// Updated Status Text for Damaged Module
			StringBuilder stringBuilder = RstShared.StringBuilder2;
			if (!(Ship == null)) {
				if (IsOverloaded) stringBuilder.AppendFormat(MonoBehaviourExtended.TT("Overloaded for {0:0.0} seconds"), overloadTimer.value);
				else if (IsJammed) stringBuilder.Append(MonoBehaviourExtended.TT("Jammed by enemy ship"));
				else if (IsPacked) {
					if (IsUnpacking) stringBuilder.AppendFormat(MonoBehaviourExtended.TT("Installed in {0:0.0} seconds"), unpackTimer.value);
					else stringBuilder.Append(MonoBehaviourExtended.TT("In storage"));
				} else if (!HasFullHealth) {
					float repairTime = CalculateRepairTime();
					if (repairTime >= 9999f) {
						float healthPercent = FFU_BE_Defs.GetHealthPercent(this);
						if (healthPercent >= FFU_BE_Defs.moduleDamageThreshold) {
							stringBuilder.Append("<color=red>").AppendFormat(MonoBehaviourExtended.TT("{0:0.0}% Damaged"), (1f - healthPercent) * 100f).Append("</color>");
							if (type == Type.Weapon) stringBuilder.Append("\n").Append("<color=red>").Append($"{FFU_BE_Defs.GetHealthEffect(this, 0.5f) * 100f:0.###}% Misfire Chance").Append("</color>");
							if (FFU_BE_Defs.CanMalfunction(this)) stringBuilder.Append("\n").Append("<color=red>").Append($"{FFU_BE_Defs.GetHealthEffect(this, 0.01f) * 100f:0.###}% Malfunction Chance").Append("</color>");
						} else stringBuilder.Append("<color=red>").Append(MonoBehaviourExtended.TT("Broken")).Append("</color>");
					} else stringBuilder.Append("<color=red>").AppendFormat(MonoBehaviourExtended.TT("Repaired in {0:0.0} seconds"), repairTime).Append("</color>");
				} else if (!turnedOn) {
					stringBuilder.Append("<color=yellow>").Append(MonoBehaviourExtended.TT("Turned off")).Append("</color>");
					if (type == Type.MaterialsConverter) {
						stringBuilder.Append("\n");
						MaterialsConverterModule mattConv = MaterialsConverter;
						float convEff = mattConv.currentWarmpUpPoints / mattConv.maxWarmUpPoints * 100f;
						if (!HasFullHealth) convEff *= FFU_BE_Defs.GetHealthPercent(this);
						float baseEff = HasFullHealth ? mattConv.baseEfficiency * 100f : mattConv.baseEfficiency * 100f * FFU_BE_Defs.GetHealthPercent(this);
						stringBuilder.Append("<color=yellow>").Append(MonoBehaviourExtended.TT($"Converter Efficiency: {baseEff:0.0}% ({convEff:0.0}%)")).Append("</color>");
					}
				} else if (EnoughResources && EnoughPower && EnoughOps) {
					float timerVal = Timer?.value ?? 0f;
					float skillMult = SkillEffects.Get(GetRequiredCrewSkillType())?.EffectiveSkillMultiplier(this, true) ?? 1f;
					if (type == Type.Weapon && Weapon.reloadIntervalTakesNoBonuses) skillMult = 1f;
					float finalVal = timerVal * skillMult;
					switch (type) {
						case Type.ShieldGen: {
							Shield shipShield = ShieldGen.ShipShield;
							if (shipShield.ShieldPoints > 0 && shipShield.ShieldPoints >= shipShield.MaxShieldPoints) stringBuilder.Append("<color=lime>").Append(MonoBehaviourExtended.TT("Shield fully charged")).Append("</color>");
							else if (shipShield.HasGenerators(true)) stringBuilder.Append("<color=yellow>").AppendFormat(MonoBehaviourExtended.TT("New shield point in {0:0.0} seconds"), finalVal).Append("</color>");
							else stringBuilder.Append("<color=red>").Append(MonoBehaviourExtended.TT("Shield not functioning")).Append("</color>");
							break;
						}
						case Type.MaterialsConverter: {
							MaterialsConverterModule mattConv = MaterialsConverter;
							float convEff = mattConv.currentWarmpUpPoints / mattConv.maxWarmUpPoints * 100f;
							if (!HasFullHealth) convEff *= FFU_BE_Defs.GetHealthPercent(this);
							if (convEff < 90) stringBuilder.Append("<color=yellow>").AppendFormat(MonoBehaviourExtended.TT("Converter Efficiency: {0:0.0}%"), convEff).Append("</color>");
							else stringBuilder.Append("<color=lime>").AppendFormat(MonoBehaviourExtended.TT("Converter Efficiency: {0:0.0}%"), convEff).Append("</color>");
							break;
						}
						default:
						if (timerVal > 0f) stringBuilder.Append("<color=yellow>").AppendFormat(MonoBehaviourExtended.TT("Ready in {0:0.0} seconds"), finalVal).Append("</color>");
						else stringBuilder.Append("<color=lime>").Append(MonoBehaviourExtended.TT("Ready/operational")).Append("</color>");
						break;
						case Type.Decoy:
						break;
					}
				} else {
					stringBuilder.Append("<color=red>").Append(MonoBehaviourExtended.TT("Lacks")).Append(": ");
					if (!EnoughOps) stringBuilder.Append((type == Type.Medbay || type == Type.Dronebay) ? MonoBehaviourExtended.TT("patients") : MonoBehaviourExtended.TT("crew")).Append(' ');
					if (!EnoughResources) stringBuilder.Append(MonoBehaviourExtended.TT("resources")).Append(' ');
					if (!EnoughPower) stringBuilder.Append(MonoBehaviourExtended.TT("power"));
					stringBuilder.Append("</color>");
				}
			}
			return stringBuilder.ToString();
		}
	}
	public class patch_WeaponModule : WeaponModule {
		[MonoModIgnore] private Ship ParentShip;
		[MonoModIgnore] private float shotTimer;
		[MonoModIgnore] private int shotsToMake;
		[MonoModIgnore] private float preshootTimer;
		[MonoModIgnore] private float toTargetAngleOffset;
		[MonoModIgnore] public bool shotMade { get; private set; }
		[MonoModIgnore] public bool HasTarget { get; private set; }
		[MonoModIgnore] private bool DoLoadAndAim() { return false; }
		[MonoModIgnore] public bool inShootSequence { get; private set; }
		[MonoModIgnore] private int BarrelTipCount => Mathf.Max(barrelTips.Length, 1);
		[MonoModIgnore] public float SecondsSinceLastTargetSwitch { get; private set; }
		[MonoModIgnore] public Vector2 TargetPos { get { return TrackedTargetGo.transform.position; } private set { } }
		[MonoModIgnore] private ShootAtDamageDealer CreateDamageDealer(int barrelTipIndex, bool isFirstInVolley) { return null; }
		private bool hasDetonated = false;
		[MonoModReplace] public float CalculateAimAngle(Vector2 targetPos) {
		/// Min Aim Angle based on Weapon Type
			if (accuracy == 0) return 0f;
			float num = 1f;
			Collider2D[] colliders = RstShared.Colliders16;
			int num2 = Physics2D.OverlapPointNonAlloc(targetPos, colliders, RstMask.Ship | RstMask.Module);
			for (int i = 0; i < num2; i++) {
				if (!(colliders[i] != null)) continue;
				IHasEvasion hasEvasion = colliders[i].GetComponent(typeof(IHasEvasion)) as IHasEvasion;
				if (hasEvasion as UnityEngine.Object != null) {
					float num3 = 1f - 0.01f * hasEvasion.GetEvasion(null);
					if (num3 < num) num = num3;
				}
			}
			Ship ship = Module.Ship;
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			float shipAccuracyBonus = Mathf.Max(((ship != null) ? (1f + ship.GetAccuracy(null) * 0.01f) : 1f) * num, 0);
			if (Module.type == ShipModule.Type.Weapon_Nuke) return 0f;
			else if (Module.displayName.ToLower().Contains("rail")) return Mathf.Clamp(gunnerySkillEffects.EffectiveAngle(this) * (1f / shipAccuracyBonus), 1f, 30f);
			else return Mathf.Clamp(gunnerySkillEffects.EffectiveAngle(this) * (1f / shipAccuracyBonus), 4f, 90f);
		}
		[MonoModReplace] public bool ShootAt() {
		/// Use All Weapon Barrels Consequently
			Ship cachedComponentInParent = GetCachedComponentInParent<Ship>();
			PlayerData useSurplusFrom = PlayerDatas.Get(cachedComponentInParent.Ownership.GetOwner());
			if (!resourcesPerShot.ConsumeFrom(cachedComponentInParent, 1f, MonoBehaviourExtended.tt("weapon"), useSurplusFrom)) return false;
			if (shotInterval > 0f) {
				shotsToMake = magazineSize;
				shotTimer = 0f;
			} else for (int i = 0; i < magazineSize; i++) CreateDamageDealer(i % BarrelTipCount, i == 0);
			if (Module.type == ShipModule.Type.Weapon_Nuke) UnityEngine.Object.Destroy(base.gameObject);
			return true;
		}
		[MonoModReplace] private void Update() {
		/// Use All Weapon Barrels Consequently, Damaged Reload Speed & Damaged Nuke Detonation
			if (Module.IsDead && Module.type == ShipModule.Type.Weapon_Nuke && !hasDetonated) {
				HasTarget = false;
				TargetPos = gameObject.transform.position;
				TrackedTargetGo = gameObject;
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, (Module.Ownership.GetOwner() == Ownership.Owner.Enemy) ?
					string.Format(MonoBehaviourExtended.TT("Enemy {0} detonated from damage!"), Module.DisplayNameLocalized) :
					string.Format(MonoBehaviourExtended.TT("Our {0} detonated from damage!"), Module.DisplayNameLocalized));
				hasDetonated = true;
				ShootAt();
			}
			if (shotsToMake > 0) {
				if (shotTimer <= 0f) {
					int barrelTipIndex = (magazineSize - shotsToMake) % BarrelTipCount;
					CreateDamageDealer(barrelTipIndex, shotsToMake == magazineSize);
					shotTimer = shotInterval;
					shotsToMake--;
					if (shotsToMake <= 0) toTargetAngleOffset = 0f;
				}
				shotTimer -= Time.deltaTime;
			}
			if (!tracksTarget && HasTarget && Physics2D.OverlapPointNonAlloc(TargetPos, RstShared.Colliders1, ShootAtDamageDealer.HitLayerMask) <= 0) UnsetTarget();
			ShipModule module = Module;
			if (module.autoOn && !HasTarget) {
				Ship parentShip = ParentShip;
				if (parentShip != null) {
					GameObject gameObject = ChooseTarget(parentShip, ShipModule.Type.Weapon, false, true);
					if (gameObject != null) SetTarget(gameObject.transform.position, gameObject);
				}
			}
			if (!module.TurnedOnAndIsWorking) reloadTimer.Restart(reloadInterval);
			else if (!inShootSequence) {
				if (module.HasFullHealth) reloadTimer.Update(reloadIntervalTakesNoBonuses ? 1f : 1f / WorldRules.Instance.gunnerySkillEffects.EffectiveSkillMultiplier(module, true));
				else reloadTimer.Update(reloadIntervalTakesNoBonuses ? FFU_BE_Defs.GetHealthPercent(module) : 1f / WorldRules.Instance.gunnerySkillEffects.EffectiveSkillMultiplier(module, true) * FFU_BE_Defs.GetHealthPercent(module));
			}
			AudioSource audioSource = module.AudioSource;
			if (!inShootSequence) {
				if (DoLoadAndAim()) {
					inShootSequence = true;
					shotMade = false;
					preshootTimer = 0f;
					reloadTimer.Restart(reloadInterval);
					module.Animator?.SetTrigger("shoot");
					if (preShootAudio != null) audioSource?.PlayOneShot(preShootAudio);
				}
			} else if (module.TurnedOnAndIsWorking) {
				if (!shotMade) {
					if (preshootTimer >= preShootDelay || (preShootAudio != null && audioSource != null && !audioSource.isPlaying)) {
						ShootAt();
						shotMade = true;
					}
					preshootTimer += Time.deltaTime;
				} else if (!ShotInProgress) {
					inShootSequence = false;
					shotMade = false;
					if (shotInterval <= 0) toTargetAngleOffset = 0f;
				}
			} else {
				inShootSequence = false;
				shotMade = false;
			}
			SecondsSinceLastTargetSwitch += Time.deltaTime;
		}
	}
	public class patch_PointDefenceModule : PointDefenceModule {
		[MonoModIgnore] private void TrackTarget(IPointDefTarget dd) { }
		[MonoModIgnore] private bool ShootAt(IPointDefTarget targetDd, bool needAndTakeResources) { return false; }
		[MonoModIgnore] private static IPointDefTarget GetHighestPriorityTarget(Vector2 fromPos, float radius, Ownership.Owner ddOwner) { return null; }
		[MonoModReplace] private void Update() {
		/// Reduce Reload Speed for Damaged Point Defense
			ShipModule module = Module;
			if (!RstTime.IsPaused && module.IsWorking) {
				IPointDefTarget target = GetTarget();
				TrackTarget(target);
				float speedMultiplier;
				if (Module.HasFullHealth) speedMultiplier = module.TurnedOnAndIsWorking ? (1f / WorldRules.Instance.gunnerySkillEffects.EffectiveSkillMultiplier(module, true)) : 1f;
				else speedMultiplier = module.TurnedOnAndIsWorking ? 1f / WorldRules.Instance.gunnerySkillEffects.EffectiveSkillMultiplier(module, true) * FFU_BE_Defs.GetHealthPercent(Module) : FFU_BE_Defs.GetHealthPercent(Module);
				if (reloadTimer.Update(speedMultiplier) && target as UnityEngine.Object != null && ShootAt(target, true)) {
					reloadTimer.Restart(reloadInterval);
				}
			}
		}
		[MonoModReplace] private IPointDefTarget GetTarget() {
		/// Reduce Cover Radius for Damaged Point Defense
			Vector2 vector = base.transform.position;
			float effectiveCoverRadius;
			if (Module.HasFullHealth) effectiveCoverRadius = EffectiveCoverRadius;
			else effectiveCoverRadius = EffectiveCoverRadius * FFU_BE_Defs.GetHealthPercent(Module);
			IPointDefTarget pointDefTarget = PriorityTarget;
			IPointDefTarget pointDefTarget2 = null;
			if (pointDefTarget as UnityEngine.Object != null && Vector2.Distance(vector, pointDefTarget.transform.position) <= effectiveCoverRadius && pointDefTarget.PointDefCanSeeThis) {
				pointDefTarget2 = pointDefTarget;
			}
			if (pointDefTarget2 == null) {
				Ownership.Owner opposite = Ownership.GetOpposite(Module.Ownership.GetOwner());
				pointDefTarget2 = GetHighestPriorityTarget(vector, effectiveCoverRadius, opposite);
			}
			return pointDefTarget2;
		}
	}
	public class patch_ReactorModule : ReactorModule {
		public int PowerCapacity {
		/// Damage Affects Reactor Output
			get {
				ShipModule module = Module;
				if (module != null && !module.HasFullHealth) return Mathf.CeilToInt((powerCapacity + ((module != null && module.IsOvercharged) ? overchargePowerCapacityAdd : 0)) * FFU_BE_Defs.GetHealthPercent(module));
				else return powerCapacity + ((module != null && module.IsOvercharged) ? overchargePowerCapacityAdd : 0);
			}
		}
	}
	public class patch_ShieldModule : ShieldModule {
		[MonoModReplace] private void Update() {
		/// Decrease Shield Regen Speed from Damage
			if (reloadInterval <= 0f) return;
			Shield shipShield = ShipShield;
			if (!(shipShield == null)) {
				ShipModule module = Module;
				if (module.TurnedOnAndIsWorking && shipShield.ShieldPoints < shipShield.MaxShieldPoints) {
					ShieldSkillEffects shieldSkillEffects = WorldRules.Instance.shieldSkillEffects;
					float shieldReload = 1f / shieldSkillEffects.EffectiveSkillMultiplier(module, true);
					if (module.HasFullHealth) reloadTimer.Update(shieldReload * (PerFrameCache.IsGoodSituation ? shieldSkillEffects.accelTimeReloadSpeedup : 1f));
					else reloadTimer.Update(shieldReload * (PerFrameCache.IsGoodSituation ? shieldSkillEffects.accelTimeReloadSpeedup : 1f) * FFU_BE_Defs.GetHealthPercent(module));
				} else {
					reloadTimer.Restart(reloadInterval);
				}
				if (reloadTimer.ReachedZero) {
					shipShield.ShieldPoints = Mathf.Min(shipShield.ShieldPoints + 1, shipShield.MaxShieldPoints);
					reloadTimer.Restart(reloadInterval);
				}
			}
		}
	}
	public class patch_CryosleepModule : CryosleepModule {
		[MonoModIgnore] private float nextHealDist;
		[MonoModIgnore] private float healDist;
		[MonoModIgnore] private float nextDreamDist;
		[MonoModIgnore] private float dreamDist;
		[MonoModIgnore] private void HealOneCrewHp() { }
		public void AddDistanceTravelled(float delta) {
		/// Cryosleep Effects Trigger from Damage
			bool fullHealth = Module.HasFullHealth;
			float healthPercent = FFU_BE_Defs.GetHealthPercent(Module);
			if (healOneCrewHp) {
				if (healDist == 0f && nextHealDist == 0f) {
					if (fullHealth) nextHealDist = healOneCrewHpDistance.GetRandomFloat();
					else nextHealDist = healOneCrewHpDistance.GetRandomFloat() / healthPercent;
				}
				if (healDist >= nextHealDist) {
					HealOneCrewHp();
					healDist -= nextHealDist;
					if (fullHealth) nextHealDist = healOneCrewHpDistance.GetRandomFloat();
					else nextHealDist = healOneCrewHpDistance.GetRandomFloat() / healthPercent;
				}
				healDist += delta * Module.CurrentLocalOpsCount;
			}
			if (genDreamCredits) {
				if (dreamDist == 0f && nextDreamDist == 0f) {
					if (fullHealth) nextDreamDist = genDreamCreditsDistance.GetRandomFloat();
					else nextDreamDist = genDreamCreditsDistance.GetRandomFloat() / healthPercent;
				}
				if (dreamDist >= nextDreamDist) {
					GenDreamCredits();
					dreamDist -= nextDreamDist;
					if (fullHealth) nextDreamDist = genDreamCreditsDistance.GetRandomFloat();
					else nextDreamDist = genDreamCreditsDistance.GetRandomFloat() / healthPercent;
				}
				dreamDist += delta * Module.CurrentLocalOpsCount;
			}
		}
		[MonoModReplace] private void GenDreamCredits() {
			ShipModule module = Module;
			List<Crewmember> list = new List<Crewmember>();
			CrewAssignmentSpot[] operatorSpots = module.operatorSpots;
			foreach (CrewAssignmentSpot crewAssignmentSpot in operatorSpots) if (crewAssignmentSpot.assignedCrewmember != null) list.Add(crewAssignmentSpot.assignedCrewmember);
			Crewmember crewmember = list.RandomElement();
			if (crewmember != null) {
				PlayerData playerData = PlayerDatas.Get(module.Ownership.GetOwner());
				if (playerData != null) {
					int randomInt = Mathf.RoundToInt(Module.HasFullHealth ? creditsPerDream.GetRandomInt() : creditsPerDream.GetRandomInt() * FFU_BE_Defs.GetHealthPercent(Module));
					if (randomInt <= 0) return;
					playerData.Credits += randomInt;
					StarmapLogPanelUI.Open();
					StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Good, string.Format(MonoBehaviourExtended.TT("{0} generated {1} while dreaming in {2}"), crewmember.displayName, MonoBehaviourExtended.TT(randomInt, "credit|credits"), Module.DisplayNameLocalized));
				}
			}
		}
	}
	public class patch_CrewIsInCryosleep : CrewIsInCryosleep {
		[MonoModIgnore] private Crewmember lastAssignedCrewmember;
		[MonoModIgnore] private ShipModule Module => GetCachedComponentInParent<ShipModule>(true);
		[MonoModIgnore] private CrewAssignmentSpot AssignemntSpot => GetCachedComponent<CrewAssignmentSpot>(true);
		[MonoModReplace] private void UpdateData() {
		/// Crew in Cryosleep in Damaged Cryobay Modules.
			Crewmember crewmember = null;
			if (AssignemntSpot.assignedCrewmember != null) {
				ShipModule module = Module;
				if (module != null && (module.HasFullHealth || FFU_BE_Defs.DamagedButWorking(module)) && module.IsPowered) crewmember = AssignemntSpot.assignedCrewmember;
			}
			if (lastAssignedCrewmember != crewmember) {
				if (lastAssignedCrewmember != null) lastAssignedCrewmember.StartWakingUp();
				if (crewmember != null) crewmember.Sleep();
				lastAssignedCrewmember = crewmember;
			}
		}
	}
	public class patch_CrewIsHealed : CrewIsHealed {
		[MonoModIgnore] private float timer;
		[MonoModIgnore] private ShipModule Module => GetCachedComponentInParent<ShipModule>(true);
		[MonoModIgnore] private CrewAssignmentSpot AssignmentSpot => GetCachedComponent<CrewAssignmentSpot>(true);
		[MonoModReplace] private void UpdateData() {
		/// Health Bay Healing Speed from Damage
			if (AssignmentSpot.assignedCrewmember == null) return;
			ShipModule module = Module;
			if (!(module != null) || !module.HasFullHealth || !module.IsPowered || 1 == 0) return;
			Crewmember assignedCrewmember = AssignmentSpot.assignedCrewmember;
			MedbayModule medbay = module.Medbay;
			float healthPercent = Mathf.Pow(FFU_BE_Defs.GetHealthPercent(module), 2);
			if (timer >= (medbay.secondsPerHp / healthPercent)) {
				bool flag = !assignedCrewmember.HasFullHealth;
				if (flag && !EnoughResources) flag = false;
				if (flag) {
					assignedCrewmember.Heal(1);
					PlayerData playerData = PlayerDatas.Get(module.Ownership.GetOwner());
					if (playerData != null) medbay.resourcesPerHp.ConsumeFrom(playerData, 1f, reasonToDisplay);
					timer = 0f;
				}
			}
			float num = PerFrameCache.IsGoodSituation ? WorldRules.Instance.medbayHealSpeedMultiplierIfGood : 1f;
			timer += num * Time.deltaTime;
		}
	}
	public class patch_GunnerySkillEffects : GunnerySkillEffects {
		[MonoModReplace] public int EffectiveAccuracy(WeaponModule wm) {
		/// Damage Based Module Accuracy Reductions
			if (wm.Module.HasFullHealth) return Mathf.CeilToInt(EffectiveSkillPoints(wm.Module) * skillPointAccuracyBonus) + wm.accuracy;
			else return Mathf.CeilToInt((EffectiveSkillPoints(wm.Module) * skillPointAccuracyBonus + wm.accuracy) * FFU_BE_Defs.GetHealthPercent(wm.Module));
		}
		[MonoModReplace] public float EffectiveReloadTime(WeaponModule wm) {
		/// Damage Based Module Reload Reductions
			if (wm.reloadIntervalTakesNoBonuses) {
				if (wm.Module.HasFullHealth) return wm.reloadInterval;
				else return wm.reloadInterval / FFU_BE_Defs.GetHealthPercent(wm.Module);
			}
			if (wm.Module.HasFullHealth) return wm.reloadInterval * EffectiveSkillMultiplier(wm.Module, true);
			else return wm.reloadInterval * EffectiveSkillMultiplier(wm.Module, true) / FFU_BE_Defs.GetHealthPercent(wm.Module);
		}
		[MonoModReplace] public float EffectiveCoverRadius(PointDefenceModule pd) {
		/// Damage Based Module Cover Radius Reductions
			if (pd.Module.HasFullHealth) return pd.coverRadius * EffectiveSkillMultiplier(pd.Module, false);
			else return pd.coverRadius * EffectiveSkillMultiplier(pd.Module, false) * FFU_BE_Defs.GetHealthPercent(pd.Module);
		}
	}
	public class patch_ScienceSkillEffects : ScienceSkillEffects {
		[MonoModReplace] public int EffectiveCreditsProduction(ShipModule m) {
		/// Allow Laboratory Modules to Produce All Types
			return EffectiveSkillPoints(m) * skillPointBonusProduction;
		}
	}
	public class patch_GardenSkillEffects : GardenSkillEffects {
		[MonoModReplace] public int EffectiveProduction(ShipModule m) {
		/// Allow Greenhouse Modules to Produce All Types
			return EffectiveSkillPoints(m) * skillPointBonusProduction;
		}
	}
	public class patch_PlayerData : PlayerData {
		[MonoModReplace] public int GetCurrentAsteroidDeflectionPercent(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
		/// Damaged Module Affects Asteroid Deflection
			Ship flagship = Flagship;
			if (flagship == null) return 0;
			int totalAstDefl = flagship.asteroidDeflectionPercentAdd;
			if (flagship.asteroidDeflectionPercentAdd != 0) perProviderCallback?.Invoke(flagship, flagship.asteroidDeflectionPercentAdd);
			List<ShipModule> modules = flagship.Modules;
			if (perProviderCallback != null) modules.Sort((ShipModule m) => -m.asteroidDeflectionPercentAdd);
			foreach (ShipModule item in modules) {
				if (item != null && item.asteroidDeflectionPercentAdd != 0 && item.IsWorking) {
					totalAstDefl += Mathf.CeilToInt(item.asteroidDeflectionPercentAdd * FFU_BE_Defs.GetHealthPercent(item));
					perProviderCallback?.Invoke(item, item.asteroidDeflectionPercentAdd);
				}
			}
			return totalAstDefl;
		}
		[MonoModReplace] public float GetCurrentSectorRadarRange(Action<IHasDisplayNameLocalized, float> perProviderCallback) {
		/// Damaged Module Affects Sector Radar Range
			Ship flagship = Flagship;
			if (flagship == null) return 0f;
			List<ShipModule> modules = flagship.Modules;
			if (perProviderCallback != null) modules.Sort((ShipModule m) => (m.type == ShipModule.Type.Sensor) ? (-m.Sensor.sectorRadarRange) : 0);
			float totalRadSecRng = 0f;
			foreach (ShipModule item in modules) {
				if (item != null && item.type == ShipModule.Type.Sensor && item.TurnedOnAndIsWorking) {
					float radSecRng = item.Sensor.sectorRadarRange * FFU_BE_Defs.GetHealthPercent(item);
					if (radSecRng != 0f) {
						radSecRng += flagship.sectorRadarRangeAdd;
						if (radSecRng > totalRadSecRng) totalRadSecRng = radSecRng;
						perProviderCallback?.Invoke(item, radSecRng);
					}
				}
			}
			return totalRadSecRng;
		}
		[MonoModReplace] public float GetCurrentStarmapRadarRange(Action<IHasDisplayNameLocalized, float> perProviderCallback) {
		/// Damaged Module Affects Starmap Radar Range
			Ship flagship = Flagship;
			if (flagship == null) return 0f;
			float totalRadStarRng = 0f;
			List<ShipModule> modules = flagship.Modules;
			if (perProviderCallback != null) modules.Sort((ShipModule m) => (m.type == ShipModule.Type.Sensor) ? (-(int)(m.Sensor.CurrentStarmapRadarRange * 1000f)) : 0);
			foreach (ShipModule item in modules) {
				if (item != null && item.type == ShipModule.Type.Sensor && item.TurnedOnAndIsWorking) {
					float currentStarmapRadarRange = item.Sensor.CurrentStarmapRadarRange * FFU_BE_Defs.GetHealthPercent(item);
					if (currentStarmapRadarRange != 0f) {
						currentStarmapRadarRange += flagship.starmapRadarRangeAdd;
						if (currentStarmapRadarRange > totalRadStarRng) totalRadStarRng = currentStarmapRadarRange;
						perProviderCallback?.Invoke(item, currentStarmapRadarRange);
					}
				}
			}
			Sector instance = Sector.Instance;
			PlayerFleet playerFleet = (flagship.Ownership.GetOwner() == Ownership.Owner.Me) ? PlayerFleet.Instance : null;
			if (!(instance != null) || !(playerFleet != null) || !instance.CheckIfInsideClouds(playerFleet.transform.position)) return totalRadStarRng;
			return totalRadStarRng * WorldRules.Instance.radarRangeMultiplierInCloud;
		}
		[MonoModReplace] public float GetCurrentStarmapSpeed(Action<IHasDisplayNameLocalized, float> perProviderCallback) {
		/// Damaged Module Affects Starmap Speed
			Ship flagship = Flagship;
			PlayerFleet instance = PlayerFleet.Instance;
			if (flagship == null || instance == null) return 0f;
			float totalStarSpeed = instance.Fleet.speed;
			if (totalStarSpeed != 0f) perProviderCallback?.Invoke(null, totalStarSpeed);
			List<ShipModule> modules = flagship.Modules;
			if (perProviderCallback != null) modules.Sort((ShipModule m) => -(int)(m.starmapSpeedAdd * 1000f));
			bool hasEngine = false;
			foreach (ShipModule item in modules) {
				if (item != null && item.starmapSpeedAdd != 0f && item.IsWorking) {
					if (item.type == ShipModule.Type.Engine) hasEngine = true;
					totalStarSpeed += item.starmapSpeedAdd * FFU_BE_Defs.GetHealthPercent(item);
					perProviderCallback?.Invoke(item, item.starmapSpeedAdd);
				}
			}
			if (!hasEngine) return 0f;
			return totalStarSpeed;
		}
	}
}
