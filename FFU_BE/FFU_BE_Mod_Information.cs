﻿#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0414
#pragma warning disable CS0436

using HarmonyLib;
using MonoMod;
using RST;
using UnityEngine;
using UnityEngine.UI;
using FFU_Bleeding_Edge;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Information {
		public static string GetSelectedWeaponExactData(HandWeapon handWeapon, bool showColors = true) {
			string weaponData = null;
			weaponData += handWeapon.DamageDealerPrefab.GetDamage(handWeapon).crewDmg > 0 ? $"{Core.TT("Crew Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.DamageDealerPrefab.GetDamage(handWeapon).crewDmg}\n" : null;
			weaponData += handWeapon.DamageDealerPrefab.GetDamage(handWeapon).doorDmg > 0 ? $"{Core.TT("Door Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.DamageDealerPrefab.GetDamage(handWeapon).doorDmg}\n" : null;
			weaponData += handWeapon.DamageDealerPrefab.GetDamage(handWeapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.DamageDealerPrefab.GetDamage(handWeapon).shipDmg}\n" : null;
			weaponData += handWeapon.DamageDealerPrefab.GetDamage(handWeapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.DamageDealerPrefab.GetDamage(handWeapon).moduleDmg}\n" : null;
			weaponData += handWeapon.DamageDealerPrefab.GetDamage(handWeapon).moduleDmgChance > 0 ? $"{Core.TT("Module Hit Chance")}: {handWeapon.DamageDealerPrefab.GetDamage(handWeapon).moduleDmgChance * 100f:0}%\n" : null;
			weaponData += handWeapon.farthestAttackDistance > 0 ? $"{Core.TT("Effective Range")}: {handWeapon.farthestAttackDistance}{Core.TT("m")}\n" : null;
			weaponData += handWeapon.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {handWeapon.reloadInterval}{Core.TT("s")}\n" : null;
			weaponData += handWeapon.shotInterval > 0 ? $"{Core.TT("Salvo Delay")}: {handWeapon.shotInterval}{Core.TT("s")}\n" : null;
			weaponData += handWeapon.accuracy > 0 ? $"{Core.TT("Accuracy")}: {handWeapon.accuracy} Δ{Core.TT("m")}\n" : null;
			if (!string.IsNullOrEmpty(weaponData)) weaponData = $"{(showColors ? "<color=lime>" : null)}{weaponData}{(showColors ? "</color>" : null)}{handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			else weaponData = handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			return weaponData;
		}
		public static string GetSelectedModuleExactData(ShipModule shipModule, bool isInst = true, bool debugInfo = false, bool showDesc = true, bool hideUnique = true, bool showColors = true) {
			string moduleData = null;
			string instanceText = null;
			if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += $"{Core.TT("Prefab Name")}: {shipModule.name}\n";
			moduleData += $"{Core.TT("Prefab ID")}: {shipModule.PrefabId}\n";
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(GetWeaponCategory(shipModule))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Weapon.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {shipModule.Weapon.reloadInterval:0.##}{Core.TT("s")}\n" : null;
				moduleData += shipModule.Weapon.preShootDelay > 0 ? $"{Core.TT("Ignition Time")}: {shipModule.Weapon.preShootDelay:0.##}{Core.TT("s")}\n" : null;
				moduleData += shipModule.Weapon.shotInterval > 0 ? $"{Core.TT("Salvo Delay")}: {shipModule.Weapon.shotInterval:0.##}{Core.TT("s")}\n" : null;
				moduleData += shipModule.Weapon.accuracy > 0 ? $"{Core.TT("Accuracy")}: {shipModule.Weapon.accuracy:0} Δ{Core.TT("m")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? $"{Core.TT("Damage Radius")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f:0.##}{Core.TT("m")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? $"{Core.TT("Ignores Shields")}: {Core.TT("Yes")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? $"{Core.TT("Never Deflects")}: {Core.TT("Yes")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? $"{Core.TT("Shield Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? $"{Core.TT("Crew Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? $"{Core.TT("Crew Hit Chance")}: {GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel)}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? $"{Core.TT("Fire Ignite Chance")}: {GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel)}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? $"{Core.TT("EMP Effect")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds}{Core.TT("s")}\n" : null;
				moduleData += !shipModule.Weapon.resourcesPerShot.IsEmpty ? $"{Core.TT("Resources Per Salvo")}:\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Weapon.resourcesPerShot.credits:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Weapon.resourcesPerShot.organics:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Weapon.resourcesPerShot.fuel:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Weapon.resourcesPerShot.metals:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Weapon.resourcesPerShot.synthetics:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Weapon.resourcesPerShot.explosives:0}\n" : null;
				moduleData += shipModule.Weapon.resourcesPerShot.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Weapon.resourcesPerShot.exotics:0}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Damage Dealer")}: {Core.TT("Projectile")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Projectile Identifier")}: {shipModule.Weapon.ProjectileOrBeamPrefab.name}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Projectile Health")}: {(shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth"))} {Core.TT("HP")}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Projectile Velocity")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed}00{Core.TT("m")}/{Core.TT("s")}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Point Defense Detection")}: {(shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis"))}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Point Defense Priority")}: {AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Deflection Angle")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectAngleRandom}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Deflection Distance (Min)")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMin}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Deflection Distance (Max)")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMax}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Expiration Time")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).selfDestructTime}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $"{Core.TT("Damage Dealer")}: {Core.TT("Beam")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $" > {Core.TT("Beam Identifier")}: {shipModule.Weapon.ProjectileOrBeamPrefab.name}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $" > {Core.TT("Beam Duration")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Beam).duration}{Core.TT("s")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $" > {Core.TT("Beam Health")}: {AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $" > {Core.TT("Beam Deflection")}: {AccessTools.FieldRefAccess<Beam, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Beam, "doDeflect")}\n" : null;
				break;
				case ShipModule.Type.Weapon_Nuke:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(GetNukeCategory(shipModule))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? $"{Core.TT("Damage Radius")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f:0.##}{Core.TT("m")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? $"{Core.TT("Ignores Shields")}: {Core.TT("Yes")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? $"{Core.TT("Never Deflects")}: {Core.TT("Yes")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? $"{Core.TT("Shield Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? $"{Core.TT("Crew Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : null)}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? $"{Core.TT("Crew Hit Chance")}: {GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel)}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? $"{Core.TT("Fire Ignite Chance")}: {GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel)}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? $"{Core.TT("EMP Effect")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds}{Core.TT("s")}\n" : null;
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? $"{Core.TT("Boarding Payload")}: {FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 2f:0} ~ {FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 5f:0} {Core.TT("Units")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Capital Missile Identifier")}: {shipModule.Weapon.ProjectileOrBeamPrefab.name}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Capital Missile Health")}: {(shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth"))} {Core.TT("HP")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += shipModule.Weapon.accuracy > 0 ? $"{Core.TT("Capital Missile Accuracy")}: {shipModule.Weapon.accuracy}\n" : null;
				try { moduleData += $"{Core.TT("Missile Acceleration")}: {((HomingMovement)AccessTools.PropertyGetter(typeof(Projectile), "HomingMovement").Invoke(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, null)).force * 10f} {Core.TT("m")}/{Core.TT("s")}²\n"; } catch { }
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Point Defense Detection")}: {(shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis"))}\n" : null;
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Point Defense Priority")}: {AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Deflection Angle")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectAngleRandom}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Deflection Distance (Min)")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMin}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Deflection Distance (Max)")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMax}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Expiration Time")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).selfDestructTime}\n" : null;
				break;
				case ShipModule.Type.PointDefence:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Close-In Weapon System")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.PointDefence.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {shipModule.PointDefence.reloadInterval:0.##}{Core.TT("s")}\n" : null;
				moduleData += shipModule.PointDefence.coverRadius > 0 ? $"{Core.TT("Cover Radius")}: {shipModule.PointDefence.coverRadius * 10f:0.##}{Core.TT("m")}\n" : null;
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += $"{Core.TT("Interceptor Identifier")}: {shipModule.PointDefence.ProjectileOrBeamPrefab.name}\n";
				moduleData += shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg > 0 ? $"{Core.TT("Interception Damage")}: {shipModule.PointDefence.ProjectileOrBeamPrefab.projectileDmg}\n" : null;
				moduleData += shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime > 0 ? $"{Core.TT("Interception Delay")}: {shipModule.PointDefence.ProjectileOrBeamPrefab.lifetime:0.##}{Core.TT("s")}\n" : null;
				moduleData += !shipModule.PointDefence.resourcesPerShot.IsEmpty ? $"{Core.TT("Resources Per Shot")}:\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.PointDefence.resourcesPerShot.credits:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.PointDefence.resourcesPerShot.organics:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.PointDefence.resourcesPerShot.fuel:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.PointDefence.resourcesPerShot.metals:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.PointDefence.resourcesPerShot.synthetics:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.PointDefence.resourcesPerShot.explosives:0}\n" : null;
				moduleData += shipModule.PointDefence.resourcesPerShot.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.PointDefence.resourcesPerShot.exotics:0}\n" : null;
				break;
				case ShipModule.Type.Bridge:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Command Bridge")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Bridge Operators")}: {shipModule.OperatorSpots.Length}\n" : null;
				break;
				case ShipModule.Type.Engine:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Sub-Light Engine")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += !shipModule.Engine.ConsumedPerDistance.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Engine.ConsumedPerDistance.credits * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Engine.ConsumedPerDistance.organics * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Engine.ConsumedPerDistance.fuel * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Engine.ConsumedPerDistance.metals * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Engine.ConsumedPerDistance.synthetics * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Engine.ConsumedPerDistance.explosives * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Engine.ConsumedPerDistance.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Engine.ConsumedPerDistance.exotics * 100:0}/100{Core.TT("ru")}\n" : null;
				break;
				case ShipModule.Type.Warp:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Warp Drive")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Warp.reloadInterval > 0 ? $"{Core.TT("Jump Drive Recharge")}: {shipModule.Warp.reloadInterval}{Core.TT("s")}\n" : null;
				moduleData += shipModule.Warp.activationFuel > 0 ? $"{Core.TT("Jump Fuel Consumption")}: {shipModule.Warp.activationFuel}\n" : null;
				break;
				case ShipModule.Type.Reactor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Energy Reactor")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Reactor.powerCapacity > 0 ? $"{Core.TT("Power Production")}: {shipModule.Reactor.powerCapacity} {Core.TT("GW/h")}\n" : null;
				moduleData += shipModule.Reactor.overchargePowerCapacityAdd > 0 ? $"{Core.TT("Overcharge Power Boost")}: +{shipModule.Reactor.overchargePowerCapacityAdd} {Core.TT("GW/h")}\n" : null;
				moduleData += shipModule.overchargeSeconds > 0 ? $"{Core.TT("Overcharge Time")}: {shipModule.overchargeSeconds}{Core.TT("s")}\n" : null;
				moduleData += !shipModule.Reactor.ConsumedPerDistance.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Reactor.ConsumedPerDistance.credits * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Reactor.ConsumedPerDistance.organics * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Reactor.ConsumedPerDistance.fuel * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Reactor.ConsumedPerDistance.metals * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Reactor.ConsumedPerDistance.synthetics * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Reactor.ConsumedPerDistance.explosives * 100:0}/100{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Reactor.ConsumedPerDistance.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Reactor.ConsumedPerDistance.exotics * 100:0}/100{Core.TT("ru")}\n" : null;
				break;
				case ShipModule.Type.Container:
				ContainerModule refCont = shipModule.Container;
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Storage Container")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += refCont.MaxOrganics > 0 || refCont.MaxFuel > 0 || refCont.MaxMetals > 0 || refCont.MaxSynthetics > 0 || refCont.MaxExplosives > 0 || refCont.MaxExotics > 0 ? $"{Core.TT("Storage Capacity")}:\n" : null;
				moduleData += shipModule.Container.MaxOrganics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Container.MaxOrganics:0}\n" : null;
				moduleData += shipModule.Container.MaxFuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Container.MaxFuel:0}\n" : null;
				moduleData += shipModule.Container.MaxMetals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Container.MaxMetals:0}\n" : null;
				moduleData += shipModule.Container.MaxSynthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Container.MaxSynthetics:0}\n" : null;
				moduleData += shipModule.Container.MaxExplosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Container.MaxExplosives:0}\n" : null;
				moduleData += shipModule.Container.MaxExotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Container.MaxExotics:0}\n" : null;
				moduleData += refCont.organicsCanLeak || refCont.fuelCanLeak || refCont.metalsCanLeak || refCont.syntheticsCanLeak || refCont.explosivesCanLeak || refCont.exoticsCanLeak ? $"{Core.TT("Leak Vulnerability")}:\n" : null;
				moduleData += shipModule.Container.organicsCanLeak ? $" > {Core.TT("Organics")}\n" : null;
				moduleData += shipModule.Container.fuelCanLeak ? $" > {Core.TT("Starfuel")}\n" : null;
				moduleData += shipModule.Container.metalsCanLeak ? $" > {Core.TT("Metals")}\n" : null;
				moduleData += shipModule.Container.syntheticsCanLeak ? $" > {Core.TT("Synthetics")}\n" : null;
				moduleData += shipModule.Container.explosivesCanLeak ? $" > {Core.TT("Explosives")}\n" : null;
				moduleData += shipModule.Container.exoticsCanLeak ? $" > {Core.TT("Exotics")}\n" : null;
				break;
				case ShipModule.Type.Integrity:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Integrity Armor")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.ShieldGen:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT((shipModule.ShieldGen.reloadInterval > 0 ? "Shield Generator" : "Shield Capacitor"))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.ShieldGen.reloadInterval > 0 ? $"{Core.TT("Shield Regeneration")}: {Core.TT("SP")}/{shipModule.ShieldGen.reloadInterval}{Core.TT("s")}\n" : null;
				moduleData += shipModule.ShieldGen.maxShieldAdd > 0 ? $"{Core.TT("Shield Capacity")}: {shipModule.ShieldGen.maxShieldAdd} {Core.TT("SP")}\n" : null;
				break;
				case ShipModule.Type.Sensor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Sensor Array")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Sensor.sectorRadarRange > 0 ? $"{Core.TT("Sector Radar Range")}: {shipModule.Sensor.sectorRadarRange}{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Sensor.starmapRadarRange > 0 ? $"{Core.TT("Starmap Radar Range")}: {shipModule.Sensor.starmapRadarRange}{Core.TT("ru")}\n" : null;
				break;
				case ShipModule.Type.StealthDecryptor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Stealth Generator")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.PassiveECM:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Countermeasure Array")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				string mType = shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Restoration Bay" :
					!shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Drone Repair Bay" :
					shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && !shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Crew Medical Bay" : 
					"Unidentified Health Bay";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(mType)}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Service Capacity")}: {shipModule.OperatorSpots.Length}\n" : null;
				moduleData += shipModule.Medbay.secondsPerHp > 0 ? $"{Core.TT("Restoration Speed")}: {Core.TT("HP")}/{shipModule.Medbay.secondsPerHp}{Core.TT("s")}\n" : null;
				moduleData += !shipModule.Medbay.resourcesPerHp.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Medbay.resourcesPerHp.credits:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Medbay.resourcesPerHp.organics:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Medbay.resourcesPerHp.fuel:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Medbay.resourcesPerHp.metals:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Medbay.resourcesPerHp.synthetics:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Medbay.resourcesPerHp.explosives:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.resourcesPerHp.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Medbay.resourcesPerHp.exotics:0}/{Core.TT("HP")}\n" : null;
				moduleData += shipModule.Medbay.acceptCrewTypes.Length > 0 ? $"{Core.TT("Serviced Crew Types")}:\n" : null;
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) ? $" > {Core.TT("Crewmembers")}\n" : null;
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? $" > {Core.TT("Drones")}\n" : null;
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Pet) ? $" > {Core.TT("Pets")}\n" : null;
				break;
				case ShipModule.Type.Cryosleep:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT((shipModule.Cryosleep.genDreamCredits ? "Cryodream Bay" : "Cryosleep Bay"))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Available Cryopods")}: {shipModule.OperatorSpots.Length}\n" : null;
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Crew Food Consumption")}: {Core.TT("Disabled")}\n" : null;
				moduleData += shipModule.Cryosleep.healOneCrewHp ? $"{Core.TT("Health Recovery Distance")}: {shipModule.Cryosleep.healOneCrewHpDistance.minValue}{Core.TT("ru")} ~ {shipModule.Cryosleep.healOneCrewHpDistance.maxValue}{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Cryosleep.genDreamCredits ? $"{Core.TT("Cryodream Record Distance")}: {shipModule.Cryosleep.genDreamCreditsDistance.minValue}{Core.TT("ru")} ~ {shipModule.Cryosleep.genDreamCreditsDistance.maxValue}{Core.TT("ru")}\n" : null;
				moduleData += shipModule.Cryosleep.genDreamCredits ? $"{Core.TT("Credits Per Cryodream")}: {shipModule.Cryosleep.creditsPerDream.minValue} ~ {shipModule.Cryosleep.creditsPerDream.maxValue}\n" : null;
				break;
				case ShipModule.Type.ResearchLab:
				ResearchModule rLab = shipModule.Research;
				ResourceValueGroup laboratoryOutput = isInst ? rLab.ProducedPerDistance * 100 : rLab.producedPerSkillPoint;
				float researchSpeed = FFU_BE_Defs.GetResearchFromRVG(laboratoryOutput) * FFU_BE_Defs.tierResearchSpeedMult;
				float reversingSpeed = FFU_BE_Defs.GetReverseFromRVG(laboratoryOutput) * FFU_BE_Defs.moduleResearchSpeedMult;
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Research Laboratory")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Available Workstations")}: {shipModule.OperatorSpots.Length}\n" : null;
				moduleData += researchSpeed > 0 || reversingSpeed > 0 ? $"{Core.TT("Laboratory Effects")}:\n" : null;
				moduleData += researchSpeed > 0 ? $" > {Core.TT("Research Progress")}: {researchSpeed * 100f:0.0##}/100{Core.TT("ru")}\n" : null;
				moduleData += reversingSpeed > 0 ? $" > {Core.TT("Reverse Engineering")}: {reversingSpeed * 100f:0.0##}/100{Core.TT("ru")}\n" : null;
				moduleData += !laboratoryOutput.IsEmpty ? $"{Core.TT("Effective Production")}:\n" : null;
				moduleData += laboratoryOutput.credits > 0 ? $" > {Core.TT("Credits")}: {laboratoryOutput.credits:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.organics > 0 ? $" > {Core.TT("Organics")}: {laboratoryOutput.organics:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.fuel > 0 ? $" > {Core.TT("Starfuel")}: {laboratoryOutput.fuel:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.metals > 0 ? $" > {Core.TT("Metals")}: {laboratoryOutput.metals:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {laboratoryOutput.synthetics:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.explosives > 0 ? $" > {Core.TT("Explosives")}: {laboratoryOutput.explosives:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += laboratoryOutput.exotics > 0 ? $" > {Core.TT("Exotics")}: {laboratoryOutput.exotics:0.0}/100{Core.TT("ru")}\n" : null;
				break;
				case ShipModule.Type.Garden:
				GardenModule rGreen = shipModule.GardenModule;
				ResourceValueGroup greenhouseOutput = isInst ? rGreen.ProducedPerDistance * 100 : rGreen.producedPerSkillPoint;
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Greenhouse Facility")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Available Workplaces")}: {shipModule.OperatorSpots.Length}\n" : null;
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Crew Food Consumption")}: {Core.TT("Disabled")}\n" : null;
				moduleData += !greenhouseOutput.IsEmpty ? $"{Core.TT("Effective Production")}:\n" : null;
				moduleData += greenhouseOutput.credits > 0 ? $" > {Core.TT("Credits")}: {greenhouseOutput.credits:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.organics > 0 ? $" > {Core.TT("Organics")}: {greenhouseOutput.organics:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.fuel > 0 ? $" > {Core.TT("Starfuel")}: {greenhouseOutput.fuel:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.metals > 0 ? $" > {Core.TT("Metals")}: {greenhouseOutput.metals:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {greenhouseOutput.synthetics:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.explosives > 0 ? $" > {Core.TT("Explosives")}: {greenhouseOutput.explosives:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += greenhouseOutput.exotics > 0 ? $" > {Core.TT("Exotics")}: {greenhouseOutput.exotics:0.0}/100{Core.TT("ru")}\n" : null;
				break;
				case ShipModule.Type.MaterialsConverter:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Industrial Facility")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				MaterialsConverterModule refConv = (shipModule as patch_ShipModule).MaterialsConverter;
				moduleData += $"Facility Full Warm-Up Time: {refConv.maxWarmUpPoints}s\n";
				moduleData += $"Facility Initial Warm-Up Time: {refConv.maxWarmUpPoints - refConv.baseWarmUpPoints}s\n";
				moduleData += $"Facility Base Efficiency: {refConv.baseEfficiency * 100:0.0}%\n";
				moduleData += $"Facility Efficiency Dissipation: {100f / (refConv.maxWarmUpPoints / refConv.warmUpDissipation):0.####}%/s\n";
				int availableRecipes = Mathf.Min(refConv.produceRecipes.Length, refConv.consumeRecipes.Length);
				if (availableRecipes > 0) {
					float mVal = isInst ? refConv.currentEfficiency : 1f;
					moduleData += availableRecipes > 0 ? $"{Core.TT("Available Recipes")}:\n" : null;
					for (int recipeNum = 0; recipeNum < availableRecipes; recipeNum++) {
						if (refConv.produceRecipes[recipeNum].organics > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].organics * mVal:0.#}x {Core.TT("Organics")}: ";
						else if (refConv.produceRecipes[recipeNum].fuel > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].fuel * mVal:0.#}x {Core.TT("Starfuel")}: ";
						else if (refConv.produceRecipes[recipeNum].metals > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].metals * mVal:0.#}x {Core.TT("Metals")}: ";
						else if (refConv.produceRecipes[recipeNum].synthetics > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].synthetics * mVal:0.#}x {Core.TT("Synthetics")}: ";
						else if (refConv.produceRecipes[recipeNum].explosives > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].explosives * mVal:0.#}x {Core.TT("Explosives")}: ";
						else if (refConv.produceRecipes[recipeNum].exotics > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].exotics * mVal:0.#}x {Core.TT("Exotics")}: ";
						else if (refConv.produceRecipes[recipeNum].credits > 0) moduleData += $" > {refConv.produceRecipes[recipeNum].credits * mVal:0.#}x {Core.TT("Credits")}: ";
						string recipeCost = "";
						if (refConv.consumeRecipes[recipeNum].organics > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].organics}-O";
						if (refConv.consumeRecipes[recipeNum].fuel > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].fuel}-F";
						if (refConv.consumeRecipes[recipeNum].metals > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].metals}-M";
						if (refConv.consumeRecipes[recipeNum].synthetics > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].synthetics}-S";
						if (refConv.consumeRecipes[recipeNum].explosives > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].explosives}-X";
						if (refConv.consumeRecipes[recipeNum].exotics > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].exotics}-E";
						if (refConv.consumeRecipes[recipeNum].credits > 0) recipeCost += $"{(!string.IsNullOrEmpty(recipeCost) ? ", " : null)}{refConv.consumeRecipes[recipeNum].credits}-C";
						moduleData += $"{recipeCost}\n";
					}
				}
				break;
				case ShipModule.Type.Fighter:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Fighter Bay")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.Decoy:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Decoy Module")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.ResourcePack:
				moduleData += $"{Core.TT("Type")}: {Core.TT("Resource Package")}\n";
				break;
				case ShipModule.Type.Storage:
				moduleData += $"{Core.TT("Type")}: {Core.TT("Modular Storage")}\n";
				break;
				default:
				string defCat = GetDefaultCategory(shipModule);
				instanceText = isInst && defCat != "Artifact" ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(defCat)}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				if (defCat.Contains("Cache")) {
					switch (GetCacheType(shipModule)) {
						case "Mechanical Upgrades":
						moduleData += $"{Core.TT("Available Upgrade Sets")}: {GetCacheSets(shipModule)}\n";
						moduleData += $"{Core.TT("Health Increase Per Set")}: {GetCacheHPIncrease(shipModule)}\n";
						moduleData += $"{Core.TT("Health Increase Limit")}: {GetCacheHPLimit(shipModule)}\n";
						break;
						case "Biological Implants":
						moduleData += $"{Core.TT("Available Implant Sets")}: {GetCacheSets(shipModule)}\n";
						moduleData += $"{Core.TT("Health Increase Per Set")}: {GetCacheHPIncrease(shipModule)}\n";
						moduleData += $"{Core.TT("Health Increase Limit")}: {GetCacheHPLimit(shipModule)}\n";
						break;
						case "CQC Class Weapons":
						case "Kinetic Type Weapons":
						case "Laser Type Weapons":
						case "Energy Type Weapons":
						case "Backup Class Weapons":
						case "Tactical Class Weapons":
						case "Assault Class Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {GetCacheSets(shipModule)}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n > {string.Join("\n > ", GetCacheWeapons(shipModule))}\n";
						break;
					}
				}
				break;
			}
			moduleData += shipModule.starmapStealthDetectionLevelMax > 0 ? $"{Core.TT("Stealth Detection Level")}: {Core.TT(GetStealthDetectionText(shipModule.starmapStealthDetectionLevelMax))}\n" : null;
			moduleData += shipModule.shipEvasionPercentAdd != 0 ? $"{Core.TT("Evasion Modifier")}: {(shipModule.shipEvasionPercentAdd > 0 ? "+" : null)}{shipModule.shipEvasionPercentAdd} °/{Core.TT("min.")}\n" : null;
			if (shipModule.type == ShipModule.Type.Engine) moduleData += shipModule.Engine.overchargeEvasionAdd > 0 && shipModule.shipEvasionPercentAdd > 0 ? $"{Core.TT("Evasion Overcharge")}: +{shipModule.Engine.overchargeEvasionAdd} °/{Core.TT("min.")}" + "\n" : null;
			moduleData += shipModule.shipAccuracyPercentAdd != 0 ? $"{Core.TT("Accuracy Modifier")}: {(shipModule.shipAccuracyPercentAdd > 0 ? "+" : null)}{shipModule.shipAccuracyPercentAdd}% Δ{Core.TT("m")}\n" : null;
			moduleData += shipModule.asteroidDeflectionPercentAdd != 0 ? $"{Core.TT("Asteroid Deflection")}: {(shipModule.asteroidDeflectionPercentAdd > 0 ? "+" : null)}{shipModule.asteroidDeflectionPercentAdd}%\n" : null;
			moduleData += shipModule.starmapSpeedAdd != 0 ? $"{Core.TT(null)}Interstellar Speed: {(shipModule.starmapSpeedAdd > 0 ? "+" : null)}{shipModule.starmapSpeedAdd:0.0} {Core.TT("ru")}/{Core.TT("s")}\n" : null;
			moduleData += shipModule.maxHealthAdd != 0 ? $"{Core.TT("Ship Armor Modifier")}: {(shipModule.maxHealthAdd > 0 ? "+" : null)}{shipModule.maxHealthAdd} {Core.TT("HP")}\n" : null;
			moduleData += shipModule.maxShieldAdd != 0 ? $"{Core.TT("Ship Shields Modifier")}: {(shipModule.maxShieldAdd > 0 ? "+" : null)}{shipModule.maxShieldAdd} {Core.TT("SP")}\n" : null;
			moduleData += shipModule.PowerConsumed > 0 ? $"{Core.TT("Power Consumption")}: {shipModule.PowerConsumed} {Core.TT("GW/h")}\n" : null;
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargePowerNeed > 0 ? $"{Core.TT("Overcharge Power Draw")}: {(shipModule.overchargePowerNeed / (float)shipModule.PowerConsumed + 1f) * 100f:0}%\n" : null;
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargeSeconds > 0 ? $"{Core.TT("Overcharge Time")}: {shipModule.overchargeSeconds}{Core.TT("s")}\n" : null;
			if (isInst && (shipModule.turnedOn || !shipModule.UsesTurnedOn) && FFU_BE_Defs.ModuleEmitsEnergy(shipModule)) moduleData += $"{Core.TT("Energy Emission")}: {FFU_BE_Defs.GetModuleEnergyEmission(shipModule):0.#}{Core.TT("m")}³\n";
			else if (!isInst && FFU_BE_Defs.ModuleEmitsEnergy(shipModule)) moduleData += $"{Core.TT("Energy Emission")}: {FFU_BE_Defs.GetModuleEmissionValues(shipModule)}\n";
			SelfCombustible shipModule_selfCombustion = shipModule.GetCachedComponent<SelfCombustible>(true);
			if (shipModule_selfCombustion != null) moduleData += shipModule_selfCombustion.chance > 0 ? $"{Core.TT("Malfunction Chance")}: {shipModule_selfCombustion.chance * 100:0.###}%\n" : null;
			moduleData += shipModule.MaxHealth > 0 ? $"{Core.TT("Module Durability")}: {shipModule.MaxHealth} {Core.TT("HP")}\n" : null;
			if (!isInst) moduleData += FFU_BE_Defs.IsAllowedModuleCategory(shipModule) ? $"{Core.TT("Crafting Proficiency")}: {FFU_BE_Defs.GetModuleCraftingProficiency(shipModule) * 100f:0.#}%\n" : null;
			moduleData += shipModule.costCreditsInShop > 0 ? $"{(isInst ? Core.TT("Market Price") : Core.TT("Base Price"))}: ${shipModule.costCreditsInShop}" : $"{(isInst ? Core.TT("Market Price") : Core.TT("Base Price"))}: {Core.TT("N/A")}";
			if (!isInst && showDesc) return $"{(showColors ? "<color=lime>" : null)}{moduleData}{(showColors ? "</color>" : null)}\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			else return $"{(showColors ? "<color=lime>" : null)}{moduleData}{(showColors ? "</color>" : null)}";
		}
		public static string GetCraftableModuleDescription(ShipModule shipModule) {
			return GetSelectedModuleExactData(shipModule, false);
		}
		public static string GetModuleGenText(ShipModule shipModule) {
			if (shipModule.name.Contains("MK-X")) return "10th";
			else if (shipModule.name.Contains("MK-IX")) return "9th";
			else if (shipModule.name.Contains("MK-VIII")) return "8th";
			else if (shipModule.name.Contains("MK-VII")) return "7th";
			else if (shipModule.name.Contains("MK-VI")) return "6th";
			else if (shipModule.name.Contains("MK-V")) return "5th";
			else if (shipModule.name.Contains("MK-IV")) return "4th";
			else if (shipModule.name.Contains("MK-III")) return "3rd";
			else if (shipModule.name.Contains("MK-II")) return "2nd";
			else if (shipModule.name.Contains("MK-I")) return "1st";
			else return "1st";
		}
		public static string GetModuleModText(ShipModule shipModule) {
			Core.BonusMod moduleMod = FFU_BE_Mod_Technology.GetModuleModifier(shipModule);
			switch (moduleMod) {
				case Core.BonusMod.None: return "None";
				case Core.BonusMod.Sustained: return "Sustained";
				case Core.BonusMod.Unstable: return "Unstable";
				case Core.BonusMod.Reinforced: return "Reinforced";
				case Core.BonusMod.Fragile: return "Fragile";
				case Core.BonusMod.Efficient: return "Efficient";
				case Core.BonusMod.Inefficient: return "Inefficient";
				case Core.BonusMod.Precise: return "Precise";
				case Core.BonusMod.Inhibited: return "Inhibited";
				case Core.BonusMod.Rapid: return "Rapid";
				case Core.BonusMod.Disrupted: return "Disrupted";
				case Core.BonusMod.Enhanced: return "Enhanced";
				case Core.BonusMod.Deficient: return "Deficient";
				case Core.BonusMod.Durable: return "Durable";
				case Core.BonusMod.Brittle: return "Brittle";
				case Core.BonusMod.Persistent: return "Persistent";
				case Core.BonusMod.Volatile: return "Volatile";
				default: return "None";
			}
		}
		public static string GetWeaponCategory(ShipModule shipModule) {
			if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Launcher].Contains(shipModule.PrefabId)) return "Rocket Launcher";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Autocannon].Contains(shipModule.PrefabId)) return "Autocannon";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Howitzer].Contains(shipModule.PrefabId)) return "Howitzer";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Railgun].Contains(shipModule.PrefabId)) return "Railgun";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Railcannon].Contains(shipModule.PrefabId)) return "Railcannon";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Laser].Contains(shipModule.PrefabId)) return "Laser Emitter";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Beamer].Contains(shipModule.PrefabId)) return "Beam Emitter";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.HeatRay].Contains(shipModule.PrefabId)) return "Heat Ray Projector";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Disruptor].Contains(shipModule.PrefabId)) return "Energy Disruptor";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.Radiator].Contains(shipModule.PrefabId)) return "Radiation Accelerator";
			else if (FFU_BE_Defs.weaponTypeIDs[Core.WeaponType.ExoticRay].Contains(shipModule.PrefabId)) return "Exotic Disintegrator";
			else return "Starship Weapon";
		}
		public static string GetNukeCategory(ShipModule shipModule) {
			if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Kinetic].Contains(shipModule.PrefabId)) return "Kinetic Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Energy].Contains(shipModule.PrefabId)) return "Energy Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Thermal].Contains(shipModule.PrefabId)) return "Thermal Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Tactical].Contains(shipModule.PrefabId)) return "Tactical Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Chemical].Contains(shipModule.PrefabId)) return "Chemical Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Boarding].Contains(shipModule.PrefabId)) return "Boarding Ordnance";
			else if (FFU_BE_Defs.nukeTypeIDs[Core.NukeType.Strategic].Contains(shipModule.PrefabId)) return "Strategic Ordnance";
			else return "Capital Ordnance";
		}
		public static string GetDefaultCategory(ShipModule shipModule) {
			if (FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Weapons].Contains(shipModule.PrefabId)) return "Weapons Cache";
			else if (FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Implants].Contains(shipModule.PrefabId)) return "Implants Cache";
			else if (FFU_BE_Defs.cacheTypeIDs[Core.CacheType.Upgrades].Contains(shipModule.PrefabId)) return "Upgrades Cache";
			else return "Artifact";
		}
		public static string GetCacheType(ShipModule shipModule) {
			if (!(shipModule != null)) return null;
			switch (shipModule.PrefabId) {
				case 685017033: return "Mechanical Upgrades";
				case 957508477: return "Biological Implants";
				case 1745395900: return "CQC Class Weapons";
				case 179311957: return "Kinetic Type Weapons";
				case 760711671: return "Laser Type Weapons";
				case 656277331: return "Energy Type Weapons";
				case 760711667: return "Backup Class Weapons";
				case 1279608160: return "Tactical Class Weapons";
				case 1316302015: return "Assault Class Weapons";
				default: return null;
			}
		}
		public static bool IsCacheModule(ShipModule shipModule) {
			if (!(shipModule != null)) return false;
			switch (shipModule.PrefabId) {
				case 685017033:
				case 957508477:
				case 1745395900:
				case 179311957:
				case 760711671:
				case 656277331:
				case 760711667:
				case 1279608160:
				case 1316302015:
				return true;
				default: return false;
			}
		}
		public static string GetStealthDetectionText(int stealthLevel) {
			switch (stealthLevel) {
				case 1: return "Basic";
				case 2: return "Improved";
				case 3: return "Advanced";
				case 4: return "Superior";
				case 5: return "Ultimate";
				default: return "Unknown";
			}
		}
		public static int GetCacheSets(ShipModule shipModule) {
			if (GetCacheType(shipModule) != null) return 3 + Mathf.RoundToInt((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f);
			else return 0;
		}
		public static int GetCacheHPIncrease(ShipModule shipModule) {
			if (!(shipModule != null)) return 0;
			if (shipModule.PrefabId == 685017033 || shipModule.PrefabId == 957508477) return 1 + Mathf.RoundToInt((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2.5f - 0.001f);
			else return 0;
		}
		public static int GetCacheHPLimit(ShipModule shipModule) {
			if (!(shipModule != null)) return 0;
			if (shipModule.PrefabId == 685017033 || shipModule.PrefabId == 957508477) return 25 + (int)FFU_BE_Mod_Technology.GetModuleTier(shipModule) * 25;
			else return 0;
		}
		public static string[] GetCacheWeapons(ShipModule shipModule, string itemSpacing = null) {
			if (!(shipModule != null)) return new string[0];
			return FFU_BE_Mod_Crewmembers.GetWeaponLocalesFromCacheID(shipModule.PrefabId, itemSpacing).ToArray();
		}
		public static string GetCrewHitChance(ShootAtDamageDealer.CrewDmgLevel crewDmgLevel) {
			switch (crewDmgLevel) {
				case ShootAtDamageDealer.CrewDmgLevel.High: return (int)Core.CrewHitChance.High + "%";
				case ShootAtDamageDealer.CrewDmgLevel.Default: return (int)Core.CrewHitChance.Medium + "%";
				case ShootAtDamageDealer.CrewDmgLevel.Low: return (int)Core.CrewHitChance.Low + "%";
				case ShootAtDamageDealer.CrewDmgLevel.None: return (int)Core.CrewHitChance.None + "%";
				default: return "0%";
			}
		}
		public static string GetFireIgniteChance(ShootAtDamageDealer.FireChanceLevel fireChanceLevel) {
			switch (fireChanceLevel) {
				case ShootAtDamageDealer.FireChanceLevel.High: return (int)Core.FireIgniteChance.High + "%";
				case ShootAtDamageDealer.FireChanceLevel.Default: return (int)Core.FireIgniteChance.Medium + "%";
				case ShootAtDamageDealer.FireChanceLevel.Low: return (int)Core.FireIgniteChance.Low + "%";
				case ShootAtDamageDealer.FireChanceLevel.None: return (int)Core.FireIgniteChance.None + "%";
				default: return "0%";
			}
		}
	}
}

