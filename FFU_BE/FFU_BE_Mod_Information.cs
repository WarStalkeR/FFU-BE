#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
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

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Information {
		public static string GetSelectedWeaponExactData(HandWeapon handWeapon, bool showColors = true) {
			string weaponData = null;
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg > 0 ? $"{Core.TT("Crew Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg}\n" : null;
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg > 0 ? $"{Core.TT("Door Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg}\n" : null;
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg}\n" : null;
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : null)}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg}\n" : null;
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance > 0 ? $"{Core.TT("Module Hit Chance")}: {handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance * 100f:0}%\n" : null;
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
			if (shipModule.name.Contains("bossweapon") && hideUnique) return $"<color=lime>{Core.TT("Type")}: {Core.TT("Unidentified")}</color>\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			if (shipModule.name.Contains("tutorial") && hideUnique) return $"<color=lime>{Core.TT("Type")}: {Core.TT("Unidentified")}</color>\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += $"{Core.TT("Module Identifier")}: {shipModule.name}\n";
			if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += $"{Core.TT("Module Prefab ID")}: {shipModule.PrefabId}\n";
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
				moduleData += !shipModule.Weapon.resourcesPerShot.IsEmpty ? $"{Core.TT("Resources Per Shot")}:\n" : null;
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
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Capital Missile")}\n";
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
				if (FFU_BE_Defs.allModuleProps || debugInfo) moduleData += $"{Core.TT("Interceptor Identifier")}: {shipModule.PointDefence.projectileOrBeamPrefab.name}\n";
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg > 0 ? $"{Core.TT("Interception Damage")}: {shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg}\n" : null;
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.lifetime > 0 ? $"{Core.TT("Interception Delay")}: {shipModule.PointDefence.projectileOrBeamPrefab.lifetime:0.##}{Core.TT("s")}\n" : null;
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
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : null;
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Storage Container")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Container.MaxOrganics > 0 ? $"{Core.TT("Organics Storage")}: {shipModule.Container.MaxOrganics:0}\n" : null;
				moduleData += shipModule.Container.MaxFuel > 0 ? $"{Core.TT("Starfuel Storage")}: {shipModule.Container.MaxFuel:0}\n" : null;
				moduleData += shipModule.Container.MaxMetals > 0 ? $"{Core.TT("Metals Storage")}: {shipModule.Container.MaxMetals:0}\n" : null;
				moduleData += shipModule.Container.MaxSynthetics > 0 ? $"{Core.TT("Synthetics Storage")}: {shipModule.Container.MaxSynthetics:0}\n" : null;
				moduleData += shipModule.Container.MaxExplosives > 0 ? $"{Core.TT("Explosives Storage")}: {shipModule.Container.MaxExplosives:0}\n" : null;
				moduleData += shipModule.Container.MaxExotics > 0 ? $"{Core.TT("Exotics Storage")}: {shipModule.Container.MaxExotics:0}\n" : null;
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
				moduleData += researchSpeed > 0 ? $" > {Core.TT("Research Progress")}: {researchSpeed * 100f:0.0}/100{Core.TT("ru")}\n" : null;
				moduleData += reversingSpeed > 0 ? $" > {Core.TT("Reverse Engineering")}: {reversingSpeed * 100f:0.0}/100{Core.TT("ru")}\n" : null;
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
				moduleData += !shipModule.MaterialsConverter.produce.IsEmpty ? $"{Core.TT("Industrial Production")}:\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.MaterialsConverter.produce.credits * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.MaterialsConverter.produce.organics * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.MaterialsConverter.produce.fuel * 60}{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.MaterialsConverter.produce.metals * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.MaterialsConverter.produce.synthetics * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.MaterialsConverter.produce.explosives * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.produce.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.MaterialsConverter.produce.exotics * 60}/{Core.TT("min.")}\n" : null;
				moduleData += !shipModule.MaterialsConverter.consume.IsEmpty ? $"{Core.TT("Industrial Consumption")}:\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.MaterialsConverter.consume.credits * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.MaterialsConverter.consume.organics * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.MaterialsConverter.consume.fuel * 60}{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.MaterialsConverter.consume.metals * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.MaterialsConverter.consume.synthetics * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.MaterialsConverter.consume.explosives * 60}/{Core.TT("min.")}\n" : null;
				moduleData += shipModule.MaterialsConverter.consume.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.MaterialsConverter.consume.exotics * 60}/{Core.TT("min.")}\n" : null;
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
			if (FFU_BE_Defs.weaponTypeIDs["Launchers"].Contains(shipModule.PrefabId)) return "Rocket Launcher";
			else if (FFU_BE_Defs.weaponTypeIDs["Autocannons"].Contains(shipModule.PrefabId)) return "Autocannon";
			else if (FFU_BE_Defs.weaponTypeIDs["Howitzers"].Contains(shipModule.PrefabId)) return "Howitzer";
			else if (FFU_BE_Defs.weaponTypeIDs["Railguns"].Contains(shipModule.PrefabId)) return "Railgun";
			else if (FFU_BE_Defs.weaponTypeIDs["Railcannons"].Contains(shipModule.PrefabId)) return "Railcannon";
			else if (FFU_BE_Defs.weaponTypeIDs["Lasers"].Contains(shipModule.PrefabId)) return "Laser Emitter";
			else if (FFU_BE_Defs.weaponTypeIDs["Beams"].Contains(shipModule.PrefabId)) return "Beam Emitter";
			else if (FFU_BE_Defs.weaponTypeIDs["Heat Rays"].Contains(shipModule.PrefabId)) return "Heat Ray Projector";
			else if (FFU_BE_Defs.weaponTypeIDs["Disruptors"].Contains(shipModule.PrefabId)) return "Energy Disruptor";
			else if (FFU_BE_Defs.weaponTypeIDs["Exotic Rays"].Contains(shipModule.PrefabId)) return "Exotic Ray Projector";
			else return "Starship Weapon";
		}
		public static string GetDefaultCategory(ShipModule shipModule) {
			if (FFU_BE_Defs.cacheTypeIDs["Weapons"].Contains(shipModule.PrefabId)) return "Weapons Cache";
			else if (FFU_BE_Defs.cacheTypeIDs["Implants"].Contains(shipModule.PrefabId)) return "Implants Cache";
			else if (FFU_BE_Defs.cacheTypeIDs["Upgrades"].Contains(shipModule.PrefabId)) return "Upgrades Cache";
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
			if (!(shipModule != null)) return null;
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
		private extern void orig_Update();
		//Resize List of Modules based on Resolution
		private void Update() {
			maxItemsToFit = (float)(Screen.height / 75) - 2;
			orig_Update();
		}
	}
	public class patch_ModuleSlotListItem : ModuleSlotListItem {
		[MonoModIgnore] private bool confirmSlotDowngrade;
		[MonoModIgnore] private ModuleSlotActionsPanel.Item Item;
		//Prefab Module Full Information Window
		[MonoModReplace] public void FillWithDataFrom(ModuleSlotActionsPanel.Item item, ResourceValueGroup pr) {
			Item = item;
			base.gameObject.SetActive(true);
			confirmSlotDowngrade = false;
			ModuleSlot.Upgrade slotUpgrade = item.slotUpgrade;
			if (slotUpgrade != null) {
				hoverableModule.HoverModule = null;
				avatarRenderer.sprite = slotUpgrade.UpgradeToSlotPrefab.avatar;
				hoverable.hoverText = Localization.TT(slotUpgrade.UpgradeToSlotPrefab.description);
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
				hoverable.hoverText = Localization.TT(FFU_BE_Mod_Information.GetCraftableModuleDescription(craftableModulePrefab));
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
		//Prefab Module Full Information Window
		[MonoModReplace] public void Refresh(ResourceValueGroup pr) {
			ModuleSlotActionsPanel.Item item = Item;
			if (item == null) return;
			ModuleSlot.Upgrade slotUpgrade = item.slotUpgrade;
			if (slotUpgrade != null) {
				text.text = (slotUpgrade.isDowngrade && confirmSlotDowngrade) ? Localization.TT("CONFIRM DOWNGRADE?") : Localization.TT(slotUpgrade.text);
				hoverable.hoverText = Localization.TT(slotUpgrade.UpgradeToSlotPrefab.description);
				if (item.slot.UpgradeWouldDestroyShip(slotUpgrade)) {
					HoverableUI hoverableUI = hoverable;
					hoverableUI.hoverText = hoverableUI.hoverText + "\n<color=red>" + Localization.TT("Button disabled, because it would destroy the ship") + "</color>";
				}
				costUi.Update(slotUpgrade.cost, !slotUpgrade.isDowngrade, pr);
				if (!slotUpgrade.isDowngrade) button.interactable = item.slot.CanUpgradeTo(slotUpgrade) && slotUpgrade.cost.CheckHasEnough(pr);
				else button.interactable = item.slot.CanUpgradeTo(slotUpgrade);
			}
			ShipModule craftableModulePrefab = item.craftableModulePrefab;
			if (craftableModulePrefab != null) {
				hoverable.hoverText = Localization.TT(FFU_BE_Mod_Information.GetCraftableModuleDescription(craftableModulePrefab));
				costUi.Update(craftableModulePrefab.craftCost, true, pr);
				button.interactable = item.slot.CanCraft(craftableModulePrefab) && craftableModulePrefab.craftCost.CheckHasEnough(pr);
			}
		}
	}
	public class patch_ModuleDataSubpanel : ModuleDataSubpanel {
		[MonoModIgnore] private ShipModule m;
		[MonoModIgnore] private ShipModule lastModule;
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
		//Selected Module Full Information Window
		[MonoModReplace] private void Update() {
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
			iconHover.hoverText = moduleTypeData != null ? Localization.TT(moduleTypeData.iconHoverText) : null;
			if (m.Ownership.GetOwner() == Ownership.Owner.Me && iconHover.Hovered) iconHover.hoverText = FFU_BE_Mod_Information.GetSelectedModuleExactData(m);
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
		}
		//Updated Weapon Information
		[MonoModReplace] private void DoWeapon() {
			WeaponModule weapon = m.Weapon;
			ShootAtDamageDealer.Damage damage = weapon.ProjectileOrBeamPrefab.GetDamage(weapon);
			Projectile projectile = weapon.ProjectileOrBeamPrefab as Projectile;
			string perArg = Localization.TT("per");
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			if (weapon.accuracy != 0) {
				weaponAccuracy.SetActiveIfNeeded();
				int effAccuracy = gunnerySkillEffects.EffectiveAccuracy(weapon);
				weaponAccuracy.effects.text = weapon.accuracy != effAccuracy ? $"{altPreClr}{preColor}{effAccuracy * healthPercent:0} Δ{Localization.TT("m")}{aftColor}{altAftClr}" : $"{preColor}{effAccuracy * healthPercent:0} Δ{Localization.TT("m")}{aftColor}";
				weaponAccuracy.skillBonus.text = "+" + gunnerySkillEffects.skillPointAccuracyBonus.ToString("0.0") + " " + perArg;
				SortOrder(weaponAccuracy, 10);
			}
			if (weapon.reloadInterval != 0f) {
				weaponReloadTime.SetActiveIfNeeded();
				float effReload = gunnerySkillEffects.EffectiveReloadTime(weapon);
				weaponReloadTime.effects.text = weapon.reloadInterval != effReload ? $"{altPreClr}{preColor}{effReload / healthPercent:0.0}{Localization.TT("s")}{aftColor}{altAftClr}" : $"{preColor}{effReload / healthPercent:0.0}{Localization.TT("s")}{aftColor}";
				weaponReloadTime.skillBonus.text = $"-{((!weapon.reloadIntervalTakesNoBonuses) ? gunnerySkillEffects.skillPointBonusPercent : 0)}% {perArg}";
				SortOrder(weaponReloadTime, 20);
			}
			_ = weapon.tracksTarget;
			if (projectile != null) SafeUpdateField(30, sensorSectorRadarRange, projectile.speed * 100f, ref prevProjSpeed, "{0:0} " + Localization.TT("m") + "/" + Localization.TT("s"));
			SafeUpdateField(40, dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.##}" + Localization.TT("m"));
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
			groupedDmgTextHover.hoverText = (stringBuilder.Length <= 0) ? null : stringBuilder.ToString(0, stringBuilder.Length - 1);
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
			SortOrder(dmgToCrewText, 90);
			SortOrder(fireChanceText, 100);
			SafeUpdateField(110, empOverloadText, damage.moduleOverloadSeconds, ref prevEMPoverload, Localization.TT("EMP") + " " + "{0:0}" + Localization.TT("s"));
			SortOrder(empOverloadText, 110);
			weaponIgnoresShieldGo.SetActive(damage.ignoresShield);
			weaponNeverDeflectsGo.SetActive(damage.neverDeflect);
			SortOrder(weaponIgnoresShieldGo, 120);
			SortOrder(weaponNeverDeflectsGo, 130);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
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
				weaponIgnoresShieldHover.hoverText = $"{Localization.TT("Shows if weapon's hits completely bypasses shields.")}";
				weaponNeverDeflectsHover.hoverText = $"{Localization.TT("Shows if weapon's hits are affected by target's deflective properties.")}";
				weaponAccuracy.Hoverable.hoverText = $"{Localization.TT("Effective accuracy of a weapon that defines hit sector size.")}";
				weaponReloadTime.Hoverable.hoverText = $"{Localization.TT("Effective reload time of a weapon between volleys.")}";
				sensorSectorRadarRangeHover.hoverText = $"{Localization.TT("Speed of projectile ejected from the weapon.")}";
				dmgAreaHover.hoverText = $"{Localization.TT("Effective area of effect at point of projectile/beam impact.")}";
				empOverloadHover.hoverText = $"{Localization.TT("Effective module disruption time within area of effect.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy weapon currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Capital Missile Information
		private void DoNuke() {
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
			if (homingMovement != null) SafeUpdateField(40, sensorSectorRadarRange, homingMovement.force * 10f, ref prevProjSpeed, "{0:0} " + Localization.TT("m") + "/" + Localization.TT("s") + "²");
			SafeUpdateField(50, dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.##}" + Localization.TT("m"));
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
			groupedDmgTextHover.hoverText = (stringBuilder.Length <= 0) ? null : stringBuilder.ToString(0, stringBuilder.Length - 1);
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
			SortOrder(dmgToCrewText, 100);
			SortOrder(fireChanceText, 110);
			SafeUpdateField(120, empOverloadText, damage.moduleOverloadSeconds, ref prevEMPoverload, Localization.TT("EMP") + " " + "{0:0}" + Localization.TT("s"));
			SortOrder(empOverloadText, 120);
			SafeUpdateField(130, crewText, weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? $"{FFU_BE_Defs.GetIntruderCountFromName(m) * 2f:0} ~ {FFU_BE_Defs.GetIntruderCountFromName(m) * 5f:0} {Core.TT("Units")}" : null);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doNukeHovers) {
				UpdateHoverFlags(doNukeHovers: true);
				weaponTracksTargetHover.hoverText = $"{Localization.TT("Shows if capital missile has tracking and homing capabilities.")}";
				weaponIgnoresShieldHover.hoverText = $"{Localization.TT("Shows if capital missile completely bypasses shields.")}";
				weaponNeverDeflectsHover.hoverText = $"{Localization.TT("Shows if capital missile is affected by target's deflective properties.")}";
				sensorSectorRadarRangeHover.hoverText = $"{Localization.TT("Capital missile acceleration speed.")}";
				dmgAreaHover.hoverText = $"{Localization.TT("Effective area of effect at point of capital missile impact.")}";
				empOverloadHover.hoverText = $"{Localization.TT("Effective module disruption time within area of effect.")}";
				crewOpsHover.hoverText = $"{Localization.TT("Minimum and maximum troop size of capital missile with boarding capabilities.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy capital missile currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Point Defense Information
		[MonoModReplace] private void DoPointDefence() {
			PointDefenceModule pointDefence = m.PointDefence;
			PointDefDamageDealer projectileOrBeamPrefab = pointDefence.projectileOrBeamPrefab;
			ResourceValueGroup resourcesPerShot = pointDefence.resourcesPerShot;
			string argPer = Localization.TT("per");
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			pointDefReloadTime.SetActiveIfNeeded();
			float pdEffReload = pointDefence.reloadInterval * gunnerySkillEffects.EffectiveSkillMultiplier(m, true);
			pointDefReloadTime.effects.text = pointDefence.reloadInterval != pdEffReload ? $"{altPreClr}{preColor}{pdEffReload / healthPercent:0.00}{Localization.TT("s")}{aftColor}{altAftClr}" : $"{preColor}{pdEffReload / healthPercent:0.00}{Localization.TT("s")}{aftColor}";
			pointDefReloadTime.skillBonus.text = $"-{gunnerySkillEffects.skillPointBonusPercent}% {argPer}";
			SortOrder(pointDefReloadTime, 10);
			pointDefCoverRadius.SetActiveIfNeeded();
			float pdEffRadius = pointDefence.EffectiveCoverRadius;
			pointDefCoverRadius.effects.text = pointDefence.coverRadius != pdEffRadius ? $"{altPreClr}{preColor}{pdEffRadius * 10f * healthPercent:0.0}{Localization.TT("m")}{aftColor}{altAftClr}" : $"{preColor}{pdEffRadius * 10f * healthPercent:0.0}{Localization.TT("m")}{aftColor}";
			pointDefCoverRadius.skillBonus.text = $"+{gunnerySkillEffects.skillPointBonusPercent}% {argPer}";
			SortOrder(pointDefCoverRadius, 20);
			SafeUpdateField(30, pointDefDmgToProjectilesText, $"{projectileOrBeamPrefab.projectileDmg:0} {Localization.TT("HP")}/{Localization.TT("Hit")}");
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
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
				pointDefReloadTime.Hoverable.hoverText = $"{Localization.TT("Effective reload time of a point defense between shots.")}";
				pointDefCoverRadius.Hoverable.hoverText = $"{Localization.TT("Effective cover radius of a point defense where it can intercept incoming projectiles.")}";
				pointDefDmgToProjectilesHover.hoverText = $"{Localization.TT("Shows how much damage per hit point defense does to incoming projectiles.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows efficiency of your anti-asteroid defenses at hazardous and volatile locations.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy point defense currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Engine Information
		[MonoModReplace] private void DoEngine() {
			EngineModule engine = m.Engine;
			SafeUpdateField(10, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(20, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(30, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(40, fireChanceText, $"+{preColor}{engine.overchargeEvasionAdd * healthPercent:0} °/{Localization.TT("min.")}{aftColor}");
			SafeUpdateField(50, empOverloadText, $"-{m.overchargePowerNeed:0} {Localization.TT("GW/h")}");
			SafeUpdateField(60, medbayHealSpeedText, $"{m.overchargeSeconds:0}{Localization.TT("s")}");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
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
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase engine provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows asteroid evasion efficiency increase that engine provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase engine provides to the ship.")}";
				fireChanceHover.hoverText = $"{Localization.TT("Maneuverability and evasive capabilities increase from active overcharge.")}";
				empOverloadHover.hoverText = $"{Localization.TT("Engine additional power consumption during overcharge.")}";
				medbayHealSpeedHover.hoverText = $"{Localization.TT("Engine overcharge effective time.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the engine.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase engine provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy engine currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Update Resource Pack Information
		[MonoModReplace] private void DoResourcePack() {
			SafeUpdateField(organicsContCurText, (m.scrapGet.organics > 0) ? $"+{m.scrapGet.organics:0}" : null);
			SafeUpdateField(fuelContCurText, (m.scrapGet.fuel > 0) ? $"+{m.scrapGet.fuel:0}" : null);
			SafeUpdateField(metalsContCurText, (m.scrapGet.metals > 0) ? $"+{m.scrapGet.metals:0}" : null);
			SafeUpdateField(syntheticsContCurText, (m.scrapGet.synthetics > 0) ? $"+{m.scrapGet.synthetics:0}" : null);
			SafeUpdateField(explosivesContCurText, (m.scrapGet.explosives > 0) ? $"+{m.scrapGet.explosives:0}" : null);
			SafeUpdateField(exoticsContCurText, (m.scrapGet.exotics > 0) ? $"+{m.scrapGet.exotics:0}" : null);
			if (!doResPackHovers) {
				UpdateHoverFlags(doResPackHovers: true);
				organicsContCurHover.hoverText = $"{Localization.TT("Shows how much organic substances contained in a resource package.")}";
				fuelContCurHover.hoverText = $"{Localization.TT("Shows how much high energy starfuel contained in a resource package.")}";
				metalsContCurHover.hoverText = $"{Localization.TT("Shows how much metals and composites contained in a resource package.")}";
				syntheticsContCurHover.hoverText = $"{Localization.TT("Shows how much synthetic compounds contained in a resource package.")}";
				explosivesContCurHover.hoverText = $"{Localization.TT("Shows how much explosive materials contained in a resource package.")}";
				exoticsContCurHover.hoverText = $"{Localization.TT("Shows how much rare & exotic matter contained in a resource package.")}";
			}
		}
		//Updated Sensor Information
		[MonoModReplace] private void DoSensor() {
			SensorModule sensor = m.Sensor;
			SafeUpdateField(10, dmgAreaText, m.starmapStealthDetectionLevelMax > 0 ? $"<color=lime><size=16>{FFU_BE_Mod_Information.GetStealthDetectionText(m.starmapStealthDetectionLevelMax)}</size></color>" : null);
			if (sensor.starmapRadarRange != 0) {
				sensorStarmapRadarRange.SetActiveIfNeeded();
				SensorSkillEffects sensorSkillEffects = WorldRules.Instance.sensorSkillEffects;
				float starRadRng = sensor.starmapRadarRange * sensorSkillEffects.EffectiveSkillMultiplier(m, false);
				sensorStarmapRadarRange.effects.text = sensor.starmapRadarRange != starRadRng ? $" {altPreClr}{preColor}<size=18>{starRadRng * healthPercent:0}{Localization.TT("ru")}</size>{aftColor}{altAftClr}" : $" {preColor}<size=18>{starRadRng * healthPercent:0}{Localization.TT("ru")}</size>{aftColor}";
				sensorStarmapRadarRange.skillBonus.text = $"+{sensorSkillEffects.skillPointBonusPercent}% {Localization.TT("per")}";
				sensorStarmapRadarRange.Hoverable.hoverText = string.Format(sensorStarmapRadarRange.HoverableTextTemplate, sensorSkillEffects.skillPointBonusPercent);
				SortOrder(sensorStarmapRadarRange, 20);
			}
			SafeUpdateField(30, sensorSectorRadarRange, sensor.sectorRadarRange > 0 ? $"{preColor}{sensor.sectorRadarRange * healthPercent:0}{Localization.TT("ru")}{aftColor}" : null);
			SafeUpdateField(40, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doSensorHovers) {
				UpdateHoverFlags(doSensorHovers: true);
				sensorStarmapRadarRange.Hoverable.hoverText = $"{Localization.TT("Shows active sensor array range that reveals accurate information about objects around your ship.")}";
				sensorSectorRadarRangeHover.hoverText = $"{Localization.TT("Shows passive sensor array range that reveals approximate information about entities in detected star systems.")}";
				dmgAreaHover.hoverText = $"{Localization.TT("Shows sensor array's effective anti-stealth capabilities that reveal hidden points of interest within active range.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of sensor array's built-in targeting systems that increase accuracy of all ship weapons.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy sensor array currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Bridge Information
		[MonoModReplace] private void DoBridge() {
			bridgeRemoteOpsGo.SetActive(true);
			bridgeEvasion.SetActiveIfNeeded();
			BridgeSkillEffects bridgeSkillEffects = WorldRules.Instance.bridgeSkillEffects;
			int bridgeEva = bridgeSkillEffects.EffectiveSkillBonusPercent(m);
			bridgeEvasion.effects.text = (m.shipEvasionPercentAdd != bridgeEva) ? $"{altPreClr}{preColor}{m.shipEvasionPercentAdd + bridgeEva * healthPercent:0} °/{Localization.TT("min.")}{aftColor}{altAftClr}" : $"{preColor}{m.shipEvasionPercentAdd + bridgeEva * healthPercent:0} °/{Localization.TT("min.")}{aftColor}";
			bridgeEvasion.skillBonus.text = string.Format("+{0} {1}", bridgeSkillEffects.skillPointBonusPercent, Localization.TT("per"));
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Officers")}</size>");
			SortOrder(bridgeRemoteOpsGo, 20);
			SortOrder(bridgeEvasion, 30);
			SafeUpdateField(40, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doBridgeHovers) {
				UpdateHoverFlags(doBridgeHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows current occupancy and limit of how much crewmembers can operate bridge at the same time.")}";
				bridgeRemoteOpsHover.hoverText = $"{Localization.TT("Shows if bridge allows to control remotely unmanned modules that require operators.")}";
				bridgeEvasion.Hoverable.hoverText = $"{Localization.TT("Shows by how much operating crew increases maneuverability and evasive capabilities of the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of birdge targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the bridge.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase bridge provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy bridge currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Shields Information
		[MonoModReplace] private void DoShieldGen() {
			ShieldModule shieldGen = m.ShieldGen;
			ShieldSkillEffects shieldSkillEffects = WorldRules.Instance.shieldSkillEffects;
			if (shieldGen.reloadInterval != 0f) {
				shieldReloadTime.SetActiveIfNeeded();
				float shieldNum = shieldGen.reloadInterval * shieldSkillEffects.EffectiveSkillMultiplier(m, true);
				shieldReloadTime.effects.text = (shieldGen.reloadInterval != shieldNum) ? $"{altPreClr}{preColor}{shieldNum / healthPercent:0.00} {Localization.TT("s")}/{Localization.TT("SP")}{aftColor}{altAftClr}" : $"{preColor}{shieldNum / healthPercent:0.00}{aftColor} {Localization.TT("s")}/{Localization.TT("SP")}";
				shieldReloadTime.skillBonus.text = string.Format("-{0}% {1}", shieldSkillEffects.skillPointBonusPercent, Localization.TT("per"));
				SortOrder(shieldReloadTime, 10);
			}
			SafeUpdateField(20, sMaxShieldBonusText, m.HasFullHealth ? shieldGen.maxShieldAdd : shieldGen.maxShieldAdd * healthPercent, ref prevShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(30, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(40, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(50, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doShieldHovers) {
				UpdateHoverFlags(doShieldHovers: true);
				shieldReloadTime.Hoverable.hoverText = $"{Localization.TT("Shows how much time it takes for shield generator to restore a single shield point.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that shield module provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase shield module provides to the ship.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows shield capacity of the shield generators and shield capacitors.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase shield module provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy shield module currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Warp Drive Information
		[MonoModReplace] private void DoWarp() {
			Ship ship = m.Ship;
			WarpModule warp = m.Warp;
			SafeUpdateField(warpActivationFuelText, warp.activationFuel, ref prevActivationFuel);
			DoRequirementColor(warpActivationFuelText, warpActivationFuel, ship == null || ship.Fuel >= warp.activationFuel);
			WarpSkillEffects warpSkillEffects = WorldRules.Instance.warpSkillEffects;
			warpReloadTime.SetActiveIfNeeded();
			float warpNum = warp.reloadInterval * warpSkillEffects.EffectiveSkillMultiplier(m, true);
			warpReloadTime.effects.text = warp.reloadInterval != warpNum ? $"{altPreClr}{preColor}{warpNum / Mathf.Pow(healthPercent, 2):0.00}{Localization.TT("s")}{aftColor}{altAftClr}" : $"{preColor}{warpNum / Mathf.Pow(healthPercent, 2):0.00}{Localization.TT("s")}{aftColor}";
			warpReloadTime.skillBonus.text = string.Format("-{0}% {1}", warpSkillEffects.skillPointBonusPercent, Localization.TT("per"));
			SortOrder(warpReloadTime, 10);
			SafeUpdateField(220, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(240, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(260, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doWarpHovers) {
				UpdateHoverFlags(doWarpHovers: true);
				warpReloadTime.Hoverable.hoverText = $"{Localization.TT("Shows how much time warp drive needs to spool up before initiating jump.")}";
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase warp drive provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that warp drive provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase warp drive provides to the ship.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the warp drive.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase warp drive provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy warp drive currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Reactor Information
		[MonoModReplace] private void DoReactor() {
			ReactorModule reactor = m.Reactor;
			bool isOvercharged = m.IsOvercharged;
			int reactorNum = isOvercharged ? reactor.powerCapacity + reactor.overchargePowerCapacityAdd : reactor.powerCapacity;
			string rPreClr = isOvercharged ? "<color=lime>" : null;
			string rAftClr = isOvercharged ? "</color>" : null;
			SafeUpdateField(10, reactorPowerProdText, $"{rPreClr}{preColor}{reactorNum * healthPercent:0} {Localization.TT("GW/h")}{aftColor}{rAftClr}");
			SafeUpdateField(20, empOverloadText, $"+{reactor.overchargePowerCapacityAdd:0} {Localization.TT("GW/h")}");
			SafeUpdateField(30, medbayHealSpeedText, $"{m.overchargeSeconds:0}{Localization.TT("s")}");
			SafeUpdateField(260, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			DoResourceConsPerDist(reactor.ConsumedPerDistance, m);
			if (!doReactorHovers) {
				UpdateHoverFlags(doReactorHovers: true);
				reactorPowerProdHover.hoverText = $"{Localization.TT("Shows reactor's current effective power output.")}";
				empOverloadHover.hoverText = $"{Localization.TT("Shows reactor power output bonus with active overcharge.")}";
				medbayHealSpeedHover.hoverText = $"{Localization.TT("Shows reactor overcharge effective time.")}";
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase reactor provides to the ship.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the reactor.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase reactor provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy reactor currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Health Bay Information
		[MonoModReplace] private void DoMedbay() {
			Ship ship = m.Ship;
			MedbayModule medbay = m.Medbay;
			int orgPerHp = (int)medbay.resourcesPerHp.organics;
			int synPerHp = (int)medbay.resourcesPerHp.synthetics;
			SafeUpdateField(10, medbayHealSpotsText, $"<size=16>{CrewmemberTypesText(medbay.acceptCrewTypes)}</size>");
			SafeUpdateField(20, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Patients")}</size>");
			SafeUpdateField(30, medbayHealSpeedText, m.HasFullHealth ? medbay.secondsPerHp : medbay.secondsPerHp / Mathf.Pow(healthPercent, 2), ref prevHealingInvSpeed, preColor + "{0:0.00}" + Localization.TT("s") + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			PlayerData playerData = PlayerDatas.Get(m.Ownership.GetOwner());
			SafeUpdateField(medbayOrganicsPerHpText, orgPerHp, ref prevOrganicsPerHp);
			SafeUpdateField(medbaySyntheticsPerHpText, synPerHp, ref prevSyntheticsPerHp);
			DoRequirementColor(medbayOrganicsPerHpText, medbayOrganicsPerHp, ship == null || playerData == null || playerData.Organics.Total >= orgPerHp);
			DoRequirementColor(medbaySyntheticsPerHpText, medbaySyntheticsPerHp, ship == null || playerData == null || playerData.Synthetics.Total >= synPerHp);
			if (!doHealthBayHovers) {
				UpdateHoverFlags(doHealthBayHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows current occupancy and limit of how much patients can be serviced at the same time.")}";
				medbayHealSpotsHover.hoverText = $"{Localization.TT("Shows what types of crewmembers health bay can service.")}";
				medbayHealSpeedHover.hoverText = $"{Localization.TT("Shows how much time it takes for a health bay to heal single health point of a crewmember.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the health bay.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase health bay provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy health bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Converter Information
		[MonoModReplace] private void DoMaterialsConverter() {
			MaterialsConverterModule materialsConverter = m.MaterialsConverter;
			exoticsProdText.transform.parent.parent.gameObject.SetActive(false);
			DoResourceProdPerSecond(materialsConverter.produce, materialsConverter.secondsPerConversion);
			DoResourceConsPerSecond(materialsConverter.consume, materialsConverter.secondsPerConversion);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doConverterHovers) {
				UpdateHoverFlags(doConverterHovers: true);
				organicsProdHover.hoverText = $"{Localization.TT("Shows how much organics material converter produces per minute, if active.")}";
				fuelProdHover.hoverText = $"{Localization.TT("Shows how much starfuel material converter produces per minute, if active.")}";
				metalsProdHover.hoverText = $"{Localization.TT("Shows how much metal material converter produces per minute, if active.")}";
				syntheticsProdHover.hoverText = $"{Localization.TT("Shows how much synthetics material converter produces per minute, if active.")}";
				explosivesProdHover.hoverText = $"{Localization.TT("Shows how much explosives material converter produces per minute, if active.")}";
				exoticsProdHover.hoverText = $"{Localization.TT("Shows how much exotics material converter produces per minute, if active.")}";
				creditsProdHover.hoverText = $"{Localization.TT("Shows how much credits material converter generates per minute, if active.")}";
				organicsConsHover.hoverText = $"{Localization.TT("Shows how much organics material converter consumes per minute, if active.")}";
				fuelConsHover.hoverText = $"{Localization.TT("Shows how much starfuel material converter consumes per minute, if active.")}";
				metalsConsHover.hoverText = $"{Localization.TT("Shows how much metal material converter consumes per minute, if active.")}";
				syntheticsConsHover.hoverText = $"{Localization.TT("Shows how much synthetics material converter consumes per minute, if active.")}";
				explosivesConsHover.hoverText = $"{Localization.TT("Shows how much explosives material converter consumes per minute, if active.")}";
				exoticsConsHover.hoverText = $"{Localization.TT("Shows how much exotics material converter consumes per minute, if active.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the materials converter.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase materials converter provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy materials converter currently emits and by how much it inflates ship's signature.")}";
				exoticsContCurHover.hoverText = exoticsProdHover.hoverText;
			}
		}
		//Updated Fighter Bay Information
		[MonoModReplace] private void DoFighter() {
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doFighterHovers) {
				UpdateHoverFlags(doFighterHovers: true);
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase fighter bay provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that fighter bay provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase fighter bay provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of fighter bay targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the fighter bay.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase fighter bay provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy fighter bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Resource Storage Information
		[MonoModReplace] private void DoContainer() {
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
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doContainerHovers) {
				UpdateHoverFlags(doContainerHovers: true);
				organicsContCurHover.hoverText = $"{Localization.TT("Shows how much organic substances can be stored in a container.")}";
				fuelContCurHover.hoverText = $"{Localization.TT("Shows how much high energy starfuel can be stored in a container.")}";
				metalsContCurHover.hoverText = $"{Localization.TT("Shows how much metals and composites can be stored in a container.")}";
				syntheticsContCurHover.hoverText = $"{Localization.TT("Shows how much synthetic compounds can be stored in a container.")}";
				explosivesContCurHover.hoverText = $"{Localization.TT("Shows how much explosive materials can be stored in a container.")}";
				exoticsContCurHover.hoverText = $"{Localization.TT("Shows how much rare & exotic matter can be stored in a container.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the container.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase container provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy container currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Module Storage Information
		[MonoModReplace] private void DoStorageContainer() {
			storageSizeText.alignment = TextAnchor.MiddleLeft;
			SafeUpdateField(10, storageSizeText, m.Storage.slotCount.ToString());
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doStorageHovers) {
				UpdateHoverFlags(doStorageHovers: true);
				storageSizeHover.hoverText = $"{Localization.TT("Shows how much modules can be stored in the module storage compartment.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the module storage compartment.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase module storage compartment provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy module storage compartment currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Greenhouse Information
		[MonoModReplace] private void DoGarden() {
			GardenModule farm = m.GardenModule;
			ResourceValueGroup farmSkillProd = farm.producedPerSkillPoint;
			ResourceValueGroup farmProdPerDist = farm.ProducedPerDistance;
			removesOpResCons.SetActive(true);
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Farmers")}</size>");
			SortOrder(removesOpResCons, 20);
			SafeUpdateField(30, creditsProdText, farmSkillProd.credits > 0 ? $"{(farmProdPerDist.credits > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.credits * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.credits > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(40, organicsProdText, farmSkillProd.organics > 0 ? $"{(farmProdPerDist.organics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.organics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.organics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(50, fuelProdText, farmSkillProd.fuel > 0 ? $"{(farmProdPerDist.fuel > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.fuel * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.fuel > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(60, metalsProdText, farmSkillProd.metals > 0 ? $"{(farmProdPerDist.metals > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.metals * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.metals > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(70, syntheticsProdText, farmSkillProd.synthetics > 0 ? $"{(farmProdPerDist.synthetics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.synthetics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.synthetics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(80, explosivesProdText, farmSkillProd.explosives > 0 ? $"{(farmProdPerDist.explosives > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.explosives * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.explosives > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(90, exoticsContCurText, farmSkillProd.exotics > 0 ? $"{(farmProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{farmProdPerDist.exotics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(farmProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			//SafeUpdateField(90, exoticsProdText, gardenSkillProd.exotics > 0 ? $"{(gardenProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{gardenProdPerDist.exotics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(gardenProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(100, gardenOrganicsProdBonusText, $" {farm.producedPerSkillPoint.organics:0.0}/100{Localization.TT("ru")} /");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doGardenHovers) {
				UpdateHoverFlags(doGardenHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows current occupancy and limit of how much farmers can work in the greenhouse at the same time.")}";
				removesOpResConsHover.hoverText = $"{Localization.TT("Shows if working in a greenhouse resolves food consumption issues for farmers.")}";
				organicsProdHover.hoverText = $"{Localization.TT("Shows how much organics greenhouse produces per 100ru of travel.")}";
				fuelProdHover.hoverText = $"{Localization.TT("Shows how much starfuel greenhouse produces per 100ru of travel.")}";
				metalsProdHover.hoverText = $"{Localization.TT("Shows how much metal greenhouse produces per 100ru of travel.")}";
				syntheticsProdHover.hoverText = $"{Localization.TT("Shows how much synthetics greenhouse produces per 100ru of travel.")}";
				explosivesProdHover.hoverText = $"{Localization.TT("Shows how much explosives greenhouse produces per 100ru of travel.")}";
				exoticsProdHover.hoverText = $"{Localization.TT("Shows how much exotics greenhouse produces per 100ru of travel.")}";
				creditsProdHover.hoverText = $"{Localization.TT("Shows how much credits greenhouse generates per 100ru of travel.")}";
				gardenOrganicsProdBonusHover.hoverText = $"{Localization.TT("Shows by how much greenhouse increases organics output per each gardening skill point for 100ru of travel.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the greenhouse.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase greenhouse provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy greenhouse currently emits and by how much it inflates ship's signature.")}";
				exoticsContCurHover.hoverText = exoticsProdHover.hoverText;
			}
		}
		//Updated Laboratory Information
		[MonoModReplace] private void DoResearch() {
			ResearchModule lab = m.Research;
			ResourceValueGroup labSkillProd = lab.producedPerSkillPoint;
			ResourceValueGroup labProdPerDist = lab.ProducedPerDistance;
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Scientists")}</size>");
			SafeUpdateField(20, creditsProdText, labSkillProd.credits > 0 ? $"{(labProdPerDist.credits > 0 ? altPreClr : null)}{preColor}{labProdPerDist.credits * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.credits > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(30, organicsProdText, labSkillProd.organics > 0 ? $"{(labProdPerDist.organics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.organics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.organics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(40, fuelProdText, labSkillProd.fuel > 0 ? $"{(labProdPerDist.fuel > 0 ? altPreClr : null)}{preColor}{labProdPerDist.fuel * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.fuel > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(50, metalsProdText, labSkillProd.metals > 0 ? $"{(labProdPerDist.metals > 0 ? altPreClr : null)}{preColor}{labProdPerDist.metals * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.metals > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(60, syntheticsProdText, labSkillProd.synthetics > 0 ? $"{(labProdPerDist.synthetics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.synthetics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.synthetics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(70, explosivesProdText, labSkillProd.explosives > 0 ? $"{(labProdPerDist.explosives > 0 ? altPreClr : null)}{preColor}{labProdPerDist.explosives * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.explosives > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(80, exoticsContCurText, labSkillProd.exotics > 0 ? $"{(labProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.exotics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			//SafeUpdateField(80, exoticsProdText, labSkillProd.exotics > 0 ? $"{(labProdPerDist.exotics > 0 ? altPreClr : null)}{preColor}{labProdPerDist.exotics * 100:0.#}/100{Localization.TT("ru")}{aftColor}{(labProdPerDist.exotics > 0 ? altAftClr : null)}" : null);
			SafeUpdateField(90, researchCreditsProdBonusText, $" {lab.producedPerSkillPoint.credits:0.0}/100{Localization.TT("ru")} /");
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doResearchHovers) {
				UpdateHoverFlags(doResearchHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows current occupancy and limit of how much scientists can work in the laboratory at the same time.")}";
				removesOpResConsHover.hoverText = $"{Localization.TT("Shows if working in a laboratory resolves food consumption issues for farmers.")}";
				organicsProdHover.hoverText = $"{Localization.TT("Shows how much organics laboratory produces per 100ru of travel.")}";
				fuelProdHover.hoverText = $"{Localization.TT("Shows how much starfuel laboratory produces per 100ru of travel.")}";
				metalsProdHover.hoverText = $"{Localization.TT("Shows how much metal laboratory produces per 100ru of travel.")}";
				syntheticsProdHover.hoverText = $"{Localization.TT("Shows how much synthetics laboratory produces per 100ru of travel.")}";
				explosivesProdHover.hoverText = $"{Localization.TT("Shows how much explosives laboratory produces per 100ru of travel.")}";
				exoticsProdHover.hoverText = $"{Localization.TT("Shows how much exotics laboratory produces per 100ru of travel.")}";
				creditsProdHover.hoverText = $"{Localization.TT("Shows how much credits laboratory generates per 100ru of travel.")}";
				researchCreditsProdBonusHover.hoverText = $"{Localization.TT("Shows by how much laboratory increases credits output per each science skill point for 100ru of travel.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the laboratory.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase laboratory provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy laboratory currently emits and by how much it inflates ship's signature.")}";
				exoticsContCurHover.hoverText = exoticsProdHover.hoverText;
			}
		}
		//Updated Cryosleep Information
		[MonoModReplace] private void DoCryosleep() {
			CryosleepModule cryo = m.Cryosleep;
			removesOpResCons.SetActive(true);
			SafeUpdateField(10, crewText, $"{m.CurrentLocalOpsCount}/{m.operatorSpots.Length} <size=16>{Localization.TT("Occupied")}</size>");
			SortOrder(removesOpResCons, 20);
			SafeUpdateField(30, medbayHealSpotsText, cryo.healOneCrewHp ? $"{preColor}{cryo.healOneCrewHpDistance.minValue / healthPercent:0}{Localization.TT("ru")} ~ {cryo.healOneCrewHpDistance.maxValue / healthPercent:0}{Localization.TT("ru")}{aftColor}" : null);
			SafeUpdateField(40, sensorSectorRadarRange, cryo.genDreamCredits ? $"{preColor}{cryo.genDreamCreditsDistance.minValue / healthPercent:0}{Localization.TT("ru")} ~ {cryo.genDreamCreditsDistance.maxValue / healthPercent:0}{Localization.TT("ru")}{aftColor}" : null);
			SafeUpdateField(50, creditsProdText, cryo.genDreamCredits ? $"{preColor}${cryo.creditsPerDream.minValue * healthPercent:0.#} ~ ${cryo.creditsPerDream.maxValue * healthPercent:0.#}{aftColor}" : null);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doCryosleepHovers) {
				UpdateHoverFlags(doCryosleepHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows current occupancy and limit of how much crewmembers can be put into cryosleep at the same time.")}";
				removesOpResConsHover.hoverText = $"{Localization.TT("Shows if sleeping in cryopods prevents food consumption for crewmembers.")}";
				medbayHealSpotsHover.hoverText = $"{Localization.TT("Shows approximate travel distance required to heal a single health point of crewmember in cryosleep.")}";
				sensorSectorRadarRangeHover.hoverText = $"{Localization.TT("Shows approximate travel distance required to record a full cryo-dream of crewmember in cryosleep.")}";
				creditsProdHover.hoverText = $"{Localization.TT("Shows approximate amount of generated credits, when cryo-dream of a crewmember in cryosleep is recorded and compiled.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the cryosleep bay.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase cryosleep bay provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy cryosleep bay currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Stealth Generator Information
		[MonoModReplace] private void DoStealthDecryptorSensor() {
			SafeUpdateField(10, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, altPreClr + preColor + "{0:0.#} " + Localization.TT("m") + "³" + aftColor + altAftClr);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			if (!doStealthHovers) {
				UpdateHoverFlags(doStealthHovers: true);
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("Shows by how much stealth generator reduces ship's signature.")}";
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase stealth generator provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that stealth generator provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase stealth generator provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of stealth generator targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the stealth generator.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase stealth generator provides to the ship.")}";
			}
		}
		//Updated Countermeasure Arrays Information
		[MonoModReplace] private void DoPassiveECM() {
			SafeUpdateField(10, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, altPreClr + preColor + "{0:0.#} " + Localization.TT("m") + "³" + aftColor + altAftClr);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			if (!doPassiveHovers) {
				UpdateHoverFlags(doPassiveHovers: true);
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("Shows by how much countermeasure module reduces ship's signature.")}";
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase countermeasure module provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that countermeasure module provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase countermeasure module provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of countermeasure module targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the countermeasure module.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase countermeasure module provides to the ship.")}";
			}
		}
		//Updated Starship Armor Information
		[MonoModReplace] private void DoIntegrity() {
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doIntegrityHovers) {
				UpdateHoverFlags(doIntegrityHovers: true);
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase armor provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that armor provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase armor provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of armor targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the armor module.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase armor provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy armor currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Decoy Modules Information
		[MonoModReplace] private void DoDecoy() {
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doDecoyHovers) {
				UpdateHoverFlags(doDecoyHovers: true);
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase decoy module provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that decoy module provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase decoy module provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of decoy module targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the decoy module.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase decoy module provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy decoy module currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Updated Other Modules Information
		[MonoModReplace] private void DoOther() {
			storageSizeText.alignment = TextAnchor.UpperLeft;
			SafeUpdateField(10, crewText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheSets(m) > 0 ? $"{FFU_BE_Mod_Information.GetCacheSets(m)} <size=16>{Localization.TT("Sets")}</size>" : null);
			SafeUpdateField(20, medbayHealSpotsText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheHPIncrease(m) > 0 ? $"+{FFU_BE_Mod_Information.GetCacheHPIncrease(m)} <size=16>{Localization.TT("Increase")}</size>" : null);
			SafeUpdateField(30, dmgToCrewText, FFU_BE_Mod_Information.IsCacheModule(m) && FFU_BE_Mod_Information.GetCacheHPLimit(m) > 0 ? $"{FFU_BE_Mod_Information.GetCacheHPLimit(m)} <size=16>{Localization.TT("Limit")}</size>" : null);
			SafeUpdateField(40, storageSizeText, FFU_BE_Mod_Information.IsCacheModule(m) && !FFU_BE_Mod_Information.GetCacheWeapons(m).IsEmpty() ? $"<size=14>{string.Join("\n", FFU_BE_Mod_Information.GetCacheWeapons(m, " "))}</size>" : null);
			SafeUpdateField(200, sSpeedBonusText, m.HasFullHealth ? m.starmapSpeedAdd : m.starmapSpeedAdd * healthPercent, ref prevStarmapSpeedAdd, preColor + "{0:0.0} " + Localization.TT("ru") + "/" + Localization.TT("s") + aftColor);
			SafeUpdateField(220, sAsteroidDeflBonusText, m.HasFullHealth ? m.asteroidDeflectionPercentAdd : m.asteroidDeflectionPercentAdd * healthPercent, ref prevAsteroidDefl, preColor + "{0:0}%" + aftColor);
			SafeUpdateField(240, sEvasionBonusText, m.HasFullHealth ? m.shipEvasionPercentAdd : m.shipEvasionPercentAdd * healthPercent, ref prevShipEvasionPercentAdd, preColor + "{0:0} °/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(260, sAccuracyBonusText, m.HasFullHealth ? m.shipAccuracyPercentAdd : m.shipAccuracyPercentAdd * healthPercent, ref prevSAccuracyBonus, preColor + "<size=18>" + "{0:0}% Δ" + Localization.TT("m") + "</size>" + aftColor);
			SafeUpdateField(280, sMaxShieldBonusText, m.HasFullHealth ? m.maxShieldAdd : m.maxShieldAdd * healthPercent, ref prevMaxShieldAdd, preColor + "{0:0} " + Localization.TT("SP") + aftColor);
			SafeUpdateField(300, sMaxHealthBonusText, m.maxHealthAdd, ref prevMaxHealthAdd, "{0:0} " + Localization.TT("HP"));
			SafeUpdateField(500, starmapStealthDetMaxText, FFU_BE_Defs.GetModuleEnergyEmission(m), ref prevEnergyEmission, "{0:0.#} " + Localization.TT("m") + "³");
			if (!doOtherHovers) {
				UpdateHoverFlags(doOtherHovers: true);
				crewOpsHover.hoverText = $"{Localization.TT("Shows how much equipment or upgrade sets cache contains.")}";
				medbayHealSpotsHover.hoverText = $"{Localization.TT("Shows health points increase amount cache will provide to crewmembers, when applied.")}";
				dmgToCrewTextHover.hoverText = $"{Localization.TT("Shows health points increase limit after which upgrade cache will have no effect.")}";
				storageSizeHover.hoverText = $"{Localization.TT("Shows list of potentials weapons that crewmembers can equip, when cache is opened.")}";
				sSpeedBonusHover.hoverText = $"{Localization.TT("Shows interstellar travel speed increase artifact provides to the ship.")}";
				sAsteroidDeflBonusHover.hoverText = $"{Localization.TT("Shows protection efficiency against asteroids that artifact provides to the ship.")}";
				sEvasionBonusHover.hoverText = $"{Localization.TT("Shows maneuverability and evasive capabilities increase artifact provides to the ship.")}";
				sAccuracyBonusHover.hoverText = $"{Localization.TT("Shows efficiency of artifact targeting and lock-on systems that increase accuracy of all ship weapons.")}";
				sMaxShieldBonusHover.hoverText = $"{Localization.TT("Shows built-in shields capacity of the artifact.")}";
				sMaxHealthBonusHover.hoverText = $"{Localization.TT("Shows durability increase artifact provides to the ship.")}";
				starmapStealthDetMaxHover.hoverText = $"{Localization.TT("How much energy artifact currently emits and by how much it inflates ship's signature.")}";
			}
		}
		//Show Updated Crew Damage in Module Panel
		[MonoModReplace] private void DoWeaponCrewDmg(WeaponModule w, ShootAtDamageDealer.CrewDmgLevel crewDmgLevel) {
			dmgToCrewText.transform.parent.parent.gameObject.SetActive(crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None);
			dmgToCrewTextHover.hoverText = $"{Localization.TT("Chance to damage all crewmembers within area of effect by shown amount.")}";
			string crewDmgText = w.magazineSize + "x" + w.ProjectileOrBeamPrefab.GetDamage(w).doorDmg;
			dmgToCrewText.alignment = TextAnchor.MiddleLeft;
			switch (crewDmgLevel) {
				//case ShootAtDamageDealer.CrewDmgLevel.None: SafeUpdateField(dmgToCrewText, Localization.TT("None (" + (int)Core.CrewHitChance.None + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Low: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Low + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Default: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Medium + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.High: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.High + "%)")); break;
			}
		}
		//Show Update Fire Ignition Chance in Module Panel
		[MonoModReplace] private void DoWeaponFireChance(ShootAtDamageDealer.FireChanceLevel fireChanceLevel) {
			fireChanceText.transform.parent.parent.gameObject.SetActive(fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None);
			fireChanceHover.hoverText = $"{Localization.TT("Chance to ignite fire in every tile within area of effect.")}";
			fireChanceText.alignment = TextAnchor.MiddleLeft;
			switch (fireChanceLevel) {
				//case ShootAtDamageDealer.FireChanceLevel.None: SafeUpdateField(fireChanceText, Localization.TT("None (" + (int)Core.FireIgniteChance.None + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Low: SafeUpdateField(fireChanceText, Localization.TT("Low (" + (int)Core.FireIgniteChance.Low + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Default: SafeUpdateField(fireChanceText, Localization.TT("Medium (" + (int)Core.FireIgniteChance.Medium + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.High: SafeUpdateField(fireChanceText, Localization.TT("High (" + (int)Core.FireIgniteChance.High + "%)")); break;
			}
		}
		//Show Serviced Crewmember Types in Module Panel
		private string CrewmemberTypesText(Crewmember.Type[] crewTypes) {
			if (crewTypes.Contains(Crewmember.Type.Regular) && crewTypes.Contains(Crewmember.Type.Drone)) return $"{Localization.TT("Drones")}/{Localization.TT("Bio")}";
			else if (crewTypes.Contains(Crewmember.Type.Regular)) return $"{Localization.TT("Biologic")}";
			else if (crewTypes.Contains(Crewmember.Type.Drone)) return $"{Localization.TT("Mechanic")}";
			else return $"{Localization.TT("Pets Only")}";
		}
		//Sorted Resource Production Per Second
		[MonoModReplace] private void DoResourceProdPerSecond(ResourceValueGroup rp, float secondsPerConversion) {
			float organicsProd = rp.organics * 60f / secondsPerConversion;
			float fuelProd = rp.fuel * 60f / secondsPerConversion;
			float metalsProd = rp.metals * 60f / secondsPerConversion;
			float syntheticsProd = rp.synthetics * 60f / secondsPerConversion;
			float explosivesProd = rp.explosives * 60f / secondsPerConversion;
			float exoticsProd = rp.exotics * 60f / secondsPerConversion;
			float creditsProd = rp.credits * 60f / secondsPerConversion;
			SafeUpdateField(10, creditsProdText, m.HasFullHealth ? creditsProd : creditsProd * healthPercent, ref prevCredits, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(20, organicsProdText, m.HasFullHealth ? organicsProd : organicsProd * healthPercent, ref prevOrganics, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(30, fuelProdText, m.HasFullHealth ? fuelProd : fuelProd * healthPercent, ref prevFuel, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(40, metalsProdText, m.HasFullHealth ? metalsProd : metalsProd * healthPercent, ref prevMetals, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(50, syntheticsProdText, m.HasFullHealth ? syntheticsProd : syntheticsProd * healthPercent, ref prevSynth, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(60, explosivesProdText, m.HasFullHealth ? explosivesProd : explosivesProd * healthPercent, ref prevExpl, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			SafeUpdateField(70, exoticsContCurText, m.HasFullHealth ? exoticsProd : exoticsProd * healthPercent, ref prevExotics, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
			//SafeUpdateField(70, exoticsProdText, m.HasFullHealth ? exoticsProd : exoticsProd * healthPercent, ref prevExotics, preColor + "{0:0}/" + Localization.TT("min.") + aftColor);
		}
		//Sorted Resource Consumption Per Second
		[MonoModReplace] private void DoResourceConsPerSecond(ResourceValueGroup rc, float secondsPerConversion) {
			float organicsCons = rc.organics * 60f / secondsPerConversion;
			float fuelCons = rc.fuel * 60f / secondsPerConversion;
			float metalsCons = rc.metals * 60f / secondsPerConversion;
			float syntheticsCons = rc.synthetics * 60f / secondsPerConversion;
			float explosivesCons = rc.explosives * 60f / secondsPerConversion;
			float exoticsCons = rc.exotics * 60f / secondsPerConversion;
			SafeUpdateField(110, organicsConsText, organicsCons, ref prevOrganicsCons, "{0:0}/" + Localization.TT("min."));
			SafeUpdateField(120, fuelConsText, fuelCons, ref prevFuelCons, "{0:0}/" + Localization.TT("min."));
			SafeUpdateField(130, metalsConsText, metalsCons, ref prevMetalsCons, "{0:0}/" + Localization.TT("min."));
			SafeUpdateField(140, syntheticsConsText, syntheticsCons, ref prevSynthCons, "{0:0}/" + Localization.TT("min."));
			SafeUpdateField(150, explosivesConsText, explosivesCons, ref prevExplCons, "{0:0}/" + Localization.TT("min."));
			SafeUpdateField(160, exoticsConsText, exoticsCons, ref prevExoticsCons, "{0:0}/" + Localization.TT("min."));
		}
		//New Function: Components Direct Data & Properties Access
		private void UpdateHoverFlags(bool doWeaponHovers = false, bool doNukeHovers = false, bool doPointDefHovers = false, bool doEngineHovers = false,
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
		//New Function: Set Sort Order for Data Entries
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
		//New Function: List Index of Each Possible Element
		private void ListAllElementsIndexes() {
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
		[MonoModIgnore] private Crewmember c;
		//Crewmember Weapon Full Information Window
		private void Update() {
			orig_Update();
			if (c != null) health.horizontalOverflow = HorizontalWrapMode.Overflow;
			if (c != null && c.HandWeaponPrefab != null) handWeaponDescriptionHover.hoverText = FFU_BE_Mod_Information.GetSelectedWeaponExactData(c.HandWeaponPrefab);
		}
	}
}
