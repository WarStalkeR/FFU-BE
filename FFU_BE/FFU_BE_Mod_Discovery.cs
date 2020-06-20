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
using System.Linq;
using RST.UI;
using System.Text;
using FFU_Bleeding_Edge;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Discovery {
		public static void ProduceResourcesFromWarp(float distance) {
			ResourceValueGroup producedInWarp = ResourceValueGroup.Empty;
			foreach (ShipModule shipModule in PerFrameCache.CachedModules) {
				if ((shipModule.Research != null || shipModule.GardenModule != null) && shipModule.InstanceId > 0 && shipModule.Ownership.GetOwner() == Ownership.Owner.Me && shipModule.TurnedOnAndIsWorking) {
					if (shipModule.Research != null) producedInWarp += shipModule.Research.ProducedPerDistance * distance;
					if (shipModule.GardenModule != null) producedInWarp += shipModule.GardenModule.ProducedPerDistance * distance;
				}
			}
			PlayerData playerData = PlayerDatas.Me;
			if (producedInWarp.organics > 0 && playerData.Organics.SoftMax - playerData.Organics.Total > Mathf.RoundToInt(producedInWarp.organics * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Organics.Add(Mathf.RoundToInt(producedInWarp.organics * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.organics = 0f;
			} else if (producedInWarp.organics > 0) { playerData.Organics.Add(playerData.Organics.SoftMax - playerData.Organics.Total, "produced during hyperjump"); producedInWarp.organics = 0f; }
			if (producedInWarp.fuel > 0 && playerData.Fuel.SoftMax - playerData.Fuel.Total > Mathf.RoundToInt(producedInWarp.fuel * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Fuel.Add(Mathf.RoundToInt(producedInWarp.fuel * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.fuel = 0f;
			} else if (producedInWarp.fuel > 0) { playerData.Fuel.Add(playerData.Fuel.SoftMax - playerData.Fuel.Total, "produced during hyperjump"); producedInWarp.fuel = 0f; }
			if (producedInWarp.metals > 0 && playerData.Metals.SoftMax - playerData.Metals.Total > Mathf.RoundToInt(producedInWarp.metals * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Metals.Add(Mathf.RoundToInt(producedInWarp.metals * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.metals = 0f;
			} else if (producedInWarp.metals > 0) { playerData.Metals.Add(playerData.Metals.SoftMax - playerData.Metals.Total, "produced during hyperjump"); producedInWarp.metals = 0f; }
			if (producedInWarp.synthetics > 0 && playerData.Synthetics.SoftMax - playerData.Synthetics.Total > Mathf.RoundToInt(producedInWarp.synthetics * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Synthetics.Add(Mathf.RoundToInt(producedInWarp.synthetics * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.synthetics = 0f;
			} else if (producedInWarp.synthetics > 0) { playerData.Synthetics.Add(playerData.Synthetics.SoftMax - playerData.Synthetics.Total, "produced during hyperjump"); producedInWarp.synthetics = 0f; }
			if (producedInWarp.explosives > 0 && playerData.Explosives.SoftMax - playerData.Explosives.Total > Mathf.RoundToInt(producedInWarp.explosives * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Explosives.Add(Mathf.RoundToInt(producedInWarp.explosives * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.explosives = 0f;
			} else if (producedInWarp.explosives > 0) { playerData.Explosives.Add(playerData.Explosives.SoftMax - playerData.Explosives.Total, "produced during hyperjump"); producedInWarp.explosives = 0f; }
			if (producedInWarp.exotics > 0 && playerData.Exotics.SoftMax - playerData.Exotics.Total > Mathf.RoundToInt(producedInWarp.exotics * FFU_BE_Defs.warpProducedResourcesMult)) {
				playerData.Exotics.Add(Mathf.RoundToInt(producedInWarp.exotics * FFU_BE_Defs.warpProducedResourcesMult), "produced during hyperjump"); producedInWarp.exotics = 0f;
			} else if (producedInWarp.exotics > 0) { playerData.Exotics.Add(playerData.Exotics.SoftMax - playerData.Exotics.Total, "produced during hyperjump"); producedInWarp.exotics = 0f; }
			if (producedInWarp.credits > 0) { playerData.Credits += Mathf.RoundToInt(producedInWarp.credits * FFU_BE_Defs.warpProducedResourcesMult); producedInWarp.credits = 0f; }
		}
		public static void CalculateProgressFromWarp(float distance) {
			float addReverseProgress = 0;
			float addResearchProgress = 0;
			foreach (ShipModule shipModule in PerFrameCache.CachedModules) {
				if (shipModule.Research != null && shipModule.InstanceId > 0 && shipModule.Ownership.GetOwner() == Ownership.Owner.Me && shipModule.TurnedOnAndIsWorking) {
					addResearchProgress += FFU_BE_Defs.GetResearchFromRVG(shipModule.Research.ProducedPerDistance) * FFU_BE_Defs.tierResearchSpeedMult * 100;
					addReverseProgress += FFU_BE_Defs.GetReverseFromRVG(shipModule.Research.ProducedPerDistance) * FFU_BE_Defs.moduleResearchSpeedMult * 100;
				}
			}
			FFU_BE_Defs.researchProgress += addResearchProgress * distance * FFU_BE_Defs.warpProducedResearchMult;
			FFU_BE_Defs.unusedReverseProgress += addReverseProgress * distance * FFU_BE_Defs.warpProducedResearchMult;
		}
		public static void CalculateProgressFromSublight(ResearchModule instance, float delta) {
			FFU_BE_Defs.researchProgress += FFU_BE_Defs.GetResearchFromRVG(instance.ProducedPerDistance) * FFU_BE_Defs.tierResearchSpeedMult * delta * 100;
			if (FFU_BE_Defs.moduleResearchGoal > 0) {
				if (FFU_BE_Defs.unusedReverseProgress > 0 && FFU_BE_Defs.moduleResearchGoal - FFU_BE_Defs.moduleResearchProgress > FFU_BE_Defs.unusedReverseProgress) {
					FFU_BE_Defs.moduleResearchProgress += FFU_BE_Defs.unusedReverseProgress;
					FFU_BE_Defs.unusedReverseProgress = 0;
				} else if (FFU_BE_Defs.unusedReverseProgress > 0) {
					FFU_BE_Defs.unusedReverseProgress -= FFU_BE_Defs.moduleResearchGoal - FFU_BE_Defs.moduleResearchProgress;
					FFU_BE_Defs.moduleResearchProgress = FFU_BE_Defs.moduleResearchGoal;
				}
				FFU_BE_Defs.moduleResearchProgress += FFU_BE_Defs.GetReverseFromRVG(instance.ProducedPerDistance) * FFU_BE_Defs.moduleResearchSpeedMult * delta * 100;
			} else FFU_BE_Defs.unusedReverseProgress = 0;
			if (FFU_BE_Defs.moduleResearchProgress > FFU_BE_Defs.moduleResearchGoal) {
				FFU_BE_Defs.moduleResearchGoal = 0;
				FFU_BE_Defs.moduleResearchProgress = 0;
				StringBuilder newCraftableItemMessage = RstShared.StringBuilder;
				newCraftableItemMessage.AppendFormat(MonoBehaviourExtended.TT("{0} was successfully reverse engineered and now available for crafting!"), FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First()).DisplayNameLocalized);
				StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, newCraftableItemMessage.ToString());
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Module [" + FFU_BE_Defs.unresearchedModuleIDs.ToList().First() + "] " + FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First()).name + " was successfully reverse engineered!");
				FFU_BE_Defs.discoveredModuleIDs.Add(FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
				if (!FFU_BE_Defs.allModulesCraftable) ModuleSlotActionsPanel.altCraftableModulePrefabs.Add(FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First()));
				if (!FFU_BE_Defs.allModulesCraftable) ModuleSlotActionsPanel.altCraftableModulePrefabs.Sort((ShipModule x, ShipModule y) => FFU_BE_Defs.SortAllModules(x).CompareTo(FFU_BE_Defs.SortAllModules(y)));
				FFU_BE_Defs.unresearchedModuleIDs.Remove(FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
				if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 0 && FFU_BE_Defs.unresearchedModuleIDs.ToList().First() > 0) {
					ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First());
					FFU_BE_Defs.moduleResearchGoal = refModule.costCreditsInShop / 10 * (refModule.type == ShipModule.Type.Weapon_Nuke || refModule.displayName.Contains("Cache") ? 10 : 1);
				} else FFU_BE_Defs.unusedReverseProgress = 0;
			}
		}
		public static void HostileAttentionCheck() {
			if (FFU_BE_Defs.distanceTraveledInPeace >= GetCurrentScanFrequency()) FFU_BE_Defs.summonAttempted = false;
			if (!FFU_BE_Defs.summonEnforcerFleet && FFU_BE_Defs.distanceTraveledInPeace >= GetCurrentScanFrequency() && !FFU_BE_Defs.summonAttempted) {
				FFU_BE_Defs.RecalculateEnergyEmission();
				FFU_BE_Defs.summonEnforcerFleet = RstRandom.Range(0f, 1f) <= (FFU_BE_Defs.energyEmission / FFU_BE_Defs.scanResolution[FFU_BE_Defs.discoveryScanLevel]);
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Tried to summon fleet with " + string.Format("{0:0.##}", FFU_BE_Defs.energyEmission / FFU_BE_Defs.scanResolution[FFU_BE_Defs.discoveryScanLevel] * 100f) + "% chance and " + (FFU_BE_Defs.summonEnforcerFleet ? "succeeded" : "failed") + "!");
				if (!FFU_BE_Defs.summonEnforcerFleet) StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, "<color=#ffff00ff>Attention! Local forces tried to pinpoint your exact coordinates for interdiction through " + GetScanLevelText() + " scanning, but failed. From the looks of it, they don't intend to give up anytime soon.</color>");
				if (FFU_BE_Defs.discoveryScanLevel < 4) FFU_BE_Defs.discoveryScanLevel++;
				if (FFU_BE_Defs.discoveryScanLevel > 4) FFU_BE_Defs.discoveryScanLevel = 4;
				FFU_BE_Defs.distanceTraveledInPeace = 0f;
				FFU_BE_Defs.summonAttempted = true;
			}
			if (FFU_BE_Defs.summonEnforcerFleet) {
				foreach (POI poi in PerFrameCache.CachedPOIs) if (poi.name.Contains("MustExpireAfterMeeting")) poi.gameObject.Destroy();
				PlayerFleet playerFleet = PlayerFleet.Instance;
				Sector sectorInstance = Sector.Instance;
				if (playerFleet != null & sectorInstance != null) {
					Fleet refFleet = Resources.FindObjectsOfTypeAll<Fleet>().ToList().Find(x => x.name == GetViableSectorFleetName(sectorInstance.number));
					if (refFleet != null && playerFleet != null) {
						Vector2 playerPos = playerFleet.transform.position;
						Vector2 relativePos = (Random.value >= 0.5f) ? new Vector2((Random.value >= 0.5f) ? -1 : 1, 0f) : new Vector2(0f, (Random.value >= 0.5f) ? -1 : 1);
						Vector2 ambusherPos = playerPos + relativePos * Random.Range(10f, 15f);
						Fleet ambusherFleet = Object.Instantiate(refFleet, ambusherPos, Quaternion.identity, playerFleet.transform.parent);
						ambusherFleet.speed = PlayerDatas.Me.GetCurrentStarmapSpeed(null) * 1.1f;
						ambusherFleet.name += "MustExpireAfterMeeting";
						if (playerFleet.warpAudioClip != null) ambusherFleet.AI.AudioSource.PlayOneShot(playerFleet.warpAudioClip);
						foreach (TimePanelControls timePanelControls in Resources.FindObjectsOfTypeAll<TimePanelControls>()) if (WorldRules.Impermanent.ironman) Delegated.dDoSlowMotion(timePanelControls); else Delegated.dDoPause(timePanelControls);
						StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, "Warning! You've drawn too much attention from local forces! Enemy interdiction fleet has warped in and pursuing us at high speed!");
						if (FFU_BE_Defs.debugMode) Debug.LogWarning("Hostile fleet came to intercept player's fleet at Hostile Awareness Level " + string.Format("{0:0}", FFU_BE_Defs.distanceTraveledInPeace));
						FFU_BE_Defs.timesInterceptedByEnforcers[sectorInstance.number - 1]++;
						while (FFU_BE_Defs.timesInterceptedByEnforcers[sectorInstance.number - 1] > FFU_BE_Defs.killedFleetsTrigger[FFU_BE_Defs.discoveryFleetsLevel] && FFU_BE_Defs.discoveryFleetsLevel < (FFU_BE_Defs.killedFleetsTrigger.Length - 1)) FFU_BE_Defs.discoveryFleetsLevel++;
						if (FFU_BE_Defs.discoveryFleetsLevel > (FFU_BE_Defs.killedFleetsTrigger.Length - 1)) FFU_BE_Defs.discoveryFleetsLevel = FFU_BE_Defs.killedFleetsTrigger.Length - 1;
						FFU_BE_Defs.distanceTraveledInPeace = 0f;
						FFU_BE_Defs.discoveryScanLevel = 0;
						FFU_BE_Defs.summonEnforcerFleet = false;
						FFU_BE_Defs.summonAttempted = true;
					}
				}
			}
		}
		public static string GetViableSectorFleetName(int sectorNum) {
			List<string> viableFleets = new List<string>();
			switch (sectorNum) {
				case 1:
				viableFleets.Add("Ambusher L1 Life taster");
				viableFleets.Add("Ambusher L1 Rat pirate, old alone or with sstriker");
				viableFleets.Add("Ambusher L1 Rats, 2 or 3 small ships");
				viableFleets.Add("Ambusher L1 Rats, Royal + 1small");
				viableFleets.Add("Ambusher L1 Rats, old cruiser +1small");
				viableFleets.Add("Ambusher L1 Rats, red cruiser +1small");
				viableFleets.Add("Ambusher L1 Solipsist small");
				viableFleets.Add("Ambusher L1 Style guardians, redsaucer or tac");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 2:
				viableFleets.Add("Ambusher L1 Solipsist small");
				viableFleets.Add("Ambusher L1 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L1 Life taster");
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L2 pirates, rat pirates + slavers, intruderspawn");
				viableFleets.Add("Ambusher L2 pirates, sstriker and arrowhead");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 3:
				viableFleets.Add("Ambusher L1 Solipsist small");
				viableFleets.Add("Ambusher L1 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L1 Life taster");
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L2 pirates, rat pirates + slavers, intruderspawn");
				viableFleets.Add("Ambusher L2 pirates, sstriker and arrowhead");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 4:
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("SOS Ambusher L4 Insectoid hunters");
				viableFleets.Add("Ambusher L4 Insectoid bluebios, holy injustice");
				viableFleets.Add("Ambusher L4 Insectoids floral bird + 1 floral small");
				viableFleets.Add("Ambusher L4 Insectoids smallbeetle + 1or2 scarabeus");
				viableFleets.Add("Ambusher L4 Insectoids wasp + 1 small");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 5:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L5 slavers, 2x slaver arrowhead");
				viableFleets.Add("Ambusher L5 slavers, 2x slaver bullet");
				viableFleets.Add("Ambusher L5 slavers, 3x slaver bullet");
				viableFleets.Add("Ambusher L5 slavers, arrow cmd + arrowhead");
				viableFleets.Add("Ambusher L5 slavers, arrow cmd +srat +bullet");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 6:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambushers L6 squid patrol");
				viableFleets.Add("Ambushers L6 squid patrol 1 medium");
				viableFleets.Add("Ambushers L6 squid patrol 1 scout");
				viableFleets.Add("Ambushers L6 squid patrol 2 scouts");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 7:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambushers L6 squid patrol");
				viableFleets.Add("Ambushers L6 squid patrol 1 medium");
				viableFleets.Add("Ambushers L6 squid patrol 1 scout");
				viableFleets.Add("Ambushers L6 squid patrol 2 scouts");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 8:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambushers L6 squid patrol");
				viableFleets.Add("Ambushers L6 squid patrol 1 medium");
				viableFleets.Add("Ambushers L6 squid patrol 1 scout");
				viableFleets.Add("Ambushers L6 squid patrol 2 scouts");
				viableFleets.Add("Ambusher L7 Squid assasnik");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 9:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L7 Squid assasnik");
				viableFleets.Add("Ambushers L9 sec corp heavy patrol");
				viableFleets.Add("Ambushers L9 sec corp light patrol");
				viableFleets.Add("Ambushers L9 sec corp medium patrol");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				case 10:
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L7 Squid assasnik");
				viableFleets.Add("Ambushers L10 neutralites 2 medium");
				viableFleets.Add("Ambushers L10 neutralites 3 smalls");
				viableFleets.Add("Ambushers L10 neutralites large and small");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
				default:
				viableFleets.Add("Ambusher L1 Life taster");
				viableFleets.Add("Ambusher L1 Rat pirate, old alone or with sstriker");
				viableFleets.Add("Ambusher L1 Rats, 2 or 3 small ships");
				viableFleets.Add("Ambusher L1 Rats, Royal + 1small");
				viableFleets.Add("Ambusher L1 Rats, old cruiser +1small");
				viableFleets.Add("Ambusher L1 Rats, red cruiser +1small");
				viableFleets.Add("Ambusher L1 Solipsist small");
				viableFleets.Add("Ambusher L1 Style guardians, redsaucer or tac");
				viableFleets.Add("SOS Ambusher Life taster 2");
				viableFleets.Add("Ambusher L2 Solipsist medium");
				viableFleets.Add("Ambusher L2 pirates, rat pirates + slavers, intruderspawn");
				viableFleets.Add("Ambusher L2 pirates, sstriker and arrowhead");
				viableFleets.Add("Ambusher L3 Squid bounty hunter");
				viableFleets.Add("SOS Ambusher L4 Insectoid hunters");
				viableFleets.Add("Ambusher L4 Insectoid bluebios, holy injustice");
				viableFleets.Add("Ambusher L4 Insectoids floral bird + 1 floral small");
				viableFleets.Add("Ambusher L4 Insectoids smallbeetle + 1or2 scarabeus");
				viableFleets.Add("Ambusher L4 Insectoids wasp + 1 small");
				viableFleets.Add("Ambusher L4 Style guardians, redsaucer or tac");
				viableFleets.Add("Ambusher L5 slavers, 2x slaver arrowhead");
				viableFleets.Add("Ambusher L5 slavers, 2x slaver bullet");
				viableFleets.Add("Ambusher L5 slavers, 3x slaver bullet");
				viableFleets.Add("Ambusher L5 slavers, arrow cmd + arrowhead");
				viableFleets.Add("Ambusher L5 slavers, arrow cmd +srat +bullet");
				viableFleets.Add("Ambushers L6 squid patrol");
				viableFleets.Add("Ambushers L6 squid patrol 1 medium");
				viableFleets.Add("Ambushers L6 squid patrol 1 scout");
				viableFleets.Add("Ambushers L6 squid patrol 2 scouts");
				viableFleets.Add("Ambusher L7 Squid assasnik");
				viableFleets.Add("Ambushers L9 sec corp heavy patrol");
				viableFleets.Add("Ambushers L9 sec corp light patrol");
				viableFleets.Add("Ambushers L9 sec corp medium patrol");
				viableFleets.Add("Ambushers L10 neutralites 2 medium");
				viableFleets.Add("Ambushers L10 neutralites 3 smalls");
				viableFleets.Add("Ambushers L10 neutralites large and small");
				return Core.RandomItemFromList(viableFleets, "Ambusher L1 Life taster");
			}
		}
		public static string GetHostileAwarnessLevel() {
			switch (FFU_BE_Defs.discoveryScanLevel) {
				case 0: return "<color=#" + "00ff00" + "ff>" + GetAwarnessLevelText() + "</color>";
				case 1: return "<color=#" + "ffff00" + "ff>" + GetAwarnessLevelText() + "</color>";
				case 2: return "<color=#" + "ffbf00" + "ff>" + GetAwarnessLevelText() + "</color>";
				case 3: return "<color=#" + "ff8000" + "ff>" + GetAwarnessLevelText() + "</color>";
				case 4: return "<color=#" + "ff0000" + "ff>" + GetAwarnessLevelText() + "</color>";
				default: return "<color=#" + "ffffff" + "ff>" + GetAwarnessLevelText() + "</color>";
			}
		}
		public static float GetCurrentScanFrequency() {
			return FFU_BE_Defs.scanFrequency - (Sector.Instance != null ? Sector.Instance.number * 100f : 100f);
		}
		public static int GetKilledFleetsCount() {
			int currentSector = Sector.Instance != null ? Sector.Instance.number : 0;
			return FFU_BE_Defs.timesInterceptedByEnforcers[currentSector];
		}
		public static int GetTopFleetsTrigger() {
			return FFU_BE_Defs.killedFleetsTrigger[FFU_BE_Defs.killedFleetsTrigger.Length - 1];
		}
		public static string GetHostileFleetsLevel() {
			switch (FFU_BE_Defs.discoveryFleetsLevel) {
				case 0: return "<color=#" + "00ff00" + "ff>" + "Useless" + "</color>";
				case 1: return "<color=#" + "55ff00" + "ff>" + "Unskilled" + "</color>";
				case 2: return "<color=#" + "aaff00" + "ff>" + "Mediocre" + "</color>";
				case 3: return "<color=#" + "ffff00" + "ff>" + "Trained" + "</color>";
				case 4: return "<color=#" + "ffd200" + "ff>" + "Experienced" + "</color>";
				case 5: return "<color=#" + "ffa800" + "ff>" + "Proficient" + "</color>";
				case 6: return "<color=#" + "ff7e00" + "ff>" + "Veterans" + "</color>";
				case 7: return "<color=#" + "ff5400" + "ff>" + "Professionals" + "</color>";
				case 8: return "<color=#" + "ff2a00" + "ff>" + "Elites" + "</color>";
				case 9: return "<color=#" + "ff0000" + "ff>" + "Special Ops" + "</color>";
				default: return "<color=#" + "ffffff" + "ff>" + "Unknown" + "</color>";
			}
		}
		public static string GetHostileFleetsLevel(int fltLevel) {
			switch (fltLevel) {
				case 0: return "<color=#" + "00ff00" + "ff>" + "Useless" + "</color>";
				case 1: return "<color=#" + "55ff00" + "ff>" + "Unskilled" + "</color>";
				case 2: return "<color=#" + "aaff00" + "ff>" + "Mediocre" + "</color>";
				case 3: return "<color=#" + "ffff00" + "ff>" + "Trained" + "</color>";
				case 4: return "<color=#" + "ffd200" + "ff>" + "Experienced" + "</color>";
				case 5: return "<color=#" + "ffa800" + "ff>" + "Proficient" + "</color>";
				case 6: return "<color=#" + "ff7e00" + "ff>" + "Veterans" + "</color>";
				case 7: return "<color=#" + "ff5400" + "ff>" + "Professionals" + "</color>";
				case 8: return "<color=#" + "ff2a00" + "ff>" + "Elites" + "</color>";
				case 9: return "<color=#" + "ff0000" + "ff>" + "Special Ops" + "</color>";
				default: return "<color=#" + "ffffff" + "ff>" + "Unknown" + "</color>";
			}
		}
		public static string GetAwarnessLevelText() {
			switch (FFU_BE_Defs.discoveryScanLevel) {
				case 0: return "Unnoticed";
				case 1: return "Discovered";
				case 2: return "Observed";
				case 3: return "Wanted";
				case 4: return "Pursued";
				default: return "Unknown";
			}
		}
		public static string GetScanLevelText() {
			switch (FFU_BE_Defs.discoveryScanLevel) {
				case 0: return "Low-Energy Signature (" + FFU_BE_Defs.scanResolution[0] + "nm)";
				case 1: return "High-Energy Signature (" + FFU_BE_Defs.scanResolution[1] + "nm)";
				case 2: return "Hyperspace Slipstream (" + FFU_BE_Defs.scanResolution[2] + "nm)";
				case 3: return "Multi-Phased Subspace (" + FFU_BE_Defs.scanResolution[3] + "nm)";
				case 4: return "Wave-Folding Quantum (" + FFU_BE_Defs.scanResolution[4] + "nm)";
				default: return "Unknown Scan";
			}
		}
	}
}

namespace RST {
	public class patch_PlayerFleet : PlayerFleet {
		[MonoModReplace] private void DoAsteroidHit(Ship playerShip) {
		/// Increase Damage From Asteroids
			if (hitAudio != null) AudioSource.PlayOneShot(hitAudio);
			if (hitCausesFire && playerShip != null) {
				if (playerShip.Fire != null) playerShip.Fire.SetFireAtRandomPos();
				hitDamageToShip = UnityEngine.Random.Range(5, Mathf.Max(50, playerShip.MaxHealth / 10) + 1);
				playerShip.TakeDamage(hitDamageToShip);
			}
			string line = string.Format(Localization.TT("Ship was hit by an asteroid. HP -{0}"), hitDamageToShip);
			StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Bad, line);
			ComchannelTip.Instance?.NotifyAboutAsteroidHit();
		}
		[MonoModReplace] public bool WarpUsingWarpGate(WarpGate wg) {
		/// Research & Peaceful Distance from Warp Gate
			if (wg == null) return false;
			if (wg.Destination == null) return false;
			Vector2 shipPos = transform.position;
			Vector2 starPos = wg.Destination.arrivals.transform.position;
			float warpedDistance = Vector2.Distance(starPos, shipPos);
			FFU_BE_Mod_Discovery.ProduceResourcesFromWarp(warpedDistance);
			if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Mod_Discovery.CalculateProgressFromWarp(warpedDistance);
			if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Defs.distanceTraveledInPeace += warpedDistance;
			if (wg.Destination.arrivals != null) {
				base.transform.SetParent(wg.Destination.arrivals.transform);
				SetPosition(wg.Destination.arrivals.transform.position);
			} else {
				base.transform.SetParent(wg.Destination.transform);
				SetPosition(wg.Destination.transform.position);
			}
			return true;
		}
		[MonoModReplace] public bool WarpToStar(Star targetStar) {
		/// Research & Peaceful Distance from Warp Drive
			if (targetStar == null) return false;
			Vector2 shipPos = transform.position;
			Vector2 starPos = targetStar.transform.position;
			float warpedDistance = Vector2.Distance(starPos, shipPos);
			FFU_BE_Mod_Discovery.ProduceResourcesFromWarp(warpedDistance);
			if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Mod_Discovery.CalculateProgressFromWarp(warpedDistance);
			if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Defs.distanceTraveledInPeace += warpedDistance;
			Vector2 targetPos = ((Vector2)base.transform.position - (Vector2)targetStar.transform.position).normalized * 45f + (Vector2)targetStar.transform.position;
			WarpModule usableWarpModule = GetUsableWarpModule();
			if (usableWarpModule == null) return false;
			return usableWarpModule.StartWarpingTo(targetPos, targetStar.transform, false);
		}
	}
	public class patch_WarningsVisualizer : WarningsVisualizer {
		private extern void orig_UpdateData();
		private void UpdateData() {
		/// Remove Modules and Upgrades Notification Icon
			orig_UpdateData();
			if (moduleSlotUpgradesAvailable != null) moduleSlotUpgradesAvailable = null;
			if (moduleCraftsAvailable != null) moduleCraftsAvailable = null;
		}
		public static bool PlayerFleetJammedWarning {
		/// Null Reference Exception Patch-Fix
			get {
				try { return PlayerFleet.Instance != null && PlayerFleet.Instance.IsJammed; } 
				catch { return true; }
			}
		}
		[MonoModReplace] public static bool WarpIsDisabledForOwner(Ownership.Owner forOwner) {
		/// Advanced Warp Drive Jamming Feature
			Ownership.Owner enemyOwner = Ownership.GetOpposite(forOwner);
			try { return PerFrameCache.CachedShips.Exists((Ship s) => s != null && s.disablesEnemyWarp && s.Ownership.GetOwner() == enemyOwner) ||
				(forOwner == Ownership.Owner.Me && WarningsVisualizer.PlayerFleetJammedWarning && FFU_BE_Defs.distanceTraveledInPeace < 5f);
			} catch { return PerFrameCache.CachedShips.Exists((Ship s) => s != null && s.disablesEnemyWarp && s.Ownership.GetOwner() == enemyOwner); }
		}
	}
	public class patch_WarpModule : WarpModule {
		[MonoModIgnore] public Vector2 Destination { get; private set; }
		[MonoModIgnore] public Transform DestinationNewParent { get; private set; }
		[MonoModIgnore] private void SetAnimState(bool warpIsLoading, bool destroyIntviewShipToo, float warpLoadDuration) { }
		[MonoModReplace] private bool UpdateCountdown() {
		/// Tier dependent Instant Warp Mode
			float healthPercent = Mathf.Pow(FFU_BE_Defs.GetHealthPercent(Module), 2);
			float speedMultiplier = Module.TurnedOnAndIsWorking ? (1f / WorldRules.Instance.warpSkillEffects.EffectiveSkillMultiplier(Module, true)) : 0f;
			if (Module.HasFullHealth) return reloadTimer.Update(Mathf.Max(speedMultiplier * (PerFrameCache.IsGoodSituation ? 10f : 1f), 1f));
			else return reloadTimer.Update(Mathf.Max(speedMultiplier * (PerFrameCache.IsGoodSituation ? 10f : 1f) * healthPercent, healthPercent));
		}
		[MonoModReplace] private void EndWarping(bool success, bool destroyIntviewShipToo) {
		/// Hostile Attention Check after Warping
			ShipModule module = Module;
			if (!success && activationFuel != 0) {
				PlayerData playerData = PlayerDatas.Get(module.Ownership.GetOwner());
				if (playerData != null) {
					playerData.Fuel.Add(activationFuel, MonoBehaviourExtended.tt("warp activation"));
				}
			}
			reloadTimer.Restart(reloadInterval);
			Destination = Vector2.zero;
			DestinationNewParent = null;
			module.turnedOn = false;
			SetAnimState(false, destroyIntviewShipToo, 0f);
			FFU_BE_Mod_Discovery.HostileAttentionCheck();
		}
	}
	public class patch_EngineModule : EngineModule {
		[MonoModIgnore] private float organicsDist;
		[MonoModIgnore] private float fuelDist;
		[MonoModIgnore] private float metalsDist;
		[MonoModIgnore] private float syntheticsDist;
		[MonoModIgnore] private float explosivesDist;
		[MonoModIgnore] private float exoticsDist;
		[MonoModIgnore] private float creditsDist;
		[MonoModIgnore] private ResourceValueGroup consumedPerDistance;
		public void AddDistanceTravelled(float delta) {
		/// Increase Peaceful Distance Counter if not Jammed
			if (IsConsumingPerDistance) {
				PlayerData playerData = PlayerDatas.Get(Module.Ownership.GetOwner());
				if (!(playerData == null)) {
					string reason = null;
					bool notConsuming = false;
					if (Module.HasFullHealth) {
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref organicsDist, delta, consumedPerDistance.organics, playerData.Organics, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref fuelDist, delta, consumedPerDistance.fuel, playerData.Fuel, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref metalsDist, delta, consumedPerDistance.metals, playerData.Metals, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref syntheticsDist, delta, consumedPerDistance.synthetics, playerData.Synthetics, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref explosivesDist, delta, consumedPerDistance.explosives, playerData.Explosives, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref exoticsDist, delta, consumedPerDistance.exotics, playerData.Exotics, reason);
						ResourceValueGroup.ProcessOneCreditCons(ref notConsuming, ref creditsDist, delta, consumedPerDistance.credits, playerData, reason);
					} else {
						float consMult = FFU_BE_Defs.GetHealthPercent(Module);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref organicsDist, delta, consumedPerDistance.organics * consMult, playerData.Organics, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref fuelDist, delta, consumedPerDistance.fuel * consMult, playerData.Fuel, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref metalsDist, delta, consumedPerDistance.metals * consMult, playerData.Metals, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref syntheticsDist, delta, consumedPerDistance.synthetics * consMult, playerData.Synthetics, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref explosivesDist, delta, consumedPerDistance.explosives * consMult, playerData.Explosives, reason);
						ResourceValueGroup.ProcessOneResourceCons(ref notConsuming, ref exoticsDist, delta, consumedPerDistance.exotics * consMult, playerData.Exotics, reason);
						ResourceValueGroup.ProcessOneCreditCons(ref notConsuming, ref creditsDist, delta, consumedPerDistance.credits * consMult, playerData, reason);
					}
					if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Defs.distanceTraveledInPeace += delta;
					FFU_BE_Mod_Discovery.HostileAttentionCheck();
				}
			}
		}
	}
	public class patch_ResearchModule : ResearchModule {
		[MonoModIgnore] private ResourceValueGroup gen;
		public void AddDistanceTravelled(float delta) {
		/// Generate research points if not Jammed
			if (IsProducingPerDistance) {
				gen += ProducedPerDistance * delta;
				if (!WarningsVisualizer.PlayerFleetJammedWarning) FFU_BE_Mod_Discovery.CalculateProgressFromSublight(this, delta);
				if (!GardenModule.DoProduction(ref gen, Module.Ownership.GetOwner(), resourceGenReason)) {
					gen -= ProducedPerDistance * delta;
				}
			}
		}
		public ResourceValueGroup ProducedPerDistance {
		/// Allow Laboratory Modules to Produce All Types
			get {
				int effectiveResearchProduction = Module.TurnedOnAndIsWorking ? WorldRules.Instance.scienceSkillEffects.EffectiveCreditsProduction(Module) : 0;
				if (Module.HasFullHealth) return producedPerSkillPoint * (effectiveResearchProduction / 100f);
				else return producedPerSkillPoint * (effectiveResearchProduction / 100f) * FFU_BE_Defs.GetHealthPercent(Module);
			}
		}
	}
	public class patch_GardenModule : GardenModule {
		public ResourceValueGroup ProducedPerDistance {
		/// Allow Greenhouse Modules to Produce All Types
			get {
				int effectiveGreenhouseProduction = Module.TurnedOnAndIsWorking ? WorldRules.Instance.gardenSkillEffects.EffectiveOrganicsProduction(Module) : 0;
				if (Module.HasFullHealth) return producedPerSkillPoint * (effectiveGreenhouseProduction / 100f);
				else return producedPerSkillPoint * (effectiveGreenhouseProduction / 100f) * FFU_BE_Defs.GetHealthPercent(Module);
			}
		}
	}
}