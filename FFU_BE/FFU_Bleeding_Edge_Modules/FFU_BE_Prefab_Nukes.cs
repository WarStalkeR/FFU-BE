using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Nukes {
		public static int SortModules(int moduleID) {
			int idx = 0;
			//Kinetic
			if (moduleID == 1012765355) return idx; idx++; //02 Decoy nuke launcher
			if (moduleID == 247153919) return idx; idx++; //07 Greentail nuke launcher
			if (moduleID == 1025580152) return idx; idx++; //02 Spideraa decoy nuke launcher
			if (moduleID == 1441404901) return idx; idx++; //07 Greentail nuke launcher 2
			if (moduleID == 2070090696) return idx; idx++; //Tiger Monolith nuke launcher
			if (moduleID == 1851270005) return idx; idx++; //Monolith nuke launcher
			//Energy
			if (moduleID == 92356131) return idx; idx++; //00 DIY decoy nuke launcher
			if (moduleID == 430038657) return idx; idx++; //00 DIY EMP nuke launcher
			if (moduleID == 1073969324) return idx; idx++; //00 DIY shieldbreaker nuke launcher
			if (moduleID == 1773946856) return idx; idx++; //16 EMP rat nuke launcher
			if (moduleID == 120056764) return idx; idx++; //Tiger EMP dual nuke launcher
			if (moduleID == 2106923011) return idx; idx++; //11 EMP nuke launcher
			//Thermal
			if (moduleID == 2146165248) return idx; idx++; //04 DIY fuel pack launcher
			if (moduleID == 507989399) return idx; idx++; //00 DIY Rat fireball nuke launcher
			if (moduleID == 949056369) return idx; idx++; //03 Barrel nuke launcher
			if (moduleID == 787880682) return idx; idx++; //09 Rat nuke launcher
			if (moduleID == 697717866) return idx; idx++; //13 Bullseye nuke launcher
			if (moduleID == 780823633) return idx; idx++; //04 Fueltank nuke launcher
			//Tactical
			if (moduleID == 533676501) return idx; idx++; //04 DIY explo pack launcher
			if (moduleID == 686511980) return idx; idx++; //08e thin speeder nuke launcher
			if (moduleID == 157230770) return idx; idx++; //06 Tiger nuke launcher
			if (moduleID == 997641622) return idx; idx++; //14 Red EB nuke launcher
			if (moduleID == 342953834) return idx; idx++; //08d Spearhead nuke launcher
			if (moduleID == 120466776) return idx; idx++; //Tiger 8x nuke launcher
			//Chemical
			if (moduleID == 1771248833) return idx; idx++; //04 DIY plastics launcher
			if (moduleID == 955652403) return idx; idx++; //07 DIY acid nuke launcher
			if (moduleID == 1178343825) return idx; idx++; //13 nanopellet nuke launcher
			if (moduleID == 475763260) return idx; idx++; //07 Weirdship Chem nuke launcher
			if (moduleID == 1711403825) return idx; idx++; //Tiger sharpnel nuke launcher
			if (moduleID == 22001514) return idx; idx++; //08c Green nuke launcher
			//Boarding
			if (moduleID == 2053889862) return idx; idx++; //07 DIY bionuke launcher
			if (moduleID == 141822690) return idx; idx++; //07 Weirdship Minibio nuke launcher
			if (moduleID == 1350933427) return idx; idx++; //99 maggot spawner launcher
			if (moduleID == 1043100994) return idx; idx++; //99 pirate spawner launcher 1
			if (moduleID == 381835966) return idx; idx++; //Tiger intruderbot nuke launcher
			//Strategic
			if (moduleID == 858424257) return idx; idx++; //04 DIY exotics nuke launcher
			if (moduleID == 1207909377) return idx; idx++; //06 DIY probe nuke launcher
			if (moduleID == 227136891) return idx; idx++; //08a Happy nuke launcher
			if (moduleID == 415755100) return idx; idx++; //08b Old nuke launcher
			if (moduleID == 1392399452) return idx; idx++; //10 White nuke launcher
			if (moduleID == 1558344950) return idx; idx++; //15 Black nuke launcher
			return idx + 100;
		}
		public static void UpdateNukeModule(ShipModule shipModule, bool initItemData) {
			string colorNukeKin = "add8e6";
			string colorNukeEnr = "0080ff";
			string colorNukeThr = "ff8040";
			string colorNukeTac = "ffff00";
			string colorNukeChm = "008000";
			string colorNukeBrd = "8060ff";
			string colorNukeStr = "ff0000";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			HomingMovement shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement = (HomingMovement)AccessTools.PropertyGetter(typeof(Projectile), "HomingMovement").Invoke(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, null);
			switch (shipModule.PrefabId) {
				case 1012765355: //02 Decoy nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Iron Harvest <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "Everything aside from engine is solid tungsten carbide alloy. Perfect as decoy due to immense durability. Impact can leave dents at ship's hull.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 15f, metals = 150f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 150;
				shipModule_maxHealth = 35;
				break;
				case 247153919: //07 Greentail nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Biotic Thorn <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "Semisolid bionic capital missile that uses reactive chemical reagent on impact to breach ship's hull and everything else in its way. Environmentally friendly.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 10f, metals = 100f, synthetics = 50f, organics = 300f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 40;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 3.0f;
				shipModule.Weapon.overrideProjectileHealth = 12;
				shipModule_maxHealth = 35;
				break;
				case 1025580152: //02 Spideraa decoy nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Hunter Killer <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "Mass-produced capital missile that concentrates and releases all destructive energy at one point on impact, that destroys everything in its direction.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 400f, synthetics = 75f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 80;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 3.0f;
				shipModule.Weapon.overrideProjectileHealth = 18;
				shipModule_maxHealth = 35;
				break;
				case 1441404901: //07 Greentail nuke launcher 2
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Biotic Spike <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "Exotic semisolid bionic capital missile that uses extremely corrosive exotic chemical reagent on impact to breach ship's hull and everything else in its way.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 200f, synthetics = 100f, organics = 400f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 15;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 15;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 120;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 3.0f;
				shipModule.Weapon.overrideProjectileHealth = 24;
				shipModule_maxHealth = 35;
				break;
				case 2070090696: //Tiger Monolith nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Bright Fury <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "Specialized capital missile made from ultra-hard and ultra-heavy material that utilizes experimental antimatter thrusters to accelerate indefinitely toward the target.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 750f, synthetics = 150f, exotics = 2f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 160;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 3.0f;
				shipModule.Weapon.overrideProjectileHealth = 30;
				shipModule_maxHealth = 35;
				break;
				case 1851270005: //Monolith nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.02f);
				shipModule.displayName = "Blackhammer <color=#" + colorNukeKin + "ff>Kinetic</color> Nuke";
				shipModule.description = "An unconventional capital missile that on near-impact accelerates to the speed of light to generate destructive immense kinetic energy in tandem in a single direction.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 1000f, synthetics = 200f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 25;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 25;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 200;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 3.0f;
				shipModule.Weapon.overrideProjectileHealth = 35;
				shipModule_maxHealth = 35;
				break;
				case 92356131: //00 DIY decoy nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Powerpack <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "Made from printed steel boiler filled with volatile electronic scrap to the brim. Extremely cheap and extremely fragile, but provides at least some form of electronic warfare.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 5f, metals = 25f, synthetics = 15f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 40;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 90;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 1;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 2;
				shipModule_maxHealth = 25;
				break;
				case 430038657: //00 DIY EMP nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Discharge <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "Manually assembled energy capital missile. Overloads shields and modules in the hit area. Fragile and may benefit from synced shots or decoys to distract enemy CIWS.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 10f, metals = 50f, synthetics = 30f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 60;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 180;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 2;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 3;
				shipModule_maxHealth = 25;
				break;
				case 1073969324: //00 DIY shieldbreaker nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Disruptor <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "This capital missile carries a strong energy emission payload that increases its shield overloading capability and effective EMP radius. May zap unprotected crew.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 100f, synthetics = 60f, exotics = 2f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 80;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 360;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 4;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 25;
				break;
				case 1773946856: //16 EMP rat nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Pulse Wave <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "An improved energy capital missile that releases a very strong disharmony pulse wave that overloads shields, disables modules and electrifies crew a little bit.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 200f, synthetics = 150f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 4.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 120;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 600;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 6;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 7;
				shipModule_maxHealth = 25;
				break;
				case 120056764: //Tiger EMP dual nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Dual Shock <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "Specialized energy capital missile that uses resonance EMP generator to release pulse wave that overloads shields, disables modules and seriously electrifies crew.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 400f, synthetics = 300f, exotics = 4f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 5.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 160;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 900;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 8;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 10;
				shipModule_maxHealth = 25;
				break;
				case 2106923011: //11 EMP nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.05f);
				shipModule.displayName = "Ion Storm <color=#" + colorNukeEnr + "ff>Energy</color> Nuke";
				shipModule.description = "Advanced energy capital missile that releases extremely strong electromagnetic pulse wave that overloads shields, disables modules and painfully electrifies crew.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 500f, synthetics = 450f, exotics = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 6.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 200;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 1250;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.2f;
				shipModule.Weapon.overrideProjectileHealth = 13;
				shipModule_maxHealth = 25;
				break;
				case 2146165248: //04 DIY fuel pack launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Firepack <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Thermal capital missile that was manually assembled from solidified starfuel, engines and crude armor. On impact effectively sets ship's interiors on fire.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 15f, synthetics = 15f, explosives = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 1.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 1;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 2;
				shipModule_maxHealth = 15;
				break;
				case 507989399: //00 DIY Rat fireball nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Fireball <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Improvised thermal capital missile that was made from various munitions and high pressure fuel tanks. Releases pressurized and self-igniting liquid on impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 20f, synthetics = 20f, explosives = 10f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 2;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 2;
				shipModule_maxHealth = 15;
				break;
				case 949056369: //03 Barrel nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Phosphate <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Old external fuel tank modified into thermal capital missile by welding in engine and additional armor. Contains a lot of self-igniting pressurized liquid that is released on impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 30f, synthetics = 30f, explosives = 20f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 3;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 3;
				shipModule_maxHealth = 15;
				break;
				case 787880682: //09 Rat nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Blazefire <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Thermal capital missile that contains specialized solid payload that self-ignites when leaves vacuum environment and comes into contact with other material or gases.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 375f, metals = 45f, synthetics = 45f, explosives = 30f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 4;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 4;
				shipModule_maxHealth = 15;
				break;
				case 697717866: //13 Bullseye nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Firestorm <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Improved thermal capital missile that uses highly radioactive and volatile liquid mixed with exotic materials that rise overall temperature of fires to the extreme levels.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 600f, metals = 60f, synthetics = 60f, explosives = 40f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 4.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 15;
				break;
				case 780823633: //04 Fueltank nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Hellfire <color=#" + colorNukeThr + "ff>Thermal</color> Nuke";
				shipModule.description = "Advanced thermal capital missile that uses extremely volatile payload of exotic origin that almost incinerates vacuum itself, when not contained in a specialized environment.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 75f, synthetics = 75f, explosives = 50f, exotics = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 6.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 6;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Low;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.7f;
				shipModule.Weapon.overrideProjectileHealth = 7;
				shipModule_maxHealth = 15;
				break;
				case 533676501: //04 DIY explo pack launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Explopack <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "A manually assembled tactical capital missile that does some external and internal damage to ship. Made form combined explosive packs with engines and crude armor.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 10f, metals = 50f, synthetics = 50f, explosives = 150f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 1.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 4;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 25;
				break;
				case 686511980: //08e thin speeder nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Stingray <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "Cheap and effective tactical capital missile that was designed centuries. Originally was used by a certain organization that fought off alien invasions since 1994.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 15f, metals = 100f, synthetics = 100f, explosives = 200f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 8;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 6;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 16;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 8;
				shipModule_maxHealth = 25;
				break;
				case 157230770: //06 Tiger nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Sub-Seismic <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "Originally a mining charge that was used for shattering colossal asteroids. Was found out that it is just as useful as tactical capital missile for shattering ship hulls.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 150f, synthetics = 150f, explosives = 300f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 8;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 10;
				shipModule_maxHealth = 25;
				break;
				case 997641622: //14 Red EB nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Commercial <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "Improved tactical capital missile that was developed for sake of profit and sold to anybody who can afford it. Self-assembly will result in breach of copyright agreements.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 200f, synthetics = 200f, explosives = 400f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 12;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 24;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 12;
				shipModule_maxHealth = 25;
				break;
				case 342953834: //08d Spearhead nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Avalanche <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "Advanced well-armored tactical capital missile that deals decent damage to interior and exterior of the ship, and releases self-igniting shrapnel that damages crew.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 250f, synthetics = 250f, explosives = 500f, exotics = 2f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 4.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 15;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 12;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 30;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 15;
				shipModule_maxHealth = 25;
				break;
				case 120466776: //Tiger 8x nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Cataclysm <color=#" + colorNukeTac + "ff>Tactical</color> Nuke";
				shipModule.description = "Experimental capital missile with cluster warhead filled with 8 sub-munition charges. While each sub-munition charge doesn't have much of an impact, sheer quantity easily makes up for it.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 325f, synthetics = 325f, explosives = 750f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 4;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.Default;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.Default;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 2.0f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 25;
				break;
				case 1771248833: //04 DIY plastics launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Synthpack <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "A manually assembled tactical capital missile that is used to poison and kill crewmembers of hostile ship. Made form combined synthetic packs with engines and crude armor.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 10f, metals = 25f, synthetics = 50f, explosives = 35f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 1;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 2;
				shipModule_maxHealth = 15;
				break;
				case 955652403: //07 DIY acid nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Corrosion <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "Chemical capital missiles that releases a splash of extremely corrosive and acidic liquid that melts any organics (such as crew) and light robotic alloy composites.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 50f, synthetics = 100f, explosives = 75f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 2.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 15;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 2;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 3;
				shipModule_maxHealth = 15;
				break;
				case 1178343825: //13 nanopellet nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Green Mist <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "This chemical capital missile releases a huge cloud of corrosive/acidic nanopellets on impact that causes severe damage to the crew and minor damage to everything else.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 50f, synthetics = 300f, explosives = 75f, exotics = 1f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 4;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 4;
				shipModule_maxHealth = 15;
				break;
				case 475763260: //07 Weirdship Chem nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Deathmite <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "Chemical capital missile of organic origin. Releases a pressurized, environmentally friendly, extremely corrosive liquid on impact that severely damages all crew.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 75f, synthetics = 500f, explosives = 100f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 4.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 25;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 6;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 15;
				break;
				case 1711403825: //Tiger sharpnel nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Acid Rain <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "Specialized capital missile that utilizes synthetic, very corrosive and acidic reagent, which is contained under the high pressure and released on capital missile impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 750f, explosives = 150f, exotics = 4f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 5.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 30;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 8;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 6;
				shipModule_maxHealth = 15;
				break;
				case 22001514: //08c Green nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.04f);
				shipModule.displayName = "Green Death <color=#" + colorNukeChm + "ff>Chemical</color> Nuke";
				shipModule.description = "Advanced chemical capital missile that contains extremely corrosive, acidic and exotic reagent under the highest pressure possible that is released on impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 125f, synthetics = 1000f, explosives = 175f, exotics = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 6.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 35;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.8f;
				shipModule.Weapon.overrideProjectileHealth = 7;
				shipModule_maxHealth = 15;
				break;
				case 2053889862: //07 DIY bionuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Micromite <color=#" + colorNukeBrd + "ff>Boarding</color> Nuke";
				shipModule.description = "Experimental capital missile that uses instant-hatching cocoons as payload. Contains small amount of active organic payload: aggressive lifeforms with limited lifespan.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 40f, synthetics = 40f, explosives = 20f, organics = 250f, exotics = 4f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 5;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.6f;
				shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount = 4;
				shipModule.Weapon.overrideProjectileHealth = 4;
				shipModule_maxHealth = 25;
				break;
				case 141822690: //07 Weirdship Minibio nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Deathspore <color=#" + colorNukeBrd + "ff>Boarding</color> Nuke";
				shipModule.description = "Semi-organic capital missile that has high capacity and suitable internal environment. Contains decent amount of active organic payload: aggressive lifeforms with limited lifespan.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 70f, synthetics = 70f, explosives = 35f, organics = 500f, exotics = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.6f;
				shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount = 8;
				shipModule.Weapon.overrideProjectileHealth = 8;
				shipModule_maxHealth = 25;
				break;
				case 1350933427: //99 maggot spawner launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Infestator <color=#" + colorNukeBrd + "ff>Boarding</color> Nuke";
				shipModule.description = "Capital missile of unknown origin, but has huge capacity and perfect internal environment. Contains huge amount of active organic payload: aggressive lifeforms with limited lifespan.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 100f, synthetics = 100f, explosives = 50f, organics = 750f, exotics = 6f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 15;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.6f;
				shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount = 12;
				shipModule.Weapon.overrideProjectileHealth = 12;
				shipModule_maxHealth = 25;
				break;
				case 1043100994: //99 pirate spawner launcher 1
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Ramshackle <color=#" + colorNukeBrd + "ff>Boarding</color> Nuke";
				shipModule.description = "Capital missile developed by pirate factions that especially fond of boarding enemy ships. Filled to brim with scrap-made berserk drones that are more then happy rip and tear everything.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 450f, synthetics = 450f, explosives = 75f, organics = 150f, exotics = 8f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.6f;
				shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount = 6;
				shipModule.Weapon.overrideProjectileHealth = 16;
				shipModule_maxHealth = 25;
				break;
				case 381835966: //Tiger intruderbot nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.03f);
				shipModule.displayName = "Apocalypse <color=#" + colorNukeBrd + "ff>Boarding</color> Nuke";
				shipModule.description = "Capital missile developed by Terran Federation. Densely packed with sturdy, but expendable industrial drones that were reconfigured with military grade software for boarding operations.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 750f, synthetics = 750f, explosives = 100f, organics = 200f, exotics = 10f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = true;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 0.50f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 0;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 25;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.None;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.None;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.6f;
				shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount = 6;
				shipModule.Weapon.overrideProjectileHealth = 20;
				shipModule_maxHealth = 25;
				break;
				case 858424257: //04 DIY exotics nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "Exopack <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "A makeshift strategic capital missiles that made from destabilized exotics combined with crude armor, engines and a small fuel tank. Damages hull and overloads modules on impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 20f, metals = 75f, synthetics = 75f, explosives = 200f, exotics = 3f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 24;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 160;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 16;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 8;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 24;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 5;
				shipModule_maxHealth = 25;
				break;
				case 1207909377: //06 DIY probe nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "Satellite <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "Improvised strategical capital missile that made by arming an old soviet probe with unstable reactor and packing it to brim with destabilized exotics for better effect.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 35f, metals = 100f, synthetics = 100f, explosives = 350f, exotics = 5f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 3.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 30;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 200;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 10;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 30;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 8;
				shipModule_maxHealth = 25;
				break;
				case 227136891: //08a Happy nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5, 6);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "Happy World <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "A civilian use strategic capital missile with a reduced payload. On impact damages exterior and interior of the ships, ignites objects, damages crew and releases EMP blast wave.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 150f, synthetics = 150f, explosives = 500f, exotics = 7f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 4.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 39;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 260;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 26;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 13;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 39;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 10;
				shipModule_maxHealth = 25;
				break;
				case 415755100: //08b Old nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7, 8);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "SS-18 Satan <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "Ancient strategic capital missile that dates back to 1974, but still printed and used even to this day for its high area of effect, damage capacity and released EMP wave.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 200f, synthetics = 200f, explosives = 750f, exotics = 10f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 5.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 48;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 320;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 32;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 16;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 48;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 10;
				shipModule_maxHealth = 25;
				break;
				case 1392399452: //10 White nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "White Death <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "Modern military-grade strategic capital missile that was developed not so long ago. Ignites objects, damages modules, crew and hull, and releases strong EMP wave on impact.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 250f, synthetics = 250f, explosives = 1000f, exotics = 20f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 6.5f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 60;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 400;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 40;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 20;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 60;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 12;
				shipModule_maxHealth = 25;
				break;
				case 1558344950: //15 Black nuke launcher
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				if (!FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Add(shipModule.PrefabId);
				if (!FFU_BE_Defs.moduleEmissionPrefabs.ContainsKey(shipModule.PrefabId)) FFU_BE_Defs.moduleEmissionPrefabs.Add(shipModule.PrefabId, 0.06f);
				shipModule.displayName = "Void Fire <color=#" + colorNukeStr + "ff>Strategic</color> Nuke";
				shipModule.description = "Experimental strategic capital missile that contains huge exotic payload that turns into overwhelming antimatter energy on impact with severe consequences for the target.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 375f, synthetics = 375f, explosives = 1500f, exotics = 50f };
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield = false;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius = 8.0f;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds = 75;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg = 500;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg = 50;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg = 25;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg = 75;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel = ShootAtDamageDealer.FireChanceLevel.High;
				shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel = ShootAtDamageDealer.CrewDmgLevel.High;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.turnSpeed = 10f;
				shipModule_Weapon_ProjectileOrBeamPrefab_HomingMovement.force = 1.9f;
				shipModule.Weapon.overrideProjectileHealth = 15;
				shipModule_maxHealth = 25;
				break;
				default:
				if (initItemData) Debug.LogWarning($"[NEW NUKE] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = $"(NUKE) {shipModule.displayName}";
				break;
			}
			(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed = 0.01f;
			shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect = true;
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth") = shipModule.Weapon.overrideProjectileHealth;
			AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "health") = shipModule.Weapon.overrideProjectileHealth;
			AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority") = 0;
			(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).displayName = shipModule.displayName;
			FFU_BE_Mod_Modules.UpdateCommonStatsCore(shipModule);
		}
	}
}