namespace RST.UI {
	public class patch_ModuleSlotActionsPanel : ModuleSlotActionsPanel {
		[MonoModIgnore] private bool repopulateList;
		[MonoModIgnore] private ModuleSlot prevSlot;
		[MonoModIgnore] private List<ModuleSlotListItem> uiItems;
		[MonoModIgnore] private List<Item> items = new List<Item>();
		[MonoModIgnore] private void Close() { }
		[MonoModReplace] private void Start() {
			repopulateList = true;
			ReplaceToggleHoverableUI();
			Update();
		}
		[MonoModReplace] private void Update() {
		/// Resize List of Modules based on Resolution and Allow Module Grouping
			maxItemsToFit = (float)(Screen.height / 75) - 2;
			if (!Input.GetKeyDown(KeyCode.PageUp) && Input.GetKeyDown(KeyCode.PageDown)) SelectNextSubCategory();
			if (Input.GetKeyDown(KeyCode.PageUp) && !Input.GetKeyDown(KeyCode.PageDown)) SelectPrevSubCategory();
			ModuleSlot exactlyOneSelectedItem = SelectionManager.GetExactlyOneSelectedItem<ModuleSlot>();
			if (exactlyOneSelectedItem == null) {
				Close();
				return;
			}
			if (!group.activeSelf) {
				group.SetActive(true);
				GetCachedComponent<UIElementOrder>()?.SetRightSiblingIndex();
			}
			displayName.text = exactlyOneSelectedItem.DisplayNameLocalized;
			description.text = MonoBehaviourExtended.TT(exactlyOneSelectedItem.description);
			avatarRenderer.sprite = exactlyOneSelectedItem.avatar;
			ModuleSlotRoot moduleSlotRoot = exactlyOneSelectedItem.ModuleSlotRoot;
			ShipModule x = (moduleSlotRoot != null) ? moduleSlotRoot.Module : null;
			bool isPlayerOwner = exactlyOneSelectedItem.Ownership.GetOwner() == Ownership.Owner.Me;
			bool isSlotUpgradeBlocked = false;
			if (isPlayerOwner && !WorldRules.Impermanent.slotUpgradeDisabled && x != null) {
				isSlotUpgradeBlocked = true;
				warnings.text = MonoBehaviourExtended.TT("A module is already in slot, some slot upgrades/downgrades and module crafting are not possible");
			}
			if (warningsGroup.activeSelf != isSlotUpgradeBlocked) {
				warningsGroup.SetActive(isSlotUpgradeBlocked);
			}
			PlayerData me = PlayerDatas.Me;
			ResourceValueGroup pr = (me != null) ? me.Resources : ResourceValueGroup.Empty;
			if (prevSlot != exactlyOneSelectedItem) {
				slotUpgradesToggle.group.SetAllTogglesOff();
				repopulateList = true;
				prevSlot = exactlyOneSelectedItem;
			}
			if (repopulateList) {
				items.Clear();
				bool slotUpgradesEnabled = false;
				bool cargoModulesEnabled = false;
				bool weaponModulesEnabled = false;
				bool nukeModulesEnabled = false;
				bool survivalModulesEnabled = false;
				bool essentialModulesEnabled = false;
				bool economyModulesEnabled = false;
				bool otherModulesEnabled = false;
				bool isAnyTogglesOn = !slotUpgradesToggle.group.AnyTogglesOn();
				if (isPlayerOwner) {
					if (!WorldRules.Impermanent.slotUpgradeDisabled) {
						ModuleSlot.Upgrade[] upgrades = exactlyOneSelectedItem.upgrades;
						foreach (ModuleSlot.Upgrade slotUpgrade in upgrades) {
							slotUpgradesEnabled = true;
							if (isAnyTogglesOn || slotUpgradesToggle.isOn) {
								items.Add(new Item {
									slotUpgrade = slotUpgrade,
									slot = exactlyOneSelectedItem
								});
							}
						}
					}
					if (!WorldRules.Impermanent.moduleCraftDisabled) {
						IEnumerable<ShipModule> enumerable;
						if (altCraftableModulePrefabs == null) {
							IEnumerable<ShipModule> craftableModulePrefabs = exactlyOneSelectedItem.CraftableModulePrefabs;
							enumerable = craftableModulePrefabs;
						} else {
							IEnumerable<ShipModule> craftableModulePrefabs = altCraftableModulePrefabs;
							enumerable = craftableModulePrefabs;
						}
						foreach (ShipModule item in enumerable) {
							if (exactlyOneSelectedItem.acceptedModuleTypes.Contains(item.type)) {
								bool isMainCategorySelected = false;
								switch (ShipModule.GetCraftCategory(item.type)) {
									case ShipModule.CraftCategory.Cargo:
									cargoModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || cargoToggle.isOn);
									break;
									case ShipModule.CraftCategory.Weapon:
									weaponModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || weaponsToggle.isOn);
									break;
									case ShipModule.CraftCategory.Nuke:
									nukeModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || nukesToggle.isOn);
									break;
									case ShipModule.CraftCategory.Survival:
									survivalModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || survivalToggle.isOn);
									break;
									case ShipModule.CraftCategory.Essential:
									essentialModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || essentialToggle.isOn);
									break;
									case ShipModule.CraftCategory.Economy:
									economyModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || economyToggle.isOn);
									break;
									case ShipModule.CraftCategory.Other:
									otherModulesEnabled = true;
									isMainCategorySelected = (isAnyTogglesOn || otherToggle.isOn);
									break;
								}
								if (isMainCategorySelected) {
									if (cargoToggle.isOn) {
										if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.cargoTypeIDs[FFU_BE_Defs.chosenCargoType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (weaponsToggle.isOn) {
										if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.weaponTypeIDs[FFU_BE_Defs.chosenWeaponType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (nukesToggle.isOn) {
										if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.nukeTypeIDs[FFU_BE_Defs.chosenNukeType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (survivalToggle.isOn) {
										if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.survivalTypeIDs[FFU_BE_Defs.chosenSurvivalType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (essentialToggle.isOn) {
										if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.essentialTypeIDs[FFU_BE_Defs.chosenEssentialType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (economyToggle.isOn) {
										if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.economyTypeIDs[FFU_BE_Defs.chosenEconomyType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else if (otherToggle.isOn) {
										if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Any) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
										else if (FFU_BE_Defs.cacheTypeIDs[FFU_BE_Defs.chosenCacheType].Contains(item.PrefabId)) items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
									} else items.Add(new Item { craftableModulePrefab = item, slot = exactlyOneSelectedItem });
								}
							}
						}
					}
				}
				uiItems = RstUtil.RebuildUiList(itemContainer.transform, itemProto, items, delegate (ModuleSlotListItem ui, Item item)
				{
					ui.FillWithDataFrom(item, pr);
				});
				slotUpgradesToggle.interactable = slotUpgradesEnabled;
				cargoToggle.interactable = cargoModulesEnabled;
				weaponsToggle.interactable = weaponModulesEnabled;
				nukesToggle.interactable = nukeModulesEnabled;
				survivalToggle.interactable = survivalModulesEnabled;
				essentialToggle.interactable = essentialModulesEnabled;
				economyToggle.interactable = economyModulesEnabled;
				otherToggle.interactable = otherModulesEnabled;
				repopulateList = false;
			} else foreach (ModuleSlotListItem uiItem in uiItems) uiItem.Refresh(pr);
			scrollView.preferredHeight = (itemProto.transform as RectTransform).sizeDelta.y * Mathf.Min(uiItems.Count, maxItemsToFit);
			bool isCraftUpgradeDisabled = isPlayerOwner && WorldRules.Impermanent.slotUpgradeDisabled && WorldRules.Impermanent.moduleCraftDisabled;
			if (craftAndUpgradeDisabledGroup.activeSelf != isCraftUpgradeDisabled) craftAndUpgradeDisabledGroup.SetActive(isCraftUpgradeDisabled);
		}
		private void ReplaceToggleHoverableUI() {
			cargoToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Containers and Resource Packs. When enabled, use PAGE UP/DOWN to change sub-category.");
			weaponsToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Weapons and Point Defenses. When enabled, use PAGE UP/DOWN to change sub-category.");
			nukesToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Capital Missiles and Torpedoes. When enabled, use PAGE UP/DOWN to change sub-category.");
			survivalToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Survival-related Starship Modules. When enabled, use PAGE UP/DOWN to change sub-category.");
			essentialToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Essential Starship Modules. When enabled, use PAGE UP/DOWN to change sub-category.");
			economyToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Economy-related Starship Modules. When enabled, use PAGE UP/DOWN to change sub-category.");
			otherToggle.transform.GetComponent<HoverableUI>().hoverText = Core.TT($"Click to list only craftable Miscellaneous Starship Modules and Caches. When enabled, use PAGE UP/DOWN to change sub-category.");
		}
		private void SelectNextSubCategory() {
			if (cargoToggle.isOn) {
				if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Any) FFU_BE_Defs.chosenCargoType = Core.CargoType.Multi;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Multi) FFU_BE_Defs.chosenCargoType = Core.CargoType.Organics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Organics) FFU_BE_Defs.chosenCargoType = Core.CargoType.Starfuel;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Starfuel) FFU_BE_Defs.chosenCargoType = Core.CargoType.Metals;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Metals) FFU_BE_Defs.chosenCargoType = Core.CargoType.Synthetics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Synthetics) FFU_BE_Defs.chosenCargoType = Core.CargoType.Exoplosives;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Exoplosives) FFU_BE_Defs.chosenCargoType = Core.CargoType.Exotics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Exotics) FFU_BE_Defs.chosenCargoType = Core.CargoType.ResPack;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.ResPack) FFU_BE_Defs.chosenCargoType = Core.CargoType.Any;
				cargoToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenCargoType);
				repopulateList = true;
			} else if (weaponsToggle.isOn) {
				if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Any) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Launcher;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Launcher) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Autocannon;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Autocannon) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Howitzer;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Howitzer) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Railgun;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Railgun) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Railcannon;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Railcannon) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Laser;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Laser) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Beamer;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Beamer) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.HeatRay;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.HeatRay) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Disruptor;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Disruptor) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Radiator;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Radiator) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.ExoticRay;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.ExoticRay) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.CIWS;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.CIWS) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Any;
				weaponsToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenWeaponType);
				repopulateList = true;
			} else if (nukesToggle.isOn) {
				if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Any) FFU_BE_Defs.chosenNukeType = Core.NukeType.Kinetic;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Kinetic) FFU_BE_Defs.chosenNukeType = Core.NukeType.Energy;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Energy) FFU_BE_Defs.chosenNukeType = Core.NukeType.Thermal;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Thermal) FFU_BE_Defs.chosenNukeType = Core.NukeType.Tactical;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Tactical) FFU_BE_Defs.chosenNukeType = Core.NukeType.Chemical;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Chemical) FFU_BE_Defs.chosenNukeType = Core.NukeType.Boarding;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Boarding) FFU_BE_Defs.chosenNukeType = Core.NukeType.Strategic;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Strategic) FFU_BE_Defs.chosenNukeType = Core.NukeType.Any;
				nukesToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenNukeType);
				repopulateList = true;
			} else if (survivalToggle.isOn) {
				if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Any) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Armor;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Armor) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Shield;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Shield) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Battery;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Battery) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Sensor;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Sensor) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Stealth;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Stealth) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.EWAR;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.EWAR) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Health;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Health) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Decoy;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Decoy) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Any;
				survivalToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenSurvivalType);
				repopulateList = true;
			} else if (essentialToggle.isOn) {
				if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Any) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Energy;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Energy) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Reactor;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Reactor) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Bionic;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Bionic) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Bridge;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Bridge) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Engine;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Engine) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Drive;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Drive) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Any;
				essentialToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenEssentialType);
				repopulateList = true;
			} else if (economyToggle.isOn) {
				if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Any) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryobay;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryobay) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryodream;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryodream) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryosleep;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryosleep) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Laboratory;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Laboratory) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Greenhouse;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Greenhouse) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Refinery;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Refinery) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Any;
				economyToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenEconomyType);
				repopulateList = true;
			} else if (otherToggle.isOn) {
				if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Any) FFU_BE_Defs.chosenCacheType = Core.CacheType.Default;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Default) FFU_BE_Defs.chosenCacheType = Core.CacheType.Weapons;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Weapons) FFU_BE_Defs.chosenCacheType = Core.CacheType.Implants;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Implants) FFU_BE_Defs.chosenCacheType = Core.CacheType.Upgrades;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Upgrades) FFU_BE_Defs.chosenCacheType = Core.CacheType.Artifact;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Artifact) FFU_BE_Defs.chosenCacheType = Core.CacheType.Any;
				otherToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenCacheType);
				repopulateList = true;
			}
		}
		private void SelectPrevSubCategory() {
			if (cargoToggle.isOn) {
				if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Any) FFU_BE_Defs.chosenCargoType = Core.CargoType.ResPack;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.ResPack) FFU_BE_Defs.chosenCargoType = Core.CargoType.Exotics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Exotics) FFU_BE_Defs.chosenCargoType = Core.CargoType.Exoplosives;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Exoplosives) FFU_BE_Defs.chosenCargoType = Core.CargoType.Synthetics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Synthetics) FFU_BE_Defs.chosenCargoType = Core.CargoType.Metals;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Metals) FFU_BE_Defs.chosenCargoType = Core.CargoType.Starfuel;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Starfuel) FFU_BE_Defs.chosenCargoType = Core.CargoType.Organics;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Organics) FFU_BE_Defs.chosenCargoType = Core.CargoType.Multi;
				else if (FFU_BE_Defs.chosenCargoType == Core.CargoType.Multi) FFU_BE_Defs.chosenCargoType = Core.CargoType.Any;
				cargoToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenCargoType);
				repopulateList = true;
			} else if (weaponsToggle.isOn) {
				if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Any) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.CIWS;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.CIWS) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.ExoticRay;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.ExoticRay) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Radiator;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Radiator) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Disruptor;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Disruptor) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.HeatRay;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.HeatRay) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Beamer;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Beamer) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Laser;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Laser) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Railcannon;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Railcannon) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Railgun;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Railgun) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Howitzer;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Howitzer) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Autocannon;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Autocannon) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Launcher;
				else if (FFU_BE_Defs.chosenWeaponType == Core.WeaponType.Launcher) FFU_BE_Defs.chosenWeaponType = Core.WeaponType.Any;
				weaponsToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenWeaponType);
				repopulateList = true;
			} else if (nukesToggle.isOn) {
				if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Any) FFU_BE_Defs.chosenNukeType = Core.NukeType.Strategic;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Strategic) FFU_BE_Defs.chosenNukeType = Core.NukeType.Boarding;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Boarding) FFU_BE_Defs.chosenNukeType = Core.NukeType.Chemical;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Chemical) FFU_BE_Defs.chosenNukeType = Core.NukeType.Tactical;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Tactical) FFU_BE_Defs.chosenNukeType = Core.NukeType.Thermal;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Thermal) FFU_BE_Defs.chosenNukeType = Core.NukeType.Energy;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Energy) FFU_BE_Defs.chosenNukeType = Core.NukeType.Kinetic;
				else if (FFU_BE_Defs.chosenNukeType == Core.NukeType.Kinetic) FFU_BE_Defs.chosenNukeType = Core.NukeType.Any;
				nukesToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenNukeType);
				repopulateList = true;
			} else if (survivalToggle.isOn) {
				if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Any) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Decoy;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Decoy) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Health;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Health) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.EWAR;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.EWAR) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Stealth;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Stealth) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Sensor;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Sensor) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Battery;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Battery) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Shield;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Shield) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Armor;
				else if (FFU_BE_Defs.chosenSurvivalType == Core.SurvivalType.Armor) FFU_BE_Defs.chosenSurvivalType = Core.SurvivalType.Any;
				survivalToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenSurvivalType);
				repopulateList = true;
			} else if (essentialToggle.isOn) {
				if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Any) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Drive;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Drive) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Engine;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Engine) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Bridge;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Bridge) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Bionic;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Bionic) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Reactor;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Reactor) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Energy;
				else if (FFU_BE_Defs.chosenEssentialType == Core.EssentialType.Energy) FFU_BE_Defs.chosenEssentialType = Core.EssentialType.Any;
				essentialToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenEssentialType);
				repopulateList = true;
			} else if (economyToggle.isOn) {
				if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Any) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Refinery;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Refinery) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Greenhouse;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Greenhouse) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Laboratory;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Laboratory) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryosleep;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryosleep) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryodream;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryodream) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Cryobay;
				else if (FFU_BE_Defs.chosenEconomyType == Core.EconomyType.Cryobay) FFU_BE_Defs.chosenEconomyType = Core.EconomyType.Any;
				economyToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenEconomyType);
				repopulateList = true;
			} else if (otherToggle.isOn) {
				if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Any) FFU_BE_Defs.chosenCacheType = Core.CacheType.Artifact;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Artifact) FFU_BE_Defs.chosenCacheType = Core.CacheType.Upgrades;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Upgrades) FFU_BE_Defs.chosenCacheType = Core.CacheType.Implants;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Implants) FFU_BE_Defs.chosenCacheType = Core.CacheType.Weapons;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Weapons) FFU_BE_Defs.chosenCacheType = Core.CacheType.Default;
				else if (FFU_BE_Defs.chosenCacheType == Core.CacheType.Default) FFU_BE_Defs.chosenCacheType = Core.CacheType.Any;
				otherToggle.transform.GetChild(1).GetComponent<Text>().text = HandleToggleText(FFU_BE_Defs.chosenCacheType);
				repopulateList = true;
			}
		}
		private static string HandleToggleText(Core.CargoType cargoType) {
			switch (cargoType) {
				case Core.CargoType.Multi: return "MULTI-CONTAINERS";
				case Core.CargoType.Organics: return "ORGANICS CONTAINERS";
				case Core.CargoType.Starfuel: return "STARFUEL CONTAINERS";
				case Core.CargoType.Metals: return "METAL ALLOYS CONTAINERS";
				case Core.CargoType.Synthetics: return "SYNTHETICS CONTAINERS";
				case Core.CargoType.Exoplosives: return "EXOPLOSIVES CONTAINERS";
				case Core.CargoType.Exotics: return "EXOTIC MATTER CONTAINERS";
				case Core.CargoType.ResPack: return "RESOURCE PACKS";
				default: return "CARGO";
			}
		}
		private static string HandleToggleText(Core.WeaponType weaponType) {
			switch (weaponType) {
				case Core.WeaponType.Launcher: return "ROCKET LAUNCHERS";
				case Core.WeaponType.Autocannon: return "AUTOCANNONS";
				case Core.WeaponType.Howitzer: return "HOWITZERS";
				case Core.WeaponType.Railgun: return "RAILGUNS";
				case Core.WeaponType.Railcannon: return "RAILCANNONS";
				case Core.WeaponType.Laser: return "LASER EMITTERS";
				case Core.WeaponType.Beamer: return "BEAM EMITTERS";
				case Core.WeaponType.HeatRay: return "HEAT RAY PROJECTORS";
				case Core.WeaponType.Disruptor: return "ENERGY DISRUPTORS";
				case Core.WeaponType.Radiator: return "RADIATION ACCELERATORS";
				case Core.WeaponType.ExoticRay: return "PARTICLE DISINTEGRATORS";
				case Core.WeaponType.CIWS: return "CLOSE-IN WEAPON SYSTEMS";
				default: return "WEAPONS";
			}
		}
		private static string HandleToggleText(Core.NukeType nukeType) {
			switch (nukeType) {
				case Core.NukeType.Kinetic: return "KINETIC NUKES";
				case Core.NukeType.Energy: return "ENERGY NUKES";
				case Core.NukeType.Thermal: return "THERMAL NUKES";
				case Core.NukeType.Tactical: return "TACTICAL NUKES";
				case Core.NukeType.Chemical: return "CHEMICAL NUKES";
				case Core.NukeType.Boarding: return "BOARDING NUKES";
				case Core.NukeType.Strategic: return "STRATEGIC NUKES";
				default: return "NUKES";
			}
		}
		private static string HandleToggleText(Core.SurvivalType survivalType) {
			switch (survivalType) {
				case Core.SurvivalType.Armor: return "INTEGRITY ARMORS";
				case Core.SurvivalType.Shield: return "SHIELD GENERATORS";
				case Core.SurvivalType.Battery: return "SHIELD CAPACITORS";
				case Core.SurvivalType.Sensor: return "SENSOR ARRAYS";
				case Core.SurvivalType.Stealth: return "STEALTH GENERATORS";
				case Core.SurvivalType.EWAR: return "ELECTRONIC COUNTERMEASURES";
				case Core.SurvivalType.Health: return "RESTORATION BAYS";
				case Core.SurvivalType.Decoy: return "DECOY MODULES";
				default: return "SURVIVAL";
			}
		}
		private static string HandleToggleText(Core.EssentialType essentialType) {
			switch (essentialType) {
				case Core.EssentialType.Energy: return "ALL REACTORS";
				case Core.EssentialType.Reactor: return "STANDARD REACTORS";
				case Core.EssentialType.Bionic: return "ORGANIC REACTORS";
				case Core.EssentialType.Bridge: return "COMMAND BRIDGES";
				case Core.EssentialType.Engine: return "STARSHIP ENGINES";
				case Core.EssentialType.Drive: return "HYPERSPACE DRIVES";
				default: return "ESSENTIAL";
			}
		}
		private static string HandleToggleText(Core.EconomyType economyType) {
			switch (economyType) {
				case Core.EconomyType.Cryobay: return "ALL CRYONIC BAYS";
				case Core.EconomyType.Cryodream: return "CRYODREAM BAYS";
				case Core.EconomyType.Cryosleep: return "CRYOSLEEP BAYS";
				case Core.EconomyType.Laboratory: return "LABORATORIES";
				case Core.EconomyType.Greenhouse: return "GREENHOUSES";
				case Core.EconomyType.Refinery: return "RESOURCE CONVERTERS";
				default: return "ECONOMY";
			}
		}
		private static string HandleToggleText(Core.CacheType cacheType) {
			switch (cacheType) {
				case Core.CacheType.Default: return "ALL USABLE CACHES";
				case Core.CacheType.Weapons: return "WEAPON CACHES";
				case Core.CacheType.Implants: return "IMPLANT CACHES";
				case Core.CacheType.Upgrades: return "UPGRADE CACHES";
				case Core.CacheType.Artifact: return "ARTIFACT MODULES";
				default: return "OTHER";
			}
		}
	}
	public class patch_ModuleSlotListItem : ModuleSlotListItem {
		[MonoModIgnore] private bool confirmSlotDowngrade;
		[MonoModIgnore] private ModuleSlotActionsPanel.Item Item;
		[MonoModReplace] public void FillWithDataFrom(ModuleSlotActionsPanel.Item item, ResourceValueGroup pr) {
		/// Prefab Module Full Information Window
			Item = item;
			base.gameObject.SetActive(true);
			confirmSlotDowngrade = false;
			ModuleSlot.Upgrade slotUpgrade = item.slotUpgrade;
			if (slotUpgrade != null) {
				hoverableModule.HoverModule = null;
				avatarRenderer.sprite = slotUpgrade.UpgradeToSlotPrefab.avatar;
				hoverable.HoverText = Localization.TT(slotUpgrade.UpgradeToSlotPrefab.description);
				if (isUpgradeGroup.activeSelf != !slotUpgrade.isDowngrade) isUpgradeGroup.SetActive(!slotUpgrade.isDowngrade);
				if (isDowngradeGroup.activeSelf != slotUpgrade.isDowngrade) isDowngradeGroup.SetActive(slotUpgrade.isDowngrade);
				if (isCraftGroup.activeSelf) isCraftGroup.SetActive(false);
				if (costLabel.activeSelf != !slotUpgrade.isDowngrade) costLabel.SetActive(!slotUpgrade.isDowngrade);
				if (gainLabel.activeSelf != slotUpgrade.isDowngrade) gainLabel.SetActive(slotUpgrade.isDowngrade);
			}
			ShipModule craftableModulePrefab = item.craftableModulePrefab;
			if (craftableModulePrefab != null) {
				hoverableModule.HoverModule = craftableModulePrefab;
				avatarRenderer.sprite = craftableModulePrefab.image;
				text.text = string.Format(Localization.TT("Craft {0}"), craftableModulePrefab.displayName.Replace("<color=", "\n<color="));
				hoverable.HoverText = Localization.TT(FFU_BE_Mod_Information.GetCraftableModuleDescription(craftableModulePrefab));
				if (isUpgradeGroup.activeSelf) isUpgradeGroup.SetActive(false);
				if (isDowngradeGroup.activeSelf) isDowngradeGroup.SetActive(false);
				if (!isCraftGroup.activeSelf) isCraftGroup.SetActive(true);
				if (!costLabel.activeSelf) costLabel.SetActive(true);
				if (gainLabel.activeSelf) gainLabel.SetActive(false);
				hoverable.enabled = true;
			}
			hoverableModule.enabled = false;
			hoverable.enabled = true;
			Refresh(pr);
		}
		[MonoModReplace] public void Refresh(ResourceValueGroup pr) {
		/// Prefab Module Full Information Window
			ModuleSlotActionsPanel.Item item = Item;
			if (item == null) return;
			ModuleSlot.Upgrade slotUpgrade = item.slotUpgrade;
			if (slotUpgrade != null) {
				text.text = (slotUpgrade.isDowngrade && confirmSlotDowngrade) ? Localization.TT("CONFIRM DOWNGRADE?") : Localization.TT(slotUpgrade.text, item.slot);
				hoverable.HoverText = Localization.TT(slotUpgrade.UpgradeToSlotPrefab.description, item.slot);
				if (item.slot.UpgradeWouldDestroyShip(slotUpgrade)) {
					HoverableUI hoverableUI = hoverable;
					hoverableUI.HoverText = hoverableUI.HoverText + "\n<color=red>" + Localization.TT("Button disabled, because it would destroy the ship") + "</color>";
				}
				costUi.Update(slotUpgrade.cost, !slotUpgrade.isDowngrade, pr);
				if (!slotUpgrade.isDowngrade) button.interactable = item.slot.CanUpgradeTo(slotUpgrade) && slotUpgrade.cost.CheckHasEnough(pr);
				else button.interactable = item.slot.CanUpgradeTo(slotUpgrade);
			}
			ShipModule craftableModulePrefab = item.craftableModulePrefab;
			if (craftableModulePrefab != null) {
				hoverable.HoverText = Localization.TT(FFU_BE_Mod_Information.GetCraftableModuleDescription(craftableModulePrefab), craftableModulePrefab);
				costUi.Update(craftableModulePrefab.craftCost, true, pr);
				button.interactable = item.slot.CanCraft(craftableModulePrefab) && craftableModulePrefab.craftCost.CheckHasEnough(pr);
			}
		}
	}
	public class patch_ModuleDataSubpanel : ModuleDataSubpanel {
		[MonoModIgnore] private patch_ShipModule m;
		[MonoModIgnore] private patch_ShipModule lastModule;
		[MonoModIgnore] private float prevMaxHealthAdd;
		[MonoModIgnore] private float prevStarmapSpeedAdd;
		[MonoModIgnore] private float prevAsteroidDefl;
		[MonoModIgnore] private float prevShipEvasionPercentAdd;
		[MonoModIgnore] private float prevMaxShieldAdd;
		[MonoModIgnore] private float prevStarmapStealthDetMax;
		[MonoModIgnore] private float prevPowerConsumed;
		[MonoModIgnore] private float prevSAccuracyBonus;
		[MonoModIgnore] private float prevWeaponDmgArea;
		[MonoModIgnore] private float prevFuel;
		[MonoModIgnore] private float prevOrganics;
		[MonoModIgnore] private float prevExpl;
		[MonoModIgnore] private float prevExotics;
		[MonoModIgnore] private float prevSynth;
		[MonoModIgnore] private float prevMetals;
		[MonoModIgnore] private float prevCredits;
		[MonoModIgnore] private float prevShieldAdd;
		[MonoModIgnore] private float prevActivationFuel;
		[MonoModIgnore] private float prevPowerCapacity;
		[MonoModIgnore] private float prevHealingSpots;
		[MonoModIgnore] private float prevHealingInvSpeed;
		[MonoModIgnore] private float prevOrganicsPerHp;
		[MonoModIgnore] private float prevSyntheticsPerHp;
		[MonoModIgnore] private float prevOpSpots;
		[MonoModIgnore] private float prevFuelCons;
		[MonoModIgnore] private float prevOrganicsCons;
		[MonoModIgnore] private float prevExplCons;
		[MonoModIgnore] private float prevExoticsCons;
		[MonoModIgnore] private float prevSynthCons;
		[MonoModIgnore] private float prevMetalsCons;
		[MonoModIgnore] private float prevCreditsCons;
		[MonoModIgnore] private void SafeUpdateField(Text text, string value) { }
		[MonoModIgnore] private void DoResourceConsPerDist(ResourceValueGroup rc, ShipModule m) { }
		[MonoModIgnore] private static void DoRequirementColor(Text text, HoverableUI h, bool hasEnough) { }
		[MonoModIgnore] private static void AppendDmgLine(StringBuilder sb, string localizedLine, int dmg, int cnt) { }
		[MonoModIgnore] private void SafeUpdateField(Text text, float value, ref float prevValue, string format = "{0}") { }
		[MonoModIgnore] private void UpdateGroupedDmg(bool showShieldIcon, bool showShipIcon, bool showModuleIcon, string value) { }
		[MonoModIgnore] private static void DoSkillIcon(HoverableUI skillIcon, bool shouldShow, ShipModule m) { }
		[MonoModIgnore] private static string LocalizedPer {get {return Localization.TT("per"); }}
		[MonoModIgnore] private static string LocalizedRu {get {return Localization.TT("ru"); }}
		[MonoModIgnore] private static string LocalizedS {get {return Localization.TT("s"); }}
		private static string LocalizedM {get {return Localization.TT("m"); }}
		private static string LocalizedEMP {get {return Localization.TT("EMP"); }}
		private static string LocalizedHP {get {return Localization.TT("HP"); }}
		private static string LocalizedSP {get {return Localization.TT("SP"); }}
		private static string LocalizedHit {get {return Localization.TT("Hit"); }}
		private static string LocalizedMin {get {return Localization.TT("min."); }}
		private static string LocalizedGWh {get {return Localization.TT("GW/h"); }}
		private bool doWeaponHovers = false;
		private bool doNukeHovers = false;
		private bool doPointDefHovers = false;
		private bool doEngineHovers = false;
		private bool doResPackHovers = false;
		private bool doSensorHovers = false;
		private bool doBridgeHovers = false;
		private bool doShieldHovers = false;
		private bool doWarpHovers = false;
		private bool doReactorHovers = false;
		private bool doHealthBayHovers = false;
		private bool doConverterHovers = false;
		private bool doFighterHovers = false;
		private bool doContainerHovers = false;
		private bool doStorageHovers = false;
		private bool doCryosleepHovers = false;
		private bool doGardenHovers = false;
		private bool doResearchHovers = false;
		private bool doStealthHovers = false;
		private bool doPassiveHovers = false;
		private bool doIntegrityHovers = false;
		private bool doDecoyHovers = false;
		private bool doOtherHovers = false;
		private bool sizeWasChanged = false;
		private float healthPercent;
		private float prevEMPoverload;
		private float prevEnergyEmission;
		private float prevProjSpeed;
		private float prevOverchargeEvasion;
		private float prevOverchargePower;
		private float prevOverchargeNeed;
		private float prevOverchargeTime;
		private string preColor;
		private string aftColor;
		private string altPreClr;
		private string altAftClr;
		[MonoModReplace] private void Update() {
		/// Selected Module Full Information Window
			if (m == null) return;
			if (!sizeWasChanged) {
				ModuleDataSubpanelUI.minHeight = 240;
				ModuleDataSubpanelUI.maxHeight = 360;
				sizeWasChanged = true;
			}
			if (lastModule != m) {
				GameObject[] array = itemGroups;
				for (int i = 0; i < array.Length; i++)
					foreach (Transform item in array[i].transform)
						item.gameObject.SetActive(false);
				prevActivationFuel = 0f;
				prevAsteroidDefl = 0f;
				prevCredits = 0f;
				prevCreditsCons = 0f;
				prevExotics = 0f;
				prevExoticsCons = 0f;
				prevExpl = 0f;
				prevExplCons = 0f;
				prevFuel = 0f;
				prevFuelCons = 0f;
				prevHealingInvSpeed = 0f;
				prevHealingSpots = 0f;
				prevMaxHealthAdd = 0f;
				prevMaxShieldAdd = 0f;
				prevMetals = 0f;
				prevMetalsCons = 0f;
				prevOpSpots = 0f;
				prevOrganics = 0f;
				prevOrganicsCons = 0f;
				prevOrganicsPerHp = 0f;
				prevPowerCapacity = 0f;
				prevPowerConsumed = 0f;
				prevSAccuracyBonus = 0f;
				prevShieldAdd = 0f;
				prevShipEvasionPercentAdd = 0f;
				prevStarmapSpeedAdd = 0f;
				prevStarmapStealthDetMax = 0f;
				prevSynth = 0f;
				prevSynthCons = 0f;
				prevSyntheticsPerHp = 0f;
				prevWeaponDmgArea = 0f;
				prevEMPoverload = 0f;
				prevEnergyEmission = 0f;
				prevProjSpeed = 0f;
				prevOverchargeEvasion = 0f;
				prevOverchargePower = 0f;
				prevOverchargeNeed = 0f;
				prevOverchargeTime = 0f;
				lastModule = m;
			}
			displayName.text = m.DisplayNameLocalized;
			description.text = Localization.TT(m.description);
			status.text = m.GetExtStatusStringLocalized();
			ModuleTypeData moduleTypeData = WorldRules.Instance.moduleTypeDatas.Get(m.type);
			icon.sprite = moduleTypeData?.icon;
			iconHover.HoverText = moduleTypeData != null ? Localization.TT(moduleTypeData.iconHoverText) : null;
			if (m.Ownership.GetOwner() == Ownership.Owner.Me && iconHover.Hovered) iconHover.HoverText = FFU_BE_Mod_Information.GetSelectedModuleExactData(m);
			image.sprite = m.image;
			health.text = (m.type != ShipModule.Type.Storage) ? RstShared.StringBuilder.AppendColoredHealth(m).ToString() : null;
			health.horizontalOverflow = HorizontalWrapMode.Overflow;
			Vector2 sizeDelta = maxHealthLostCountTiled.rectTransform.sizeDelta;
			float num = m.MaxHealthLostCount * sizeDelta.y;
			if (sizeDelta.x != num) maxHealthLostCountTiled.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
			ModuleSlotRoot moduleSlotRoot = m.ModuleSlotRoot;
			float chance = (moduleSlotRoot == null || moduleSlotRoot.Slot == null) ? 0f : moduleSlotRoot.Slot.deflectChance;
			deflection.text = RstUtil.FormatChanceValue(chance);
			if (m.HasFullHealth) {
				preColor = null;
				aftColor = null;
				altPreClr = "<color=lime>";
				altAftClr = "</color>";
				healthPercent = 1f;
			} 
			else {
				preColor = "<color=red>";
				aftColor = "</color>";
				altPreClr = null;
				altAftClr = null;
				healthPercent = FFU_BE_Defs.GetHealthPercent(m);
			}
			switch (m.type) {
				case ShipModule.Type.Weapon:
				DoWeapon(); break;
				case ShipModule.Type.Weapon_Nuke:
				DoNuke(); break;
				case ShipModule.Type.PointDefence:
				DoPointDefence(); break;
				case ShipModule.Type.Engine:
				DoEngine(); break;
				case ShipModule.Type.ResourcePack:
				DoResourcePack(); break;
				case ShipModule.Type.Sensor:
				DoSensor(); break;
				case ShipModule.Type.Bridge:
				DoBridge(); break;
				case ShipModule.Type.ShieldGen:
				DoShieldGen(); break;
				case ShipModule.Type.Warp:
				DoWarp(); break;
				case ShipModule.Type.Reactor:
				DoReactor(); break;
				case ShipModule.Type.Medbay:
				case ShipModule.Type.Dronebay:
				DoMedbay(); break;
				case ShipModule.Type.MaterialsConverter:
				DoMaterialsConverter(); break;
				case ShipModule.Type.Fighter:
				DoFighter(); break;
				case ShipModule.Type.Container:
				DoContainer(); break;
				case ShipModule.Type.Storage:
				DoStorageContainer(); break;
				case ShipModule.Type.Cryosleep:
				DoCryosleep(); break;
				case ShipModule.Type.Garden:
				DoGarden(); break;
				case ShipModule.Type.ResearchLab:
				DoResearch(); break;
				case ShipModule.Type.StealthDecryptor:
				DoStealthDecryptorSensor(); break;
				case ShipModule.Type.PassiveECM:
				DoPassiveECM(); break;
				case ShipModule.Type.Integrity:
				DoIntegrity(); break;
				case ShipModule.Type.Decoy:
				DoDecoy(); break;
				case ShipModule.Type.Other:
				DoOther(); break;
			}
			Crewmember.Skill requiredCrewSkillType = m.GetRequiredCrewSkillType();
			DoSkillIcon(bridgeSkill, requiredCrewSkillType == Crewmember.Skill.Bridge, m);
			DoSkillIcon(sensorSkill, requiredCrewSkillType == Crewmember.Skill.Sensor, m);
			DoSkillIcon(gunnerySkill, requiredCrewSkillType == Crewmember.Skill.Gunnery, m);
			DoSkillIcon(shieldSkill, requiredCrewSkillType == Crewmember.Skill.Shield, m);
			DoSkillIcon(scienceSkill, requiredCrewSkillType == Crewmember.Skill.Science, m);
			DoSkillIcon(warpSkill, requiredCrewSkillType == Crewmember.Skill.Warp, m);
			DoSkillIcon(gardeningSkill, requiredCrewSkillType == Crewmember.Skill.Garden, m);
			Ship ship = m.Ship;
			SafeUpdateField(powerConsText, m.powerConsumed, ref prevPowerConsumed, "{0:0}");
			DoRequirementColor(powerConsText, powerCons, ship == null || m.type == ShipModule.Type.Warp || (m.turnedOn && m.EnoughPower));
			//if (Time.frameCount % 300 == 0) FFU_BE_Defs.GetComponentsListTree(matConvEquationGroup);
		}
		[MonoModReplace] private void DoWeapon() {
		/// Updated Weapon Information
			WeaponModule weapon = m.Weapon;
			ShootAtDamageDealer.Damage damage = weapon.ProjectileOrBeamPrefab.GetDamage(weapon);
			Projectile projectile = weapon.ProjectileOrBeamPrefab as Projectile;
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			if (weapon.accuracy != 0) {
				weaponAccuracy.SetActiveIfNeeded();
				int effAccuracy = gunnerySkillEffects.EffectiveAccuracy(weapon);
				weaponAccuracy.effects.text = weapon.accuracy != effAccuracy ? $"{altPreClr}{preColor}{effAccuracy * healthPercent:0} Δ{LocalizedM}{aftColor}{altAftClr}" : $"{preColor}{effAccuracy * healthPercent:0} Δ{LocalizedM}{aftColor}";
				weaponAccuracy.skillBonus.text = "+" + gunnerySkillEffects.skillPointAccuracyBonus.ToString("0.0") + " " + LocalizedPer;
				SortOrder(weaponAccuracy, 10);
			}
			if (weapon.reloadInterval != 0f) {
				weaponReloadTime.SetActiveIfNeeded();
				float effReload = gunnerySkillEffects.EffectiveReloadTime(weapon);
				weaponReloadTime.effects.text = weapon.reloadInterval != effReload ? $"{altPreClr}{preColor}{effReload / healthPercent:0.0}{LocalizedS}{aftColor}{altAftClr}" : $"{preColor}{effReload / healthPercent:0.0}{LocalizedS}{aftColor}";
				weaponReloadTime.skillBonus.text = $"-{((!weapon.reloadIntervalTakesNoBonuses) ? gunnerySkillEffects.skillPointBonusPercent : 0)}% {LocalizedPer}";
				SortOrder(weaponReloadTime, 20);
			}
			_ = weapon.tracksTarget;
			if (projectile != null) SafeUpdateField(30, sensorSectorRadarRange, projectile.speed * 100f, ref prevProjSpeed, "{0:0} " + LocalizedM + "/" + LocalizedS);
			SafeUpdateField(40, dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.##}" + LocalizedM);
			if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg && damage.shipDmg == damage.moduleDmg) {
				if (!groupedDmg.activeSelf) groupedDmg.SetActive(true);
				UpdateGroupedDmg(true, true, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
				SortOrder(groupedDmg, 50);
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg) {
				UpdateGroupedDmg(true, true, false, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(70, dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
				SortOrder(groupedDmg, 50);
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.moduleDmg) {
				UpdateGroupedDmg(true, false, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.shipDmg != 0) SafeUpdateField(80, dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
				SortOrder(groupedDmg, 50);
			} else if (damage.shipDmg != 0 && damage.shipDmg == damage.moduleDmg) {
				UpdateGroupedDmg(false, true, true, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(60, dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
				SortOrder(groupedDmg, 50);
			} else {
				if (damage.shipDmg != 0) SafeUpdateField(80, dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(70, dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(60, dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
			}
			StringBuilder stringBuilder = RstShared.StringBuilder;
			if (damage.shipDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to armor"), damage.shipDmg, weapon.magazineSize);
			if (damage.moduleDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to modules"), damage.moduleDmg, weapon.magazineSize);
			if (damage.shieldDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to shields"), damage.shieldDmg, weapon.magazineSize);
			groupedDmgTextHover.HoverText = stringBuilder.ToStringWithoutLastChar();
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
			SortOrder(dmgToCrewText, 90);
			SortOrder(fireChanceText, 100);
			SafeUpdateField(110, empOverloadText, damage.moduleOverloadSeconds, ref prevEMPoverload, LocalizedEMP + " " + "{0:0}" + LocalizedS);
			SortOrder(empOverloadText, 110);
			weaponIgnoresShieldGo.SetActive(damage.ignoresShield);
			weaponNeverDeflectsGo.SetActive(damage.neverDeflect);
			SortOrder(weaponIgnoresShieldGo, 120);
			SortOrder(weaponNeverDeflectsGo, 130);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			Ship ship = m.Ship;
			ResourceValueGroup resourcesPerShot = weapon.resourcesPerShot;
			SafeUpdateField(organicsPerShotText, resourcesPerShot.organics, ref prevOrganics, "{0:0}");
			SafeUpdateField(fuelPerShotText, resourcesPerShot.fuel, ref prevFuel, "{0:0}");
			SafeUpdateField(metalsPerShotText, resourcesPerShot.metals, ref prevMetals, "{0:0}");
			SafeUpdateField(explosivesPerShotText, resourcesPerShot.explosives, ref prevExpl, "{0:0}");
			SafeUpdateField(syntheticsPerShotText, resourcesPerShot.synthetics, ref prevSynth, "{0:0}");
			SafeUpdateField(exoticsPerShotText, resourcesPerShot.exotics, ref prevExotics, "{0:0}");
			DoRequirementColor(organicsPerShotText, organicsPerShot, ship == null || ship.Organics >= resourcesPerShot.organics);
			DoRequirementColor(fuelPerShotText, fuelPerShot, ship == null || ship.Fuel >= resourcesPerShot.fuel);
			DoRequirementColor(metalsPerShotText, metalsPerShot, ship == null || ship.Metals >= resourcesPerShot.metals);
			DoRequirementColor(syntheticsPerShotText, syntheticsPerShot, ship == null || ship.Synthetics >= resourcesPerShot.synthetics);
			DoRequirementColor(explosivesPerShotText, explosivesPerShot, ship == null || ship.Explosives >= resourcesPerShot.explosives);
			DoRequirementColor(exoticsPerShotText, exoticsPerShot, ship == null || ship.Exotics >= resourcesPerShot.exotics);
			if (!doWeaponHovers) {
				UpdateHoverFlags(doWeaponHovers: true);
				weaponIgnoresShieldHover.HoverText = $"{Localization.TT("Shows if weapon's hits completely bypass shields.")}";
				weaponNeverDeflectsHover.HoverText = $"{Localization.TT("Shows if weapon's hits are affected by target's deflective properties.")}";
				weaponAccuracy.hoverable.HoverText = $"{Localization.TT("Effective accuracy of a weapon that defines hit sector size.")}";
				weaponReloadTime.hoverable.HoverText = $"{Localization.TT("Effective reload time of a weapon between volleys.")}";
				sensorSectorRadarRangeHover.HoverText = $"{Localization.TT("Speed of projectile ejected from the weapon.")}";
				dmgAreaHover.HoverText = $"{Localization.TT("Effective area of effect at point of projectile/beam impact.")}";
				empOverloadHover.HoverText = $"{Localization.TT("Effective module disruption time within area of effect.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy weapon currently emits and by how much it inflates ship's signature.")}";
			}
		}
		private void DoNuke() {
		/// Updated Capital Missile Information
			WeaponModule weapon = m.Weapon;
			ShootAtDamageDealer.Damage damage = weapon.ProjectileOrBeamPrefab.GetDamage(weapon);
			Projectile projectile = weapon.ProjectileOrBeamPrefab as Projectile;
			HomingMovement homingMovement = projectile?.GetCachedComponent<HomingMovement>(true);
			weaponTracksTargetGo.SetActive(m.type == ShipModule.Type.Weapon_Nuke);
			weaponIgnoresShieldGo.SetActive(damage.ignoresShield);
			weaponNeverDeflectsGo.SetActive(damage.neverDeflect);
			SortOrder(weaponTracksTargetGo, 10);
			SortOrder(weaponIgnoresShieldGo, 20);
			SortOrder(weaponNeverDeflectsGo, 30);
			if (homingMovement != null) SafeUpdateField(40, sensorSectorRadarRange, homingMovement.force * 10f, ref prevProjSpeed, "{0:0} " + LocalizedM + "/" + LocalizedS + "²");
			SafeUpdateField(50, dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.##}" + LocalizedM);
			_ = weapon.tracksTarget;
			if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg && damage.shipDmg == damage.moduleDmg) {
				if (!groupedDmg.activeSelf) groupedDmg.SetActive(true);
				UpdateGroupedDmg(true, true, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
				SortOrder(groupedDmg, 60);
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg) {
				UpdateGroupedDmg(true, true, false, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(80, dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
				SortOrder(groupedDmg, 60);
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.moduleDmg) {
				UpdateGroupedDmg(true, false, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.shipDmg != 0) SafeUpdateField(90, dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
				SortOrder(groupedDmg, 60);
			} else if (damage.shipDmg != 0 && damage.shipDmg == damage.moduleDmg) {
				UpdateGroupedDmg(false, true, true, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(70, dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
				SortOrder(groupedDmg, 60);
			} else {
				if (damage.shipDmg != 0) SafeUpdateField(90, dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(80, dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(70, dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
			}
			StringBuilder stringBuilder = RstShared.StringBuilder;
			if (damage.shipDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to armor"), damage.shipDmg, weapon.magazineSize);
			if (damage.moduleDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to modules"), damage.moduleDmg, weapon.magazineSize);
			if (damage.shieldDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to shields"), damage.shieldDmg, weapon.magazineSize);
			groupedDmgTextHover.HoverText = (stringBuilder.Length <= 0) ? null : stringBuilder.ToString(0, stringBuilder.Length - 1);
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
			SortOrder(dmgToCrewText, 100);
			SortOrder(fireChanceText, 110);
			SafeUpdateField(120, empOverloadText, damage.moduleOverloadSeconds, ref prevEMPoverload, LocalizedEMP + " " + "{0:0}" + LocalizedS);
			SortOrder(empOverloadText, 120);
			SafeUpdateField(130, crewText, weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? $"{FFU_BE_Defs.GetIntruderCountFromName(m) * 2f:0} ~ {FFU_BE_Defs.GetIntruderCountFromName(m) * 5f:0} {Core.TT("Units")}" : null);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doNukeHovers) {
				UpdateHoverFlags(doNukeHovers: true);
				weaponTracksTargetHover.HoverText = $"{Localization.TT("Shows if capital missile has tracking and homing capabilities.")}";
				weaponIgnoresShieldHover.HoverText = $"{Localization.TT("Shows if capital missile completely bypasses shields.")}";
				weaponNeverDeflectsHover.HoverText = $"{Localization.TT("Shows if capital missile is affected by target's deflective properties.")}";
				sensorSectorRadarRangeHover.HoverText = $"{Localization.TT("Capital missile acceleration speed.")}";
				dmgAreaHover.HoverText = $"{Localization.TT("Effective area of effect at point of capital missile impact.")}";
				empOverloadHover.HoverText = $"{Localization.TT("Effective module disruption time within area of effect.")}";
				crewOpsHover.HoverText = $"{Localization.TT("Minimum and maximum troop size of capital missile with boarding capabilities.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy capital missile currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoPointDefence() {
		/// Updated Point Defense Information
			PointDefenceModule pointDefence = m.PointDefence;
			PointDefDamageDealer projectileOrBeamPrefab = pointDefence.ProjectileOrBeamPrefab;
			ResourceValueGroup resourcesPerShot = pointDefence.resourcesPerShot;
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			pointDefReloadTime.SetActiveIfNeeded();
			float pdEffReload = pointDefence.reloadInterval * gunnerySkillEffects.EffectiveSkillMultiplier(m, true);
			pointDefReloadTime.effects.text = pointDefence.reloadInterval != pdEffReload ? $"{altPreClr}{preColor}{pdEffReload / healthPercent:0.00}{LocalizedS}{aftColor}{altAftClr}" : $"{preColor}{pdEffReload / healthPercent:0.00}{LocalizedS}{aftColor}";
			pointDefReloadTime.skillBonus.text = $"-{gunnerySkillEffects.skillPointBonusPercent}% {LocalizedPer}";
			SortOrder(pointDefReloadTime, 10);
			pointDefCoverRadius.SetActiveIfNeeded();
			float pdEffRadius = pointDefence.EffectiveCoverRadius;
			pointDefCoverRadius.effects.text = pointDefence.coverRadius != pdEffRadius ? $"{altPreClr}{preColor}{pdEffRadius * 10f * healthPercent:0.0}{LocalizedM}{aftColor}{altAftClr}" : $"{preColor}{pdEffRadius * 10f * healthPercent:0.0}{LocalizedM}{aftColor}";
			pointDefCoverRadius.skillBonus.text = $"+{gunnerySkillEffects.skillPointBonusPercent}% {LocalizedPer}";
			SortOrder(pointDefCoverRadius, 20);
			SafeUpdateField(30, pointDefDmgToProjectilesText, $"{projectileOrBeamPrefab.projectileDmg:0} {LocalizedHP}/{LocalizedHit}");
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			Ship ship = m.Ship;
			SafeUpdateField(organicsPerShotText, resourcesPerShot.organics, ref prevOrganics, "{0:0}");
			SafeUpdateField(fuelPerShotText, resourcesPerShot.fuel, ref prevFuel, "{0:0}");
			SafeUpdateField(metalsPerShotText, resourcesPerShot.metals, ref prevMetals, "{0:0}");
			SafeUpdateField(syntheticsPerShotText, resourcesPerShot.synthetics, ref prevSynth, "{0:0}");
			SafeUpdateField(explosivesPerShotText, resourcesPerShot.explosives, ref prevExpl, "{0:0}");
			SafeUpdateField(exoticsPerShotText, resourcesPerShot.exotics, ref prevExotics, "{0:0}");
			DoRequirementColor(organicsPerShotText, organicsPerShot, ship == null || ship.Organics >= resourcesPerShot.organics);
			DoRequirementColor(fuelPerShotText, fuelPerShot, ship == null || ship.Fuel >= resourcesPerShot.fuel);
			DoRequirementColor(metalsPerShotText, metalsPerShot, ship == null || ship.Metals >= resourcesPerShot.metals);
			DoRequirementColor(syntheticsPerShotText, syntheticsPerShot, ship == null || ship.Synthetics >= resourcesPerShot.synthetics);
			DoRequirementColor(explosivesPerShotText, explosivesPerShot, ship == null || ship.Explosives >= resourcesPerShot.explosives);
			DoRequirementColor(exoticsPerShotText, exoticsPerShot, ship == null || ship.Exotics >= resourcesPerShot.exotics);
			if (!doPointDefHovers) {
				UpdateHoverFlags(doPointDefHovers: true);
				pointDefReloadTime.hoverable.HoverText = $"{Localization.TT("Effective reload time of a point defense between shots.")}";
				pointDefCoverRadius.hoverable.HoverText = $"{Localization.TT("Effective cover radius of a point defense where it can intercept incoming projectiles.")}";
				pointDefDmgToProjectilesHover.HoverText = $"{Localization.TT("Shows how much damage per hit point defense does to incoming projectiles.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows efficiency of your anti-asteroid defenses at hazardous and volatile locations.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy point defense currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoEngine() {
		/// Updated Engine Information
			EngineModule engine = m.Engine;
			SafeUpdateField(10, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(20, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(30, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(40, fireChanceText, $"+{preColor}{engine.overchargeEvasionAdd * healthPercent:0} °/{LocalizedMin}{aftColor}");
			SafeUpdateField(50, empOverloadText, $"-{m.overchargePowerNeed:0} {LocalizedGWh}");
			SafeUpdateField(60, medbayHealSpeedText, $"{m.overchargeSeconds:0}{LocalizedS}");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (m.HasFullHealth) DoResourceConsPerDist(engine.ConsumedPerDistance, m);
			else {
				DoResourceConsPerDist(engine.ConsumedPerDistance * (1f / healthPercent), m);
				DoRequirementColor(organicsPerDistText, null, false);
				DoRequirementColor(fuelPerDistText, null, false);
				DoRequirementColor(metalsPerDistText, null, false);
				DoRequirementColor(syntheticsPerDistText, null, false);
				DoRequirementColor(explosivesPerDistText, null, false);
				DoRequirementColor(exoticsPerDistText, null, false);
				DoRequirementColor(creditsPerDistText, null, false);
			}
			if (!doEngineHovers) {
				UpdateHoverFlags(doEngineHovers: true);
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase engine provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows asteroid evasion efficiency increase that engine provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase engine provides to the ship.")}";
				fireChanceHover.HoverText = $"{Localization.TT("Maneuverability and evasive capabilities increase from active overcharge.")}";
				empOverloadHover.HoverText = $"{Localization.TT("Engine additional power consumption during overcharge.")}";
				medbayHealSpeedHover.HoverText = $"{Localization.TT("Engine overcharge effective time.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the engine.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase engine provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy engine currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoResourcePack() {
		/// Update Resource Pack Information
			SafeUpdateField(10, organicsContCurText, (m.scrapGet.organics > 0) ? $"+{m.scrapGet.organics:0}" : null);
			SafeUpdateField(20, fuelContCurText, (m.scrapGet.fuel > 0) ? $"+{m.scrapGet.fuel:0}" : null);
			SafeUpdateField(30, metalsContCurText, (m.scrapGet.metals > 0) ? $"+{m.scrapGet.metals:0}" : null);
			SafeUpdateField(40, syntheticsContCurText, (m.scrapGet.synthetics > 0) ? $"+{m.scrapGet.synthetics:0}" : null);
			SafeUpdateField(50, explosivesContCurText, (m.scrapGet.explosives > 0) ? $"+{m.scrapGet.explosives:0}" : null);
			SafeUpdateField(60, exoticsContCurText, (m.scrapGet.exotics > 0) ? $"+{m.scrapGet.exotics:0}" : null);
			if (!doResPackHovers) {
				UpdateHoverFlags(doResPackHovers: true);
				organicsContCurHover.HoverText = $"{Localization.TT("Shows how much organic substances contained in a resource package.")}";
				fuelContCurHover.HoverText = $"{Localization.TT("Shows how much high energy starfuel contained in a resource package.")}";
				metalsContCurHover.HoverText = $"{Localization.TT("Shows how much metals and composites contained in a resource package.")}";
				syntheticsContCurHover.HoverText = $"{Localization.TT("Shows how much synthetic compounds contained in a resource package.")}";
				explosivesContCurHover.HoverText = $"{Localization.TT("Shows how much explosive materials contained in a resource package.")}";
				exoticsContCurHover.HoverText = $"{Localization.TT("Shows how much rare & exotic matter contained in a resource package.")}";
			}
		}
		[MonoModReplace] private void DoSensor() {
		/// Updated Sensor Information
			SensorModule sensor = m.Sensor;
			SafeUpdateField(10, dmgAreaText, m.starmapStealthDetectionLevelMax > 0 ? $"<color=lime><size=16>{FFU_BE_Mod_Information.GetStealthDetectionText(m.starmapStealthDetectionLevelMax)}</size></color>" : null);
			if (sensor.starmapRadarRange != 0) {
				sensorStarmapRadarRange.SetActiveIfNeeded();
				SensorSkillEffects sensorSkillEffects = WorldRules.Instance.sensorSkillEffects;
				float starRadRng = sensor.starmapRadarRange * sensorSkillEffects.EffectiveSkillMultiplier(m, false);
				sensorStarmapRadarRange.effects.text = sensor.starmapRadarRange != starRadRng ? $" {altPreClr}{preColor}<size=18>{starRadRng * healthPercent:0}{LocalizedRu}</size>{aftColor}{altAftClr}" : $" {preColor}<size=18>{starRadRng * healthPercent:0}{LocalizedRu}</size>{aftColor}";
				sensorStarmapRadarRange.skillBonus.text = $"+{sensorSkillEffects.skillPointBonusPercent}% {LocalizedPer}";
				sensorStarmapRadarRange.hoverable.HoverText = string.Format(MonoBehaviourExtended.TT("Starmap radar range.\nShip will use max value if multiple sensors are present.\nIncreased by sensor skill(+{0}% per operator sensor skill point)"), sensorSkillEffects.skillPointBonusPercent);
				SortOrder(sensorStarmapRadarRange, 20);
			}
			SafeUpdateField(30, sensorSectorRadarRange, sensor.sectorRadarRange > 0 ? $"{preColor}{sensor.sectorRadarRange * healthPercent:0}{LocalizedRu}{aftColor}" : null);
			SafeUpdateField(40, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doSensorHovers) {
				UpdateHoverFlags(doSensorHovers: true);
				sensorStarmapRadarRange.hoverable.HoverText = $"{Localization.TT("Shows active sensor array range that reveals accurate information about objects around your ship.")}";
				sensorSectorRadarRangeHover.HoverText = $"{Localization.TT("Shows passive sensor array range that reveals approximate information about entities in detected star systems.")}";
				dmgAreaHover.HoverText = $"{Localization.TT("Shows sensor array's effective anti-stealth capabilities that reveal hidden points of interest within active range.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of sensor array's built-in targeting systems that increase accuracy of all ship weapons.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy sensor array currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoBridge() {
		/// Updated Bridge Information
			bridgeRemoteOpsGo.SetActive(true);
			bridgeEvasion.SetActiveIfNeeded();
			BridgeSkillEffects bridgeSkillEffects = WorldRules.Instance.bridgeSkillEffects;
			int bridgeEva = bridgeSkillEffects.EffectiveSkillBonusPercent(m);
			bridgeEvasion.effects.text = (m.shipEvasionPercentAdd != bridgeEva) ? $"{altPreClr}{preColor}{m.shipEvasionPercentAdd + bridgeEva * healthPercent:0} °/{LocalizedMin}{aftColor}{altAftClr}" : $"{preColor}{m.shipEvasionPercentAdd + bridgeEva * healthPercent:0} °/{LocalizedMin}{aftColor}";
			bridgeEvasion.skillBonus.text = string.Format("+{0} {1}", bridgeSkillEffects.skillPointBonusPercent, LocalizedPer);
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Officers")}</size>");
			SortOrder(bridgeRemoteOpsGo, 20);
			SortOrder(bridgeEvasion, 30);
			SafeUpdateField(40, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doBridgeHovers) {
				UpdateHoverFlags(doBridgeHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows current occupancy and limit of how much crewmembers can operate bridge at the same time.")}";
				bridgeRemoteOpsHover.HoverText = $"{Localization.TT("Shows if bridge allows to control remotely unmanned modules that require operators.")}";
				bridgeEvasion.hoverable.HoverText = $"{Localization.TT("Shows by how much operating crew increases maneuverability and evasive capabilities of the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of birdge targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the bridge.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase bridge provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy bridge currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoShieldGen() {
		/// Updated Shields Information
			ShieldModule shieldGen = m.ShieldGen;
			ShieldSkillEffects shieldSkillEffects = WorldRules.Instance.shieldSkillEffects;
			if (shieldGen.reloadInterval != 0f) {
				shieldReloadTime.SetActiveIfNeeded();
				float shieldNum = shieldGen.reloadInterval * shieldSkillEffects.EffectiveSkillMultiplier(m, true);
				shieldReloadTime.effects.text = (shieldGen.reloadInterval != shieldNum) ? $"{altPreClr}{preColor}{shieldNum / healthPercent:0.00} {LocalizedS}/{LocalizedSP}{aftColor}{altAftClr}" : $"{preColor}{shieldNum / healthPercent:0.00}{aftColor} {LocalizedS}/{LocalizedSP}";
				shieldReloadTime.skillBonus.text = string.Format("-{0}% {1}", shieldSkillEffects.skillPointBonusPercent, LocalizedPer);
				SortOrder(shieldReloadTime, 10);
			}
			SafeUpdateField(20, sMaxShieldBonusText, m.HasFullHealth ? shieldGen.maxShieldAdd : shieldGen.maxShieldAdd * healthPercent, ref prevShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(30, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(40, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(50, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doShieldHovers) {
				UpdateHoverFlags(doShieldHovers: true);
				shieldReloadTime.hoverable.HoverText = $"{Localization.TT("Shows how much time it takes for shield generator to restore a single shield point.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that shield module provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase shield module provides to the ship.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows shield capacity of the shield generators and shield capacitors.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase shield module provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy shield module currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoWarp() {
		/// Updated Warp Drive Information
			Ship ship = m.Ship;
			WarpModule warp = m.Warp;
			SafeUpdateField(warpActivationFuelText, warp.activationFuel, ref prevActivationFuel);
			DoRequirementColor(warpActivationFuelText, warpActivationFuel, ship == null || ship.Fuel >= warp.activationFuel);
			WarpSkillEffects warpSkillEffects = WorldRules.Instance.warpSkillEffects;
			warpReloadTime.SetActiveIfNeeded();
			float warpNum = warp.reloadInterval * warpSkillEffects.EffectiveSkillMultiplier(m, true);
			warpReloadTime.effects.text = warp.reloadInterval != warpNum ? $"{altPreClr}{preColor}{warpNum / Mathf.Pow(healthPercent, 2):0.00}{LocalizedS}{aftColor}{altAftClr}" : $"{preColor}{warpNum / Mathf.Pow(healthPercent, 2):0.00}{LocalizedS}{aftColor}";
			warpReloadTime.skillBonus.text = string.Format("-{0}% {1}", warpSkillEffects.skillPointBonusPercent, LocalizedPer);
			SortOrder(warpReloadTime, 10);
			SafeUpdateField(220, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(240, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(260, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doWarpHovers) {
				UpdateHoverFlags(doWarpHovers: true);
				warpReloadTime.hoverable.HoverText = $"{Localization.TT("Shows how much time warp drive needs to spool up before initiating jump.")}";
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase warp drive provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that warp drive provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase warp drive provides to the ship.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the warp drive.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase warp drive provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy warp drive currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoReactor() {
		/// Updated Reactor Information
			ReactorModule reactor = m.Reactor;
			bool isOvercharged = m.IsOvercharged;
			int reactorNum = isOvercharged ? reactor.powerCapacity + reactor.overchargePowerCapacityAdd : reactor.powerCapacity;
			string rPreClr = isOvercharged ? "<color=lime>" : null;
			string rAftClr = isOvercharged ? "</color>" : null;
			SafeUpdateField(10, reactorPowerProdText, $"{rPreClr}{preColor}{reactorNum * healthPercent:0} {LocalizedGWh}{aftColor}{rAftClr}");
			SafeUpdateField(20, empOverloadText, $"+{reactor.overchargePowerCapacityAdd:0} {LocalizedGWh}");
			SafeUpdateField(30, medbayHealSpeedText, $"{m.overchargeSeconds:0}{LocalizedS}");
			SafeUpdateField(260, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			DoResourceConsPerDist(reactor.ConsumedPerDistance, m);
			if (!doReactorHovers) {
				UpdateHoverFlags(doReactorHovers: true);
				reactorPowerProdHover.HoverText = $"{Localization.TT("Shows reactor's current effective power output.")}";
				empOverloadHover.HoverText = $"{Localization.TT("Shows reactor power output bonus with active overcharge.")}";
				medbayHealSpeedHover.HoverText = $"{Localization.TT("Shows reactor overcharge effective time.")}";
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase reactor provides to the ship.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the reactor.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase reactor provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy reactor currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoMedbay() {
		/// Updated Health Bay Information
			Ship ship = m.Ship;
			MedbayModule medbay = m.Medbay;
			int orgPerHp = (int)medbay.resourcesPerHp.organics;
			int synPerHp = (int)medbay.resourcesPerHp.synthetics;
			SafeUpdateField(10, medbayHealSpotsText, $"<size=16>{CrewmemberTypesText(medbay.acceptCrewTypes)}</size>");
			SafeUpdateField(20, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Patients")}</size>");
			SafeUpdateField(30, medbayHealSpeedText, m.HasFullHealth ? medbay.secondsPerHp : medbay.secondsPerHp / Mathf.Pow(healthPercent, 2), ref prevHealingInvSpeed, preColor + "{0:0.00}" + LocalizedS + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			PlayerData playerData = PlayerDatas.Get(m.Ownership.GetOwner());
			SafeUpdateField(medbayOrganicsPerHpText, orgPerHp, ref prevOrganicsPerHp);
			SafeUpdateField(medbaySyntheticsPerHpText, synPerHp, ref prevSyntheticsPerHp);
			DoRequirementColor(medbayOrganicsPerHpText, medbayOrganicsPerHp, ship == null || playerData == null || playerData.Organics.Total >= orgPerHp);
			DoRequirementColor(medbaySyntheticsPerHpText, medbaySyntheticsPerHp, ship == null || playerData == null || playerData.Synthetics.Total >= synPerHp);
			if (!doHealthBayHovers) {
				UpdateHoverFlags(doHealthBayHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows current occupancy and limit of how much patients can be serviced at the same time.")}";
				medbayHealSpotsHover.HoverText = $"{Localization.TT("Shows what types of crewmembers health bay can service.")}";
				medbayHealSpeedHover.HoverText = $"{Localization.TT("Shows how much time it takes for a health bay to heal single health point of a crewmember.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the health bay.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase health bay provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy health bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoMaterialsConverter() {
		/// Updated Converter Information
			MaterialsConverterModule materialsConverter = m.MaterialsConverter;
			int availableRecipes = Mathf.Min(materialsConverter.produceRecipes.Length, materialsConverter.consumeRecipes.Length);
			for (int recipeNum = 0; recipeNum < availableRecipes; recipeNum++) {
				string recipeCost = $"{DoConverterRecipeCost(materialsConverter.consumeRecipes[recipeNum])}";
				float prodAmt = 100f * materialsConverter.currentEfficiency * (m.HasFullHealth ? 1f : FFU_BE_Defs.GetHealthPercent(m));
				if (materialsConverter.produceRecipes[recipeNum].organics > 0) SafeUpdateField(10, organicsProdText, $"<size=15>{preColor}{prodAmt:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].fuel > 0) SafeUpdateField(20, fuelProdText, $"<size=15>{preColor}{prodAmt:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].metals > 0) SafeUpdateField(30, metalsProdText, $"<size=15>{preColor}{prodAmt:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].synthetics > 0) SafeUpdateField(40, syntheticsProdText, $"<size=15>{preColor}{prodAmt:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].explosives > 0) SafeUpdateField(50, explosivesProdText, $"<size=15>{preColor}{prodAmt:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].exotics > 0) SafeUpdateField(60, exoticsProdText, $"<size=15>{preColor}{prodAmt / 10:0.#}: {recipeCost}{aftColor}</size>");
				if (materialsConverter.produceRecipes[recipeNum].credits > 0) SafeUpdateField(70, creditsProdText, $"<size=15>{preColor}{prodAmt * 10:0.#}: {recipeCost}{aftColor}</size>");
			}
			SafeUpdateField(100, medbayHealSpeedText, $"{materialsConverter.maxWarmUpPoints:0}{LocalizedS}");
			SafeUpdateField(110, dmgAreaText, $"{materialsConverter.maxWarmUpPoints / materialsConverter.warmUpDissipation:0}{LocalizedS}");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doConverterHovers) {
				UpdateHoverFlags(doConverterHovers: true);
				organicsProdHover.HoverText = $"{Localization.TT("Shows how much organics material converter produces per minute, if active.")}";
				fuelProdHover.HoverText = $"{Localization.TT("Shows how much starfuel material converter produces per minute, if active.")}";
				metalsProdHover.HoverText = $"{Localization.TT("Shows how much metal material converter produces per minute, if active.")}";
				syntheticsProdHover.HoverText = $"{Localization.TT("Shows how much synthetics material converter produces per minute, if active.")}";
				explosivesProdHover.HoverText = $"{Localization.TT("Shows how much explosives material converter produces per minute, if active.")}";
				exoticsProdHover.HoverText = $"{Localization.TT("Shows how much exotics material converter produces per minute, if active.")}";
				creditsProdHover.HoverText = $"{Localization.TT("Shows how much credits material converter generates per minute, if active.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the materials converter.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase materials converter provides to the ship.")}";
				medbayHealSpeedHover.HoverText = $"{Localization.TT("Shows how much time it takes for converter to warm-up from 0% to 100% efficiency.")}";
				dmgAreaHover.HoverText = $"{Localization.TT("Shows how much time it takes for converter to dissipate efficiency from 100% to 0%, when powered off.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy materials converter currently emits and by how much it inflates ship's signature.")}";
				exoticsContCurHover.HoverText = exoticsProdHover.HoverText;
			}
		}
		[MonoModReplace] private void DoFighter() {
		/// Updated Fighter Bay Information
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doFighterHovers) {
				UpdateHoverFlags(doFighterHovers: true);
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase fighter bay provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that fighter bay provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase fighter bay provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of fighter bay targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the fighter bay.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase fighter bay provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy fighter bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoContainer() {
		/// Updated Resource Storage Information
			ContainerModule container = m.Container;
			int organics = container.Organics;
			int fuel = container.Fuel;
			int metals = container.Metals;
			int synthetics = container.Synthetics;
			int explosives = container.Explosives;
			int exotics = container.Exotics;
			int maxOrganics = container.MaxOrganics;
			int maxFuel = container.MaxFuel;
			int maxMetals = container.MaxMetals;
			int maxSynthetics = container.MaxSynthetics;
			int maxExplosives = container.MaxExplosives;
			int maxExotics = container.MaxExotics;
			SafeUpdateField(10, organicsContCurText, (maxOrganics == 0) ? null : (organics + " / " + maxOrganics));
			SafeUpdateField(20, fuelContCurText, (maxFuel == 0) ? null : (fuel + " / " + maxFuel));
			SafeUpdateField(30, metalsContCurText, (maxMetals == 0) ? null : (metals + " / " + maxMetals));
			SafeUpdateField(40, syntheticsContCurText, (maxSynthetics == 0) ? null : (synthetics + " / " + maxSynthetics));
			SafeUpdateField(50, explosivesContCurText, (maxExplosives == 0) ? null : (explosives + " / " + maxExplosives));
			SafeUpdateField(60, exoticsContCurText, (maxExotics == 0) ? null : (exotics + " / " + maxExotics));
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doContainerHovers) {
				UpdateHoverFlags(doContainerHovers: true);
				organicsContCurHover.HoverText = $"{Localization.TT("Shows how much organic substances can be stored in a container.")}";
				fuelContCurHover.HoverText = $"{Localization.TT("Shows how much high energy starfuel can be stored in a container.")}";
				metalsContCurHover.HoverText = $"{Localization.TT("Shows how much metals and composites can be stored in a container.")}";
				syntheticsContCurHover.HoverText = $"{Localization.TT("Shows how much synthetic compounds can be stored in a container.")}";
				explosivesContCurHover.HoverText = $"{Localization.TT("Shows how much explosive materials can be stored in a container.")}";
				exoticsContCurHover.HoverText = $"{Localization.TT("Shows how much rare & exotic matter can be stored in a container.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the container.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase container provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy container currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoStorageContainer() {
		/// Updated Module Storage Information
			storageSizeText.alignment = TextAnchor.MiddleLeft;
			SafeUpdateField(10, storageSizeText, m.Storage.slotCount.ToString());
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doStorageHovers) {
				UpdateHoverFlags(doStorageHovers: true);
				storageSizeHover.HoverText = $"{Localization.TT("Shows how much modules can be stored in the module storage compartment.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the module storage compartment.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase module storage compartment provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy module storage compartment currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoGarden() {
		/// Updated Greenhouse Information
			GardenModule farm = m.GardenModule;
			ResourceValueGroup farmSkillProd = farm.producedPerSkillPoint;
			ResourceValueGroup farmProdPerDist = farm.ProducedPerDistance;
			removesOpResCons.SetActive(true);
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Farmers")}</size>");
			SortOrder(removesOpResCons, 20);
			SafeUpdateField(30, creditsProdText, farmSkillProd.credits > 0 ? $"{(farmProdPerDist.credits > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.credits * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.credits > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(40, organicsProdText, farmSkillProd.organics > 0 ? $"{(farmProdPerDist.organics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.organics * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.organics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(50, fuelProdText, farmSkillProd.fuel > 0 ? $"{(farmProdPerDist.fuel > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.fuel * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.fuel > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(60, metalsProdText, farmSkillProd.metals > 0 ? $"{(farmProdPerDist.metals > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.metals * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.metals > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(70, syntheticsProdText, farmSkillProd.synthetics > 0 ? $"{(farmProdPerDist.synthetics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.synthetics * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.synthetics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(80, explosivesProdText, farmSkillProd.explosives > 0 ? $"{(farmProdPerDist.explosives > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.explosives * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.explosives > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(90, exoticsProdText, farmSkillProd.exotics > 0 ? $"{(farmProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.exotics * 100:0.#}/100{LocalizedRu}{aftColor}{(farmProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(100, gardenOrganicsProdBonusText, $" {farm.producedPerSkillPoint.organics:0.0}/100{LocalizedRu} /");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doGardenHovers) {
				UpdateHoverFlags(doGardenHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows current occupancy and limit of how much farmers can work in the greenhouse at the same time.")}";
				removesOpResConsHover.HoverText = $"{Localization.TT("Shows if working in a greenhouse resolves food consumption issues for farmers.")}";
				organicsProdHover.HoverText = $"{Localization.TT("Shows how much organics greenhouse produces per 100ru of travel.")}";
				fuelProdHover.HoverText = $"{Localization.TT("Shows how much starfuel greenhouse produces per 100ru of travel.")}";
				metalsProdHover.HoverText = $"{Localization.TT("Shows how much metal greenhouse produces per 100ru of travel.")}";
				syntheticsProdHover.HoverText = $"{Localization.TT("Shows how much synthetics greenhouse produces per 100ru of travel.")}";
				explosivesProdHover.HoverText = $"{Localization.TT("Shows how much explosives greenhouse produces per 100ru of travel.")}";
				exoticsProdHover.HoverText = $"{Localization.TT("Shows how much exotics greenhouse produces per 100ru of travel.")}";
				creditsProdHover.HoverText = $"{Localization.TT("Shows how much credits greenhouse generates per 100ru of travel.")}";
				gardenOrganicsProdBonusHover.HoverText = $"{Localization.TT("Shows by how much greenhouse increases organics output per each gardening skill point for 100ru of travel.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the greenhouse.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase greenhouse provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy greenhouse currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoResearch() {
		/// Updated Laboratory Information
			ResearchModule lab = m.Research;
			ResourceValueGroup labSkillProd = lab.producedPerSkillPoint;
			ResourceValueGroup labProdPerDist = lab.ProducedPerDistance;
			ResourceValueGroup laboratoryOutput = !m.IsPacked ? labProdPerDist * 100 : labSkillProd;
			float researchSpeed = FFU_BE_Defs.GetResearchFromRVG(laboratoryOutput) * FFU_BE_Defs.tierResearchSpeedMult;
			float reversingSpeed = FFU_BE_Defs.GetReverseFromRVG(laboratoryOutput) * FFU_BE_Defs.moduleResearchSpeedMult;
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Scientists")}</size>");
			SafeUpdateField(20, sEvasionBonusText, $"{researchSpeed * 100f:0.0##}/100{LocalizedRu}");
			SafeUpdateField(30, sAccuracyBonusText, $"<size=18>{reversingSpeed * 100f:0.0##}/100{LocalizedRu}</size>");
			SafeUpdateField(40, creditsProdText, labSkillProd.credits > 0 ? $"{(labProdPerDist.credits > 0 ? altPreClr : null)}{preColor}{labProdPerDist.credits * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.credits > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(50, organicsProdText, labSkillProd.organics > 0 ? $"{(labProdPerDist.organics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.organics * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.organics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(60, fuelProdText, labSkillProd.fuel > 0 ? $"{(labProdPerDist.fuel > 0 ? altPreClr : null)}{preColor}{labProdPerDist.fuel * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.fuel > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(70, metalsProdText, labSkillProd.metals > 0 ? $"{(labProdPerDist.metals > 0 ? altPreClr : null)}{preColor}{labProdPerDist.metals * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.metals > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(80, syntheticsProdText, labSkillProd.synthetics > 0 ? $"{(labProdPerDist.synthetics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.synthetics * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.synthetics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(90, explosivesProdText, labSkillProd.explosives > 0 ? $"{(labProdPerDist.explosives > 0 ? altPreClr : null)}{preColor}{labProdPerDist.explosives * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.explosives > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(100, exoticsProdText, labSkillProd.exotics > 0 ? $"{(labProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.exotics * 100:0.#}/100{LocalizedRu}{aftColor}{(labProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(110, researchCreditsProdBonusText, $" {lab.producedPerSkillPoint.credits:0.0}/100{LocalizedRu} /");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doResearchHovers) {
				UpdateHoverFlags(doResearchHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows current occupancy and limit of how much scientists can work in the laboratory at the same time.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows by how much laboratory currently increases technology research progress for 100ru of travel.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows by how much laboratory currently increases reverse engineering progress for 100ru of travel.")}";
				organicsProdHover.HoverText = $"{Localization.TT("Shows how much organics laboratory produces per 100ru of travel.")}";
				fuelProdHover.HoverText = $"{Localization.TT("Shows how much starfuel laboratory produces per 100ru of travel.")}";
				metalsProdHover.HoverText = $"{Localization.TT("Shows how much metal laboratory produces per 100ru of travel.")}";
				syntheticsProdHover.HoverText = $"{Localization.TT("Shows how much synthetics laboratory produces per 100ru of travel.")}";
				explosivesProdHover.HoverText = $"{Localization.TT("Shows how much explosives laboratory produces per 100ru of travel.")}";
				exoticsProdHover.HoverText = $"{Localization.TT("Shows how much exotics laboratory produces per 100ru of travel.")}";
				creditsProdHover.HoverText = $"{Localization.TT("Shows how much credits laboratory generates per 100ru of travel.")}";
				researchCreditsProdBonusHover.HoverText = $"{Localization.TT("Shows by how much laboratory increases credits output per each science skill point for 100ru of travel.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the laboratory.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase laboratory provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy laboratory currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoCryosleep() {
		/// Updated Cryosleep Information
			CryosleepModule cryo = m.Cryosleep;
			removesOpResCons.SetActive(true);
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Occupied")}</size>");
			SortOrder(removesOpResCons, 20);
			SafeUpdateField(30, medbayHealSpotsText, cryo.healOneCrewHp ? $"{preColor}{cryo.healOneCrewHpDistance.minValue / healthPercent:0}{LocalizedRu} ~ {cryo.healOneCrewHpDistance.maxValue / healthPercent:0}{LocalizedRu}{aftColor}" : null);
			SafeUpdateField(40, sensorSectorRadarRange, cryo.genDreamCredits ? $"{preColor}{cryo.genDreamCreditsDistance.minValue / healthPercent:0}{LocalizedRu} ~ {cryo.genDreamCreditsDistance.maxValue / healthPercent:0}{LocalizedRu}{aftColor}" : null);
			SafeUpdateField(50, creditsProdText, cryo.genDreamCredits ? $"{preColor}${cryo.creditsPerDream.minValue * healthPercent:0.#} ~ ${cryo.creditsPerDream.maxValue * healthPercent:0.#}{aftColor}" : null);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doCryosleepHovers) {
				UpdateHoverFlags(doCryosleepHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows current occupancy and limit of how much crewmembers can be put into cryosleep at the same time.")}";
				removesOpResConsHover.HoverText = $"{Localization.TT("Shows if sleeping in cryopods prevents food consumption for crewmembers.")}";
				medbayHealSpotsHover.HoverText = $"{Localization.TT("Shows approximate travel distance required to heal a single health point of crewmember in cryosleep.")}";
				sensorSectorRadarRangeHover.HoverText = $"{Localization.TT("Shows approximate travel distance required to record a full cryo-dream of crewmember in cryosleep.")}";
				creditsProdHover.HoverText = $"{Localization.TT("Shows approximate amount of generated credits, when cryo-dream of a crewmember in cryosleep is recorded and compiled.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the cryosleep bay.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase cryosleep bay provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy cryosleep bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoStealthDecryptorSensor() {
		/// Updated Stealth Generator Information
			SafeUpdateField(10, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, altPreClr + preColor + "{0:0.#} " + LocalizedM + "³" + aftColor + altAftClr);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			if (!doStealthHovers) {
				UpdateHoverFlags(doStealthHovers: true);
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("Shows by how much stealth generator reduces ship's signature.")}";
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase stealth generator provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that stealth generator provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase stealth generator provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of stealth generator targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the stealth generator.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase stealth generator provides to the ship.")}";
			}
		}
		[MonoModReplace] private void DoPassiveECM() {
		/// Updated Countermeasure Arrays Information
			SafeUpdateField(10, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, altPreClr + preColor + "{0:0.#} " + LocalizedM + "³" + aftColor + altAftClr);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			if (!doPassiveHovers) {
				UpdateHoverFlags(doPassiveHovers: true);
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("Shows by how much countermeasure module reduces ship's signature.")}";
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase countermeasure module provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that countermeasure module provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase countermeasure module provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of countermeasure module targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the countermeasure module.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase countermeasure module provides to the ship.")}";
			}
		}
		[MonoModReplace] private void DoIntegrity() {
		/// Updated Starship Armor Information
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doIntegrityHovers) {
				UpdateHoverFlags(doIntegrityHovers: true);
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase armor provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that armor provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase armor provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of armor targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the armor module.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase armor provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy armor currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoDecoy() {
		/// Updated Decoy Modules Information
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doDecoyHovers) {
				UpdateHoverFlags(doDecoyHovers: true);
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase decoy module provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that decoy module provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase decoy module provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of decoy module targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the decoy module.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase decoy module provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy decoy module currently emits and by how much it inflates ship's signature.")}";
			}
		}
		[MonoModReplace] private void DoOther() {
		/// Updated Other Modules Information
			storageSizeText.alignment = TextAnchor.UpperLeft;
			SafeUpdateField(10, crewText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheSets(m) > 0 ? $"{FFU_BE_Mod_Information.GetCacheSets(m)} <size=16>{Localization.TT("Sets")}</size>" : null);
			SafeUpdateField(20, medbayHealSpotsText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheHPIncrease(m) > 0 ? $"+{FFU_BE_Mod_Information.GetCacheHPIncrease(m)} <size=16>{Localization.TT("Increase")}</size>" : null);
			SafeUpdateField(30, dmgToCrewText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheHPLimit(m) > 0 ? $"{FFU_BE_Mod_Information.GetCacheHPLimit(m)} <size=16>{Localization.TT("Limit")}</size>" : null);
			if (m.Ownership.GetOwner() == Ownership.Owner.Me) SafeUpdateField(40, pointDefDmgToProjectilesText, FFU_BE_Mod_Information.IsCacheModule(m) && !FFU_BE_Mod_Information.GetCacheWeapons(m).IsEmpty() ? $"<size=14>{GetSelectedWeapon()}</size>" : null);
			SafeUpdateField(50, storageSizeText, FFU_BE_Mod_Information.IsCacheModule(m) && !FFU_BE_Mod_Information.GetCacheWeapons(m).IsEmpty() ? $"<size=14>{string.Join("\n", FFU_BE_Mod_Information.GetCacheWeapons(m, " "))}</size>" : null);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + LocalizedRu + "/" + LocalizedS + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + LocalizedMin + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + LocalizedM + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + LocalizedSP + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + LocalizedHP);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + LocalizedM + "³");
			if (!doOtherHovers) {
				UpdateHoverFlags(doOtherHovers: true);
				crewOpsHover.HoverText = $"{Localization.TT("Shows how much equipment or upgrade sets cache contains.")}";
				medbayHealSpotsHover.HoverText = $"{Localization.TT("Shows health points increase amount cache will provide to crewmembers, when applied.")}";
				dmgToCrewTextHover.HoverText = $"{Localization.TT("Shows health points increase limit after which upgrade cache will have no effect.")}";
				pointDefDmgToProjectilesHover.HoverText = $"{Localization.TT("Shows currently selected weapon type that crewmembers will equip.\nCan be changed with PAGE UP and PAGE DOWN hotkeys.")}";
				storageSizeHover.HoverText = $"{Localization.TT("Shows list of potentials weapons that crewmembers can equip, when cache is opened.")}";
				sSpeedBonusHover.HoverText = $"{Localization.TT("Shows interstellar travel speed increase artifact provides to the ship.")}";
				sAsteroidDeflBonusHover.HoverText = $"{Localization.TT("Shows protection efficiency against asteroids that artifact provides to the ship.")}";
				sEvasionBonusHover.HoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase artifact provides to the ship.")}";
				sAccuracyBonusHover.HoverText = $"{Localization.TT("Shows efficiency of artifact targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.HoverText = $"{Localization.TT("Shows built-in shields capacity of the artifact.")}";
				sMaxHealthBonusHover.HoverText = $"{Localization.TT("Shows durability increase artifact provides to the ship.")}";
				starmapStealthDetMaxHover.HoverText = $"{Localization.TT("How much energy artifact currently emits and by how much it inflates ship's signature.")}";
			}
		}
		private string GetSelectedWeapon() {
			List<string> weaponList = FFU_BE_Mod_Crewmembers.GetWeaponDualIDsFromCacheID(m.PrefabId);
			if (!weaponList.Contains(FFU_BE_Defs.currentlySelectedWeapon) || FFU_BE_Defs.weaponSelectionCount != weaponList.Count) {
				FFU_BE_Defs.weaponSelectionCount = weaponList.Count;
				FFU_BE_Defs.weaponSelectionIndex = 0;
			}
			if (weaponList.Count > 1 && !Input.GetKeyDown(KeyCode.PageUp) && Input.GetKeyDown(KeyCode.PageDown)) {
				if (FFU_BE_Defs.weaponSelectionIndex < FFU_BE_Defs.weaponSelectionCount - 1) FFU_BE_Defs.weaponSelectionIndex++;
				else FFU_BE_Defs.weaponSelectionIndex = 0;
			}
			if (weaponList.Count > 1 && Input.GetKeyDown(KeyCode.PageUp) && !Input.GetKeyDown(KeyCode.PageDown)) {
				if (FFU_BE_Defs.weaponSelectionIndex > 0) FFU_BE_Defs.weaponSelectionIndex--;
				else FFU_BE_Defs.weaponSelectionIndex = FFU_BE_Defs.weaponSelectionCount - 1;
			}
			FFU_BE_Defs.currentlySelectedWeapon = weaponList[FFU_BE_Defs.weaponSelectionIndex];
			return FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == FFU_BE_Defs.currentlySelectedWeapon)?.displayName;
		}
		[MonoModReplace] private void DoWeaponCrewDmg(WeaponModule w, ShootAtDamageDealer.CrewDmgLevel crewDmgLevel) {
		/// Show Updated Crew Damage in Module Panel
			dmgToCrewText.transform.parent.parent.gameObject.SetActive(crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None);
			dmgToCrewTextHover.HoverText = $"{Localization.TT("Chance to damage all crewmembers within area of effect by shown amount.")}";
			string crewDmgText = w.magazineSize + "x" + w.ProjectileOrBeamPrefab.GetDamage(w).doorDmg;
			dmgToCrewText.alignment = TextAnchor.MiddleLeft;
			switch (crewDmgLevel) {
				//case ShootAtDamageDealer.CrewDmgLevel.None: SafeUpdateField(dmgToCrewText, Localization.TT("None (" + (int)Core.CrewHitChance.None + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Low: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Low + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Default: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Medium + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.High: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.High + "%)")); break;
			}
		}
		[MonoModReplace] private void DoWeaponFireChance(ShootAtDamageDealer.FireChanceLevel fireChanceLevel) {
		/// Show Update Fire Ignition Chance in Module Panel
			fireChanceText.transform.parent.parent.gameObject.SetActive(fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None);
			fireChanceHover.HoverText = $"{Localization.TT("Chance to ignite fire in every tile within area of effect.")}";
			fireChanceText.alignment = TextAnchor.MiddleLeft;
			switch (fireChanceLevel) {
				//case ShootAtDamageDealer.FireChanceLevel.None: SafeUpdateField(fireChanceText, Localization.TT("None (" + (int)Core.FireIgniteChance.None + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Low: SafeUpdateField(fireChanceText, Localization.TT("Low (" + (int)Core.FireIgniteChance.Low + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Default: SafeUpdateField(fireChanceText, Localization.TT("Medium (" + (int)Core.FireIgniteChance.Medium + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.High: SafeUpdateField(fireChanceText, Localization.TT("High (" + (int)Core.FireIgniteChance.High + "%)")); break;
			}
		}
		private string CrewmemberTypesText(Crewmember.Type[] crewTypes) {
		/// Show Serviced Crewmember Types in Module Panel
			if (crewTypes.Contains(Crewmember.Type.Regular) && crewTypes.Contains(Crewmember.Type.Drone)) return $"{Localization.TT("Drones")}/{Localization.TT("Bio")}";
			else if (crewTypes.Contains(Crewmember.Type.Regular)) return $"{Localization.TT("Biologic")}";
			else if (crewTypes.Contains(Crewmember.Type.Drone)) return $"{Localization.TT("Mechanic")}";
			else return $"{Localization.TT("Pets Only")}";
		}
		[MonoModReplace] private void DoResourceProdPerSecond(ResourceValueGroup rp, float secondsPerConversion) {
		/// Sorted Resource Production Per Second
			float organicsProd = rp.organics * 60f / secondsPerConversion;
			float fuelProd = rp.fuel * 60f / secondsPerConversion;
			float metalsProd = rp.metals * 60f / secondsPerConversion;
			float syntheticsProd = rp.synthetics * 60f / secondsPerConversion;
			float explosivesProd = rp.explosives * 60f / secondsPerConversion;
			float exoticsProd = rp.exotics * 60f / secondsPerConversion;
			float creditsProd = rp.credits * 60f / secondsPerConversion;
			SafeUpdateField(10, creditsProdText, m.HasFullHealth ? creditsProd : creditsProd * healthPercent, ref prevCredits, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(20, organicsProdText, m.HasFullHealth ? organicsProd : organicsProd * healthPercent, ref prevOrganics, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(30, fuelProdText, m.HasFullHealth ? fuelProd : fuelProd * healthPercent, ref prevFuel, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(40, metalsProdText, m.HasFullHealth ? metalsProd : metalsProd * healthPercent, ref prevMetals, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(50, syntheticsProdText, m.HasFullHealth ? syntheticsProd : syntheticsProd * healthPercent, ref prevSynth, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(60, explosivesProdText, m.HasFullHealth ? explosivesProd : explosivesProd * healthPercent, ref prevExpl, preColor + "{0:0}/" + LocalizedMin + aftColor);
			SafeUpdateField(70, exoticsContCurText, m.HasFullHealth ? exoticsProd : exoticsProd * healthPercent, ref prevExotics, preColor + "{0:0}/" + LocalizedMin + aftColor);
			//SafeUpdateField(70, exoticsProdText, m.HasFullHealth ? exoticsProd : exoticsProd * healthPercent, ref prevExotics, preColor + "{0:0}/" + LocalizedMin + aftColor);
		}
		[MonoModReplace] private void DoResourceConsPerSecond(ResourceValueGroup rc, float secondsPerConversion) {
		/// Sorted Resource Consumption Per Second
			float organicsCons = rc.organics * 60f / secondsPerConversion;
			float fuelCons = rc.fuel * 60f / secondsPerConversion;
			float metalsCons = rc.metals * 60f / secondsPerConversion;
			float syntheticsCons = rc.synthetics * 60f / secondsPerConversion;
			float explosivesCons = rc.explosives * 60f / secondsPerConversion;
			float exoticsCons = rc.exotics * 60f / secondsPerConversion;
			SafeUpdateField(110, organicsConsText, organicsCons, ref prevOrganicsCons, "{0:0}/" + LocalizedMin);
			SafeUpdateField(120, fuelConsText, fuelCons, ref prevFuelCons, "{0:0}/" + LocalizedMin);
			SafeUpdateField(130, metalsConsText, metalsCons, ref prevMetalsCons, "{0:0}/" + LocalizedMin);
			SafeUpdateField(140, syntheticsConsText, syntheticsCons, ref prevSynthCons, "{0:0}/" + LocalizedMin);
			SafeUpdateField(150, explosivesConsText, explosivesCons, ref prevExplCons, "{0:0}/" + LocalizedMin);
			SafeUpdateField(160, exoticsConsText, exoticsCons, ref prevExoticsCons, "{0:0}/" + LocalizedMin);
		}
		private string DoConverterRecipeCost(ResourceValueGroup recipe) {
			string costText = "";
			if (recipe.organics > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#79e051ff>{recipe.organics:0}</color>"; }
			if (recipe.fuel > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#e76d08ff>{recipe.fuel:0}</color>"; }
			if (recipe.metals > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#9caec6ff>{recipe.metals:0}</color>"; }
			if (recipe.synthetics > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#ecbabaff>{recipe.synthetics:0}</color>"; }
			if (recipe.explosives > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#ffd600ff>{recipe.explosives:0}</color>"; }
			if (recipe.exotics > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#ce3761ff>{recipe.exotics:0}</color>"; }
			if (recipe.credits > 0) { if (!string.IsNullOrEmpty(costText)) costText += $"/"; costText += $"<color=#c8c8c8ff>{recipe.credits:0}</color>"; }
			return costText;
		}
		private void UpdateHoverFlags(bool doWeaponHovers = false, bool doNukeHovers = false, bool doPointDefHovers = false, bool doEngineHovers = false,
		/// New Function: Components Direct Data & Properties Access
			bool doResPackHovers = false, bool doSensorHovers = false, bool doBridgeHovers = false, bool doShieldHovers = false,
			bool doWarpHovers = false, bool doReactorHovers = false, bool doHealthBayHovers = false, bool doConverterHovers = false,
			bool doFighterHovers = false, bool doContainerHovers = false, bool doStorageHovers = false, bool doCryosleepHovers = false,
			bool doGardenHovers = false, bool doResearchHovers = false, bool doStealthHovers = false, bool doPassiveHovers = false, 
			bool doIntegrityHovers = false, bool doDecoyHovers = false, bool doOtherHovers = false) {
			this.doWeaponHovers = doWeaponHovers;
			this.doNukeHovers = doNukeHovers;
			this.doPointDefHovers = doPointDefHovers;
			this.doEngineHovers = doEngineHovers;
			this.doResPackHovers = doResPackHovers;
			this.doSensorHovers = doSensorHovers;
			this.doBridgeHovers = doBridgeHovers;
			this.doShieldHovers = doShieldHovers;
			this.doWarpHovers = doWarpHovers;
			this.doReactorHovers = doReactorHovers;
			this.doHealthBayHovers = doHealthBayHovers;
			this.doConverterHovers = doConverterHovers;
			this.doFighterHovers = doFighterHovers;
			this.doContainerHovers = doContainerHovers;
			this.doStorageHovers = doStorageHovers;
			this.doCryosleepHovers = doCryosleepHovers;
			this.doGardenHovers = doGardenHovers;
			this.doResearchHovers = doResearchHovers;
			this.doStealthHovers = doStealthHovers;
			this.doPassiveHovers = doPassiveHovers;
			this.doIntegrityHovers = doIntegrityHovers;
			this.doDecoyHovers = doDecoyHovers;
			this.doOtherHovers = doOtherHovers;
		}
		private void SafeUpdateField(int sortOrder, Text text, string value) {
			bool flag = !string.IsNullOrEmpty(value);
			if (text.isActiveAndEnabled != flag) {
				text.transform.parent.parent.gameObject.SetActive(flag);
			}
			if (flag && sortOrder > 0) {
				SortOrder(text, sortOrder);
			}
			text.text = value;
		}
		private void SafeUpdateField(int sortOrder, Text text, float value, ref float prevValue, string format = "{0}") {
			bool flag = value != 0f;
			if (text.isActiveAndEnabled != flag) {
				text.transform.parent.parent.gameObject.SetActive(flag);
			}
			if (flag && sortOrder > 0) {
				SortOrder(text, sortOrder);
			}
			if (prevValue == 0f || !value.Equals(prevValue)) {
				text.text = string.Format(format, value);
				prevValue = value;
			}
		}
		private void SafeUpdateField(Text text, GameObject refObj, float value, ref float prevValue, string format = "{0}") {
			bool flag = value != 0f;
			if (refObj.activeSelf != flag) {
				refObj.SetActive(flag);
			}
			if (prevValue == 0f || !value.Equals(prevValue)) {
				text.text = string.Format(format, value);
				prevValue = value;
			}
		}
		private void SafeUpdateField(int sortOrder, Text text, GameObject refObj, float value, ref float prevValue, string format = "{0}") {
			bool flag = value != 0f;
			if (refObj.activeSelf != flag) {
				refObj.SetActive(flag);
			}
			if (flag && sortOrder > 0) {
				SortOrder(refObj, sortOrder);
			}
			if (prevValue == 0f || !value.Equals(prevValue)) {
				text.text = string.Format(format, value);
				prevValue = value;
			}
		}
		public float ModuleDataSubpanelHeightMax {
			set {
				UISetPreferredHeight refUISetPreferredHeight = transform.GetChild(1).GetChild(1).GetComponent<UISetPreferredHeight>() ?? null;
				if (refUISetPreferredHeight != null) refUISetPreferredHeight.maxHeight = value;
			}
		}
		public float ModuleDataSubpanelHeightMin {
			set {
				UISetPreferredHeight refUISetPreferredHeight = transform.GetChild(1).GetChild(1).GetComponent<UISetPreferredHeight>();
				LayoutElement refLayoutElement = refUISetPreferredHeight.GetComponent<LayoutElement>() ?? null;
				if (refLayoutElement != null) refLayoutElement.preferredHeight = value;
			}
		}
		public UISetPreferredHeight ModuleDataSubpanelUI {
			get {
				return transform.GetChild(1).GetChild(1).GetComponent<UISetPreferredHeight>();
			}
		}
		public HoverableUI cryoSleepSpotsHover {
			get {
				return cryoSleepSpotsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI cryoSleepChanceToHealHover {
			get {
				return cryoSleepChanceToHeal.transform.GetComponent<HoverableUI>();
			}
		}
		public HoverableUI cryoGenDreamCreditsHover {
			get {
				return cryoGenDreamCredits.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI medbayHealSpotsHover {
			get {
				return medbayHealSpotsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI medbayHealSpeedHover {
			get {
				return medbayHealSpeedText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI reactorPowerProdHover {
			get {
				return reactorPowerProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI weaponTracksTargetHover {
			get {
				return weaponTracksTargetGo.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI weaponIgnoresShieldHover {
			get {
				return weaponIgnoresShieldGo.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI weaponNeverDeflectsHover {
			get {
				return weaponNeverDeflectsGo.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI pointDefDmgToProjectilesHover {
			get {
				return pointDefDmgToProjectilesText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI dmgAreaHover {
			get {
				return dmgAreaText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI empOverloadHover {
			get {
				return empOverloadText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI bridgeRemoteOpsHover {
			get {
				return bridgeRemoteOpsGo.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI fuelContCurHover {
			get {
				return fuelContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI organicsContCurHover {
			get {
				return organicsContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI explosivesContCurHover {
			get {
				return explosivesContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI exoticsContCurHover {
			get {
				return exoticsContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI syntheticsContCurHover {
			get {
				return syntheticsContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI metalsContCurHover {
			get {
				return metalsContCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI fuelProdHover {
			get {
				return fuelProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI organicsProdHover {
			get {
				return organicsProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI explosivesProdHover {
			get {
				return explosivesProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI exoticsProdHover {
			get {
				return exoticsProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI syntheticsProdHover {
			get {
				return syntheticsProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI metalsProdHover {
			get {
				return metalsProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI creditsProdHover {
			get {
				return creditsProdText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI fuelConsHover {
			get {
				return fuelConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI organicsConsHover {
			get {
				return organicsConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI explosivesConsHover {
			get {
				return explosivesConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI exoticsConsHover {
			get {
				return exoticsConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI syntheticsConsHover {
			get {
				return syntheticsConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI metalsConsHover {
			get {
				return metalsConsText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI gardenOrganicsProdCurHover {
			get {
				return gardenOrganicsProdCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI gardenOrganicsProdBonusHover {
			get {
				return gardenOrganicsProdBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI researchCreditsProdCurHover {
			get {
				return researchCreditsProdCurText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI researchCreditsProdBonusHover {
			get {
				return researchCreditsProdBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI removesOpResConsHover {
			get {
				return removesOpResCons.transform.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI crewOpsHover {
			get {
				return crewText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sMaxHealthBonusHover {
			get {
				return sMaxHealthBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sSpeedBonusHover {
			get {
				return sSpeedBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sAsteroidDeflBonusHover {
			get {
				return sAsteroidDeflBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sEvasionBonusHover {
			get {
				return sEvasionBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sAccuracyBonusHover {
			get {
				return sAccuracyBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sMaxShieldBonusHover {
			get {
				return sMaxShieldBonusText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI sensorSectorRadarRangeHover {
			get {
				return sensorSectorRadarRange.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI starmapStealthDetMaxHover {
			get {
				return starmapStealthDetMaxText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI moduleDeflectionHover {
			get {
				return moduleDeflectionText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public HoverableUI storageSizeHover {
			get {
				return storageSizeText.transform.parent.parent.GetChild(0).GetComponent<HoverableUI>();
			}
		}
		public Text cryoSleepChanceToHealText {
			get {
				return cryoSleepChanceToHeal.transform.GetChild(0).GetComponent<Text>();
			}
		}
		public Text cryoGenDreamCreditsText {
			get {
				return cryoGenDreamCredits.transform.GetChild(0).GetChild(1).GetComponent<Text>();
			}
		}
		public Text weaponTracksTargetText {
			get {
				return weaponTracksTargetGo.transform.GetChild(0).GetChild(0).GetComponent<Text>();
			}
		}
		public Text weaponIgnoresShieldText {
			get {
				return weaponIgnoresShieldGo.transform.GetChild(0).GetChild(0).GetComponent<Text>();
			}
		}
		public Text weaponNeverDeflectsText {
			get {
				return weaponNeverDeflectsGo.transform.GetChild(0).GetChild(0).GetComponent<Text>();
			}
		}
		public Text bridgeRemoteOpsText {
			get {
				return bridgeRemoteOpsGo.transform.GetChild(0).GetChild(0).GetComponent<Text>();
			}
		}
		public Text removesOpResConsText {
			get {
				return removesOpResCons.transform.GetChild(0).GetChild(1).GetComponent<Text>();
			}
		}
		private static void SortOrder(ModuleEffectItem tObject, int sortOrder) {
			tObject.transform.SetSiblingIndex(sortOrder);
		}
		private static void SortOrder(GameObject tObject, int sortOrder) {
			tObject.transform.SetSiblingIndex(sortOrder);
		}
		private static void SortOrder(Text tObject, int sortOrder) {
			tObject.transform.parent.parent.SetSiblingIndex(sortOrder);
		}
		private static int SortIndex(ModuleEffectItem tObject) {
			return tObject.transform.GetSiblingIndex();
		}
		private static int SortIndex(GameObject tObject) {
			return tObject.transform.GetSiblingIndex();
		}
		private static int SortIndex(Text tObject) {
			return tObject.transform.parent.parent.GetSiblingIndex();
		}
		private void ListAllElementsIndexes() {
		/// New Function: List Index of Each Possible Element
			if (Time.frameCount % 150 != 0) return;
			Debug.LogWarning($"[cryoSleepSpotsText]: {SortIndex(cryoSleepSpotsText)}");
			Debug.LogWarning($"[cryoSleepChanceToHeal]: {SortIndex(cryoSleepChanceToHeal)}");
			Debug.LogWarning($"[cryoGenDreamCredits]: {SortIndex(cryoGenDreamCredits)}");
			Debug.LogWarning($"[medbayHealSpotsText]: {SortIndex(medbayHealSpotsText)}");
			Debug.LogWarning($"[medbayHealSpeedText]: {SortIndex(medbayHealSpeedText)}");
			Debug.LogWarning($"[reactorPowerProdText]: {SortIndex(reactorPowerProdText)}");
			Debug.LogWarning($"[weaponAttackText]: {SortIndex(weaponAttackText)}");
			Debug.LogWarning($"[weaponAccuracy]: {SortIndex(weaponAccuracy)}");
			Debug.LogWarning($"[weaponReloadTime]: {SortIndex(weaponReloadTime)}");
			Debug.LogWarning($"[weaponTracksTargetGo]: {SortIndex(weaponTracksTargetGo)}");
			Debug.LogWarning($"[weaponIgnoresShieldGo]: {SortIndex(weaponIgnoresShieldGo)}");
			Debug.LogWarning($"[weaponNeverDeflectsGo]: {SortIndex(weaponNeverDeflectsGo)}");
			Debug.LogWarning($"[pointDefCoverRadius]: {SortIndex(pointDefCoverRadius)}");
			Debug.LogWarning($"[pointDefReloadTime]: {SortIndex(pointDefReloadTime)}");
			Debug.LogWarning($"[pointDefDmgToProjectilesText]: {SortIndex(pointDefDmgToProjectilesText)}");
			Debug.LogWarning($"[dmgAreaText]: {SortIndex(dmgAreaText)}");
			Debug.LogWarning($"[fireChanceText]: {SortIndex(fireChanceText)}");
			Debug.LogWarning($"[groupedDmg]: {SortIndex(groupedDmg)}");
			Debug.LogWarning($"[groupedDmgToShield]: {SortIndex(groupedDmgToShield)}");
			Debug.LogWarning($"[groupedDmgToShip]: {SortIndex(groupedDmgToShip)}");
			Debug.LogWarning($"[groupedDmgToModule]: {SortIndex(groupedDmgToModule)}");
			//Debug.LogWarning($"[groupedDmgText]: {SortIndex(groupedDmgText)}");
			Debug.LogWarning($"[dmgToModulesText]: {SortIndex(dmgToModulesText)}");
			Debug.LogWarning($"[dmgToShipsText]: {SortIndex(dmgToShipsText)}");
			Debug.LogWarning($"[dmgToDoorsText]: {SortIndex(dmgToDoorsText)}");
			Debug.LogWarning($"[dmgToShieldsText]: {SortIndex(dmgToShieldsText)}");
			Debug.LogWarning($"[dmgToCrewText]: {SortIndex(dmgToCrewText)}");
			Debug.LogWarning($"[empOverloadText]: {SortIndex(empOverloadText)}");
			Debug.LogWarning($"[bridgeRemoteOpsGo]: {SortIndex(bridgeRemoteOpsGo)}");
			Debug.LogWarning($"[warpReloadTime]: {SortIndex(warpReloadTime)}");
			Debug.LogWarning($"[fuelContCurText]: {SortIndex(fuelContCurText)}");
			Debug.LogWarning($"[organicsContCurText]: {SortIndex(organicsContCurText)}");
			Debug.LogWarning($"[explosivesContCurText]: {SortIndex(explosivesContCurText)}");
			Debug.LogWarning($"[exoticsContCurText]: {SortIndex(exoticsContCurText)}");
			Debug.LogWarning($"[syntheticsContCurText]: {SortIndex(syntheticsContCurText)}");
			Debug.LogWarning($"[metalsContCurText]: {SortIndex(metalsContCurText)}");
			Debug.LogWarning($"[fuelProdText]: {SortIndex(fuelProdText)}");
			Debug.LogWarning($"[organicsProdText]: {SortIndex(organicsProdText)}");
			Debug.LogWarning($"[explosivesProdText]: {SortIndex(explosivesProdText)}");
			Debug.LogWarning($"[exoticsProdText]: {SortIndex(exoticsProdText)}");
			Debug.LogWarning($"[syntheticsProdText]: {SortIndex(syntheticsProdText)}");
			Debug.LogWarning($"[metalsProdText]: {SortIndex(metalsProdText)}");
			Debug.LogWarning($"[creditsProdText]: {SortIndex(creditsProdText)}");
			Debug.LogWarning($"[gardenOrganicsProdCurText]: {SortIndex(gardenOrganicsProdCurText)}");
			Debug.LogWarning($"[gardenOrganicsProdBonusText]: {SortIndex(gardenOrganicsProdBonusText)}");
			Debug.LogWarning($"[researchCreditsProdCurText]: {SortIndex(researchCreditsProdCurText)}");
			Debug.LogWarning($"[researchCreditsProdBonusText]: {SortIndex(researchCreditsProdBonusText)}");
			Debug.LogWarning($"[removesOpResCons]: {SortIndex(removesOpResCons)}");
			Debug.LogWarning($"[crewText]: {SortIndex(crewText)}");
			Debug.LogWarning($"[sMaxHealthBonusText]: {SortIndex(sMaxHealthBonusText)}");
			Debug.LogWarning($"[sSpeedBonusText]: {SortIndex(sSpeedBonusText)}");
			Debug.LogWarning($"[sAsteroidDeflBonusText]: {SortIndex(sAsteroidDeflBonusText)}");
			Debug.LogWarning($"[sEvasionBonusText]: {SortIndex(sEvasionBonusText)}");
			Debug.LogWarning($"[bridgeEvasion]: {SortIndex(bridgeEvasion)}");
			Debug.LogWarning($"[sAccuracyBonusText]: {SortIndex(sAccuracyBonusText)}");
			Debug.LogWarning($"[sMaxShieldBonusText]: {SortIndex(sMaxShieldBonusText)}");
			Debug.LogWarning($"[shieldReloadTime]: {SortIndex(shieldReloadTime)}");
			Debug.LogWarning($"[sensorSectorRadarRange]: {SortIndex(sensorSectorRadarRange)}");
			Debug.LogWarning($"[sensorStarmapRadarRange]: {SortIndex(sensorStarmapRadarRange)}");
			Debug.LogWarning($"[starmapStealthDetMaxText]: {SortIndex(starmapStealthDetMaxText)}");
			Debug.LogWarning($"[moduleDeflectionText]: {SortIndex(moduleDeflectionText)}");
			Debug.LogWarning($"[operatorSpotsText]: {SortIndex(operatorSpotsText)}");
			Debug.LogWarning($"[fuelConsText]: {SortIndex(fuelConsText)}");
			Debug.LogWarning($"[organicsConsText]: {SortIndex(organicsConsText)}");
			Debug.LogWarning($"[explosivesConsText]: {SortIndex(explosivesConsText)}");
			Debug.LogWarning($"[exoticsConsText]: {SortIndex(exoticsConsText)}");
			Debug.LogWarning($"[syntheticsConsText]: {SortIndex(syntheticsConsText)}");
			Debug.LogWarning($"[metalsConsText]: {SortIndex(metalsConsText)}");
			Debug.LogWarning($"[storageSizeText]: {SortIndex(storageSizeText)}");
		}
		private void ListAllElementsChildren() {
			if (Time.frameCount % 150 != 0) return;
			FFU_BE_Defs.GetComponentsListTree(cryoSleepSpotsText);
			FFU_BE_Defs.GetComponentsListTree(cryoSleepChanceToHeal);
			FFU_BE_Defs.GetComponentsListTree(cryoGenDreamCredits);
			FFU_BE_Defs.GetComponentsListTree(medbayHealSpotsText);
			FFU_BE_Defs.GetComponentsListTree(medbayHealSpeedText);
			FFU_BE_Defs.GetComponentsListTree(reactorPowerProdText);
			FFU_BE_Defs.GetComponentsListTree(weaponAttackText);
			FFU_BE_Defs.GetComponentsListTree(weaponAccuracy);
			FFU_BE_Defs.GetComponentsListTree(weaponReloadTime);
			FFU_BE_Defs.GetComponentsListTree(weaponTracksTargetGo);
			FFU_BE_Defs.GetComponentsListTree(weaponIgnoresShieldGo);
			FFU_BE_Defs.GetComponentsListTree(weaponNeverDeflectsGo);
			FFU_BE_Defs.GetComponentsListTree(pointDefCoverRadius);
			FFU_BE_Defs.GetComponentsListTree(pointDefReloadTime);
			FFU_BE_Defs.GetComponentsListTree(pointDefDmgToProjectilesText);
			FFU_BE_Defs.GetComponentsListTree(dmgAreaText);
			FFU_BE_Defs.GetComponentsListTree(fireChanceText);
			FFU_BE_Defs.GetComponentsListTree(groupedDmg);
			FFU_BE_Defs.GetComponentsListTree(groupedDmgToShield);
			FFU_BE_Defs.GetComponentsListTree(groupedDmgToShip);
			FFU_BE_Defs.GetComponentsListTree(groupedDmgToModule);
			//FFU_BE_Defs.GetComponentsListTree(groupedDmgText);
			FFU_BE_Defs.GetComponentsListTree(dmgToModulesText);
			FFU_BE_Defs.GetComponentsListTree(dmgToShipsText);
			FFU_BE_Defs.GetComponentsListTree(dmgToDoorsText);
			FFU_BE_Defs.GetComponentsListTree(dmgToShieldsText);
			FFU_BE_Defs.GetComponentsListTree(dmgToCrewText);
			FFU_BE_Defs.GetComponentsListTree(empOverloadText);
			FFU_BE_Defs.GetComponentsListTree(bridgeRemoteOpsGo);
			FFU_BE_Defs.GetComponentsListTree(warpReloadTime);
			FFU_BE_Defs.GetComponentsListTree(fuelContCurText);
			FFU_BE_Defs.GetComponentsListTree(organicsContCurText);
			FFU_BE_Defs.GetComponentsListTree(explosivesContCurText);
			FFU_BE_Defs.GetComponentsListTree(exoticsContCurText);
			FFU_BE_Defs.GetComponentsListTree(syntheticsContCurText);
			FFU_BE_Defs.GetComponentsListTree(metalsContCurText);
			FFU_BE_Defs.GetComponentsListTree(fuelProdText);
			FFU_BE_Defs.GetComponentsListTree(organicsProdText);
			FFU_BE_Defs.GetComponentsListTree(explosivesProdText);
			FFU_BE_Defs.GetComponentsListTree(exoticsProdText);
			FFU_BE_Defs.GetComponentsListTree(syntheticsProdText);
			FFU_BE_Defs.GetComponentsListTree(metalsProdText);
			FFU_BE_Defs.GetComponentsListTree(creditsProdText);
			FFU_BE_Defs.GetComponentsListTree(gardenOrganicsProdCurText);
			FFU_BE_Defs.GetComponentsListTree(gardenOrganicsProdBonusText);
			FFU_BE_Defs.GetComponentsListTree(researchCreditsProdCurText);
			FFU_BE_Defs.GetComponentsListTree(researchCreditsProdBonusText);
			FFU_BE_Defs.GetComponentsListTree(removesOpResCons);
			FFU_BE_Defs.GetComponentsListTree(crewText);
			FFU_BE_Defs.GetComponentsListTree(sMaxHealthBonusText);
			FFU_BE_Defs.GetComponentsListTree(sSpeedBonusText);
			FFU_BE_Defs.GetComponentsListTree(sAsteroidDeflBonusText);
			FFU_BE_Defs.GetComponentsListTree(sEvasionBonusText);
			FFU_BE_Defs.GetComponentsListTree(bridgeEvasion);
			FFU_BE_Defs.GetComponentsListTree(sAccuracyBonusText);
			FFU_BE_Defs.GetComponentsListTree(sMaxShieldBonusText);
			FFU_BE_Defs.GetComponentsListTree(shieldReloadTime);
			FFU_BE_Defs.GetComponentsListTree(sensorSectorRadarRange);
			FFU_BE_Defs.GetComponentsListTree(sensorStarmapRadarRange);
			FFU_BE_Defs.GetComponentsListTree(starmapStealthDetMaxText);
			FFU_BE_Defs.GetComponentsListTree(moduleDeflectionText);
			FFU_BE_Defs.GetComponentsListTree(operatorSpotsText);
			FFU_BE_Defs.GetComponentsListTree(fuelConsText);
			FFU_BE_Defs.GetComponentsListTree(organicsConsText);
			FFU_BE_Defs.GetComponentsListTree(explosivesConsText);
			FFU_BE_Defs.GetComponentsListTree(exoticsConsText);
			FFU_BE_Defs.GetComponentsListTree(syntheticsConsText);
			FFU_BE_Defs.GetComponentsListTree(metalsConsText);
			FFU_BE_Defs.GetComponentsListTree(storageSizeText);
		}
	}
	public class patch_CrewDataSubpanel : CrewDataSubpanel {
		private extern void orig_Update();
		public extern static void orig_DoSkill(SkillUi skillUi, Crewmember c, ISkillEffects se, bool crewIsMine);
		[MonoModIgnore] private Crewmember c;
		private void Update() {
		/// Crewmember Weapon Full Information Window
			orig_Update();
			if (c != null) health.horizontalOverflow = HorizontalWrapMode.Overflow;
			if (c != null && c.HandWeaponPrefab != null) handWeaponDescriptionHover.HoverText = FFU_BE_Mod_Information.GetSelectedWeaponExactData(c.HandWeaponPrefab);
		}
		public static void DoSkill(SkillUi skillUi, Crewmember c, ISkillEffects se, bool crewIsMine) {
		/// Info About Full Skill Level Up
			orig_DoSkill(skillUi, c, se, crewIsMine);
			if (skillUi.levelUpHoverable != null) if (!skillUi.levelUpHoverable.HoverText.Contains("Hold Shift, while clicking for fast skill level up")) 
			skillUi.levelUpHoverable.HoverText = skillUi.levelUpHoverable.HoverText.Replace("Click to level up this skill", "Click to level up this skill\nHold Shift, while clicking for fast skill level up");
		}
		public class patch_SkillUi : SkillUi {
			[MonoModIgnore] private CrewDataSubpanel cds;
			[MonoModIgnore] private CrewPanel.AssignmentItem ai;
			[MonoModReplace] private void LevelUpClicked() {
			/// Level Up Skill Fully with Pressed Shift Key
				if (cds != null && ai != null && cds.Crewmember != null) {
					if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
						int currentSkill = 0;
						switch (ai.skillUsed) {
							case Crewmember.Skill.Bridge: currentSkill = cds.Crewmember.skills.bridge; break;
							case Crewmember.Skill.Sensor: currentSkill = cds.Crewmember.skills.sensor; break;
							case Crewmember.Skill.Gunnery: currentSkill = cds.Crewmember.skills.gunnery; break;
							case Crewmember.Skill.Shield: currentSkill = cds.Crewmember.skills.shield; break;
							case Crewmember.Skill.Repair: currentSkill = cds.Crewmember.skills.repair; break;
							case Crewmember.Skill.FightFire: currentSkill = cds.Crewmember.skills.firefight; break;
							case Crewmember.Skill.HandWeapon: currentSkill = cds.Crewmember.skills.handWeapon; break;
							case Crewmember.Skill.Garden: currentSkill = cds.Crewmember.skills.gardening; break;
							case Crewmember.Skill.Science: currentSkill = cds.Crewmember.skills.science; break;
							case Crewmember.Skill.Warp: currentSkill = cds.Crewmember.skills.warp; break;
						}
						int allowedIncrease = 10 - currentSkill;
						if (allowedIncrease > cds.Crewmember.unusedSkillPoints) cds.Crewmember.LevelUpSkill(ai.skillUsed, cds.Crewmember.unusedSkillPoints);
						else cds.Crewmember.LevelUpSkill(ai.skillUsed, allowedIncrease);
					} else cds.Crewmember.LevelUpSkill(ai.skillUsed, 1);
				}
			}
		}
	}
}
