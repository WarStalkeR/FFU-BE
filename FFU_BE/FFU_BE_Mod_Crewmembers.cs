#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108

using HarmonyLib;
using MonoMod;
using RST;
using RST.UI;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using FFU_Bleeding_Edge;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Crewmembers {
		public static int GetShipID(Ship ship) {
			if (ship.name.Contains("Tigerfish")) return 0;
			else if (ship.name.Contains("Nuke Runner")) return 1;
			else if (ship.name.Contains("Weirdship")) return 2;
			else if (ship.name.Contains("Rogue Rat")) return 3;
			else if (ship.name.Contains("Gardenship")) return 4;
			else if (ship.name.Contains("Atlas")) return 5;
			else if (ship.name.Contains("Bluestar")) return 6;
			else if (ship.name.Contains("Roundship")) return 7;
			else if (ship.name.Contains("Endurance")) return 8;
			else if (ship.name.Contains("BattleTiger")) return 9;
			else if (ship.name.Contains("Easy Tiger")) return 10;
			else return 0;
		}
		public static string GetMoodTextFromWeapon(string weaponName) {
			if (weaponName == "Hand weapon tazerfists") return Localization.TT(" and understood why screaming \"FOR THE EMPEROR!\" while trying to bash invisible heresy feels great.");
			else if (weaponName == "Hand weapon welder double") return Localization.TT(" and started thinking deeply how effective will it be on USG Ishimura at cutting necromorphs' limbs.");
			else if (weaponName == "Hand weapon flamepistol") return Localization.TT(", because killing with fire is the best way to purify dirty souls of these unwelcome guests on your ship.");
			else if (weaponName == "Hand weapon acidgun") return Localization.TT(", because killing with fire is not enough and turning somebody into toxic sludge is best way to show your compassion.");
			else if (weaponName == "Hand weapon autopistol") return Localization.TT(" and got the feeling that speaking with British accent sentences like \"For King and Country!\" seems absolutely legit.");
			else if (weaponName == "Hand weapon revolver small") return Localization.TT(" and suddenly remembered historical lesson that God created people different, but Colonel Colt made them equal.");
			else if (weaponName == "Hand weapon revolver large") return Localization.TT(" and feels like he got transfered to the ancient times of Wild West, where Clint Eastwood was serious business.");
			else if (weaponName == "Hand weapon revolver large acc") return Localization.TT(" and was weirded out how unbalanced it looks. Even attached tactical system itself questions sanity of the user.");
			else if (weaponName == "Hand weapon uzi") return Localization.TT(" and started looking for its silencer, but then remembered about wrong time, place and occurrence and embarrassingly hid it.");
			else if (weaponName == "Hand weapon shotgun") return Localization.TT(", because when Zombie Apocalypse starts, shotgun with infinite ammo is your best friend, especially against Nazi Zombies.");
			else if (weaponName == "Hand weapon assaultrifle") return Localization.TT(" and regrets that this is just a standard issue modern Assault Rifle, and not Storm Bolter with proper Hellfire rounds.");
			else if (weaponName == "Hand weapon precisiongatling") return Localization.TT(" and feels that bringing democracy, enlightenment and compassion to disagreeing parties became so much easier.");
			else if (weaponName == "Hand weapon handcannon") return Localization.TT(" and agrees that caliber matters, especially when it comes to 90mm High-Explosive Anti-Armor Tungsten Carbide Perforating rounds.");
			else if (weaponName == "Hand weapon diyrailgun") return Localization.TT(", noticed unknown \"Caldari Navy Issue\" label on it and already imagines 20-Mach projectile ripping apart everything in its way.");
			else if (weaponName == "Hand weapon laser pistol") return Localization.TT(" and understood that even at its finest times, it was only giving hope to its wielder at best, when facing army of reapers.");
			else if (weaponName == "Hand weapon diylasergun") return Localization.TT(" and started reminiscing about good old times, when it was efficiently used to burst sectoid brains like fresh watermelons.");
			else if (weaponName == "Hand weapon laserrifle") return Localization.TT(" and started playing around with it, but suddenly remembered that in its own time, it was only viable weapon against chryssalids.");
			else if (weaponName == "Hand weapon insect pinkray pistol") return Localization.TT(" and feels happy about getting ability to role-play hist favorite character, captain Kirk from very famous sci-fi series.");
			else if (weaponName == "Hand weapon insect pinkray rifle") return Localization.TT(", was weirded out by its looks, but decided to keep it anyway, because going into battle barehanded is bad idea.");
			else if (weaponName == "Hand weapon warpeffector") return Localization.TT(" and started to feel presence of immaterium, but got bored quickly, because random dude named \"Khorne\" was especially annoying.");
			else if (weaponName == "Hand weapon yellow raypistol") return Localization.TT(" and remembered historical joke about Large Hadron Collider, where best scientists gather every 7 billion years and activate it.");
			else return Localization.TT(" and started thinking deeply about meaning of life.");
		}
		public static string GetMoodTextFromWeapon(HandWeapon handWeapon) {
			if (handWeapon != null) {
				switch (handWeapon.PrefabId) {
					case 678337536: return Localization.TT(" and understood why screaming \"FOR THE EMPEROR!\" while trying to bash invisible heresy feels great.");
					case 266021953: return Localization.TT(" and started thinking deeply how effective will it be on USG Ishimura at cutting necromorphs' limbs.");
					case 1990035535: return Localization.TT(", because killing with fire is the best way to purify dirty souls of these unwelcome guests on your ship.");
					case 607231408: return Localization.TT(", because killing with fire is not enough and turning somebody into toxic sludge is best way to show your compassion.");
					case 1878534267: return Localization.TT(" and got the feeling that speaking with British accent sentences like \"For King and Country!\" seems absolutely legit.");
					case 933952449: return Localization.TT(" and suddenly remembered historical lesson that God created people different, but Colonel Colt made them equal.");
					case 117866831: return Localization.TT(" and feels like he got transfered to the ancient times of Wild West, where Clint Eastwood was serious business.");
					case 270410422: return Localization.TT(" and was weirded out how unbalanced it looks. Even attached tactical system itself questions sanity of the user.");
					case 799894355: return Localization.TT(" and started looking for its silencer, but then remembered about wrong time, place and occurrence and embarrassingly hid it.");
					case 1702502749: return Localization.TT(", because when Zombie Apocalypse starts, shotgun with infinite ammo is your best friend, especially against Nazi Zombies.");
					case 1906191868: return Localization.TT(" and regrets that this is just a standard issue modern Assault Rifle, and not Storm Bolter with proper Hellfire rounds.");
					case 82011213: return Localization.TT(" and feels that bringing democracy, enlightenment and compassion to disagreeing parties became so much easier.");
					case 658851245: return Localization.TT(" and agrees that caliber matters, especially when it comes to 90mm High-Explosive Anti-Armor Tungsten Carbide Perforating rounds.");
					case 82876487: return Localization.TT(", noticed unknown \"Caldari Navy Issue\" label on it and already imagines 20-Mach projectile ripping apart everything in its way.");
					case 2126525717: return Localization.TT(" and understood that even at its finest times, it was only giving hope to its wielder at best, when facing army of reapers.");
					case 1310955184: return Localization.TT(" and started reminiscing about good old times, when it was efficiently used to burst sectoid brains like fresh watermelons.");
					case 1723915276: return Localization.TT(" and started playing around with it, but suddenly remembered that in its own time, it was only viable weapon against chryssalids.");
					case 928676718: return Localization.TT(" and feels happy about getting ability to role-play hist favorite character, captain Kirk from very famous sci-fi series.");
					case 154008401: return Localization.TT(", was weirded out by its looks, but decided to keep it anyway, because going into battle barehanded is bad idea.");
					case 1558207795: return Localization.TT(" and started to feel presence of immaterium, but got bored quickly, because random dude named \"Khorne\" was especially annoying.");
					case 1688300750: return Localization.TT(" and remembered historical joke about Large Hadron Collider, where best scientists gather every 7 billion years and activate it.");
					default: return Localization.TT(" and started thinking deeply about meaning of life.");
				}
			} else return Localization.TT(" and started thinking deeply about meaning of life.");
		}
		public static List<string> GetWeaponNameIDsFromCacheID(int cachePrefabID) {
			switch (cachePrefabID) {
				case 1745395900: return new List<string> {
					"Hand weapon tazerfists",
					"Hand weapon welder double",
					"Hand weapon flamepistol",
					"Hand weapon acidgun" }; ;
				case 179311957: return new List<string> {
					"Hand weapon revolver large acc",
					"Hand weapon uzi",
					"Hand weapon shotgun",
					"Hand weapon assaultrifle",
					"Hand weapon precisiongatling",
					"Hand weapon handcannon",
					"Hand weapon diyrailgun" };
				case 760711671: return new List<string> {
					"Hand weapon laser pistol",
					"Hand weapon diylasergun",
					"Hand weapon laserrifle" };
				case 656277331: return new List<string> {
					"Hand weapon insect pinkray pistol",
					"Hand weapon insect pinkray rifle",
					"Hand weapon warpeffector",
					"Hand weapon yellow raypistol" };
				case 760711667: return new List<string> {
					"Hand weapon autopistol",
					"Hand weapon revolver small",
					"Hand weapon revolver large",
					"Hand weapon revolver large acc",
					"Hand weapon laser pistol" };
				case 1279608160: return new List<string> {
					"Hand weapon uzi",
					"Hand weapon shotgun",
					"Hand weapon assaultrifle",
					"Hand weapon diylasergun" };
				case 1316302015: return new List<string> {
					"Hand weapon precisiongatling",
					"Hand weapon handcannon",
					"Hand weapon diyrailgun",
					"Hand weapon laserrifle" };
				default: return null;
			}
		}
		public static List<string> GetWeaponLocalesFromCacheID(int cachePrefabID, string itemSpacing) {
			List<string> listedItems = new List<string>();
			switch (cachePrefabID) {
				case 1745395900: listedItems = new List<string> {
					Localization.TT("Power Fists"),
					Localization.TT("Dual Welder"),
					Localization.TT("Napalm Gun"),
					Localization.TT("Toxic Gun")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 179311957: listedItems = new List<string> {
					Localization.TT("Assault Revolver"),
					Localization.TT("Assault SMG"),
					Localization.TT("Assault Shotgun"),
					Localization.TT("Assault Rifle"),
					Localization.TT("Tactical Railgun"),
					Localization.TT("Assault Autocannon"),
					Localization.TT("Breacher Cannon")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 760711671: listedItems = new List<string> {
					Localization.TT("Laser Pistol"),
					Localization.TT("Laser Rifle"),
					Localization.TT("Laser Cannon")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 656277331: listedItems = new List<string> {
					Localization.TT("Blaster Pistol"),
					Localization.TT("Blaster Rifle"),
					Localization.TT("Warp Ray Gun"),
					Localization.TT("Particle Gun")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 760711667: listedItems = new List<string> {
					Localization.TT("Assault Pistol"),
					Localization.TT("Light Revolver"),
					Localization.TT("Heavy Revolver"),
					Localization.TT("Assault Revolver"),
					Localization.TT("Laser Pistol")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 1279608160: listedItems = new List<string> {
					Localization.TT("Assault SMG"),
					Localization.TT("Assault Shotgun"),
					Localization.TT("Assault Rifle"),
					Localization.TT("Laser Rifle")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				case 1316302015: listedItems = new List<string> {
					Localization.TT("Tactical Railgun"),
					Localization.TT("Assault Autocannon"),
					Localization.TT("Laser Minicannon"),
					Localization.TT("Breacher Cannon")};
				if (!string.IsNullOrEmpty(itemSpacing)) listedItems.Add(itemSpacing);
				return listedItems;
				default: return new List<string>();
			}
		}
		public static void AddSkillPointsWithinLimits(Crewmember crewmember) {
			int maxSkillPoints = 0;
			if (crewmember.skills.bridge > 0) maxSkillPoints += 10 - crewmember.skills.bridge;
			if (crewmember.skills.gunnery > 0) maxSkillPoints += 10 - crewmember.skills.gunnery;
			if (crewmember.skills.handWeapon > 0) maxSkillPoints += 10 - crewmember.skills.handWeapon;
			if (crewmember.skills.repair > 0) maxSkillPoints += 10 - crewmember.skills.repair;
			if (crewmember.skills.gardening > 0) maxSkillPoints += 10 - crewmember.skills.gardening;
			if (crewmember.skills.sensor > 0) maxSkillPoints += 10 - crewmember.skills.sensor;
			if (crewmember.skills.shield > 0) maxSkillPoints += 10 - crewmember.skills.shield;
			if (crewmember.skills.firefight > 0) maxSkillPoints += 10 - crewmember.skills.firefight;
			if (crewmember.skills.science > 0) maxSkillPoints += 10 - crewmember.skills.science;
			if (crewmember.skills.warp > 0) maxSkillPoints += 10 - crewmember.skills.warp;
			if (FFU_BE_Defs.addFreeCrewSkillPoints > maxSkillPoints) crewmember.unusedSkillPoints = maxSkillPoints;
			else crewmember.unusedSkillPoints = FFU_BE_Defs.addFreeCrewSkillPoints;
		}
		public static void ForceCrewMinSkillLevels(Crewmember crewmember, int minLevel) {
			if (crewmember.skills.bridge > 0) if (crewmember.skills.bridge < minLevel) crewmember.skills.bridge = minLevel;
			if (crewmember.skills.gunnery > 0) if (crewmember.skills.gunnery < minLevel) crewmember.skills.gunnery = minLevel;
			if (crewmember.skills.handWeapon > 0) if (crewmember.skills.handWeapon < minLevel) crewmember.skills.handWeapon = minLevel;
			if (crewmember.skills.repair > 0) if (crewmember.skills.repair < minLevel) crewmember.skills.repair = minLevel;
			if (crewmember.skills.gardening > 0) if (crewmember.skills.gardening < minLevel) crewmember.skills.gardening = minLevel;
			if (crewmember.skills.sensor > 0) if (crewmember.skills.sensor < minLevel) crewmember.skills.sensor = minLevel;
			if (crewmember.skills.shield > 0) if (crewmember.skills.shield < minLevel) crewmember.skills.shield = minLevel;
			if (crewmember.skills.firefight > 0) if (crewmember.skills.firefight < minLevel) crewmember.skills.firefight = minLevel;
			if (crewmember.skills.science > 0) if (crewmember.skills.science < minLevel) crewmember.skills.science = minLevel;
			if (crewmember.skills.warp > 0) if (crewmember.skills.warp < minLevel) crewmember.skills.warp = minLevel;
		}
		public static void SetCrewRelativeSkillLevels(Crewmember crewmember, int minLevel, int currSector) {
			if (crewmember.skills.bridge > 0) crewmember.skills.bridge = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.gunnery > 0) crewmember.skills.gunnery = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.handWeapon > 0) crewmember.skills.handWeapon = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.repair > 0) crewmember.skills.repair = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.gardening > 0) crewmember.skills.gardening = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.sensor > 0) crewmember.skills.sensor = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.shield > 0) crewmember.skills.shield = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.firefight > 0) crewmember.skills.firefight = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.science > 0) crewmember.skills.science = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
			if (crewmember.skills.warp > 0) crewmember.skills.warp = Mathf.Clamp(UnityEngine.Random.Range(Mathf.Max(currSector - 2, minLevel), Mathf.Max(currSector + 3, minLevel)), 1, 10);
		}
		public static bool CrewLacksHealth(Crewmember crewmember) {
			Crewmember crewPrefab = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == crewmember.PrefabId);
			switch (crewPrefab.name) {
				case "Cat1":
				case "Drone pet":
				case "Slime pet":
				case "Larva small":
				case "Drone fire safety":
				case "Drone DIY fire safety clawed":
				return crewmember.MaxHealth < 10;
				case "Rat crew":
				case "Rat crew cook":
				case "Human crew":
				case "Human crew adventurer":
				case "Pirates humanoid crew":
				case "Larva big":
				return crewmember.MaxHealth < 15;
				case "GorMor crew":
				case "Grippy crew":
				case "Gitchanki crew":
				case "Testcrew 1":
				case "Testcrew 2":
				case "Testcrew 3":
				case "Testcrew 4":
				case "Drone CT1 maintenance":
				case "Drone CT2 gunnery clawed":
				case "Drone CT2 gunnery":
				case "Drone DIY firesafety pirates":
				case "Drone DIY firesafety":
				case "Drone DIY guard pirates":
				case "Drone DIY guard":
				case "Drone DIY gunnery":
				case "Drone DIY repairer pirates":
				case "Drone DIY repairer":
				case "Drone DIY science":
				case "Drone DIY sensor":
				return crewmember.MaxHealth < 20;
				case "Mantis crew":
				case "Slavers crew":
				case "Lizardman crew":
				case "Insectoid crew":
				case "Insectoidian crew":
				case "Drone DIY mincer pirates":
				case "Drone CT1 maintenance clawed":
				case "Drone DIY gunnery pirates cannon":
				return crewmember.MaxHealth < 25;
				case "Moleculaati":
				case "Squid crew":
				case "Yu-Ee crew":
				case "EmperorBanks crew":
				return crewmember.MaxHealth < 30;
				case "Spideraa crew":
				case "Beedroid crew":
				case "Combat Drone Humanoid":
				return crewmember.MaxHealth < 35;
				case "Drone tigerspider pirates":
				case "Drone tigerspider":
				return crewmember.MaxHealth < 50;
				case "Heavy security drone":
				return crewmember.MaxHealth < 75;
				case "Redripper crew":
				return crewmember.MaxHealth < 100;
				case "Drone DIY gunjunker":
				case "Drone DIY gunjunker enemy":
				return crewmember.MaxHealth < 125;
				default: return false;
			}
		}
		public static int GetCrewBaseHealth(Crewmember crewmember) {
			Crewmember crewPrefab = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == crewmember.PrefabId);
			switch (crewPrefab.name) {
				case "Cat1":
				case "Drone pet":
				case "Slime pet":
				case "Larva small":
				case "Drone fire safety":
				case "Drone DIY fire safety clawed":
				return 10;
				case "Rat crew":
				case "Rat crew cook":
				case "Human crew":
				case "Human crew adventurer":
				case "Pirates humanoid crew":
				case "Larva big":
				return 15;
				case "GorMor crew":
				case "Grippy crew":
				case "Gitchanki crew":
				case "Testcrew 1":
				case "Testcrew 2":
				case "Testcrew 3":
				case "Testcrew 4":
				case "Drone CT1 maintenance":
				case "Drone CT2 gunnery clawed":
				case "Drone CT2 gunnery":
				case "Drone DIY firesafety pirates":
				case "Drone DIY firesafety":
				case "Drone DIY guard pirates":
				case "Drone DIY guard":
				case "Drone DIY gunnery":
				case "Drone DIY repairer pirates":
				case "Drone DIY repairer":
				case "Drone DIY science":
				case "Drone DIY sensor":
				return 20;
				case "Mantis crew":
				case "Slavers crew":
				case "Lizardman crew":
				case "Insectoid crew":
				case "Insectoidian crew":
				case "Drone DIY mincer pirates":
				case "Drone CT1 maintenance clawed":
				case "Drone DIY gunnery pirates cannon":
				return 25;
				case "Moleculaati":
				case "Squid crew":
				case "Yu-Ee crew":
				case "EmperorBanks crew":
				return 30;
				case "Spideraa crew":
				case "Beedroid crew":
				case "Combat Drone Humanoid":
				return 35;
				case "Drone tigerspider pirates":
				case "Drone tigerspider":
				return 50;
				case "Heavy security drone":
				return 75;
				case "Redripper crew":
				return 100;
				case "Drone DIY gunjunker":
				case "Drone DIY gunjunker enemy":
				return 125;
				default: return 0;
			}
		}
		public static void ApplyCrewChanges(Crewmember crewmember) {
			Crewmember crewPrefab = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == crewmember.PrefabId);
			ModifyCrewmemberProperties(crewPrefab, crewmember);
		}
		public static void ApplyCacheToCrewInRange(ShipModule shipModule) {
			int healthBoost = 5 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f);
			int healthLimit = 25 + (int)FFU_BE_Mod_Technology.GetModuleTier(shipModule) * 20;
			int availableSets = 3 + (int)Math.Round((float)FFU_BE_Mod_Technology.GetModuleTier(shipModule) / 2 - 0.001f);
			ShipModule refSource = PerFrameCache.CachedModules.Find(x => x.type == ShipModule.Type.Engine && x.Ownership.GetOwner() == Ownership.Owner.Me);
			HandWeapon refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == "Hand melee basic fists");
			ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId);
			string moodMessage = GetMoodTextFromWeapon(refWeapon.name);
			StringBuilder cacheUsedMessage = null;
			List<string> availableWeapons = new List<string>();
			foreach (Crewmember cachedCrewmember in PerFrameCache.CachedCrewmembers.Where(x => x.Ownership.GetOwner() == Ownership.Owner.Me && Vector2.Distance(refSource.transform.position, x.transform.position) <= FFU_BE_Defs.equipmentChangeDist)) {
				if (refSource != null && refModule != null & availableSets > 0) {
					switch (refModule.name) {
						case "artifactmodule tec 33 biostasis nice worm":
						if (cachedCrewmember.type == Crewmember.Type.Drone) {
							cacheUsedMessage = RstShared.StringBuilder;
							if (cachedCrewmember.MaxHealth <= healthLimit + GetCrewBaseHealth(cachedCrewmember)) {
								cachedCrewmember.MaxHealth += healthBoost + GetCrewBaseHealth(cachedCrewmember) / 10;
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} was upgraded with new mechanical upgrades and now has {1} health in total!"), cachedCrewmember.DisplayNameLocalized, cachedCrewmember.MaxHealth);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							}
						} break;
						case "artifactmodule tec 11 biostasis":
						if (cachedCrewmember.type == Crewmember.Type.Regular || cachedCrewmember.type == Crewmember.Type.Pet) {
							cacheUsedMessage = RstShared.StringBuilder;
							if (cachedCrewmember.MaxHealth <= healthLimit + GetCrewBaseHealth(cachedCrewmember)) {
								cachedCrewmember.MaxHealth += healthBoost + GetCrewBaseHealth(cachedCrewmember) / 10;
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} was enhanced with new biological implants and now has {1} health in total!"), cachedCrewmember.DisplayNameLocalized, cachedCrewmember.MaxHealth);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							}
						} break;
						case "artifactmodule tec 17 broken screen gizmo, data":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(1745395900);
							EQUIP_CQC:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_CQC;
						} break;
						case "artifactmodule tec 25 broken screen gizmo":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(179311957);
							EQUIP_KINETIC:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_KINETIC;
						} break;
						case "artifactmodule tec 32 broken container gizmo":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(760711671);
							EQUIP_LASERS:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_LASERS;
						} break;
						case "artifactmodule tec 37 ripped quarter of a dome":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(656277331);
							EQUIP_ENERGY:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_ENERGY;
						} break;
						case "artifactmodule tec 36 broken gizmo":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(760711667);
							EQUIP_BACKUP:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_BACKUP;
						} break;
						case "artifactmodule tec 34 data core grammofon":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(1279608160);
							EQUIP_TACTICAL:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_TACTICAL;
						} break;
						case "artifactmodule tec 35 data core makk":
						if (cachedCrewmember.HandWeaponPrefab != null && !FFU_BE_Defs.builtInWeaponTypes.Contains(cachedCrewmember.HandWeaponPrefab.name)) {
							availableWeapons = GetWeaponNameIDsFromCacheID(1316302015);
							EQUIP_ASSAULT:
							cacheUsedMessage = RstShared.StringBuilder;
							refWeapon = FFU_BE_Defs.prefabModdedFirearmsList.Find(x => x.name == Core.RandomItemFromList(availableWeapons));
							if (refWeapon != null) {
								CrewmemberSetWeapon(cachedCrewmember, refWeapon);
								moodMessage = GetMoodTextFromWeapon(refWeapon.name);
								cacheUsedMessage.AppendFormat(MonoBehaviourExtended.TT("{0} has equipped {1}{2}"), cachedCrewmember.DisplayNameLocalized, refWeapon.DisplayNameLocalized, moodMessage);
								StarmapLogPanelUI.AddLine(StarmapLogPanelUI.MsgType.Normal, cacheUsedMessage.ToString());
								availableSets--;
							} else goto EQUIP_ASSAULT;
						} break;
					}
				}
			}
		}
		public static void CrewmemberSetWeapon(Crewmember setCrewmember, HandWeapon setWeapon) {
			if (setWeapon != null & setCrewmember != null) {
				setCrewmember.HandWeaponPrefab = setWeapon;
				if (PlayerDatas.Me.crewRecords.ContainsKey(setCrewmember.InstanceId)) PlayerDatas.Me.crewRecords[setCrewmember.InstanceId].HandWeaponPrefab = setWeapon;
				if (FFU_BE_Defs.equippedCrewFirearms.ContainsKey(setCrewmember.InstanceId)) FFU_BE_Defs.equippedCrewFirearms[setCrewmember.InstanceId] = setWeapon.PrefabId;
				else FFU_BE_Defs.equippedCrewFirearms.Add(new KeyValuePair<int, int>(setCrewmember.InstanceId, setWeapon.PrefabId));
			}
		}
		public static void ModifyCrewmemberProperties(Crewmember refCrew, Crewmember targetCrew) {
			switch (refCrew.name) {
				case "Larva small":
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 0.7f;
				break;
				case "Dog":
				if (targetCrew.skills.shield < 1) targetCrew.skills.shield = 1;
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Cat1":
				if (targetCrew.skills.warp < 1) targetCrew.skills.warp = 1;
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Rabbit":
				if (targetCrew.skills.gardening < 1) targetCrew.skills.gardening = 1;
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Drone pet":
				if (targetCrew.skills.repair < 1) targetCrew.skills.repair = 1;
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Slime pet":
				if (targetCrew.skills.science < 1) targetCrew.skills.science = 1;
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 6);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Drone fire safety":
				case "Drone DIY fire safety clawed":
				targetCrew.MaxHealth = 10 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 1.00f;
				targetCrew.moveSpeed = 1.7f;
				break;
				case "Larva big":
				targetCrew.MaxHealth = 15 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 0.7f;
				break;
				case "Lizard":
				if (targetCrew.skills.sensor < 1) targetCrew.skills.sensor = 1;
				targetCrew.MaxHealth = 15 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Floater":
				if (targetCrew.skills.gunnery < 1) targetCrew.skills.gunnery = 1;
				targetCrew.MaxHealth = 15 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "Rat crew":
				case "Rat crew cook":
				case "Human crew":
				case "Human crew adventurer":
				case "Pirates humanoid crew":
				targetCrew.MaxHealth = 15 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.05f;
				targetCrew.moveSpeed = 1.0f;
				break;
				case "GorMor crew":
				case "Grippy crew":
				case "Gitchanki crew":
				case "Human sunglasses crew":
				targetCrew.MaxHealth = 20 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.25f;
				targetCrew.moveSpeed = 1.1f;
				break;
				case "Testcrew 1":
				case "Testcrew 2":
				case "Testcrew 3":
				case "Testcrew 4":
				case "Testcrew 5":
				case "Drone CT1 maintenance":
				case "Drone CT2 gunnery clawed":
				case "Drone CT2 gunnery":
				case "Drone DIY firesafety pirates":
				case "Drone DIY firesafety":
				case "Drone DIY guard pirates":
				case "Drone DIY guard":
				case "Drone DIY gunnery":
				case "Drone DIY repairer pirates":
				case "Drone DIY repairer":
				case "Drone DIY science":
				case "Drone DIY sensor":
				targetCrew.MaxHealth = 20 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.65f;
				targetCrew.moveSpeed = 0.9f;
				break;
				case "Mantis crew":
				case "Slavers crew":
				case "Lizardman crew":
				case "Insectoid crew":
				case "Insectoidian crew":
				targetCrew.MaxHealth = 25 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.35f;
				targetCrew.moveSpeed = 1.3f;
				break;
				case "Drone DIY mincer pirates":
				case "Drone CT1 maintenance clawed":
				case "Drone DIY gunnery pirates cannon":
				targetCrew.MaxHealth = 25 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.75f;
				targetCrew.moveSpeed = 1.1f;
				break;
				case "Man cat crew":
				case "Woman cat crew":
				targetCrew.MaxHealth = 25 + UnityEngine.Random.Range(0, 11);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.25f;
				targetCrew.moveSpeed = 1.8f;
				break;
				case "Moleculaati":
				case "Squid crew":
				case "Yu-Ee crew":
				case "EmperorBanks crew":
				targetCrew.MaxHealth = 30 + UnityEngine.Random.Range(0, 16);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.0f;
				targetCrew.fireResistance = 0.35f;
				targetCrew.moveSpeed = 1.2f;
				break;
				case "Tortoise":
				if (targetCrew.skills.bridge < 1) targetCrew.skills.bridge = 1;
				targetCrew.MaxHealth = 35 + UnityEngine.Random.Range(0, 16);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 0.75f;
				targetCrew.moveSpeed = 0.8f;
				break;
				case "Spideraa crew":
				case "Beedroid crew":
				case "Male cyborg crew":
				case "Female cyborg crew":
				targetCrew.MaxHealth = 35 + UnityEngine.Random.Range(0, 16);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.0f;
				targetCrew.fireResistance = 0.50f;
				targetCrew.moveSpeed = 1.3f;
				break;
				case "Drone tigerdog":
				case "Drone tigerspider":
				case "Drone tigerspider pirates":
				case "Drone tigerspider assaulter":
				targetCrew.MaxHealth = 50 + UnityEngine.Random.Range(0, 26);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.5f;
				targetCrew.fireResistance = 1.00f;
				targetCrew.moveSpeed = 1.9f;
				break;
				case "Heavy security drone":
				targetCrew.MaxHealth = 75 + UnityEngine.Random.Range(0, 36);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.5f;
				targetCrew.fireResistance = 1.00f;
				targetCrew.moveSpeed = 2.2f;
				break;
				case "Redripper crew":
				targetCrew.description = "A genetically engineered combat animal. Eats as much as a squad of humans. Claws contain fire-extinguisher implants. Loves to care for flowers and other plants.";
				if (targetCrew.skills.gardening < 1) targetCrew.skills.gardening = 1;
				targetCrew.MaxHealth = 100 + UnityEngine.Random.Range(0, 51);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.5f;
				targetCrew.fireResistance = 0.80f;
				targetCrew.moveSpeed = 2.8f;
				break;
				case "Drone DIY gunjunker":
				case "Drone DIY gunjunker enemy":
				targetCrew.MaxHealth = 125 + UnityEngine.Random.Range(0, 101);
				targetCrew.HomingMovement.turnSpeed = 2.0f;
				targetCrew.HomingMovement.force = 2.5f;
				targetCrew.fireResistance = 1.00f;
				targetCrew.moveSpeed = 0.8f;
				break;
				case "Combat Drone Humanoid":
				targetCrew.description = "Light tactical droid. Very versatile and capable of performing same operations as any normal crewmember. Fire-resistant body.";
				if (targetCrew.skills.bridge < 1) targetCrew.skills.bridge = 1;
				if (targetCrew.skills.gunnery < 1) targetCrew.skills.gunnery = 1;
				if (targetCrew.skills.handWeapon < 1) targetCrew.skills.handWeapon = 1;
				if (targetCrew.skills.repair < 1) targetCrew.skills.repair = 1;
				if (targetCrew.skills.gardening < 1) targetCrew.skills.gardening = 1;
				if (targetCrew.skills.sensor < 1) targetCrew.skills.sensor = 1;
				if (targetCrew.skills.shield < 1) targetCrew.skills.shield = 1;
				if (targetCrew.skills.firefight < 1) targetCrew.skills.firefight = 1;
				if (targetCrew.skills.science < 1) targetCrew.skills.science = 1;
				if (targetCrew.skills.warp < 1) targetCrew.skills.warp = 1;
				targetCrew.MaxHealth = 35 + UnityEngine.Random.Range(0, 16);
				targetCrew.HomingMovement.turnSpeed = 2.5f;
				targetCrew.HomingMovement.force = 3.5f;
				targetCrew.fireResistance = 1.00f;
				targetCrew.moveSpeed = 1.6f;
				break;
				default: break;
			}
		}
		public static void InitFirearmsList() {
			foreach (HandWeapon handWeapon in Resources.FindObjectsOfTypeAll<HandWeapon>()) {
				switch (handWeapon.name) {
					case "Hand melee insectbite":
					handWeapon.displayName = "Acid Claws";
					handWeapon.description = "Claws covered by sticky acidic substance that causes chemical burns on contact.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.2f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.3f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand melee red claw":
					handWeapon.displayName = "Corrosive Claws";
					handWeapon.description = "Claws covered by very corrosive substance that dissolves pretty much anything on contact.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.3f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.3f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand melee basic fists":
					handWeapon.displayName = "Fists";
					handWeapon.description = "Default solution to all disagreements when guns are not allowed.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.2f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand melee enhanced fists":
					handWeapon.displayName = "Augmented Fists";
					handWeapon.description = "Owner of these fists can easily break sound barrier just by punching air.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.2f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.2f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand melee blue crystals":
					handWeapon.displayName = "Crustal Tusks";
					handWeapon.description = "Made out of unrefined nephrite, which is stronger then diamond. Effectively breaks metal and flesh alike.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 9;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.4f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.4f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand melee teeth":
					handWeapon.displayName = "Teeth";
					handWeapon.description = "Sharp teeth. Mostly used by animals that can't hold autocannon during argument.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.1f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand weapon acid gland spray":
					handWeapon.displayName = "Acid Glands";
					handWeapon.description = "Glands that secrete acidic substances that good at chemically burning almost any material.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 0.5f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 3;
					handWeapon.accuracy = 14;
					break;
					case "Hand weapon acid gland spray red":
					handWeapon.displayName = "Corrosive Glands";
					handWeapon.description = "Glands that secrete extremely corrosive substances that good at dissolving living flesh and sturdy metals alike.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.7f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 0.5f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 3;
					handWeapon.accuracy = 14;
					break;
					case "Hand weapon warp moleculoray":
					handWeapon.displayName = "Positron Glands";
					handWeapon.description = "Glands that allow living creature to emit directed positron stream that causes severe damage to any material.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 1.0f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 2;
					handWeapon.accuracy = 22;
					break;
					case "Hand weapon warp spider":
					handWeapon.displayName = "Warp Glands";
					handWeapon.description = "Glands that allow living creature to direct destructive warp energies that break and rend everything apart.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 1.0f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 2;
					handWeapon.accuracy = 22;
					break;
					case "Hand weapon electric":
					handWeapon.displayName = "Lightning Glands";
					handWeapon.description = "Glands that allow living creature emit directed lightning impulse that throughly electrifies targets.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.2f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 0.6f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 22;
					break;
					case "Hand weapon flames":
					handWeapon.displayName = "Dragon Breath Glands";
					handWeapon.description = "Glands that allow living creature to breath fire as if it is a dragon from random (or famous) fantasy novel.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 1.2f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 2;
					handWeapon.accuracy = 22;
					break;
					case "Hand weapon pink ray":
					handWeapon.displayName = "Neutrino Glands";
					handWeapon.description = "Glands that allow living creature to emit focused stream of extremely deadly neutrino particles in desired direction.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.3f;
					handWeapon.farthestAttackDistance = 6.0f;
					handWeapon.reloadInterval = 0.6f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 22;
					break;
					case "Hand melee mincer":
					handWeapon.displayName = "Metal Claws";
					handWeapon.description = "Made from refined tungsten. Can perfectly cut starship alloy and dense alien carapace full without losing edge.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 0.2f;
					handWeapon.reloadInterval = 0.3f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 0;
					break;
					case "Hand weapon drone liquid nitrogen spray":
					handWeapon.displayName = "Nitrogen Spray";
					handWeapon.description = "Made and mostly used to extinguish fires, but also can be used to turn somebody into frozen work of art with consequences.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.2f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 0.8f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 2;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon drone flamer":
					handWeapon.displayName = "Flamethrower";
					handWeapon.description = "Once it was called nitrogen spray. Until somebody was bored enough to replace it with extremely flammable napalm compound.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.3f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 0.8f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 2;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon welder light":
					handWeapon.displayName = "Light Welder";
					handWeapon.description = "Used weld mechanical components and light alloys. Also can be used to weld somebody into hard surface for good.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.6f;
					handWeapon.farthestAttackDistance = 4.0f;
					handWeapon.reloadInterval = 1.0f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 36;
					break;
					case "Hand weapon welder heavy":
					handWeapon.displayName = "Heavy Welder";
					handWeapon.description = "Heavy industrial welder that allows heavy duty welding activities, such as welding starship alloys and intruders alike.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 12;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 4.0f;
					handWeapon.reloadInterval = 1.0f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 36;
					break;
					case "Hand weapon blunderpistol":
					handWeapon.displayName = "Light Blunderbuss";
					handWeapon.description = "Failed attempt by a certain empire to develop compact assault shotgun. Although awful, still hurts if hit.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 10.0f;
					handWeapon.reloadInterval = 1.2f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 4;
					handWeapon.accuracy = 6;
					break;
					case "Hand weapon blunderrifle":
					handWeapon.displayName = "Heavy Blunderbuss";
					handWeapon.description = "Failed attempt by a certain empire to develop heavy assault shotgun. Although awful, still hurts a lot if hit.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 10.0f;
					handWeapon.reloadInterval = 1.8f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 8;
					handWeapon.accuracy = 6;
					break;
					case "Hand weapon diy pistol":
					handWeapon.displayName = "Makeshift Pistol";
					handWeapon.description = "Light firearm made from scrap. Mostly used to scare wild animals off and lacks impact for a serious gunfight.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 10.0f;
					handWeapon.reloadInterval = 3.2f;
					handWeapon.shotInterval = 0.6f;
					handWeapon.magazineSize = 10;
					handWeapon.accuracy = 12;
					break;
					case "Hand weapon diy crossbow":
					handWeapon.displayName = "Crossbow";
					handWeapon.description = "Cheap in production and maintenance with decent impact. Good alternative as weapon, when there is nothing else to use.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 18.0f;
					handWeapon.reloadInterval = 0.8f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon tazerfists":
					handWeapon.displayName = "Power Fists";
					handWeapon.description = "Allows to throw lightning at offenders, literally, but lacks range to perform at tactical scale. Good weapon for CQC.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 0.6f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 36;
					break;
					case "Hand weapon welder double":
					handWeapon.displayName = "Dual Welder";
					handWeapon.description = "Portable dual welder that can be used weld anything. Including intruders, bounty hunters and other uninvited personnel.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 3.0f;
					handWeapon.reloadInterval = 0.8f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 1;
					handWeapon.accuracy = 36;
					break;
					case "Hand weapon flamepistol":
					handWeapon.displayName = "Napalm Gun";
					handWeapon.description = "Allows one to become interstellar inquisitor in order to purify all evil of the universe. Also kills intruders with fire.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.4f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 2.5f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 5;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon acidgun":
					handWeapon.displayName = "Toxic Gun";
					handWeapon.description = "Some feel special kind of joy seeing their enemies melt in corrosive liquids ejected under high pressure from this gun.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 2.0f;
					handWeapon.reloadInterval = 3.5f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 5;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon autopistol":
					handWeapon.displayName = "Assault Pistol";
					handWeapon.description = "Decent light firearm weapon designed for effective self defense or covert operations. Completely useless against heavily armored targets.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 15.0f;
					handWeapon.reloadInterval = 2.8f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 12;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon revolver small":
					handWeapon.displayName = "Light Revolver";
					handWeapon.description = "Firearm that uses high caliber rounds. Requires constant maintenance due to heavy wear from using high caliber rounds. Deadly.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.3f;
					handWeapon.farthestAttackDistance = 18.0f;
					handWeapon.reloadInterval = 4.2f;
					handWeapon.shotInterval = 0.7f;
					handWeapon.magazineSize = 6;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon revolver large":
					handWeapon.displayName = "Heavy Revolver";
					handWeapon.description = "An attempt to turn already deadly revolver into hand cannon. Almost successful. 50% deadlier then it's already deadly predecessor.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 18.0f;
					handWeapon.reloadInterval = 4.2f;
					handWeapon.shotInterval = 0.7f;
					handWeapon.magazineSize = 6;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon revolver large acc":
					handWeapon.displayName = "Assault Revolver";
					handWeapon.description = "Deadly heavy revolver with side-mounted advanced targeting system. Better accuracy ensures that package will be delivered to where ordered.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 18.0f;
					handWeapon.reloadInterval = 4.2f;
					handWeapon.shotInterval = 0.7f;
					handWeapon.magazineSize = 6;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon uzi":
					handWeapon.displayName = "Assault SMG";
					handWeapon.description = "Questionable accuracy, but sheer size of ammo clip grants that it can be ignored. Perfect for hit and run attacks. Low maintenance and ammo cost.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 16.0f;
					handWeapon.reloadInterval = 3.8f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 24;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon shotgun":
					handWeapon.displayName = "Assault Shotgun";
					handWeapon.description = "A solution for problem that requires you get close and personal. Ensures that no one is left unhappy. Good at breaking flesh and electronics alike.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.1f;
					handWeapon.farthestAttackDistance = 12.0f;
					handWeapon.reloadInterval = 1.2f;
					handWeapon.shotInterval = 0.0f;
					handWeapon.magazineSize = 12;
					handWeapon.accuracy = 12;
					break;
					case "Hand weapon assaultrifle":
					handWeapon.displayName = "Assault Rifle";
					handWeapon.description = "A main argument when civilized, democratic and peaceful people can't find diplomatic solution. Allows you to bring democracy to all corners of the galaxy.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.2f;
					handWeapon.farthestAttackDistance = 24.0f;
					handWeapon.reloadInterval = 4.8f;
					handWeapon.shotInterval = 0.3f;
					handWeapon.magazineSize = 28;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon precisiongatling":
					handWeapon.displayName = "Assault Autocannon";
					handWeapon.description = "An even more effective way to bring peace and democracy to all corners of the galaxy. Pacifies hostilities and enlightens people at 6000 rpm with AP rounds.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.4f;
					handWeapon.farthestAttackDistance = 28.0f;
					handWeapon.reloadInterval = 8.6f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 60;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon handcannon":
					handWeapon.displayName = "Breacher Cannon";
					handWeapon.description = "Mostly used by heavy infantry in power armor when somebody resists democracy and peace. Uses exceptional HEAT rounds to cause extreme damage to targets.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 16;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 36.0f;
					handWeapon.reloadInterval = 6.2f;
					handWeapon.shotInterval = 1.0f;
					handWeapon.magazineSize = 3;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon diyrailgun":
					handWeapon.displayName = "Tactical Railgun";
					handWeapon.description = "Pinnacle of ballistic weapons. Launches kinetic projectiles at Mach-10 speed that followed by immense inversion wave that rips apart everything in its way.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 5;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 10;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 48.0f;
					handWeapon.reloadInterval = 5.4f;
					handWeapon.shotInterval = 0.8f;
					handWeapon.magazineSize = 5;
					handWeapon.accuracy = 48;
					break;
					case "Hand weapon laser pistol":
					handWeapon.displayName = "Laser Pistol";
					handWeapon.description = "Practical application of advanced light focusing technology gave birth to this weapon and all interstellar variants of agents 007 and secret servicemen.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.3f;
					handWeapon.farthestAttackDistance = 24.0f;
					handWeapon.reloadInterval = 2.2f;
					handWeapon.shotInterval = 0.3f;
					handWeapon.magazineSize = 10;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon diylasergun":
					handWeapon.displayName = "Laser Rifle";
					handWeapon.description = "A weapon that made almost all interstellar empire equal, just like Colt & AK-47 in their own time. Now serves as solution to most problem that you can encounter.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 36.0f;
					handWeapon.reloadInterval = 3.6f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 20;
					handWeapon.accuracy = 36;
					break;
					case "Hand weapon laserrifle":
					handWeapon.displayName = "Laser Minicannon";
					handWeapon.description = "Same as assault autocannon, but twice as good and trice as deadly. Still serves greater good by bringing peace and salvation to most civilizations even these days.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 1;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.7f;
					handWeapon.farthestAttackDistance = 48.0f;
					handWeapon.reloadInterval = 6.2f;
					handWeapon.shotInterval = 0.1f;
					handWeapon.magazineSize = 30;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon insect pinkray pistol":
					handWeapon.displayName = "Blaster Pistol";
					handWeapon.description = "Lacks aesthetics, hard to handle and absolutely useless for covert operations, since even single shot will illuminate surroundings better then neon party. But still deadly.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 4;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 2;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.5f;
					handWeapon.farthestAttackDistance = 18.0f;
					handWeapon.reloadInterval = 4.2f;
					handWeapon.shotInterval = 0.4f;
					handWeapon.magazineSize = 8;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon insect pinkray rifle":
					handWeapon.displayName = "Blaster Rifle";
					handWeapon.description = "Looks absolutely weird and makes everybody who uses it look just as weird. Can be used as signal flare in cases of emergency to be seen from low orbit. Has extreme damage output.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 6;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.8f;
					handWeapon.farthestAttackDistance = 24.0f;
					handWeapon.reloadInterval = 7.8f;
					handWeapon.shotInterval = 0.3f;
					handWeapon.magazineSize = 16;
					handWeapon.accuracy = 24;
					break;
					case "Hand weapon warpeffector":
					handWeapon.displayName = "Warp Ray Gun";
					handWeapon.description = "Less of gun, but more of radio to immaterium that allows user to listen annoying whining of some \"Khorne\" dude. Still used these days only because it requires no ammunition.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.7f;
					handWeapon.farthestAttackDistance = 12.0f;
					handWeapon.reloadInterval = 5.4f;
					handWeapon.shotInterval = 0.3f;
					handWeapon.magazineSize = 4;
					handWeapon.accuracy = 18;
					break;
					case "Hand weapon yellow raypistol":
					handWeapon.displayName = "Particle Gun";
					handWeapon.description = "Probably the only energy weapon that doesn't look weird, doesn't make you listen somebody's whining entire day and still emits stream of devastating neutrino particles when needed.";
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg = 8;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg = 0;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg = 3;
					handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance = 0.9f;
					handWeapon.farthestAttackDistance = 16.0f;
					handWeapon.reloadInterval = 7.8f;
					handWeapon.shotInterval = 0.2f;
					handWeapon.magazineSize = 8;
					handWeapon.accuracy = 36;
					break;
					default:
					Debug.LogWarning($"[NEW HAND WEAPON] Identifier: {handWeapon.name}\nPrefab ID:{handWeapon.PrefabId}\n{FFU_BE_Mod_Information.GetSelectedWeaponExactData(handWeapon, false)}");
					break;
				}
				FFU_BE_Defs.prefabModdedFirearmsList.Add(handWeapon);
			}
			if (FFU_BE_Defs.dumpObjectLists) foreach(HandWeapon handWeapon in FFU_BE_Defs.prefabModdedFirearmsList)
				Debug.Log("[" + handWeapon.name + "] (" + handWeapon.PrefabId + ") " + handWeapon.displayName + ": Accuracy: " + handWeapon.accuracy + ", Range: " + handWeapon.farthestAttackDistance +
				", Ammo: " + handWeapon.magazineSize + ", Reload: " + handWeapon.reloadInterval + "s" + ", Interval: " + handWeapon.shotInterval + "s" +
				", Crew Damage: " + handWeapon.damageDealerPrefab.GetDamage(handWeapon).crewDmg +
				", Door Damage: " + handWeapon.damageDealerPrefab.GetDamage(handWeapon).doorDmg +
				", Hull Damage: " + handWeapon.damageDealerPrefab.GetDamage(handWeapon).shipDmg +
				", Module Damage: " + handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmg +
			" (" + string.Format("{0:0}", handWeapon.damageDealerPrefab.GetDamage(handWeapon).moduleDmgChance * 100f) + "%), Description: " + handWeapon.description);
		}
		public static void InitCrewTypesList() {
			foreach (Crewmember crewmember in Resources.FindObjectsOfTypeAll<Crewmember>()) {
				if (FFU_BE_Defs.dumpObjectLists) Debug.Log("Crewmember: [" + crewmember.name + "] (" + crewmember.PrefabId + ") " + crewmember.displayName + " (Speed: " + crewmember.moveSpeed + ")");
				ModifyCrewmemberProperties(crewmember, crewmember);
				FFU_BE_Defs.prefabModdedCrewList.Add(crewmember);
			}
		}
		public static void InitSpacePodsList() {
			SpacePod[] spacePods = Resources.FindObjectsOfTypeAll<SpacePod>();
			foreach (SpacePod spacePod in spacePods) {
				switch (spacePod.name.Replace("(Clone)", string.Empty)) {
					case "Pink space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 20;
					break;
					case "Rat space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 30;
					break;
					case "Large space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 50;
					break;
					case "Pirate space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 30;
					break;
					case "Invisible space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 15;
					break;
					case "Ordinary space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 25;
					break;
					case "Pirate space pod red":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 30;
					break;
					case "Spideraa space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 35;
					break;
					case "Slaver space pod":
					AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth") = 30;
					break;
					default: break;
				}
				AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "health") = AccessTools.FieldRefAccess<SpacePod, int>(spacePod, "maxHealth");
				if (FFU_BE_Defs.dumpObjectLists) Debug.Log("Space Pod: [" + spacePod.name + "] " + spacePod.displayName + ": " + spacePod.MaxHealth + " HP");
				FFU_BE_Defs.prefabModdedSpacePodsList.Add(spacePod);
			}
			spacePods = null;
		}
	}
}

