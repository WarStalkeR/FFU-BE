#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0414

using MonoMod;
using RST;
using System;
using System.Collections.Generic;
using UnityEngine;
using FFU_Bleeding_Edge;
using UnityEngine.EventSystems;
using System.Text;
using RST.PlaymakerAction;
using System.Linq;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Mod_Spaceships {
		public static void InitSelectablePerks() {
			string perksData = "\n";
			IDictionary<string, Sprite> storedPerkSprites = new Dictionary<string, Sprite>();
			foreach (Perk perk in Resources.FindObjectsOfTypeAll<Perk>()) {
				Perk.Pool[] temp_ExtraCrew = perk.extraCrew;
				Perk.Pool[] temp_ExtraModules = perk.extraModules;
				switch (perk.name) {
					//Universal Perks
					case "Perk add fuel":
					perk.displayName = "Additional Starfuel Stash";
					perk.description = "Additional stash of starfuel provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.fuel.minValue} {Core.TT("Starfuel")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk add fuel 2, extra canisters":
					perk.displayName = "Emergency Starfuel Backup";
					perk.description = "Emergency starfuel backup that we've prepared a long time ago, but eventually forgot about it. Good that now we've remembered about it.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.fuel.minValue} {Core.TT("Starfuel")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add fuel 3, passing ship":
					perk.displayName = "Alliance Starfuel Supply";
					perk.description = "Starfuel supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue(4500);
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.fuel.minValue} {Core.TT("Starfuel")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add organics 0":
					perk.displayName = "Additional Organics Stash";
					perk.description = "Additional stash of organics provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk add organics 2, increased nutrition":
					perk.displayName = "Sumptuous & Luxurious Feast";
					perk.description = "Feast comparable to Manchu-Han Imperial Feast, made by locals to celebrate start of our great endeavor, whilst getting rid of our annoying presence.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add organics 3, braindead":
					perk.displayName = "Bionic Technology Remnants";
					perk.description = "Generously donated by unknown 3rd party to support our endeavor. They were probably trying to get rid of the evidence after their failed experiments.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(1500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add organics 5, dead animals":
					perk.displayName = "Herd of Exotic Animals";
					perk.description = "We accidentally stumbled on a herd of wild animals and decided to turn them into space rations. During butchering we found out about their exotic nature.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(1500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add organics 1, houseplant":
					perk.displayName = "Nitrocherry Tree Garden";
					perk.description = "Somebody before their death left their will that designated us as inheritors of garden full of nitrocherry trees. We happily accepted and reprocessed them.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(1500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add organics 4, dead insectoids":
					perk.displayName = "Alliance Organics Supply";
					perk.description = "Organics supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(4500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add metals":
					perk.displayName = "Additional Metals Stash";
					perk.description = "Additional stash of metals provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk add metals 2, scrap tank":
					perk.displayName = "Ruined Battle Fortress";
					perk.description = "Our scanning drones accidentally discovered Mobile Battle Fortress, but sadly we didn't have enough time to repair it before takeoff and had to melt it down into hefty stash of alloys.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(7000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 4;
					break;
					case "Perk add synthetics":
					perk.displayName = "Additional Synthetics Stash";
					perk.description = "Additional stash of synthetics provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk add synthetics 2, broken lamp":
					perk.displayName = "Fragmented Solar Furnace";
					perk.description = "Once these were a solar furnace used to supply entire planet with energy and heat, but now this only a fragments of the past glory. We've discovered them accidentally, when we were exploring some ancient ruins.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(1500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(3000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add synthetics and fuel":
					perk.displayName = "Enriched Tritium Rods";
					perk.description = "Found in one of the abandoned power plants that were used centuries ago. Unexpectedly, power plant was completely cleaned up with only these rods left untouched. They probably were too heavy to steal. Or too radioactive.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue(3000);
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(1500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.fuel.minValue} {Core.TT("Starfuel")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add synthetics 3, ex container":
					perk.displayName = "Alliance Synthetics Supply";
					perk.description = "Synthetics supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(4500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add explosives":
					perk.displayName = "Additional Explosives Stash";
					perk.description = "Additional stash of explosives provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk add explosives 2, explo sculpture":
					perk.displayName = "Alliance Explosives Supply";
					perk.description = "Explosives supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(4500);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add exotics":
					perk.displayName = "Exotic Ur-Quanite Crystals";
					perk.description = "Were discovered floating in lower layers of the atmosphere during atmospheric reentry by the crewmember that was nostalgically reminiscing about good old classic games that were released centuries ago.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk barter get exotics for credits":
					perk.displayName = "Exotic Low Quality Ore";
					perk.description = "A months before takeoff we've managed to discover in one the excavated tunnels vein of low quality exotic ore. Sadly, only part of it found buyers. Rest of it had to be reprocessed.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(150);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(10000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk add exotics 2, broken sex toy":
					perk.displayName = "Rare Exotic Contraption";
					perk.description = "Was accidentally discovered by one of the most curious crewmembers at some junkyard. Although we can only assume that this was some sort of a sex toy, we had no use for it and thus reprocessed it into marvelous amount of exotic matter.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(350);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk barter get exotics for explosives":
					perk.displayName = "Exotics-Infused Ammunition";
					perk.description = "Was discovered at one of the abandoned munitions factories. It was probably way too volatile and too unstable to steal as is. We had to spend some time to setup facilities to reprocess it into sumptuous amount of exotic matter.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(350);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add credits":
					perk.displayName = "Anonymous Xenodata Donation";
					perk.description = "Additional amount of credits provided by supporters of our endeavor. Supporters sent it anonymously.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(10000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 1;
					break;
					case "Perk barter get credits for explosives":
					perk.displayName = "Hidden Rebel Supply Stash";
					perk.description = "As it seems we've discovered a hidden supply stash that was intended for the rebels. I'm pretty sure, if we will take it, nobody will be angry. We even will be the good ones who saved the day.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(2000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(25000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 3;
					break;
					case "Perk add credits 2, personal savings":
					perk.displayName = "Hacked Ancient Xenodata Vault";
					perk.description = "At one of the ancient archaeological sites we've discovered an untouched xenodata vault with priceless data. We've managed to bypass its protection due to the usage of centuries old encrypting algorithms in it.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(100000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 5;
					break;
					case "Perk pack, medical resources":
					perk.displayName = "Abandoned Artificer Stash";
					perk.description = "As it seems somebody was in a hurry (or didn't had enough free space in storage) and left these stashes to collect the dust. I think they will be more useful during our endeavor. And nobody needs them anyway.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "compressed exotics pack").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case "Perk pack, organics":
					perk.displayName = "Helpful Military Requisition";
					perk.description = "While we were stationed on this planet, we've made some connections with local representatives of different powers. When military representatives heard about our secret mission, they were more than happy to help us.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "general pack organics, synth, metal").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk pack, 3xsolid starfuel from level7":
					perk.displayName = "Supply Transport Wreckage";
					perk.description = "During planetary surface scan with our printed satellites we've discovered a centuries old spaceship wreckage. Although it was left undiscovered, time is an unbeatable foe and majority of intact supplies ended up being spoiled.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives pack").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+3x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk module DIY medbay":
					perk.displayName = "Advanced Medical Bay Cache";
					perk.description = "Discovered at one of the abandoned and locked down medical facilities during exploration. Contains completely working and packed module, encrypted blueprint and some resources required to operate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay6 biological").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay6 biological").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case "Perk module medbay 202":
					perk.displayName = "Universal Restoration Bay Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of destructive ion storms. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay4 stem celler").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay4 stem celler").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk crew 1 human adventurer":
					perk.displayName = "Experienced Adventurer";
					perk.description = "A trustworthy adventurer offers credits for the opportunity to travel back to Earth with us. They wear an armored helmet and promise to bring along a cool handgun.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(5000);
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Human")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 2;
					break;
					case "Perk crew best marine":
					perk.displayName = "Tactical Marine Graduate";
					perk.description = "A marine with top grades from University of Tactical Land Warfare joins our mission. For the experience. They also carry a full set of live ammunition with them. Just in case.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Human")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 2;
					break;
					case "Perk crew human scientist":
					perk.displayName = "Seasoned Quantum Physicist";
					perk.description = "A scientist joins the mission, to research an obscure topic of time travel, causality manipulation, how it affects the universe and related to the meaning of life. They bring along some exotic supplies.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Human")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 2;
					break;
					case "Perk crew 2 beedroid engineer":
					perk.displayName = "Beedroid Engineer Veteran";
					perk.description = "An alien cyborg joins the mission to repay an old favor. The entire species of Beedroids have transcended their biological bodies. They also bring a full set of tools to perform repairs and modifications.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Beedroid")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk crew rat cook":
					perk.displayName = "Proficient Rat Cook";
					perk.description = "This excellent Rat cook is also skilled in growing food and extinguishing fires. Both mastered during his years in the Rat Cooking University. They also bring along a set of precooked supplies.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Rat")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk crew rat mercs -creds":
					perk.displayName = "Ragtag Rat Mercenaries";
					perk.description = "A band of ragtag mercenary rats join the mission for ability feed themselves. The poor fellas had mediocre skills and do not have any body augments. They also bring along a set of low quality metals to maintain their weapons.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Rat")} {Core.TT("Crewmembers")}",
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 6;
					break;
					case "Perk crew gitchanki sensorist":
					perk.displayName = "Inexperienced Gitchanki Astronomer";
					perk.description = "His regular lovers were a gang of female space marines who taught him everything about wrestling, handguns and ship sensors. They gave him some credits and sent him to adventure to get more life experience.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(5000);
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Gitchanki")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk crew lizard firefighter":
					perk.displayName = "Monk of Infinite Fire Temple";
					perk.description = "This old lizardfolk monk has improved fire resistance and firefighting skills due to years spent in the Temple of Infinite Fire. Likes to stay in the shower for hours. Has hobby of collecting exotic and volatile matter.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Lizardfolk")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk crew grippy gunner":
					perk.displayName = "Weaponry Ex-Specialist Grippy";
					perk.description = "This snake-individual used to serve in a military warship as a gunnery officer. Experienced in using all kinds of ship weapons. Regularly consumes a cocktail of intoxicants, always has hidden stash of explosives. Just in case.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(500);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Grippy")} {Core.TT("Crewmember")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk crew gormor gardener":
					perk.displayName = "Tranquil Gor-Mor Gardener";
					perk.description = "This Gor-Mor individual is a famous gardener-philosopher, praised highly by political leaders and spiritual acolytes who seek enlightenment. He wants to help us in exchange for allowing him to meditate in our greenhouses.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(5000);
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Gor-Mor Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk augment 00a full checkup":
					perk.displayName = "Full Diagnostics & Maintenance";
					perk.description = "Full testing of all ship components, modules and subroutines, and replacement of deprecated and faulty one ensures increased survivability of the ship and crew that uses it.";
					perk.addShipMaxHealth = 50;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk augment 00b evasive manuever dbase update":
					perk.displayName = "Advanced Maneuvering Subroutines";
					perk.description = "Refurbishment and upgrade of built-in maneuvering systems will increase ship's chances to successfully evade incoming hostile fire and break-off from enemy targeting systems.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 5;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipEvasionPercent}°/ₘ {Core.TT("Ship Evasion")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk augment 00c impact dampeners":
					perk.displayName = "Impact Dampening Armor Coating";
					perk.description = "An experimental armor coating that eventually fuses into armor and becomes part of it, while increasing its deflective properties against incoming enemy fire.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 5;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipDeflectPercent}% {Core.TT("Ship Deflection")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk augment 00d tactical predictor":
					perk.displayName = "Tactical Prediction Software";
					perk.description = "Almost universal software that requires no hardware upgrades. Increases accuracy of all on-board and built-in weapon system without any negative drawbacks and consequences.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 5;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipAccuracyPercent}% {Core.TT("Ship Accuracy")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk augment 001a elastic augmentations":
					perk.displayName = "Carbon Fiber Integrity Upgrade";
					perk.description = "Increases ship hull integrity by reinforcing ship's hardpoints and exposed inter-connectors with extremely durable carbon fibers that allow the ship to \"bend\" a little.";
					perk.addShipMaxHealth = 100;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk augment 001b exotic armor":
					perk.displayName = "Composite Exotic-Infused Armor";
					perk.description = "Adds additional layer of composite exotic-infused armor over ship's hull that provides additional durability and increases overall integrity, thus increasing survivability of the ship.";
					perk.addShipMaxHealth = 200;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-2000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-200);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk augment 02 Fortified subsections":
					perk.displayName = "Segmented Armored Subsections";
					perk.description = "Complete rework of ship's interior. Replaces all standard subsection with heavily armored ones that follow strict segmentation standards to prevent uncontrolled decompression in cases of even extreme damage.";
					perk.addShipMaxHealth = 150;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk augment 03 targeting software":
					perk.displayName = "Combat Forensics Processing Units";
					perk.description = "An entire full set of new hardware that is integrated into the core systems of the ship and even partially replaces built-in targeting systems. Allows to analyze on the fly hostile ships behavior and perform necessary targeting corrections.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 5;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipAccuracyPercent}% {Core.TT("Ship Accuracy")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk augment 04 maneuvering jets":
					perk.displayName = "Reinforced Maneuvering Thrusters";
					perk.description = "Replaces ship's original maneuvering thrusters and reaction control systems with more advanced and reinforced ones. Reinforced maneuvering thrusters and reaction control systems has much greater evasion capability due to enhanced durability.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 0;
					perk.addShipEvasionPercent = 5;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipEvasionPercent}°/ₘ {Core.TT("Ship Evasion")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk augment 05 deflection":
					perk.displayName = "Experimental Reflective Composite Armor";
					perk.description = "Completely replaces original ship armor with experimental reflective composite one. Due to its exotic nature, this armor has improved deflective properties that equally effective for deflection of projectiles and reflection of beams.";
					perk.addShipMaxHealth = 0;
					perk.addShipDeflectPercent = 5;
					perk.addShipEvasionPercent = 0;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipDeflectPercent}% {Core.TT("Ship Deflection")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk add permanent credits":
					perk.displayName = "Detailed Spideraa Scientific Data";
					perk.description = "Scientific data about the Spideraa species is worth a lot of credits once we've obtained it. This information is quite dangerous, so we had to invest a lot of time and money into comprehensive background checks before deciding on a buyer.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(125000);
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk fate permanent 01 fortunate coincidence":
					perk.displayName = "A Fortunate Coincidence";
					perk.description = "A fortunate coincidence helps you to prepare better for the upcoming journey.";
					perk.fateBonusInPerkSelection = 1 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case "Perk fate permanent 02 good luck":
					perk.displayName = "The Good Luck";
					perk.description = "Somebody wished you good luck before the journey, and thanks to an unexpected series of events, their wish actually came true.";
					perk.fateBonusInPerkSelection = 2 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 4;
					break;
					case "Perk fate permanent 03 causal chain reaction":
					perk.displayName = "The Causal Chain Reaction";
					perk.description = "Years ago, you helped somebody, changing their lives forever. It started a chain-reaction of events that led to somebody helping you today.";
					perk.fateBonusInPerkSelection = 3 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 6;
					break;
					case "Perk fate permanent 04 generosity and abundance":
					perk.displayName = "The Seeds of Generosity";
					perk.description = "By sowing the seeds of generosity in the past, you have arrived to the harvest of abundance in the present.";
					perk.fateBonusInPerkSelection = 4 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 8;
					break;
					case "Perk fate permanent 05 friend of truth":
					perk.displayName = "The Friend of Truth";
					perk.description = "Awareness of your personal limitations has granted you an even deeper awareness of your freedom.";
					perk.fateBonusInPerkSelection = 5 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk fate permanent 06 focused one":
					perk.displayName = "The Focused One";
					perk.description = "You understand something so deeply that it allows you to understand everything a bit better than individuals usually do.";
					perk.fateBonusInPerkSelection = 6 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 12;
					break;
					case "Perk fate permanent 07 masterful exister":
					perk.displayName = "The Masterful Exister";
					perk.description = "Random coincidences seem to support the fulfillment of your wishes more than what is usually considered normal.";
					perk.fateBonusInPerkSelection = 7 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 14;
					break;
					case "Perk fate permanent 08 the great peace":
					perk.displayName = "The Great Peace";
					perk.description = "You're starting to realize your intimate connection with the Great Peace, remaining calm even in situations of utter distress.";
					perk.fateBonusInPerkSelection = 8 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 16;
					break;
					case "Perk fate permanent 09 optimality":
					perk.displayName = "The Optimality";
					perk.description = "You are in the right place, at the right time and under the right circumstances.";
					perk.fateBonusInPerkSelection = 9 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 18;
					break;
					case "Perk fate permanent 10 victory":
					perk.displayName = "The Taste of Victory";
					perk.description = "Those who know what awaits at the end of the road can enjoy the road itself better. And you are such person.";
					perk.fateBonusInPerkSelection = 10 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk module drone repair bay":
					perk.displayName = "Advanced Drone Bay Cache";
					perk.description = "Discovered at one of the abandoned and locked down maintanance facilities during exploration. Contains completely working and packed module, encrypted blueprint and some resources required to operate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dronebay 1 basic").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dronebay 1 basic").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case "Perk drone 00 smallbot":
					perk.displayName = "Swearing Bot Drone Crew";
					perk.description = "A small toy drone and its useful drone crew. Knows vulgar words in all human languages & draws fire from intruders during internal combat, while all its friends do proper work it is uncapable of.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone pet").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY firesafety").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY repairer").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY science").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY sensor").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Swearing")} {Core.TT("Drone")} {Core.TT("Pet")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Fire Safety")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Repair")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Research")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Sensor")} {Core.TT("Drone")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk drone 01 DIY fire safety":
					perk.displayName = "Basic Combat Drones";
					perk.description = "A set of light walker chassis drones with built-in weaponry and friend/foe identification system to take care of uninvited intruders that decided to come into your ship. Do not expect much from their caterpillar-based AI.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY guard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY guard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY guard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY guard").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk drone 02 DIY guard":
					perk.displayName = "Basic Gunnery Drones";
					perk.description = "A set of light walker chassis drones with improved ship-to-ship targeting and interfacing systems that allow to operate weaponry of your ship. Do not expect much from their scorpion-based AI.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT2 gunnery").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT2 gunnery").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT2 gunnery").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT2 gunnery").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Weapon Operator")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk drone 03 DIY repairbot":
					perk.displayName = "Basic Maintenance Drones";
					perk.description = "A set of light walker chassis drones with improved repairing and firefighting capabilities that allow to maintain ship operational and working. Do not expect much from their beetle-based AI.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT1 maintenance").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT1 maintenance").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT1 maintenance").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone CT1 maintenance").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Maintenance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk drone 04 fire safety x2":
					perk.displayName = "Basic Research Drones";
					perk.description = "A set of light walker chassis drones with improved calculation and analysis capabilities that allow to perform basic research and data analysis. Do not expect much from their octopus-based AI.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY science").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY science").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY science").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY science").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Research")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk drone 05 gardening and repair":
					perk.displayName = "Heavy Maintenance Drones";
					perk.description = "A set of heavy quadruple walker chassis drones with advanced repairing and firefighting capabilities that allow to maintain ship operational and working. In addition, they're absolutely resistant to fire.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk drone 06 DIY gunnery":
					perk.displayName = "Tactical Combat Drones";
					perk.description = "A set of extremely versatile walker chassis drones with state of art tactical AI and software that allows them imitate operational capabilities of the living crew. In addition, they're absolutely resistant to fire.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk drone 07 gunnery and repair":
					perk.displayName = "Heavy Security Drones";
					perk.description = "A set of extremely armored walker chassis drones with state of art combat AI and unholy load of weapons that allows them to eradicated everything in their path. In addition, they're absolutely resistant to fire.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk drone 08 DIY sentry tank":
					perk.displayName = "Armored Assault Drones";
					perk.description = "A set of threaded and extremely armored chassis drones with great combat AI, decent weapons and unholy amount of armor comparable to the bona fide tank. In addition, they're absolutely resistant to fire.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY gunjunker").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY gunjunker").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY gunjunker").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone DIY gunjunker").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Armored Assault")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case "Perk module artifact, nontech":
					perk.displayName = "Huge Assault Weapons Stash";
					perk.description = "Accidental discovery of the underground entrance led us to the bunker that had left some assault weapons stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk module artifact, tech":
					perk.displayName = "Huge Mechanical Upgrades Stash";
					perk.description = "Accidental discovery of the underground entrance led us to the bunker that had left some mechanical upgrades stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk module artifact, worm stasis":
					perk.displayName = "Huge Biological Implants Stash";
					perk.description = "Accidental discovery of the underground entrance led us to the bunker that had left some biological stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case "Perk module artifact, data core":
					perk.displayName = "Industrial Modules Manufacturing Licenses";
					perk.description = "We've found an official dealer that is ready to sell us a complete set of manufacturing licenses for industrial modules, along with their blueprints. However, we still need to research these blueprints, before we can manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = null;
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+{FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").displayName} {Core.TT("Blueprint")}",
						$"+{FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").displayName} {Core.TT("Blueprint")}",
						$"+{FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").displayName} {Core.TT("Blueprint")}",
						$"+{FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module DIY cryosleep":
					perk.displayName = "Medical Cryosleep Bay Cache";
					perk.description = "Discovered at one of the abandoned and locked down cryogenic facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 3x medical").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 3x medical").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case "Perk module DIY cryodream recorder":
					perk.displayName = "Military Cryosleep Bay Cache";
					perk.description = "Discovered at one of the abandoned and locked down cryogenic facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 8x insect").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 8x insect").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case "Perk module lovers cryosleep":
					perk.displayName = "Exploration Cryodream Bay Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of raging radiation emissions. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY garden":
					perk.displayName = "Replicator Greenhouse Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hazardous location full of hostile carnivorous and toxic plants. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 4 greenhouse").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 4 greenhouse").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module minigrowery":
					perk.displayName = "Exogenetic Greenhouse Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hazardous location full of unstable and volatile exotic elements. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 6 synthethics").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 6 synthethics").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY lab":
					perk.displayName = "Quantum Laboratory Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in hazardous experimental facility full of man-made horrors and abominations. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY sensor":
					perk.displayName = "Multi-Phased Sensor Array Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hostile location full of constant firestorms and solar flares. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 9 sunpanel new s2").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 9 sunpanel new s2").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY backup warpdrive":
					perk.displayName = "Quantum Warp Drive Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of destructive temporal fluctuations. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 07 rotor glass").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 07 rotor glass").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY bridge":
					perk.displayName = "Dreadnought Command Bridge Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in ancient ruined dreadnought full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew metalarmor").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew metalarmor").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY random nonweapon":
					perk.displayName = "Heavy Ion Reactors Cache";
					perk.description = "We've managed to receive completely working and packed modules along with reverse engineerable encrypted blueprint as commission from Earth Alliance right before takeoff.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					if (!storedPerkSprites.ContainsKey("Leftover_Module_Sprite")) storedPerkSprites.Add("Leftover_Module_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case "Perk module DIY reactor":
					perk.displayName = "Heavy Bio-Reactors Cache";
					perk.description = "Discovered at one of the abandoned and locked down experimental energy development facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 biofruit").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 biofruit").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 biofruit").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 35;
					break;
					case "Perk module decommissioned DIY reactors x2":
					perk.displayName = "Antimatter Reactors Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hostile location full of constant plasma and meteor storms. The only reason this cache was left intact is extremely protected bunker, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 22 cube").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 22 cube").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 22 cube").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module decommissioned DIY ecms x3":
					perk.displayName = "Quantum ECM Array Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned fortress full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 03 terran").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 03 terran").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY integrity":
					perk.displayName = "Nanometric Integrity Armor Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned spaceship docks full of volatile active nanomachines. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "integrity tiger").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "integrity tiger").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module DIY integrity 2":
					perk.displayName = "Zero Point Shield Capacitor Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned shield technology research center full of destructive dimensional fluctuations. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat tiger").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat tiger").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module integrity 3":
					perk.displayName = "Zero Point Shield Generator Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned shield technology research center full of destructive dimensional fluctuations. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield tigership").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield tigership").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module container MS1":
					perk.displayName = "Phased Stealth Generator Cache";
					perk.description = "We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned fortress full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Stealth decryptor 3 newest human tec").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Stealth decryptor 3 newest human tec").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case "Perk module EOME container":
					perk.displayName = "Capital Storages Manufacturing Cache";
					perk.description = "We've found an official dealer that is ready to sell us a complete working set of storage containers and manufacturing license, along with blueprints. However, we still need to research blueprints, before we can manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 30;
					break;
					case "Perk module DIY point-defence":
					perk.displayName = "Iron Dome Tactical CIWS Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced CIWS, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "2 Tiger PD").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "2 Tiger PD").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "2 Tiger PD").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("CIWS_DIY_Sprite")) storedPerkSprites.Add("CIWS_DIY_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module DIY weapon":
					perk.displayName = "Liberator Kinetic Railcannons Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced railcannons, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Random_Module_Sprite")) storedPerkSprites.Add("Random_Module_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module Rat weapon for exotics":
					perk.displayName = "Shockwave Plasma Howitzers Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced plasma howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Imperial_Crate_Sprite")) storedPerkSprites.Add("Imperial_Crate_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module weapon bank missile x2":
					perk.displayName = "Annihilator Rocket Launchers Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced rocket launchers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module DIY exotic raygun 2":
					perk.displayName = "Hi-Gothic Relic Exotic Ray Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced exotic ray projectors, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon rarelasergothic").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon rarelasergothic").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon rarelasergothic").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector",string.Empty)}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector",string.Empty)} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					//Unused Perks
					case "Perk TESTER PACKAGE":
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = "Disintegrator Exotic Howitzer Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced exotic howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon exoticscannon1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon exoticscannon1").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon exoticscannon1").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk nuke thinspeeder for atlas, unlockable":
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = "Ultra-Effector Beam Emitter Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working set of highly advanced exotic howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Insectoid slowlaser").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Insectoid slowlaser").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Insectoid slowlaser").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk pack, random":
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = "Specialized Capital Missiles Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working pack of kinetic, energy and thermal capital missiles, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Packed")} {perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+3x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+3x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk module DIY shield battery":
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = "Tactical Capital Missiles Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working pack of tactical and boarding capital missiles, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+3x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case "Perk Replace 5x mininglasers with6x, for Gardenship":
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = "Cataclysm Capital Missiles Cache";
					perk.description = "We've found a black market dealer that is ready to sell us a working pack of strategic and chemical capital missiles, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").PrefabId,
						FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+3x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					//Tigerfish Perks
					case "Perk module DIY exotic raygun":
					perk.displayName = "Recovered Exotic Ray Projector";
					perk.description = "Right before takeoff, we've managed to restore to the working condition one of the exotic ray weapons, we've found earlier.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon rarelaserblue2 dual").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector",string.Empty)}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace Industrial lasers with MK2":
					perk.displayName = "Advanced Industrial Mining Upgrade";
					perk.description = "This was last a day purchase that allowed us to replace our original industrial lasers with more advanced versions and smaller XSM storage container with a bigger one.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement { 
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigerlaser MK1").gameObject }, 
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigerlaser MK2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Tigerfish":
					perk.displayName = "Remote Mining Charges Stash";
					perk.description = "A surplus stash of remote mining charges converted into deadly nukes. Was sold at extremely low price at nearest unofficial supplier of industrial machinery.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "06 Tiger nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke DIY random":
					perk.displayName = "Capital Missiles Requisition";
					perk.description = "An official requisition of military-grade capital missiles from Earth Alliance for symbolic amount of credits that were used as transportation fee at very most.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Random_Nuke_Sprite")) storedPerkSprites.Add("Random_Nuke_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module DIY explo combinator, to 3ships":
					perk.displayName = "Advanced Industrial Modules Deal";
					perk.description = "A cache of freshly manufactured and neatly packed advanced industrial modules sold by official dealer for acceptable price. Contains modules for manufacturing explosives and metals.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module synth cooker, to tigerfish":
					perk.displayName = "Emergency Industrial Modules Deal";
					perk.description = "A cache of freshly manufactured and neatly packed advanced industrial modules sold by official dealer for acceptable price. Contains modules for manufacturing synthetics and starfuel.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-2500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace shield 2old":
					perk.displayName = "Fusion Shield Modules Deal";
					perk.description = "A cache of freshly manufactured and neatly packed shield generation and capacity modules sold by official dealer for acceptable price. Contains fusion shield generator and fusion shield capacitor.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 3 threespace").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 2 terran").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[0];
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace terran smallreactor old":
					perk.displayName = "Energy Systems Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older reactors of the ship with newer reactors available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 4 diy 1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 5 diy 2 backup").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 7 diy 3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 6 smalltrapho").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 8 smallmulty").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 9 biotech DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 9 small old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 10 small").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 11 single biofruit DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 12 custom old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 single biofruit").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 rats").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace combat sensor old with new":
					perk.displayName = "Utility Systems Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older utility modules of the ship with newer utility modules available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 0-C diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 4 saucer new").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 1-L DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 4 saucer new").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 2 saucer old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 4 saucer new").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 3 L terran simple").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 4 saucer new").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 3 planty").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 4 saucer new").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 0 DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 spiralcrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 02 bluecrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 03 neoncrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[5].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk drone for Tigerfish":
					perk.displayName = "Additional Drone Crew Support";
					perk.description = "Additional set of all kinds of drones to delegate majority of routine work to autonomous machines. Was honestly acquired through official Earth Alliance channels due to reaching expiration date.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Heavy Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Nuke Runner Perks
					case "Perk Replace sniper2 with sniper3":
					perk.displayName = "Precision Weapon Upgrade";
					perk.description = "Permitted military acquisition of an upgraded precision weapons from the official supplier. Was possible only due to the crewmembers' deep connections with military.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Sniper cannon 2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon sniper cannon EMP").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace lasers for Nuke Runner":
					perk.displayName = "Energy Weapon Upgrade";
					perk.description = "Permitted military acquisition of an upgraded precision energy from the official supplier. Was possible only due to the crewmembers' deep connections with military.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon powerbeam-MK1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon powerbeam-MK3").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace autogatling with better one, for Nukerunner":
					perk.displayName = "Suppression Weapon Upgrade";
					perk.description = "Permitted military acquisition of an upgraded suppression weapons from the official supplier. Was possible only due to the crewmembers' deep connections with military.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling whiteA 13,4").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Sniper cannon 4").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName.Replace("Explosive","Expl.")} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke arsenal for SP33":
					perk.displayName = "Planetary Bombardment Arsenal";
					perk.description = "A complete arsenal of a military-grade strategic capital missiles that can be used to bomb any single planet into complete oblivion. It was acquired when we signed a very-ethical-use-only declaration and paid additional fees.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+12x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module oilcake organics converter":
					perk.displayName = "Complete Industrial Modules Deal";
					perk.description = "A cache of freshly manufactured and neatly packed advanced industrial modules sold by official dealer for acceptable price. Contains modules for manufacturing synthetics, starfuel, metals and explosives.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk crew top cadet":
					perk.displayName = "Excellent Tactical Marines Team";
					perk.description = "Due to nature of our endeavor and military connections, this team of excellent tactical marines from best academy were willing to escort us through the dangers to gain hands-on experience and small payment.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-2500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Human")} {Core.TT("Crewmembers")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk drone 09 light sec":
					perk.displayName = "Tactical Drones Primary Set";
					perk.description = "A primary set of military tactical drones that will assist with daily operations of the ship, along with boarding and defensive actions.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-2500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk drone 09b tactical sec":
					perk.displayName = "Tactical Drones Secondary Set";
					perk.description = "A secondary set of military tactical drones that will assist with daily operations of the ship, along with boarding and defensive actions.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-2500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk drone 09c Sentinel sec":
					perk.displayName = "Security Drones Boarding Party";
					perk.description = "A complete squad of heavy security drones modified for advanced boarding and defensive operations. Drones were upgraded with military-grade hardware as well.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Security_Drone_Sprite")) storedPerkSprites.Add("Security_Drone_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Rogue Rat Perks
					case "Perk Replace Rat firecannon1 with 2":
					perk.displayName = "Specialized Armaments Upgrade";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older specialized weapons of the ship with newer weapons of similar type available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ratcannon fire1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ratcannon fire3").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ratlaser short").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ratlaser long").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace Rat gatling cannon":
					perk.displayName = "Ballistic Armaments Upgrade";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older ballistic weapons of the ship with newer weapons of similar type available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling RatA 14,4").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling RatB 15,5").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke diy decoy for Rogue Rat":
					perk.displayName = "Decommissioned Electromagnetic Nukes";
					perk.description = "Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with greatly improved electromagnetic payload.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "16 EMP rat nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Rat DIY incendiary":
					perk.displayName = "Decommissioned Strategic Nukes";
					perk.description = "Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with high-performance nuclear payload.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08b Old nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Rat incendiary for Rogue Rat":
					perk.displayName = "Decommissioned Incendiary Nukes";
					perk.description = "Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with advanced incendiary payload.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "09 Rat nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk add explosives for Ratship":
					perk.displayName = "Abandoned Explosives Storage";
					perk.description = "Explosives are abundant in the Rat Empire, and can be obtained quite easily. We've found a huge storage of explosives that was abandoned long ago and took what we could.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(10000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module old random":
					perk.displayName = "Corrupted Rat Empire Official Deal";
					perk.description = "A shady deal with corrupted rat empire official for a meager amount of exotics allows us to upgrade majority of ship's modules to much higher grade modules acquired through not so official channels.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 gmo biotech").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 5 floral").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 1.5 rats diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 2 rats").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 3 brass, single").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 4 greendome").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 2 manualrats").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 3 brass, single").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 3 planty").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 5 futu saucer s1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 2 saucer old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 8 sunpanel old s1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab rats x3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab module x3").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 single biofruit").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 17 flower").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 12 custom old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 rats").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 8x insect").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 3x rats armor").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 8x insect").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 spiralcrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 03 neoncrystal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 03 neoncrystal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 3 shroomery").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab module x3").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dream recorder 1 rats").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dream recorder 4x weird biotech").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Reactors & Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensors & Laboratories")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Cryosleep & Cryodream Bays")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Shield Generators & Capacitors")} {Core.TT("Upgrade")}",
						$"+2x {Core.TT("Packed")} {Core.TT("Emergency Industrial Modules")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Deal_Handshake_Sprite")) storedPerkSprites.Add("Deal_Handshake_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case "Perk augment, jet tubing cleanup for Ratship":
					perk.displayName = "Thrusters Exhaust Refurbishment";
					perk.description = "Full refurbishment of ship's thrusters exhaust tubes. Significantly increases thrust power ship-wide and as result boost maneuvering capabilities of the ship.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.addShipEvasionPercent = 5;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipEvasionPercent}°/ₘ {Core.TT("Ship Evasion")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace engines with rat engines for rogue rat":
					perk.displayName = "Engine Systems Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older engines and thrusters of the ship with newer engines and thrusters available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 0 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 01 brittle").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 01 primitive").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2 rats").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 classic").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2 floral").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 01 tiger").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 weird").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 terran").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk crew warrior princess x2":
					perk.displayName = "Twin Insectoid Warrior Princesses";
					perk.description = "A pair of invertebrate mercenaries join our mission to feed their family of hundreds. A young insectoid princesses of a minor hive must survive 10 years of mercenary life before they can ascend into royal politics.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Insectoid")} {Core.TT("Crewmembers")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					//Fierce Sincerity Perks
					case "Perk module weapon Spideraa Shuriken":
					perk.displayName = "Flechette Chemical Railguns Deal";
					perk.description = "A cache of freshly manufactured and neatly packed weapon modules sold by official dealer for acceptable price. Contains pack of specialized anti-personnel flechette chemical railguns.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Spideraa shuriken").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Spideraa shuriken").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk nuke bio":
					perk.displayName = "Deathspore Boarding Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of specialized boarding and breaching capital missiles.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Minibio nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke bio 2 greentail":
					perk.displayName = "Biotic Spike Kinetic Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of specialized hull perforation kinetic impactor capital missiles.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Greentail nuke launcher 2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module Decoy Set x 3":
					perk.displayName = "Farmland Greenhouses Deal";
					perk.description = "A cache of freshly manufactured and neatly packed greenhouse modules sold by official dealer for acceptable price. Contains pack of high-tier greenhouse modules that will supply ship with organics during travel.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 5 greenhouse").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 5 greenhouse").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk artifact skull for Weirdship":
					perk.displayName = "Storage Modules Upgrade";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older storage modules of the ship with newer storage modules of similar type available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "exotics container 0 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container 1 bio").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module green integrity for weirdship":
					perk.displayName = "Engine Systems Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older engines and thrusters of the ship with newer engines and thrusters available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2 floral").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2.5 weird").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module integrity blue scales, unlockable for weirdship":
					perk.displayName = "Dragonscale Integrity Armors Deal";
					perk.description = "A cache of freshly manufactured and neatly packed integrity armors sold by official dealer for acceptable price. Contains pack of quality integrity armors that will greatly boost survivability of the ship and its crew.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "integrity 06 big green scales").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "integrity 06 big green scales").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk pet random":
					perk.displayName = "Best AI Friends Forever";
					perk.description = "Since our journey will be long and all of our crewmembers will be occupied, we still need a way to entertain AI of our ship, before she will decide to blow ship out of pure boredom. And pets are best to keep her entertained.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Dog").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Cat1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Rabbit").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Slime pet").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Dog")}",
						$"+1x {Core.TT("Cat")}",
						$"+1x {Core.TT("Slime")}",
						$"+1x {Core.TT("Rabbit")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk war animal for weirdship":
					perk.displayName = "Red Rippers Boarding Party";
					perk.description = "A complete squad of red rippers, combat animals trained for advanced boarding and defensive operations. These red rippers undergone extremely strict military-grade training, examinations and enhancements.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Red Ripper")} {Core.TT("Combat Animals")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Red_Ripper_Crew_Sprite")) storedPerkSprites.Add("Red_Ripper_Crew_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Easy Tiger Perks
					case "Perk module DIY exotic EMP sniper":
					perk.displayName = "Recovered Exotic Ray Projector";
					perk.description = "Right before takeoff, we've managed to restore to the working condition one of the exotic ray weapons, we've found earlier.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon BFGx9 for bluestar").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector",string.Empty)}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Pumpkin Hammer Perks
					case "Perk nuke barrel":
					perk.displayName = "Avalanche Tactical Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of standard-type tactical capital missiles with high-yield explosive warhead.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08d Spearhead nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke old":
					perk.displayName = "Happy World Strategic Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of civilian-grade strategic capital missiles with low-yield nuclear warhead.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08a Happy nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace organics containers with betters for gardenship":
					perk.displayName = "Organics Storage Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "organics container 3 large").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "organics container 5 ultra large").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace fuel containers with betters":
					perk.displayName = "Earth Alliance Support Agreement";
					perk.description = "Due to our achievements, Earth Alliance and the allies are ready to overhaul majority of equipment on our ship for free, given we can provide enough exotic matter to power temporary trans-dimensional gate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container 2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container 5").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "organics container 2 medium").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "exotics container 2 medium").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer MS-1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives container 3 large").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 fusion").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 18 weird alien biotech").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 6 smalltrapho").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 05 rotor metal").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 1 round old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 4 greendome").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 2 terran").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 gmo biotech").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 0 ancient").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 03 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay2 startversion").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay4 stem celler").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 8 sunpanel old s1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 11 sophisiticated s2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab module x3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 2crew").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew plastarmor").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Reactors & Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensors & Laboratories")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Bridge & Shield Systems")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Storages & Cryosleep Bays")} {Core.TT("Upgrade")}",
						$"+2x {Core.TT("Packed")} {Core.TT("Emergency Industrial Modules")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case "Perk pack, explosive cargo for gardenship":
					perk.displayName = "Point Defenses Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "0 DIY PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "5 Human PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk pack, organic cargo for gardenship":
					perk.displayName = "Advanced Weapons Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon mininglaser 4").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ancientrockets x3").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk module DIY shielding set x 2":
					perk.displayName = "Antimatter Shield Systems Deal";
					perk.description = "A cache of freshly manufactured and neatly packed shield generator and capacitors sold by official dealer for acceptable price. Contains set of high-tier antimatter shield generators and capacitors that will greatly boost survivability of the ship.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 4 greendome").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 gmo biotech").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 gmo biotech").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module shroomery for gardenship":
					perk.displayName = "Greenhouse Modules Replacement";
					perk.description = "Planned upgrade that takes some time and preparations to execute. Replaces older greenhouse modules of the ship with newer greenhouse modules available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 1 DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 3 shroomery").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk maggot pet":
					perk.displayName = "Red Rippers Boarding Party";
					perk.description = "A complete squad of red rippers, combat animals trained for advanced boarding and defensive operations. These red rippers undergone extremely strict military-grade training, examinations and enhancements.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(c => c.name == "Redripper crew").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(c => c.name == "Redripper crew").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(c => c.name == "Redripper crew").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(c => c.name == "Redripper crew").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Red Ripper")} {Core.TT("Combat Animals")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk crew warrior queen":
					perk.displayName = "Twin Insectoid Warrior Queens";
					perk.description = "A leaders of a minor hives, looking to complete their ritual training. They brings along some resources as compensation for our effort.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(5000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Insectoid")} {Core.TT("Crewmembers")}",
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					//Atlas Perks
					case "Perk nuke fueltank for atlas":
					perk.displayName = "Hellfire Thermal Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of experimental thermal capital missiles with volumetric instant-ignition warhead.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace or improve bridge for atlas":
					perk.displayName = "Primary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older reactors, weapons and bridge modules of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "5 Human PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "2 Tiger PD").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Sniper cannon 0").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon sniper cannon EMP").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ATK-MK2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Segmented cannonx2 C").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon powerbeam-MK2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon insectoid fast laser").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 9 small old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 fusion").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 2crew").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew plastarmor").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[4].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[5].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace or improve growery for Atlas":
					perk.displayName = "Secondary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older shields, engines, sensors and warp drive modules of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 1 round old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 4 solitary").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 2 terran").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 generic alien").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2 large robust").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 04 xblack").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 06 rotor blue").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 3 L terran simple").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 11 sophisiticated s2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[4].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace or improve lab for atlas":
					perk.displayName = "Auxiliary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older storage containers, greenhouses, laboratories and cryosleep bays of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 3x medical").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab module x3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 2 minigrow").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 4 greenhouse").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "organics container 1 small").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container 3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[4].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module fuel combinator, to atlas":
					perk.displayName = "Complete Industrial Modules Deal";
					perk.description = "A cache of freshly manufactured and neatly packed advanced industrial modules sold by official dealer for acceptable price. Contains modules for manufacturing synthetics, starfuel, metals and explosives.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk crew human volunteer":
					perk.displayName = "Squad of Human Volunteers";
					perk.description = "A squad of human volunteers joins the mission to aid us during journey. They also bring along some supplies and emergency equipment.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue(1000);
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs },
						new Perk.Pool{ Prefabs = temp_ExtraCrew[0].Prefabs }};
					perk.randomizerMenuStrings = new string[]{
						$"+3x {Core.TT("Human")} {Core.TT("Crewmembers")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					//Bluestar Perks
					case "Perk Replace dual mininglasers with triple, for Bluestar":
					perk.displayName = "Main Weapon Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older weapon modules of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon mininglaser 2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon exoticscannon1").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk nuke EMP 9000":
					perk.displayName = "Ion Storm Energy Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade electromagnetic capital missiles with high-intensity pulse generators.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke DIY probe ual4 for bluestar":
					perk.displayName = "White Death Strategic Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade strategic capital missiles with high-yield nuclear warhead.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace sensor with new for bluestar":
					perk.displayName = "Reconnaissance Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older sensor modules and point defenses of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "5 Human PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 3 L terran simple").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 10 tiger").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk moleculaati pet":
					perk.displayName = "Best AI Friends' Friends Forever";
					perk.description = "Since our journey will be long and all of our crewmembers will be occupied, we still need even more ways to entertain AI of our ship, before she will decide to blow ship out of pure boredom. And more pets are best to keep her entertained.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Lizard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Floater").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Tortoise").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Moleculaati").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Lizard")}",
						$"+1x {Core.TT("Floater")}",
						$"+1x {Core.TT("Tortoise")}",
						$"+1x {Core.TT("Moleculaati")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk drone 05 DIY science":
					perk.displayName = "Security Drones Boarding Party";
					perk.description = "A complete squad of heavy security drones modified for advanced boarding and defensive operations. Drones were upgraded with military-grade hardware as well.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk module artifact, nontech for Bluestar":
					perk.displayName = "Recovered Ancient Modules Cache";
					perk.description = "Right before takeoff, we've managed to restore all modules from the ancient cache to the working condition, we've found earlier.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon monolith missile x1").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.menuSprite = perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					//Warpshell Perks
					case "Perk nuke DIY shield breaker":
					perk.displayName = "Absolute Chemical Extravaganza";
					perk.description = "A complete arsenal of a military-grade chemical capital missiles that can be used to purify any single planet from any sings of life. It was acquired when we signed a very-ethical-use-only declaration and paid additional fees.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "07 Weirdship Chem nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+12x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk warpshell extra deflection":
					perk.displayName = "External Tissue Enhancement";
					perk.description = "The living part of the ship can be easily modified using a variety of biotechnological solutions. This one improves ship's internal and external kinetic bumpers, improving overall deflection efficiency.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.addShipDeflectPercent = 5;
					perk.extraModules = new Perk.Pool[0];
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipDeflectPercent}% {Core.TT("Ship Deflection")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk warpshell extra hitpoints":
					perk.displayName = "Organic Integrity Enhancement";
					perk.description = "The living part of the ship has a range of exotic nutrients it needs to consume couple of times a year. If correct biotechnological solutions added to the nutrients, the ship's living tissue will grow more resistant to damage.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.addShipMaxHealth = 300;
					perk.extraModules = new Perk.Pool[0];
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace terran smallreactor oldx2":
					perk.displayName = "Primary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older reactors, weapons and bridge modules of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "5 Human PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "7 Red PD").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon sniper cannon EMP").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Floral cannon").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon Floral cannon").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon dual EMP").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon exoticscannon1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 5 diy 2 backup").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 biofruit").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 9 small old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 biofruit").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 1crew DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew floral").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[5].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[6].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace ECM of warpshell":
					perk.displayName = "Secondary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older shields, engines, sensors and warp drive modules of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat 3 generic alien").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Stealth decryptor 2 biobrain").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 1 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 4 solitary").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 01 terran").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "ECM 02 terran").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 0 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 03 bioship").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 0 DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 06 rotor blue").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 0-C diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 11 seashell s2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[4].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Replace DIY FO with FOO":
					perk.displayName = "Auxiliary Modules Replacement";
					perk.description = "Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older storage containers, greenhouses, laboratories and cryosleep bays of the ship with newer modules of same types available at the market.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay4 stem celler").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 6 synthethics").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer DIY FO").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer MFO retro futu").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "exotics container 2 medium").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Battle Tiger Perks
					case "Perk nuke Tiger sharpnel":
					perk.displayName = "Acid Rain Chemical Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade chemical capital missiles with extremely corrosive payload.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger sharpnel nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Battle Tiger monolith":
					perk.displayName = "Bright Fury Kinetic Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade kinetic capital missiles with tandem-impactor kinetic warhead.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger Monolith nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Tiger dual EMP":
					perk.displayName = "Dual Shock Energy Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade electromagnetic capital missiles with high-intensity pulse generators.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger EMP dual nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Tiger battery 8":
					perk.displayName = "Cataclysm Tactical Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade tactical capital missiles with octagonal cluster high-explosive high-yield warheads.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk nuke Tiger intruderbot nuke":
					perk.displayName = "Apocalypse Boarding Nukes Deal";
					perk.description = "A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade boarding capital missiles with perforation capabilities that release military boarding drones on impact.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk pet Tiger dog drone":
					perk.displayName = "Earth Alliance Drone Legion";
					perk.description = "Additional set of all kinds of drones to delegate majority of routine work to autonomous machines. Was properly acquired through official Earth Alliance channels for fraction of a price due to the direct support of our endeavor by high command.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-20000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerdog").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerdog").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Heavy security drone").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+2x {Core.TT("General Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk pet DLC combat rabbit":
					perk.displayName = "Primary Systems Upgrade & Combat Rabbit Pet";
					perk.description = "We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. It is genetically modified for superior speed and strength, and digitally trained to attack enemies in close combat.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon dual EMP").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigerlaser MK2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile x2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 6 smalltrapho").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 15 medium").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 10 small").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 20 fusion").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 2crew tiger").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew plastarmor").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[4].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[5].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk pet DLC shocker lizard":
					perk.displayName = "Secondary Systems Upgrade & Shocker Lizard Pet";
					perk.description = "We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. The creature is quite intelligent and can shoot energy rays from its eyes.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield tigership").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat tiger").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 06 rotor blue").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 01 tiger").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 04 xblack").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 2 saucer old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 10 tiger").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk pet DLC fire tortoise":
					perk.displayName = "Support Systems Upgrade & Fire Tortoise Pet";
					perk.description = "We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. The creature is very intelligent and can tend gardens. It can also naturally breathe fire at enemies.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dronebay 1 basic").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay5 biofluid bath").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator diy").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FE armor").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container tiger").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 4 greenhouse").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer OME mechanical").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[2].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[3].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk pet DLC warp floater":
					perk.displayName = "Auxiliary Systems Upgrade & Warp Floater Pet";
					perk.description = "We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. This warp creature is an extreme rarity due to being able to effectively communicate with non-warp beings. It is quite intelligent and likes to stare into human eyes.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }}};
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "dream recorder 2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Endurance Perks
					case "Perk module old triple cannon":
					perk.displayName = "Personnel Equipment Requisition";
					perk.description = "A cache of freshly manufactured and neatly packed high-end personnel weapons, implants and upgrades supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 11 biostasis").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 33 biostasis nice worm").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "artifactmodule tec 35 data core makk").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+6x {Core.TT("Packed")} {perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+6x {Core.TT("Packed")} {perk.extraModules[12].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case "Perk Replace ATK old with ATK new for Endurance":
					perk.displayName = "Experimental Weapons Requisition";
					perk.description = "A cache of freshly manufactured and neatly packed multiple types of experimental weapons supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon EMP energyball 3x Tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon gatling Tiger").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk nuke for Endurance":
					perk.displayName = "Ancient Capital Missiles Cache";
					perk.description = "An ancient, but perfectly sealed cache with capital missiles of all types and classifications suitable for any objective. We had to pay a hefty price to one of the famous hackers to break the seal open without triggering self-destruction mechanism.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-20000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Monolith nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "11 EMP nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "04 Fueltank nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger 8x nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "08c Green nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Tiger intruderbot nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "15 Black nuke launcher").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+14x {Core.TT("Packed Nukes (2x Each)")}: " +
							$"{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[8].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[10].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)} {Core.TT("and")} " +
							$"{perk.extraModules[12].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)} {Core.TT("Nukes")}.",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}, {perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk Endurance extra hitpoints and deflection":
					perk.displayName = "Bulkheads & Armor Refurbishment";
					perk.description = "A full refurbishment of all armor plates and integrity bulkheads will greatly increase durability of this ancient space vessel, as well its deflective and evasion properties, thus greatly increasing chances to reach the conclusion of our journey safely.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-5000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-5000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.addShipMaxHealth = 500;
					perk.addShipDeflectPercent = 15;
					perk.addShipEvasionPercent = 5;
					perk.extraModules = new Perk.Pool[0];
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipEvasionPercent}°/ₘ {Core.TT("Ship Evasion")}",
						$"+{perk.addShipDeflectPercent}% {Core.TT("Ship Deflection")}",
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case "Perk Replace containers with betters for Endurance":
					perk.displayName = "Earth Alliance Council Backing";
					perk.description = "Due to our immense achievements, Earth Alliance and the allies are ready to overhaul all of equipment with high-end modules on our ship for free, given we can provide enough exotic matter to power temporary trans-dimensional gate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-50000);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "metals container 2 medium").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Stealth decryptor 3 newest human tec").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer DIY EE").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "organics container 0 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "medbay4 stem celler").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics container 0 diy").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel container 1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 2x human small").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat tiger").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield 1 round old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shield tigership").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 8 sunpanel old s1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "sensor 9 sunpanel new s2").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "03 Barrel nuke launcher").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "10 White nuke launcher").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon DIY Minicannon ancient 2,3").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon ATK-MK1").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon DIY exoticslaser").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "weapon tigermissile large").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "5 Human PD").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "2 Tiger PD").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 01 greencrystal").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "warp 07 rotor glass").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 01 primitive").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "engine 2 F-gulper").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 1 DIY").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "garden 4 greenhouse").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab module diy x2").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "lab 1xgood").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel combinator 1A old").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 22 cube").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 13 classic cooled").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "reactor 22 cube").gameObject }},
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew").gameObject },
							newModulePrefabRef = new PrefabRef { Prefab = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "bridge 3crew metalarmor").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Bridge, Shields & CIWS")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Reactors, Engines & Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Weapons, Nukes & Stealth")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Storages, Cryo & Health Bays")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensors, Greenhouses & Labs")} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 40;
					break;
					case "Perk pack, solid starfuel for endurance":
					perk.displayName = "Support Modules Requisition";
					perk.description = "A cache of freshly manufactured and neatly packed full range of support modules supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-50000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "shieldbat tiger").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "Stealth decryptor 3 newest human tec").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "cryosleep 6x human standard").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer ESM-2").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "multicontainer FEO-1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "synthetics cooker 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 1B").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "explosives combinator 1").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(x => x.name == "fuel processor 2").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Packed Storages/Factories Set")}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case "Perk DIY drone army":
					perk.displayName = "Private Tactical Drone Company";
					perk.description = "A private company of sentient tactical drones with built-in perfect loyalty lock that ready to help us on our journey for serious credit investment. We can delegate majority of our work to them and increase overall efficiency of the ship.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider pirates").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider pirates").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider pirates").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Drone tigerspider pirates").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == "Combat Drone Humanoid").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+8x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+4x {Core.TT("Assault Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Drone_Army_Sprite")) storedPerkSprites.Add("Drone_Army_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					//Perks Fallback
					default:
					string perkData = FFU_BE_Defs.dumpObjectLists ? "" : "[NEW PERK] ";
					perkData += $"Prefab ID: {perk.PrefabId}\n";
					perkData += $"Object Name: {perk.name}\n";
					perkData += $"Display Name: {perk.displayName}\n";
					perkData += $"Description: {perk.description}\n";
					perkData += $"Is Permanent: {perk.isPermanent.ToString()}\n";
					perkData += $"Is Default: {perk.isUnlockedByDefault.ToString()}\n";
					perkData += $"Unlock Announcement: {perk.unlockAnnouncementText}\n";
					perkData += $"Max Health Increase: {perk.addShipMaxHealth}\n";
					perkData += $"Max Deflect Increase: {perk.addShipDeflectPercent}\n";
					perkData += $"Max Evasion Increase: {perk.addShipEvasionPercent}\n";
					perkData += $"Max Accuracy Increase: {perk.addShipAccuracyPercent}\n";
					if (!perk.extraCrew.IsEmpty()) perkData += $"Extra Crewmember Pools:\n";
					if (!perk.extraCrew.IsEmpty()) for (int i = 0; i < perk.extraCrew.Length; i++) if (!perk.extraCrew[i].Prefabs.IsEmpty()) for (int j = 0; j < perk.extraCrew[i].Prefabs.Length; j++) perkData += $" > Pool #{i}: {perk.extraCrew[i].Prefabs[j].name}\n";
					perkData += $"Crew Matching Comment: {perk.extraCrewChooseWithMatchingComment}\n";
					perkData += $"Crew Display Name Override: {perk.extraCrewDisplayNameOverride}\n";
					perkData += $"Crew Description Override: {perk.extraCrewDescripionOverride}\n";
					if (!perk.extraModules.IsEmpty()) perkData += $"Extra Ship Module Pools:\n";
					if (!perk.extraModules.IsEmpty()) for (int i = 0; i < perk.extraModules.Length; i++) if (!perk.extraModules[i].Prefabs.IsEmpty()) for (int j = 0; j < perk.extraModules[i].Prefabs.Length; j++) perkData += $" > Pool #{i}: {perk.extraModules[i].Prefabs[j].name}\n";
					if (!perk.moduleReplacements.IsEmpty()) perkData += $"Ship Module Replacement Sets:\n";
					if (!perk.moduleReplacements.IsEmpty()) for (int i = 0; i < perk.moduleReplacements.Length; i++) perkData += $" > Set #{i}: {perk.moduleReplacements[i].oldModulePrefabRef.Prefab.name} => {perk.moduleReplacements[i].newModulePrefabRef.Prefab.name}\n";
					if (perk.randomizerResources.organics.MinValue != 0 ||
						perk.randomizerResources.fuel.MinValue != 0 ||
						perk.randomizerResources.metals.MinValue != 0 ||
						perk.randomizerResources.synthetics.MinValue != 0 ||
						perk.randomizerResources.explosives.MinValue != 0 ||
						perk.randomizerResources.exotics.MinValue != 0 ||
						perk.randomizerResources.credits.MinValue != 0)
						perkData += $"Additional Resources:\n";
					if (perk.randomizerResources.organics.MinValue != 0) perkData += $" > Organics: {perk.randomizerResources.organics.MinValue} ~ {perk.randomizerResources.organics.MaxValue}\n";
					if (perk.randomizerResources.fuel.MinValue != 0) perkData += $" > Starfuel: {perk.randomizerResources.fuel.MinValue} ~ {perk.randomizerResources.fuel.MaxValue}\n";
					if (perk.randomizerResources.metals.MinValue != 0) perkData += $" > Metals: {perk.randomizerResources.metals.MinValue} ~ {perk.randomizerResources.metals.MaxValue}\n";
					if (perk.randomizerResources.synthetics.MinValue != 0) perkData += $" > Synthetics: {perk.randomizerResources.synthetics.MinValue} ~ {perk.randomizerResources.synthetics.MaxValue}\n";
					if (perk.randomizerResources.explosives.MinValue != 0) perkData += $" > Explosives: {perk.randomizerResources.explosives.MinValue} ~ {perk.randomizerResources.explosives.MaxValue}\n";
					if (perk.randomizerResources.exotics.MinValue != 0) perkData += $" > Exotics: {perk.randomizerResources.exotics.MinValue} ~ {perk.randomizerResources.exotics.MaxValue}\n";
					if (perk.randomizerResources.credits.MinValue != 0) perkData += $" > Credits: {perk.randomizerResources.credits.MinValue} ~ {perk.randomizerResources.credits.MaxValue}\n";
					if (!perk.randomizerMenuStrings.IsEmpty()) perkData += $"Additional Descriptions:\n";
					if (!perk.randomizerMenuStrings.IsEmpty()) for (int i = 0; i < perk.randomizerMenuStrings.Length; i++) perkData += $" > Entry #{i}: {perk.randomizerMenuStrings[i]}\n";
					perkData += $"Fate Bonus: {perk.fateBonusInPerkSelection}\n";
					perkData += $"Fate Cost: {perk.repCost}";
					if (FFU_BE_Defs.dumpObjectLists) perksData += perkData + "\n\n";
					if (!FFU_BE_Defs.dumpObjectLists) Debug.LogWarning(perkData);
					break;
				}
				if (!perk.isUnlockedByDefault) FFU_BE_Defs.unlockablePerkList.Add(perk);
				FFU_BE_Defs.prefabPerkList.Add(perk);
			}
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk Replace containers with betters for Endurance").menuSprite = storedPerkSprites["Deal_Handshake_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk Replace ATK old with ATK new for Endurance").menuSprite = storedPerkSprites["Random_Module_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk Replace fuel containers with betters").menuSprite = storedPerkSprites["Deal_Handshake_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk pack, solid starfuel for endurance").menuSprite = storedPerkSprites["Leftover_Module_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk module old triple cannon").menuSprite = storedPerkSprites["Imperial_Crate_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk drone 05 DIY science").menuSprite = storedPerkSprites["Security_Drone_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk pet Tiger dog drone").menuSprite = storedPerkSprites["Drone_Army_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk nuke for Endurance").menuSprite = storedPerkSprites["Random_Nuke_Sprite"];
			FFU_BE_Defs.prefabPerkList.Find(p => p.name == "Perk maggot pet").menuSprite = storedPerkSprites["Red_Ripper_Crew_Sprite"];
			if (FFU_BE_Defs.dumpObjectLists) Debug.LogWarning(perksData);
		}
		public static void InitLockedPerksAllocation() {
			List<GameObject> unusedPerks = new List<GameObject>();
			List<GameObject> existingPerks = new List<GameObject>();
			foreach (Sector sector in Resources.FindObjectsOfTypeAll<Sector>()) {
				foreach (Perk item in sector.otherUnlockablePerks) if (!existingPerks.Contains(item.gameObject)) existingPerks.Add(item.gameObject);
				if (sector.sectorEndUnlockablePerkPool != null) foreach (GameObject item in sector.sectorEndUnlockablePerkPool.items) if (item != null) if (!existingPerks.Contains(item)) existingPerks.Add(item);
			}
			foreach (Perk perk in FFU_BE_Defs.unlockablePerkList) if (!existingPerks.Contains(perk.gameObject)) unusedPerks.Add(perk.gameObject);
			foreach (Sector sector in Resources.FindObjectsOfTypeAll<Sector>()) if (sector.sectorEndUnlockablePerkPool != null) foreach (GameObject item in unusedPerks) sector.sectorEndUnlockablePerkPool.items.Add(item);
		}
		public static void InitShipCoreCrewmembers() {
			foreach (AddCrewToShip crewSet in Resources.FindObjectsOfTypeAll<AddCrewToShip>()) {
				int shipPrefabID = 0;
				switch (crewSet.name) {
					case "01 Tigerfish": shipPrefabID = 516057105; break;
					case "02 Nuke Runner": shipPrefabID = 487234563; break;
					case "04 Rogue Rat": shipPrefabID = 578937222; break;
					case "03 Weirdship": shipPrefabID = 1809014558; break;
					case "00 Easy Tiger": shipPrefabID = 1920692188; break;
					case "05 Gardenship": shipPrefabID = 1106792042; break;
					case "06 Atlas": shipPrefabID = 2103659466; break;
					case "07 Bluestar MK III scientific": shipPrefabID = 1772361532; break;
					case "08 Roundship": shipPrefabID = 1251918188; break;
					case "BattleTiger": shipPrefabID = 1452660923; break;
					case "10 Endurance": shipPrefabID = 1939804939; break;
				}
				if (shipPrefabID > 0) {
					List<AddCrewToShip.Group> crewSetList = crewSet.groups.ToList();
					foreach (KeyValuePair<string, int> storedCrewSet in FFU_BE_Defs.startingCrew[shipPrefabID]) {
						AddCrewToShip.Group newCrewSet = new AddCrewToShip.Group();
						Crewmember refCrew = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == storedCrewSet.Key);
						if (refCrew != null) {
							newCrewSet.prefabRef.Prefab = refCrew.gameObject;
							newCrewSet.spawnArea = Ship.TaskArea.DefaultCrewSpawn;
							newCrewSet.count = FFU_BE_Defs.NewExactValue(storedCrewSet.Value);
							newCrewSet.matchCrewColor = true;
							crewSetList.Add(newCrewSet);
						}
					}
					crewSet.groups = new AddCrewToShip.Group[crewSetList.Count];
					crewSet.groups = crewSetList.ToArray();
					FFU_BE_Defs.prefabCrewmemberSets.Add(crewSet);
				}
			}
		}
		public static void InitShipResourcePrefabs() {
			foreach (AddResourcesToShip resSet in Resources.FindObjectsOfTypeAll<AddResourcesToShip>()) {
				if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Resource Set: {resSet.name}");
				switch (resSet.name) {
					case "01 Tigerfish":
					resSet.organics = FFU_BE_Defs.NewExactValue(3000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(3000);
					resSet.metals = FFU_BE_Defs.NewExactValue(3000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(3000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(3000);
					resSet.exotics = FFU_BE_Defs.NewExactValue();
					resSet.credits = FFU_BE_Defs.NewExactValue(50000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "02 Nuke Runner":
					resSet.organics = FFU_BE_Defs.NewExactValue(3500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(4500);
					resSet.metals = FFU_BE_Defs.NewExactValue(4000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(4000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(5000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(50);
					resSet.credits = FFU_BE_Defs.NewExactValue(35000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "04 Rogue Rat":
					resSet.organics = FFU_BE_Defs.NewExactValue(3500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(8500);
					resSet.metals = FFU_BE_Defs.NewExactValue(6000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(6000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(6000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(350);
					resSet.credits = FFU_BE_Defs.NewExactValue(15000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "03 Weirdship":
					resSet.organics = FFU_BE_Defs.NewExactValue(6500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(6000);
					resSet.metals = FFU_BE_Defs.NewExactValue(4000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(4000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(4000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(150);
					resSet.credits = FFU_BE_Defs.NewExactValue(40000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "00 Easy Tiger":
					resSet.organics = FFU_BE_Defs.NewExactValue(10000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(10000);
					resSet.metals = FFU_BE_Defs.NewExactValue(10000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(10000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(10000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(750);
					resSet.credits = FFU_BE_Defs.NewExactValue(125000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "05 Gardenship":
					resSet.organics = FFU_BE_Defs.NewExactValue(10000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(7000);
					resSet.metals = FFU_BE_Defs.NewExactValue(4500);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(6500);
					resSet.explosives = FFU_BE_Defs.NewExactValue(4500);
					resSet.exotics = FFU_BE_Defs.NewExactValue(250);
					resSet.credits = FFU_BE_Defs.NewExactValue(50000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "06 Atlas":
					resSet.organics = FFU_BE_Defs.NewExactValue(6000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(9000);
					resSet.metals = FFU_BE_Defs.NewExactValue(8000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(8000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(8000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(350);
					resSet.credits = FFU_BE_Defs.NewExactValue(75000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "07 Bluestar MK III scientific":
					resSet.organics = FFU_BE_Defs.NewExactValue(7500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(9000);
					resSet.metals = FFU_BE_Defs.NewExactValue(7000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(7000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(7000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(500);
					resSet.credits = FFU_BE_Defs.NewExactValue(75000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "08 Roundship":
					resSet.organics = FFU_BE_Defs.NewExactValue(15000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(10000);
					resSet.metals = FFU_BE_Defs.NewExactValue(10000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(10000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(10000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(1500);
					resSet.credits = FFU_BE_Defs.NewExactValue(100000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "BattleTiger":
					resSet.organics = FFU_BE_Defs.NewExactValue(10000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(15000);
					resSet.metals = FFU_BE_Defs.NewExactValue(12500);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(12500);
					resSet.explosives = FFU_BE_Defs.NewExactValue(15000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(1250);
					resSet.credits = FFU_BE_Defs.NewExactValue(125000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
					case "10 Endurance":
					resSet.organics = FFU_BE_Defs.NewExactValue(13500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(15000);
					resSet.metals = FFU_BE_Defs.NewExactValue(12000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(12000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(17500);
					resSet.exotics = FFU_BE_Defs.NewExactValue(1500);
					resSet.credits = FFU_BE_Defs.NewExactValue(150000);
					FFU_BE_Defs.prefabResourceSets.Add(resSet);
					break;
				}
			}
		}
		public static void InitSpaceShipsPrefabList() {
			foreach (Ship ship in Resources.FindObjectsOfTypeAll<Ship>()) {
				if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Ship: {ship.name} [{ship.PrefabId}] {ship.displayName}");
				switch (ship.name) {
					case "01 Tigerfish":
					ship.MaxHealthAdd = 300;
					ship.survivabilityText = "NO";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 150));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Industrial Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 24));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "02 Nuke Runner":
					ship.MaxHealthAdd = 250;
					ship.survivabilityText = "NO";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Security Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 30));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "04 Rogue Rat":
					ship.MaxHealthAdd = 280;
					ship.survivabilityText = "LOL";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 125));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Metal Scrap Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "03 Weirdship":
					ship.MaxHealthAdd = 330;
					ship.survivabilityText = "MEH";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 75));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Organic Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "00 Easy Tiger":
					ship.MaxHealthAdd = 450;
					ship.survivabilityText = "OK";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Tactical Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "05 Gardenship":
					ship.MaxHealthAdd = 380;
					ship.survivabilityText = "OK";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 175));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Pressure Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "06 Atlas":
					ship.MaxHealthAdd = 470;
					ship.survivabilityText = "OK";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 225));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Reinforced Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "07 Bluestar MK III scientific":
					ship.MaxHealthAdd = 520;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 275));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "High-Tech Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "08 Roundship":
					ship.MaxHealthAdd = 420;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 200));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Carapace Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "BattleTiger":
					ship.MaxHealthAdd = 700;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 350));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Shielded Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 54));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "10 Endurance":
					ship.MaxHealthAdd = 600;
					ship.survivabilityText = "EPIC";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 475));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Heavy Blast Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 60));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
				}
			}
		}
		public static void EnablePowerOverwhelmingMode(Ship bossShip) {
			if (bossShip == null) return;
			switch (bossShip.PrefabId) {
				case 162816515: /*01B Rat boss*/ break;
				case 861690815: /*Level 2 Pirate boss*/ break;
				case 1569255838: /*Level 3 boss squid bounty hunter*/ break;
				case 334853457: /*Level 4 Insectoid boss*/ break;
				case 382650247: /*Level 5 Slaver boss, lair*/ break;
				case 1126524606: /*Level 7 boss squid assasnik*/ break;
				case 808198467: /*Level 9 boss, Shogar*/ break;
				case 2009197315: /*Level 10 boss insectoid Calm Destruction*/ break;
				default: break;
			}
		}
		public static bool IsUpdatedTemplateShip(Ship bossShip) {
			if (bossShip == null) return false;
			//if (bossShip.name.Contains("Level 1 Rat boss")) return true;
			//else if (bossShip.name.Contains("Level 2 Pirate boss")) return true;
			//else if (bossShip.name.Contains("Level 3 boss squid bounty hunter")) return true;
			//else if (bossShip.name.Contains("Level 4 Insectoid boss")) return true;
			//else if (bossShip.name.Contains("Level 5 Slaver boss, lair")) return true;
			//else if (bossShip.name.Contains("Level 7 boss squid assasnik")) return true;
			//else if (bossShip.name.Contains("Level 9 boss, Shogar")) return true;
			//else if (bossShip.name.Contains("Level 10 boss insectoid Calm Destruction")) return true;
			return false;
		}
	}
}

namespace RST {
	public class patch_Ship : Ship {
		[MonoModIgnore] private bool flyTo;
		[MonoModIgnore] private bool exploding;
		[MonoModIgnore] private Vector2 flyToPos;
		[MonoModIgnore] private float explosionTimer;
		[MonoModIgnore] private bool doAfterSpawnDone;
		[MonoModIgnore] private int doAfterSpawnCounter;
		[MonoModIgnore] private bool prevIsSelfDestructing;
		[MonoModIgnore] private void CompleteFlyTo() { }
		[MonoModIgnore] private void UpdateExplosion() { }
		[MonoModIgnore] private void AiSendSomeoneToExtinguishFire() { }
		public string HoverText {
		/// Detailed Ship Hover Info
			get {
				StringBuilder stringBuilder = RstShared.StringBuilder;
				Ownership.Owner owner = Ownership.GetOwner();
				switch (owner) {
					case Ownership.Owner.Me: stringBuilder.Append(MonoBehaviourExtended.TT("Your Ship")).Append(": ").Append(displayName); break;
					case Ownership.Owner.Enemy: stringBuilder.Append(MonoBehaviourExtended.TT("Enemy Ship")).Append(": ").Append(displayName); break;
					default: stringBuilder.Append(MonoBehaviourExtended.TT("Unknown Ship")).Append(": ").Append(displayName); break;
				}
				stringBuilder.Append('\n').Append(MonoBehaviourExtended.TT("Health Points")).Append(": ").AppendColoredHealth(this);
				if (IsSelfDestructing) stringBuilder.Append("\n<color=red>").AppendFormat(MonoBehaviourExtended.TT("Self-Destructs in {0}s"), (int)selfDestructTimer.value).Append("</color>");
				if (owner == Ownership.Owner.Me) {
					stringBuilder.Append('\n').Append(MonoBehaviourExtended.TT("Energy Emission: ")).Append($"{FFU_BE_Defs.energyEmission:0.#}").Append(MonoBehaviourExtended.TT("m³"));
					if (sectorRadarRangeAdd != 0) stringBuilder.Append('\n').AppendFormat(MonoBehaviourExtended.TT("Sector Radar Range Bonus: +{0}ru"), sectorRadarRangeAdd);
					if (starmapRadarRangeAdd != 0) stringBuilder.Append('\n').AppendFormat(MonoBehaviourExtended.TT("Starmap Radar Range Bonus: +{0}ru"), starmapRadarRangeAdd);
				}
				return stringBuilder.ToString();
			}
		}
		public int GetEvasion(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
		/// Ship Evasion Limit from Configuration & Reduced Evasion Bonus from Damaged Modules
			int finalEvasion = evasionPercentAdd;
			if (evasionPercentAdd != 0) perProviderCallback?.Invoke(this, evasionPercentAdd);
			List<ShipModule> shipModules = Modules;
			if (perProviderCallback != null) shipModules.Sort((ShipModule m) => -m.ShipEvasionPercentBonus);
			foreach (ShipModule shipModule in shipModules) {
				if (shipModule != null) {
					int evasionFromModule = (perProviderCallback != null) ? (-(int)(shipModule.SortIndex >> 32)) : shipModule.ShipEvasionPercentBonus;
					if (!shipModule.HasFullHealth) evasionFromModule = Mathf.CeilToInt(evasionFromModule * FFU_BE_Defs.GetHealthPercent(shipModule));
					if (evasionFromModule != 0) {
						finalEvasion += evasionFromModule;
						perProviderCallback?.Invoke(shipModule, evasionFromModule);
					}
				}
			}
			return Mathf.Clamp(finalEvasion, 0, FFU_BE_Defs.shipMaxEvasionLimit);
		}
		[MonoModReplace] public int GetAccuracy(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
		/// Reduced Accuracy Bonus from Damaged Modules
			int finalAccuracy = accuracyPercentAdd;
			if (accuracyPercentAdd != 0) perProviderCallback?.Invoke(this, accuracyPercentAdd);
			foreach (ShipModule shipModule in Modules) {
				if (shipModule != null) {
					int shipAccuracyPercentBonus = shipModule.ShipAccuracyPercentBonus;
					if (!shipModule.HasFullHealth) shipAccuracyPercentBonus = Mathf.CeilToInt(shipAccuracyPercentBonus * FFU_BE_Defs.GetHealthPercent(shipModule));
					if (shipAccuracyPercentBonus != 0) {
						finalAccuracy += shipAccuracyPercentBonus;
						perProviderCallback?.Invoke(shipModule, shipAccuracyPercentBonus);
					}
				}
			}
			return finalAccuracy;
		}
		[MonoModReplace] public int GetMaxShieldPoints(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
		/// Reduced Shield Capacity from Damaged Modules
			List<ShipModule> modules = Modules;
			if (perProviderCallback != null) modules.Sort((ShipModule m) => -m.MaxShieldAdd);
			int totalShield = 0;
			foreach (ShipModule shipModule in modules) {
				if (shipModule != null && !shipModule.IsPacked) {
					int maxShieldAdd = shipModule.MaxShieldAdd;
					if (!shipModule.HasFullHealth) maxShieldAdd = Mathf.RoundToInt(maxShieldAdd * FFU_BE_Defs.GetHealthPercent(shipModule));
					if (maxShieldAdd != 0) {
						totalShield += maxShieldAdd;
						perProviderCallback?.Invoke(shipModule, maxShieldAdd);
					}
				}
			}
			return totalShield;
		}
		[MonoModReplace] private void DoSelfDestruct() {
		/// Enforce Ship Self-Destruct Timer
			bool isSelfDestructing = IsSelfDestructing;
			if (prevIsSelfDestructing != isSelfDestructing) {
				if (isSelfDestructing) selfDestructTimer.Restart(WorldRules.Instance.shipSelfDestructTime);
				prevIsSelfDestructing = isSelfDestructing;
			}
			if (!isSelfDestructing && prevIsSelfDestructing) selfDestructTimer.Restart(WorldRules.Instance.shipSelfDestructTime);
			if (isSelfDestructing && selfDestructTimer.Update(1f)) TakeDamage(int.MaxValue);
		}
		[MonoModReplace] private void Update() {
		/// Collections to List Fix
			if (flyTo) {
				if (!(Vector2.Distance(base.transform.position, flyToPos) < 0.1f)) {
					if (!RstTime.IsPaused) base.transform.position = Vector2.Lerp(base.transform.position, flyToPos, 0.55f);
				} else {
					flyTo = false;
					CompleteFlyTo();
				}
			}
			if (doAfterSpawnCounter >= 0) {
				if (doAfterSpawnCounter == 0 && !doAfterSpawnDone) {
					List<IDoAfterShipSpawn> registeredChildren = GetRegisteredChildren<IDoAfterShipSpawn>();
					foreach (IDoAfterShipSpawn item in registeredChildren.ToList()) item.DoAfterShipSpawn(this);
					DestroyAll(registeredChildren);
					Ownership.Owner owner = Ownership.GetOwner();
					if (owner == Ownership.Owner.Enemy) ShipAction.Do(this, ShipAction.Action.TurnAllModulesOn);
					AI?.ThinkAndCommand(WorldRules.Instance.shipAiDoOnceActionsToConsider, true);
					PowerDistributor.Update();
					PlayerData me = PlayerDatas.Me;
					switch (owner) {
						case Ownership.Owner.Enemy:
						ShipAction.Do(this, ShipAction.Action.ReloadShield);
						ShipAction.Do(this, ShipAction.Action.TurnWeaponsToShipDirection);
						break;
						case Ownership.Owner.Me:
						if (me != null && me.quickSelectSlotCount <= 0) me.AutoAssignQuickSelectSlots();
						break;
					}
					if (owner == Ownership.Owner.Me && me != null && WorldRules.Impermanent.beginnerStartingBonus) {
						WorldRules.StartingBonus beginnerStartingBonus = WorldRules.Instance.beginnerStartingBonus;
						float startingBonusMult = FFU_BE_Defs.GetStartingModDiffMult();
						accuracyPercentAdd += Mathf.RoundToInt(beginnerStartingBonus.accuracyBonusPercent * startingBonusMult);
						evasionPercentAdd += Mathf.RoundToInt(beginnerStartingBonus.evasionBonusPercent * startingBonusMult);
						deflectChance += Mathf.RoundToInt(beginnerStartingBonus.deflectionBonusPercent * 0.01f * startingBonusMult);
						me.Fuel.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.fuel), null);
						me.Organics.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.organics), null);
						me.Explosives.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.explosives), null);
						me.Exotics.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.exotics), null);
						me.Synthetics.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.synthetics), null);
						me.Metals.Add(Mathf.RoundToInt(beginnerStartingBonus.resources.metals), null);
						if (Mathf.RoundToInt(beginnerStartingBonus.resources.credits) != 0) {
							me.Credits += Mathf.RoundToInt(beginnerStartingBonus.resources.credits);
							me.creditsChangeReasons.Add(null);
						}
					}
					doAfterSpawnDone = true;
				}
				doAfterSpawnCounter--;
			}
			bool flag = shield.ShieldPoints > 0;
			if (shield.gameObject.activeSelf != flag) shield.gameObject.SetActive(flag);
			DoSelfDestruct();
			if (IsDead) {
				if (!exploding) {
					if (Ownership.GetOwner() == Ownership.Owner.Me) GameSummaryPanel.PlayerDeathRelatedAchievementsCheck(this);
					PlayerData me2 = PlayerDatas.Me;
					if (me2 != null) me2.shipsDestroyed++;
					UsableWarpModule?.CancelWarp();
					SelectionManager.RemoveFromSelection(base.gameObject);
					explosionTimer = 0f;
					exploding = true;
				}
			} else AiSendSomeoneToExtinguishFire();
			if (exploding) UpdateExplosion();
		}
		[MonoModReplace] private void LeaveLootModules() {
		/// All Modules Lootable (Depends on their Integrity)
			int[] leaveLootModuleCounts = WorldRules.Instance.shipExplosionParams.leaveLootModuleCounts;
			if (!WorldRules.Impermanent.shipModuleLootDisabled && leaveLootModuleCounts.Length != 0 && Ownership.GetOwner() != Ownership.Owner.Me) {
				List<ShipModule> droppedModulesList = Modules.FindAll((ShipModule m) => m != null && !m.IsDead && m.type != ShipModule.Type.Storage && !FFU_BE_Defs.IsProhibitedModule(m));
				PlayerData me = PlayerDatas.Me;
				if (me != null) me.battleLoot += lootGet;
				foreach (ShipModule droppedModule in droppedModulesList) {
					if (FFU_BE_Defs.debugMode) Debug.Log("Dropped Module: [" + droppedModule.name + "] Health: " + droppedModule.Health + "/" + droppedModule.MaxHealth);
					bool wasDropped = (FFU_BE_Defs.intactModuleDropChance * FFU_BE_Defs.GetHealthPercent(droppedModule)) >= UnityEngine.Random.Range(0f, 1f);
					if (droppedModule.type == ShipModule.Type.Weapon_Nuke) wasDropped = FFU_BE_Defs.GetHealthPercent(droppedModule) >= UnityEngine.Random.Range(0f, 1f);
					if (droppedModule.displayName.Contains("Cache")) wasDropped = true;
					if (wasDropped) DetatchModule(droppedModule);
				}
			}
		}
		[MonoModReplace] private static void DetatchModule(ShipModule module) {
		/// Remove Temporary Modifiers & Make Boss Weapons Useless
			if (module == null) return;
			CrewAssignmentSpot[] operatorSpots = module.operatorSpots;
			for (int i = 0; i < operatorSpots.Length; i++) operatorSpots[i].UnassignCrew();
			operatorSpots = module.repairSpots;
			for (int i = 0; i < operatorSpots.Length; i++) operatorSpots[i].UnassignCrew();
			if (module.type == ShipModule.Type.Container) {
				ShipModule refModule = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == module.PrefabId);
				if (refModule.Container.MaxOrganics == 0) module.Container.MaxOrganics = 0;
				if (refModule.Container.MaxFuel == 0) module.Container.MaxFuel = 0;
				if (refModule.Container.MaxMetals == 0) module.Container.MaxMetals = 0;
				if (refModule.Container.MaxSynthetics == 0) module.Container.MaxSynthetics = 0;
				if (refModule.Container.MaxExplosives == 0) module.Container.MaxExplosives = 0;
				if (refModule.Container.MaxExotics == 0) module.Container.MaxExotics = 0;
				module.Container.Organics = 0;
				module.Container.Fuel = 0;
				module.Container.Metals = 0;
				module.Container.Synthetics = 0;
				module.Container.Explosives = 0;
				module.Container.Exotics = 0;
				
			}
			if (module != null && module.type == ShipModule.Type.Reactor && module.displayName.Contains(" (Overcharged)")) {
				module.Reactor.powerCapacity -= module.Reactor.overchargePowerCapacityAdd;
				module.displayName = module.displayName.Replace(" (Overcharged)", string.Empty);
			}
			if (module != null && module.displayName.Contains("bossweapon")) {
				module.Weapon.ProjectileOrBeamPrefab.GetDamage(module.Weapon).moduleOverloadSeconds = 0;
				module.Weapon.ProjectileOrBeamPrefab.GetDamage(module.Weapon).damageAreaRadius = 0;
				module.Weapon.ProjectileOrBeamPrefab.GetDamage(module.Weapon).shieldDmg = 0;
				module.Weapon.ProjectileOrBeamPrefab.GetDamage(module.Weapon).moduleDmg = 0;
				module.Weapon.ProjectileOrBeamPrefab.GetDamage(module.Weapon).shipDmg = 0;
			}
			if (module.type == ShipModule.Type.Weapon || module.type == ShipModule.Type.Weapon_Nuke) module.Weapon.Stop();
			module.transform.SetParent(PlayerDatas.Instance?.transform);
			module.transform.position = new Vector3(10000f, 0f, 0f);
			module.transform.rotation = Quaternion.identity;
			module.Ownership.SetOwner(Ownership.Owner.Inherit);
		}
	}
	public class patch_Door : Door {
		[MonoModIgnore] private PlayMakerFSM Fsm => GetCachedComponent<PlayMakerFSM>(true);
		[MonoModIgnore] private static List<Crewmember> tmpCrewList = new List<Crewmember>();
		public void OnPointerClick(PointerEventData eventData) {
		/// Repair Door when clicking Left Mouse Button
			if (eventData.button == Settings.SelectButton) {
				if (Ownership.GetOwner() == Ownership.Owner.Me && !HasFullHealth && PerFrameCache.IsGoodSituation) {
					int repairAmount = (MaxHealth - Health) >= 10 ? 10 : MaxHealth - Health;
					if (FFU_BE_Defs.doorRepairCost.CheckHasEnough(PlayerDatas.Me, repairAmount * FFU_BE_Defs.GetDifficultyModifier())) {
						FFU_BE_Defs.doorRepairCost.ConsumeFrom(PlayerDatas.Me, repairAmount * FFU_BE_Defs.GetDifficultyModifier(), Localization.tt("door repair"));
						Heal(repairAmount);
					}
				}
				SelectionManager.Select(base.gameObject);
			} else if (eventData.button == Settings.ActionButton) {
				if (PlayerCanLockThis()) Fsm.SendEvent("cmd action");
				else if (Crewmember.GetSelectedPlayerCrewThatCanTarget(tmpCrewList, this)) {
					UnityEngine.Object.Instantiate(VisualSettings.Instance.crewAttackFeedbackPrefab, base.transform.position, Quaternion.identity);
					foreach (Crewmember tmpCrew in tmpCrewList) tmpCrew.Attack(base.gameObject, true);
				} else MonoBehaviourExtended.ExecuteEventUpInHierarchy(base.gameObject, eventData, ExecuteEvents.pointerClickHandler);
			}
		}
		public string HoverText {
			get {
				StringBuilder stringBuilder = RstShared.StringBuilder;
				stringBuilder.Append(MonoBehaviourExtended.TT(DisplayNameLocalized)).Append('\n').Append(MonoBehaviourExtended.TT("HP")).Append(": ").AppendColoredHealth(this);
				if (IsLocked) stringBuilder.Append('\n').Append(MonoBehaviourExtended.TT("<color=lime>Locked</color>"));
				if (!HasFullHealth) {
					int lackingHealth = MaxHealth - Health;
					stringBuilder.Append("\n\n").Append(MonoBehaviourExtended.TT("Full Repair Cost: "));
					if (Ownership.GetOwner() == Ownership.Owner.Me) {
						stringBuilder.Append('\n').Append(" > Metals: ").Append("<color=red>").Append(lackingHealth * FFU_BE_Defs.doorRepairCost.metals * FFU_BE_Defs.GetDifficultyModifier()).Append("</color>");
						stringBuilder.Append('\n').Append(" > Synthetics: ").Append("<color=red>").Append(lackingHealth * FFU_BE_Defs.doorRepairCost.synthetics * FFU_BE_Defs.GetDifficultyModifier()).Append("</color>");
					} else {
						stringBuilder.Append('\n').Append(" > Metals: ").Append("<color=red>").Append(lackingHealth * FFU_BE_Defs.doorRepairCost.metals).Append("</color>");
						stringBuilder.Append('\n').Append(" > Synthetics: ").Append("<color=red>").Append(lackingHealth * FFU_BE_Defs.doorRepairCost.synthetics).Append("</color>");
					}
					stringBuilder.Append("\n\n").Append("Click to repair.");
				}
				return stringBuilder.ToString();
			}
		}
	}
}
