#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0414

using System;
using System.Text.RegularExpressions;
using UnityEngine;
using MonoMod;
using RST.UI;
using RST.PlaymakerAction;
using HutongGames.PlayMaker;
using System.Collections.Generic;
using System.Linq;
using FFU_Bleeding_Edge;
using UnityEngine.UI;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Backend {
		public static float timePassedOrganics = 50f;
		public static float timePassedFuel = 50f;
		public static float timePassedMetals = 50f;
		public static float timePassedSynthetics = 50f;
		public static float timePassedExplosives = 50f;
		public static float timePassedExotics = 50f;
		public static float timePassedCredits = 50f;
		public static int lastValueOrganics = -1;
		public static int lastValueFuel = -1;
		public static int lastValueMetals = -1;
		public static int lastValueSynthetics = -1;
		public static int lastValueExplosives = -1;
		public static int lastValueExotics = -1;
		public static int lastValueCredits = -1;
	}
}

namespace RST {
	public class patch_WeaponModule : WeaponModule {
		[MonoModIgnore] private Ship ParentShip;
		[MonoModIgnore] private float shotTimer;
		[MonoModIgnore] private int shotsToMake;
		[MonoModIgnore] private int BarrelTipCount;
		[MonoModIgnore] private float preshootTimer;
		[MonoModIgnore] public bool shotMade { get; private set; }
		[MonoModIgnore] private bool DoLoadAndAim() { return false; }
		[MonoModIgnore] public bool inShootSequence { get; private set; }
		[MonoModIgnore] public float SecondsSinceLastTargetSwitch { get; private set; }
		[MonoModIgnore] private ShootAtDamageDealer CreateDamageDealer(int barrelTipIndex, bool isFirstInVolley) { return null; }
		//Min Aim Angle based on Weapon Type
		public float CalculateAimAngle(Vector2 targetPos) {
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
			float shipAccuracyBonus = ((ship != null) ? (1f + ship.GetAccuracy(null) * 0.01f) : 1f) * num;
			if (Module.type == ShipModule.Type.Weapon_Nuke) return 0f;
			else if (Module.displayName.ToLower().Contains("rail")) return Mathf.Clamp(gunnerySkillEffects.EffectiveAngle(this) * (1f / shipAccuracyBonus), 1f, 30f);
			else return Mathf.Clamp(gunnerySkillEffects.EffectiveAngle(this) * (1f / shipAccuracyBonus), 4f, 90f);
		}
		//Use All Weapon Barrels Consequently
		private void Update() {
			if (shotsToMake > 0) {
				if (shotTimer <= 0f) {
					int barrelTipIndex = BarrelTipCount - shotsToMake;
					CreateDamageDealer(barrelTipIndex, shotsToMake == magazineSize);
					shotsToMake--;
					shotTimer = shotInterval;
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
			else if (!inShootSequence) reloadTimer.Update(reloadIntervalTakesNoBonuses ? 1f : (1f / WorldRules.Instance.gunnerySkillEffects.EffectiveSkillMultiplier(module, true)));
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
				}
			} else {
				inShootSequence = false;
				shotMade = false;
			}
			SecondsSinceLastTargetSwitch += Time.deltaTime;
		}
	}
	public class patch_ShootAtDamageDealer : ShootAtDamageDealer {
		//Overload Shield Gens/Caps from Damage
		protected void DoShieldHit(Shield shield) {
			if (shield == null) return;
			if (shield.ShieldPoints < damage.shieldDmg) {
				Ship ship = shield.Ship;
				if (ship != null)
				foreach (ShipModule module in ship.Modules)
				if (module != null && module.type == ShipModule.Type.ShieldGen && module.TurnedOnAndIsWorking)
				module.TryCauseOverload(Mathf.Clamp(damage.shieldDmg - shield.ShieldPoints, 20f, 120f));
			}
			shield.PlayHitAnimation();
			shield.ShieldPoints = Mathf.Max(0, shield.ShieldPoints - damage.shieldDmg);
			GameObject gameObject = GameObjectPool.TakeRandomPrefab<GameObject>(Effects.explosionOnShieldPool);
			if (gameObject != null) {
				Explosion.InstantiateExplosion(gameObject, base.transform, target);
			}
		}
		//Improved Boarding/Spawner Nukes Mechanic
		protected void DoHit(Collider2D[] hits, int hitCount, Vector2 hitPos) {
			Collider2D collider2D = null;
			for (int i = 0; i < hitCount; i++) {
				Collider2D collider2D2 = hits[i];
				if (!(collider2D2 != null)) continue;
				(collider2D2.GetComponent(typeof(IHasHealth)) as IHasHealth)?.TakeDamage(damage, hitPos);
				if (!collider2D2.CompareTag("IntViewShip")) continue;
				collider2D = collider2D2;
				if (target != null) {
					RisingText.FireAndForget(target.gameObject, (-damage.shipDmg).ToString(), Color.red, RisingText.Space.World);
					if (target.GetComponent(typeof(IHasDisplayNameLocalized)) is IHasDisplayNameLocalized hasDisplayNameLocalized) {
						StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, string.Format(MonoBehaviourExtended.TT("Hit {0}"), hasDisplayNameLocalized.DisplayNameLocalized));
					}
				}
			}
			GameObject gameObject = GameObjectPool.TakeRandomPrefab<GameObject>(Effects.explosionPool);
			if (gameObject != null) Explosion.InstantiateExplosion(gameObject, base.transform, target);
			if (!(collider2D != null)) return;
			float num = 0.2f;
			Ownership.Owner owner = (Ownership != null) ? Ownership.GetOwner() : ((sourceWeapon != null) ? sourceWeapon.Module.Ownership.GetOwner() : Ownership.Owner.None);
			if (owner == Ownership.Owner.None) return;
			int moddedSpawnCount = spawnIntruderCount > 0 ? (int)FFU_BE_Defs.GetIntruderCountFromName(this) : 0;
			int randomSpawnCount = spawnIntruderCount > 0 ? (int)UnityEngine.Random.Range(moddedSpawnCount / 3f * 2f, moddedSpawnCount / 3f * 5f) : 0;
			for (int j = 0; j < randomSpawnCount; j++) {
				Crewmember crewmember = FFU_BE_Defs.GetRandomIntruderFromName(this);
				if (crewmember != null) {
					Crewmember bioPayloadSpawn = UnityEngine.Object.Instantiate(crewmember);
					Vector2 v = hitPos;
					if (j > 0) v += new Vector2(RstRandom.Range(0f - num, num), RstRandom.Range(0f - num, num));
					bioPayloadSpawn.transform.parent = collider2D.transform;
					bioPayloadSpawn.transform.position = v;
					bioPayloadSpawn.transform.localScale = Vector3.one;
					bioPayloadSpawn.Ownership.SetOwner(owner);
					bioPayloadSpawn.role = Crewmember.Role.Intruder;
					bioPayloadSpawn.gameObject.SetActive(true);
					bioPayloadSpawn.Idle(false);
					bioPayloadSpawn.name += "ShortLifeSpan";
					if (PlayerDatas.Me.crewRecords.ContainsKey(bioPayloadSpawn.InstanceId)) {
						PlayerDatas.Me.crewRecords[crewmember.InstanceId].forgotten = true;
					} else {
						CrewmemberRecord value = new CrewmemberRecord {
							status = CrewmemberRecord.Status.Alive,
							crewType = bioPayloadSpawn.type,
							crewDisplayName = bioPayloadSpawn.displayName,
							crewInstanceId = bioPayloadSpawn.InstanceId,
							crewPrefabId = bioPayloadSpawn.PrefabId,
							crewSeed = bioPayloadSpawn.seed,
							Avatar = bioPayloadSpawn.avatar,
							HandWeaponPrefab = bioPayloadSpawn.HandWeaponPrefab,
							AnimController = bioPayloadSpawn.AnimController,
							forgotten = true
						};
						PlayerDatas.Me.crewRecords.Add(bioPayloadSpawn.InstanceId, value);
					}
					FFU_BE_Mod_Crewmembers.ApplyCrewChanges(bioPayloadSpawn);
				}
			}
		}
	}
	public class patch_RepairSkillEffects : RepairSkillEffects {
		//Speed Up Hull Repair Time
		public float GetShipHpRepairTime(Crewmember c, bool considerAccelTime) {
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.shipHullRepairAcceleration : 1f;
			return FFU_BE_Defs.shipHullRepairTime * TimeMultiplier(c) / timeMult;
		}
		//Speed Up Module Repair Time
		public float GetModuleHpRepairTime(Crewmember c, bool considerAccelTime) {
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.moduleRepairAcceleration : 1f;
			return FFU_BE_Defs.moduleRepairTime * TimeMultiplier(c) / timeMult;
		}
		//Decrease Module Repair Cost
		public ResourceValueGroup ModuleHpRepairCost {
			get { return new ResourceValueGroup { synthetics = FFU_BE_Defs.moduleRepairCost }; }
		}
	}
	public class patch_Shop : Shop {
		[MonoModIgnore] private bool wasLoaded;
		//Increased Station Resource Capacity
		private void Start() {
			if (!wasLoaded) {
				moduleCommissionFeeSeed = RstRandom.positiveIntValue;
				if (crewStation) {
					int crewPoolSize = RstRandom.Range(crewPoolTakeMin, crewPoolTakeMax + 1);
					foreach (Crewmember shopMember in InstantiateFromPool.DoIt<Crewmember>(crewPool, crewPoolAllowDuplicates, buyableCrewContainer, (crewPoolSize <= 0) ? crewPool.Length : crewPoolSize)) {
						shopMember.Randomize();
						shopMember.BuyableAssignToStore(this);
					}
				}
				if (moduleStation) {
					int modulePoolSize = RstRandom.Range(modulePoolTakeMin, modulePoolTakeMax + 1);
					foreach (ShipModule shopModule in InstantiateFromPool.DoIt<ShipModule>(modulePool, modulePoolAllowDuplicates, buyableModulesContainer, (modulePoolSize <= 0) ? modulePool.Length : modulePoolSize)) {
						shopModule.SetHealthToPercent(100f - RstRandom.Range(moduleDamagePercentMin, moduleDamagePercentMax));
						shopModule.BuyableAssignToStore(this);
					}
				}
				organics.capacity *= FFU_BE_Defs.stationCapacityMult;
				fuel.capacity *= FFU_BE_Defs.stationCapacityMult;
				metals.capacity *= FFU_BE_Defs.stationCapacityMult;
				synthetics.capacity *= FFU_BE_Defs.stationCapacityMult;
				explosives.capacity *= FFU_BE_Defs.stationCapacityMult;
				exotics.capacity *= FFU_BE_Defs.stationCapacityMult;
				if (organics.available < organics.capacity / 4) organics.available += organics.capacity / 3;
				if (fuel.available < fuel.capacity / 4) fuel.available += fuel.capacity / 3;
				if (metals.available < metals.capacity / 4) metals.available += metals.capacity / 3;
				if (synthetics.available < synthetics.capacity / 4) synthetics.available += synthetics.capacity / 3;
				if (explosives.available < explosives.capacity / 4) explosives.available += explosives.capacity / 3;
				if (exotics.available < exotics.capacity / 4) exotics.available += exotics.capacity / 3;
			}
		}
	}
	public class patch_RandomizeShip : RandomizeShip {
		public extern void orig_Randomize(int seed);
		//Increased Resource Drop from Battles
		public void Randomize(int seed) {
			int sectorMult = Sector.Instance != null ? Sector.Instance.number : 1;
			lootOrganics.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootOrganics.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootFuel.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootFuel.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootMetals.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootMetals.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootSynthetics.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootSynthetics.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootExplosives.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootExplosives.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootExotics.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootExotics.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			lootCredits.minValue *= FFU_BE_Defs.enemyResourcesLootMinMult * sectorMult;
			lootCredits.maxValue *= FFU_BE_Defs.enemyResourcesLootMaxMult * sectorMult;
			orig_Randomize(seed);
		}
	}
	public class patch_WorldRules : WorldRules {
		//Alternative Fire Chance Levels
		public float GetFireChancePercent(ShootAtDamageDealer.FireChanceLevel level) {
			switch (level) {
				case ShootAtDamageDealer.FireChanceLevel.Low: return (float)Core.FireIgniteChance.High;
				case ShootAtDamageDealer.FireChanceLevel.Default: return (float)Core.FireIgniteChance.Medium;
				case ShootAtDamageDealer.FireChanceLevel.High: return (float)Core.FireIgniteChance.Low;
				default: return 0f;
			}
		}
	}
}