namespace RST {
	public class patch_Crewmember : Crewmember {
		[MonoModIgnore] public SpacePod SpacePodInstance { get; private set; }
		[MonoModReplace] public int GetEffectiveSkill(Skill skill) {
		/// Skill Efficiency Limit
			int effectiveSkill = GetSkill(skill);
			if (effectiveSkill > 0) {
				if (!Hungry) return Mathf.Clamp(effectiveSkill, 1, 10);
				return Mathf.Clamp(effectiveSkill / 3, 1, 10);
			}
			return 0;
		}
		[MonoModReplace] private static void AutoLevelUp(Crewmember c) {
		/// Auto Level Up Skill Overflow Fix
			if (c.unusedSkillPoints > 0) {
				Skill prioritySkill = Skill.None;
				switch (c.role) {
					case Role.FireOfficer: prioritySkill = Skill.FightFire; break;
					case Role.RepairOfficer: prioritySkill = Skill.Repair; break;
					case Role.SecurityOfficer: prioritySkill = Skill.HandWeapon; break;
					case Role.Intruder: prioritySkill = Skill.HandWeapon; break;
					case Role.Bridge: prioritySkill = Skill.Bridge; break;
					case Role.Sensor: prioritySkill = Skill.Sensor; break;
					case Role.Weapon: prioritySkill = Skill.Gunnery; break;
					case Role.PointDefence: prioritySkill = Skill.Gunnery; break;
					case Role.Shield: prioritySkill = Skill.Shield; break;
					case Role.Garden: prioritySkill = Skill.Garden; break;
					case Role.Research: prioritySkill = Skill.Science; break;
					case Role.Warp: prioritySkill = Skill.Warp; break;
					default: prioritySkill = Skill.None; break;
				}
				switch (prioritySkill) {
					case Skill.FightFire:
					if (c.skills.firefight < 10) {
						if (c.unusedSkillPoints + c.skills.firefight > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.firefight);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Repair:
					if (c.skills.repair < 10) {
						if (c.unusedSkillPoints + c.skills.repair > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.repair);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.HandWeapon:
					if (c.skills.handWeapon < 10) {
						if (c.unusedSkillPoints + c.skills.handWeapon > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.handWeapon);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Gunnery:
					if (c.skills.gunnery < 10) {
						if (c.unusedSkillPoints + c.skills.gunnery > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.gunnery);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Bridge:
					if (c.skills.bridge < 10) {
						if (c.unusedSkillPoints + c.skills.bridge > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.bridge);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Sensor:
					if (c.skills.sensor < 10) {
						if (c.unusedSkillPoints + c.skills.sensor > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.sensor);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Shield:
					if (c.skills.shield < 10) {
						if (c.unusedSkillPoints + c.skills.shield > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.shield);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Garden:
					if (c.skills.gardening < 10) {
						if (c.unusedSkillPoints + c.skills.gardening > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.gardening);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Science:
					if (c.skills.science < 10) {
						if (c.unusedSkillPoints + c.skills.science > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.science);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					case Skill.Warp:
					if (c.skills.warp < 10) {
						if (c.unusedSkillPoints + c.skills.warp > 10) c.LevelUpSkill(prioritySkill, 10 - c.skills.warp);
						else c.LevelUpSkill(prioritySkill, c.unusedSkillPoints);
					}
					break;
					default: break;
				}
				while (c.unusedSkillPoints > 0) {
					int minSkillLevel = 10;
					Skill weakestSkill = Skill.None;
					if (c.skills.firefight < 10 && c.skills.firefight < minSkillLevel) { minSkillLevel = c.skills.firefight; weakestSkill = Skill.FightFire; }
					if (c.skills.repair < 10 && c.skills.repair < minSkillLevel) { minSkillLevel = c.skills.repair; weakestSkill = Skill.Repair; }
					if (c.skills.handWeapon < 10 && c.skills.handWeapon < minSkillLevel) { minSkillLevel = c.skills.handWeapon; weakestSkill = Skill.HandWeapon; }
					if (c.skills.gunnery < 10 && c.skills.gunnery < minSkillLevel) { minSkillLevel = c.skills.gunnery; weakestSkill = Skill.Gunnery; }
					if (c.skills.bridge < 10 && c.skills.bridge < minSkillLevel) { minSkillLevel = c.skills.bridge; weakestSkill = Skill.Bridge; }
					if (c.skills.sensor < 10 && c.skills.sensor < minSkillLevel) { minSkillLevel = c.skills.sensor; weakestSkill = Skill.Sensor; }
					if (c.skills.shield < 10 && c.skills.shield < minSkillLevel) { minSkillLevel = c.skills.shield; weakestSkill = Skill.Shield; }
					if (c.skills.gardening < 10 && c.skills.gardening < minSkillLevel) { minSkillLevel = c.skills.gardening; weakestSkill = Skill.Garden; }
					if (c.skills.science < 10 && c.skills.science < minSkillLevel) { minSkillLevel = c.skills.science; weakestSkill = Skill.Science; }
					if (c.skills.warp < 10 && c.skills.warp < minSkillLevel) { minSkillLevel = c.skills.warp; weakestSkill = Skill.Warp; }
					if (weakestSkill != Skill.None) c.LevelUpSkill(weakestSkill, 1);
					if (c.skills.firefight >= 10 && c.skills.repair >= 10 && c.skills.handWeapon >= 10 &&
					c.skills.shield >= 10 && c.skills.gardening >= 10 && c.skills.science >= 10 &&
					c.skills.gunnery >= 10 && c.skills.bridge >= 10 && c.skills.sensor >= 10 &&
					c.skills.warp >= 10) c.unusedSkillPoints = 0;
				}
			}
		}
		public void TakeDamage(ShootAtDamageDealer.Damage dd, Vector2 hitPos) {
		/// Take Crew Damage From Ship Weapons
			float crewHitChance = 0;
			switch (dd.crewDmgLevel) {
				case ShootAtDamageDealer.CrewDmgLevel.High: crewHitChance = (float)Core.CrewHitChance.High; break;
				case ShootAtDamageDealer.CrewDmgLevel.Default: crewHitChance = (float)Core.CrewHitChance.Medium; break;
				case ShootAtDamageDealer.CrewDmgLevel.Low: crewHitChance = (float)Core.CrewHitChance.Low; break;
			}
			if (crewHitChance > 0f && dd.doorDmg > 0 && crewHitChance * 0.01f > RstRandom.value) {
				TakeDamage(dd.doorDmg);
				TriggerHitAnim();
			}
		}
		[MonoModReplace] public void EnterPod() {
		/// Kill Boarding Party when Leaving Ship
			if (name.Contains("ShortLifeSpan")) {
				SpacePodInstance.gameObject.Destroy();
				gameObject.Destroy();
				return;
			}
			SpacePodInstance = UnityEngine.Object.Instantiate(Effects.spacePodPrefab, base.transform.position, base.transform.rotation, base.transform);
			MonoBehaviourExtended.ResetCachedChildComponents(base.transform);
			if (NavAgent != null) NavAgent.enabled = false;
			if (HomingMovement != null) HomingMovement.enabled = true;
			base.transform.SetParent(PlayerDatas.Instance?.transform);
		}
		[MonoModReplace] public bool CanLevelUpSkill(Skill skill, int inc) {
		/// Allow Drones Skill Points Allocation
			if (skill == Skill.Presence || skill == Skill.None || inc <= 0) return false;
			int skill2 = GetSkill(skill);
			if (unusedSkillPoints >= inc) return skill2 + inc <= 10;
			return false;
		}
		public void BuyableAssignToStore(Shop shop) {
		/// Update Crew Parameters Assigned to Shops
			base.gameObject.SetActive(false);
			Ownership.SetOwner(Ownership.Owner.None);
			base.transform.parent = shop.buyableCrewContainer;
			base.transform.position = new Vector3(20000f, 0f, 0f);
			FFU_BE_Mod_Crewmembers.ApplyCrewChanges(this);
			FFU_BE_Mod_Crewmembers.SetCrewRelativeSkillLevels(this, 1, Sector.Instance.number);
			costCreditsInShop = MaxHealth * 100 + 
				skills.bridge * 500 + skills.gunnery * 500 +
				skills.handWeapon * 500 + skills.repair * 500 +
				skills.gardening * 500 + skills.sensor * 500 +
				skills.shield * 500 + skills.firefight * 500 +
				skills.science * 500 + skills.warp * 500;
			Fsm.SendEvent("assign to store");
		}
		[MonoModReplace] public void BuyableAssignToShip(Ship ship, Ship.TaskArea spawnArea, Ship.TaskArea initialMoveToArea) {
		/// Update Crew Parameters Assigned to Ships
			base.gameObject.SetActive(true);
			Ownership.SetOwner(ship.Ownership.GetOwner());
			FFU_BE_Mod_Crewmembers.ApplyCrewChanges(this);
			if (ship.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Mod_Crewmembers.AddSkillPointsWithinLimits(this);
			if (ship.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Mod_Crewmembers.ForceCrewMinSkillLevels(this, FFU_BE_Defs.minPlayerCrewSkillsLimit);
			if (ship.Ownership.GetOwner() != Ownership.Owner.Me && !FFU_BE_Defs.relativeEnemyCrewSkills) FFU_BE_Mod_Crewmembers.ForceCrewMinSkillLevels(this, FFU_BE_Defs.minEnemyCrewSkillsLimit);
			else if (ship.Ownership.GetOwner() != Ownership.Owner.Me && FFU_BE_Defs.relativeEnemyCrewSkills) FFU_BE_Mod_Crewmembers.SetCrewRelativeSkillLevels(this, FFU_BE_Defs.minEnemyCrewSkillsLimit, Sector.Instance.number);
			if (Sector.Instance != null && ship.Ownership.GetOwner() == Ownership.Owner.Enemy) MaxHealth = (int)(MaxHealth * (1 + Sector.Instance.number * FFU_BE_Defs.enemyCrewHealthSectorMult));
			if (spawnArea != 0) {
				base.transform.parent = ship.GetRandomUnoccupiedTaskArea(spawnArea);
				base.transform.localPosition = Vector3.zero;
				base.transform.localScale = Vector3.one;
			}
			if (initialMoveToArea != 0) {
				List<Transform> taskAreas = ship.GetTaskAreas(initialMoveToArea);
				if (taskAreas.Count > 0) MoveTo(taskAreas.RandomElement().position, false);
			} else Idle(false);
		}
	}
	public class patch_AddCrewToShip : AddCrewToShip {
		public bool DoAfterShipSpawn(Ship ship) {
		/// Advanced Starting/Initial Ships Crew Spawn
			if (ship == null || !AddResourcesToShip.CheckIfConditionSatisfied(condition, ship)) return false;
			if (!FFU_BE_Defs.updatedCrews.Contains(ship.InstanceId)) {
				StartGameCustomization.LoadOrInitAddCrewToShipSeed(this);
				RstRandom.InitState(seed);
				for (int i = 0; i < groups.Length; i++) {
					Group group = groups[i];
					Color color = Color.white;
					if (group.matchCrewColor) RandomizeCrewmember.PickMatchedColor(group.Pool, out color);
					int runCycles = ship.Ownership.GetOwner() != Ownership.Owner.Me ? FFU_BE_Defs.enemyShipCrewSizeMult : 1;
					for (int k = 0; k < runCycles; k++) {
						int randomInt = group.count.GetRandomInt();
						for (int j = 0; j < randomInt; j++) {
							Crewmember crewmemberPrefab = GameObjectPool.TakeRandomPrefab<Crewmember>(group.Pool);
							if (!(crewmemberPrefab != null)) continue;
							Crewmember newCrewmember = UnityEngine.Object.Instantiate(crewmemberPrefab, base.transform.position, Quaternion.identity, base.transform);
							newCrewmember.seed = Mathf.Abs(seed + i * 100 + k * 10 + j);
							RandomizeCrewmember randomizeCrewmember = newCrewmember.RandomizeCrewmember;
							if (randomizeCrewmember != null) {
								if (!string.IsNullOrEmpty(group.chooseWithMatchingComment)) randomizeCrewmember.RemoveAppearances((RandomizeCrewmember.Appearance a) => !a.comment.Contains(group.chooseWithMatchingComment));
								((IRandomizer)randomizeCrewmember).Randomize(newCrewmember.seed);
							}
							StartGameCustomization.LoadCrewCustomization(newCrewmember);
							if (group.overrideRole) newCrewmember.role = group.role;
							if (group.matchCrewColor) newCrewmember.SetColor(color);
							newCrewmember.BuyableAssignToShip(ship, group.spawnArea, Ship.TaskArea.None);
						}
						if (FFU_BE_Defs.canSpawnCrew && ship.Ownership.GetOwner() == Ownership.Owner.Me) {
							if (FFU_BE_Defs.startingCrew.ContainsKey(ship.PrefabId)) {
								if (FFU_BE_Defs.startingCrew[ship.PrefabId].Count() > 0) {
									foreach (var crewSpawn in FFU_BE_Defs.startingCrew[ship.PrefabId]) {
										Crewmember crewPrefab = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == crewSpawn.Key);
										if (crewPrefab != null & crewSpawn.Value > 0) {
											for (int n = 0; n < crewSpawn.Value; n++) {
												Crewmember newCrewmember = UnityEngine.Object.Instantiate<Crewmember>(crewPrefab, base.transform.position, Quaternion.identity, base.transform);
												newCrewmember.seed = Mathf.Abs(seed + i * 100 + FFU_BE_Defs.startingCrew[ship.PrefabId].IndexOf(crewSpawn) * 10 + n);
												RandomizeCrewmember randomizeCrewmember = newCrewmember.RandomizeCrewmember;
												if (randomizeCrewmember != null) ((IRandomizer)randomizeCrewmember).Randomize(newCrewmember.seed);
												StartGameCustomization.LoadCrewCustomization(newCrewmember);
												if (group.matchCrewColor) newCrewmember.SetColor(color);
												newCrewmember.BuyableAssignToShip(ship, group.spawnArea, Ship.TaskArea.None);
											}
										}
									}
								}
								FFU_BE_Defs.canSpawnCrew = false;
							}
						}
					}
				}
				FFU_BE_Defs.updatedCrews.Add(ship.InstanceId);
			}
			return true;
		}
	}

}

namespace RST.PlaymakerAction {
	public class patch_StartSector : StartSector {
		[MonoModIgnore] private bool done;
		[MonoModIgnore] private GameObject loadingInstance;
		[MonoModReplace] public override void OnUpdate() {
		/// Drones Receive Skill Points & No Overflow
			if (done) return;
			Sector sector = CreateIfNeeded.Do(levelPrefab.Value.GetComponent<Sector>());
			sector.transform.SetParent(base.Fsm.GameObject.transform);
			sector.Generate(levelSeed.Value);
			PerFrameCache.InvalidateStarCache();
			PerFrameCache.InvalidatePOICache();
			WorldRules worldInstance = WorldRules.Instance;
			PlayerFleet playerFleet = PrefabFinder.Instance.Find<PlayerFleet>("Player ship");
			PlayerFleet altPlayerFleet = null;
			if (playerFleet != null) altPlayerFleet = UnityEngine.Object.Instantiate(playerFleet);
			else Debug.LogError("Player fleet not found, can't instantiate it. Continuing anyway, although the game is unplayable...");
			UnityEngine.Object.Instantiate(worldInstance.sectorStatsPrefab).Reset();
			if (altPlayerFleet != null) {
				GameObject gameObject = GameObject.FindGameObjectWithTag("Entry warpgate");
				if (gameObject != null) altPlayerFleet.CompleteWarp(gameObject.transform.position, gameObject.transform.parent);
				else {
					PlayerFleetAction.Do(PlayerFleetAction.Action.PlaceToLeftmostStarCommand, 60f);
					altPlayerFleet.PanTo(true, true);
				}
			}
			CreateIfNeeded.Do(UISkin.Instance.questUIPrefab);
			PlayerData me = PlayerDatas.Me;
			if (me != null) me.questText = "";
			SwitchView.Do(SwitchView.View.StarmapView);
			RstAnalytics.SendSectorStarted();
			TimePanelControls.ControlsDisabled = false;
			if (RstTime.timeScale <= 0f) RstTime.timeScale = 1f;
			bool crewFlag = false;
			MainQuest questInstance = MainQuest.Instance;
			if (questInstance != null && questInstance.StartingSectorNumber != sector.number && sector.skillPointsPerCrewToGive > 0) {
				foreach (Crewmember cachedCrewmember in PerFrameCache.CachedCrewmembers) {
					if (cachedCrewmember != null &&
						cachedCrewmember.Ownership.GetOwner() == Ownership.Owner.Me &&
							(cachedCrewmember.skills.bridge > 0 ||
							cachedCrewmember.skills.firefight > 0 ||
							cachedCrewmember.skills.gardening > 0 ||
							cachedCrewmember.skills.gunnery > 0 ||
							cachedCrewmember.skills.handWeapon > 0 ||
							cachedCrewmember.skills.repair > 0 ||
							cachedCrewmember.skills.science > 0 ||
							cachedCrewmember.skills.sensor > 0 ||
							cachedCrewmember.skills.shield > 0 ||
							cachedCrewmember.skills.warp > 0)) {
						try { cachedCrewmember.unusedSkillPoints += sector.number; } 
						catch { cachedCrewmember.unusedSkillPoints++; }
						int maxSkillPoints = 0;
						if (cachedCrewmember.skills.bridge > 0) maxSkillPoints += 10 - cachedCrewmember.skills.bridge;
						if (cachedCrewmember.skills.gunnery > 0) maxSkillPoints += 10 - cachedCrewmember.skills.gunnery;
						if (cachedCrewmember.skills.handWeapon > 0) maxSkillPoints += 10 - cachedCrewmember.skills.handWeapon;
						if (cachedCrewmember.skills.repair > 0) maxSkillPoints += 10 - cachedCrewmember.skills.repair;
						if (cachedCrewmember.skills.gardening > 0) maxSkillPoints += 10 - cachedCrewmember.skills.gardening;
						if (cachedCrewmember.skills.sensor > 0) maxSkillPoints += 10 - cachedCrewmember.skills.sensor;
						if (cachedCrewmember.skills.shield > 0) maxSkillPoints += 10 - cachedCrewmember.skills.shield;
						if (cachedCrewmember.skills.firefight > 0) maxSkillPoints += 10 - cachedCrewmember.skills.firefight;
						if (cachedCrewmember.skills.science > 0) maxSkillPoints += 10 - cachedCrewmember.skills.science;
						if (cachedCrewmember.skills.warp > 0) maxSkillPoints += 10 - cachedCrewmember.skills.warp;
						if (cachedCrewmember.unusedSkillPoints > maxSkillPoints) cachedCrewmember.unusedSkillPoints = maxSkillPoints;
						crewFlag = true;
					}
				}
			}
			ComchannelTip channelInstance = ComchannelTip.Instance;
			if (crewFlag && channelInstance != null) channelInstance.NotifyAboutSkillpointsGiven();
			done = true;
			if (loadingInstance != null) UnityEngine.Object.Destroy(loadingInstance);
			Finish();
		}
	}
}