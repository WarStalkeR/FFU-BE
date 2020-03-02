#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
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
		//Force Misfire Damaged Weapon Module
		[MonoModReplace] public virtual void SetInitialCondition(WeaponModule sourceWeapon, GameObject targetGo, Vector2 targetPos, float exactTargetDistance, Shield shieldToIgnore) {
			if (exactTargetDistance <= 0f) exactTargetDistance = 100f;
			effectDone = false;
			this.sourceWeapon = sourceWeapon;
			float num = (sourceWeapon != null) ? sourceWeapon.CalculateHitSectorDepth(exactTargetDistance) : 0f;
			targetDistance = exactTargetDistance + RstRandom.Range(0f - num, num);
			if (sourceWeapon != null && sourceWeapon.Module != null && !sourceWeapon.Module.HasFullHealth)
				if (RstRandom.value <= FFU_BE_Defs.GetHealthEffect(sourceWeapon.Module, 0.5f)) targetDistance = 0f;
			this.shieldToIgnore = shieldToIgnore;
		}
		//Overload Shield Gens/Caps from Damage
		[MonoModReplace] protected void DoShieldHit(Shield shield) {
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
		[MonoModReplace] protected void DoHit(Collider2D[] hits, int hitCount, Vector2 hitPos) {
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
	public class patch_Projectile : Projectile {
		[MonoModIgnore] private float timer;
		[MonoModIgnore] private Vector2 sourcePosition;
		[MonoModIgnore] private Rigidbody2D Rigidbody2D => GetCachedComponent<Rigidbody2D>(true);
		[MonoModIgnore] private HomingMovement HomingMovement => GetCachedComponent<HomingMovement>(true);
		[MonoModIgnore] private bool DoEffect(Vector2 hitPos, Shield shield) { return false; }
		//Damaged Nukes Launched with Reduced HP and Detonated on Zero HP.
		[MonoModReplace] public void ApplyWeaponOverrides(WeaponModule w) {
			if (!(w == null)) {
				if (w.overridePointDefCanSeeThis) PointDefCanSeeThis = true;
				if (w.overrideProjectileHealth > 0) maxHealth = health = w.overrideProjectileHealth;
				if (w.Module != null) if (w.Module.type == ShipModule.Type.Weapon_Nuke) if (!w.Module.HasFullHealth) health = Mathf.RoundToInt(maxHealth * FFU_BE_Defs.GetHealthPercent(w.Module));
				if (health <= 0) DoEffect(gameObject.transform.position, null);
			}
		}
	}
	public class patch_RepairSkillEffects : RepairSkillEffects {
		//Speed Up Hull Repair Time
		[MonoModReplace] public float GetShipHpRepairTime(Crewmember c, bool considerAccelTime) {
			float timeMult = (considerAccelTime && PerFrameCache.IsGoodSituation) ? FFU_BE_Defs.shipHullRepairAcceleration : 1f;
			return FFU_BE_Defs.shipHullRepairTime * TimeMultiplier(c) / timeMult;
		}
		//Speed Up Module Repair Time
		[MonoModReplace] public float GetModuleHpRepairTime(Crewmember c, bool considerAccelTime) {
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
		[MonoModReplace] private void Start() {
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
		[MonoModReplace] public float GetFireChancePercent(ShootAtDamageDealer.FireChanceLevel level) {
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
		//Triggering SOS might empower Local Forces.
		[MonoModReplace] private void Update() {
			if (timer > chosenWaitTime) {
				PlayerFleet fleetInstance = PlayerFleet.Instance;
				Sector sectorInstance = Sector.Instance;
				if (fleetInstance != null && sectorInstance != null) {
					GameObject gameObject = GameObjectPool.TakeRandomPrefab<GameObject>(sectorInstance.sosPoiPrefabOrPool);
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
		//Makes Damaged Module Suitable for Operation
		[MonoModReplace] private static bool ModuleIsSuitableForOp(ShipModule m, ShipModule.Type expectType, Ownership.Owner expectOwner, bool requireFullHealth) {
			if (m != null && m.type == expectType) {
				if ((requireFullHealth && m.HasFullHealth) || !requireFullHealth)
					return !m.IsPacked && m.Ship != null && m.Ownership.GetOwner() == expectOwner && m.CurrentLocalOpsCount < m.operatorSpots.Length && m.EnoughResources;
				else if (FFU_BE_Defs.DamagedButWorking(m))
					return !m.IsPacked && m.Ship != null && m.Ownership.GetOwner() == expectOwner && m.CurrentLocalOpsCount < m.operatorSpots.Length && m.EnoughResources;
			}
			return false;
		}
		//Crew is Allowed to Operate Damaged Module
		[MonoModReplace] private bool CheckOperate() {
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
		//Operators will Repair Broken, Full Repair to Repairers
		[MonoModReplace] private bool CheckRepair(bool seeAllShip) {
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
		//Status Visualizer of Damaged Modules
		[MonoModReplace] private void UpdateData() {
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
		//Status Visualizers of Damaged Modules
		[MonoModReplace] private void UpdateData() {
			ShipModule module = Module;
			bool isAlive = module != null && !module.IsDead;
			if (mainGroup.activeSelf != isAlive) {
				mainGroup.SetActive(isAlive);
			}
			if (!isAlive) return;
			base.transform.rotation = Quaternion.identity;
			Collider2D collider2D = module.Collider2D;
			BoxCollider2D boxCollider2D = collider2D as BoxCollider2D;
			CircleCollider2D circleCollider2D = collider2D as CircleCollider2D;
			Vector2 healthBarSize = (boxCollider2D != null) ? boxCollider2D.size : ((circleCollider2D != null) ? new Vector2(circleCollider2D.radius * 2f, circleCollider2D.radius * 2f) : new Vector2(2f, 2f));
			bool isUnpacked = !module.IsPacked;
			if (healthBar.gameObject.activeSelf != isUnpacked) healthBar.gameObject.SetActive(isUnpacked);
			float healthPercent = 0f;
			if (isUnpacked) {
				Transform transform = healthBar.transform;
				transform.localPosition = new Vector3(0f, (0f - healthBarSize.y) * 0.5f, 0f);
				transform.localScale = healthBarSize;
				healthPercent = Mathf.Clamp01(1f - (module.Health + module.OnePointRepairProgress) / module.MaxHealth);
			}
			if (healthBar.size.y != healthPercent) healthBar.size = new Vector2(1f, healthPercent);
			Ownership.Owner owner = module.Ownership.GetOwner();
			bool isJammed = module.IsJammed;
			bool hasTimer = module.IsUnpacking || (!module.IsPacked && FFU_BE_Defs.DamagedButWorking(module) && (module.Timer != null || module.IsOverloaded));
			GameObject gameObject = loadingBarRenderer.transform.parent.gameObject;
			if (gameObject.activeSelf != hasTimer) gameObject.SetActive(hasTimer);
			float barPercent = 0f;
			if (hasTimer) {
				barPercent = module.IsOverloaded ? (module.overloadTimer.value / module.overloadTimeWhenCaused) : 
					(module.IsUnpacking ? (1f - module.UnpackTimeLeft / module.UnpackTime) : 
					((module.Timer != null) ? (1f - module.Timer.value / module.TimerInterval) : 0f));
				if (float.IsNaN(barPercent)) barPercent = 0f;
				VisualSettings vsInstance = VisualSettings.Instance;
				Color barColor = module.IsOverloaded ? vsInstance.overloadedBarColor : 
					(module.IsUnpacking ? vsInstance.unpackBarColor : 
					((barPercent >= 1f) ? vsInstance.loadingBarCompleteColor : 
					((module.type == ShipModule.Type.ShieldGen) ? vsInstance.shieldLoadingBarColor : 
					((module.type == ShipModule.Type.Weapon || module.type == ShipModule.Type.Weapon_Nuke || 
					module.type == ShipModule.Type.PointDefence) ? vsInstance.weaponLoadingBarColor : loadingBarDefaultColor))));
				if (loadingBarRenderer.color != barColor) loadingBarRenderer.color = barColor;
				CountdownTimer timer = module.Timer;
				float skillTimer = SkillEffects.Get(module.GetRequiredCrewSkillType())?.EffectiveSkillMultiplier(module, true) ?? 1f;
				if (module.type == ShipModule.Type.Weapon && module.Weapon.reloadIntervalTakesNoBonuses) skillTimer = 1f;
				loadingBarText.color = loadingBarRenderer.color;
				loadingBarText.text = module.IsOverloaded ? ((int)module.overloadTimer.value).ToString() : (module.IsUnpacking ? ((int)module.UnpackTimeLeft).ToString() : ((timer == null || timer.value <= 0f || timer.value >= module.TimerInterval) ? "" : ((int)(module.Timer.value * skillTimer)).ToString()));
				bool barHasText = !string.IsNullOrEmpty(loadingBarText.text);
				if (loadingBarText.transform.parent.gameObject.activeSelf != barHasText) loadingBarText.transform.parent.gameObject.SetActive(barHasText);
			} else loadingBarText.text = "";
			if (loadingBarRenderer.size.x != barPercent) loadingBarRenderer.size = new Vector2(barPercent, loadingBarRenderer.size.y);
			VisualizeByActivating(overloaded, !module.IsPacked && module.IsOverloaded);
			VisualizeByActivating(disabledByEnemy, !module.IsPacked && isJammed);
			VisualizeByActivating(unpacking, module.IsUnpacking);
			VisualizeByActivating(darken, !module.IsPacked && (!module.HasFullHealth || !module.IsPowered), healthBarSize * 1.1f);
			bool show = !module.IsPacked && !module.HasFullHealth;
			VisualizeByActivating(broken, show, healthBarSize);
			VisualizeByActivating(brokenUnscaled, show);
			float repairTime = 0f;
			bool isNotFullHealth = !module.IsPacked && !module.HasFullHealth;
			if (isNotFullHealth) {
				repairTime = module.CalculateRepairTime();
				isNotFullHealth = !float.IsInfinity(repairTime);
				beingRepaired.transform.localPosition = new Vector3(0.5f * healthBarSize.x, -0.5f * healthBarSize.y, 0f);
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
			VisualizeByActivating(leaking, !module.IsPacked && getCanLeakResource != null && getCanLeakResource.SomethingIsLeaking);
			bool wasCriticallyHit = !module.IsPacked && module.MaxHealthLostCount > 0;
			VisualizeByActivating(maxHealthLostCountGroup, wasCriticallyHit);
			if (wasCriticallyHit) {
				maxHealthLostCountWorld.size = new Vector2(module.MaxHealthLostCount * maxHealthLostCountWorld.size.y, maxHealthLostCountWorld.size.y);
				maxHealthLostCountQs.size = new Vector2(module.MaxHealthLostCount * maxHealthLostCountQs.size.y, maxHealthLostCountQs.size.y);
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
					Vector2 basePos = base.transform.position;
					Vector2 targetPos = weapon.TargetPos;
					Vector2 relRange = targetPos - basePos;
					aimSector.directionDeg = Mathf.Atan2(relRange.y, relRange.x) * 57.29578f;
					aimSector.angleDeg = weapon.CalculateAimAngle(targetPos);
					float magnitude = relRange.magnitude;
					float hitDepth = weapon.CalculateHitSectorDepth(magnitude);
					aimSector.closerRadius = magnitude - hitDepth;
					aimSector.fartherRadius = magnitude + hitDepth;
					aimSector.hasFocus = SelectionManager.Selection.Contains(module.gameObject);
				}
				if (aimSector.gameObject.activeSelf != isTargeted) aimSector.gameObject.SetActive(isTargeted);
			}
			CrewPanel cpInstance = CrewPanel.Instance;
			if (!(cpInstance != null)) return;
			bool shouldShowPowerPreview = cpInstance.GetShouldShowPowerPreview(out bool on, module);
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