#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
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
			string perksData = $"\n";
			foreach (Perk perk in Resources.FindObjectsOfTypeAll<Perk>()) {
				switch (perk.name) {
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
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "compressed exotics pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "compressed exotics pack").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
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
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "general pack organics, synth, metal").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "general pack organics, synth, metal").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
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
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "fuel pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "explosives pack").gameObject }},
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "explosives pack").gameObject }}};
					perk.randomizerMenuStrings = new string[]{
						$"+3x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}" };
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
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "medbay6 biological").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "medbay6 biological").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
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
						new Perk.Pool{ Prefabs = new GameObject[]{ FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "medbay4 stem celler").gameObject }}};
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						FFU_BE_Defs.prefabModdedModulesList.Find(m => m.name == "medbay4 stem celler").PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
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
						$"+1x {Core.TT("Human Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
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
						$"+1x {Core.TT("Human Crewmember")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
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
						$"+1x {Core.TT("Human Crewmember")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
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
						$"+1x {Core.TT("Beedroid Crewmember")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
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
						$"+1x {Core.TT("Rat Crewmember")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
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
						$"+3x {Core.TT("Rat Crewmember")}",
						$"+{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
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
						$"+1x {Core.TT("Gitchanki Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
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
						$"+1x {Core.TT("Lizardfolk Crewmember")}",
						$"+{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
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
						$"+1x {Core.TT("Grippy Crewmember")}",
						$"+{perk.randomizerResources.explosives.minValue} {Core.TT("Explosives")}" };
					perk.repCost = 2;
					break;
					case "Perk crew gormor gardener":
					perk.displayName = "Tranquil Gor-Mod Gardener";
					perk.description = "This Gor-Mor individual is a famous gardener-philosopher, praised highly by political leaders and spiritual acolytes who seek enlightenment. He wants to help us in exchange for allowing him to meditate in our greenhouses.";
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(5000);
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Gor-Mod Crewmember")}",
						$"+{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
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
					perk.repCost = 25;
					break;
					case "Perk fate permanent 01 fortunate coincidence":
					perk.displayName = "A Fortunate Coincidence";
					perk.description = "A fortunate coincidence helps you to prepare better for the upcoming journey.";
					perk.fateBonusInPerkSelection = 1 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 2;
					break;
					case "Perk fate permanent 02 good luck":
					perk.displayName = "The Good Luck";
					perk.description = "Somebody wished you good luck before the journey, and thanks to an unexpected series of events, their wish actually came true.";
					perk.fateBonusInPerkSelection = 2 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 4;
					break;
					case "Perk fate permanent 03 causal chain reaction":
					perk.displayName = "The Causal Chain Reaction";
					perk.description = "Years ago, you helped somebody, changing their lives forever. It started a chain-reaction of events that led to somebody helping you today.";
					perk.fateBonusInPerkSelection = 3 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 6;
					break;
					case "Perk fate permanent 04 generosity and abundance":
					perk.displayName = "The Seeds of Generosity";
					perk.description = "By sowing the seeds of generosity in the past, you have arrived to the harvest of abundance in the present.";
					perk.fateBonusInPerkSelection = 4 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 8;
					break;
					case "Perk fate permanent 05 friend of truth":
					perk.displayName = "The Friend of Truth";
					perk.description = "Awareness of your personal limitations has granted you an even deeper awareness of your freedom.";
					perk.fateBonusInPerkSelection = 5 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 10;
					break;
					case "Perk fate permanent 06 focused one":
					perk.displayName = "The Focused One";
					perk.description = "You understand something so deeply that it allows you to understand everything a bit better than individuals usually do.";
					perk.fateBonusInPerkSelection = 6 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 12;
					break;
					case "Perk fate permanent 07 masterful exister":
					perk.displayName = "The Masterful Exister";
					perk.description = "Random coincidences seem to support the fulfillment of your wishes more than what is usually considered normal.";
					perk.fateBonusInPerkSelection = 7 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 14;
					break;
					case "Perk fate permanent 08 the great peace":
					perk.displayName = "The Great Peace";
					perk.description = "You're starting to realize your intimate connection with the Great Peace, remaining calm even in situations of utter distress.";
					perk.fateBonusInPerkSelection = 8 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 16;
					break;
					case "Perk fate permanent 09 optimality":
					perk.displayName = "The Optimality";
					perk.description = "You are in the right place, at the right time and under the right circumstances.";
					perk.fateBonusInPerkSelection = 9 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 18;
					break;
					case "Perk fate permanent 10 victory":
					perk.displayName = "The Taste of Victory";
					perk.description = "Those who know what awaits at the end of the road can enjoy the road itself better. And you are such person.";
					perk.fateBonusInPerkSelection = 10 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.repCost = 20;
					break;
					default:
					if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Perk: {perk.name} [{perk.PrefabId}] {perk.displayName}");
					perksData += $"Prefab ID: {perk.PrefabId}\n";
					perksData += $"Object Name: {perk.name}\n";
					perksData += $"Display Name: {perk.displayName}\n";
					perksData += $"Description: {perk.description}\n";
					perksData += $"Is Permanent: {perk.isPermanent.ToString()}\n";
					perksData += $"Is Default: {perk.isUnlockedByDefault.ToString()}\n";
					perksData += $"Unlock Announcement: {perk.unlockAnnouncementText}\n";
					perksData += $"Max Health Increase: {perk.addShipMaxHealth}\n";
					perksData += $"Max Deflect Increase: {perk.addShipDeflectPercent}\n";
					perksData += $"Max Evasion Increase: {perk.addShipEvasionPercent}\n";
					perksData += $"Max Accuracy Increase: {perk.addShipAccuracyPercent}\n";
					if (!perk.extraCrew.IsEmpty()) perksData += $"Extra Crewmember Pools:\n";
					if (!perk.extraCrew.IsEmpty()) for (int i = 0; i < perk.extraCrew.Length; i++) if (!perk.extraCrew[i].Prefabs.IsEmpty()) for (int j = 0; j < perk.extraCrew[i].Prefabs.Length; j++) perksData += $" > Pool #{i}: {perk.extraCrew[i].Prefabs[j].name}\n";
					perksData += $"Crew Matching Comment: {perk.extraCrewChooseWithMatchingComment}\n";
					perksData += $"Crew Display Name Override: {perk.extraCrewDisplayNameOverride}\n";
					perksData += $"Crew Description Override: {perk.extraCrewDescripionOverride}\n";
					if (!perk.extraModules.IsEmpty()) perksData += $"Extra Ship Module Pools:\n";
					if (!perk.extraModules.IsEmpty()) for (int i = 0; i < perk.extraModules.Length; i++) if (!perk.extraModules[i].Prefabs.IsEmpty()) for (int j = 0; j < perk.extraModules[i].Prefabs.Length; j++) perksData += $" > Pool #{i}: {perk.extraModules[i].Prefabs[j].name}\n";
					if (!perk.moduleReplacements.IsEmpty()) perksData += $"Ship Module Replacement Sets:\n";
					if (!perk.moduleReplacements.IsEmpty()) for (int i = 0; i < perk.moduleReplacements.Length; i++) perksData += $" > Set #{i}: {perk.moduleReplacements[i].oldModulePrefabRef.Prefab.name} => {perk.moduleReplacements[i].newModulePrefabRef.Prefab.name}\n";
					if (perk.randomizerResources.organics.MinValue != 0 ||
						perk.randomizerResources.fuel.MinValue != 0 ||
						perk.randomizerResources.metals.MinValue != 0 ||
						perk.randomizerResources.synthetics.MinValue != 0 ||
						perk.randomizerResources.explosives.MinValue != 0 ||
						perk.randomizerResources.exotics.MinValue != 0 ||
						perk.randomizerResources.credits.MinValue != 0)
						perksData += $"Additional Resources:\n";
					if (perk.randomizerResources.organics.MinValue != 0) perksData += $" > Organics: {perk.randomizerResources.organics.MinValue} ~ {perk.randomizerResources.organics.MaxValue}\n";
					if (perk.randomizerResources.fuel.MinValue != 0) perksData += $" > Starfuel: {perk.randomizerResources.fuel.MinValue} ~ {perk.randomizerResources.fuel.MaxValue}\n";
					if (perk.randomizerResources.metals.MinValue != 0) perksData += $" > Metals: {perk.randomizerResources.metals.MinValue} ~ {perk.randomizerResources.metals.MaxValue}\n";
					if (perk.randomizerResources.synthetics.MinValue != 0) perksData += $" > Synthetics: {perk.randomizerResources.synthetics.MinValue} ~ {perk.randomizerResources.synthetics.MaxValue}\n";
					if (perk.randomizerResources.explosives.MinValue != 0) perksData += $" > Explosives: {perk.randomizerResources.explosives.MinValue} ~ {perk.randomizerResources.explosives.MaxValue}\n";
					if (perk.randomizerResources.exotics.MinValue != 0) perksData += $" > Exotics: {perk.randomizerResources.exotics.MinValue} ~ {perk.randomizerResources.exotics.MaxValue}\n";
					if (perk.randomizerResources.credits.MinValue != 0) perksData += $" > Credits: {perk.randomizerResources.credits.MinValue} ~ {perk.randomizerResources.credits.MaxValue}\n";
					if (!perk.randomizerMenuStrings.IsEmpty()) perksData += $"Additional Descriptions:\n";
					if (!perk.randomizerMenuStrings.IsEmpty()) for (int i = 0; i < perk.randomizerMenuStrings.Length; i++) perksData += $" > Entry #{i}: {perk.randomizerMenuStrings[i]}\n";
					perksData += $"Fate Bonus: {perk.fateBonusInPerkSelection}\n";
					perksData += $"Fate Cost: {perk.repCost}\n\n";
					break;
				}
				FFU_BE_Defs.prefabPerkList.Add(perk);
			}
			if (FFU_BE_Defs.dumpObjectLists) Debug.LogWarning(perksData);
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
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 150));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Industrial Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 24));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "02 Nuke Runner":
					ship.MaxHealthAdd = 250;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Security Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 30));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "03 Weirdship":
					ship.MaxHealthAdd = 330;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 75));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Organic Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 18));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "04 Rogue Rat":
					ship.MaxHealthAdd = 280;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 125));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Metal Scrap Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "05 Gardenship":
					ship.MaxHealthAdd = 380;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 175));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Pressure Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 24));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "06 Atlas":
					ship.MaxHealthAdd = 470;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 225));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Reinforced Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "07 Bluestar MK III scientific":
					ship.MaxHealthAdd = 520;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 275));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "High-Tech Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "00 Easy Tiger":
					ship.MaxHealthAdd = 450;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Tactical Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "08 Roundship":
					ship.MaxHealthAdd = 420;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 200));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Carapace Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "BattleTiger":
					ship.MaxHealthAdd = 700;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 350));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Shielded Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case "10 Endurance":
					ship.MaxHealthAdd = 600;
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 475));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Heavy Blast Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 60));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
				}
			}
		}
		public static void EnablePowerOverwhelmingMode(Ship bossShip) {
			switch (bossShip.name) {
				case "Level 1 Rat boss": break;
				case "Level 2 Pirate boss": break;
				case "Level 3 boss squid bounty hunter": break;
				case "Level 4 Insectoid boss": break;
				case "Level 5 Slaver boss, lair": break;
				case "Level 7 boss squid assasnik": break;
				case "Level 9 boss, Shogar": break;
				case "Level 10 boss insectoid Calm Destruction": break;
				default: break;
			}
		}
		public static bool IsUpdatedTemplateShip(Ship bossShip) {
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
		//Detailed Ship Hover Info
		public string HoverText {
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
		//Ship Evasion Limit from Configuration & Reduced Evasion Bonus from Damaged Modules
		public int GetEvasion(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
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
		//Reduced Accuracy Bonus from Damaged Modules
		[MonoModReplace] public int GetAccuracy(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
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
		//Reduced Shield Capacity from Damaged Modules
		[MonoModReplace] public int GetMaxShieldPoints(Action<IHasDisplayNameLocalized, int> perProviderCallback) {
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
		//Enforce Ship Self-Destruct Timer
		[MonoModReplace] private void DoSelfDestruct() {
			bool isSelfDestructing = IsSelfDestructing;
			if (prevIsSelfDestructing != isSelfDestructing) {
				if (isSelfDestructing) selfDestructTimer.Restart(WorldRules.Instance.shipSelfDestructTime);
				prevIsSelfDestructing = isSelfDestructing;
			}
			if (!isSelfDestructing && prevIsSelfDestructing) selfDestructTimer.Restart(WorldRules.Instance.shipSelfDestructTime);
			if (isSelfDestructing && selfDestructTimer.Update(1f)) TakeDamage(int.MaxValue);
		}//Collections to List Fix
		[MonoModReplace] private void Update() {
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
		//All Modules Lootable (Depends on their Integrity)
		[MonoModReplace] private void LeaveLootModules() {
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
		//Remove Temporary Modifiers & Make Boss Weapons Useless
		[MonoModReplace] private static void DetatchModule(ShipModule module) {
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
		//Repair Door when clicking Left Mouse Button
		public void OnPointerClick(PointerEventData eventData) {
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