namespace RST.UI {
	public class patch_ResourceActionsPanel : ResourceActionsPanel {
		[MonoModIgnore] private ShipModule resPackPrefab;
		[MonoModIgnore] private PlayerResource GetPlayerResource(PlayerData pd) { return null; }
		//Consume Full Cost on Resource Pack From Action Panel
		private bool ResPackCraftCheck(out int resToPack, out ResourceValueGroup cost, out ResourceValueGroup packValue, out bool hasUsableStorage, out bool hasEnoughForPayingCraftingCost, out bool craftNotDisabled) {
			PlayerData me = PlayerDatas.Me;
			PlayerResource playerResource = GetPlayerResource(me);
			resToPack = 0;
			packValue = default;
			cost = WorldRules.Instance.resourcePackCraftCost;
			switch (type) {
				case ResourceType.Fuel:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.fuel - cost.fuel));
				packValue.fuel = resToPack;
				break;
				case ResourceType.Organics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.organics - cost.organics));
				packValue.organics = resToPack;
				break;
				case ResourceType.Explosives:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.explosives - cost.explosives));
				packValue.explosives = resToPack;
				break;
				case ResourceType.Exotics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.exotics - cost.exotics));
				packValue.exotics = resToPack;
				break;
				case ResourceType.Synthetics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.synthetics - cost.synthetics));
				packValue.synthetics = resToPack;
				break;
				case ResourceType.Metals:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.metals - cost.metals));
				packValue.metals = resToPack;
				break;
			}
			cost += packValue;
			hasEnoughForPayingCraftingCost = cost.CheckHasEnough(me, 1f);
			hasUsableStorage = !WorldRules.Impermanent.StorageDisabled && StoragePanel.HasRoom(Ownership.Owner.Me);
			craftNotDisabled = !WorldRules.Impermanent.moduleCraftDisabled;
			return hasUsableStorage & hasEnoughForPayingCraftingCost & craftNotDisabled;
		}
	}
	public class patch_PlayerPanel : PlayerPanel {
		private extern void orig_Update();
		//Spam Reduction Timers & Modified Interface
		private void Update() {
			FFU_BE_Mod_Backend.timePassedOrganics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedFuel += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedMetals += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedSynthetics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedExplosives += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedExotics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedCredits += Time.unscaledDeltaTime;
			if (FFU_BE_Mod_Backend.timePassedOrganics > 10000f) FFU_BE_Mod_Backend.timePassedOrganics = 50f;
			if (FFU_BE_Mod_Backend.timePassedFuel > 10000f) FFU_BE_Mod_Backend.timePassedFuel = 50f;
			if (FFU_BE_Mod_Backend.timePassedMetals > 10000f) FFU_BE_Mod_Backend.timePassedMetals = 50f;
			if (FFU_BE_Mod_Backend.timePassedSynthetics > 10000f) FFU_BE_Mod_Backend.timePassedSynthetics = 50f;
			if (FFU_BE_Mod_Backend.timePassedExplosives > 10000f) FFU_BE_Mod_Backend.timePassedExplosives = 50f;
			if (FFU_BE_Mod_Backend.timePassedExotics > 10000f) FFU_BE_Mod_Backend.timePassedExotics = 50f;
			if (FFU_BE_Mod_Backend.timePassedCredits > 10000f) FFU_BE_Mod_Backend.timePassedCredits = 50f;
			orig_Update();
			researchCreditsBonus.text = FFU_BE_Mod_Technology.GetCraftChanceText().Replace("MK-", string.Empty).Replace(": ", string.Empty).Replace("I", string.Empty).Replace("V", string.Empty).Replace("X", string.Empty);
			for (int i = 0; i < researchCreditsBonus.transform.childCount; i++) researchCreditsBonus.transform.GetChild(i).gameObject.SetActive(false);
		}
		//Update Research Pop-Up to Show Modified Data
		private static string BuildResearchCreditsBonusHover(int researchCreditsBonus) {
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 2 && Input.GetKeyDown(KeyCode.PageUp) && !Input.GetKeyDown(KeyCode.PageDown)) FFU_BE_Mod_Technology.RotateResearchListForward();
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 2 && !Input.GetKeyDown(KeyCode.PageUp) && Input.GetKeyDown(KeyCode.PageDown)) FFU_BE_Mod_Technology.RotateResearchListBackward();
			string currentEnergyEmission = "<b>Flagship Energy Emission</b>: " + string.Format("{0:0.#}", FFU_BE_Defs.energyEmission) + "m³" + "\n";
			string hostileAwarenessLevel = "<b>Local Forces Awareness Level</b>: " + FFU_BE_Mod_Discovery.GetHostileAwarnessLevel() + (FFU_BE_Defs.allStatProps ? " (" + string.Format("{0:0.##}", FFU_BE_Defs.distanceTraveledInPeace / FFU_BE_Mod_Discovery.GetCurrentScanFrequency() * 100f) + "%)" : "") + "\n";
			string hostileEnforcersStrength = "<b>Local Forces Military Strength</b>: " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel() + (FFU_BE_Defs.allStatProps ? " (" + string.Format("{0:0.##}", FFU_BE_Mod_Discovery.GetKilledFleetsCount() / FFU_BE_Mod_Discovery.GetTopFleetsTrigger() * 100f) + "%)" : "") + "\n";
			string tierResearchProgress = "<b>Research Progress</b>: " + FFU_BE_Mod_Technology.GetCraftChanceText() + (FFU_BE_Defs.allStatProps ? " (" + Mathf.RoundToInt(FFU_BE_Defs.researchProgress) + ")" : "") + "\n";
			string reverseEngineeringProgress = FFU_BE_Defs.unresearchedModuleIDs.ToList().Count == 0 ? "<b>Reverse Engineering</b>: (No Active Project)" : "<b>Reverse Engineering</b>: " +
				FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First()).displayName + " " +
				string.Format("{0:0}", FFU_BE_Defs.moduleResearchProgress / FFU_BE_Defs.moduleResearchGoal * 100f) + "%" + (FFU_BE_Defs.allStatProps ? " (" +
				string.Format("{0:0}", FFU_BE_Defs.moduleResearchProgress) + "/" + string.Format("{0:0}", FFU_BE_Defs.moduleResearchGoal) + ")" : "");
			string reverseEngineeringQueue = "";
			bool postfixShown = false;
			int totalQueueEntries = 0;
			int totalQueueEntriesMax = (int)((Screen.height - 500) / 35f);
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 1) {
				reverseEngineeringQueue = "\n" + "<b>Reverse Engineering Queue</b>:";
				foreach (int unresearchedModuleID in FFU_BE_Defs.unresearchedModuleIDs.ToList()) {
					if (unresearchedModuleID != FFU_BE_Defs.unresearchedModuleIDs.ToList().First() && totalQueueEntries < totalQueueEntriesMax)
						reverseEngineeringQueue += "\n" + " > " + FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == unresearchedModuleID).displayName;
					else if (!postfixShown && totalQueueEntries > (totalQueueEntriesMax - 1)) {
						reverseEngineeringQueue += "\n" + "<b>...and " + (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count - totalQueueEntriesMax) +
							" module" + (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count - totalQueueEntriesMax > 1 ? "s" : "") + " more in research queue...</b>";
						postfixShown = true;
					}
					totalQueueEntries++;
				}
			}
			return "<color=lime>" + currentEnergyEmission + hostileAwarenessLevel + hostileEnforcersStrength + tierResearchProgress + reverseEngineeringProgress + reverseEngineeringQueue + "</color>";
		}
		//Limit Interface Size and Reduce Text Spam
		private class ResourceBlock {
			[MonoModIgnore] public int resouceChangeSize;
			[MonoModIgnore] public float animDuration;
			[MonoModIgnore] public Color textChangingColor;
			[MonoModIgnore] public AnimationCurve changingAnim;
			[MonoModIgnore] public float risingTextSpeed;
			[MonoModIgnore] public Color barColor;
			[MonoModIgnore] private int lastValue;
			[MonoModIgnore] private int lastMaxValue;
			[MonoModIgnore] private float timer;
			[MonoModIgnore] public int LastValue;
			[MonoModIgnore] public int LastMaxValue;
			[MonoModIgnore] public ResourceBlock(PlayerPanel ui, Color? barColor = null) { }
			[MonoModIgnore] public bool Show(PlayerResource r, Text text, GameObject changeShowPos) { return false; }
			[MonoModIgnore] public bool Show(PlayerResource r, Text text, GameObject changeShowPos, int ifCurValueLowerThanThisThenMakeItRed) { return false; }
			[MonoModIgnore] public bool Show(int curValue, Text text, GameObject changeShowPos, List<string> changeReasons, string name) { return false; }
			[MonoModIgnore] public bool Show(int curValue, int maxValue, Text text, GameObject changeShowPos, Image bar, LayoutElement maxBar, Texture2D specter, string name) { return false; }
			[MonoModIgnore] public bool Show(int curValue, int maxValue, Text text, GameObject changeShowPos, string name) { return false; }
			private bool PrivateShow(int curValue, int maxValue, int ifCurValueLowerThanThisThenMakeItRed, Text text, GameObject changeShowPos, List<string> reasons, Image bar, LayoutElement maxBar, Texture2D specter, string name) {
				bool result = false;
				if (text != null) {
					if (lastValue != curValue || lastMaxValue != maxValue) {
						FireRaisingText(changeShowPos, curValue, lastValue, reasons, (!string.IsNullOrEmpty(name)) ? MonoBehaviourExtended.TT(name).ToLowerInvariant() : null);
						string valueText = (curValue < ifCurValueLowerThanThisThenMakeItRed) ? ("<color=red>" + curValue + "</color>") : curValue.ToString();
						text.text = (maxValue != int.MaxValue) ? (valueText + " / " + maxValue) : valueText;
						if (bar != null) bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (curValue * bar.sprite.rect.width > Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width) ? (Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width) : (curValue * bar.sprite.rect.width));
						if (maxBar != null) maxBar.preferredWidth = (maxValue * bar.sprite.rect.width > Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width) ? (Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width) : (maxValue * bar.sprite.rect.width);
						timer = 0f;
						lastValue = curValue;
						lastMaxValue = maxValue;
						result = true;
					}
					Color uiColor = VisualSettings.Instance.uiColor;
					text.color = Color.Lerp(uiColor, textChangingColor, changingAnim.Evaluate(timer / animDuration));
					if (bar != null && specter != null) {
						Color pixelBilinear = specter.GetPixelBilinear(curValue / (float)maxValue, 0.5f);
						bar.color = Color.Lerp(pixelBilinear, barColor, changingAnim.Evaluate(timer / animDuration));
					}
					timer += Time.unscaledDeltaTime;
				}
				return result;
			}
			private void FireRaisingText(GameObject posGO, int value, int lastValue, List<string> reasons, string name) {
				ResourceValueGroup pData = PlayerDatas.Me != null ? PlayerDatas.Me.Resources : ResourceValueGroup.Empty;
				switch (name) {
					case "organics":
					if (FFU_BE_Mod_Backend.timePassedOrganics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedOrganics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueOrganics;
						FFU_BE_Mod_Backend.lastValueOrganics = (int)pData.organics;
					} else return;
					break;
					case "fuel":
					if (FFU_BE_Mod_Backend.timePassedFuel >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedFuel = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueFuel;
						FFU_BE_Mod_Backend.lastValueFuel = (int)pData.fuel;
					} else return;
					break;
					case "metals":
					if (FFU_BE_Mod_Backend.timePassedMetals >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedMetals = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueMetals;
						FFU_BE_Mod_Backend.lastValueMetals = (int)pData.metals;
					} else return;
					break;
					case "synthetics":
					if (FFU_BE_Mod_Backend.timePassedSynthetics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedSynthetics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueSynthetics;
						FFU_BE_Mod_Backend.lastValueSynthetics = (int)pData.synthetics;
					} else return;
					break;
					case "explosives":
					if (FFU_BE_Mod_Backend.timePassedExplosives >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedExplosives = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueExplosives;
						FFU_BE_Mod_Backend.lastValueExplosives = (int)pData.explosives;
					} else return;
					break;
					case "exotics":
					if (FFU_BE_Mod_Backend.timePassedExotics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedExotics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueExotics;
						FFU_BE_Mod_Backend.lastValueExotics = (int)pData.exotics;
					} else return;
					break;
					case "credits":
					if (FFU_BE_Mod_Backend.timePassedCredits >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedCredits = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueCredits;
						FFU_BE_Mod_Backend.lastValueCredits = (int)pData.credits;
					} else return;
					break;
				}
				if (lastValue >= 0) {
					string text = "";
					if (reasons != null) {
						List<string> list = new List<string>();
						foreach (string reason in reasons) {
							string item = MonoBehaviourExtended.TT(reason);
							if (!list.Contains(item)) list.Add(item);
						}
						text = string.Join(", ", list.ToArray());
						reasons.Clear();
					}
					int num = value - lastValue;
					if (num != 0 && !string.IsNullOrEmpty(text)) {
						Vector2 dir = new Vector2(0f, 1f);
						string text2 = " <size=" + resouceChangeSize + ">" + num.ToString("+0;-0") + ((!string.IsNullOrEmpty(name)) ? (" " + name) : "") + " (" + text + ")</size>";
						RisingText risingText = RisingText.FireAndForget(posGO, Vector2.zero, text2, (num >= 0) ? Color.green : Color.red, RisingText.Space.UI, dir, true);
						risingText.lifetime = animDuration;
						risingText.speed = risingTextSpeed;
					}
				}
			}
		}
	}
	public class patch_ModuleActionsPanel : ModuleActionsPanel {
		private extern void orig_StoreModule();
		private extern void orig_ModuleOvercharge();
		private extern void orig_PowerToggleChanged(bool newValue);
		//Recalculate Ship's Signature on Storing Module
		private void StoreModule() {
			orig_StoreModule();
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Overcharging Module
		private void ModuleOvercharge() {
			orig_ModuleOvercharge();
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Powering Module
		private void PowerToggleChanged(bool newValue) {
			orig_PowerToggleChanged(newValue);
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
	}
	public class patch_StoragePanel : StoragePanel {
		[MonoModIgnore] private HoverableUI upgradeButtonHover;
		//Modified Max Storage Capacity Upgrade
		public void UpdateUpgradeButton(Ownership.Owner resourcesGoTo) {
			PlayerData playerData = PlayerDatas.Get(resourcesGoTo);
			ResourceValueGroup r = (playerData != null) ? playerData.Resources : ResourceValueGroup.Empty;
			WorldRules instance = WorldRules.Instance;
			StorageModule storageModule = GetStorageModule(resourcesGoTo, false);
			bool canIncrease = storageModule != null && storageModule.slotCount < FFU_BE_Defs.maxStorageCapacity;
			bool hasResources = instance.storageUpgradeCost.CheckHasEnough(r);
			if (!canIncrease) upgradeButtonHover.hoverText = MonoBehaviourExtended.TT("Maximum slot count reached");
			else if (!hasResources) upgradeButtonHover.hoverText = MonoBehaviourExtended.TT("Not enough resources for upgrading");
			else upgradeButtonHover.hoverText = "";
			upgradeButton.interactable = storageModule != null && canIncrease && hasResources;
		}
		//Modified Max Storage Capacity Upgrade
		public static void Upgrade() {
			PlayerData me = PlayerDatas.Me;
			StorageModule storageModule = GetStorageModule(Ownership.Owner.Me, false);
			if (me == null || storageModule == null) return;
			WorldRules instance = WorldRules.Instance;
			if (storageModule.slotCount < FFU_BE_Defs.maxStorageCapacity) {
				ResourceValueGroup storageUpgradeCost = WorldRules.Instance.storageUpgradeCost;
				if (storageUpgradeCost.ConsumeFrom(me, 1f, Localization.tt("storage upgrade"))) {
					FFU_BE_Defs.shipCurrentStorageCap = storageModule.slotCount + 1;
					storageModule.slotCount++;
				}
			}
		}
	}
}

namespace RST.PlaymakerAction {
	public class patch_ChoicePanel : ChoicePanel {
		private extern void orig_Start();
		//Increased Resource Numbers for Choices
		private void Start() {
			if (!FFU_BE_Defs.updatedChoices.Contains(GetHashCode())) {
				foreach (var choiceEntry in choiceText)
					if (Regex.Match(choiceEntry.Value, @"\d+").Success)
						foreach (string anchorWord in FFU_BE_Defs.choiceAnchorWords)
							if (Regex.Match(choiceEntry.Value, @"\d+ " + anchorWord).Success)
								foreach (var matchEntry in Regex.Matches(choiceEntry.Value, @"\d+ " + anchorWord))
									choiceEntry.Value = choiceEntry.Value.Replace(matchEntry.ToString(), (int.Parse(Regex.Match(matchEntry.ToString(), @"\d+").Value) * FFU_BE_Defs.resultNumbersMult).ToString() + " " + anchorWord);
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Choice Instance with Hash [" + GetHashCode() + "] was successfully modified.");
				FFU_BE_Defs.updatedChoices.Add(GetHashCode());
			}
			orig_Start();
		}
	}
	public class patch_ResultsPanel : ResultsPanel {
		[MonoModIgnore] private bool started;
		[MonoModIgnore] private PlayMakerFSM fsm;
		[MonoModIgnore] private AudioPlayWithFade.Ctx audioCtx;
		//Increased Resource Numbers for Results
		private void Start() {
			started = true;
			fsm = CreateIfNeeded.Do(UISkin.Instance.resultsPrefab);
			FsmVariables fsmVariables = fsm.FsmVariables;
			POI current = POI.Current;
			fsmVariables.GetFsmString("title").Value = ChoicePanel.GetTitle(base.Fsm, title);
			fsmVariables.GetFsmObject("picture").Value = Pool<Sprite>.TakeRandomItem(picturePool.Value as SpritePool, picture.Value as Sprite, current);
			string text = Localization.TT(Pool<string>.TakeRandomItem(textPool.Value as StringPool, text2, current));
			fsmVariables.GetFsmString("text").Value = ChoicePanel.MakeReplacements(text, replacements);
			fsmVariables.GetFsmBool("resources given").Value = resourcesGiven;
			PlayerData pd = PlayerDatas.Me;
			Ship flagship = pd.Flagship;
			if (flagship != null) {
				int psMaxHealth = flagship.MaxHealth;
				int psHealth = flagship.HealthFast(psMaxHealth);
				int psHealthNum = WorldRules.Impermanent.PlayerShipsTakeMaxHpDamage ? (psHealth + psMaxHealth) : psHealth;
				int psMaxHealthNum = WorldRules.Impermanent.PlayerShipsTakeMaxHpDamage ? (psMaxHealth * 2) : psMaxHealth;
				int psHealthChange = ParseIntExpr(Health.Value, () => psMaxHealth - psHealth);
				psHealthChange = (healthNoKill.Value && -psHealthChange >= psHealthNum) ? (-psHealthNum + 1) : (Mathf.Clamp(psHealthNum + psHealthChange, 0, psMaxHealthNum) - psHealthNum);
				bool value = -psHealthChange >= psHealthNum;
				fsmVariables.GetFsmInt("health").Value = psHealthChange;
				fsmVariables.GetFsmBool("dead by ship").Value = value;
			}
			ResourceValueGroup battleLoot = pd.battleLoot;
			int fTotal = pd.Fuel.Total;
			int oTotal = pd.Organics.Total;
			int eTotal = pd.Explosives.Total;
			int xTotal = pd.Exotics.Total;
			int sTotal = pd.Synthetics.Total;
			int mTotal = pd.Metals.Total;
			int fAmount = ParseIntExpr(Fuel.Value, () => pd.Fuel.SoftMax - fTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.fuel;
			int oAmount = ParseIntExpr(Organics.Value, () => pd.Organics.SoftMax - oTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.organics;
			int eAmount = ParseIntExpr(Explosives.Value, () => pd.Explosives.SoftMax - eTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.explosives;
			int xAmount = ParseIntExpr(Exotics.Value, () => pd.Exotics.SoftMax - xTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.exotics;
			int sAmount = ParseIntExpr(Synthetics.Value, () => pd.Synthetics.SoftMax - sTotal) + (int)battleLoot.synthetics;
			int mAmount = ParseIntExpr(Metals.Value, () => pd.Metals.SoftMax - mTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.metals;
			int cAmount = ParseIntExpr(Credits.Value, null) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.credits;
			if (cAmount >= 0 && addResearchCreditsBonus.Value) cAmount += WorldRules.Instance.scienceSkillEffects.EffectiveCreditsBonus(Ownership.Owner.Me);
			fsmVariables.GetFsmInt("fuel").Value = Mathf.Clamp(fTotal + fAmount, 0, int.MaxValue) - fTotal;
			fsmVariables.GetFsmInt("organics").Value = Mathf.Clamp(oTotal + oAmount, 0, int.MaxValue) - oTotal;
			fsmVariables.GetFsmInt("explosives").Value = Mathf.Clamp(eTotal + eAmount, 0, int.MaxValue) - eTotal;
			fsmVariables.GetFsmInt("exotics").Value = Mathf.Clamp(xTotal + xAmount, 0, int.MaxValue) - xTotal;
			fsmVariables.GetFsmInt("synthetics").Value = Mathf.Clamp(sTotal + sAmount, 0, int.MaxValue) - sTotal;
			fsmVariables.GetFsmInt("metals").Value = Mathf.Clamp(mTotal + mAmount, 0, int.MaxValue) - mTotal;
			fsmVariables.GetFsmInt("credits").Value = Mathf.Max(pd.Credits + cAmount, 0) - pd.Credits;
			int repAmount = ParseIntExpr(RepPoints.Value, null);
			fsmVariables.GetFsmInt("repPoints").Value = Mathf.Max(pd.RepPoints + repAmount, 0) - pd.RepPoints;
			bool deadByCrew = false;
			int crewHealth = ParseIntExpr(CrewHealth.Value, null);
			int crewHealthMax = ParseIntExpr(CrewMaxHealth.Value, null);
			if (crewHealth != 0 && crewHealthNoKill.Value) crewHealth *= FFU_BE_Defs.resultNumbersMult;
			int crewHealthCount = (crewHealth != 0 || crewHealthMax != 0) ? (string.IsNullOrEmpty(divideBetweenHowManyCrew.Value) ? 1000 : ParseIntExpr(divideBetweenHowManyCrew.Value, () => 1000)) : 0;
			if (crewHealth < 0 && !crewHealthNoKill.Value) {
				int crewHealthDist = 0;
				foreach (Crewmember cachedCrewmember in PerFrameCache.CachedCrewmembers)
					if (cachedCrewmember != null && UpdatePlayerData.CrewIsDeletable(cachedCrewmember) && cachedCrewmember.Ownership.GetOwner() == Ownership.Owner.Me)
						crewHealthDist += cachedCrewmember.Health;
				if (-crewHealth >= crewHealthDist) deadByCrew = true;
				if (crewHealthMax < 0) Debug.LogError("deadByCrew check can't be done if both crewMaxHealth<0 and crewHealth<0");
			}
			fsmVariables.GetFsmInt("crewHealth").Value = crewHealth;
			fsmVariables.GetFsmInt("crewHealthCrewCount").Value = crewHealthCount;
			fsmVariables.GetFsmBool("crewHealthNoKill").Value = crewHealthNoKill.Value;
			fsmVariables.GetFsmString("crewDeathMessage").Value = crewDeathMessage.IsNone ? "<default>" : crewDeathMessage.Value;
			fsmVariables.GetFsmInt("crewMaxHealth").Value = crewHealthMax;
			int crewCountNum = ParseIntExpr(CrewCount.Value, null);
			if (-crewCountNum >= pd.ControllableCrewCount) deadByCrew = true;
			fsmVariables.GetFsmBool("dead by crew").Value = deadByCrew;
			fsmVariables.GetFsmInt("crew").Value = crewCountNum;
			fsmVariables.GetFsmArray("crewmemberPool").CopyValues(crewmemberPool);
			fsmVariables.GetFsmString("crewNameOverride").Value = crewNameOverride.Value;
			fsmVariables.GetFsmString("crewDescriptionOverride").Value = crewDescriptionOverride.Value;
			int count = ParseIntExpr(ModuleCount.Value, null);
			foreach (ShipModule item in InstantiateFromPool.DoIt<ShipModule>(Array.ConvertAll(modulePool.Values, (object p) => (GameObject)p), modulePoolAllowDuplicates.Value, PlayerDatas.Instance?.transform, count)) {
				item.transform.position = new Vector3(10000f, 0f, 0f);
				item.Ownership.SetOwner(Ownership.Owner.Inherit);
			}
			if (InstantiateFromPool.DoIt<ShipModule>(Array.ConvertAll(modulePool.Values, (object p) => (GameObject)p), modulePoolAllowDuplicates.Value, PlayerDatas.Instance?.transform, count).Count > 0) PerFrameCache.InvalidateModuleCache();
			fsmVariables.GetFsmFloat("module dmg percent min").Value = moduleDmgPercentMin.Value;
			fsmVariables.GetFsmFloat("module dmg percent max").Value = moduleDmgPercentMax.Value;
			fsmVariables.GetFsmBool("dontDoLargeBg").Value = dontDoLargeBg.Value;
			fsmVariables.GetFsmBool("crewDidntDie").Value = crewDidntDie.Value;
			object[] array = fsmVariables.GetFsmArray("choiceTexts").Values = choiceTexts.stringValues;
			fsmVariables.GetFsmBool("tutorial mode").Value = noPopup.Value;
			fsmVariables.GetFsmString("reason to display").Value = reasonToDisplay.Value;
			audioCtx = AudioPlayWithFade.Enter(base.Fsm.GameObject, audioClip.Value as AudioClip, audioNoFade.Value);
		}
	}
	public class patch_PerksSelection : PerksSelection {
		public extern void orig_OnEnter();
		//Configurable Starting Fate
		public override void OnEnter() {
			firstRunFate.Value = FFU_BE_Defs.newStartingFateBonus;
			orig_OnEnter();
		}
	}
	public class patch_CrewOperatesModule : CrewOperatesModule {
		public extern void orig_OnEnter();
		public extern void orig_OnExit();
		[MonoModIgnore] private Crewmember crew;
		//Recalculate Ship's Signature on Crew's Entry
		public override void OnEnter() {
			orig_OnEnter();
			if (crew != null) if (crew.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Crew's Exit
		public override void OnExit() {
			orig_OnExit();
			if (crew != null) if (crew.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Defs.RecalculateEnergyEmission();
		}
	}
}