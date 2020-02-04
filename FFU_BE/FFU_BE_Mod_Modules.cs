#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable CS0626
#pragma warning disable CS0649
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
		public static List<ShipModule> sortedListPacks = new List<ShipModule>();
		public static List<ShipModule> sortedListNukes = new List<ShipModule>();
		public static List<ShipModule> sortedListWeapons = new List<ShipModule>();
		public static List<ShipModule> sortedListPDs = new List<ShipModule>();
		public static List<ShipModule> sortedListBridges = new List<ShipModule>();
		public static List<ShipModule> sortedListEngines = new List<ShipModule>();
		public static List<ShipModule> sortedListWDrives = new List<ShipModule>();
		public static List<ShipModule> sortedListReactors = new List<ShipModule>();
		public static List<ShipModule> sortedListContainers = new List<ShipModule>();
		public static List<ShipModule> sortedListArmors = new List<ShipModule>();
		public static List<ShipModule> sortedListShields = new List<ShipModule>();
		public static List<ShipModule> sortedListSensors = new List<ShipModule>();
		public static List<ShipModule> sortedListDecryptors = new List<ShipModule>();
		public static List<ShipModule> sortedListCountermeasures = new List<ShipModule>();
		public static List<ShipModule> sortedListDronebays = new List<ShipModule>();
		public static List<ShipModule> sortedListMedbays = new List<ShipModule>();
		public static List<ShipModule> sortedListCryosleeps = new List<ShipModule>();
		public static List<ShipModule> sortedListLabs = new List<ShipModule>();
		public static List<ShipModule> sortedListGardens = new List<ShipModule>();
		public static List<ShipModule> sortedListMattConvs = new List<ShipModule>();
		public static List<ShipModule> sortedListDecoys = new List<ShipModule>();
		public static List<ShipModule> sortedListMisc = new List<ShipModule>();
		public static void InitShipSlotsList() {
			try {
				foreach (ModuleSlot moduleSlot in Resources.FindObjectsOfTypeAll<ModuleSlot>()) {
					if (FFU_BE_Defs.dumpObjectLists) Debug.Log(moduleSlot.name + " [" + moduleSlot.PrefabId + "] " + moduleSlot.displayName + " (H:" + moduleSlot.shipMaxHealthAdd + "/D:" + moduleSlot.deflectChance + ")");
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
					if (FFU_BE_Defs.dumpObjectLists) Debug.Log("Module, " + GetModuleTypeName(shipModule) + ": [" + shipModule.name + "] (" + shipModule.PrefabId + ") " + shipModule.displayName);
					ApplyModuleEffects(shipModule);
					ApplyModuleChanges(shipModule);
					ApplyMaxCoreHealth(shipModule);
					SortModuleByType(shipModule);
					if (FFU_BE_Defs.moduleCraftingForFree) AllowCraftForFree(shipModule);
				}
				MoveToMainList(FFU_BE_Defs.prefabModdedModulesList, true);
				UpdateModuleEffects(FFU_BE_Defs.prefabModdedModulesList);
				FFU_BE_Defs.prefabModdedModulesList.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				if (FFU_BE_Defs.allModulesCraftable) {
					foreach (ShipModule litedModule in FFU_BE_Defs.prefabModdedModulesList)
						if (FFU_BE_Defs.IsAllowedModuleToList(litedModule)) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(litedModule);
						else if (!FFU_BE_Defs.IsAllowedModuleToList(litedModule) && FFU_BE_Defs.allTypesCraftable) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(litedModule);
					ModuleSlotActionsPanel.altCraftableModulePrefabs.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				}
				if (FFU_BE_Defs.createModulesCSV) WeaponListCreateCSV(FFU_BE_Defs.prefabModdedModulesList);
				CleanMinorModuleLists();
				if (FFU_BE_Defs.showSortedList && FFU_BE_Defs.showPrefabIDs && FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name + " [" + shipModule.PrefabId + "]" + " (" + shipModule.displayName + ") {" + shipModule.description + "}");
				else if (FFU_BE_Defs.showSortedList && FFU_BE_Defs.showPrefabIDs && !FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name + " [" + shipModule.PrefabId + "]" + " (" + shipModule.displayName + ")");
				else if (FFU_BE_Defs.showSortedList && !FFU_BE_Defs.showPrefabIDs && !FFU_BE_Defs.showDescription) foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList) Debug.Log(shipModule.name);
				if (FFU_BE_Defs.dumpObjectLists) {
					foreach (ShipModule shipModule in FFU_BE_Defs.prefabModdedModulesList)
						if (shipModule.type == ShipModule.Type.Weapon_Nuke)
							if (shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab != null)
								foreach (GameObject gameObject in GameObjectPool.TakePrefabList<GameObject>(shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab))
									Debug.Log("Intruder, " + shipModule.name + " [" + shipModule.Weapon.ProjectileOrBeamPrefab.name + "]: " + gameObject.name);
				}
				originalList = null;
			} catch (Exception ex) { Debug.LogError(ex); }
		}
		public static void ApplyModuleEffects(ShipModule shipModule) {
			switch (shipModule.name.Replace("(Clone)", string.Empty)) {
				case "weapon ATK-MK1":
				case "weapon ATK-MK1 old":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Cannon projectile 1 d2");
				break;
				case "weapon Segmented cannonx2 A":
				case "weapon Segmented cannonx2 B":
				case "weapon Segmented cannonx2 C":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Cannon projectile rocketsound d2");
				break;
				case "weapon cubecannon1":
				case "weapon cubecannon1x3":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Cannon projectile2 d2");
				break;
				case "weapon gatling RatA 14,4":
				case "weapon gatling RatB 15,5":
				case "weapon gatling whiteA 13,4":
				case "weapon gatling whiteB 14,5":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Gatling projectile thin");
				break;
				case "weapon gatling ClawA 12,4":
				case "weapon gatling ClawB 14,5":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Gatling projectile medium");
				break;
				case "weapon Sniper cannon 0 DIY":
				case "weapon Sniper cannon 0":
				case "weapon Sniper cannon 2":
				case "weapon Sniper cannon 3":
				case "weapon Sniper cannon 2 insectoid":
				shipModule.Weapon.ProjectileOrBeamPrefab = FFU_BE_Defs.prefabProjectilesList.Find(prj => prj.name == "Gatling projectile thick");
				break;
				case "0 DIY PD":
				case "1 Rat PD":
				case "3 Rat PD 2":
				shipModule.PointDefence.projectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == "pointdef beam gatling single");
				break;
				case "6 Squid PD":
				case "4 Insectoid PD":
				case "5 Human PD":
				shipModule.PointDefence.projectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == "pointdef beam gatling");
				break;
				case "7 Red PD":
				case "2 Tiger PD":
				shipModule.PointDefence.projectileOrBeamPrefab = FFU_BE_Defs.prefabDefDealersList.Find(def => def.name == "pointdef beam");
				break;
				default: break;
			}
		}
		public static void UpdateModuleEffects(List<ShipModule> shipModules) {
			shipModules.Find(x => x.name.Contains("07 DIY acid nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("08c Green nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("13 nanopellet nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("08c Green nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("07 Weirdship Chem nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("08c Green nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("Tiger sharpnel nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("08c Green nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("07 DIY bionuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("07 Weirdship Minibio nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("99 maggot spawner launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool = shipModules.Find(x => x.name.Contains("07 Weirdship Minibio nuke launcher")).Weapon.ProjectileOrBeamPrefab.Effects.explosionPool;
			shipModules.Find(x => x.name.Contains("07 DIY bionuke launcher")).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab = shipModules.Find(x => x.name.Contains("99 maggot spawner launcher")).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab;
			shipModules.Find(x => x.name.Contains("07 Weirdship Minibio nuke launcher")).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab = shipModules.Find(x => x.name.Contains("99 maggot spawner launcher")).Weapon.ProjectileOrBeamPrefab.spawnIntruderPrefabRef.Prefab;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 17 broken screen gizmo, data")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 25 broken screen gizmo")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 32 broken container gizmo")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 37 ripped quarter of a dome")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 36 broken gizmo")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 34 data core grammofon")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name.Contains("artifactmodule tec 35 data core makk")).image = shipModules.Find(x => x.name.Contains("explosives pack")).image;
			shipModules.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").image = shipModules.Find(x => x.name.Contains("medical pack organics, synth")).image;
			shipModules.Find(x => x.name == "artifactmodule tec 11 biostasis").image = shipModules.Find(x => x.name.Contains("medical pack organics, synth")).image;
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
		private static void SortModuleByType(ShipModule shipModule) {
			if ((shipModule.name.Contains("decoy") || shipModule.name.Contains("Decoy")) && shipModule.type != ShipModule.Type.Weapon_Nuke) sortedListDecoys.Add(shipModule);
			else if (shipModule.name.Contains("artifact") || shipModule.name.Contains("tutorial") || shipModule.name.Contains("bossweapon")) sortedListMisc.Add(shipModule);
			else {
				switch (shipModule.type) {
					case ShipModule.Type.ResourcePack: sortedListPacks.Add(shipModule); break;
					case ShipModule.Type.Weapon_Nuke: sortedListNukes.Add(shipModule); break;
					case ShipModule.Type.Weapon: sortedListWeapons.Add(shipModule); break;
					case ShipModule.Type.PointDefence: sortedListPDs.Add(shipModule); break;
					case ShipModule.Type.Bridge: sortedListBridges.Add(shipModule); break;
					case ShipModule.Type.Engine: sortedListEngines.Add(shipModule); break;
					case ShipModule.Type.Warp: sortedListWDrives.Add(shipModule); break;
					case ShipModule.Type.Reactor: sortedListReactors.Add(shipModule); break;
					case ShipModule.Type.Container: sortedListContainers.Add(shipModule); break;
					case ShipModule.Type.Integrity: sortedListArmors.Add(shipModule); break;
					case ShipModule.Type.ShieldGen: sortedListShields.Add(shipModule); break;
					case ShipModule.Type.Sensor: sortedListSensors.Add(shipModule); break;
					case ShipModule.Type.StealthDecryptor: sortedListDecryptors.Add(shipModule); break;
					case ShipModule.Type.PassiveECM: sortedListCountermeasures.Add(shipModule); break;
					case ShipModule.Type.Dronebay: sortedListDronebays.Add(shipModule); break;
					case ShipModule.Type.Medbay: sortedListMedbays.Add(shipModule); break;
					case ShipModule.Type.Cryosleep: sortedListCryosleeps.Add(shipModule); break;
					case ShipModule.Type.ResearchLab: sortedListLabs.Add(shipModule); break;
					case ShipModule.Type.Garden: sortedListGardens.Add(shipModule); break;
					case ShipModule.Type.MaterialsConverter: sortedListMattConvs.Add(shipModule); break;
					case ShipModule.Type.Decoy: sortedListDecoys.Add(shipModule); break;
					default: sortedListMisc.Add(shipModule); break;
				}
			}
		}
		private static void SortListedModules() {
			sortedListPacks.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_ResPacks.SortModules(x.name).CompareTo(FFU_BE_Prefab_ResPacks.SortModules(y.name)));
			sortedListNukes.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Nukes.SortModules(x.name).CompareTo(FFU_BE_Prefab_Nukes.SortModules(y.name)));
			sortedListWeapons.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Weapons.SortModules(x.name).CompareTo(FFU_BE_Prefab_Weapons.SortModules(y.name)));
			sortedListPDs.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_PointDefences.SortModules(x.name).CompareTo(FFU_BE_Prefab_PointDefences.SortModules(y.name)));
			sortedListBridges.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Bridges.SortModules(x.name).CompareTo(FFU_BE_Prefab_Bridges.SortModules(y.name)));
			sortedListEngines.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Engines.SortModules(x.name).CompareTo(FFU_BE_Prefab_Engines.SortModules(y.name)));
			sortedListWDrives.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Drives.SortModules(x.name).CompareTo(FFU_BE_Prefab_Drives.SortModules(y.name)));
			sortedListReactors.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Reactors.SortModules(x.name).CompareTo(FFU_BE_Prefab_Reactors.SortModules(y.name)));
			sortedListContainers.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Storages.SortModules(x.name).CompareTo(FFU_BE_Prefab_Storages.SortModules(y.name)));
			sortedListArmors.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Armors.SortModules(x.name).CompareTo(FFU_BE_Prefab_Armors.SortModules(y.name)));
			sortedListShields.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Shields.SortModules(x.name).CompareTo(FFU_BE_Prefab_Shields.SortModules(y.name)));
			sortedListSensors.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Sensors.SortModules(x.name).CompareTo(FFU_BE_Prefab_Sensors.SortModules(y.name)));
			sortedListDecryptors.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Decryptors.SortModules(x.name).CompareTo(FFU_BE_Prefab_Decryptors.SortModules(y.name)));
			sortedListCountermeasures.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_PassiveECMs.SortModules(x.name).CompareTo(FFU_BE_Prefab_PassiveECMs.SortModules(y.name)));
			sortedListDronebays.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_HealthBays.SortModules(x.name).CompareTo(FFU_BE_Prefab_HealthBays.SortModules(y.name)));
			sortedListMedbays.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_HealthBays.SortModules(x.name).CompareTo(FFU_BE_Prefab_HealthBays.SortModules(y.name)));
			sortedListCryosleeps.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_CryoBays.SortModules(x.name).CompareTo(FFU_BE_Prefab_CryoBays.SortModules(y.name)));
			sortedListLabs.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Laboratories.SortModules(x.name).CompareTo(FFU_BE_Prefab_Laboratories.SortModules(y.name)));
			sortedListGardens.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Greenhouses.SortModules(x.name).CompareTo(FFU_BE_Prefab_Greenhouses.SortModules(y.name)));
			sortedListMattConvs.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Converters.SortModules(x.name).CompareTo(FFU_BE_Prefab_Converters.SortModules(y.name)));
			sortedListDecoys.Sort((ShipModule x, ShipModule y) => FFU_BE_Prefab_Decoys.SortModules(x.name).CompareTo(FFU_BE_Prefab_Decoys.SortModules(y.name)));
			sortedListMisc.Sort((ShipModule x, ShipModule y) => x.name.CompareTo(y.name));
		}
		private static void MoveToMainList(List<ShipModule> mainList, bool ignoreLimits) {
			if (sortedListPacks.Count > 0) foreach (ShipModule sModule in sortedListPacks) mainList.Add(sModule);
			if (sortedListNukes.Count > 0) foreach (ShipModule sModule in sortedListNukes) mainList.Add(sModule);
			if (sortedListWeapons.Count > 0) foreach (ShipModule sModule in sortedListWeapons) mainList.Add(sModule);
			if (sortedListPDs.Count > 0) foreach (ShipModule sModule in sortedListPDs) mainList.Add(sModule);
			if (sortedListBridges.Count > 0) foreach (ShipModule sModule in sortedListBridges) mainList.Add(sModule);
			if (sortedListEngines.Count > 0) foreach (ShipModule sModule in sortedListEngines) mainList.Add(sModule);
			if (sortedListWDrives.Count > 0) foreach (ShipModule sModule in sortedListWDrives) mainList.Add(sModule);
			if (sortedListReactors.Count > 0) foreach (ShipModule sModule in sortedListReactors) mainList.Add(sModule);
			if (sortedListContainers.Count > 0) foreach (ShipModule sModule in sortedListContainers) mainList.Add(sModule);
			if (sortedListArmors.Count > 0) foreach (ShipModule sModule in sortedListArmors) mainList.Add(sModule);
			if (sortedListShields.Count > 0) foreach (ShipModule sModule in sortedListShields) mainList.Add(sModule);
			if (sortedListSensors.Count > 0) foreach (ShipModule sModule in sortedListSensors) mainList.Add(sModule);
			if (sortedListDecryptors.Count > 0) foreach (ShipModule sModule in sortedListDecryptors) mainList.Add(sModule);
			if (sortedListCountermeasures.Count > 0) foreach (ShipModule sModule in sortedListCountermeasures) mainList.Add(sModule);
			if (sortedListDronebays.Count > 0) foreach (ShipModule sModule in sortedListDronebays) mainList.Add(sModule);
			if (sortedListMedbays.Count > 0) foreach (ShipModule sModule in sortedListMedbays) mainList.Add(sModule);
			if (sortedListCryosleeps.Count > 0) foreach (ShipModule sModule in sortedListCryosleeps) mainList.Add(sModule);
			if (sortedListLabs.Count > 0) foreach (ShipModule sModule in sortedListLabs) mainList.Add(sModule);
			if (sortedListGardens.Count > 0) foreach (ShipModule sModule in sortedListGardens) mainList.Add(sModule);
			if (sortedListMattConvs.Count > 0) foreach (ShipModule sModule in sortedListMattConvs) mainList.Add(sModule);
			if (sortedListDecoys.Count > 0) foreach (ShipModule sModule in sortedListDecoys) mainList.Add(sModule);
			if (ignoreLimits) if (sortedListMisc.Count > 0) foreach (ShipModule sModule in sortedListMisc) mainList.Add(sModule);
		}
		private static void CleanMinorModuleLists() {
			sortedListPacks = null;
			sortedListNukes = null;
			sortedListWeapons = null;
			sortedListPDs = null;
			sortedListBridges = null;
			sortedListEngines = null;
			sortedListWDrives = null;
			sortedListReactors = null;
			sortedListContainers = null;
			sortedListArmors = null;
			sortedListShields = null;
			sortedListSensors = null;
			sortedListDecryptors = null;
			sortedListCountermeasures = null;
			sortedListDronebays = null;
			sortedListMedbays = null;
			sortedListCryosleeps = null;
			sortedListLabs = null;
			sortedListGardens = null;
			sortedListMattConvs = null;
			sortedListDecoys = null;
			sortedListMisc = null;
		}
		public static void ApplyModuleChanges(ShipModule shipModule) {
			CraftCostFallback(shipModule);
			switch (shipModule.type) {
				case ShipModule.Type.ResourcePack: FFU_BE_Prefab_ResPacks.UpdateResourcePackModule(shipModule); break;
				case ShipModule.Type.Weapon_Nuke: FFU_BE_Prefab_Nukes.UpdateNukeModule(shipModule); break;
				case ShipModule.Type.Weapon: FFU_BE_Prefab_Weapons.UpdateWeaponModule(shipModule); break;
				case ShipModule.Type.PointDefence: FFU_BE_Prefab_PointDefences.UpdatePointDefModule(shipModule); break;
				case ShipModule.Type.Bridge: FFU_BE_Prefab_Bridges.UpdateBridgeModule(shipModule); break;
				case ShipModule.Type.Engine: FFU_BE_Prefab_Engines.UpdateEngineModule(shipModule); break;
				case ShipModule.Type.Warp: FFU_BE_Prefab_Drives.UpdateWarpDriveModule(shipModule); break;
				case ShipModule.Type.Reactor: FFU_BE_Prefab_Reactors.UpdateReactorModule(shipModule); break;
				case ShipModule.Type.Container: FFU_BE_Prefab_Storages.UpdateStorageModule(shipModule); break;
				case ShipModule.Type.Integrity: FFU_BE_Prefab_Armors.UpdateArmorModule(shipModule); break;
				case ShipModule.Type.ShieldGen: FFU_BE_Prefab_Shields.UpdateShieldModule(shipModule); break;
				case ShipModule.Type.Sensor: FFU_BE_Prefab_Sensors.UpdateSensorModule(shipModule); break;
				case ShipModule.Type.StealthDecryptor: FFU_BE_Prefab_Decryptors.UpdateDecryptorModule(shipModule); break;
				case ShipModule.Type.PassiveECM: FFU_BE_Prefab_PassiveECMs.UpdateCountermeasureModule(shipModule); break;
				case ShipModule.Type.Dronebay: FFU_BE_Prefab_HealthBays.UpdateHealthBayModule(shipModule); break;
				case ShipModule.Type.Medbay: FFU_BE_Prefab_HealthBays.UpdateHealthBayModule(shipModule); break;
				case ShipModule.Type.Cryosleep: FFU_BE_Prefab_CryoBays.UpdateCryosleepModule(shipModule); break;
				case ShipModule.Type.ResearchLab: FFU_BE_Prefab_Laboratories.UpdateLaboratoryModule(shipModule); break;
				case ShipModule.Type.Garden: FFU_BE_Prefab_Greenhouses.UpdateGreenhouseModule(shipModule); break;
				case ShipModule.Type.MaterialsConverter: FFU_BE_Prefab_Converters.UpdateConverterModule(shipModule); break;
				case ShipModule.Type.Decoy: FFU_BE_Prefab_Decoys.UpdateDecoyModule(shipModule); break;
				default: FFU_BE_Prefab_Miscellaneous.UpdateMsicModule(shipModule); break;
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
			if (shipModule.type != ShipModule.Type.Integrity && !shipModule.name.Contains("bossweapon") && !shipModule.name.Contains("artifactmodule")) shipModule.maxHealthAdd = 0;
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
						shipModulesListFile.Write((shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? String.Format("{0:0.###}", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius) : "") + ",");
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
		private extern void orig_Unpack();
		[MonoModIgnore] private int maxHealth;
		[MonoModIgnore] private Ship cachedShip;
		[MonoModIgnore] private Ship cachedShip2;
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
		//Tactical Unpack Times
		[MonoModReplace] public void StartUnpacking(bool useCraftTime) {
			UnpackShared();
			UnpackTime = useCraftTime ? FFU_BE_Defs.shipModuleCraftTime : FFU_BE_Defs.shipModuleUnpackTime;
			if (UnpackTime == 0f) { Unpack(); return; }
			IsUnpacking = true;
			unpackTimer.Restart(UnpackTime);
		}
		//Update Module Parameters Assigned to Store
		public void BuyableAssignToStore(Shop shop) {
			Ownership.SetOwner(Ownership.Owner.None);
			float healthPercent = FFU_BE_Mod_Modules.GetRelativeHealth(this);
			FFU_BE_Mod_Technology.ApplySectorModuleTier(this);
			FFU_BE_Mod_Modules.ApplyRelativeNewHealth(this, healthPercent);
			if (Sector.Instance != null) if (FFU_BE_Defs.ModuleAvailableSector(this) > Sector.Instance.number) costCreditsInShop *= FFU_BE_Defs.blackMarketMult;
			base.transform.SetParent(shop.buyableModulesContainer.transform);
			Pack();
			base.transform.position = new Vector3(10000f, 0f, 0f);
		}
		//Recalculate Ship's Signature on Module Unpack
		private void Unpack() {
			orig_Unpack();
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Do Permanent Damage to Module on Higher Difficulties
		public void TakeDamage(ShootAtDamageDealer.Damage dd, Vector2 hitPos) {
			if (type == Type.Storage) return;
			TakeDamage(dd.moduleDmg);
			if (dd.moduleOverloadSeconds > 0) TryCauseOverload(dd.moduleOverloadSeconds);
			if (dd.moduleDmg > 0 && Health > 0 && WorldRules.Impermanent.playerModulesTakeMaxHpDamage && Ownership.GetOwner() == Ownership.Owner.Me && RstRandom.value < (FFU_BE_Defs.permanentModuleDamageChance * FFU_BE_Defs.GetDifficultyModifier())) {
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
		//Multiple Features Implementations on Scrap Module
		[MonoModReplace] public void Scrap(PlayerData resourcesGoTo, bool addLogLine) {
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
			if (!IsPacked) FFU_BE_Defs.RecalculateEnergyEmission();
			if (FFU_BE_Defs.IsAllowedModuleCategory(this) && !FFU_BE_Defs.discoveredModuleIDs.Contains(PrefabId) && !FFU_BE_Defs.unresearchedModuleIDs.ToList().Contains(PrefabId)) {
				FFU_BE_Defs.unresearchedModuleIDs.Add(PrefabId);
				if (FFU_BE_Defs.moduleResearchGoal == 0 && FFU_BE_Defs.unresearchedModuleIDs.Count > 0) {
					ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
					FFU_BE_Defs.moduleResearchGoal = refModule.costCreditsInShop / 10 * (refModule.type == ShipModule.Type.Weapon_Nuke || displayName.Contains("Cache") ? 10 : 1);
				}
				StringBuilder newItemInResearchQueueMessage = RstShared.StringBuilder;
				newItemInResearchQueueMessage.AppendFormat(MonoBehaviourExtended.TT("{0} is not listed in crafting database! Adding to reverse engineering queue..."), FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == PrefabId).DisplayNameLocalized);
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, newItemInResearchQueueMessage.ToString());
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Discovered new module: [" + PrefabId + "] " + FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == PrefabId).name + "! Adding to reverse engineering queue...");
			}
			if (Container != null) PlayerResource.RedistributeAllTo(Container, Ownership.GetOwner());
			base.enabled = false;
			UnityEngine.Object.Destroy(base.gameObject);
			GameObject gameObject = (!IsPacked) ? Effects.scrappedPrefab : ((!InStorage) ? Effects.scrappedPackedPrefab : null);
			if (gameObject != null) UnityEngine.Object.Instantiate(gameObject, base.transform.position, base.transform.rotation);
		}
		//Extensive Damage from Overcharge
		[MonoModReplace] public bool StartOvercharge() {
			if (!OverchargeAvailable) return false;
			WorldRules instance = WorldRules.Instance;
			if (RstRandom.value <= instance.moduleOverchargeDamageChance) TakeDamage(UnityEngine.Random.Range(1, MaxHealth / 3));
			if (RstRandom.value <= instance.moduleOverchargeOverloadChance) TryCauseOverload(UnityEngine.Random.Range(1f, 60f));
			if (RstRandom.value <= instance.moduleOverchargeFireChance) if (Ship != null && Ship.Fire != null) Ship.Fire.SetFireAt(base.transform.position);
			overchargeTimer.Restart(overchargeSeconds);
			if (type == Type.Engine) if (Ship != null) UnityEngine.Object.Instantiate(VisualSettings.Instance.shipDodgeEffectPrefab, Ship.transform);
			return true;
		}
		//Damaged Module Continues to Work
		public bool IsWorking {
			get {
				if (!IsPacked && IsPowered && !IsOverloaded && !IsJammed && EnoughOps)
					if (Health / (float)MaxHealth >= FFU_BE_Defs.moduleDamageThreshold)
						return EnoughResources;
				return false;
			}
		}
		//Trigger Module Changes from Damage
		[MonoModReplace] private void Update() {
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
			if (!overloadTimer.ReachedZero && overloadTimer.Update(1f)) EndOverload();
			if (IsPacked && IsOverloaded) EndOverload();
			if (!RstTime.IsPaused && jammedPrefab != null) {
				bool isJammed = IsJammed;
				if (isJammed && isJammedInstance == null) isJammedInstance = UnityEngine.Object.Instantiate(jammedPrefab, base.transform.position, base.transform.rotation, base.transform.parent);
				else if (!isJammed && isJammedInstance != null) UnityEngine.Object.Destroy(isJammedInstance);
			}
			SelfCombustible selfCombustible = SelfCombustible;
			if (selfCombustible != null) {
				bool isWorking = IsWorking;
				if (selfCombustible.enabled != isWorking) selfCombustible.enabled = isWorking;
			}
			if (IsDead) {
				GameObject gameObject = GameObjectPool.TakeRandomPrefab<GameObject>(Effects.explosionPool);
				if (gameObject != null) Explosion.InstantiateExplosion(gameObject, base.transform, base.transform.parent);
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, (Ownership.GetOwner() == Ownership.Owner.Enemy) ? 
					string.Format(MonoBehaviourExtended.TT("Enemy module {0} destroyed"), DisplayNameLocalized) : 
					string.Format(MonoBehaviourExtended.TT("{0} destroyed"), DisplayNameLocalized));
				UnityEngine.Object.Destroy(base.gameObject);
			}
			Animator animator = Animator;
			if (animator != null) animator.SetBool("operational", (type != Type.Warp) ? 
				(TurnedOnAndIsWorking && (PrefabId != 1088715096 || !Weapon.inShootSequence || !Weapon.shotMade)) : 
				((Health / (float)MaxHealth >= FFU_BE_Defs.moduleDamageThreshold) && EnoughOps && EnoughResources && !IsPacked));
			UpdateAppearance();
			bool flag = !PopupControls.PowerManagementMode;
			if (OutlineHoverAndSelect.outlineDrawer.gameObject.activeSelf != flag)
				OutlineHoverAndSelect.outlineDrawer.gameObject.SetActive(flag);
		}
	}
}
