﻿#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0169
#pragma warning disable CS0414
#pragma warning disable CS0114

using UnityEngine;
using System.Collections.Generic;
using RST.PlaymakerAction;
using FFU_Bleeding_Edge;
using MonoMod;
using RST.UI;

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
	public class patch_ShootAtDamageDealer : ShootAtDamageDealer {
		[MonoModIgnore] public WeaponModule SourceWeapon { get; private set; }
		[MonoModReplace] public virtual void SetInitialCondition(WeaponModule sourceWeapon, GameObject targetGo, Vector2 targetPos, float exactTargetDistance, Shield shieldToIgnore) {
		/// Force Misfire Damaged Weapon Module
			if (exactTargetDistance <= 0f) exactTargetDistance = 100f;
			effectDone = false;
			SourceWeapon = sourceWeapon;
			float num = (sourceWeapon != null) ? sourceWeapon.CalculateHitSectorDepth(exactTargetDistance) : 0f;
			targetDistance = exactTargetDistance + RstRandom.Range(0f - num, num);
			if (sourceWeapon != null && sourceWeapon.Module != null && !sourceWeapon.Module.HasFullHealth)
				if (RstRandom.value <= FFU_BE_Defs.GetHealthEffect(sourceWeapon.Module, 0.5f)) targetDistance = 0f;
			this.shieldToIgnore = shieldToIgnore;
		}
		[MonoModReplace] protected void DoShieldHit(Shield shield) {
		/// Overload Shield Gens/Caps from Damage
			if (shield == null) return;
			if (shield.ShieldPoints < damage.shieldDmg) {
				Ship ship = shield.Ship;
				List<ShipModule> list = (ship != null) ? ship.Modules.FindAll((ShipModule m) => m != null && m.type == ShipModule.Type.ShieldGen && m.TurnedOnAndIsWorking) : null;
				if (list != null && list.Count > 0) {
					RstUtil.Shuffle(list);
					list[0].TryCauseOverloadFromShield();
					for (int i = 1; i < list.Count; i++) if (RstRandom.value < WorldRules.Instance.moduleOverloadFromShieldChance) list[i].TryCauseOverload(Mathf.Clamp(damage.shieldDmg - shield.ShieldPoints, 20f, 120f));
				}
			}
			shield.PlayHitAnimation();
			shield.ShieldPoints = Mathf.Max(0, shield.ShieldPoints - damage.shieldDmg);
			GameObject gameObject = PrefabPool.TakeRandomPrefab<GameObject>(this.Effects.explosionOnShieldPoolRef.Prefab);
			if (gameObject != null) Explosion.InstantiateExplosion(gameObject, base.transform, target);
		}
		[MonoModReplace] protected void DoHit(Collider2D[] hits, int hitCount, Vector2 hitPos) {
		/// Improved Boarding/Spawner Nukes Mechanic
			Ownership.Owner hitOwner = Ownership.Owner.None;
			Collider2D collider2D = null;
			for (int i = 0; i < hitCount; i++) {
				Collider2D collider2D2 = hits[i];
				if (!(collider2D2 != null)) continue;
				(collider2D2.GetComponent(typeof(IHasHealth)) as IHasHealth)?.TakeDamage(damage, hitPos);
				if (hitOwner == Ownership.Owner.None) {
					Ship tempShip = collider2D2.GetComponent(typeof(IHasHealth)) as Ship;
					hitOwner = tempShip != null ? tempShip.Ownership.GetOwner() : Ownership.Owner.None;
					if (hitOwner == Ownership.Owner.Me) hitOwner = Ownership.Owner.Enemy;
					else if (hitOwner == Ownership.Owner.Enemy) hitOwner = Ownership.Owner.Me;
				}
				if (!collider2D2.CompareTag("IntViewShip")) continue;
				collider2D = collider2D2;
				if (target != null) {
					RisingText.FireAndForget(target.gameObject, (-damage.shipDmg).ToString(), Color.red, RisingText.Space.World);
					if (target.GetComponent(typeof(IHasDisplayNameLocalized)) is IHasDisplayNameLocalized hasDisplayNameLocalized) {
						StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, string.Format(MonoBehaviourExtended.TT("Hit {0}"), hasDisplayNameLocalized.DisplayNameLocalized));
					}
				}
			}
			GameObject gameObject = PrefabPool.TakeRandomPrefab<GameObject>(this.Effects.explosionPoolRef.Prefab);
			if (gameObject != null) Explosion.InstantiateExplosion(gameObject, base.transform, target);
			if (!(collider2D != null)) return;
			float num = 0.2f;
			if (hitOwner == Ownership.Owner.None) hitOwner = (Ownership != null) ? Ownership.GetOwner() : ((SourceWeapon != null) ? SourceWeapon.Module.Ownership.GetOwner() : Ownership.Owner.None);
			if (hitOwner == Ownership.Owner.None) return;
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
					bioPayloadSpawn.Ownership.SetOwner(hitOwner);
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
	public class patch_Projectile : Projectile {
		[MonoModIgnore] private float timer;
		[MonoModIgnore] private Vector2 sourcePosition;
		[MonoModIgnore] private Rigidbody2D Rigidbody2D => GetCachedComponent<Rigidbody2D>(true);
		[MonoModIgnore] private HomingMovement HomingMovement => GetCachedComponent<HomingMovement>(true);
		[MonoModIgnore] private bool DoEffect(Vector2 hitPos, Shield shield) { return false; }
		[MonoModReplace] public void ApplyWeaponOverrides(WeaponModule w) {
		/// Damaged Nukes Launched with Reduced HP and Detonated on Zero HP.
			if (!(w == null)) {
				if (w.overridePointDefCanSeeThis) PointDefCanSeeThis = true;
				if (w.overrideProjectileHealth > 0) maxHealth = health = w.overrideProjectileHealth;
				if (w.Module != null) if (w.Module.type == ShipModule.Type.Weapon_Nuke) if (!w.Module.HasFullHealth) health = Mathf.RoundToInt(maxHealth * FFU_BE_Defs.GetHealthPercent(w.Module));
				if (health <= 0) DoEffect(gameObject.transform.position, null);
			}
		}
	}
	public class patch_RepairSkillEffects : RepairSkillEffects {
		[MonoModReplace] public float GetShipHpRepairTime(Crewmember c, bool considerAccelTime) {
		/// Speed Up Hull Repair Time
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.shipHullRepairAcceleration : 1f;
			return FFU_BE_Defs.shipHullRepairTime * TimeMultiplier(c) / timeMult;
		}
		[MonoModReplace] public float GetModuleHpRepairTime(Crewmember c, bool considerAccelTime) {
		/// Speed Up Module Repair Time
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.moduleRepairAcceleration : 1f;
			return FFU_BE_Defs.moduleRepairTime * TimeMultiplier(c) / timeMult;
		}
		[MonoModReplace] public float GetDoorHpRepairTime(Crewmember c, bool considerAccelTime) {
		/// Speed Up Door Repair Time
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.doorRepairAcceleration : 1f;
			return FFU_BE_Defs.doorRepairTime * TimeMultiplier(c) / timeMult;
		}
		public ResourceValueGroup ModuleHpRepairCost {
		/// Decrease Module Repair Cost
			get { return new ResourceValueGroup { synthetics = FFU_BE_Defs.moduleRepairCost }; }
		}
		public ResourceValueGroup DoorHpRepairCost {
		/// Decrease Door Repair Cost
			get { return new ResourceValueGroup { synthetics = FFU_BE_Defs.doorRepairCost }; }
		}

	}
	public class patch_Shop : Shop {
		[MonoModIgnore] private bool wasLoaded;
		[MonoModReplace] private void Start() {
		/// Increased Station Resource Capacity
			if (!wasLoaded) {
				moduleCommissionFeeSeed = RstRandom.positiveIntValue;
				if (crewStation) {
					int crewPoolSize = crewPoolTakeMax;
					List<GameObject> crewPool = crewPoolRefs.ConvertAll((PrefabRef p) => p.Prefab);
					foreach (Crewmember shopMember in InstantiateFromPool.Do<Crewmember>(crewPool, crewPoolAllowDuplicates, buyableCrewContainer, (crewPoolSize <= 0) ? crewPool.Count : crewPoolSize)) {
						shopMember.Randomize();
						shopMember.BuyableAssignToStore(this);
					}
				}
				if (moduleStation) {
					int modulePoolSize = modulePoolTakeMax;
					List<GameObject> modulePool = modulePoolRefs.ConvertAll((PrefabRef p) => p.Prefab);
					foreach (ShipModule shopModule in InstantiateFromPool.Do<ShipModule>(modulePool, modulePoolAllowDuplicates, buyableModulesContainer, (modulePoolSize <= 0) ? modulePool.Count : modulePoolSize)) {
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
				if (organics.available < organics.capacity / 3) organics.available += organics.capacity / 2;
				if (fuel.available < fuel.capacity / 3) fuel.available += fuel.capacity / 2;
				if (metals.available < metals.capacity / 3) metals.available += metals.capacity / 2;
				if (synthetics.available < synthetics.capacity / 3) synthetics.available += synthetics.capacity / 2;
				if (explosives.available < explosives.capacity / 3) explosives.available += explosives.capacity / 2;
				if (exotics.available < exotics.capacity / 3) exotics.available += exotics.capacity / 2;
			} else {
				organics.capacity *= FFU_BE_Defs.stationCapacityMult;
				fuel.capacity *= FFU_BE_Defs.stationCapacityMult;
				metals.capacity *= FFU_BE_Defs.stationCapacityMult;
				synthetics.capacity *= FFU_BE_Defs.stationCapacityMult;
				explosives.capacity *= FFU_BE_Defs.stationCapacityMult;
				exotics.capacity *= FFU_BE_Defs.stationCapacityMult;
				if (organics.available < organics.capacity / 3) organics.available += organics.capacity / 2;
				if (fuel.available < fuel.capacity / 3) fuel.available += fuel.capacity / 2;
				if (metals.available < metals.capacity / 3) metals.available += metals.capacity / 2;
				if (synthetics.available < synthetics.capacity / 3) synthetics.available += synthetics.capacity / 2;
				if (explosives.available < explosives.capacity / 3) explosives.available += explosives.capacity / 2;
				if (exotics.available < exotics.capacity / 3) exotics.available += exotics.capacity / 2;
			}
		}
	}
	public class patch_RandomizeShip : RandomizeShip {
		public extern void orig_Randomize(int seed);
		public void Randomize(int seed) {
		/// Increased Resource Drop from Battles
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
		public class patch_ImpermanentRules : ImpermanentRules {
		/// Custom Difficulty Settings
			public bool PauseDisabled => FFU_BE_Defs.GetDifficultyAllowPause();
			public bool PlayerShipsTakeMaxHpDamage => FFU_BE_Defs.GetDifficultyAllowSurvive();
			public bool playerModulesTakeMaxHpDamage => FFU_BE_Defs.GetDifficultyAllowCrits();
		}
		[MonoModReplace] public float GetFireChancePercent(ShootAtDamageDealer.FireChanceLevel level) {
		/// Alternative Fire Chance Levels
			switch (level) {
				case ShootAtDamageDealer.FireChanceLevel.High: return (float)Core.FireIgniteChance.High;
				case ShootAtDamageDealer.FireChanceLevel.Default: return (float)Core.FireIgniteChance.Medium;
				case ShootAtDamageDealer.FireChanceLevel.Low: return (float)Core.FireIgniteChance.Low;
				default: return 0f;
			}
		}
	}
	public class patch_SOSBeacon : SOSBeacon {
		[MonoModIgnore] private float timer;
		[MonoModIgnore] private float chosenWaitTime;
		[MonoModReplace] private void Update() {
		/// Triggering SOS might empower Local Forces.
			if (timer > chosenWaitTime) {
				PlayerFleet fleetInstance = PlayerFleet.Instance;
				Sector sectorInstance = Sector.Instance;
				if (fleetInstance != null && sectorInstance != null) {
					GameObject gameObject = PrefabPool.TakeRandomPrefab<GameObject>(sectorInstance.sosPoiPoolRef.Prefab);
					if (gameObject != null && fleetInstance != null) {
						Vector2 a = fleetInstance.transform.position;
						Vector2 a2 = (UnityEngine.Random.value < 0.5f) ? new Vector2(0f, (UnityEngine.Random.value < 0.5f) ? 1 : (-1)) : new Vector2((UnityEngine.Random.value < 0.5f) ? 1 : (-1), 0f);
						Vector2 v = a + a2 * spawnDistanceFromPlayer;
						UnityEngine.Object.Instantiate(gameObject, v, Quaternion.identity, fleetInstance.transform.parent);
						PlayerData me = PlayerDatas.Me;
						if (RstRandom.value <= FFU_BE_Defs.empowerLocalForcesChance)
							FFU_BE_Defs.timesInterceptedByEnforcers[sectorInstance.number - 1]++;
						if (me != null) me.sosUseCount++;
					}
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
			if (RstShared.eventLockHolder == null) timer += Time.deltaTime;
		}
	}
	public class patch_CrewmemberAI : CrewmemberAI {
		[MonoModIgnore] private Crewmember Crewmember => GetCachedComponent<Crewmember>(true);
		[MonoModIgnore] private static bool RoleShouldRepair(Crewmember crew, out IRepairable rep) { rep = null; return false; }
		[MonoModIgnore] private static ShipModule.Type GetModuleTypeToOperate(Crewmember.Role role) { return ShipModule.Type.None; }
		[MonoModReplace] private static bool ModuleIsSuitableForOp(ShipModule m, ShipModule.Type expectType, Ownership.Owner expectOwner, bool requireFullHealth) {
		/// Makes Damaged Module Suitable for Operation
			if (m != null && m.type == expectType) {
				if ((requireFullHealth && m.HasFullHealth) || !requireFullHealth)
					return !m.IsPacked && m.Ship != null && m.Ownership.GetOwner() == expectOwner && m.CurrentLocalOpsCount < m.operatorSpots.Length && m.EnoughResources;
				else if (FFU_BE_Defs.DamagedButWorking(m))
					return !m.IsPacked && m.Ship != null && m.Ownership.GetOwner() == expectOwner && m.CurrentLocalOpsCount < m.operatorSpots.Length && m.EnoughResources;
			}
			return false;
		}
		[MonoModReplace] private bool CheckOperate() {
		/// Crew is Allowed to Operate Damaged Module
			Crewmember crewmember = Crewmember;
			ShipModule.Type moduleTypeToOperate = GetModuleTypeToOperate(crewmember.role);
			if (moduleTypeToOperate != 0) {
				ShipModule cModule = crewmember.TargetModule;
				if ((crewmember.CurrentCmd != Crewmember.Command.Operate && crewmember.CurrentCmd != Crewmember.Command.Repair) || cModule == null || cModule.type != moduleTypeToOperate) {
					ShipModule shipModule = null;
					Ownership.Owner crewOwner = crewmember.Ownership.GetOwner();
					if (crewmember.previousTargetGo != null && crewmember.previousTargetGo.CompareTag("Module")) {
						ShipModule component = crewmember.previousTargetGo.GetComponent<ShipModule>();
						if (ModuleIsSuitableForOp(component, moduleTypeToOperate, crewOwner, true)) shipModule = component;
					}
					if (shipModule == null) {
						List<ShipModule> suitableModuleList = new List<ShipModule>();
						foreach (ShipModule sModule in PerFrameCache.CachedModules) if (ModuleIsSuitableForOp(sModule, moduleTypeToOperate, crewOwner, false)) suitableModuleList.Add(sModule);
						shipModule = suitableModuleList.RandomElement();
					}
					if (shipModule != null) {
						if (shipModule.HasFullHealth) crewmember.Operate(shipModule, false, false);
						else if (crewmember.role == Crewmember.Role.RepairOfficer && shipModule.IsCrewRepairable && shipModule.IsRepairableNow) crewmember.Repair(shipModule, false, false);
						else if (FFU_BE_Defs.DamagedButWorking(shipModule)) crewmember.Operate(shipModule, false, false);
						else if (shipModule.IsCrewRepairable && shipModule.IsRepairableNow) crewmember.Repair(shipModule, false, false);
						else crewmember.Operate(shipModule, false, false);
					}
				}
			}
			ShipModule tModule = crewmember.TargetModule;
			if (tModule != null && tModule.type == moduleTypeToOperate) {
				if (crewmember.CurrentCmd != Crewmember.Command.Operate || !FFU_BE_Defs.DamagedButWorking(tModule)) {
					if (crewmember.CurrentCmd == Crewmember.Command.Repair) return tModule.NeedsRepairs;
					return false;
				}
				return true;
			}
			return false;
		}
		[MonoModReplace] private bool CheckRepair(bool seeAllShip) {
		/// Operators will Repair Broken, Full Repair to Repairers
			Crewmember crewmember = Crewmember;
			if (crewmember.CurrentCmd != Crewmember.Command.Repair) {
				IRepairable targetModule;
				if (!seeAllShip) {
					if (crewmember.CurrentCmd == Crewmember.Command.Operate) {
						targetModule = crewmember.TargetModule;
						if (targetModule as Object != null && targetModule.NeedsRepairs && targetModule.IsCrewRepairable && targetModule.IsRepairableNow) {
							if (targetModule as ShipModule != null)
								if (FFU_BE_Defs.DamagedButWorking(targetModule as ShipModule)) return true;
							if (crewmember.CanAcceptCommand(Crewmember.Command.Repair, targetModule.gameObject))
								crewmember.Repair(targetModule, false, false);
							else crewmember.Idle(true);
						}
					}
				} else if (RoleShouldRepair(crewmember, out targetModule) && crewmember.CanAcceptCommand(Crewmember.Command.Repair, targetModule.gameObject)) crewmember.Repair(targetModule, false, true);
			}
			return crewmember.CurrentCmd == Crewmember.Command.Repair;
		}
	}
	public class patch_ModuleStatusVisualizer : ModuleStatusVisualizer {
		[MonoModIgnore] private ShipModule Module => GetCachedComponentInParent<ShipModule>(true);
		[MonoModReplace] private void UpdateData() {
		/// Status Visualizer of Damaged Modules
			ShipModule module = Module;
			if (module == null) return;
			if (rootToRotate != null) rootToRotate.rotation = Quaternion.identity;
			bool flag = false;
			switch (visualizeIf) {
				case VisualizeIf.AllConditionsTrue:
				flag = (!broken || (broken && !FFU_BE_Defs.DamagedButWorking(module))) && 
					(!notEnoughPower || (notEnoughPower && !module.EnoughPower)) && 
					(!notEnoughAmmo || (notEnoughAmmo && !module.EnoughResources)) && 
					(!notEnoughOperators || (notEnoughOperators && !module.EnoughOps)) && 
					(!notAllOperatorsPresent || (notAllOperatorsPresent && !module.AllOpsPresent)) && 
					(!notEnoughRepairers || (notEnoughRepairers && !module.EnoughRepairers)) && 
					(!notPowered || (notPowered && !module.IsPowered));
				break;
				case VisualizeIf.AllConditionsFalse:
				flag = (!broken || (broken && FFU_BE_Defs.DamagedButWorking(module))) && 
					(!notEnoughPower || (notEnoughPower && module.EnoughPower)) && 
					(!notEnoughAmmo || (notEnoughAmmo && module.EnoughResources)) && 
					(!notEnoughOperators || (notEnoughOperators && module.EnoughOps)) && 
					(!notAllOperatorsPresent || (notAllOperatorsPresent && module.AllOpsPresent)) && 
					(!notEnoughRepairers || (notEnoughRepairers && module.EnoughRepairers)) && 
					(!notPowered || (notPowered && module.IsPowered));
				break;
				case VisualizeIf.AnyConditionTrue:
				flag = false;
				if (broken && FFU_BE_Defs.DamagedButWorking(module)) flag = true;
				if (notEnoughPower && module.EnoughPower) flag = true;
				if (notEnoughAmmo && module.EnoughResources) flag = true;
				if (notEnoughOperators && module.EnoughOps) flag = true;
				if (notAllOperatorsPresent && module.AllOpsPresent) flag = true;
				if (notEnoughRepairers && module.EnoughRepairers) flag = true;
				if (notPowered && module.IsPowered) flag = true;
				break;
				case VisualizeIf.AnyConditionFalse:
				flag = false;
				if (broken && !FFU_BE_Defs.DamagedButWorking(module)) flag = true;
				if (notEnoughPower && !module.EnoughPower) flag = true;
				if (notEnoughAmmo && !module.EnoughResources) flag = true;
				if (notEnoughOperators && !module.EnoughOps) flag = true;
				if (notAllOperatorsPresent && !module.AllOpsPresent) flag = true;
				if (notEnoughRepairers && !module.EnoughRepairers) flag = true;
				if (notPowered && !module.IsPowered) flag = true;
				break;
				default:
				throw new System.NotImplementedException(string.Concat("VisualizeIf=", visualizeIf, " not implemented"));
			}
			if (visulizingGO != null && visulizingGO.activeSelf != flag) visulizingGO.SetActive(flag);
			if (visualizingBeh != null && visualizingBeh.enabled != flag) visualizingBeh.enabled = flag;
		}
	}
	public class patch_ModuleStatusVisualizers : ModuleStatusVisualizers {
		[MonoModIgnore] private Color loadingBarDefaultColor;
		[MonoModIgnore] private ShipModule Module => GetCachedComponentInParent<ShipModule>(true);
		[MonoModReplace] private void UpdateData() {
		/// Status Visualizers of Damaged Modules
			ShipModule module = Module;
			bool isAlive = module != null && !module.IsDead;
			if (mainGroup.activeSelf != isAlive) mainGroup.SetActive(isAlive);
			if (!isAlive) return;
			base.transform.rotation = Quaternion.identity;
			Collider2D collider2D = module.Collider2D;
			BoxCollider2D boxCollider2D = collider2D as BoxCollider2D;
			CircleCollider2D circleCollider2D = collider2D as CircleCollider2D;
			Vector2 vector = (boxCollider2D != null) ? boxCollider2D.size : ((circleCollider2D != null) ? new Vector2(circleCollider2D.radius * 2f, circleCollider2D.radius * 2f) : new Vector2(2f, 2f));
			bool isUnpacked = !module.IsPacked;
			if (healthBar.gameObject.activeSelf != isUnpacked) healthBar.gameObject.SetActive(isUnpacked);
			float healthPercent = 0f;
			if (isUnpacked) {
				Transform transform = healthBar.transform;
				transform.localPosition = new Vector3(0f, (0f - vector.y) * 0.5f, 0f);
				transform.localScale = vector;
				healthPercent = Mathf.Clamp01(1f - ((float)module.Health + module.OnePointRepairProgress) / (float)module.MaxHealth);
			}
			if (healthBar.size.y != healthPercent) healthBar.size = new Vector2(1f, healthPercent);
			Ownership.Owner owner = module.Ownership.GetOwner();
			bool isJammed = module.IsJammed;
			bool hasTimer = module.IsUnpacking || (!module.IsPacked && FFU_BE_Defs.DamagedButWorking(module) && (module.Timer != null || module.IsOverloaded));
			GameObject gameObject = loadingBarRenderer.transform.parent.gameObject;
			if (gameObject.activeSelf != hasTimer) gameObject.SetActive(hasTimer);
			float barPercent = 0f;
			if (hasTimer) {
				barPercent = (module.IsOverloaded ? (module.overloadTimer.value / module.overloadTimeWhenCaused) : (module.IsUnpacking ? (1f - module.UnpackTimeLeft / module.UnpackTime) : ((module.Timer != null) ? (1f - module.Timer.value / module.TimerInterval) : 0f)));
				if (float.IsNaN(barPercent)) barPercent = 0f;
				VisualSettings instance = VisualSettings.Instance;
				Color color = module.IsOverloaded ? instance.overloadedBarColor : (module.IsUnpacking ? instance.unpackBarColor : ((barPercent >= 1f) ? instance.loadingBarCompleteColor : ((module.type == ShipModule.Type.ShieldGen) ? instance.shieldLoadingBarColor : ((module.type == ShipModule.Type.Weapon || module.type == ShipModule.Type.Weapon_Nuke || module.type == ShipModule.Type.PointDefence) ? instance.weaponLoadingBarColor : loadingBarDefaultColor))));
				if (loadingBarRenderer.color != color) loadingBarRenderer.color = color;
				CountdownTimer timer = module.Timer;
				float skillTimer = SkillEffects.Get(module.GetRequiredCrewSkillType())?.EffectiveSkillMultiplier(module, true) ?? 1f;
				if (module.type == ShipModule.Type.Weapon && module.Weapon.reloadIntervalTakesNoBonuses) skillTimer = 1f;
				loadingBarText.color = loadingBarRenderer.color;
				loadingBarText.text = (module.IsOverloaded ? ((int)module.overloadTimer.value).ToString() : (module.IsUnpacking ? ((int)module.UnpackTimeLeft).ToString() : ((timer == null || timer.value <= 0f || timer.value >= module.TimerInterval) ? "" : ((int)(module.Timer.value * skillTimer)).ToString())));
				bool barHasText = !string.IsNullOrEmpty(loadingBarText.text);
				if (loadingBarText.transform.parent.gameObject.activeSelf != barHasText) loadingBarText.transform.parent.gameObject.SetActive(barHasText);
			} else loadingBarText.text = "";
			if (loadingBarRenderer.size.x != barPercent) loadingBarRenderer.size = new Vector2(barPercent, loadingBarRenderer.size.y);
			VisualizeByActivating(overloaded, !module.IsPacked && module.IsOverloaded);
			VisualizeByActivating(disabledByEnemy, !module.IsPacked && isJammed);
			VisualizeByActivating(unpacking, module.IsUnpacking);
			VisualizeByActivating(darken, !module.IsPacked && (!module.HasFullHealth || !module.IsPowered), vector * 1.1f);
			if (darken.activeSelf && module.PrefabId == 1934368951) darken.transform.localPosition = new Vector2(2f, 0f);
			bool show = !module.IsPacked && !module.HasFullHealth;
			VisualizeByActivating(broken, show, vector);
			VisualizeByActivating(brokenUnscaled, show);
			float repairTime = 0f;
			bool isNotFullHealth = !module.IsPacked && !module.HasFullHealth;
			if (isNotFullHealth) {
				repairTime = module.CalculateRepairTime();
				isNotFullHealth = !float.IsInfinity(repairTime);
				beingRepaired.transform.localPosition = new Vector3(0.5f * vector.x, -0.5f * vector.y, 0f);
			}
			if (beingRepaired.activeSelf != isNotFullHealth) beingRepaired.SetActive(isNotFullHealth);
			repairedInText.text = ((int)repairTime).ToString();
			EnoughResourcesCheckResult enoughResources = module.EnoughResources;
			VisualizeByActivating(noFuel, !module.IsPacked && !enoughResources.fuel);
			VisualizeByActivating(noOrganics, !module.IsPacked && !enoughResources.organics);
			VisualizeByActivating(noExplosives, !module.IsPacked && !enoughResources.explosives);
			VisualizeByActivating(noExotics, !module.IsPacked && !enoughResources.exotics);
			VisualizeByActivating(noSynthetics, !module.IsPacked && !enoughResources.synthetics);
			VisualizeByActivating(noMetals, !module.IsPacked && !enoughResources.metals);
			VisualizeByActivating(noCredits, !module.IsPacked && !enoughResources.credits);
			VisualizeByActivating(noOperators, !module.IsPacked && module.turnedOn && module.HasFullHealth && !module.EnoughOps);
			VisualizeByActivating(remoteOperators, !module.IsPacked && module.IsRemotelyOperated);
			VisualizeByActivating(localOperators, !module.IsPacked && module.IsLocallyOperated);
			VisualizeByActivating(autoOperator, !module.IsPacked && module.type != ShipModule.Type.Container && module.type != ShipModule.Type.Storage && module.IsAutoOperated);
			VisualizeByActivating(noPower, !module.IsPacked && !module.EnoughPower);
			VisualizeByActivating(turnedOff.gameObject, !module.IsPacked && module.UsesTurnedOn && !module.turnedOn);
			VisualizeByActivating(powerOn, !module.IsPacked && module.EnoughPower && module.IsPowered);
			ICanLeakResource getCanLeakResource = module.GetCanLeakResource;
			bool isLeakingResources = !module.IsPacked && getCanLeakResource != null && getCanLeakResource.SomethingIsLeaking;
			VisualizeByActivating(leaking, isLeakingResources);
			HoverableUILeakWarning hoverableUILeakWarning = (!isLeakingResources) ? null : (HoverPanel.TopmostHoverable as HoverableUILeakWarning);
			VisualizeByActivating(leakingWarningHovered, hoverableUILeakWarning != null && module.type == ShipModule.Type.Container && hoverableUILeakWarning.Matches(module.Container) && module.Ownership.GetOwner() == Ownership.Owner.Me);
			bool wasCriticallyHit = !module.IsPacked && module.MaxHealthLostCount > 0;
			VisualizeByActivating(maxHealthLostCountGroup, wasCriticallyHit);
			if (wasCriticallyHit) {
				maxHealthLostCountWorld.size = new Vector2((float)module.MaxHealthLostCount * maxHealthLostCountWorld.size.y, maxHealthLostCountWorld.size.y);
				maxHealthLostCountQs.size = new Vector2((float)module.MaxHealthLostCount * maxHealthLostCountQs.size.y, maxHealthLostCountQs.size.y);
			}
			if (module.type == ShipModule.Type.PointDefence) {
				coverArea.radius = module.PointDefence.EffectiveCoverRadius;
				bool isInSelection = SelectionManager.Selection.Contains(module.gameObject);
				bool showPointDefRange = !module.IsPacked && isInSelection && module.IsWorking && owner == Ownership.Owner.Me;
				if (coverArea.gameObject.activeSelf != showPointDefRange) coverArea.gameObject.SetActive(showPointDefRange);
			}
			if (module.type == ShipModule.Type.Weapon || module.type == ShipModule.Type.Weapon_Nuke) {
				WeaponModule weapon = module.Weapon;
				bool isTargeted = !module.IsPacked && weapon.HasTarget;
				if (isTargeted && owner == Ownership.Owner.Me) {
					Vector2 b = base.transform.position;
					Vector2 targetPos = weapon.TargetPos;
					Vector2 vector2 = targetPos - b;
					aimSector.directionDeg = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
					aimSector.angleDeg = weapon.CalculateAimAngle(targetPos);
					float magnitude = vector2.magnitude;
					float num5 = weapon.CalculateHitSectorDepth(magnitude);
					aimSector.closerRadius = magnitude - num5;
					aimSector.fartherRadius = magnitude + num5;
					aimSector.hasFocus = SelectionManager.Selection.Contains(module.gameObject);
				}
				if (aimSector.gameObject.activeSelf != isTargeted) aimSector.gameObject.SetActive(isTargeted);
			}
			CrewPresetsPanel crewPresetsPanelInstance = CrewPresetsPanel.Instance;
			if (!(crewPresetsPanelInstance != null)) return;
			bool on;
			bool shouldShowPowerPreview = crewPresetsPanelInstance.GetShouldShowPowerPreview(out on, module);
			if (powerPresetPreview.activeSelf == shouldShowPowerPreview) return;
			if (shouldShowPowerPreview) {
				Color color2 = on ? new Color(0f, 1f, 0f) : new Color(1f, 0f, 0f);
				SpriteRenderer[] componentsInChildren = powerPresetPreview.GetComponentsInChildren<SpriteRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++) componentsInChildren[i].color = color2;
			}
			powerPresetPreview.SetActive(shouldShowPowerPreview);
		}
	}
}