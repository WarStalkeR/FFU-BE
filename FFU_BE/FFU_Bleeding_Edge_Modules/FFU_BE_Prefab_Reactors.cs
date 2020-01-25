using RST;
using HarmonyLib;
using System.Collections.Generic;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Reactors {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "reactor 4 diy 1") return idx; idx++;
			if (moduleName == "reactor 5 diy 2 backup") return idx; idx++;
			if (moduleName == "reactor 6 smalltrapho") return idx; idx++;
			if (moduleName == "reactor 7 diy 3") return idx; idx++;
			if (moduleName == "reactor 8 smallmulty") return idx; idx++;
			if (moduleName == "reactor 9 biotech DIY") return idx; idx++;
			if (moduleName == "reactor 9 small old") return idx; idx++;
			if (moduleName == "reactor 10 small") return idx; idx++;
			if (moduleName == "reactor 11 single biofruit DIY") return idx; idx++;
			if (moduleName == "reactor 12 custom old") return idx; idx++;
			if (moduleName == "reactor 13 single biofruit") return idx; idx++;
			if (moduleName == "reactor 13 rats") return idx; idx++;
			if (moduleName == "reactor 13 classic cooled") return idx; idx++;
			if (moduleName == "reactor 15 medium") return idx; idx++;
			if (moduleName == "reactor 16 explosives eater") return idx; idx++;
			if (moduleName == "reactor 17 emperorbanks") return idx; idx++;
			if (moduleName == "reactor 17 flower") return idx; idx++;
			if (moduleName == "reactor 18 weird alien biotech") return idx; idx++;
			if (moduleName == "reactor 20 biofruit") return idx; idx++;
			if (moduleName == "reactor 22 spideraa small") return idx; idx++;
			if (moduleName == "reactor 20 fusion") return idx; idx++;
			if (moduleName == "reactor 25 spideraa large") return idx; idx++;
			if (moduleName == "reactor 22 cube") return idx; idx++;
			return 999;
		}
		public static List<string> ViableForSector(int sectorNum) {
			List<string> moduleList = new List<string>();
			switch (sectorNum) {
				case 1:
				moduleList.Add("reactor 4 diy 1");
				moduleList.Add("reactor 5 diy 2 backup");
				moduleList.Add("reactor 6 smalltrapho");
				moduleList.Add("reactor 7 diy 3");
				moduleList.Add("reactor 8 smallmulty");
				return moduleList;
				case 2:
				moduleList.Add("reactor 5 diy 2 backup");
				moduleList.Add("reactor 6 smalltrapho");
				moduleList.Add("reactor 7 diy 3");
				moduleList.Add("reactor 8 smallmulty");
				moduleList.Add("reactor 9 biotech DIY");
				return moduleList;
				case 3:
				moduleList.Add("reactor 7 diy 3");
				moduleList.Add("reactor 8 smallmulty");
				moduleList.Add("reactor 9 biotech DIY");
				moduleList.Add("reactor 9 small old");
				moduleList.Add("reactor 10 small");
				return moduleList;
				case 4:
				moduleList.Add("reactor 9 small old");
				moduleList.Add("reactor 10 small");
				moduleList.Add("reactor 11 single biofruit DIY");
				moduleList.Add("reactor 12 custom old");
				moduleList.Add("reactor 13 single biofruit");
				return moduleList;
				case 5:
				moduleList.Add("reactor 12 custom old");
				moduleList.Add("reactor 13 single biofruit");
				moduleList.Add("reactor 13 rats");
				moduleList.Add("reactor 13 classic cooled");
				moduleList.Add("reactor 15 medium");
				return moduleList;
				case 6:
				moduleList.Add("reactor 13 classic cooled");
				moduleList.Add("reactor 15 medium");
				moduleList.Add("reactor 16 explosives eater");
				moduleList.Add("reactor 17 emperorbanks");
				moduleList.Add("reactor 17 flower");
				return moduleList;
				case 7:
				moduleList.Add("reactor 17 emperorbanks");
				moduleList.Add("reactor 17 flower");
				moduleList.Add("reactor 18 weird alien biotech");
				moduleList.Add("reactor 20 biofruit");
				moduleList.Add("reactor 22 spideraa small");
				moduleList.Add("reactor 20 fusion");
				return moduleList;
				case 8:
				moduleList.Add("reactor 22 spideraa small");
				moduleList.Add("reactor 20 fusion");
				moduleList.Add("reactor 25 spideraa large");
				moduleList.Add("reactor 22 cube");
				return moduleList;
				case 9:
				moduleList.Add("reactor 20 fusion");
				moduleList.Add("reactor 25 spideraa large");
				moduleList.Add("reactor 22 cube");
				return moduleList;
				case 10:
				moduleList.Add("reactor 20 fusion");
				moduleList.Add("reactor 25 spideraa large");
				moduleList.Add("reactor 22 cube");
				return moduleList;
				default:
				moduleList.Add("reactor 4 diy 1");
				moduleList.Add("reactor 5 diy 2 backup");
				moduleList.Add("reactor 6 smalltrapho");
				moduleList.Add("reactor 7 diy 3");
				moduleList.Add("reactor 8 smallmulty");
				moduleList.Add("reactor 9 biotech DIY");
				moduleList.Add("reactor 9 small old");
				moduleList.Add("reactor 10 small");
				moduleList.Add("reactor 11 single biofruit DIY");
				moduleList.Add("reactor 12 custom old");
				moduleList.Add("reactor 13 single biofruit");
				moduleList.Add("reactor 13 rats");
				moduleList.Add("reactor 13 classic cooled");
				moduleList.Add("reactor 15 medium");
				moduleList.Add("reactor 16 explosives eater");
				moduleList.Add("reactor 17 emperorbanks");
				moduleList.Add("reactor 17 flower");
				moduleList.Add("reactor 18 weird alien biotech");
				moduleList.Add("reactor 20 biofruit");
				moduleList.Add("reactor 22 spideraa small");
				moduleList.Add("reactor 20 fusion");
				moduleList.Add("reactor 25 spideraa large");
				moduleList.Add("reactor 22 cube");
				return moduleList;
			}
		}
		public static void UpdateReactorModule(ShipModule shipModule) {
			string colorReactor = "ff4d4d";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			switch (Core.GetOriginalName(shipModule.name)) {
				case "reactor 4 diy 1":
				shipModule.displayName = "Light Scrap <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor assembled from tech scraps. Not very stable and may breaks down often, but provides necessary power. Especially when there are no other alternatives.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 25f, metals = 50f, synthetics = 75f, exotics = 1f };
				shipModule.Reactor.overchargePowerCapacityAdd = 4;
				shipModule.Reactor.powerCapacity = 7;
				shipModule.overchargeSeconds = 150;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 6;
				break;
				case "reactor 5 diy 2 backup":
				shipModule.displayName = "Medium Scrap <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor assembled from pre-printed parts. Just as unstable as previous one, but breaks down a little bit less and provides a little bit more power.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 50f, metals = 75f, synthetics = 100f, exotics = 1f };
				shipModule.Reactor.overchargePowerCapacityAdd = 5;
				shipModule.Reactor.powerCapacity = 8;
				shipModule.overchargeSeconds = 150;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 8;
				break;
				case "reactor 6 smalltrapho":
				shipModule.displayName = "Light Fission <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that mainly used on small civilian vessels such as luxurious exploration yachts. Stable, but not durable. Reminds about it every time when overloaded.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 150f, synthetics = 100f, exotics = 1f };
				shipModule.Reactor.overchargePowerCapacityAdd = 5;
				shipModule.Reactor.powerCapacity = 9;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 12;
				break;
				case "reactor 7 diy 3":
				shipModule.displayName = "Heavy Scrap <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor assembled from decent energy core and big pile of tech scraps. Still unstable and still breakdowns, but doesn't require many materials to assemble.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 75f, metals = 100f, synthetics = 125f, exotics = 1f };
				shipModule.Reactor.overchargePowerCapacityAdd = 6;
				shipModule.Reactor.powerCapacity = 10;
				shipModule.overchargeSeconds = 150;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 10;
				break;
				case "reactor 8 smallmulty":
				shipModule.displayName = "Heavy Fission <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that mainly used on medium civilian vessels such as luxurious cruise ships. Stable, but not durable. Reminds about it every time when overloaded.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 125f, metals = 200f, synthetics = 150f, exotics = 2f };
				shipModule.Reactor.overchargePowerCapacityAdd = 7;
				shipModule.Reactor.powerCapacity = 11;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 15;
				break;
				case "reactor 9 biotech DIY":
				shipModule.displayName = "Zapfruit <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Reactor that mainly made from organic compound while using synthesized Zapfruit as its core. Its durability leaves much to be desired.";
				shipModule.craftCost = new ResourceValueGroup { organics = 300f, fuel = 75f, synthetics = 200f, exotics = 2f };
				shipModule.Reactor.overchargePowerCapacityAdd = 4;
				shipModule.Reactor.powerCapacity = 12;
				shipModule.overchargeSeconds = 200;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 14;
				break;
				case "reactor 9 small old":
				shipModule.displayName = "Ancient Fusion <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Was mainstream source of energy centuries ago. Although rather cheap in production and maintenance, quite unstable and randomly breaks down at most unsuitable times.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 300f, synthetics = 200f, exotics = 2f };
				shipModule.Reactor.overchargePowerCapacityAdd = 10;
				shipModule.Reactor.powerCapacity = 13;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 18;
				break;
				case "reactor 10 small":
				shipModule.displayName = "Modern Fusion <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Modern version of fusion reactor which was through multiple revisions and modifications. Although power output didn't increase much, it became very stable, albeit more expensive.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 250f, metals = 400f, synthetics = 300f, exotics = 2f };
				shipModule.Reactor.overchargePowerCapacityAdd = 15;
				shipModule.Reactor.powerCapacity = 14;
				shipModule.overchargeSeconds = 400;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case "reactor 11 single biofruit DIY":
				shipModule.displayName = "Makeshift <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Organic and environment friendly bio-reactor that made from organic spare parts. Stable, rather cheap to produce with proper knowledge, but with lacking durability.";
				shipModule.craftCost = new ResourceValueGroup { organics = 500f, fuel = 150f, synthetics = 300f, exotics = 3f };
				shipModule.Reactor.overchargePowerCapacityAdd = 6;
				shipModule.Reactor.powerCapacity = 15;
				shipModule.overchargeSeconds = 200;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 16;
				break;
				case "reactor 12 custom old":
				shipModule.displayName = "Light Ion <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that utilizes ionized energy streams to generate proper energy output. Favored by civilians and healthcare fanatics. Fragile and lacks stability when overloaded.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 150f, metals = 350f, synthetics = 600f, exotics = 3f };
				shipModule.Reactor.overchargePowerCapacityAdd = 12;
				shipModule.Reactor.powerCapacity = 16;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 22;
				break;
				case "reactor 13 single biofruit":
				shipModule.displayName = "Light <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Organic bio-reactor specially cultivated in cloning laboratories. Has average energy output, but very stable and environment friendly. Lack in durability department.";
				shipModule.craftCost = new ResourceValueGroup { organics = 750f, fuel = 250f, synthetics = 500f, exotics = 3f };
				shipModule.Reactor.overchargePowerCapacityAdd = 7;
				shipModule.Reactor.powerCapacity = 17;
				shipModule.overchargeSeconds = 200;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 18;
				break;
				case "reactor 13 rats":
				shipModule.displayName = "Imperial <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Developed by scientists of the Rat Empire and based on probably stolen ionized energy streams technology. Fragile, but used anyway due to the lack of alternatives.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 450f, synthetics = 750f, exotics = 4f };
				shipModule.Reactor.overchargePowerCapacityAdd = 11;
				shipModule.Reactor.powerCapacity = 18;
				shipModule.overchargeSeconds = 200;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 24;
				break;
				case "reactor 13 classic cooled":
				shipModule.displayName = "Heavy Ion <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that utilizes massive ionized energy streams to generate proper energy output. Favored by civilians and healthcare fanatics. Less fragile than light version.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 600f, synthetics = 850f, exotics = 4f };
				shipModule.Reactor.overchargePowerCapacityAdd = 17;
				shipModule.Reactor.powerCapacity = 20;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 26;
				break;
				case "reactor 15 medium":
				shipModule.displayName = "Cold Fusion <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that uses more stable and efficient fusion reaction to generate power. Loved by military and used in most military vessels for its endurance, durability and stability.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1000f, synthetics = 750f, exotics = 4f };
				shipModule.Reactor.overchargePowerCapacityAdd = 32;
				shipModule.Reactor.powerCapacity = 22;
				shipModule.overchargeSeconds = 400;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 28;
				break;
				case "reactor 16 explosives eater":
				shipModule.displayName = "Ordnance Blast <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that uses excessive amounts of explosives to generate power. Not very cost efficient. Mostly used by mad and eccentric people. Extremely durable, but just as dangerous.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 1500f, synthetics = 1000f, exotics = 4f };
				shipModule.Reactor.overchargePowerCapacityAdd = 28;
				shipModule.Reactor.powerCapacity = 24;
				shipModule.overchargeSeconds = 600;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 45;
				break;
				case "reactor 17 emperorbanks":
				shipModule.displayName = "Commercial <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Developed for sake of profit and sold to anybody who can afford it. If you managed to create such as this one by yourself, you probably breached multiple copyright agreements.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 1250f, synthetics = 1250f, exotics = 6f };
				shipModule.Reactor.overchargePowerCapacityAdd = 29;
				shipModule.Reactor.powerCapacity = 26;
				shipModule.overchargeSeconds = 400;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 30;
				break;
				case "reactor 17 flower":
				shipModule.displayName = "Photovatic <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Reactor that converts solar radiation into proper and usable energy. Organic in nature, but not as environment friendly as you expect. Very stable, but very fragile as well.";
				shipModule.craftCost = new ResourceValueGroup { organics = 1500f, fuel = 500f, synthetics = 1500f, exotics = 6f };
				shipModule.Reactor.overchargePowerCapacityAdd = 18;
				shipModule.Reactor.powerCapacity = 29;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 20;
				break;
				case "reactor 18 weird alien biotech":
				shipModule.displayName = "Resonance <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Weird reactor that uses unknown resonance principles to generate energy. Consequences of using this reactor are unknown. Has good output, but everything else is pretty much average.";
				shipModule.craftCost = new ResourceValueGroup { organics = 1700f, fuel = 500f, synthetics = 1500f, exotics = 15f };
				shipModule.Reactor.overchargePowerCapacityAdd = 20;
				shipModule.Reactor.powerCapacity = 32;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 22;
				break;
				case "reactor 20 biofruit":
				shipModule.displayName = "Heavy <color=#" + colorReactor + "ff>Bio-Reactor</color>";
				shipModule.description = "Heavy version of organic bio-reactor. Just as light version, can only be cultivated in special environment. Durability is still it's weak point, but stability is superb.";
				shipModule.craftCost = new ResourceValueGroup { organics = 2000f, fuel = 1000f, synthetics = 1750f, exotics = 8f };
				shipModule.Reactor.overchargePowerCapacityAdd = 22;
				shipModule.Reactor.powerCapacity = 35;
				shipModule.overchargeSeconds = 300;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 25;
				break;
				case "reactor 22 spideraa small":
				shipModule.displayName = "Light Repulsor <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that uses kinetic energy and unknown principles to generate stable and constant power current. If damaged, contained internal kinetic energy will turn ship's hull into sieve.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, metals = 2500f, synthetics = 1500f, exotics = 10f };
				shipModule.Reactor.overchargePowerCapacityAdd = 44;
				shipModule.Reactor.powerCapacity = 38;
				shipModule.overchargeSeconds = 400;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 35;
				break;
				case "reactor 20 fusion":
				shipModule.displayName = "Quantum <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that generates power from lowest possible energy fluctuations. Complex to produce and maintain, but just as durable and stable when used, with great overload endurance.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 3500f, synthetics = 1750f, exotics = 15f };
				shipModule.Reactor.overchargePowerCapacityAdd = 60;
				shipModule.Reactor.powerCapacity = 42;
				shipModule.overchargeSeconds = 600;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 32;
				break;
				case "reactor 25 spideraa large":
				shipModule.displayName = "Heavy Repulsor <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "Reactor that uses kinetic energy and unknown principles to generate stable and constant power current. Albeit more reinforced then light version, just as dangerous if exposed.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 4500f, synthetics = 2500f, exotics = 20f };
				shipModule.Reactor.overchargePowerCapacityAdd = 66;
				shipModule.Reactor.powerCapacity = 46;
				shipModule.overchargeSeconds = 400;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 45;
				break;
				case "reactor 22 cube":
				shipModule.displayName = "Antimatter <color=#" + colorReactor + "ff>Reactor</color>";
				shipModule.description = "High-performance and high-output reactor that utilizes stabilized antimatter as source of energy. Extremely durable and extremely stable due to immense amounts of fail-safe mechanisms.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1750f, metals = 5500f, synthetics = 3500f, exotics = 25f };
				shipModule.Reactor.overchargePowerCapacityAdd = 75;
				shipModule.Reactor.powerCapacity = 50;
				shipModule.overchargeSeconds = 600;
				shipModule.maxHealthAdd = 0;
				shipModule_maxHealth = 40;
				break;
				default: shipModule.displayName = "(REACTOR) " + shipModule.displayName; break;
			}
			shipModule.overchargePowerNeed = 0;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
