﻿#pragma warning disable IDE1006
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
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg > 0 ? "Crew Damage: " + (handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "") + handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg + "\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg > 0 ? "Door Damage: " + (handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "") + handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg + "\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg > 0 ? "Hull Damage: " + (handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "") + handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg + "\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg > 0 ? "Module Damage: " + (handWeapon.magazineSize > 1 ? handWeapon.magazineSize + "x" : "") + handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg + "\n" : "";
			weaponData += handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance > 0 ? "Module Hit Chance: " + string.Format("{0:0}", handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance * 100f) + "%" + "\n" : "";
			weaponData += handWeapon.farthestAttackDistance > 0 ? "Effective Range: " + handWeapon.farthestAttackDistance + "m" + "\n" : "";
			weaponData += handWeapon.reloadInterval > 0 ? "Reload Time: " + handWeapon.reloadInterval + "s" + "\n" : "";
			weaponData += handWeapon.shotInterval > 0 ? "Salvo Delay: " + handWeapon.shotInterval + "s" + "\n" : "";
			weaponData += handWeapon.accuracy > 0 ? "Accuracy: " + handWeapon.accuracy + " Δm" + "\n" : "";
			if (!string.IsNullOrEmpty(weaponData)) weaponData = "<color=lime>" + weaponData + "</color>" + handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			else weaponData = handWeapon.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			return weaponData;
		}
		public static string GetSelectedModuleExactData(ShipModule shipModule) {
			string moduleData = "";
			if (shipModule.name.Contains("bossweapon")) return "<color=lime>" + "Type: Unidentified" + "</color>" + "\n" + shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			if (shipModule.name.Contains("tutorial")) return "<color=lime>" + "Type: Unidentified" + "</color>" + "\n" + shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. " +
					(shipModule.displayName.Contains("Rocket") ? "Rocket Launcher" :
					(shipModule.displayName.Contains("Autocannon") ? "Autocannon" :
					(shipModule.displayName.Contains("Howitzer") ? "Howitzer" :
					(shipModule.displayName.Contains("Railgun") ? "Railgun" :
					(shipModule.displayName.Contains("Railcannon") ? "Railcannon" :
					(shipModule.displayName.Contains("Laser") ? "Laser Emitter" :
					(shipModule.displayName.Contains("Beam") ? "Beam Emitter" :
					(shipModule.displayName.Contains("Heat Ray") ? "Heat Ray Projector" :
					(shipModule.displayName.Contains("Disruptor") ? "Energy Disruptor" :
					(shipModule.displayName.Contains("Exotic Ray") ? "Exotic Ray Projector" :
					"Starship Weapon")))))))))) + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Weapon.reloadInterval > 0 ? "Reload Time: " + shipModule.Weapon.reloadInterval + "s" + "\n" : "";
				moduleData += shipModule.Weapon.preShootDelay > 0 ? "Ignition Time: " + shipModule.Weapon.preShootDelay + "s" + "\n" : "";
				moduleData += shipModule.Weapon.shotInterval > 0 ? "Salvo Delay: " + shipModule.Weapon.shotInterval + "s" + "\n" : "";
				moduleData += shipModule.Weapon.accuracy > 0 ? "Accuracy: " + shipModule.Weapon.accuracy + " Δm" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? "Damage Radius: " + string.Format("{0:0.###}m", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? "Ignores Shields: Yes" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? "Never Deflects: Yes" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? "Shield Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? "Module Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? "Hull Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? "Crew Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? "Crew Hit Chance: " + GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? "Fire Ignite Chance: " + GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? "EMP Effect: " + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds + "s" + "\n" : "";
				moduleData += (shipModule.Weapon.resourcesPerShot.organics > 0 ||
					shipModule.Weapon.resourcesPerShot.fuel > 0 ||
					shipModule.Weapon.resourcesPerShot.metals > 0 ||
					shipModule.Weapon.resourcesPerShot.synthetics > 0 ||
					shipModule.Weapon.resourcesPerShot.explosives > 0 ||
					shipModule.Weapon.resourcesPerShot.exotics > 0) ? "Resources Per Shot:" + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.organics > 0 ? " > Organics: " + shipModule.Weapon.resourcesPerShot.organics + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.fuel > 0 ? " > Starfuel: " + shipModule.Weapon.resourcesPerShot.fuel + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.metals > 0 ? " > Metals: " + shipModule.Weapon.resourcesPerShot.metals + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.synthetics > 0 ? " > Synthetics: " + shipModule.Weapon.resourcesPerShot.synthetics + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.explosives > 0 ? " > Explosives: " + shipModule.Weapon.resourcesPerShot.explosives + "\n" : "";
				moduleData += shipModule.Weapon.resourcesPerShot.exotics > 0 ? " > Exotic: " + shipModule.Weapon.resourcesPerShot.exotics + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Damage Dealer: Projectile" + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Projectile Health: " + (shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth")) + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Projectile Velocity: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed + "00" + "m/s" + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Point Defense Detection: " + (shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis")) + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Point Defense Priority: " + AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority") + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? "Damage Dealer: Beam" + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? " > Beam Duration: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Beam).duration + "s" + "\n" : "";
				break;
				case ShipModule.Type.Weapon_Nuke:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Capital Missile" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? "Damage Radius: " + string.Format("{0:0.###}m", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? "Ignores Shields: Yes" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? "Never Deflects: Yes" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? "Shield Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? "Module Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? "Hull Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? "Crew Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? "Crew Hit Chance: " + GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? "Fire Ignite Chance: " + GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel) + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? "EMP Effect: " + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds + "s" + "\n" : "";
				moduleData += shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? "Boarding Payload: " + (int)Math.Round(FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 2f) + " ~ " + (int)Math.Round(FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 5f) + " Units" + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Capital Missile Health: " + (shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth")) + "\n" : "";
				try { moduleData += "Missile Acceleration: " + (((HomingMovement)AccessTools.PropertyGetter(typeof(Projectile), "HomingMovement").Invoke(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, null)).force * 10f) + " m/s²" + "\n"; } catch { }
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Point Defense Detection: " + (shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis")) + "\n" : "";
				moduleData += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Point Defense Priority: " + AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority") + "\n" : "";
				break;
				case ShipModule.Type.PointDefence:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Close-In Weapon System" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.PointDefence.reloadInterval > 0 ? "Reload Time: " + shipModule.PointDefence.reloadInterval + "s" + "\n" : "";
				moduleData += shipModule.PointDefence.coverRadius > 0 ? "Cover Radius: " + shipModule.PointDefence.coverRadius * 10f + "m" + "\n" : "";
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg > 0 ? "Interception Damage: " + shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg + "\n" : "";
				moduleData += shipModule.PointDefence.projectileOrBeamPrefab.lifetime > 0 ? "Interception Delay: " + shipModule.PointDefence.projectileOrBeamPrefab.lifetime + "s" + "\n" : "";
				moduleData += (shipModule.PointDefence.resourcesPerShot.organics > 0 ||
					shipModule.PointDefence.resourcesPerShot.fuel > 0 ||
					shipModule.PointDefence.resourcesPerShot.metals > 0 ||
					shipModule.PointDefence.resourcesPerShot.synthetics > 0 ||
					shipModule.PointDefence.resourcesPerShot.explosives > 0 ||
					shipModule.PointDefence.resourcesPerShot.exotics > 0) ? "Resources Per Shot:" + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.organics > 0 ? " > Organics: " + shipModule.PointDefence.resourcesPerShot.organics + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.fuel > 0 ? " > Starfuel: " + shipModule.PointDefence.resourcesPerShot.fuel + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.metals > 0 ? " > Metals: " + shipModule.PointDefence.resourcesPerShot.metals + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.synthetics > 0 ? " > Synthetics: " + shipModule.PointDefence.resourcesPerShot.synthetics + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.explosives > 0 ? " > Explosives: " + shipModule.PointDefence.resourcesPerShot.explosives + "\n" : "";
				moduleData += shipModule.PointDefence.resourcesPerShot.exotics > 0 ? " > Exotic: " + shipModule.PointDefence.resourcesPerShot.exotics + "\n" : "";
				break;
				case ShipModule.Type.Bridge:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Command Bridge" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Bridge Operators: " + shipModule.OperatorSpots.Length + "\n" : "";
				break;
				case ShipModule.Type.Engine:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Sub-Light Engine" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.Engine.ConsumedPerDistance.organics > 0 ||
					shipModule.Engine.ConsumedPerDistance.fuel > 0 ||
					shipModule.Engine.ConsumedPerDistance.metals > 0 ||
					shipModule.Engine.ConsumedPerDistance.synthetics > 0 ||
					shipModule.Engine.ConsumedPerDistance.explosives > 0 ||
					shipModule.Engine.ConsumedPerDistance.exotics > 0) ? "Resources Consumption:" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.organics > 0 ? " > Organics: " + shipModule.Engine.ConsumedPerDistance.organics * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.fuel > 0 ? " > Starfuel: " + shipModule.Engine.ConsumedPerDistance.fuel * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.metals > 0 ? " > Metals: " + shipModule.Engine.ConsumedPerDistance.metals * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.synthetics > 0 ? " > Synthetics: " + shipModule.Engine.ConsumedPerDistance.synthetics * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.explosives > 0 ? " > Explosives: " + shipModule.Engine.ConsumedPerDistance.explosives * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Engine.ConsumedPerDistance.exotics > 0 ? " > Exotics: " + shipModule.Engine.ConsumedPerDistance.exotics * 100 + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Warp:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Warp Drive" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Warp.reloadInterval > 0 ? "Jump Drive Recharge: " + shipModule.Warp.reloadInterval + "s" + "\n" : "";
				moduleData += shipModule.Warp.activationFuel > 0 ? "Jump Fuel Consumption: " + shipModule.Warp.activationFuel + "\n" : "";
				break;
				case ShipModule.Type.Reactor:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Energy Reactor" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Reactor.powerCapacity > 0 ? "Power Production: " + shipModule.Reactor.powerCapacity + " GW/h" + "\n" : "";
				moduleData += shipModule.Reactor.overchargePowerCapacityAdd > 0 ? "Overcharge Production: " + string.Format("{0:0}", (shipModule.Reactor.overchargePowerCapacityAdd / (float)shipModule.Reactor.powerCapacity + 1f) * 100f) + "%" + "\n" : "";
				moduleData += shipModule.overchargeSeconds > 0 ? "Overcharge Time: " + shipModule.overchargeSeconds + "s" + "\n" : "";
				moduleData += (shipModule.Reactor.ConsumedPerDistance.organics > 0 ||
					shipModule.Reactor.ConsumedPerDistance.fuel > 0 ||
					shipModule.Reactor.ConsumedPerDistance.metals > 0 ||
					shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ||
					shipModule.Reactor.ConsumedPerDistance.explosives > 0 ||
					shipModule.Reactor.ConsumedPerDistance.exotics > 0) ? "Resources Consumption:" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.organics > 0 ? " > Organics: " + shipModule.Reactor.ConsumedPerDistance.organics * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.fuel > 0 ? " > Starfuel: " + shipModule.Reactor.ConsumedPerDistance.fuel * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.metals > 0 ? " > Metals: " + shipModule.Reactor.ConsumedPerDistance.metals * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ? " > Synthetics: " + shipModule.Reactor.ConsumedPerDistance.synthetics * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.explosives > 0 ? " > Explosives: " + shipModule.Reactor.ConsumedPerDistance.explosives * 100 + "/100ru" + "\n" : "";
				moduleData += shipModule.Reactor.ConsumedPerDistance.exotics > 0 ? " > Exotics: " + shipModule.Reactor.ConsumedPerDistance.exotics * 100 + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Container:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Storage Container" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Container.MaxOrganics > 0 ? "Organics Storage: " + shipModule.Container.MaxOrganics + "\n" : "";
				moduleData += shipModule.Container.MaxFuel > 0 ? "Starfuel Storage: " + shipModule.Container.MaxFuel + "\n" : "";
				moduleData += shipModule.Container.MaxMetals > 0 ? "Metals Storage: " + shipModule.Container.MaxMetals + "\n" : "";
				moduleData += shipModule.Container.MaxSynthetics > 0 ? "Synthetics Storage: " + shipModule.Container.MaxSynthetics + "\n" : "";
				moduleData += shipModule.Container.MaxExplosives > 0 ? "Explosives Storage: " + shipModule.Container.MaxExplosives + "\n" : "";
				moduleData += shipModule.Container.MaxExotics > 0 ? "Exotics Storage: " + shipModule.Container.MaxExotics + "\n" : "";
				break;
				case ShipModule.Type.Integrity:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Integrity Armor" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				break;
				case ShipModule.Type.ShieldGen:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. " + (shipModule.ShieldGen.reloadInterval > 0 ? "Shield Generator" : "Shield Capacitor") + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.ShieldGen.reloadInterval > 0 ? "Shield Regeneration: " + shipModule.ShieldGen.reloadInterval + "s" + "\n" : "";
				moduleData += shipModule.ShieldGen.maxShieldAdd > 0 ? "Shield Capacity: " + shipModule.ShieldGen.maxShieldAdd + "\n" : "";
				break;
				case ShipModule.Type.Sensor:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Sensor Array" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Sensor.sectorRadarRange > 0 ? "Sector Radar Range: " + shipModule.Sensor.sectorRadarRange + "\n" : "";
				moduleData += shipModule.Sensor.starmapRadarRange > 0 ? "Starmap Radar Range: " + shipModule.Sensor.starmapRadarRange + "\n" : "";
				break;
				case ShipModule.Type.StealthDecryptor:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Stealth Generator" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				break;
				case ShipModule.Type.PassiveECM:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Countermeasure Array" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. " + (shipModule.Medbay.resourcesPerHp.organics > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Restoration Bay" : 
					(shipModule.Medbay.resourcesPerHp.organics > 0 ? "Crew Medical Bay" : (shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Drone Repair Bay" : "Unidentified Health Bay"))) + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Medbay Crew Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Medbay Healing Speed: " + shipModule.Medbay.secondsPerHp + "s" + "\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Organics Consumption: " + shipModule.Medbay.resourcesPerHp.organics + "/HP" + "\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Dronebay Bots Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Dronebay Repair Speed: " + shipModule.Medbay.secondsPerHp + "s" + "\n" : "";
				moduleData += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Synthetics Consumption: " + shipModule.Medbay.resourcesPerHp.synthetics + "/HP" + "\n" : "";
				break;
				case ShipModule.Type.Cryosleep:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. " + (shipModule.Cryosleep.genDreamCredits ? "Cryodream Bay" : "Cryosleep Bay") + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Cryosleep Crew Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Crew Food Consumption: " + "Disabled" + "\n" : "";
				moduleData += shipModule.Cryosleep.healOneCrewHp ? "Health Recovery Distance: " + shipModule.Cryosleep.healOneCrewHpDistance.minValue + "ru ~ " + shipModule.Cryosleep.healOneCrewHpDistance.maxValue + "ru" + "\n" : "";
				moduleData += shipModule.Cryosleep.genDreamCredits ? "Cryodream Record Distance: " + shipModule.Cryosleep.genDreamCreditsDistance.minValue + "ru ~ " + shipModule.Cryosleep.genDreamCreditsDistance.maxValue + "ru" + "\n" : "";
				moduleData += shipModule.Cryosleep.genDreamCredits ? "Credits Per Cryodream: " + shipModule.Cryosleep.creditsPerDream.minValue + " ~ " + shipModule.Cryosleep.creditsPerDream.maxValue + "\n" : "";
				break;
				case ShipModule.Type.ResearchLab:
				float effectiveScienceInput = WorldRules.Instance.scienceSkillEffects.EffectiveCreditsProduction(shipModule) / shipModule.Research.producedPerSkillPoint.credits;
				float researchSpeed = (shipModule.Research.producedPerSkillPoint.credits / 1000f + shipModule.Research.producedPerSkillPoint.exotics / 20f) * effectiveScienceInput * FFU_BE_Defs.tierResearchSpeedMult;
				float reversingSpeed = (shipModule.Research.producedPerSkillPoint.credits / 333.33f + shipModule.Research.producedPerSkillPoint.exotics / 6.66f) * effectiveScienceInput * FFU_BE_Defs.moduleResearchSpeedMult;
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Research Laboratory" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Researchers Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				moduleData += (researchSpeed > 0 || reversingSpeed > 0) ? "Laboratory Effects:" + "\n" : "";
				moduleData += (researchSpeed > 0) ? " > Research Progress: " + string.Format("{0:0.0}", researchSpeed * 100f) + "/100ru" + "\n" : "";
				moduleData += (reversingSpeed > 0) ? " > Reverse Engineering: " + string.Format("{0:0.0}", reversingSpeed * 100f) + "/100ru" + "\n" : "";
				moduleData += (shipModule.Research.producedPerSkillPoint.credits > 0 ||
					shipModule.Research.producedPerSkillPoint.organics > 0 ||
					shipModule.Research.producedPerSkillPoint.fuel > 0 ||
					shipModule.Research.producedPerSkillPoint.metals > 0 ||
					shipModule.Research.producedPerSkillPoint.synthetics > 0 ||
					shipModule.Research.producedPerSkillPoint.explosives > 0 ||
					shipModule.Research.producedPerSkillPoint.exotics > 0) ? "Effective Production:" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.credits > 0 ? " > Credits: " + shipModule.Research.producedPerSkillPoint.credits * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.organics > 0 ? " > Organics: " + shipModule.Research.producedPerSkillPoint.organics * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.fuel > 0 ? " > Starfuel: " + shipModule.Research.producedPerSkillPoint.fuel * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.metals > 0 ? " > Metals: " + shipModule.Research.producedPerSkillPoint.metals * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.synthetics > 0 ? " > Synthetics: " + shipModule.Research.producedPerSkillPoint.synthetics * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.explosives > 0 ? " > Explosives: " + shipModule.Research.producedPerSkillPoint.explosives * effectiveScienceInput + "/100ru" + "\n" : "";
				moduleData += shipModule.Research.producedPerSkillPoint.exotics > 0 ? " > Exotics: " + shipModule.Research.producedPerSkillPoint.exotics * effectiveScienceInput + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Garden:
				float effectiveAgriInput = WorldRules.Instance.gardenSkillEffects.EffectiveOrganicsProduction(shipModule) / shipModule.GardenModule.producedPerSkillPoint.organics;
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Greenhouse Facility" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Agricultural Operators: " + shipModule.OperatorSpots.Length + "\n" : "";
				moduleData += (shipModule.OperatorSpots.Length > 0) ? "Operators Food Consumption: " + "Disabled" + "\n" : "";
				moduleData += (shipModule.GardenModule.producedPerSkillPoint.credits > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.organics > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.fuel > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.metals > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.synthetics > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.explosives > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.exotics > 0) ? "Effective Production:" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.credits > 0 ? " > Credits: " + shipModule.GardenModule.producedPerSkillPoint.credits * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.organics > 0 ? " > Organics: " + shipModule.GardenModule.producedPerSkillPoint.organics * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.fuel > 0 ? " > Starfuel: " + shipModule.GardenModule.producedPerSkillPoint.fuel * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.metals > 0 ? " > Metals: " + shipModule.GardenModule.producedPerSkillPoint.metals * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.synthetics > 0 ? " > Synthetics: " + shipModule.GardenModule.producedPerSkillPoint.synthetics * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.explosives > 0 ? " > Explosives: " + shipModule.GardenModule.producedPerSkillPoint.explosives * effectiveAgriInput + "/100ru" + "\n" : "";
				moduleData += shipModule.GardenModule.producedPerSkillPoint.exotics > 0 ? " > Exotics: " + shipModule.GardenModule.producedPerSkillPoint.exotics * effectiveAgriInput + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.MaterialsConverter:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Industrial Facility" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				moduleData += (shipModule.MaterialsConverter.produce.organics > 0 ||
					shipModule.MaterialsConverter.produce.fuel > 0 ||
					shipModule.MaterialsConverter.produce.metals > 0 ||
					shipModule.MaterialsConverter.produce.synthetics > 0 ||
					shipModule.MaterialsConverter.produce.explosives > 0 ||
					shipModule.MaterialsConverter.produce.exotics > 0) ? "Industrial Production:" + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.organics > 0 ? " > Organics: " + (shipModule.MaterialsConverter.produce.organics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.fuel > 0 ? " > Starfuel: " + (shipModule.MaterialsConverter.produce.fuel * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.metals > 0 ? " > Metals: " + (shipModule.MaterialsConverter.produce.metals * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.synthetics > 0 ? " > Synthetics: " + (shipModule.MaterialsConverter.produce.synthetics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.explosives > 0 ? " > Explosives: " + (shipModule.MaterialsConverter.produce.explosives * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.exotics > 0 ? " > Exotics: " + (shipModule.MaterialsConverter.produce.exotics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.produce.credits > 0 ? " > Xenodata: " + (shipModule.MaterialsConverter.produce.credits * 60) + "/min." + "\n" : "";
				moduleData += (shipModule.MaterialsConverter.consume.organics > 0 ||
					shipModule.MaterialsConverter.consume.fuel > 0 ||
					shipModule.MaterialsConverter.consume.metals > 0 ||
					shipModule.MaterialsConverter.consume.synthetics > 0 ||
					shipModule.MaterialsConverter.consume.explosives > 0 ||
					shipModule.MaterialsConverter.consume.exotics > 0) ? "Industrial Consumption:" + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.organics > 0 ? " > Organics: " + (shipModule.MaterialsConverter.consume.organics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.fuel > 0 ? " > Starfuel: " + (shipModule.MaterialsConverter.consume.fuel * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.metals > 0 ? " > Metals: " + (shipModule.MaterialsConverter.consume.metals * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.synthetics > 0 ? " > Synthetics: " + (shipModule.MaterialsConverter.consume.synthetics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.explosives > 0 ? " > Explosives: " + (shipModule.MaterialsConverter.consume.explosives * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.exotics > 0 ? " > Exotics: " + (shipModule.MaterialsConverter.consume.exotics * 60) + "/min." + "\n" : "";
				moduleData += shipModule.MaterialsConverter.consume.credits > 0 ? " > Xenodata: " + (shipModule.MaterialsConverter.consume.credits * 60) + "/min." + "\n" : "";
				break;
				case ShipModule.Type.Fighter:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Fighter Bay" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				break;
				case ShipModule.Type.Decoy:
				moduleData += "Type: " + FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Decoy Module" + "\n";
				moduleData += "Modifier: " + FFU_BE_Mod_Technology.GetModuleModText(shipModule) + "\n";
				break;
				case ShipModule.Type.ResourcePack:
				moduleData += "Type: Resource Package" + "\n";
				break;
				case ShipModule.Type.Storage:
				moduleData += "Type: Modular Storage" + "\n";
				break;
				default:
				moduleData += "Type: " + (shipModule.displayName.Contains("Cache") ?
					(shipModule.displayName.Contains("Weapons") ? FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Weapons" :
					shipModule.displayName.Contains("Implants") ? FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Implants" :
					shipModule.displayName.Contains("Upgrades") ? FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Upgrades" :
					FFU_BE_Mod_Technology.GetModuleGenText(shipModule) + " Gen. Unidentified") + " Cache" :
					shipModule.name.Contains("artifact") ? "Artifact" : "Unidentified") + "\n";
				if (shipModule.displayName.Contains("Cache") && shipModule.displayName.Contains("Weapons")) {
					moduleData += "Available Weapon Sets: " + (3 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f)) + "\n";
					moduleData += "Available Weapons: " + "\n";
					if (shipModule.displayName.Contains("CQC Class")) {
						moduleData += " > Power Fists" + "\n";
						moduleData += " > Dual Welder" + "\n";
						moduleData += " > Napalm Gun" + "\n";
						moduleData += " > Toxic Gun" + "\n";
					} else if (shipModule.displayName.Contains("Kinetic Type")) {
						moduleData += " > Assault Pistol" + "\n";
						moduleData += " > Light Revolver" + "\n";
						moduleData += " > Heavy Revolver" + "\n";
						moduleData += " > Assault Revolver" + "\n";
						moduleData += " > Assault SMG" + "\n";
						moduleData += " > Assault Shotgun" + "\n";
						moduleData += " > Assault Rifle" + "\n";
						moduleData += " > Assault Autocannon" + "\n";
						moduleData += " > Breacher Cannon" + "\n";
						moduleData += " > Assault Railgun" + "\n";
					} else if (shipModule.displayName.Contains("Laser Type")) {
						moduleData += " > Laser Pistol" + "\n";
						moduleData += " > Laser Rifle" + "\n";
						moduleData += " > Laser Cannon" + "\n";
					} else if (shipModule.displayName.Contains("Energy Type")) {
						moduleData += " > Blaster Pistol" + "\n";
						moduleData += " > Blaster Rifle" + "\n";
						moduleData += " > Warp Ray Gun" + "\n";
						moduleData += " > Particle Gun" + "\n";
					} else if (shipModule.displayName.Contains("Backup Class")) {
						moduleData += " > Assault Pistol" + "\n";
						moduleData += " > Light Revolver" + "\n";
						moduleData += " > Heavy Revolver" + "\n";
						moduleData += " > Assault Revolver" + "\n";
						moduleData += " > Laser Pistol" + "\n";
					} else if (shipModule.displayName.Contains("Tactical Class")) {
						moduleData += " > Assault SMG" + "\n";
						moduleData += " > Assault Shotgun" + "\n";
						moduleData += " > Assault Rifle" + "\n";
						moduleData += " > Laser Rifle" + "\n";
					} else if (shipModule.displayName.Contains("Assault Class")) {
						moduleData += " > Assault Autocannon" + "\n";
						moduleData += " > Breacher Cannon" + "\n";
						moduleData += " > Assault Railgun" + "\n";
						moduleData += " > Laser Cannon" + "\n";
					}
				} else if (shipModule.displayName.Contains("Cache") && (shipModule.displayName.Contains("Implants") || shipModule.displayName.Contains("Upgrades"))) {
					moduleData += "Available Cache Sets: " + (3 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f)) + "\n";
					moduleData += "Health Increase Per Set: " + (5 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f)) + "\n";
					moduleData += "Health Increase Limit: " + (25 + (int)FFU_BE_Mod_Technology.GetModuleTier(shipModule) * 20) + "\n";
				}
				break;
			}
			moduleData += shipModule.starmapStealthDetectionLevelMax > 0 ? "Stealth Decryption Level: " + shipModule.starmapStealthDetectionLevelMax + "\n" : "";
			moduleData += shipModule.shipEvasionPercentAdd != 0 ? "Evasion Modifier: " + (shipModule.shipEvasionPercentAdd > 0 ? "+" : "") + shipModule.shipEvasionPercentAdd + "%" + "\n" : "";
			moduleData += shipModule.shipAccuracyPercentAdd != 0 ? "Accuracy Modifier: " + (shipModule.shipAccuracyPercentAdd > 0 ? "+" : "") + shipModule.shipAccuracyPercentAdd + "%" + "\n" : "";
			moduleData += shipModule.asteroidDeflectionPercentAdd != 0 ? "Asteroid Deflection: " + (shipModule.asteroidDeflectionPercentAdd > 0 ? "+" : "") + shipModule.asteroidDeflectionPercentAdd + "%" + "\n" : "";
			moduleData += shipModule.starmapSpeedAdd != 0 ? "Interstellar Speed: " + (shipModule.starmapSpeedAdd > 0 ? "+" : "") + string.Format("{0:0.0}", shipModule.starmapSpeedAdd) + "\n" : "";
			moduleData += shipModule.maxHealthAdd != 0 ? "Ship Armor Modifier: " + (shipModule.maxHealthAdd > 0 ? "+" : "") + shipModule.maxHealthAdd + "\n" : "";
			moduleData += shipModule.maxShieldAdd != 0 ? "Ship Shields Modifier: " + (shipModule.maxShieldAdd > 0 ? "+" : "") + shipModule.maxShieldAdd + "\n" : "";
			moduleData += shipModule.PowerConsumed > 0 ? "Power Consumption: " + shipModule.PowerConsumed + " GW/h" + "\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargePowerNeed > 0 ? "Overcharge Consumption: " + string.Format("{0:0}", (shipModule.overchargePowerNeed / (float)shipModule.PowerConsumed + 1f) * 100f) + "%" + "\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) moduleData += shipModule.overchargeSeconds > 0 ? "Overcharge Time: " + shipModule.overchargeSeconds + "s" + "\n" : "";
			moduleData += (shipModule.turnedOn || !shipModule.UsesTurnedOn) && FFU_BE_Defs.GetModuleEnergyEmission(shipModule) != 0f ? "Energy Emission: " + string.Format("{0:0.#}", FFU_BE_Defs.GetModuleEnergyEmission(shipModule)) + "m³\n" : "";
			moduleData += shipModule.MaxHealth > 0 ? "Maximum Durability: " + shipModule.MaxHealth + "\n" : "";
			moduleData += shipModule.costCreditsInShop > 0 ? "Market Price: $" + shipModule.costCreditsInShop : "Market Price: N/A";
			return "<color=lime>" + moduleData + "</color>";
		}
		public static string GetCraftableModuleDescription(ShipModule shipModule) {
			string newDescription = "";
			if (shipModule.name.Contains("bossweapon")) return "<color=lime>" + "Type: Unidentified" + "</color>" + "\n" + shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			if (shipModule.name.Contains("tutorial")) return "<color=lime>" + "Type: Unidentified" + "</color>" + "\n" + shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			switch (shipModule.type) {
				case ShipModule.Type.Weapon:
				newDescription += "Type: " +
					(shipModule.displayName.Contains("Rocket") ? "Rocket Launcher" :
					(shipModule.displayName.Contains("Autocannon") ? "Autocannon" :
					(shipModule.displayName.Contains("Howitzer") ? "Howitzer" :
					(shipModule.displayName.Contains("Railgun") ? "Railgun" :
					(shipModule.displayName.Contains("Railcannon") ? "Railcannon" :
					(shipModule.displayName.Contains("Laser") ? "Laser Emitter" :
					(shipModule.displayName.Contains("Beam") ? "Beam Emitter" :
					(shipModule.displayName.Contains("Heat Ray") ? "Heat Ray Projector" :
					(shipModule.displayName.Contains("Disruptor") ? "Energy Disruptor" :
					(shipModule.displayName.Contains("Exotic Ray") ? "Exotic Ray Projector" :
					"Starship Weapon")))))))))) + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Weapon.reloadInterval > 0 ? "Reload Time: " + shipModule.Weapon.reloadInterval + "s" + "\n" : "";
				newDescription += shipModule.Weapon.preShootDelay > 0 ? "Ignition Time: " + shipModule.Weapon.preShootDelay + "s" + "\n" : "";
				newDescription += shipModule.Weapon.shotInterval > 0 ? "Salvo Delay: " + shipModule.Weapon.shotInterval + "s" + "\n" : "";
				newDescription += shipModule.Weapon.accuracy > 0 ? "Accuracy: " + shipModule.Weapon.accuracy + " Δm" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? "Damage Radius: " + string.Format("{0:0.###}m", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius * 10f) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? "Ignores Shields: Yes" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? "Never Deflects: Yes" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? "Shield Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? "Module Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? "Hull Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? "Crew Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? "Crew Hit Chance: " + GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? "Fire Ignite Chance: " + GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? "EMP Effect: " + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds + "s" + "\n" : "";
				newDescription += (shipModule.Weapon.resourcesPerShot.organics > 0 ||
					shipModule.Weapon.resourcesPerShot.fuel > 0 ||
					shipModule.Weapon.resourcesPerShot.metals > 0 ||
					shipModule.Weapon.resourcesPerShot.synthetics > 0 ||
					shipModule.Weapon.resourcesPerShot.explosives > 0 ||
					shipModule.Weapon.resourcesPerShot.exotics > 0) ? "Resources Per Shot:" + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.organics > 0 ? " > Organics: " + shipModule.Weapon.resourcesPerShot.organics + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.fuel > 0 ? " > Starfuel: " + shipModule.Weapon.resourcesPerShot.fuel + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.metals > 0 ? " > Metals: " + shipModule.Weapon.resourcesPerShot.metals + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.synthetics > 0 ? " > Synthetics: " + shipModule.Weapon.resourcesPerShot.synthetics + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.explosives > 0 ? " > Explosives: " + shipModule.Weapon.resourcesPerShot.explosives + "\n" : "";
				newDescription += shipModule.Weapon.resourcesPerShot.exotics > 0 ? " > Exotic: " + shipModule.Weapon.resourcesPerShot.exotics + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Damage Dealer: Projectile" + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Projectile Identifier: " + shipModule.Weapon.ProjectileOrBeamPrefab.name + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Projectile Health: " + (shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth")) + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Projectile Velocity: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).speed + "00" + "m/s" + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Point Defense Detection: " + (shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis")) + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Point Defense Priority: " + AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority") + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Deflection Angle: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectAngleRandom + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Deflection Distance (Min): " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMin + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Deflection Distance (Max): " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMax + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? " > Expiration Time: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).selfDestructTime + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? "Damage Dealer: Beam" + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? " > Beam Identifier: " + shipModule.Weapon.ProjectileOrBeamPrefab.name + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? " > Beam Duration: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Beam).duration + "s" + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? " > Beam Health: " + AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth") + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Beam) != null ? " > Beam Deflection: " + AccessTools.FieldRefAccess<Beam, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Beam, "doDeflect") + "\n" : "";
				break;
				case ShipModule.Type.Weapon_Nuke:
				newDescription += "Type: Capital Missile" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius > 0 ? "Damage Radius: " + string.Format("{0:0.###}", shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).damageAreaRadius) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).ignoresShield ? "Ignores Shields: Yes" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).neverDeflect ? "Never Deflects: Yes" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg > 0 ? "Shield Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shieldDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg > 0 ? "Module Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg > 0 ? "Hull Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).shipDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg > 0 ? "Crew Damage: " + (shipModule.Weapon.magazineSize > 1 ? shipModule.Weapon.magazineSize + "x" : "") + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).doorDmg + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel != ShootAtDamageDealer.CrewDmgLevel.None ? "Crew Hit Chance: " + GetCrewHitChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).crewDmgLevel) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel != ShootAtDamageDealer.FireChanceLevel.None ? "Fire Ignite Chance: " + GetFireIgniteChance(shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).fireChanceLevel) + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds > 0 ? "EMP Effect: " + shipModule.Weapon.ProjectileOrBeamPrefab.GetDamage(shipModule.Weapon).moduleOverloadSeconds + "s" + "\n" : "";
				newDescription += shipModule.Weapon.ProjectileOrBeamPrefab.spawnIntruderCount > 0 ? "Boarding Payload: " + (int)Math.Round(FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 2f) + " ~ " + (int)Math.Round(FFU_BE_Defs.GetIntruderCountFromName(shipModule) * 5f) + " Units" + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Capital Missile Identifier: " + shipModule.Weapon.ProjectileOrBeamPrefab.name + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Capital Missile Health: " + (shipModule.Weapon.overrideProjectileHealth > 0 ? shipModule.Weapon.overrideProjectileHealth : AccessTools.FieldRefAccess<ShootAtDamageDealer, int>(shipModule.Weapon.ProjectileOrBeamPrefab, "maxHealth")) + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += shipModule.Weapon.accuracy > 0 ? "Capital Missile Accuracy: " + shipModule.Weapon.accuracy + "\n" : "";
				try { newDescription += "Missile Acceleration: " + (((HomingMovement)AccessTools.PropertyGetter(typeof(Projectile), "HomingMovement").Invoke(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, null)).force * 10f) + " m/s²" + "\n"; } catch { }
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Point Defense Detection: " + (shipModule.Weapon.overridePointDefCanSeeThis ? shipModule.Weapon.overridePointDefCanSeeThis : AccessTools.FieldRefAccess<Projectile, bool>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefCanSeeThis")) + "\n" : "";
				newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Point Defense Priority: " + AccessTools.FieldRefAccess<Projectile, int>(shipModule.Weapon.ProjectileOrBeamPrefab as Projectile, "pointDefPriority") + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Deflection Angle: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectAngleRandom + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Deflection Distance (Min): " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMin + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Deflection Distance (Max): " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).deflectDistanceMax + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile) != null ? "Expiration Time: " + (shipModule.Weapon.ProjectileOrBeamPrefab as Projectile).selfDestructTime + "\n" : "";
				break;
				case ShipModule.Type.PointDefence:
				newDescription += "Type: Close-In Weapon System" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.PointDefence.reloadInterval > 0 ? "Reload Time: " + shipModule.PointDefence.reloadInterval + "s" + "\n" : "";
				newDescription += shipModule.PointDefence.coverRadius > 0 ? "Cover Radius: " + shipModule.PointDefence.coverRadius * 10f + "m" + "\n" : "";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Interceptor Identifier: " + shipModule.PointDefence.projectileOrBeamPrefab.name + "\n";
				newDescription += shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg > 0 ? "Interception Damage: " + shipModule.PointDefence.projectileOrBeamPrefab.projectileDmg + "\n" : "";
				newDescription += shipModule.PointDefence.projectileOrBeamPrefab.lifetime > 0 ? "Interception Delay: " + shipModule.PointDefence.projectileOrBeamPrefab.lifetime + "s" + "\n" : "";
				newDescription += (shipModule.PointDefence.resourcesPerShot.organics > 0 ||
					shipModule.PointDefence.resourcesPerShot.fuel > 0 ||
					shipModule.PointDefence.resourcesPerShot.metals > 0 ||
					shipModule.PointDefence.resourcesPerShot.synthetics > 0 ||
					shipModule.PointDefence.resourcesPerShot.explosives > 0 ||
					shipModule.PointDefence.resourcesPerShot.exotics > 0) ? "Resources Per Shot:" + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.organics > 0 ? " > Organics: " + shipModule.PointDefence.resourcesPerShot.organics + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.fuel > 0 ? " > Starfuel: " + shipModule.PointDefence.resourcesPerShot.fuel + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.metals > 0 ? " > Metals: " + shipModule.PointDefence.resourcesPerShot.metals + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.synthetics > 0 ? " > Synthetics: " + shipModule.PointDefence.resourcesPerShot.synthetics + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.explosives > 0 ? " > Explosives: " + shipModule.PointDefence.resourcesPerShot.explosives + "\n" : "";
				newDescription += shipModule.PointDefence.resourcesPerShot.exotics > 0 ? " > Exotic: " + shipModule.PointDefence.resourcesPerShot.exotics + "\n" : "";
				break;
				case ShipModule.Type.Bridge:
				newDescription += "Type: Command Bridge" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Bridge Operators: " + shipModule.OperatorSpots.Length + "\n" : "";
				break;
				case ShipModule.Type.Engine:
				newDescription += "Type: Sub-Light Engine" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.Engine.ConsumedPerDistance.organics > 0 ||
					shipModule.Engine.ConsumedPerDistance.fuel > 0 ||
					shipModule.Engine.ConsumedPerDistance.metals > 0 ||
					shipModule.Engine.ConsumedPerDistance.synthetics > 0 ||
					shipModule.Engine.ConsumedPerDistance.explosives > 0 ||
					shipModule.Engine.ConsumedPerDistance.exotics > 0) ? "Resources Consumption:" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.organics > 0 ? " > Organics: " + shipModule.Engine.ConsumedPerDistance.organics * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.fuel > 0 ? " > Starfuel: " + shipModule.Engine.ConsumedPerDistance.fuel * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.metals > 0 ? " > Metals: " + shipModule.Engine.ConsumedPerDistance.metals * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.synthetics > 0 ? " > Synthetics: " + shipModule.Engine.ConsumedPerDistance.synthetics * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.explosives > 0 ? " > Explosives: " + shipModule.Engine.ConsumedPerDistance.explosives * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Engine.ConsumedPerDistance.exotics > 0 ? " > Exotics: " + shipModule.Engine.ConsumedPerDistance.exotics * 100 + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Warp:
				newDescription += "Type: Warp Drive" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Warp.reloadInterval > 0 ? "Jump Drive Recharge: " + shipModule.Warp.reloadInterval + "s" + "\n" : "";
				newDescription += shipModule.Warp.activationFuel > 0 ? "Jump Fuel Consumption: " + shipModule.Warp.activationFuel + "\n" : "";
				break;
				case ShipModule.Type.Reactor:
				newDescription += "Type: Energy Reactor" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Reactor.powerCapacity > 0 ? "Power Production: " + shipModule.Reactor.powerCapacity + " GW/h" + "\n" : "";
				newDescription += shipModule.Reactor.overchargePowerCapacityAdd > 0 ? "Overcharge Production: " + string.Format("{0:0}", (shipModule.Reactor.overchargePowerCapacityAdd / (float)shipModule.Reactor.powerCapacity + 1f) * 100f) + "%" + "\n" : "";
				newDescription += shipModule.overchargeSeconds > 0 ? "Overcharge Time: " + shipModule.overchargeSeconds + "s" + "\n" : "";
				newDescription += (shipModule.Reactor.ConsumedPerDistance.organics > 0 ||
					shipModule.Reactor.ConsumedPerDistance.fuel > 0 ||
					shipModule.Reactor.ConsumedPerDistance.metals > 0 ||
					shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ||
					shipModule.Reactor.ConsumedPerDistance.explosives > 0 ||
					shipModule.Reactor.ConsumedPerDistance.exotics > 0) ? "Resources Consumption:" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.organics > 0 ? " > Organics: " + shipModule.Reactor.ConsumedPerDistance.organics * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.fuel > 0 ? " > Starfuel: " + shipModule.Reactor.ConsumedPerDistance.fuel * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.metals > 0 ? " > Metals: " + shipModule.Reactor.ConsumedPerDistance.metals * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.synthetics > 0 ? " > Synthetics: " + shipModule.Reactor.ConsumedPerDistance.synthetics * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.explosives > 0 ? " > Explosives: " + shipModule.Reactor.ConsumedPerDistance.explosives * 100 + "/100ru" + "\n" : "";
				newDescription += shipModule.Reactor.ConsumedPerDistance.exotics > 0 ? " > Exotics: " + shipModule.Reactor.ConsumedPerDistance.exotics * 100 + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Container:
				newDescription += "Type: Storage Container" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Container.MaxOrganics > 0 ? "Organics Storage: " + shipModule.Container.MaxOrganics + "\n" : "";
				newDescription += shipModule.Container.MaxFuel > 0 ? "Starfuel Storage: " + shipModule.Container.MaxFuel + "\n" : "";
				newDescription += shipModule.Container.MaxMetals > 0 ? "Metals Storage: " + shipModule.Container.MaxMetals + "\n" : "";
				newDescription += shipModule.Container.MaxSynthetics > 0 ? "Synthetics Storage: " + shipModule.Container.MaxSynthetics + "\n" : "";
				newDescription += shipModule.Container.MaxExplosives > 0 ? "Explosives Storage: " + shipModule.Container.MaxExplosives + "\n" : "";
				newDescription += shipModule.Container.MaxExotics > 0 ? "Exotics Storage: " + shipModule.Container.MaxExotics + "\n" : "";
				break;
				case ShipModule.Type.Integrity:
				newDescription += "Type: Integrity Armor" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.ShieldGen:
				newDescription += "Type: " + (shipModule.ShieldGen.reloadInterval > 0 ? "Shield Generator" : "Shield Capacitor") + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.ShieldGen.reloadInterval > 0 ? "Shield Regeneration: " + shipModule.ShieldGen.reloadInterval + "s" + "\n" : "";
				newDescription += shipModule.ShieldGen.maxShieldAdd > 0 ? "Shield Capacity: " + shipModule.ShieldGen.maxShieldAdd + "\n" : "";
				break;
				case ShipModule.Type.Sensor:
				newDescription += "Type: Sensor Array" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Sensor.sectorRadarRange > 0 ? "Sector Radar Range: " + shipModule.Sensor.sectorRadarRange + "\n" : "";
				newDescription += shipModule.Sensor.starmapRadarRange > 0 ? "Starmap Radar Range: " + shipModule.Sensor.starmapRadarRange + "\n" : "";
				break;
				case ShipModule.Type.StealthDecryptor:
				newDescription += "Type: Stealth Generator" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.PassiveECM:
				newDescription += "Type: Countermeasure Array" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.Dronebay:
				case ShipModule.Type.Medbay:
				newDescription += "Type: " + (shipModule.Medbay.resourcesPerHp.organics > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Restoration Bay" : 
					(shipModule.Medbay.resourcesPerHp.organics > 0 ? "Crew Medical Bay" : (shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Drone Repair Bay" : "Unidentified Health Bay"))) + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Medbay Crew Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Medbay Healing Speed: " + shipModule.Medbay.secondsPerHp + "s" + "\n" : "";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.organics > 0 ? "Organics Consumption: " + shipModule.Medbay.resourcesPerHp.organics + "/HP" + "\n" : "";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Dronebay Bots Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Dronebay Repair Speed: " + shipModule.Medbay.secondsPerHp + "s" + "\n" : "";
				newDescription += shipModule.Medbay.secondsPerHp > 0 && shipModule.Medbay.resourcesPerHp.synthetics > 0 ? "Synthetics Consumption: " + shipModule.Medbay.resourcesPerHp.synthetics + "/HP" + "\n" : "";
				break;
				case ShipModule.Type.Cryosleep:
				newDescription += "Type: " + (shipModule.Cryosleep.genDreamCredits ? "Cryodream Bay" : "Cryosleep Bay") + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Cryosleep Crew Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Crew Food Consumption: " + "Disabled" + "\n" : "";
				newDescription += shipModule.Cryosleep.healOneCrewHp ? "Health Recovery Distance: " + shipModule.Cryosleep.healOneCrewHpDistance.minValue + "ru ~ " + shipModule.Cryosleep.healOneCrewHpDistance.maxValue + "ru" + "\n" : "";
				newDescription += shipModule.Cryosleep.genDreamCredits ? "Cryodream Record Distance: " + shipModule.Cryosleep.genDreamCreditsDistance.minValue + "ru ~ " + shipModule.Cryosleep.genDreamCreditsDistance.maxValue + "ru" + "\n" : "";
				newDescription += shipModule.Cryosleep.genDreamCredits ? "Credits Per Cryodream: " + shipModule.Cryosleep.creditsPerDream.minValue + " ~ " + shipModule.Cryosleep.creditsPerDream.maxValue + "\n" : "";
				break;
				case ShipModule.Type.ResearchLab:
				float researchSpeed = (shipModule.Research.producedPerSkillPoint.credits / 1000f + shipModule.Research.producedPerSkillPoint.exotics / 20f) * FFU_BE_Defs.tierResearchSpeedMult;
				float reversingSpeed = (shipModule.Research.producedPerSkillPoint.credits / 333.33f + shipModule.Research.producedPerSkillPoint.exotics / 6.66f) * FFU_BE_Defs.moduleResearchSpeedMult;
				newDescription += "Type: Research Laboratory" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Researchers Capacity: " + shipModule.OperatorSpots.Length + "\n" : "";
				newDescription += (researchSpeed > 0 || reversingSpeed > 0) ? "Effects/Skill Point:" + "\n" : "";
				newDescription += (researchSpeed > 0) ? " > Research Progress: " + string.Format("{0:0.0}", researchSpeed * 100f) + "/100ru" + "\n" : "";
				newDescription += (reversingSpeed > 0) ? " > Reverse Engineering: " + string.Format("{0:0.0}", reversingSpeed * 100f) + "/100ru" + "\n" : "";
				newDescription += (shipModule.Research.producedPerSkillPoint.credits > 0 ||
					shipModule.Research.producedPerSkillPoint.organics > 0 ||
					shipModule.Research.producedPerSkillPoint.fuel > 0 ||
					shipModule.Research.producedPerSkillPoint.metals > 0 ||
					shipModule.Research.producedPerSkillPoint.synthetics > 0 ||
					shipModule.Research.producedPerSkillPoint.explosives > 0 ||
					shipModule.Research.producedPerSkillPoint.exotics > 0) ? "Production/Skill Point:" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.credits > 0 ? " > Credits: " + shipModule.Research.producedPerSkillPoint.credits + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.organics > 0 ? " > Organics: " + shipModule.Research.producedPerSkillPoint.organics + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.fuel > 0 ? " > Starfuel: " + shipModule.Research.producedPerSkillPoint.fuel + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.metals > 0 ? " > Metals: " + shipModule.Research.producedPerSkillPoint.metals + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.synthetics > 0 ? " > Synthetics: " + shipModule.Research.producedPerSkillPoint.synthetics + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.explosives > 0 ? " > Explosives: " + shipModule.Research.producedPerSkillPoint.explosives + "/100ru" + "\n" : "";
				newDescription += shipModule.Research.producedPerSkillPoint.exotics > 0 ? " > Exotics: " + shipModule.Research.producedPerSkillPoint.exotics + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.Garden:
				newDescription += "Type: Greenhouse Facility" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Agricultural Operators: " + shipModule.OperatorSpots.Length + "\n" : "";
				newDescription += (shipModule.OperatorSpots.Length > 0) ? "Operators Food Consumption: " + "Disabled" + "\n" : "";
				newDescription += (shipModule.GardenModule.producedPerSkillPoint.credits > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.organics > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.fuel > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.metals > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.synthetics > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.explosives > 0 ||
					shipModule.GardenModule.producedPerSkillPoint.exotics > 0) ? "Production/Skill Point:" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.credits > 0 ? " > Credits: " + shipModule.GardenModule.producedPerSkillPoint.credits + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.organics > 0 ? " > Organics: " + shipModule.GardenModule.producedPerSkillPoint.organics + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.fuel > 0 ? " > Starfuel: " + shipModule.GardenModule.producedPerSkillPoint.fuel + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.metals > 0 ? " > Metals: " + shipModule.GardenModule.producedPerSkillPoint.metals + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.synthetics > 0 ? " > Synthetics: " + shipModule.GardenModule.producedPerSkillPoint.synthetics + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.explosives > 0 ? " > Explosives: " + shipModule.GardenModule.producedPerSkillPoint.explosives + "/100ru" + "\n" : "";
				newDescription += shipModule.GardenModule.producedPerSkillPoint.exotics > 0 ? " > Exotics: " + shipModule.GardenModule.producedPerSkillPoint.exotics + "/100ru" + "\n" : "";
				break;
				case ShipModule.Type.MaterialsConverter:
				newDescription += "Type: Industrial Facility" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				newDescription += (shipModule.MaterialsConverter.produce.organics > 0 ||
					shipModule.MaterialsConverter.produce.fuel > 0 ||
					shipModule.MaterialsConverter.produce.metals > 0 ||
					shipModule.MaterialsConverter.produce.synthetics > 0 ||
					shipModule.MaterialsConverter.produce.explosives > 0 ||
					shipModule.MaterialsConverter.produce.exotics > 0) ? "Industrial Production:" + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.organics > 0 ? " > Organics: " + (shipModule.MaterialsConverter.produce.organics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.fuel > 0 ? " > Starfuel: " + (shipModule.MaterialsConverter.produce.fuel * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.metals > 0 ? " > Metals: " + (shipModule.MaterialsConverter.produce.metals * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.synthetics > 0 ? " > Synthetics: " + (shipModule.MaterialsConverter.produce.synthetics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.explosives > 0 ? " > Explosives: " + (shipModule.MaterialsConverter.produce.explosives * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.exotics > 0 ? " > Exotics: " + (shipModule.MaterialsConverter.produce.exotics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.produce.credits > 0 ? " > Xenodata: " + (shipModule.MaterialsConverter.produce.credits * 60) + "/min." + "\n" : "";
				newDescription += (shipModule.MaterialsConverter.consume.organics > 0 ||
					shipModule.MaterialsConverter.consume.fuel > 0 ||
					shipModule.MaterialsConverter.consume.metals > 0 ||
					shipModule.MaterialsConverter.consume.synthetics > 0 ||
					shipModule.MaterialsConverter.consume.explosives > 0 ||
					shipModule.MaterialsConverter.consume.exotics > 0) ? "Industrial Consumption:" + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.organics > 0 ? " > Organics: " + (shipModule.MaterialsConverter.consume.organics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.fuel > 0 ? " > Starfuel: " + (shipModule.MaterialsConverter.consume.fuel * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.metals > 0 ? " > Metals: " + (shipModule.MaterialsConverter.consume.metals * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.synthetics > 0 ? " > Synthetics: " + (shipModule.MaterialsConverter.consume.synthetics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.explosives > 0 ? " > Explosives: " + (shipModule.MaterialsConverter.consume.explosives * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.exotics > 0 ? " > Exotics: " + (shipModule.MaterialsConverter.consume.exotics * 60) + "/min." + "\n" : "";
				newDescription += shipModule.MaterialsConverter.consume.credits > 0 ? " > Xenodata: " + (shipModule.MaterialsConverter.consume.credits * 60) + "/min." + "\n" : "";
				break;
				case ShipModule.Type.Fighter:
				newDescription += "Type: Fighter Bay" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.Decoy:
				newDescription += "Type: Decoy Module" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.ResourcePack:
				newDescription += "Type: Resource Package" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				case ShipModule.Type.Storage:
				newDescription += "Type: Modular Storage" + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				break;
				default:
				newDescription += "Type: " + (shipModule.displayName.Contains("Cache") ?
					(shipModule.displayName.Contains("Weapons") ? "Weapons" :
					shipModule.displayName.Contains("Implants") ? "Implants" :
					shipModule.displayName.Contains("Upgrades") ? "Upgrades" :
					"Unidentified") + " Cache" :
					shipModule.name.Contains("artifact") ? "Artifact" : "Unidentified") + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Identifier: " + shipModule.name + "\n";
				if (FFU_BE_Defs.allModuleProps) newDescription += "Module Prefab ID: " + shipModule.PrefabId + "\n";
				if (shipModule.displayName.Contains("Cache") && shipModule.displayName.Contains("Weapons")) {
					newDescription += "Initial Weapon Sets: " + 3 + "\n";
					newDescription += "Available Weapons: " + "\n";
					if (shipModule.displayName.Contains("CQC Class")) {
						newDescription += " > Power Fists" + "\n";
						newDescription += " > Dual Welder" + "\n";
						newDescription += " > Napalm Gun" + "\n";
						newDescription += " > Toxic Gun" + "\n";
					} else if (shipModule.displayName.Contains("Kinetic Type")) {
						newDescription += " > Assault Pistol" + "\n";
						newDescription += " > Light Revolver" + "\n";
						newDescription += " > Heavy Revolver" + "\n";
						newDescription += " > Assault Revolver" + "\n";
						newDescription += " > Assault SMG" + "\n";
						newDescription += " > Assault Shotgun" + "\n";
						newDescription += " > Assault Rifle" + "\n";
						newDescription += " > Assault Autocannon" + "\n";
						newDescription += " > Breacher Cannon" + "\n";
						newDescription += " > Assault Railgun" + "\n";
					} else if (shipModule.displayName.Contains("Laser Type")) {
						newDescription += " > Laser Pistol" + "\n";
						newDescription += " > Laser Rifle" + "\n";
						newDescription += " > Laser Cannon" + "\n";
					} else if (shipModule.displayName.Contains("Energy Type")) {
						newDescription += " > Blaster Pistol" + "\n";
						newDescription += " > Blaster Rifle" + "\n";
						newDescription += " > Warp Ray Gun" + "\n";
						newDescription += " > Particle Gun" + "\n";
					} else if (shipModule.displayName.Contains("Backup Class")) {
						newDescription += " > Assault Pistol" + "\n";
						newDescription += " > Light Revolver" + "\n";
						newDescription += " > Heavy Revolver" + "\n";
						newDescription += " > Assault Revolver" + "\n";
						newDescription += " > Laser Pistol" + "\n";
					} else if (shipModule.displayName.Contains("Tactical Class")) {
						newDescription += " > Assault SMG" + "\n";
						newDescription += " > Assault Shotgun" + "\n";
						newDescription += " > Assault Rifle" + "\n";
						newDescription += " > Laser Rifle" + "\n";
					} else if (shipModule.displayName.Contains("Assault Class")) {
						newDescription += " > Assault Autocannon" + "\n";
						newDescription += " > Breacher Cannon" + "\n";
						newDescription += " > Assault Railgun" + "\n";
						newDescription += " > Laser Cannon" + "\n";
					}
				} else if (shipModule.displayName.Contains("Cache") && (shipModule.displayName.Contains("Implants") || shipModule.displayName.Contains("Upgrades"))) {
					newDescription += "Initial Cache Sets: " + 3 + "\n";
					newDescription += "Health Increase Per Set: " + 5 + "\n";
					newDescription += "Health Increase Limit: " + 45 + "\n";
				}
				break;
			}
			newDescription += shipModule.starmapStealthDetectionLevelMax > 0 ? "Stealth Decryption Level: " + shipModule.starmapStealthDetectionLevelMax + "\n" : "";
			newDescription += shipModule.shipEvasionPercentAdd != 0 ? "Evasion Modifier: " + (shipModule.shipEvasionPercentAdd > 0 ? "+" : "") + shipModule.shipEvasionPercentAdd + "%" + "\n" : "";
			newDescription += shipModule.shipAccuracyPercentAdd != 0 ? "Accuracy Modifier: " + (shipModule.shipAccuracyPercentAdd > 0 ? "+" : "") + shipModule.shipAccuracyPercentAdd + "%" + "\n" : "";
			newDescription += shipModule.asteroidDeflectionPercentAdd != 0 ? "Asteroid Deflection: " + (shipModule.asteroidDeflectionPercentAdd > 0 ? "+" : "") + shipModule.asteroidDeflectionPercentAdd + "%" + "\n" : "";
			newDescription += shipModule.starmapSpeedAdd != 0 ? "Interstellar Speed: " + (shipModule.starmapSpeedAdd > 0 ? "+" : "") + string.Format("{0:0.0}", shipModule.starmapSpeedAdd) + "\n" : "";
			newDescription += shipModule.maxHealthAdd != 0 ? "Ship Armor Modifier: " + (shipModule.maxHealthAdd > 0 ? "+" : "") + shipModule.maxHealthAdd + "\n" : "";
			newDescription += shipModule.maxShieldAdd != 0 ? "Ship Shields Modifier: " + (shipModule.maxShieldAdd > 0 ? "+" : "") + shipModule.maxShieldAdd + "\n" : "";
			newDescription += shipModule.PowerConsumed > 0 ? "Power Consumption: " + shipModule.PowerConsumed + " GW/h" + "\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) newDescription += shipModule.overchargePowerNeed > 0 ? "Overcharge Consumption: " + string.Format("{0:0}", (shipModule.overchargePowerNeed / (float)shipModule.PowerConsumed + 1f) * 100f) + "%" + "\n" : "";
			if (shipModule.type != ShipModule.Type.Reactor) newDescription += shipModule.overchargeSeconds > 0 ? "Overcharge Time: " + shipModule.overchargeSeconds + "s" + "\n" : "";
			newDescription += !string.IsNullOrEmpty(FFU_BE_Defs.GetModuleEnergyEmissionText(shipModule)) ? "Energy Emission: " + FFU_BE_Defs.GetModuleEnergyEmissionText(shipModule) + "\n" : "";
			newDescription += shipModule.MaxHealth > 0 ? "Maximum Durability: " + shipModule.MaxHealth + "\n" : "";
			newDescription += FFU_BE_Defs.IsAllowedModuleCategory(shipModule) ? "Crafting Proficiency: " + string.Format("{0:0.#}", FFU_BE_Defs.GetModuleCraftingProficiency(shipModule) * 100f) + "%" + "\n" : "";
			newDescription += shipModule.costCreditsInShop > 0 ? "Base Price: $" + shipModule.costCreditsInShop + "\n" : "Base Price: N/A" + "\n";
			if (!string.IsNullOrEmpty(newDescription)) newDescription = "<color=lime>" + newDescription + "</color>" + shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			else newDescription = shipModule.description.Wrap(lineLength: FFU_BE_Defs.wordWrapLimit);
			return newDescription;
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
			groupedDmgTextHover.hoverText = ((stringBuilder.Length <= 0) ? "" : stringBuilder.ToString(0, stringBuilder.Length - 1));
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
			SafeUpdateField(dmgAreaText, damage.damageAreaRadius * 10f, ref prevWeaponDmgArea, "{0:0.###}m");
			DoWeaponCrewDmg(weapon, damage.crewDmgLevel);
			DoWeaponFireChance(damage.fireChanceLevel);
		}
		//Updated Point Defense Information
		[MonoModReplace] private void DoPointDefence() {
			PointDefenceModule pointDefence = m.PointDefence;
			PointDefDamageDealer projectileOrBeamPrefab = pointDefence.projectileOrBeamPrefab;
			ResourceValueGroup resourcesPerShot = pointDefence.resourcesPerShot;
			string arg = Localization.TT("per");
			GunnerySkillEffects gunnerySkillEffects = WorldRules.Instance.gunnerySkillEffects;
			pointDefReloadTime.SetActiveIfNeeded();
			float pdEffReload = pointDefence.reloadInterval * gunnerySkillEffects.EffectiveSkillMultiplier(m, true);
			if (m.HasFullHealth) pointDefReloadTime.effects.text = pointDefence.reloadInterval != pdEffReload ? $"<color=lime>{pdEffReload:0.00}{Localization.TT("s")}</color>": $"{pdEffReload:0.00}{Localization.TT("s")}";
			else pointDefReloadTime.effects.text = $"<color=red>{pdEffReload / FFU_BE_Defs.GetHealthPercent(m):0.00}{Localization.TT("s")}</color>";
			pointDefReloadTime.skillBonus.text = $"-{gunnerySkillEffects.skillPointBonusPercent}% {arg}";
			pointDefReloadTime.Hoverable.hoverText = string.Format(pointDefReloadTime.HoverableTextTemplate, gunnerySkillEffects.skillPointBonusPercent);
			pointDefCoverRadius.SetActiveIfNeeded();
			float pdEffRadius = pointDefence.EffectiveCoverRadius;
			if (m.HasFullHealth) pointDefCoverRadius.effects.text = pointDefence.coverRadius != pdEffRadius ? $"<color=lime>{pdEffRadius * 10f:0.0}{Localization.TT("m")}</color>" : $"{pdEffRadius * 10f:0.0}{Localization.TT("m")}";
			else pointDefCoverRadius.effects.text = $"<color=red>{pdEffRadius * 10f * FFU_BE_Defs.GetHealthPercent(m):0.0}{Localization.TT("m")}</color>";
			pointDefCoverRadius.skillBonus.text = $"+{gunnerySkillEffects.skillPointBonusPercent}% {arg}";
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
			string arg = Localization.TT("ru");
			string arg2 = Localization.TT("per");
			SafeUpdateField(sensorSectorRadarRange, sensor.sectorRadarRange + arg);
			if (sensor.starmapRadarRange != 0) {
				sensorStarmapRadarRange.SetActiveIfNeeded();
				SensorSkillEffects sensorSkillEffects = WorldRules.Instance.sensorSkillEffects;
				float num = sensor.starmapRadarRange * sensorSkillEffects.EffectiveSkillMultiplier(m, false);
				sensorStarmapRadarRange.effects.text = sensor.starmapRadarRange + arg + ((sensor.starmapRadarRange != num) ? $" <color=lime>({num:0}{arg})</color>" : "");
				sensorStarmapRadarRange.skillBonus.text = $"+{sensorSkillEffects.skillPointBonusPercent}% {arg2}";
				sensorStarmapRadarRange.Hoverable.hoverText = string.Format(sensorStarmapRadarRange.HoverableTextTemplate, sensorSkillEffects.skillPointBonusPercent);
			}
		}
		//Updated Bridge Information
		[MonoModReplace] private void DoBridge() {
			bridgeRemoteOpsGo.SetActive(true);
			BridgeSkillEffects bridgeSkillEffects = WorldRules.Instance.bridgeSkillEffects;
			bridgeEvasion.SetActiveIfNeeded();
			int num = bridgeSkillEffects.EffectiveSkillBonusPercent(m);
			bridgeEvasion.effects.text = m.shipEvasionPercentAdd + ((m.shipEvasionPercentAdd != num) ? $" <color=lime>({num})</color>" : "");
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
