#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108

using HarmonyLib;
using MonoMod;
using RST;
using System;
using UnityEngine;
using UnityEngine.UI;
using FFU_Bleeding_Edge;
using System.Text;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Information {
		public static string GetSelectedWeaponExactData(HandWeapon handWeapon) {
			string weaponData = "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg > 0 ? $"{Core.TT("Crew Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "")}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg}\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg > 0 ? $"{Core.TT("Door Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "")}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg}\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "")}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg}\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "")}{handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg}\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance > 0 ? $"{Core.TT("Module Hit Chance")}: {handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance * 100f:0}%\n" : "";
			weaponData += handWeapon.farthestAttackDistance > 0 ? $"{Core.TT("Effective Range")}: {handWeapon.farthestAttackDistance}{Core.TT("m")}\n" : "";
			weaponData += handWeapon.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {handWeapon.reloadInterval}{Core.TT("s")}\n" : "";
			weaponData += handWeapon.shotInterval > 0 ? $"{Core.TT("Salvo Delay")}: {handWeapon.shotInterval}{Core.TT("s")}\n" : "";
			weaponData += handWeapon.accuracy > 0 ? $"{Core.TT("Accuracy")}: {handWeapon.accuracy} Δ{Core.TT("m")}\n" : "";
			if (!string.IsNullOrEmpty(weaponData)) weaponData = $"<color=lime>{weaponData}</color>{handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			else weaponData = handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			return weaponData;
		}
		public static string GetSelectedModuleExactData(ShipModule shipModule, bool isInst = true) {
			string moduleData = "";
			string instanceText = "";
			if (shipModule.name.Contains("bossweapon")) return $"<color=lime>{Core.TT("Type")}: {Core.TT("Unidentified")}</color>\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			if (shipModule.name.Contains("tutorial")) return $"<color=lime>{Core.TT("Type")}: {Core.TT("Unidentified")}</color>\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(GetWeaponCategory(shipModule))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Weapon.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {shipModule.Weapon.reloadInterval:0.##}{Core.TT("s")}\n" : "";
				moduleData += shipModule.Weapon.preShootDelay > 0 ? $"{Core.TT("Ignition Time")}: {shipModule.Weapon.preShootDelay:0.##}{Core.TT("s")}\n" : "";
				moduleData += shipModule.Weapon.shotInterval > 0 ? $"{Core.TT("Salvo Delay")}: {shipModule.Weapon.shotInterval:0.##}{Core.TT("s")}\n" : "";
				moduleData += shipModule.Weapon.accuracy > 0 ? $"{Core.TT("Accuracy")}: {shipModule.Weapon.accuracy:0} Δ{Core.TT("m")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? $"{Core.TT("Damage Radius")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f:0.##}{Core.TT("m")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? $"{Core.TT("Ignores Shields")}: {Core.TT("Yes")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? $"{Core.TT("Never Deflects")}: {Core.TT("Yes")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? $"{Core.TT("Shield Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? $"{Core.TT("Crew Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? $"{Core.TT("Crew Hit Chance")}: {GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel)}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? $"{Core.TT("Fire Ignite Chance")}: {GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel)}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? $"{Core.TT("EMP Effect")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds}{Core.TT("s")}\n" : "";
				moduleData += !shipModule.Weapon.resourcesPerShot.IsEmpty ? $"{Core.TT("Resources Per Shot")}:\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Weapon.resourcesPerShot.credits:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Weapon.resourcesPerShot.organics:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Weapon.resourcesPerShot.fuel:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Weapon.resourcesPerShot.metals:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Weapon.resourcesPerShot.synthetics:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Weapon.resourcesPerShot.explosives:0}\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Weapon.resourcesPerShot.exotics:0}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Damage Dealer")}: {Core.TT("Projectile")}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Projectile Health")}: {(shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth"))}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Projectile Velocity")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed}00{Core.TT("m")}/{Core.TT("s")}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Point Defense Detection")}: {(shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis"))}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $" > {Core.TT("Point Defense Priority")}: {AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority")}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $"{Core.TT("Damage Dealer")}: {Core.TT("Beam")}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? $" > {Core.TT("Beam Duration")}: {(shipModule.Weapon.ProjectileOrBeamPrefab as Beam).duration}{Core.TT("s")}\n" : "";
				break;
				case ShipModule.Type.Weapon_Nuke:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Capital Missile")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? $"{Core.TT("Damage Radius")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f:0.##}{Core.TT("m")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? $"{Core.TT("Ignores Shields")}: {Core.TT("Yes")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? $"{Core.TT("Never Deflects")}: {Core.TT("Yes")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? $"{Core.TT("Shield Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? $"{Core.TT("Module Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? $"{Core.TT("Hull Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? $"{Core.TT("Crew Damage")}: {(shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "")}{shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? $"{Core.TT("Crew Hit Chance")}: {GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel)}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? $"{Core.TT("Fire Ignite Chance")}: {GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel)}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? $"{Core.TT("EMP Effect")}: {shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds}{Core.TT("s")}\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? $"{Core.TT("Boarding Payload")}: {FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 2f:0} ~ {FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 5f:0} {Core.TT("Units")}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Capital Missile Health")}: {(shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth"))}\n" : "";
				try { moduleData += $"{Core.TT("Missile Acceleration")}: {((HomingMovement)AccessTools.PropertyGetter(typeof(Projectile), "HomingMovement").Invoke(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, null)).force * 10f} {Core.TT("m")}/{Core.TT("s")}²\n"; } catch { }
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Point Defense Detection")}: {(shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis"))}\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? $"{Core.TT("Point Defense Priority")}: {AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority")}\n" : "";
				break;
				case ShipModule.Type.PointDefence:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Close-In Weapon System")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.PointDefence.reloadInterval > 0 ? $"{Core.TT("Reload Time")}: {shipModule.PointDefence.reloadInterval:0.##}{Core.TT("s")}\n" : "";
				moduleData += shipModule.PointDefence.coverRadius > 0 ? $"{Core.TT("Cover Radius")}: {shipModule.PointDefence.coverRadius * 10f:0.##}{Core.TT("m")}\n" : "";
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg > 0 ? $"{Core.TT("Interception Damage")}: {shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg}\n" : "";
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.lifetime > 0 ? $"{Core.TT("Interception Delay")}: {shipModule.PointDefence.projectileOrBeamPrefab.lifetime:0.##}{Core.TT("s")}\n" : "";
				moduleData += !shipModule.PointDefence.resourcesPerShot.IsEmpty ? $"{Core.TT("Resources Per Shot")}:\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.PointDefence.resourcesPerShot.credits:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.PointDefence.resourcesPerShot.organics:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.PointDefence.resourcesPerShot.fuel:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.PointDefence.resourcesPerShot.metals:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.PointDefence.resourcesPerShot.synthetics:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.PointDefence.resourcesPerShot.explosives:0}\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.PointDefence.resourcesPerShot.exotics:0}\n" : "";
				break;
				case ShipModule.Type.Bridge:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Command Bridge")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Bridge Operators")}: {shipModule.OperatorSpots.Length}\n" : "";
				break;
				case ShipModule.Type.Engine:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Sub-Light Engine")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += !shipModule.Engine.ConsumedPerDistance.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Engine.ConsumedPerDistance.credits * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Engine.ConsumedPerDistance.organics * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Engine.ConsumedPerDistance.fuel * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Engine.ConsumedPerDistance.metals * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Engine.ConsumedPerDistance.synthetics * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Engine.ConsumedPerDistance.explosives * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Engine.ConsumedPerDistance.exotics * 100:0}/100{Core.TT("ru")}\n" : "";
				break;
				case ShipModule.Type.Warp:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Warp Drive")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Warp.reloadInterval > 0 ? $"{Core.TT("Jump Drive Recharge")}: {shipModule.Warp.reloadInterval}{Core.TT("s")}\n" : "";
				moduleData += shipModule.Warp.activationFuel > 0 ? $"{Core.TT("Jump Fuel Consumption")}: {shipModule.Warp.activationFuel}\n" : "";
				break;
				case ShipModule.Type.Reactor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Energy Reactor")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Reactor.powerCapacity > 0 ? $"{Core.TT("Power Production")}: {shipModule.Reactor.powerCapacity} {Core.TT("GW/h")}\n" : "";
				moduleData += shipModule.Reactor.overchargePowerCapacityAdd > 0 ? $"{Core.TT("Overcharge Production")}: {(shipModule.Reactor.overchargePowerCapacityAdd / (float)shipModule.Reactor.powerCapacity + 1f) * 100f:0}%\n" : "";
				moduleData += shipModule.overchargeSeconds > 0 ? $"{Core.TT("Overcharge Time")}: {shipModule.overchargeSeconds}{Core.TT("s")}\n" : "";
				moduleData += !shipModule.Reactor.ConsumedPerDistance.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Reactor.ConsumedPerDistance.credits * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Reactor.ConsumedPerDistance.organics * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Reactor.ConsumedPerDistance.fuel * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Reactor.ConsumedPerDistance.metals * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Reactor.ConsumedPerDistance.synthetics * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Reactor.ConsumedPerDistance.explosives * 100:0}/100{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Reactor.ConsumedPerDistance.exotics * 100:0}/100{Core.TT("ru")}\n" : "";
				break;
				case ShipModule.Type.Container:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Storage Container")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Container.MaxOrganics > 0 ? $"{Core.TT("Organics Storage")}: {shipModule.Container.MaxOrganics:0}\n" : "";
				moduleData += shipModule.Container.MaxFuel > 0 ? $"{Core.TT("Starfuel Storage")}: {shipModule.Container.MaxFuel:0}\n" : "";
				moduleData += shipModule.Container.MaxMetals > 0 ? $"{Core.TT("Metals Storage")}: {shipModule.Container.MaxMetals:0}\n" : "";
				moduleData += shipModule.Container.MaxSynthetics > 0 ? $"{Core.TT("Synthetics Storage")}: {shipModule.Container.MaxSynthetics:0}\n" : "";
				moduleData += shipModule.Container.MaxExplosives > 0 ? $"{Core.TT("Explosives Storage")}: {shipModule.Container.MaxExplosives:0}\n" : "";
				moduleData += shipModule.Container.MaxExotics > 0 ? $"{Core.TT("Exotics Storage")}: {shipModule.Container.MaxExotics:0}\n" : "";
				break;
				case ShipModule.Type.Integrity:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Integrity Armor")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.ShieldGen:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT((shipModule.ShieldGen.reloadInterval > 0 ? "Shield Generator" : "Shield Capacitor"))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.ShieldGen.reloadInterval > 0 ? $"{Core.TT("Shield Regeneration")}: {Core.TT("SP")}/{shipModule.ShieldGen.reloadInterval}{Core.TT("s")}\n" : "";
				moduleData += shipModule.ShieldGen.maxShieldAdd > 0 ? $"{Core.TT("Shield Capacity")}: {shipModule.ShieldGen.maxShieldAdd}\n" : "";
				break;
				case ShipModule.Type.Sensor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Sensor Array")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.Sensor.sectorRadarRange > 0 ? $"{Core.TT("Sector Radar Range")}: {shipModule.Sensor.sectorRadarRange}{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Sensor.starmapRadarRange > 0 ? $"{Core.TT("Starmap Radar Range")}: {shipModule.Sensor.starmapRadarRange}{Core.TT("ru")}\n" : "";
				break;
				case ShipModule.Type.StealthDecryptor:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Stealth Generator")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.PassiveECM:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Countermeasure Array")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				string mType = shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Restoration Bay" :
					!shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Drone Repair Bay" :
					shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) && !shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? "Crew Medical Bay" : 
					"Unidentified Health Bay";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(mType)}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Service Capacity")}: {shipModule.OperatorSpots.Length}\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 ? $"{Core.TT("Restoration Speed")}: {Core.TT("HP")}/{shipModule.Medbay.secondsPerHp}{Core.TT("s")}\n" : "";
				moduleData += !shipModule.Medbay.resourcesPerHp.IsEmpty ? $"{Core.TT("Resources Consumption")}:\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.Medbay.resourcesPerHp.credits:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.Medbay.resourcesPerHp.organics:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.Medbay.resourcesPerHp.fuel:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.Medbay.resourcesPerHp.metals:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.Medbay.resourcesPerHp.synthetics:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.Medbay.resourcesPerHp.explosives:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.resourcesPerHp.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.Medbay.resourcesPerHp.exotics:0}/{Core.TT("HP")}\n" : "";
				moduleData += shipModule.Medbay.acceptCrewTypes.Length > 0 ? $"{Core.TT("Serviced Crew Types")}:\n" : "";
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Regular) ? $" > {Core.TT("Crewmembers")}\n" : "";
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Drone) ? $" > {Core.TT("Drones")}\n" : "";
				moduleData += shipModule.Medbay.acceptCrewTypes.Contains(Crewmember.Type.Pet) ? $" > {Core.TT("Pets")}\n" : "";
				break;
				case ShipModule.Type.Cryosleep:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT((shipModule.Cryosleep.genDreamCredits ? "Cryodream Bay" : "Cryosleep Bay"))}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Available Cryopods")}: {shipModule.OperatorSpots.Length}\n" : "";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? $"{Core.TT("Crew Food Consumption")}: {Core.TT("Disabled")}\n" : "";
				moduleData += shipModule.Cryosleep.healOneCrewHp ? $"{Core.TT("Health Recovery Distance")}: {shipModule.Cryosleep.healOneCrewHpDistance.minValue} ~ {shipModule.Cryosleep.healOneCrewHpDistance.maxValue}{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Cryosleep.genDreamCredits ? $"{Core.TT("Cryodream Record Distance")}: {shipModule.Cryosleep.genDreamCreditsDistance.minValue}{Core.TT("ru")} ~ {shipModule.Cryosleep.genDreamCreditsDistance.maxValue}{Core.TT("ru")}\n" : "";
				moduleData += shipModule.Cryosleep.genDreamCredits ? $"{Core.TT("Credits Per Cryodream")}: {shipModule.Cryosleep.creditsPerDream.minValue} ~ {shipModule.Cryosleep.creditsPerDream.maxValue}\n" : "";
				break;
				case ShipModule.Type.ResearchLab:
				ResearchModule rLab = shipModule.Research;
				ResourceValueGroup laboratoryOutput = isInst ? rLab.ProducedPerDistance : rLab.producedPerSkillPoint;
				float researchSpeed = FFU_BE_Defs.GetResearchFromRVG(laboratoryOutput) * FFU_BE_Defs.tierResearchSpeedMult;
				float reversingSpeed = FFU_BE_Defs.GetReverseFromRVG(laboratoryOutput) * FFU_BE_Defs.moduleResearchSpeedMult;
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Research Laboratory")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Available Workstations")}: {shipModule.OperatorSpots.Length}\n" : "";
				moduleData += researchSpeed > 0 || reversingSpeed > 0 ? $"{Core.TT("Laboratory Effects")}:\n" : "";
				moduleData += researchSpeed > 0 ? $" > {Core.TT("Research Progress")}: {researchSpeed * 100f:0.0}/100{Core.TT("ru")}\n" : "";
				moduleData += reversingSpeed > 0 ? $" > {Core.TT("Reverse Engineering")}: {reversingSpeed * 100f:0.0}/100{Core.TT("ru")}\n" : "";
				moduleData += !laboratoryOutput.IsEmpty ? $"{Core.TT("Effective Production")}:\n" : "";
				moduleData += laboratoryOutput.credits > 0 ? $" > {Core.TT("Credits")}: {laboratoryOutput.credits}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.organics > 0 ? $" > {Core.TT("Organics")}: {laboratoryOutput.organics}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.fuel > 0 ? $" > {Core.TT("Starfuel")}: {laboratoryOutput.fuel}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.metals > 0 ? $" > {Core.TT("Metals")}: {laboratoryOutput.metals}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {laboratoryOutput.synthetics}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.explosives > 0 ? $" > {Core.TT("Explosives")}: {laboratoryOutput.explosives}/100{Core.TT("ru")}\n" : "";
				moduleData += laboratoryOutput.exotics > 0 ? $" > {Core.TT("Exotics")}: {laboratoryOutput.exotics}/100{Core.TT("ru")}\n" : "";
				break;
				case ShipModule.Type.Garden:
				GardenModule rGreen = shipModule.GardenModule;
				ResourceValueGroup greenhouseOutput = isInst ? rGreen.ProducedPerDistance : rGreen.producedPerSkillPoint;
				float effectiveAgriInput = isInst ? WorldRules.Instance.gardenSkillEffects.EffectiveOrganicsProduction(shipModule) / shipModule.GardenModule.producedPerSkillPoint.organics : 1f;
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Greenhouse Facility")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Available Workplaces")}: {shipModule.OperatorSpots.Length}\n" : "";
				moduleData += shipModule.OperatorSpots.Length > 0 ? $"{Core.TT("Workers Food Consumption")}: {Core.TT("Disabled")}\n" : "";
				moduleData += !greenhouseOutput.IsEmpty ? $"{Core.TT("Effective Production")}:\n" : "";
				moduleData += greenhouseOutput.credits > 0 ? $" > {Core.TT("Credits")}: {greenhouseOutput.credits}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.organics > 0 ? $" > {Core.TT("Organics")}: {greenhouseOutput.organics}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.fuel > 0 ? $" > {Core.TT("Starfuel")}: {greenhouseOutput.fuel}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.metals > 0 ? $" > {Core.TT("Metals")}: {greenhouseOutput.metals}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {greenhouseOutput.synthetics}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.explosives > 0 ? $" > {Core.TT("Explosives")}: {greenhouseOutput.explosives}/100{Core.TT("ru")}\n" : "";
				moduleData += greenhouseOutput.exotics > 0 ? $" > {Core.TT("Exotics")}: {greenhouseOutput.exotics}/100{Core.TT("ru")}\n" : "";
				break;
				case ShipModule.Type.MaterialsConverter:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Industrial Facility")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				moduleData += !shipModule.MaterialsConverter.produce.IsEmpty ? $"{Core.TT("Industrial Production")}:\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.MaterialsConverter.produce.credits * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.MaterialsConverter.produce.organics * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.MaterialsConverter.produce.fuel * 60}{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.MaterialsConverter.produce.metals * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.MaterialsConverter.produce.synthetics * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.MaterialsConverter.produce.explosives * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.MaterialsConverter.produce.exotics * 60}/{Core.TT("min.")}\n" : "";
				moduleData += !shipModule.MaterialsConverter.consume.IsEmpty ? $"{Core.TT("Industrial Consumption")}:\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.credits > 0 ? $" > {Core.TT("Credits")}: {shipModule.MaterialsConverter.consume.credits * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.organics > 0 ? $" > {Core.TT("Organics")}: {shipModule.MaterialsConverter.consume.organics * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.fuel > 0 ? $" > {Core.TT("Starfuel")}: {shipModule.MaterialsConverter.consume.fuel * 60}{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.metals > 0 ? $" > {Core.TT("Metals")}: {shipModule.MaterialsConverter.consume.metals * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.synthetics > 0 ? $" > {Core.TT("Synthetics")}: {shipModule.MaterialsConverter.consume.synthetics * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.explosives > 0 ? $" > {Core.TT("Explosives")}: {shipModule.MaterialsConverter.consume.explosives * 60}/{Core.TT("min.")}\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.exotics > 0 ? $" > {Core.TT("Exotics")}: {shipModule.MaterialsConverter.consume.exotics * 60}/{Core.TT("min.")}\n" : "";
				break;
				case ShipModule.Type.Fighter:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT("Fighter Bay")}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				break;
				case ShipModule.Type.Decoy:
				instanceText = isInst ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
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
				instanceText = isInst && defCat != "Artifact" ? $"{Core.TT(GetModuleGenText(shipModule))} {Core.TT("Gen.")} " : "";
				moduleData += $"{Core.TT("Type")}: {instanceText}{Core.TT(defCat)}\n";
				if (isInst) moduleData += $"{Core.TT("Modifier")}: {Core.TT(GetModuleModText(shipModule))}\n";
				if (defCat.Contains("Cache")) {
					int maxSets = 3 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f);
					int maxInc = (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f);
					int maxLimit = 25 + (int)FFU_BE_Mod_Technology.GetModuleTier(shipModule) * 25;
					switch (GetCacheType(shipModule)) {
						case "Mechanical Upgrades":
						moduleData += $"{Core.TT("Available Upgrade Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Health Increase Per Set")}: {maxInc}\n";
						moduleData += $"{Core.TT("Health Increase Limit")}: {maxLimit}\n";
						break;
						case "Biological Implants":
						moduleData += $"{Core.TT("Available Implant Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Health Increase Per Set")}: {maxInc}\n";
						moduleData += $"{Core.TT("Health Increase Limit")}: {maxLimit}\n";
						break;
						case "CQC Class Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Power Fists")}\n";
						moduleData += $" > {Core.TT("Dual Welder")}\n";
						moduleData += $" > {Core.TT("Napalm Gun")}\n";
						moduleData += $" > {Core.TT("Toxic Gun")}\n";
						break;
						case "Kinetic Type Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Assault Pistol")}\n";
						moduleData += $" > {Core.TT("Light Revolver")}\n";
						moduleData += $" > {Core.TT("Heavy Revolver")}\n";
						moduleData += $" > {Core.TT("Assault Revolver")}\n";
						moduleData += $" > {Core.TT("Assault SMG")}\n";
						moduleData += $" > {Core.TT("Assault Shotgun")}\n";
						moduleData += $" > {Core.TT("Assault Rifle")}\n";
						moduleData += $" > {Core.TT("Assault Autocannon")}\n";
						moduleData += $" > {Core.TT("Breacher Cannon")}\n";
						moduleData += $" > {Core.TT("Assault Railgun")}\n";
						break;
						case "Laser Type Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Laser Pistol")}\n";
						moduleData += $" > {Core.TT("Laser Rifle")}\n";
						moduleData += $" > {Core.TT("Laser Cannon")}\n";
						break;
						case "Energy Type Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Blaster Pistol")}\n";
						moduleData += $" > {Core.TT("Blaster Rifle")}\n";
						moduleData += $" > {Core.TT("Warp Ray Gun")}\n";
						moduleData += $" > {Core.TT("Particle Gun")}\n";
						break;
						case "Backup Class Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Assault Pistol")}\n";
						moduleData += $" > {Core.TT("Light Revolver")}\n";
						moduleData += $" > {Core.TT("Heavy Revolver")}\n";
						moduleData += $" > {Core.TT("Assault Revolver")}\n";
						moduleData += $" > {Core.TT("Laser Pistol")}\n";
						break;
						case "Tactical Class Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Assault SMG")}\n";
						moduleData += $" > {Core.TT("Assault Shotgun")}\n";
						moduleData += $" > {Core.TT("Assault Rifle")}\n";
						moduleData += $" > {Core.TT("Laser Rifle")}\n";
						break;
						case "Assault Class Weapons":
						moduleData += $"{Core.TT("Available Weapon Sets")}: {maxSets}\n";
						moduleData += $"{Core.TT("Available Weapons")}: \n";
						moduleData += $" > {Core.TT("Assault Autocannon")}\n";
						moduleData += $" > {Core.TT("Breacher Cannon")}\n";
						moduleData += $" > {Core.TT("Assault Railgun")}\n";
						moduleData += $" > {Core.TT("Laser Cannon")}\n";
						break;
					}
				}
				break;
			}
			moduleData += shipModule.starmapStealthDetectionLevelMax > 0 ? $"{Core.TT("Stealth Decryption Level")}: {shipModule.starmapStealthDetectionLevelMax}\n" : "";
			moduleData += shipModule.shipEvasionPercentAdd != 0 ? $"{Core.TT("Evasion Modifier")}: {(shipModule.shipEvasionPercentAdd > 0 ? "+" : "")}{shipModule.shipEvasionPercentAdd}%\n" : "";
			if (shipModule.type == ShipModule.Type.Engine) moduleData += shipModule.Engine.overchargeEvasionAdd > 0 && shipModule.shipEvasionPercentAdd > 0 ? $"{Core.TT("Evasion Boost")}: {(shipModule.Engine.overchargeEvasionAdd / (float)shipModule.shipEvasionPercentAdd + 1f) * 100f:0}%" + "\n" : "";
			moduleData += shipModule.shipAccuracyPercentAdd != 0 ? $"{Core.TT("Accuracy Modifier")}: {(shipModule.shipAccuracyPercentAdd > 0 ? "+" : "")}{shipModule.shipAccuracyPercentAdd}%\n" : "";
			moduleData += shipModule.asteroidDeflectionPercentAdd != 0 ? $"{Core.TT("Asteroid Deflection")}: {(shipModule.asteroidDeflectionPercentAdd > 0 ? "+" : "")}{shipModule.asteroidDeflectionPercentAdd}%\n" : "";
			moduleData += shipModule.starmapSpeedAdd != 0 ? $"{Core.TT("")}Interstellar Speed: {(shipModule.starmapSpeedAdd > 0 ? "+" : "")}{shipModule.starmapSpeedAdd:0.0} {Core.TT("ru")}/{Core.TT("s")}\n" : "";
			moduleData += shipModule.maxHealthAdd != 0 ? $"{Core.TT("Ship Armor Modifier")}: {(shipModule.maxHealthAdd > 0 ? "+" : "")}{shipModule.maxHealthAdd}\n" : "";
			moduleData += shipModule.maxShieldAdd != 0 ? $"{Core.TT("Ship Shields Modifier")}: {(shipModule.maxShieldAdd > 0 ? "+" : "")}{shipModule.maxShieldAdd}\n" : "";
			moduleData += shipModule.PowerConsumed > 0 ? $"{Core.TT("Power Consumption")}: {shipModule.PowerConsumed} {Core.TT("GW/h")}\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargePowerNeed > 0 ? $"{Core.TT("Overcharge Consumption")}: {(shipModule.overchargePowerNeed / (float)shipModule.PowerConsumed + 1f) * 100f:0}%\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargeSeconds > 0 ? $"{Core.TT("Overcharge Time")}: {shipModule.overchargeSeconds}{Core.TT("s")}\n" : "";
			if (isInst && (shipModule.turnedOn || !shipModule.UsesTurnedOn)) moduleData += $"{Core.TT("Energy Emission")}: {FFU_BE_Defs.GetModuleEnergyEmission(shipModule):0.#}{Core.TT("m")}³\n";
			else if (!isInst) moduleData += $"{Core.TT("Energy Emission")}: {FFU_BE_Defs.GetModuleEmissionValues(shipModule)}\n";
			moduleData += shipModule.MaxHealth > 0 ? $"{Core.TT("Module Durability")}: {shipModule.MaxHealth} {Core.TT("HP")}\n" : "";
			moduleData += shipModule.costCreditsInShop > 0 ? $"{Core.TT("Market Price")}: ${shipModule.costCreditsInShop}" : $"{Core.TT("Market Price")}: {Core.TT("N/A")}";
			if (!isInst) return $"<color=lime>{moduleData}</color>\n{shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit)}";
			else return $"<color=lime>{moduleData}</color>";
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
			if (shipModule == null) return "";
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
				default: return "";
			}
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
		private extern void orig_Update();
		[MonoModIgnore] private ShipModule m;
		[MonoModIgnore] private float prevOpSpots;
		[MonoModIgnore] private float prevOrganics;
		[MonoModIgnore] private float prevFuel;
		[MonoModIgnore] private float prevMetals;
		[MonoModIgnore] private float prevSynth;
		[MonoModIgnore] private float prevExpl;
		[MonoModIgnore] private float prevExotics;
		[MonoModIgnore] private float prevWeaponDmgArea;
		[MonoModIgnore] private float prevPowerCapacity;
		[MonoModIgnore] private float prevShieldAdd;
		[MonoModIgnore] private float prevActivationFuel;
		[MonoModIgnore] private float prevHealingSpots;
		[MonoModIgnore] private float prevHealingInvSpeed;
		[MonoModIgnore] private float prevOrganicsPerHp;
		[MonoModIgnore] private float prevSyntheticsPerHp;
		[MonoModIgnore] private float prevStarmapSpeedAdd;
		[MonoModIgnore] private float prevAsteroidDefl;
		[MonoModIgnore] private float prevSAccuracyBonus;
		[MonoModIgnore] private float prevShipEvasionPercentAdd;
		[MonoModIgnore] private void SafeUpdateField(Text text, string value) { }
		[MonoModIgnore] private void DoResourceConsPerDist(ResourceValueGroup rc, ShipModule m) { }
		[MonoModIgnore] private static void DoRequirementColor(Text text, HoverableUI h, bool hasEnough) { }
		[MonoModIgnore] private void DoResourceProdPerSecond(ResourceValueGroup rp, float secondsPerConversion) { }
		[MonoModIgnore] private void DoResourceConsPerSecond(ResourceValueGroup rc, float secondsPerConversion) { }
		[MonoModIgnore] private static void AppendDmgLine(StringBuilder sb, string localizedLine, int dmg, int cnt) { }
		[MonoModIgnore] private void SafeUpdateField(Text text, float value, ref float prevValue, string format = "{0}") { }
		[MonoModIgnore] private void UpdateGroupedDmg(bool showShieldIcon, bool showShipIcon, bool showModuleIcon, string value) { }
		//Selected Module Full Information Window
		private void Update() {
			orig_Update();
			if (m != null) if (!m.HasFullHealth) {
				SafeUpdateField(sSpeedBonusText, m.starmapSpeedAdd * FFU_BE_Defs.GetHealthPercent(m), ref prevStarmapSpeedAdd, "<color=red>{0:0.0}</color>");
				SafeUpdateField(sAsteroidDeflBonusText, m.asteroidDeflectionPercentAdd * FFU_BE_Defs.GetHealthPercent(m), ref prevAsteroidDefl, "<color=red>{0:0}%</color>");
				SafeUpdateField(sAccuracyBonusText, m.shipAccuracyPercentAdd * FFU_BE_Defs.GetHealthPercent(m), ref prevSAccuracyBonus, "<color=red>{0:0}%</color>");
				if (m.type != ShipModule.Type.Bridge) SafeUpdateField(sEvasionBonusText, m.shipEvasionPercentAdd * FFU_BE_Defs.GetHealthPercent(m), ref prevShipEvasionPercentAdd, "<color=red>{0:0}</color>");
			}
			exoticsProdText.transform.parent.parent.gameObject.SetActive(false);
			if (m != null) health.horizontalOverflow = HorizontalWrapMode.Overflow;
			if (m != null && m.Ownership.GetOwner() == Ownership.Owner.Me && iconHover.Hovered) iconHover.hoverText = FFU_BE_Mod_Information.GetSelectedModuleExactData(m);
		}
		//Updated Weapon Information
		[MonoModReplace] private void DoWeapon() {
			WeaponModule weapon = m.Weapon;
			ShootAtDamageDealer.Damage damage = weapon.ProjectileOrBeamPrefab.GetDamage(weapon);
			string text = Localization.TT("per");
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			if (weapon.accuracy != 0) {
				weaponAccuracy.SetActiveIfNeeded();
				int effAccuracy = gunnerySkillEffects.EffectiveAccuracy(weapon);
				if (m.HasFullHealth) weaponAccuracy.effects.text = weapon.accuracy != effAccuracy ? $"<color=lime>{effAccuracy:0} {Localization.TT("Δm")}</color>" : $"{effAccuracy:0} {Localization.TT("Δm")}";
				else weaponAccuracy.effects.text = $"<color=red>{effAccuracy:0} {Localization.TT("Δm")}</color>";
				weaponAccuracy.skillBonus.text = "+" + gunnerySkillEffects.skillPointAccuracyBonus.ToString("0.0") + " " + text;
				weaponAccuracy.Hoverable.hoverText = string.Format(weaponAccuracy.HoverableTextTemplate, effAccuracy, gunnerySkillEffects.EffectiveAngle(weapon), gunnerySkillEffects.skillPointAccuracyBonus.ToString("0.0"));
			}
			if (weapon.reloadInterval != 0f) {
				weaponReloadTime.SetActiveIfNeeded();
				float effReload = gunnerySkillEffects.EffectiveReloadTime(weapon);
				if (m.HasFullHealth) weaponReloadTime.effects.text = weapon.reloadInterval != effReload ? $"<color=lime>{effReload:0.0}{Localization.TT("s")}</color>" : $"{effReload:0.0}{Localization.TT("s")}";
				else weaponReloadTime.effects.text = $"<color=red>{effReload:0.0}{Localization.TT("s")}</color>";
				weaponReloadTime.skillBonus.text = $"-{((!weapon.reloadIntervalTakesNoBonuses) ? gunnerySkillEffects.skillPointBonusPercent : 0)}% {text}";
				weaponReloadTime.Hoverable.hoverText = string.Format(weaponReloadTime.HoverableTextTemplate, gunnerySkillEffects.skillPointBonusPercent);
			}
			weaponTracksTargetGo.SetActive(false);
			_ = weapon.tracksTarget;
			weaponIgnoresShieldGo.SetActive(damage.ignoresShield);
			weaponNeverDeflectsGo.SetActive(damage.neverDeflect);
			if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg && damage.shipDmg == damage.moduleDmg) {
				if (!groupedDmg.activeSelf) groupedDmg.SetActive(true);
				UpdateGroupedDmg(true, true, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.shipDmg) {
				UpdateGroupedDmg(true, true, false, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
			} else if (damage.shieldDmg != 0 && damage.shieldDmg == damage.moduleDmg) {
				UpdateGroupedDmg(true, false, true, $"{weapon.magazineSize}x{damage.shieldDmg}");
				if (damage.shipDmg != 0) SafeUpdateField(dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
			} else if (damage.shipDmg != 0 && damage.shipDmg == damage.moduleDmg) {
				UpdateGroupedDmg(false, true, true, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
			} else {
				if (damage.shipDmg != 0) SafeUpdateField(dmgToShipsText, $"{weapon.magazineSize}x{damage.shipDmg}");
				if (damage.moduleDmg != 0) SafeUpdateField(dmgToModulesText, $"{weapon.magazineSize}x{damage.moduleDmg}");
				if (damage.shieldDmg != 0) SafeUpdateField(dmgToShieldsText, $"{weapon.magazineSize}x{damage.shieldDmg}");
			}
			StringBuilder stringBuilder = RstShared.StringBuilder;
			if (damage.shipDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to armor"), damage.shipDmg, weapon.magazineSize);
			if (damage.moduleDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to modules"), damage.moduleDmg, weapon.magazineSize);
			if (damage.shieldDmg != 0) AppendDmgLine(stringBuilder, MonoBehaviourExtended.TT("Damage to shields"), damage.shieldDmg, weapon.magazineSize);
			groupedDmgTextHover.hoverText = (stringBuilder.Length <= 0) ? "" : stringBuilder.ToString(0, stringBuilder.Length - 1);
			SafeUpdateField(empOverloadText, (damage.moduleOverloadSeconds != 0) ? string.Format(Localization.TT("EMP {0}s"), damage.moduleOverloadSeconds) : null);
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
			SafeUpdateField(dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.##}m");
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
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
			if (m.HasFullHealth) pointDefReloadTime.effects.text = pointDefence.reloadInterval != pdEffReload ? $"<color=lime>{pdEffReload:0.00}{Localization.TT("s")}</color>": $"{pdEffReload:0.00}{Localization.TT("s")}";
			else pointDefReloadTime.effects.text = $"<color=red>{pdEffReload / FFU_BE_Defs.GetHealthPercent(m):0.00}{Localization.TT("s")}</color>";
			pointDefReloadTime.skillBonus.text = $"-{gunnerySkillEffects.skillPointBonusPercent}% {argPer}";
			pointDefReloadTime.Hoverable.hoverText = string.Format(pointDefReloadTime.HoverableTextTemplate, gunnerySkillEffects.skillPointBonusPercent);
			pointDefCoverRadius.SetActiveIfNeeded();
			float pdEffRadius = pointDefence.EffectiveCoverRadius;
			if (m.HasFullHealth) pointDefCoverRadius.effects.text = pointDefence.coverRadius != pdEffRadius ? $"<color=lime>{pdEffRadius * 10f:0.0}{Localization.TT("m")}</color>" : $"{pdEffRadius * 10f:0.0}{Localization.TT("m")}";
			else pointDefCoverRadius.effects.text = $"<color=red>{pdEffRadius * 10f * FFU_BE_Defs.GetHealthPercent(m):0.0}{Localization.TT("m")}</color>";
			pointDefCoverRadius.skillBonus.text = $"+{gunnerySkillEffects.skillPointBonusPercent}% {argPer}";
			pointDefCoverRadius.Hoverable.hoverText = string.Format(pointDefCoverRadius.HoverableTextTemplate, gunnerySkillEffects.skillPointBonusPercent);
			SafeUpdateField(pointDefDmgToProjectilesText, projectileOrBeamPrefab.projectileDmg.ToString());
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
		}
		//Updated Engine Information
		[MonoModReplace] private void DoEngine() {
			EngineModule engine = m.Engine;
			if (m.HasFullHealth) DoResourceConsPerDist(engine.ConsumedPerDistance, m);
			else {
				DoResourceConsPerDist(engine.ConsumedPerDistance * (1f / FFU_BE_Defs.GetHealthPercent(m)), m);
				DoRequirementColor(organicsPerDistText, null, false);
				DoRequirementColor(fuelPerDistText, null, false);
				DoRequirementColor(metalsPerDistText, null, false);
				DoRequirementColor(syntheticsPerDistText, null, false);
				DoRequirementColor(explosivesPerDistText, null, false);
				DoRequirementColor(exoticsPerDistText, null, false);
				DoRequirementColor(creditsPerDistText, null, false);
			}
		}
		//Updated Sensor Information
		[MonoModReplace] private void DoSensor() {
			SensorModule sensor = m.Sensor;
			string argRu = Localization.TT("ru");
			string argPer = Localization.TT("per");
			if (m.HasFullHealth) SafeUpdateField(sensorSectorRadarRange, sensor.sectorRadarRange + argRu);
			else SafeUpdateField(sensorSectorRadarRange, $"<color=red>{sensor.sectorRadarRange * FFU_BE_Defs.GetHealthPercent(m):0}{argRu}</color>");
			if (sensor.starmapRadarRange != 0) {
				sensorStarmapRadarRange.SetActiveIfNeeded();
				SensorSkillEffects sensorSkillEffects = WorldRules.Instance.sensorSkillEffects;
				float starRadRng = sensor.starmapRadarRange * sensorSkillEffects.EffectiveSkillMultiplier(m, false);
				if (m.HasFullHealth) sensorStarmapRadarRange.effects.text = sensor.starmapRadarRange != starRadRng ? $" <color=lime>{starRadRng:0}{argRu}</color>" : $" {starRadRng:0}{argRu}";
				else sensorStarmapRadarRange.effects.text = $" <color=red>{starRadRng * FFU_BE_Defs.GetHealthPercent(m):0}{argRu}</color>";
				sensorStarmapRadarRange.skillBonus.text = $"+{sensorSkillEffects.skillPointBonusPercent}% {argPer}";
				sensorStarmapRadarRange.Hoverable.hoverText = string.Format(sensorStarmapRadarRange.HoverableTextTemplate, sensorSkillEffects.skillPointBonusPercent);
			}
		}
		//Updated Bridge Information
		[MonoModReplace] private void DoBridge() {
			bridgeRemoteOpsGo.SetActive(true);
			BridgeSkillEffects bridgeSkillEffects = WorldRules.Instance.bridgeSkillEffects;
			bridgeEvasion.SetActiveIfNeeded();
			int bridgeEva = bridgeSkillEffects.EffectiveSkillBonusPercent(m);
			if (m.HasFullHealth) bridgeEvasion.effects.text = (m.shipEvasionPercentAdd != bridgeEva) ? $"<color=lime>({m.shipEvasionPercentAdd + bridgeEva:0})</color>" : $"({m.shipEvasionPercentAdd + bridgeEva:0})";
			else bridgeEvasion.effects.text = $"<color=red>({m.shipEvasionPercentAdd + bridgeEva * FFU_BE_Defs.GetHealthPercent(m):0})</color>";
			bridgeEvasion.skillBonus.text = string.Format("+{0} {1}", bridgeSkillEffects.skillPointBonusPercent, Localization.TT("per"));
			bridgeEvasion.Hoverable.hoverText = string.Format(bridgeEvasion.HoverableTextTemplate, bridgeSkillEffects.skillPointBonusPercent);
			SafeUpdateField(crewText, m.CurrentLocalOpsCount + "/" + m.operatorSpots.Length);
		}
		//Updated Shields Information
		[MonoModReplace] private void DoShieldGen() {
			ShieldModule shieldGen = m.ShieldGen;
			int maxShieldAdd = shieldGen.maxShieldAdd;
			SafeUpdateField(sMaxShieldBonusText, maxShieldAdd, ref prevShieldAdd);
			ShieldSkillEffects shieldSkillEffects = WorldRules.Instance.shieldSkillEffects;
			if (shieldGen.reloadInterval != 0f) {
				shieldReloadTime.SetActiveIfNeeded();
				float num = shieldGen.reloadInterval * shieldSkillEffects.EffectiveSkillMultiplier(m, true);
				shieldReloadTime.effects.text = shieldGen.reloadInterval + Localization.TT("s") + ((shieldGen.reloadInterval != num) ? string.Format(" <color=lime>({0:0.0}{1})</color>", num, Localization.TT("s")) : "");
				shieldReloadTime.skillBonus.text = string.Format("-{0}% {1}", shieldSkillEffects.skillPointBonusPercent, Localization.TT("per"));
				shieldReloadTime.Hoverable.hoverText = string.Format(shieldReloadTime.HoverableTextTemplate, shieldSkillEffects.skillPointBonusPercent);
			}
		}
		//Updated Warp Drive Information
		[MonoModReplace] private void DoWarp() {
			WarpModule warp = m.Warp;
			SafeUpdateField(warpActivationFuelText, warp.activationFuel, ref prevActivationFuel);
			Ship ship = m.Ship;
			DoRequirementColor(warpActivationFuelText, warpActivationFuel, ship == null || ship.Fuel >= warp.activationFuel);
			WarpSkillEffects warpSkillEffects = WorldRules.Instance.warpSkillEffects;
			warpReloadTime.SetActiveIfNeeded();
			float num = warp.reloadInterval * warpSkillEffects.EffectiveSkillMultiplier(m, true);
			warpReloadTime.effects.text = warp.reloadInterval + Localization.TT("s") + ((warp.reloadInterval != num) ? string.Format(" <color=lime>({0:0.0}{1})</color>", num, Localization.TT("s")) : "");
			warpReloadTime.skillBonus.text = string.Format("-{0}% {1}", warpSkillEffects.skillPointBonusPercent, Localization.TT("per"));
			warpReloadTime.Hoverable.hoverText = string.Format(warpReloadTime.HoverableTextTemplate, warpSkillEffects.skillPointBonusPercent);
		}
		//Updated Reactor Information
		[MonoModReplace] private void DoReactor() {
			ReactorModule reactor = m.Reactor;
			fireChanceHover.hoverText = "Overcharge power bonus and effective time";
			fireChanceText.alignment = TextAnchor.UpperLeft;
			if (m.HasFullHealth) SafeUpdateField(reactorPowerProdText, reactor.powerCapacity, ref prevPowerCapacity, "{0:0} GW/h");
			else SafeUpdateField(reactorPowerProdText, string.Format("<color=red>{0:0}</color> GW/h", reactor.powerCapacity * FFU_BE_Defs.GetHealthPercent(m)));
			if (m.HasFullHealth) SafeUpdateField(fireChanceText, string.Format("+{0:0} GW/h\n{1:0.0}s", reactor.overchargePowerCapacityAdd, m.overchargeSeconds));
			else SafeUpdateField(fireChanceText, string.Format("<color=red>+{0:0}</color> GW/h\n{1:0.0}s", reactor.overchargePowerCapacityAdd * FFU_BE_Defs.GetHealthPercent(m), m.overchargeSeconds));
			DoResourceConsPerDist(reactor.ConsumedPerDistance, m);
		}
		//Updated Drone/Medbay Information
		[MonoModReplace] private void DoMedbay() {
			MedbayModule medbay = m.Medbay;
			int num = m.operatorSpots.Length;
			float secondsPerHp = medbay.secondsPerHp;
			int num2 = (int)medbay.resourcesPerHp.organics;
			int num3 = (int)medbay.resourcesPerHp.synthetics;
			SafeUpdateField(medbayHealSpotsText, num, ref prevHealingSpots);
			SafeUpdateField(medbayHealSpeedText, secondsPerHp, ref prevHealingInvSpeed, "{0:0.0}");
			PlayerData playerData = PlayerDatas.Get(m.Ownership.GetOwner());
			Ship ship = m.Ship;
			SafeUpdateField(medbayOrganicsPerHpText, num2, ref prevOrganicsPerHp);
			DoRequirementColor(medbayOrganicsPerHpText, medbayOrganicsPerHp, ship == null || playerData == null || playerData.Organics.Total >= num2);
			SafeUpdateField(medbaySyntheticsPerHpText, num3, ref prevSyntheticsPerHp);
			DoRequirementColor(medbaySyntheticsPerHpText, medbaySyntheticsPerHp, ship == null || playerData == null || playerData.Synthetics.Total >= num3);
		}
		//Updated Converter Information
		[MonoModReplace] private void DoMaterialsConverter() {
			MaterialsConverterModule materialsConverter = m.MaterialsConverter;
			DoResourceConsPerSecond(materialsConverter.consume, materialsConverter.secondsPerConversion);
			DoResourceProdPerSecond(materialsConverter.produce, materialsConverter.secondsPerConversion);
		}
		//Updated Greenhouse Information
		[MonoModReplace] private void DoGarden() {
			SafeUpdateField(crewText, m.CurrentLocalOpsCount + "/" + m.operatorSpots.Length);
			GardenSkillEffects gardenSkillEffects = WorldRules.Instance.gardenSkillEffects;
			int gardenProduction = gardenSkillEffects.EffectiveOrganicsProduction(m);
			bool gardenProduces = gardenProduction > 0;
			SafeUpdateField(gardenOrganicsProdCurText, gardenProduces ? string.Format("<color=lime>{0}/100{1}</color>", gardenProduction, Localization.TT("ru")) : null);
			int totalGardenProduction = gardenSkillEffects.skillPointBonusProduction * (int)m.GardenModule.producedPerSkillPoint.organics;
			SafeUpdateField(gardenOrganicsProdBonusText, totalGardenProduction + "/100" + Localization.TT("ru") + " " + Localization.TT("per"));
			removesOpResCons.SetActive(true);
		}
		//Updated Laboratory Information
		[MonoModReplace] private void DoResearch() {
			SafeUpdateField(crewText, m.CurrentLocalOpsCount + "/" + m.operatorSpots.Length);
			ScienceSkillEffects scienceSkillEffects = WorldRules.Instance.scienceSkillEffects;
			int labProduciton = scienceSkillEffects.EffectiveCreditsProduction(m);
			bool labProduces = labProduciton > 0;
			SafeUpdateField(researchCreditsProdCurText, labProduces ? string.Format("<color=lime>{0}/100{1}</color>", labProduciton, Localization.TT("ru")) : null);
			int totalLabProduction = scienceSkillEffects.skillPointBonusProduction * (int)m.Research.producedPerSkillPoint.credits;
			SafeUpdateField(researchCreditsProdBonusText, totalLabProduction + "/100" + Localization.TT("ru") + " " + Localization.TT("per"));
		}
		//Updated Cryosleep Information
		[MonoModReplace] private void DoCryosleep() {
			int num = m.operatorSpots.Length;
			removesOpResCons.SetActive(true);
			SafeUpdateField(cryoSleepSpotsText, num, ref prevOpSpots);
			cryoSleepChanceToHeal.SetActive(m.Cryosleep.healOneCrewHp);
			cryoGenDreamCredits.SetActive(m.Cryosleep.genDreamCredits);
		}
		//Show Updated Crew Damage in Weapon Panel
		[MonoModReplace] private void DoWeaponCrewDmg(WeaponModule w, ShootAtDamageDealer.CrewDmgLevel crewDmgLevel) {
			dmgToCrewTextHover.hoverText = "Chance to damage all crewmembers within area of effect by shown amount.";
			string crewDmgText = w.magazineSize + "x" + w.ProjectileOrBeamPrefab.GetDamage(w).doorDmg;
			dmgToCrewText.alignment = TextAnchor.MiddleLeft;
			switch (crewDmgLevel) {
				case ShootAtDamageDealer.CrewDmgLevel.None: SafeUpdateField(dmgToCrewText, Localization.TT("None (" + (int)Core.CrewHitChance.None + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Low: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Low + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.Default: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.Medium + "%)")); break;
				case ShootAtDamageDealer.CrewDmgLevel.High: SafeUpdateField(dmgToCrewText, Localization.TT(crewDmgText + " (" + (int)Core.CrewHitChance.High + "%)")); break;
			}
		}
		//Show Update Fire Ignition Chance in Weapon Panel
		[MonoModReplace] private void DoWeaponFireChance(ShootAtDamageDealer.FireChanceLevel fireChanceLevel) {
			fireChanceHover.hoverText = "Chance to ignite fire in every tile within area of effect.";
			fireChanceText.alignment = TextAnchor.MiddleLeft;
			switch (fireChanceLevel) {
				case ShootAtDamageDealer.FireChanceLevel.None: SafeUpdateField(fireChanceText, Localization.TT("None (" + (int)Core.FireIgniteChance.None + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Low: SafeUpdateField(fireChanceText, Localization.TT("Low (" + (int)Core.FireIgniteChance.Low + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.Default: SafeUpdateField(fireChanceText, Localization.TT("Medium (" + (int)Core.FireIgniteChance.Medium + "%)")); break;
				case ShootAtDamageDealer.FireChanceLevel.High: SafeUpdateField(fireChanceText, Localization.TT("High (" + (int)Core.FireIgniteChance.High + "%)")); break;
			}
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
