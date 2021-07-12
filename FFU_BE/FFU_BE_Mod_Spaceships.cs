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
				if (FFU_BE_Defs.dumpObjectLists) Debug.Log($"Perk: [{perk.name}] ({perk.PrefabId}) {perk.displayName}");
				Perk.Pool[] temp_ExtraCrew = perk.extraCrew;
				Perk.Pool[] temp_ExtraModules = perk.extraModules;
				switch (perk.PrefabId) {
					//Universal Perks
					case 1828524155: //Perk add fuel
					perk.displayName = Core.TT($"Additional Starfuel Stash");
					perk.description = Core.TT($"Additional stash of starfuel provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 1636676426: //Perk add fuel 2, extra canisters
					perk.displayName = Core.TT($"Emergency Starfuel Backup");
					perk.description = Core.TT($"Emergency starfuel backup that we've prepared a long time ago, but eventually forgot about it. Good that now we've remembered about it.");
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
					case 1636676425: //Perk add fuel 3, passing ship
					perk.displayName = Core.TT($"Alliance Starfuel Supply");
					perk.description = Core.TT($"Starfuel supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.");
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
					case 1590596161: //Perk add organics 0
					perk.displayName = Core.TT($"Additional Organics Stash");
					perk.description = Core.TT($"Additional stash of organics provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 1672628015: //Perk add organics 2, increased nutrition
					perk.displayName = Core.TT($"Sumptuous & Luxurious Feast");
					perk.description = Core.TT($"Feast comparable to Manchu-Han Imperial Feast, made by locals to celebrate start of our great endeavor, whilst getting rid of our annoying presence.");
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
					case 1672628016: //Perk add organics 3, braindead
					perk.displayName = Core.TT($"Bionic Technology Remnants");
					perk.description = Core.TT($"Generously donated by unknown 3rd party to support our endeavor. They were probably trying to get rid of the evidence after their failed experiments.");
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
					case 945087461: //Perk add organics 5, dead animals
					perk.displayName = Core.TT($"Herd of Exotic Animals");
					perk.description = Core.TT($"We accidentally stumbled on a herd of wild animals and decided to turn them into space rations. During butchering we found out about their exotic nature.");
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
					case 430920595: //Perk add organics 1, houseplant
					perk.displayName = Core.TT($"Nitrocherry Tree Garden");
					perk.description = Core.TT($"Somebody before their death left their will that designated us as inheritors of garden full of nitrocherry trees. We happily accepted and reprocessed them.");
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
					case 75978646: //Perk add organics 4, dead insectoids
					perk.displayName = Core.TT($"Alliance Organics Supply");
					perk.description = Core.TT($"Organics supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.");
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
					case 798752091: //Perk add metals
					perk.displayName = Core.TT($"Additional Metals Stash");
					perk.description = Core.TT($"Additional stash of metals provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 1311577453: //Perk add metals 2, scrap tank
					perk.displayName = Core.TT($"Ruined Battle Fortress");
					perk.description = Core.TT($"Our scanning drones accidentally discovered Mobile Battle Fortress, but sadly we didn't have enough time to repair it before takeoff and had to melt it down into hefty stash of alloys.");
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
					case 1289207917: //Perk add synthetics
					perk.displayName = Core.TT($"Additional Synthetics Stash");
					perk.description = Core.TT($"Additional stash of synthetics provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 1019109695: //Perk add synthetics 2, broken lamp
					perk.displayName = Core.TT($"Fragmented Solar Furnace");
					perk.description = Core.TT($"Once these were a solar furnace used to supply entire planet with energy and heat, but now this only a fragments of the past glory. We've discovered them accidentally, when we were exploring some ancient ruins.");
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
					case 1312794238: //Perk add synthetics and fuel
					perk.displayName = Core.TT($"Enriched Tritium Rods");
					perk.description = Core.TT($"Found in one of the abandoned power plants that were used centuries ago. Unexpectedly, power plant was completely cleaned up with only these rods left untouched. They probably were too heavy to steal. Or too radioactive.");
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
					case 986856836: //Perk add synthetics 3, ex container
					perk.displayName = Core.TT($"Alliance Synthetics Supply");
					perk.description = Core.TT($"Synthetics supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.");
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
					case 153460441: //Perk add explosives
					perk.displayName = Core.TT($"Additional Explosives Stash");
					perk.description = Core.TT($"Additional stash of explosives provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 1491789515: //Perk add explosives 2, explo sculpture
					perk.displayName = Core.TT($"Alliance Explosives Supply");
					perk.description = Core.TT($"Explosives supply provided by Earth Alliance and the allies through hidden channels to aid us in our endeavor and fight against our eternal foe.");
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
					case 1585922370: //Perk add exotics
					perk.displayName = Core.TT($"Exotic Ur-Quanite Crystals");
					perk.description = Core.TT($"Were discovered floating in lower layers of the atmosphere during atmospheric reentry by the crewmember that was nostalgically reminiscing about good old classic games that were released centuries ago.");
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
					case 136575048: //Perk barter get exotics for credits
					perk.displayName = Core.TT($"Exotic Low Quality Ore");
					perk.description = Core.TT($"A months before takeoff we've managed to discover in one the excavated tunnels vein of low quality exotic ore. Sadly, only part of it found buyers. Rest of it had to be reprocessed.");
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
					case 1246169320: //Perk add exotics 2, broken sex toy
					perk.displayName = Core.TT($"Rare Exotic Contraption");
					perk.description = Core.TT($"Was accidentally discovered by one of the most curious crewmembers at some junkyard. Although we can only assume that this was some sort of a sex toy, we had no use for it and thus reprocessed it into marvelous amount of exotic matter.");
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
					case 28396574: //Perk barter get exotics for explosives
					perk.displayName = Core.TT($"Exotics-Infused Ammunition");
					perk.description = Core.TT($"Was discovered at one of the abandoned munitions factories. It was probably way too volatile and too unstable to steal as is. We had to spend some time to setup facilities to reprocess it into sumptuous amount of exotic matter.");
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
					case 1687140155: //Perk add credits
					perk.displayName = Core.TT($"Anonymous Xenodata Donation");
					perk.description = Core.TT($"Additional amount of credits provided by supporters of our endeavor. Supporters sent it anonymously.");
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
					case 83526129: //Perk barter get credits for explosives
					perk.displayName = Core.TT($"Hidden Rebel Supply Stash");
					perk.description = Core.TT($"As it seems we've discovered a hidden supply stash that was intended for the rebels. I'm pretty sure, if we will take it, nobody will be angry. We even will be the good ones who saved the day.");
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
					case 1722324010: //Perk add credits 2, personal savings
					perk.displayName = Core.TT($"Hacked Ancient Xenodata Vault");
					perk.description = Core.TT($"At one of the ancient archaeological sites we've discovered an untouched xenodata vault with priceless data. We've managed to bypass its protection due to the usage of centuries old encrypting algorithms in it.");
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
					case 1569517835: //Perk pack, medical resources
					perk.displayName = Core.TT($"Abandoned Artificer Stash");
					perk.description = Core.TT($"As it seems somebody was in a hurry (or didn't had enough free space in storage) and left these stashes to collect the dust. I think they will be more useful during our endeavor. And nobody needs them anyway.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(57217862) }}, //compressed exotics pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(57217862) }}, //compressed exotics pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(57217862) }}, //compressed exotics pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(57217862) }}, //compressed exotics pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(57217862) }}}; //compressed exotics pack
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case 1105713209: //Perk pack, organics
					perk.displayName = Core.TT($"Helpful Military Requisition");
					perk.description = Core.TT($"While we were stationed on this planet, we've made some connections with local representatives of different powers. When military representatives heard about our secret mission, they were more than happy to help us.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2025144458) }}, //general pack organics, synth, metal
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2025144458) }},	//general pack organics, synth, metal
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2025144458) }},	//general pack organics, synth, metal
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2025144458) }},	//general pack organics, synth, metal
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2025144458) }}}; //general pack organics, synth, metal
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 917843686: //Perk pack, 3xsolid starfuel from level7
					perk.displayName = Core.TT($"Supply Transport Wreckage");
					perk.description = Core.TT($"During planetary surface scan with our printed satellites we've discovered a centuries old spaceship wreckage. Although it was left undiscovered, time is an unbeatable foe and majority of intact supplies ended up being spoiled.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(453797399) }}, //fuel pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(453797399) }}, //fuel pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(453797399) }}, //fuel pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(813048445) }}, //explosives pack
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(813048445) }}}; //explosives pack
					perk.randomizerMenuStrings = new string[]{
						$"+3x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 1105381290: //Perk module DIY medbay
					perk.displayName = Core.TT($"Advanced Medical Bay Cache");
					perk.description = Core.TT($"Discovered at one of the abandoned and locked down medical facilities during exploration. Contains completely working and packed module, encrypted blueprint and some resources required to operate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(463896999) }}}; //medbay6 biological
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[] { 463896999 });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case 411849296: //Perk module medbay 202
					perk.displayName = Core.TT($"Universal Restoration Bay Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of destructive ion storms. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1304112764) }}}; //medbay4 stem celler
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[] { 1304112764 });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 484808345: //Perk crew 1 human adventurer
					perk.displayName = Core.TT($"Experienced Adventurer");
					perk.description = Core.TT($"A trustworthy adventurer offers credits for the opportunity to travel back to Earth with us. They wear an armored helmet and promise to bring along a cool handgun.");
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
					case 2060998335: //Perk crew best marine
					perk.displayName = Core.TT($"Tactical Marine Graduate");
					perk.description = Core.TT($"A marine with top grades from University of Tactical Land Warfare joins our mission. For the experience. They also carry a full set of live ammunition with them. Just in case.");
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
					case 936025880: //Perk crew human scientist
					perk.displayName = Core.TT($"Seasoned Quantum Physicist");
					perk.description = Core.TT($"A scientist joins the mission, to research an obscure topic of time travel, causality manipulation, how it affects the universe and related to the meaning of life. They bring along some exotic supplies.");
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
					case 141752450: //Perk crew 2 beedroid engineer
					perk.displayName = Core.TT($"Beedroid Engineer Veteran");
					perk.description = Core.TT($"An alien cyborg joins the mission to repay an old favor. The entire species of Beedroids have transcended their biological bodies. They also bring a full set of tools to perform repairs and modifications.");
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
					case 584291632: //Perk crew rat cook
					perk.displayName = Core.TT($"Proficient Rat Cook");
					perk.description = Core.TT($"This excellent Rat cook is also skilled in growing food and extinguishing fires. Both mastered during his years in the Rat Cooking University. They also bring along a set of precooked supplies.");
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
					case 2140969742: //Perk crew rat mercs -creds
					perk.displayName = Core.TT($"Ragtag Rat Mercenaries");
					perk.description = Core.TT($"A band of ragtag mercenary rats join the mission for ability feed themselves. The poor fellas had mediocre skills and do not have any body augments. They also bring along a set of low quality metals to maintain their weapons.");
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
					case 2036238841: //Perk crew gitchanki sensorist
					perk.displayName = Core.TT($"Inexperienced Gitchanki Astronomer");
					perk.description = Core.TT($"His regular lovers were a gang of female space marines who taught him everything about wrestling, handguns and ship sensors. They gave him some credits and sent him to adventure to get more life experience.");
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
					case 187729117: //Perk crew lizard firefighter
					perk.displayName = Core.TT($"Monk of Infinite Fire Temple");
					perk.description = Core.TT($"This old lizardfolk monk has improved fire resistance and firefighting skills due to years spent in the Temple of Infinite Fire. Likes to stay in the shower for hours. Has hobby of collecting exotic and volatile matter.");
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
					case 1581853207: //Perk crew grippy gunner
					perk.displayName = Core.TT($"Weaponry Ex-Specialist Grippy");
					perk.description = Core.TT($"This snake-individual used to serve in a military warship as a gunnery officer. Experienced in using all kinds of ship weapons. Regularly consumes a cocktail of intoxicants, always has hidden stash of explosives. Just in case.");
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
					case 142590729: //Perk crew gormor gardener
					perk.displayName = Core.TT($"Tranquil Gor-Mor Gardener");
					perk.description = Core.TT($"This Gor-Mor individual is a famous gardener-philosopher, praised highly by political leaders and spiritual acolytes who seek enlightenment. He wants to help us in exchange for allowing him to meditate in our greenhouses.");
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
					case 2075504578: //Perk augment 00a full checkup
					perk.displayName = Core.TT($"Full Diagnostics & Maintenance");
					perk.description = Core.TT($"Full testing of all ship components, modules and subroutines, and replacement of deprecated and faulty one ensures increased survivability of the ship and crew that uses it.");
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
					case 344652167: //Perk augment 00b evasive manuever dbase update
					perk.displayName = Core.TT($"Advanced Maneuvering Subroutines");
					perk.description = Core.TT($"Refurbishment and upgrade of built-in maneuvering systems will increase ship's chances to successfully evade incoming hostile fire and break-off from enemy targeting systems.");
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
					case 237545307: //Perk augment 00c impact dampeners
					perk.displayName = Core.TT($"Impact Dampening Armor Coating");
					perk.description = Core.TT($"An experimental armor coating that eventually fuses into armor and becomes part of it, while increasing its deflective properties against incoming enemy fire.");
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
					case 918962338: //Perk augment 00d tactical predictor
					perk.displayName = Core.TT($"Tactical Prediction Software");
					perk.description = Core.TT($"Almost universal software that requires no hardware upgrades. Increases accuracy of all on-board and built-in weapon system without any negative drawbacks and consequences.");
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
					case 780498261: //Perk augment 001a elastic augmentations
					perk.displayName = Core.TT($"Carbon Fiber Integrity Upgrade");
					perk.description = Core.TT($"Increases ship hull integrity by reinforcing ship's hardpoints and exposed inter-connectors with extremely durable carbon fibers that allow the ship to \"bend\" a little.");
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
					case 69059130: //Perk augment 001b exotic armor
					perk.displayName = Core.TT($"Composite Exotic-Infused Armor");
					perk.description = Core.TT($"Adds additional layer of composite exotic-infused armor over ship's hull that provides additional durability and increases overall integrity, thus increasing survivability of the ship.");
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
					case 2037439773: //Perk augment 02 Fortified subsections
					perk.displayName = Core.TT($"Segmented Armored Subsections");
					perk.description = Core.TT($"Complete rework of ship's interior. Replaces all standard subsection with heavily armored ones that follow strict segmentation standards to prevent uncontrolled decompression in cases of even extreme damage.");
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
					case 1577853994: //Perk augment 03 targeting software
					perk.displayName = Core.TT($"Combat Forensics Processing Units");
					perk.description = Core.TT($"An entire full set of new hardware that is integrated into the core systems of the ship and even partially replaces built-in targeting systems. Allows to analyze on the fly hostile ships behavior and perform necessary targeting corrections.");
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
					case 1913754090: //Perk augment 04 maneuvering jets
					perk.displayName = Core.TT($"Reinforced Maneuvering Thrusters");
					perk.description = Core.TT($"Replaces ship's original maneuvering thrusters and reaction control systems with more advanced and reinforced ones. Reinforced maneuvering thrusters and reaction control systems has much greater evasion capability due to enhanced durability.");
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
					case 82318717: //Perk augment 05 deflection
					perk.displayName = Core.TT($"Experimental Reflective Composite Armor");
					perk.description = Core.TT($"Completely replaces original ship armor with experimental reflective composite one. Due to its exotic nature, this armor has improved deflective properties that equally effective for deflection of projectiles and reflection of beams.");
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
					case 406945286: //Perk add permanent credits
					perk.displayName = Core.TT($"Detailed Spideraa Scientific Data");
					perk.description = Core.TT($"Scientific data about the Spideraa species is worth a lot of credits once we've obtained it. This information is quite dangerous, so we had to invest a lot of time and money into comprehensive background checks before deciding on a buyer.");
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
					case 1975921437: //Perk fate permanent 01 fortunate coincidence
					perk.displayName = Core.TT($"A Fortunate Coincidence");
					perk.description = Core.TT($"A fortunate coincidence helps you to prepare better for the upcoming journey.");
					perk.fateBonusInPerkSelection = 1 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 2;
					break;
					case 388240334: //Perk fate permanent 02 good luck
					perk.displayName = Core.TT($"The Good Luck");
					perk.description = Core.TT($"Somebody wished you good luck before the journey, and thanks to an unexpected series of events, their wish actually came true.");
					perk.fateBonusInPerkSelection = 2 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 4;
					break;
					case 1048034788: //Perk fate permanent 03 causal chain reaction
					perk.displayName = Core.TT($"The Causal Chain Reaction");
					perk.description = Core.TT($"Years ago, you helped somebody, changing their lives forever. It started a chain-reaction of events that led to somebody helping you today.");
					perk.fateBonusInPerkSelection = 3 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 6;
					break;
					case 873320189: //Perk fate permanent 04 generosity and abundance
					perk.displayName = Core.TT($"The Seeds of Generosity");
					perk.description = Core.TT($"By sowing the seeds of generosity in the past, you have arrived to the harvest of abundance in the present.");
					perk.fateBonusInPerkSelection = 4 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 8;
					break;
					case 117807373: //Perk fate permanent 05 friend of truth
					perk.displayName = Core.TT($"The Friend of Truth");
					perk.description = Core.TT($"Awareness of your personal limitations has granted you an even deeper awareness of your freedom.");
					perk.fateBonusInPerkSelection = 5 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 1109573451: //Perk fate permanent 06 focused one
					perk.displayName = Core.TT($"The Focused One");
					perk.description = Core.TT($"You understand something so deeply that it allows you to understand everything a bit better than individuals usually do.");
					perk.fateBonusInPerkSelection = 6 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 12;
					break;
					case 1840253454: //Perk fate permanent 07 masterful exister
					perk.displayName = Core.TT($"The Masterful Exister");
					perk.description = Core.TT($"Random coincidences seem to support the fulfillment of your wishes more than what is usually considered normal.");
					perk.fateBonusInPerkSelection = 7 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 14;
					break;
					case 2098263678: //Perk fate permanent 08 the great peace
					perk.displayName = Core.TT($"The Great Peace");
					perk.description = Core.TT($"You're starting to realize your intimate connection with the Great Peace, remaining calm even in situations of utter distress.");
					perk.fateBonusInPerkSelection = 8 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 16;
					break;
					case 786995751: //Perk fate permanent 09 optimality
					perk.displayName = Core.TT($"The Optimality");
					perk.description = Core.TT($"You are in the right place, at the right time and under the right circumstances.");
					perk.fateBonusInPerkSelection = 9 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 18;
					break;
					case 361125977: //Perk fate permanent 10 victory
					perk.displayName = Core.TT($"The Taste of Victory");
					perk.description = Core.TT($"Those who know what awaits at the end of the road can enjoy the road itself better. And you are such person.");
					perk.fateBonusInPerkSelection = 10 * FFU_BE_Defs.permanentFateMult;
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.fateBonusInPerkSelection} {Core.TT("Fate Points on Next Run")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case 326598807: //Perk module drone repair bay
					perk.displayName = Core.TT($"Advanced Drone Bay Cache");
					perk.description = Core.TT($"Discovered at one of the abandoned and locked down maintanance facilities during exploration. Contains completely working and packed module, encrypted blueprint and some resources required to operate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(2500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(383658151) }}}; //dronebay 1 basic
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"+{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case 1108785668: //Perk drone 00 smallbot
					perk.displayName = Core.TT($"Swearing Bot Drone Crew");
					perk.description = Core.TT($"A small toy drone and its useful drone crew. Knows vulgar words in all human languages & draws fire from intruders during internal combat, while all its friends do proper work it is uncapable of.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1349473499) }}, //Drone pet
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(791329320) }}, //Drone DIY firesafety
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(229081020) }}, //Drone DIY repairer
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(421109168) }}, //Drone DIY science
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1179088392) }}}; //Drone DIY sensor
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Swearing")} {Core.TT("Drone")} {Core.TT("Pet")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Fire Safety")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Repair")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Research")} {Core.TT("Drone")}",
						$"+1x {Core.TT("Makeshift")} {Core.TT("Sensor")} {Core.TT("Drone")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1425666963: //Perk drone 01 DIY fire safety
					perk.displayName = Core.TT($"Basic Combat Drones");
					perk.description = Core.TT($"A set of light walker chassis drones with built-in weaponry and friend/foe identification system to take care of uninvited intruders that decided to come into your ship. Do not expect much from their caterpillar-based AI.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1559583687) }}, //Drone DIY guard
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1559583687) }}, //Drone DIY guard
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1559583687) }}, //Drone DIY guard
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1559583687) }}}; //Drone DIY guard
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 124153277: //Perk drone 02 DIY guard
					perk.displayName = Core.TT($"Basic Gunnery Drones");
					perk.description = Core.TT($"A set of light walker chassis drones with improved ship-to-ship targeting and interfacing systems that allow to operate weaponry of your ship. Do not expect much from their scorpion-based AI.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1589791427) }}, //Drone CT2 gunnery
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1589791427) }}, //Drone CT2 gunnery
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1589791427) }}, //Drone CT2 gunnery
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1589791427) }}}; //Drone CT2 gunnery
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Weapon Operator")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1599767297: //Perk drone 03 DIY repairbot
					perk.displayName = Core.TT($"Basic Maintenance Drones");
					perk.description = Core.TT($"A set of light walker chassis drones with improved repairing and firefighting capabilities that allow to maintain ship operational and working. Do not expect much from their beetle-based AI.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1444414821) }}, //Drone CT1 maintenance
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1444414821) }}, //Drone CT1 maintenance
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1444414821) }}, //Drone CT1 maintenance
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1444414821) }}}; //Drone CT1 maintenance
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Maintenance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1406333136: //Perk drone 04 fire safety x2
					perk.displayName = Core.TT($"Basic Research Drones");
					perk.description = Core.TT($"A set of light walker chassis drones with improved calculation and analysis capabilities that allow to perform basic research and data analysis. Do not expect much from their octopus-based AI.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(421109168) }},	 //Drone DIY science
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(421109168) }},	 //Drone DIY science
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(421109168) }},	 //Drone DIY science
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(421109168) }}}; //Drone DIY science
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Research")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 755906886: //Perk drone 05 gardening and repair
					perk.displayName = Core.TT($"Heavy Maintenance Drones");
					perk.description = Core.TT($"A set of heavy quadruple walker chassis drones with advanced repairing and firefighting capabilities that allow to maintain ship operational and working. In addition, they're absolutely resistant to fire.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}, //Drone tigerspider
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}, //Drone tigerspider
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}, //Drone tigerspider
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}}; //Drone tigerspider
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case 1559698830: //Perk drone 06 DIY gunnery
					perk.displayName = Core.TT($"Tactical Combat Drones");
					perk.description = Core.TT($"A set of extremely versatile walker chassis drones with state of art tactical AI and software that allows them imitate operational capabilities of the living crew. In addition, they're absolutely resistant to fire.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }},	 //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }},	 //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }},	 //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}}; //Combat Drone Humanoid
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case 1559119211: //Perk drone 07 gunnery and repair
					perk.displayName = Core.TT($"Heavy Security Drones");
					perk.description = Core.TT($"A set of extremely armored walker chassis drones with state of art combat AI and unholy load of weapons that allows them to eradicated everything in their path. In addition, they're absolutely resistant to fire.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }},	 //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }},	 //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }},	 //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}}; //Heavy security drone
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case 136621601: //Perk drone 08 DIY sentry tank
					perk.displayName = Core.TT($"Armored Assault Drones");
					perk.description = Core.TT($"A set of threaded and extremely armored chassis drones with great combat AI, decent weapons and unholy amount of armor comparable to the bona fide tank. In addition, they're absolutely resistant to fire.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(745155399) }},	 //Drone DIY gunjunker
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(745155399) }},	 //Drone DIY gunjunker
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(745155399) }},	 //Drone DIY gunjunker
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(745155399) }}}; //Drone DIY gunjunker
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Armored Assault")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 20;
					break;
					case 1821549491: //Perk module artifact, nontech
					perk.displayName = Core.TT($"Huge Assault Weapons Stash");
					perk.description = Core.TT($"Accidental discovery of the underground entrance led us to the bunker that had left some assault weapons stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }},	//artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }},	//artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }},	//artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }},	//artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}}; //artifactmodule tec 35 data core makk
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 907839204: //Perk module artifact, tech
					perk.displayName = Core.TT($"Huge Mechanical Upgrades Stash");
					perk.description = Core.TT($"Accidental discovery of the underground entrance led us to the bunker that had left some mechanical upgrades stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}}; //artifactmodule tec 33 biostasis nice worm
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 522883132: //Perk module artifact, worm stasis
					perk.displayName = Core.TT($"Huge Biological Implants Stash");
					perk.description = Core.TT($"Accidental discovery of the underground entrance led us to the bunker that had left some biological stashed away. As it seems this bunker was abandoned not so long ago and in a hurry.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}}; //artifactmodule tec 11 biostasis
					perk.randomizerMenuStrings = new string[]{
						$"+5x {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.isUnlockedByDefault = false;
					perk.repCost = 10;
					break;
					case 989922131: //Perk module artifact, data core
					perk.displayName = Core.TT($"Efficient Industrial Facility Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in ancient manufacturing complex full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1363987393, 1482294420) }}}; //explosives combinator tiger //fuel processor 2
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 872216984: //Perk module DIY cryosleep
					perk.displayName = Core.TT($"Medical Cryosleep Bay Cache");
					perk.description = Core.TT($"Discovered at one of the abandoned and locked down cryogenic facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(703894034) }}}; //cryosleep 3x medical
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case 209451390: //Perk module DIY cryodream recorder
					perk.displayName = Core.TT($"Military Cryosleep Bay Cache");
					perk.description = Core.TT($"Discovered at one of the abandoned and locked down cryogenic facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2059107150) }}}; //cryosleep 8x insect
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 15;
					break;
					case 16054811: //Perk module lovers cryosleep
					perk.displayName = Core.TT($"Exploration Cryodream Bay Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of raging radiation emissions. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(41460892) }}}; //cryosleep 6x human standard
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1002977681: //Perk module DIY garden
					perk.displayName = Core.TT($"Replicator Greenhouse Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hazardous location full of hostile carnivorous and toxic plants. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(728608876) }}}; //garden 4 greenhouse
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1610304684: //Perk module minigrowery
					perk.displayName = Core.TT($"Exogenetic Greenhouse Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hazardous location full of unstable and volatile exotic elements. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(737359377) }}}; //garden 6 synthethics
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1983487017: //Perk module DIY lab
					perk.displayName = Core.TT($"Quantum Laboratory Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in hazardous experimental facility full of man-made horrors and abominations. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1448350571) }}}; //lab 1xgood
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 450353830: //Perk module DIY sensor
					perk.displayName = Core.TT($"Multi-Phased Sensor Array Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hostile location full of constant firestorms and solar flares. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(171954197) }}}; //sensor 9 sunpanel new s2
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1860396564: //Perk module DIY backup warpdrive
					perk.displayName = Core.TT($"Quantum Warp Drive Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely anomalous location full of destructive temporal fluctuations. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1559705412) }}}; //warp 07 rotor glass
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 600376461: //Perk module DIY bridge
					perk.displayName = Core.TT($"Sturdiest Command Bridge Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in ancient ruined dreadnought full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1148319565) }}}; //bridge 3crew metalarmor
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 996292804: //Perk module DIY random nonweapon
					perk.displayName = Core.TT($"Heavy Ion Reactors Cache");
					perk.description = Core.TT($"We've managed to receive completely working and packed modules along with reverse engineerable encrypted blueprint as commission from Earth Alliance right before takeoff.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(549367690) }}, //reactor 13 classic cooled
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(549367690) }}}; //reactor 13 classic cooled
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					if (!storedPerkSprites.ContainsKey("Leftover_Module_Sprite")) storedPerkSprites.Add("Leftover_Module_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case 1920833206: //Perk module DIY reactor
					perk.displayName = Core.TT($"Heavy Bio-Reactors Cache");
					perk.description = Core.TT($"Discovered at one of the abandoned and locked down experimental energy development facilities during exploration. Contains completely working and packed module, and reverse engineerable encrypted blueprint.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2093337887) }}, //reactor 20 biofruit
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2093337887) }}}; //reactor 20 biofruit
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 35;
					break;
					case 1809779126: //Perk module decommissioned DIY reactors x2
					perk.displayName = Core.TT($"Antimatter Reactors Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in extremely hostile location full of constant plasma and meteor storms. The only reason this cache was left intact is extremely protected bunker, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1699316752) }},	//reactor 22 cube
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1699316752) }}}; //reactor 22 cube
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 1607974324: //Perk module decommissioned DIY ecms x3
					perk.displayName = Core.TT($"Quantum ECM Array Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned fortress full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(738383846) }}}; //ECM 03 terran
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1860627745: //Perk module DIY integrity
					perk.displayName = Core.TT($"Experimental Integrity Armor Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned spaceship docks full of volatile active nanomachines. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1196638242, 786297539, ShipModule.Type.Integrity) }}}; //integrity tiger //integrity 00 Ratty
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1993735695: //Perk module DIY integrity 2
					perk.displayName = Core.TT($"High-Tech Shield Capacitor Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned shield technology research center full of destructive dimensional fluctuations. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1424188745, 1179432425, ShipModule.Type.ShieldGen) }}}; //shieldbat tiger //shieldbat 3 generic alien
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 450636944: //Perk module integrity 3
					perk.displayName = Core.TT($"High-Tech Shield Generator Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned shield technology research center full of destructive dimensional fluctuations. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1427874574, 1386797426, ShipModule.Type.ShieldGen) }}}; //shield tigership //shield 4 solitary
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 131783302: //Perk module container MS1
					perk.displayName = Core.TT($"Phased Stealth Generator Cache");
					perk.description = Core.TT($"We had to give an arm and a leg to acquire this module cache, literally. It was discovered in abandoned fortress full of active hostile defense systems. The only reason this cache was left intact is extremely protected compartment, where it was found.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1276182160) }}}; //Stealth decryptor 3 newest human tec
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 25;
					break;
					case 1506790699: //Perk module EOME container
					perk.displayName = Core.TT($"Capital Storages Manufacturing Cache");
					perk.description = Core.TT($"We've found an official dealer that is ready to sell us a complete working set of storage containers and manufacturing license, along with blueprints. However, we still need to research blueprints, before we can manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(426751082) }}}; //multicontainer ESM-2
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().PrefabId });
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
					case 174917737: //Perk module DIY point-defence
					perk.displayName = Core.TT($"Top of the Line CIWS Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of top of the line CIWS, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(938711464) }}, //2 Tiger PD
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(938711464) }}}; //2 Tiger PD
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("CIWS_DIY_Sprite")) storedPerkSprites.Add("CIWS_DIY_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 225180168: //Perk module DIY weapon
					perk.displayName = Core.TT($"Advanced Kinetic Weapons Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly advanced kinetic weapons, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(412909021, 1086561640, ShipModule.Type.Weapon) }}, //weapon gatling Tiger //weapon Segmented cannonx2 C
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(412909021, 1086561640, ShipModule.Type.Weapon) }}}; //weapon gatling Tiger //weapon Segmented cannonx2 C
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Random_Module_Sprite")) storedPerkSprites.Add("Random_Module_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 22277590: //Perk module Rat weapon for exotics
					perk.displayName = Core.TT($"Overloaded Energy Weapons Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly advanced energy howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}, //weapon EMP energyball 3x Tiger //weapon rare warp shield breaker EMP
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}}; //weapon EMP energyball 3x Tiger	//weapon rare warp shield breaker EMP
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Imperial_Crate_Sprite")) storedPerkSprites.Add("Imperial_Crate_Sprite", perk.menuSprite);
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 633108626: //Perk module weapon bank missile x2
					perk.displayName = Core.TT($"Volatile Rocket Launchers Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly volatile rocket launchers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1571322820, 469527491, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon ancientrockets x3
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1571322820, 469527491, ShipModule.Type.Weapon) }}}; //weapon tigermissile large //weapon ancientrockets x3
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 1252646026: //Perk module DIY exotic raygun 2
					perk.displayName = Core.TT($"Exotic Relic Disintegrator Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly advanced exotic disintegrator, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(452279033) }}, //weapon rarelasergothic
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(452279033) }}}; //weapon rarelasergothic
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Disintegrator"," Dstg.")}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Disintegrator"," Dstg.")} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 1260454991: //Perk nuke arsenal DIY
					perk.displayName = Core.TT($"Extremely Corrosive Howitzer Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly advanced corrosive howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(790917823) }}, //weapon Floral cannon
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(790917823) }}}; //weapon Floral cannon
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					//Unused Perks
					case 2106414951: //Perk TESTER PACKAGE
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = Core.TT($"Exotic Antimatter Howitzer Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of highly advanced antimatter howitzers, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1983239915) }},	//weapon exoticscannon1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1983239915) }}}; //weapon exoticscannon1
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Howitzer"," Hwtz.")}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Howitzer"," Hwtz.")} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 305450922: //Perk nuke thinspeeder for atlas, unlockable
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = Core.TT($"Cataclysm Capital Missiles Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working pack of capital missiles of all types, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1851270005) }}, //Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1851270005) }}, //Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776, 342953834, ShipModule.Type.Weapon_Nuke) }}, //Tiger 8x nuke launcher //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776, 342953834, ShipModule.Type.Weapon_Nuke) }}, //Tiger 8x nuke launcher //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(22001514) }}, //08c Green nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(22001514) }}, //08c Green nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966, 1043100994, ShipModule.Type.Weapon_Nuke) }}, //Tiger intruderbot nuke launcher //99 pirate spawner launcher 1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966, 1043100994, ShipModule.Type.Weapon_Nuke) }}, //Tiger intruderbot nuke launcher //99 pirate spawner launcher 1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1558344950) }}, //15 Black nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1558344950) }}}; //15 Black nuke launcher
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[8].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[10].Prefabs[0].GetComponent<ShipModule>().PrefabId,
						perk.extraModules[12].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+14x {Core.TT("Packed Nukes (2x Each) & Blueprints")}: " +
							$"{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[8].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)}, " +
							$"{perk.extraModules[10].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)} {Core.TT("and")} " +
							$"{perk.extraModules[12].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Nuke", string.Empty)} {Core.TT("Nukes")}.",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = GetPrefabIDModuleGO(1043100994).GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 100;
					break;
					case 152890152: //Perk pack, random
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = Core.TT($"Forge World Thermal Weapons Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of thermal weapons acquired directly from the forge world, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1322541741) }},	//weapon Heatray emitter x red
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1322541741) }}}; //weapon Heatray emitter x red
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector"," Proj.")}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Projector"," Proj.")} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 2073380488: //Perk module DIY shield battery
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = Core.TT($"Illegal Radiation Weapons Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of illegal radiation weapons created, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1238435842) }},	//weapon BFGx9 for bluestar
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1238435842) }}}; //weapon BFGx9 for bluestar
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Accelerator"," Accl.")}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Accelerator"," Accl.")} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					case 1248482139: //Perk Replace 5x mininglasers with6x, for Gardenship
					FFU_BE_Defs.unusedPerkIDs.Add(perk.PrefabId);
					perk.displayName = Core.TT($"Overclocked Beam Emitter Cache");
					perk.description = Core.TT($"We've found a black market dealer that is ready to sell us a working set of extremely overclocked beam emitters, along with encrypted blueprints for hefty amount of exotics. Given enough time for research, we will be able to manufacture them on our own.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(849984806) }}, //weapon Insectoid slowlaser
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(849984806) }}}; //weapon Insectoid slowlaser
					if (!FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perk.PrefabId)) FFU_BE_Defs.perkStoredBlueprintIDs.Add(perk.PrefabId, new int[]{
						perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().PrefabId });
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName} {Core.TT("Blueprint")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = false;
					perk.repCost = 50;
					break;
					//Tigerfish Perks
					case 1512794172: //Perk module DIY exotic raygun
					perk.displayName = Core.TT($"Recovered Exotic Disintegrator");
					perk.description = Core.TT($"Right before takeoff, we've managed to restore to the working condition one of the exotic ray weapons, we've found earlier.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(68261259) }}}; //weapon rarelaserblue2 dual
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Disintegrator"," Dstg.")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 566836399: //Perk Replace Industrial lasers with MK2
					perk.displayName = Core.TT($"Advanced Industrial Mining Upgrade");
					perk.description = Core.TT($"This was last a day purchase that allowed us to replace our original industrial lasers with more advanced versions and smaller XSM storage container with a bigger one.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(306184113) }, //weapon tigerlaser MK1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(306184114) }}, //weapon tigerlaser MK2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1008150789) }, //multicontainer ESM-1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}}; //multicontainer ESM-2
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1555035434: //Perk nuke Tigerfish
					perk.displayName = Core.TT($"Remote Mining Charges Stash");
					perk.description = Core.TT($"A surplus stash of remote mining charges converted into deadly nukes. Was sold at extremely low price at nearest unofficial supplier of industrial machinery.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}, //06 Tiger nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}, //06 Tiger nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}, //06 Tiger nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}, //06 Tiger nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}, //06 Tiger nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(157230770) }}}; //06 Tiger nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1447363940: //Perk nuke DIY random
					perk.displayName = Core.TT($"Capital Missiles Requisition");
					perk.description = Core.TT($"An official requisition of military-grade capital missiles from Earth Alliance for symbolic amount of credits that were used as transportation fee at very most.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696, 1441404901, ShipModule.Type.Weapon_Nuke) }}, //Tiger Monolith nuke launcher //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696, 1441404901, ShipModule.Type.Weapon_Nuke) }}, //Tiger Monolith nuke launcher //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764, 1773946856, ShipModule.Type.Weapon_Nuke) }}, //Tiger EMP dual nuke launcher //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764, 1773946856, ShipModule.Type.Weapon_Nuke) }}, //Tiger EMP dual nuke launcher //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825, 475763260, ShipModule.Type.Weapon_Nuke) }}, //Tiger sharpnel nuke launcher //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825, 475763260, ShipModule.Type.Weapon_Nuke) }}}; //Tiger sharpnel nuke launcher //07 Weirdship Chem nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Random_Nuke_Sprite")) storedPerkSprites.Add("Random_Nuke_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1565459393: //Perk module DIY explo combinator, to 3ships
					perk.displayName = Core.TT($"Advanced Industrial Module Deal");
					perk.description = Core.TT($"A cache with freshly manufactured and neatly packed improved industrial module sold by official dealer for acceptable price. Has decent features and moderate conversion efficiency.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(373200662) }}}; //synthetics cooker 1
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1783804007: //Perk module synth cooker, to tigerfish
					perk.displayName = Core.TT($"Emergency Industrial Module Deal");
					perk.description = Core.TT($"A cache with freshly manufactured and neatly packed basic industrial module sold by official dealer for acceptable price. Doesn't have much features and efficiency, but rather durable.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-2500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(166404798) }}}; //oilcake converter
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1114131722: //Perk Replace shield 2old
					perk.displayName = Core.TT($"Fusion Shield Modules Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed shield generation and capacity modules sold by official dealer for acceptable price. Contains fusion shield generator and fusion shield capacitor.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1967967252) }}, //shield 3 threespace
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(911395348) }}}; //shieldbat 2 terran
					perk.moduleReplacements = new Perk.ModuleReplacement[0];
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1908150008: //Perk Replace terran smallreactor old
					perk.displayName = Core.TT($"Energy Systems Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older reactors of the ship with newer reactors available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(482395317) }, //reactor 4 diy 1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1700526886) }, //reactor 5 diy 2 backup
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(482395319) }, //reactor 7 diy 3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(833760257) }, //reactor 6 smalltrapho
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1796369958) }, //reactor 8 smallmulty
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(45764579) }, //reactor 9 biotech DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1554868377) }, //reactor 9 small old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(813614528) }, //reactor 10 small
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1088784368) }, //reactor 11 single biofruit DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1939016857) }, //reactor 12 custom old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(694263055) }, //reactor 13 single biofruit
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1515340139) }, //reactor 13 rats
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(549367690) }, //reactor 13 classic cooled
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}}; //reactor 15 medium
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1524517897: //Perk Replace combat sensor old with new
					perk.displayName = Core.TT($"Utility Systems Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older utility modules of the ship with newer utility modules available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(930742757) }, //sensor 0-C diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2063928716) }}, //sensor 4 saucer new
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2117018739) }, //sensor 1-L DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2063928716) }}, //sensor 4 saucer new
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(948524677) }, //sensor 2 saucer old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2063928716) }}, //sensor 4 saucer new
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1084722255) }, //sensor 3 L terran simple
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2063928716) }}, //sensor 4 saucer new
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1995820130) }, //sensor 3 planty
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2063928716) }}, //sensor 4 saucer new
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2136288774) }, //warp 0 DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2005632838) }, //warp 05 spiralcrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1622263161) }, //warp 02 bluecrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(458296297) }, //warp 03 neoncrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}}; //warp 05 rotor metal
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[5].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 858785858: //Perk drone for Tigerfish
					perk.displayName = Core.TT($"Additional Drone Crew Support");
					perk.description = Core.TT($"Additional set of all kinds of drones to delegate majority of routine work to autonomous machines. Was honestly acquired through official Earth Alliance channels due to reaching expiration date.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}, //Drone tigerspider
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1481089982) }}, //Drone tigerspider
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }},	 //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }},	 //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}}; //Heavy security drone
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Heavy Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Nuke Runner Perks
					case 883360183: //Perk Replace sniper2 with sniper3
					perk.displayName = Core.TT($"Precision Weapon Upgrade");
					perk.description = Core.TT($"Permitted military acquisition of an upgraded precision weapons from the official supplier. Was possible only due to the crewmembers' deep connections with military.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1499937036) }, //weapon Sniper cannon 2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1567764648) }}}; //weapon sniper cannon EMP
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1819699687: //Perk Replace lasers for Nuke Runner
					perk.displayName = Core.TT($"Energy Weapon Upgrade");
					perk.description = Core.TT($"Permitted military acquisition of an upgraded precision energy from the official supplier. Was possible only due to the crewmembers' deep connections with military.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1860805838) }, //weapon powerbeam-MK1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(876121604) }}}; //weapon powerbeam-MK3
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1734489161: //Perk Replace autogatling with better one, for Nukerunner
					perk.displayName = Core.TT($"Suppression Weapon Upgrade");
					perk.description = Core.TT($"Permitted military acquisition of an upgraded suppression weapons from the official supplier. Was possible only due to the crewmembers' deep connections with military.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-500);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1092529672) }, //weapon gatling whiteA 13,4
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(698348090) }}}; //weapon Sniper cannon 4
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 6974583: //Perk nuke arsenal for SP33
					perk.displayName = Core.TT($"Planetary Bombardment Arsenal");
					perk.description = Core.TT($"A complete arsenal of a military-grade strategic capital missiles that can be used to bomb any single planet into complete oblivion. It was acquired when we signed a very-ethical-use-only declaration and paid additional fees.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }},	//10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}}; //10 White nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+12x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1995216412: //Perk module oilcake organics converter
					perk.displayName = Core.TT($"Complex Industrial Module Deal");
					perk.description = Core.TT($"A cache with freshly manufactured and neatly packed advanced industrial module sold by official dealer for acceptable price. Rather efficient and has many features, but most important - armored as nuclear bunker.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1615170861) }}}; //explosives combinator 1
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1138940531: //Perk crew top cadet
					perk.displayName = Core.TT($"Excellent Tactical Marines Team");
					perk.description = Core.TT($"Due to nature of our endeavor and military connections, this team of excellent tactical marines from best academy were willing to escort us through the dangers to gain hands-on experience and small payment.");
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
					case 1504797922: //Perk drone 09 light sec
					perk.displayName = Core.TT($"Tactical Drones Primary Set");
					perk.description = Core.TT($"A primary set of military tactical drones that will assist with daily operations of the ship, along with boarding and defensive actions.");
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
					case 161683945: //Perk drone 09b tactical sec
					perk.displayName = Core.TT($"Tactical Drones Secondary Set");
					perk.description = Core.TT($"A secondary set of military tactical drones that will assist with daily operations of the ship, along with boarding and defensive actions.");
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
					case 1984849323: //Perk drone 09c Sentinel sec
					perk.displayName = Core.TT($"Security Drones Boarding Party");
					perk.description = Core.TT($"A complete squad of heavy security drones modified for advanced boarding and defensive operations. Drones were upgraded with military-grade hardware as well.");
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
					case 2114506397: //Perk Replace Rat firecannon1 with 2
					perk.displayName = Core.TT($"Specialized Armaments Upgrade");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older specialized weapons of the ship with newer weapons of similar type available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1662502911) }, //weapon ratcannon fire1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(499703497) }}, //weapon ratcannon fire3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1281020726) }, //weapon ratlaser short
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1447130390) }}}; //weapon ratlaser long
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1794605234: //Perk Replace Rat gatling cannon
					perk.displayName = Core.TT($"Ballistic Armaments Upgrade");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older ballistic weapons of the ship with newer weapons of similar type available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(704483685) }, //weapon gatling RatA 14,4
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(123083978) }}}; //weapon gatling RatB 15,5
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 2033479731: //Perk nuke diy decoy for Rogue Rat
					perk.displayName = Core.TT($"Decommissioned Electromagnetic Nukes");
					perk.description = Core.TT($"Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with greatly improved electromagnetic payload.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}, //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}, //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}, //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}, //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}, //16 EMP rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1773946856) }}}; //16 EMP rat nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1042155144: //Perk nuke Rat DIY incendiary
					perk.displayName = Core.TT($"Decommissioned Strategic Nukes");
					perk.description = Core.TT($"Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with high-performance nuclear payload.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}, //08b Old nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}, //08b Old nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}, //08b Old nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}, //08b Old nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}, //08b Old nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(415755100) }}}; //08b Old nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 746099772: //Perk nuke Rat incendiary for Rogue Rat
					perk.displayName = Core.TT($"Decommissioned Incendiary Nukes");
					perk.description = Core.TT($"Widespread corruption in the Rat Empire ensures that everything is available for a price. Including these \"decommissioned\" capital missiles with advanced incendiary payload.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}, //09 Rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}, //09 Rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}, //09 Rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}, //09 Rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}, //09 Rat nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(787880682) }}}; //09 Rat nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 203859815: //Perk add explosives for Ratship
					perk.displayName = Core.TT($"Abandoned Explosives Storage");
					perk.description = Core.TT($"Explosives are abundant in the Rat Empire, and can be obtained quite easily. We've found a huge storage of explosives that was abandoned long ago and took what we could.");
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
					case 1890494450: //Perk module old random
					perk.displayName = Core.TT($"Corrupted Rat Empire Official Deal");
					perk.description = Core.TT($"A shady deal with corrupted rat empire official for a meager amount of exotics allows us to upgrade majority of ship's modules to much higher grade modules acquired through not so official channels.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(194638103) }}}; //fuel processor 1B
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(74390932) }, //shieldbat 3 gmo biotech
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1094609544) }}, //shieldbat 5 floral
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1494179234) }, //shieldbat 1.5 rats diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1750659454) }}, //shieldbat 2 rats
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(813097155) }, //shield 3 brass, single
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1646813987) }}, //shield 4 greendome
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(60711451) }, //shield 2 manualrats
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(813097155) }}, //shield 3 brass, single
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1995820130) }, //sensor 3 planty
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1241054343) }}, //sensor 5 futu saucer s1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(948524677) }, //sensor 2 saucer old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1451617742) }}, //sensor 8 sunpanel old s1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1027857851) }, //lab rats x3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1863175212) }}, //lab module x3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(694263055) }, //reactor 13 single biofruit
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(433363694) }}, //reactor 17 flower
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1939016857) }, //reactor 12 custom old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1515340139) }}, //reactor 13 rats
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2059107150) }, //cryosleep 8x insect
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(41460892) }}, //cryosleep 6x human standard
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(623034016) }, //cryosleep 3x rats armor
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2059107150) }}, //cryosleep 8x insect
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2005632838) }, //warp 05 spiralcrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(458296297) }}, //warp 03 neoncrystal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(458296297) }}, //warp 03 neoncrystal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1832274586) }, //garden 3 shroomery
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1863175212) }}, //lab module x3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1018033786) }, //dream recorder 1 rats
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1484543824) }}}; //dream recorder 4x weird biotech
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Reactors & Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensors & Laboratories")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Cryosleep & Cryodream Bays")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Shield Generators & Capacitors")} {Core.TT("Upgrade")}",
						$"+1x {Core.TT("Packed")} {Core.TT("Emergency Industrial Module")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Deal_Handshake_Sprite")) storedPerkSprites.Add("Deal_Handshake_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case 283158951: //Perk augment, jet tubing cleanup for Ratship
					perk.displayName = Core.TT($"Thrusters Exhaust Refurbishment");
					perk.description = Core.TT($"Full refurbishment of ship's thrusters exhaust tubes. Significantly increases thrust power ship-wide and as result boost maneuvering capabilities of the ship.");
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
					case 1688834803: //Perk Replace engines with rat engines for rogue rat
					perk.displayName = Core.TT($"Engine Systems Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older engines and thrusters of the ship with newer engines and thrusters available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1284816050) }, //engine 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1364709951) }, //engine 01 brittle
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(497175846) }, //engine 01 primitive
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1708644704) }, //engine 2 rats
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(533178690) }, //engine 2.5 classic
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(245228012) }, //engine 2 floral
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(362626339) }, //engine 01 tiger
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}, //engine 2.5 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(229499087) }, //engine 2.5 weird
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }}}; //engine 2.5 terran
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1744683542: //Perk crew warrior princess x2
					perk.displayName = Core.TT($"Twin Insectoid Warrior Princesses");
					perk.description = Core.TT($"A pair of invertebrate mercenaries join our mission to feed their family of hundreds. A young insectoid princesses of a minor hive must survive 10 years of mercenary life before they can ascend into royal politics.");
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
					case 1511793584: //Perk module weapon Spideraa Shuriken
					perk.displayName = Core.TT($"Flechette Chemical Railguns Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed weapon modules sold by official dealer for acceptable price. Contains pack of specialized anti-personnel flechette chemical railguns.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(985673324) }}, //weapon Spideraa shuriken
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(985673324) }}}; //weapon Spideraa shuriken
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1092748221: //Perk nuke bio
					perk.displayName = Core.TT($"Deathspore Boarding Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of specialized boarding and breaching capital missiles.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}, //07 Weirdship Minibio nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}, //07 Weirdship Minibio nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}, //07 Weirdship Minibio nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}, //07 Weirdship Minibio nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}, //07 Weirdship Minibio nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(141822690) }}}; //07 Weirdship Minibio nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 611909834: //Perk nuke bio 2 greentail
					perk.displayName = Core.TT($"Biotic Spike Kinetic Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of specialized hull perforation kinetic impactor capital missiles.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}, //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}, //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}, //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}, //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}, //07 Greentail nuke launcher 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1441404901) }}}; //07 Greentail nuke launcher 2
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 817992879: //Perk module Decoy Set x 3
					perk.displayName = Core.TT($"Farmland Greenhouses Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed greenhouse modules sold by official dealer for acceptable price. Contains pack of high-tier greenhouse modules that will supply ship with organics during travel.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1579035116) }}, //garden 5 greenhouse
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1579035116) }}}; //garden 5 greenhouse
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1960274027: //Perk artifact skull for Weirdship
					perk.displayName = Core.TT($"Storage Modules Upgrade");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older storage modules of the ship with newer storage modules of similar type available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(168523420) }, //exotics container 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1140021200) }, //fuel container 1 bio
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}}; //multicontainer FEO-1
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1904910966: //Perk module green integrity for weirdship
					perk.displayName = Core.TT($"Engine Systems Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older engines and thrusters of the ship with newer engines and thrusters available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(245228012) }, //engine 2 floral
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(229499087) }}}; //engine 2.5 weird
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 28205014: //Perk module integrity blue scales, unlockable for weirdship
					perk.displayName = Core.TT($"Dragonscale Integrity Armors Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed integrity armors sold by official dealer for acceptable price. Contains pack of quality integrity armors that will greatly boost survivability of the ship and its crew.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1152328828) }}, //integrity 06 big green scales
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1152328828) }}}; //integrity 06 big green scales 
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 768469910: //Perk pet random
					perk.displayName = Core.TT($"Best AI Friends Forever");
					perk.description = Core.TT($"Since our journey will be long and all of our crewmembers will be occupied, we still need a way to entertain AI of our ship, before she will decide to blow ship out of pure boredom. And pets are best to keep her entertained.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1502599448, 735284731) }}, //Dog //Cat1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(735284731) }}, //Cat1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1820607702, 1701486595) }}, //Rabbit //Slime pet
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1701486595) }}}; //Slime pet
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Different Pets")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 907765912: //Perk war animal for weirdship
					perk.displayName = Core.TT($"Red Rippers Boarding Party");
					perk.description = Core.TT($"A complete squad of red rippers, combat animals trained for advanced boarding and defensive operations. These red rippers undergone extremely strict military-grade training, examinations and enhancements.");
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
					case 1886509521: //Perk module DIY exotic EMP sniper
					perk.displayName = Core.TT($"Recovered Radiation Accelerator");
					perk.description = Core.TT($"Right before takeoff, we've managed to restore to the working condition one of the exotic disintegrator weapons, we've found earlier.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1238435842) }}}; //weapon BFGx9 for bluestar
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName.Replace(" Accelerator"," Accl.")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Pumpkin Hammer Perks
					case 1362449879: //Perk nuke barrel
					perk.displayName = Core.TT($"Avalanche Tactical Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of standard-type tactical capital missiles with high-yield explosive warhead.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}, //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}, //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}, //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}, //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}, //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(342953834) }}}; //08d Spearhead nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1852263270: //Perk nuke old
					perk.displayName = Core.TT($"Happy World Strategic Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of civilian-grade strategic capital missiles with low-yield nuclear warhead.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}, //08a Happy nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}, //08a Happy nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}, //08a Happy nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}, //08a Happy nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}, //08a Happy nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(227136891) }}}; //08a Happy nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 2032285499: //Perk Replace organics containers with betters for gardenship
					perk.displayName = Core.TT($"Organics Storage Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1530196661) }, //organics container 3 large
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1969497769) }}}; //organics container 5 ultra large
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 272967497: //Perk Replace fuel containers with betters
					perk.displayName = Core.TT($"Earth Alliance Support Agreement");
					perk.description = Core.TT($"Due to our achievements, Earth Alliance and the allies are ready to overhaul majority of equipment on our ship for free, given we can provide enough exotic matter to power temporary trans-dimensional gate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1482294420) }}}; //fuel processor 2
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(809627495) }, //fuel container 2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1569142382) }}, //fuel container 5
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(82212496) }, //organics container 2 medium
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(584489047) }, //exotics container 2 medium
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1380487708) }, //multicontainer MS-1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}, //multicontainer ESM-2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(311517981) }, //explosives container 3 large
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}, //multicontainer ESM-2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }, //reactor 15 medium
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(423938228) }}, //reactor 20 fusion
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(549367690) }, //reactor 13 classic cooled
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(933867895) }}, //reactor 18 weird alien biotech
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(833760257) }, //reactor 6 smalltrapho
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1518301159) }, //shield 1 round old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1646813987) }}, //shield 4 greendome
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(911395348) }, //shieldbat 2 terran
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(74390932) }}, //shieldbat 3 gmo biotech
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1078640904) }, //ECM 0 ancient
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(738383846) }}, //ECM 03 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(384091446) }, //medbay2 startversion
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1304112764) }}, //medbay4 stem celler
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1451617742) }, //sensor 8 sunpanel old s1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(680853891) }}, //sensor 11 sophisiticated s2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1863175212) }, //lab module x3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1448350571) }}, //lab 1xgood
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1003445460) }, //bridge 2crew
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(436212146) }}}; //bridge 3crew plastarmor
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Reactors & Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensors & Laboratories")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Bridge & Shield Systems")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Storages & Cryosleep Bays")} {Core.TT("Upgrade")}",
						$"+1x {Core.TT("Packed")} {Core.TT("Emergency Industrial Module")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case 798912976: //Perk pack, explosive cargo for gardenship
					perk.displayName = Core.TT($"Point Defenses Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(893617597) }, //0 DIY PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1381757148) }}, //7 Red PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1468502746) }, //5 Human PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1381757148) }}}; //7 Red PD
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1420718850: //Perk pack, organic cargo for gardenship
					perk.displayName = Core.TT($"Advanced Weapons Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older organics storage containers of the ship with newer organics storage containers available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1780996798) }, //weapon DIY Minicannon ancient 2,3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(469527491) }}, //weapon ancientrockets x3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1363897257) }, //weapon gatling 01 ancient dual 14,4
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(469527491) }}, //weapon ancientrockets x3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1118713154) }, //weapon ATK-MK2 old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(469527491) }}, //weapon ancientrockets x3
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(206321745) }, //weapon mininglaser 4
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(469527491) }}}; //weapon ancientrockets x3
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1711522921: //Perk module DIY shielding set x 2
					perk.displayName = Core.TT($"Antimatter Shield Systems Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed shield generator and capacitors sold by official dealer for acceptable price. Contains set of high-tier antimatter shield generators and capacitors that will greatly boost survivability of the ship.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1646813987) }}, //shield 4 greendome
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(74390932) }}, //shieldbat 3 gmo biotech
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(74390932) }}};  //shieldbat 3 gmo biotech
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1304884710: //Perk module shroomery for gardenship
					perk.displayName = Core.TT($"Greenhouse Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes some time and preparations to execute. Replaces older greenhouse modules of the ship with newer greenhouse modules available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1902866107) }, //garden 1 DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1832274586) }}}; //garden 3 shroomery
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1461582440: //Perk maggot pet
					perk.displayName = Core.TT($"Red Rippers Boarding Party");
					perk.description = Core.TT($"A complete squad of red rippers, combat animals trained for advanced boarding and defensive operations. These red rippers undergone extremely strict military-grade training, examinations and enhancements.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(488555786) }}, //Redripper crew
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(488555786) }}, //Redripper crew
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(488555786) }}, //Redripper crew
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(488555786) }}}; //Redripper crew
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Red Ripper")} {Core.TT("Combat Animals")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1101108011: //Perk crew warrior queen
					perk.displayName = Core.TT($"Twin Insectoid Warrior Queens");
					perk.description = Core.TT($"A leaders of a minor hives, looking to complete their ritual training. They brings along some resources as compensation for our effort.");
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
					case 656830655: //Perk nuke fueltank for atlas
					perk.displayName = Core.TT($"Hellfire Thermal Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of experimental thermal capital missiles with volumetric instant-ignition warhead.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}}; //04 Fueltank nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1071540180: //Perk Replace or improve bridge for atlas
					perk.displayName = Core.TT($"Primary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older reactors, weapons and bridge modules of the ship with newer modules of same types available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1468502746) }, //5 Human PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1230723452, 938711464, ShipModule.Type.PointDefence) }}, //10 laser PD //2 Tiger PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(514626098) }, //weapon Sniper cannon 0
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1567764648) }}, //weapon sniper cannon EMP
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1685141509) }, //weapon ATK-MK2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1086561640) }}, //weapon Segmented cannonx2 C
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1457521311) }, //weapon powerbeam-MK2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(848686115) }}, //weapon insectoid fast laser
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1554868377) }, //reactor 9 small old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(423938228) }}, //reactor 20 fusion
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1003445460) }, //bridge 2crew
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(436212146) }}}; //bridge 3crew plastarmor
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
					case 1765157179: //Perk Replace or improve growery for Atlas
					perk.displayName = Core.TT($"Secondary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older shields, engines, sensors and warp drive modules of the ship with newer modules of same types available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1518301159) }, //shield 1 round old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1386797426) }}, //shield 4 solitary
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(911395348) }, //shieldbat 2 terran
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1179432425) }}, //shieldbat 3 generic alien
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1508923010) }, //engine 2 large robust
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(366713264) }}, //engine 04 xblack
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(45815679) }}, //warp 06 rotor blue
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1084722255) }, //sensor 3 L terran simple
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(680853891) }}}; //sensor 11 sophisiticated s2
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
					case 1512141944: //Perk Replace or improve lab for atlas
					perk.displayName = Core.TT($"Auxiliary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older storage containers, greenhouses, laboratories and cryosleep bays of the ship with newer modules of same types available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(703894034) }, //cryosleep 3x medical
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(41460892) }}, //cryosleep 6x human standard
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1863175212) }, //lab module x3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1448350571) }}, //lab 1xgood
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1785710223) }, //garden 2 minigrow
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(728608876) }}, //garden 4 greenhouse
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(940750901) }, //organics container 1 small
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(228227788) }, //fuel container 3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}}; //multicontainer ESM-2
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
					case 81789966: //Perk module fuel combinator, to atlas
					perk.displayName = Core.TT($"Experimental Industrial Module Deal");
					perk.description = Core.TT($"A cache with freshly manufactured/grown and neatly packed experimental industrial module sold by official dealer for acceptable price. Has great efficiency a lot of features, but very fragile.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1405176791) }}}; //biotech explosives recycler
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1163778916: //Perk crew human volunteer
					perk.displayName = Core.TT($"Squad of Human Volunteers");
					perk.description = Core.TT($"A squad of human volunteers joins the mission to aid us during journey. They also bring along some supplies and emergency equipment.");
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
					case 1872158117: //Perk Replace dual mininglasers with triple, for Bluestar
					perk.displayName = Core.TT($"Main Weapon Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older weapon modules of the ship with newer modules of same types available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1191005979) }, //weapon mininglaser 2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1983239915) }}}; //weapon exoticscannon1
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.menuSprite = perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1339234810: //Perk nuke EMP 9000
					perk.displayName = Core.TT($"Ion Storm Energy Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade electromagnetic capital missiles with high-intensity pulse generators.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}}; //11 EMP nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 547639251: //Perk nuke DIY probe ual4 for bluestar
					perk.displayName = Core.TT($"White Death Strategic Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade strategic capital missiles with high-yield nuclear warhead.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-15000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1392399452) }}}; //10 White nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 3870557: //Perk Replace sensor with new for bluestar
					perk.displayName = Core.TT($"Reconnaissance Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older sensor modules and point defenses of the ship with newer modules of same types available at the market.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1468502746) }, //5 Human PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1495856276, 1381757148, ShipModule.Type.PointDefence) }}, //8 Crystal PD //7 Red PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1084722255) }, //sensor 3 L terran simple
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(160051026, 524731680, ShipModule.Type.Sensor) }}}; //sensor 10 tiger //sensor 11 seashell s2
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"+{perk.moduleReplacements[1].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 184540469: //Perk moleculaati pet
					perk.displayName = Core.TT($"Best AI Friends' Friends Forever");
					perk.description = Core.TT($"Since our journey will be long and all of our crewmembers will be occupied, we still need even more ways to entertain AI of our ship, before she will decide to blow ship out of pure boredom. And more pets are best to keep her entertained.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(301730638, 490627374) }}, //Lizard //Moleculaati
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(185113131, 490627374) }}, //Floater //Moleculaati
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(93253305, 490627374) }}, //Tortoise //Moleculaati
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(490627374) }}}; //Moleculaati
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("More Different Pets")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1633476255: //Perk drone 05 DIY science
					perk.displayName = Core.TT($"Security Drones Boarding Party");
					perk.description = Core.TT($"A complete squad of heavy security drones modified for advanced boarding and defensive operations. Drones were upgraded with military-grade hardware as well.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}}; //Heavy security drone
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1857941328: //Perk module artifact, nontech for Bluestar
					perk.displayName = Core.TT($"Recovered Ancient Modules Cache");
					perk.description = Core.TT($"Right before takeoff, we've managed to restore all modules from the ancient cache to the working condition, we've found earlier.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1615170861) }}, //explosives combinator 1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1348589878) }}}; //weapon monolith missile x1
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}" };
					perk.menuSprite = perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					//Warpshell Perks
					case 548302033: //Perk nuke DIY shield breaker
					perk.displayName = Core.TT($"Absolute Chemical Extravaganza");
					perk.description = Core.TT($"A complete arsenal of a military-grade chemical capital missiles that can be used to purify any single planet from any sings of life. It was acquired when we signed a very-ethical-use-only declaration and paid additional fees.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}, //07 Weirdship Chem nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(475763260) }}}; //07 Weirdship Chem nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+12x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.menuSprite = perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().image;
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 1763651597: //Perk warpshell extra deflection
					perk.displayName = Core.TT($"External Tissue Enhancement");
					perk.description = Core.TT($"The living part of the ship can be easily modified using a variety of biotechnological solutions. This one improves ship's internal and external kinetic bumpers, improving overall deflection efficiency.");
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
					case 1570827982: //Perk warpshell extra hitpoints
					perk.displayName = Core.TT($"Organic Integrity Enhancement");
					perk.description = Core.TT($"The living part of the ship has a range of exotic nutrients it needs to consume couple of times a year. If correct biotechnological solutions added to the nutrients, the ship's living tissue will grow more resistant to damage.");
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
					case 1666507194: //Perk Replace terran smallreactor oldx2
					perk.displayName = Core.TT($"Primary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older reactors, weapons and bridge modules of the ship with newer modules of same types available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1495856276, 1381757148, ShipModule.Type.PointDefence) }}, //8 Crystal PD //7 Red PD
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1495856276, 1381757148, ShipModule.Type.PointDefence) }}}; //8 Crystal PD //7 Red PD
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1468502746) }, //5 Human PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1495856276, 1381757148, ShipModule.Type.PointDefence) }}, //8 Crystal PD //7 Red PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1567764648) }, //weapon sniper cannon EMP
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(790917823) }}, //weapon Floral cannon
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1482677315) }, //weapon EMP energyball
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(790917823) }}, //weapon Floral cannon
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1249253086) }, //weapon dual EMP
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1983239915) }}, //weapon exoticscannon1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1700526886) }, //reactor 5 diy 2 backup
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2093337887) }}, //reactor 20 biofruit
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1554868377) }, //reactor 9 small old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2093337887) }}, //reactor 20 biofruit
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(983196801) }, //bridge 1crew DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1200522469) }}}; //bridge 3crew floral
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
					case 335666066: //Perk Replace ECM of warpshell
					perk.displayName = Core.TT($"Secondary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older shields, engines, sensors and warp drive modules of the ship with newer modules of same types available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1179432425) }}, //shieldbat 3 generic alien
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(29772476) }}};  //Stealth decryptor 2 biobrain
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(126798266) }, //shield 1 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1386797426) }}, //shield 4 solitary
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(738383848) }, //ECM 01 terran
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(738383845) }}, //ECM 02 terran
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1284816050) }, //engine 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(292475796) }}, //engine 03 bioship
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2136288774) }, //warp 0 DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(45815679) }}, //warp 06 rotor blue
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(930742757) }, //sensor 0-C diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(524731680) }}}; //sensor 11 seashell s2
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
					case 367285597: //Perk Replace DIY FO with FOO
					perk.displayName = Core.TT($"Auxiliary Modules Replacement");
					perk.description = Core.TT($"Planned upgrade that takes exotic matter investments, some time and preparations to execute. Replaces older storage containers, greenhouses, laboratories and cryosleep bays of the ship with newer modules of same types available at the market.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(41460892) }}, //cryosleep 6x human standard
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1304112764) }}, //medbay4 stem celler
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(737359377) }}, //garden 6 synthethics
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1448350571) }}}; //lab 1xgood
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1404265275) }, //multicontainer DIY FO
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1366723326) }, //multicontainer MFO retro futu
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(584489047) }, //exotics container 2 medium
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}, //multicontainer ESM-2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1008150789) }, //multicontainer ESM-1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}}; //multicontainer ESM-2
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
					case 1494259635: //Perk nuke Tiger sharpnel
					perk.displayName = Core.TT($"Acid Rain Chemical Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade chemical capital missiles with extremely corrosive payload.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}, //Tiger sharpnel nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}, //Tiger sharpnel nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}, //Tiger sharpnel nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}, //Tiger sharpnel nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}, //Tiger sharpnel nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1711403825) }}}; //Tiger sharpnel nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1581121396: //Perk nuke Battle Tiger monolith
					perk.displayName = Core.TT($"Bright Fury Kinetic Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade kinetic capital missiles with tandem-impactor kinetic warhead.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}, //Tiger Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}, //Tiger Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}, //Tiger Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}, //Tiger Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}, //Tiger Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2070090696) }}}; //Tiger Monolith nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 655868932: //Perk nuke Tiger dual EMP
					perk.displayName = Core.TT($"Dual Shock Energy Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade electromagnetic capital missiles with high-intensity pulse generators.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}, //Tiger EMP dual nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}, //Tiger EMP dual nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}, //Tiger EMP dual nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}, //Tiger EMP dual nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}, //Tiger EMP dual nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120056764) }}}; //Tiger EMP dual nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 850100445: //Perk nuke Tiger battery 8
					perk.displayName = Core.TT($"Cataclysm Tactical Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade tactical capital missiles with octagonal cluster high-explosive high-yield warheads.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}, //Tiger 8x nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}, //Tiger 8x nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}, //Tiger 8x nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}, //Tiger 8x nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}, //Tiger 8x nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776) }}}; //Tiger 8x nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1273038811: //Perk nuke Tiger intruderbot nuke
					perk.displayName = Core.TT($"Apocalypse Boarding Nukes Deal");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed capital missiles sold by official dealer for acceptable price. Contains pack of military-grade boarding capital missiles with perforation capabilities that release military boarding drones on impact.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}, //Tiger intruderbot nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}, //Tiger intruderbot nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}, //Tiger intruderbot nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}, //Tiger intruderbot nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}, //Tiger intruderbot nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966) }}}; //Tiger intruderbot nuke launcher
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 1137508603: //Perk pet Tiger dog drone
					perk.displayName = Core.TT($"Earth Alliance Drone Legion");
					perk.description = Core.TT($"Additional set of all kinds of drones to delegate majority of routine work to autonomous machines. Was properly acquired through official Earth Alliance channels for fraction of a price due to the direct support of our endeavor by high command.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-20000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1727276051, 1481089982) }}, //Drone tigerdog
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1727276051, 1481089982) }}, //Drone tigerdog
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}, //Heavy security drone
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(190195895) }}}; //Heavy security drone
					perk.randomizerMenuStrings = new string[]{
						$"+4x {Core.TT("Heavy Security")} {Core.TT("Drones")}",
						$"+2x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+2x {Core.TT("General Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 2073301424: //Perk pet DLC combat rabbit
					perk.displayName = Core.TT($"Primary Systems Upgrade & Combat Rabbit Pet");
					perk.description = Core.TT($"We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. It is genetically modified for superior speed and strength, and digitally trained to attack enemies in close combat.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1249253086) }, //weapon dual EMP
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(412909021, 1086561640, ShipModule.Type.Weapon) }}, //weapon gatling Tiger
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(306184114) }, //weapon tigerlaser MK2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}, //weapon EMP energyball 3x Tiger
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(97880399) }, //weapon tigermissile x2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}, //weapon EMP energyball 3x Tiger
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(833760257) }, //reactor 6 smalltrapho
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}, //reactor 15 medium
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(813614528) }, //reactor 10 small
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(423938228) }}, //reactor 20 fusion
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(171768739) }, //bridge 2crew tiger
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(436212146) }}}; //bridge 3crew plastarmor
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
					case 910502010: //Perk pet DLC shocker lizard
					perk.displayName = Core.TT($"Secondary Systems Upgrade & Shocker Lizard Pet");
					perk.description = Core.TT($"We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. The creature is quite intelligent and can shoot energy rays from its eyes.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1427874574, 1386797426, ShipModule.Type.ShieldGen) }}, //shield tigership //shield 4 solitary
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1424188745, 1179432425, ShipModule.Type.ShieldGen) }}}; //shieldbat tiger //shieldbat 3 generic alien
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(45815679) }}, //warp 06 rotor blue
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(362626339) }, //engine 01 tiger
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(366713264) }}, //engine 04 xblack
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(948524677) }, //sensor 2 saucer old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(160051026) }}}; //sensor 10 tiger
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
					case 507217483: //Perk pet DLC fire tortoise
					perk.displayName = Core.TT($"Support Systems Upgrade & Fire Tortoise Pet");
					perk.description = Core.TT($"We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. The creature is very intelligent and can tend gardens. It can also naturally breathe fire at enemies.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(383658151) }}, //dronebay 1 basic
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1197296009) }}, //medbay5 biofluid bath
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1515661102) }}}; //explosives combinator diy
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(619214127) }, //multicontainer FE armor
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1448350571) }}, //lab 1xgood
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1061408062) }, //fuel container tiger
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(728608876) }}, //garden 4 greenhouse
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(920367928) }, //multicontainer OME mechanical
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1008150789) }, //multicontainer ESM-1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}}; //multicontainer ESM-2
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
					case 1491901717: //Perk pet DLC warp floater
					perk.displayName = Core.TT($"Auxiliary Systems Upgrade & Warp Floater Pet");
					perk.description = Core.TT($"We've acquired this ancient combat organism from a Earth Alliance support channel as present, when we used their ship upgrade services. This warp creature is an extreme rarity due to being able to effectively communicate with non-warp beings. It is quite intelligent and likes to stare into human eyes.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-7500);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1482294420) }}, //fuel processor 2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(738383845) }}, //ECM 02 terran
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1276182163) }}, //Stealth decryptor 2 new human tec
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1468502746) }}}; //5 Human PD
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1813199311) }, //dream recorder 2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(41460892) }}}; //cryosleep 6x human standard
					perk.randomizerMenuStrings = new string[]{
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[3].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+{perk.moduleReplacements[0].newModulePrefabRef.Prefab.GetComponent<ShipModule>().displayName} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Endurance Perks
					case 28078182: //Perk module old triple cannon
					perk.displayName = Core.TT($"Personnel Equipment Requisition");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed high-end personnel weapons, implants and upgrades supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-5000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(957508477) }}, //artifactmodule tec 11 biostasis
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(685017033) }}, //artifactmodule tec 33 biostasis nice worm
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}, //artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}, //artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}, //artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}, //artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}, //artifactmodule tec 35 data core makk
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1316302015) }}}; //artifactmodule tec 35 data core makk
					perk.randomizerMenuStrings = new string[]{
						$"+6x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+6x {Core.TT("Packed")} {perk.extraModules[6].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+6x {Core.TT("Packed")} {perk.extraModules[12].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					case 889458515: //Perk Replace ATK old with ATK new for Endurance
					perk.displayName = Core.TT($"Experimental Weapons Requisition");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed multiple types of experimental weapons supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1571322820, 469527491, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon ancientrockets x3
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1571322820, 469527491, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon ancientrockets x3
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}, //weapon EMP energyball 3x Tiger //weapon rare warp shield breaker EMP
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(876704941, 1317545673, ShipModule.Type.Weapon) }}, //weapon EMP energyball 3x Tiger //weapon rare warp shield breaker EMP
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(412909021, 1086561640, ShipModule.Type.Weapon) }}, //weapon gatling Tiger //weapon Segmented cannonx2 C
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(412909021, 1086561640, ShipModule.Type.Weapon) }}}; //weapon gatling Tiger //weapon Segmented cannonx2 C
					perk.randomizerMenuStrings = new string[]{
						$"+2x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+2x {Core.TT("Packed")} {perk.extraModules[4].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 285860403: //Perk nuke for Endurance
					perk.displayName = Core.TT($"Ancient Capital Missiles Cache");
					perk.description = Core.TT($"An ancient, but perfectly sealed cache with capital missiles of all types and classifications suitable for any objective. We had to pay a hefty price to one of the famous hackers to break the seal open without triggering self-destruction mechanism.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-20000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1851270005) }}, //Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1851270005) }}, //Monolith nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(2106923011) }}, //11 EMP nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(780823633) }}, //04 Fueltank nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776, 342953834, ShipModule.Type.Weapon_Nuke) }}, //Tiger 8x nuke launcher //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(120466776, 342953834, ShipModule.Type.Weapon_Nuke) }}, //Tiger 8x nuke launcher //08d Spearhead nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(22001514) }}, //08c Green nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(22001514) }}, //08c Green nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966, 1043100994, ShipModule.Type.Weapon_Nuke) }}, //Tiger intruderbot nuke launcher //99 pirate spawner launcher 1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(381835966, 1043100994, ShipModule.Type.Weapon_Nuke) }}, //Tiger intruderbot nuke launcher //99 pirate spawner launcher 1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1558344950) }}, //15 Black nuke launcher
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1558344950) }}}; //15 Black nuke launcher
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
					case 873280599: //Perk Endurance extra hitpoints and deflection
					perk.displayName = Core.TT($"Bulkheads & Armor Refurbishment");
					perk.description = Core.TT($"A full refurbishment of all armor plates and integrity bulkheads will greatly increase durability of this ancient space vessel, as well its deflective and evasion properties, thus greatly increasing chances to reach the conclusion of our journey safely.");
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
					case 754443567: //Perk Replace containers with betters for Endurance
					perk.displayName = Core.TT($"Earth Alliance Council Backing");
					perk.description = Core.TT($"Due to our immense achievements, Earth Alliance and the allies are ready to overhaul all of equipment with high-end modules on our ship for free, given we can provide enough exotic matter to power temporary trans-dimensional gate.");
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
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1448463490) }, //metals container 2 medium
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1276182160) }}, //Stealth decryptor 3 newest human tec
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(825891570) }, //multicontainer DIY EE
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(41460892) }}, //cryosleep 6x human standard
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1449641283) }, //organics container 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1304112764) }}, //medbay4 stem celler
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(165493307) }, //synthetics container 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(426751082) }}, //multicontainer ESM-2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1391027202) }, //fuel container 1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(41460888) }, //cryosleep 2x human small
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1424188745, 1179432425, ShipModule.Type.ShieldGen) }}, //shieldbat tiger //shieldbat 3 generic alien
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1518301159) }, //shield 1 round old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1427874574, 1386797426, ShipModule.Type.ShieldGen) }}, //shield tigership //shield 4 solitary
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1451617742) }, //sensor 8 sunpanel old s1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(171954197) }}, //sensor 9 sunpanel new s2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(949056369) }, //03 Barrel nuke launcher
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1392399452) }}, //10 White nuke launcher
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1780996798) }, //weapon DIY Minicannon ancient 2,3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1571322820, 1983239915, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon exoticscannon1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1281856982) }, //weapon ATK-MK1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1571322820, 1983239915, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon exoticscannon1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2075523594) }, //weapon DIY exoticslaser
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1571322820, 1983239915, ShipModule.Type.Weapon) }}, //weapon tigermissile large //weapon exoticscannon1
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1468502746) }, //5 Human PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(938711464) }}, //2 Tiger PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1559705412) }}, //warp 07 rotor glass
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(497175846) }, //engine 01 primitive
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1119228548) }}, //engine 2 F-gulper
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1902866107) }, //garden 1 DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(728608876) }}, //garden 4 greenhouse
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(665713195) }, //lab module diy x2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1448350571) }}, //lab 1xgood
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1531409027) }, //fuel combinator 1A old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1699316752) }}, //reactor 22 cube
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(549367690) }, //reactor 13 classic cooled
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1699316752) }}, //reactor 22 cube
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2085174639) }, //bridge 3crew
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1148319565) }}}; //bridge 3crew metalarmor
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
					case 1332005888: //Perk pack, solid starfuel for endurance
					perk.displayName = Core.TT($"Support Modules Requisition");
					perk.description = Core.TT($"A cache of freshly manufactured and neatly packed full range of support modules supplied by an official Earth Alliance representative. We only had to pay transportation fee in credits and supply meager amount of exotic matter to power trans-dimensional gate.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-50);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-50000);
					perk.extraModules = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1424188745, 1179432425, ShipModule.Type.ShieldGen) }}, //shieldbat tiger //shieldbat 3 generic alien
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1276182160) }}, //Stealth decryptor 3 newest human tec
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(41460892) }}, //cryosleep 6x human standard
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(426751082) }}, //multicontainer ESM-2
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1165288718) }}, //multicontainer FEO-1
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDModuleGO(1363987393) }}}; //explosives combinator tiger
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Packed Storages & State-of-Art Factory")}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[1].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[2].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"+1x {Core.TT("Packed")} {perk.extraModules[0].Prefabs[0].GetComponent<ShipModule>().displayName}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 2043215293: //Perk DIY drone army
					perk.displayName = Core.TT($"Private Tactical Drone Company");
					perk.description = Core.TT($"A private company of sentient tactical drones with built-in perfect loyalty lock that ready to help us on our journey for serious credit investment. We can delegate majority of our work to them and increase overall efficiency of the ship.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraCrew = new Perk.Pool[]{
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1351800556) }}, //Drone tigerspider pirates
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1351800556) }}, //Drone tigerspider pirates
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1351800556) }}, //Drone tigerspider pirates
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(1351800556) }}, //Drone tigerspider pirates
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}, //Combat Drone Humanoid
						new Perk.Pool{ Prefabs = new GameObject[]{ GetPrefabIDCrewGO(826379097) }}}; //Combat Drone Humanoid
					perk.randomizerMenuStrings = new string[]{
						$"+8x {Core.TT("Tactical Combat")} {Core.TT("Drones")}",
						$"+4x {Core.TT("Assault Maintanance")} {Core.TT("Drones")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}" };
					if (!storedPerkSprites.ContainsKey("Drone_Army_Sprite")) storedPerkSprites.Add("Drone_Army_Sprite", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					//Riggy Perks
					case 260900693: //Perk module container FO for Riggy
					perk.displayName = Core.TT($"Mining Union Exchange");
					perk.description = Core.TT($"After tapping into our connection, we've manged to contact Mining Union. In exchange for providing credits and some exotic materials, they will be more than happy to refurbish some modules on this decommissioned mining vessel.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(171768739) }, //bridge 2crew tiger
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(436212146) }}, //bridge 3crew plastarmor
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(241738085) }, //dronebay 0 diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(383658151) }}, //dronebay 1 basic
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1451617742) }, //sensor 8 sunpanel old s1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(680853891) }}, //sensor 11 sophisiticated s2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1554868377) }, //reactor 9 small old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1633550495) }}}; //reactor 15 medium
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Bridge Compartment")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Drone Repair Bay")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensor Array")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Ship Reactors")} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					case 905925927: //Perk module container experimental random for Riggy
					perk.displayName = Core.TT($"Mysterious Upgrade Cache");
					perk.description = Core.TT($"An mysterious strangers approached us with. They were in dire need of credits and exotic materials, and as repayment they're willing to use their mysterious knowledge to upgrade some of the modules on our ship.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-10000);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2018774202) }}, //warp 05 rotor metal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(813097155) }, //shield 3 brass, single
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1646813987) }}, //shield 4 greendome
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1398713621) }, //cryosleep 1 DIY
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2059107150) }}, //cryosleep 8x insect
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(166404798) }, //oilcake converter
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1832274586) }}, //garden 3 shroomery
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(373200662) }, //synthetics cooker 1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1832274586) }}, //garden 3 shroomery
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1531409027) }, //fuel combinator 1A old
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1832274586) }}}; //garden 3 shroomery
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Shield Systems")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Cryosleep Bays")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Greenhouses")} {Core.TT("Replacement")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					if (!storedPerkSprites.ContainsKey("Something_Mysterious")) storedPerkSprites.Add("Something_Mysterious", perk.menuSprite);
					perk.isUnlockedByDefault = true;
					perk.repCost = 10;
					break;
					//Exception Perks
					case 463511730: //Perk Exception extra artifacts
					perk.displayName = Core.TT($"Original Biomodular Interior");
					perk.description = Core.TT($"Numerous technological artifacts of organic origin were excavated together with the Exception. Pulling some strings via our connections, we will ensure that they are still attached to the ship as they initially were.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-250);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-25000);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1003445460) }, //bridge 2crew
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1200522469) }}, //bridge 3crew floral
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2128566595) }, //shield 2 round
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1646813987) }}, //shield 4 greendome
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(228227788) }, //fuel container 3
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1094609544) }}, //shieldbat 5 floral
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1391715479) }, //integrity 0 DIY plastic
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1152328828) }}, //integrity 06 big green scales
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(825891570) }, //multicontainer DIY EE
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1847976825) }}, //multicontainer FSEE biotech
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(930742757) }, //sensor 0-C diy
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(204974912) }}, //sensor 11 blue adv s2
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1503624866) }, //warp 01 greencrystal
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(458296297) }}, //warp 03 neoncrystal
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(2023634410) }, //engine 2.5 terran
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(292475796) }}, //engine 03 bioship
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1776726075) }, //artifactmodule tec 39 accuracy advanced data core
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1405176791) }}}; //biotech explosives recycler
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Engine & Warp Drive")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Sensor & Armor Plates")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Bridge & Shield Systems")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Storages & Converters")} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case 462414045: //Perk Replace beamer laser for Exception
					perk.displayName = Core.TT($"Exceptional Tactical Armaments");
					perk.description = Core.TT($"Multiple armaments and ordnance of organic and crystalline origin was excavated together with the Exception. Pulling some strings via our connections, we will ensure that they are coming along with the ship as initially was intended.");
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue(-1000);
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue(-20000);
					perk.extraModules = new Perk.Pool[0];
					perk.moduleReplacements = new Perk.ModuleReplacement[] {
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(893617597) }, //0 DIY PD
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1495856276) }}, //8 Crystal PD
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(176876935) }, //weapon bigbeamer1
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(599402385) }}, //weapon Florallaser
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1532741737) }, //weapon Energy cannon x2
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(1768012478) }}, //weapon Energy cannon OP
						new Perk.ModuleReplacement {
							oldModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(55650103) }, //weapon DIY Laser
							newModulePrefabRef = new PrefabRef { Prefab = GetPrefabIDModuleGO(848686115) }}}; //weapon insectoid fast laser
					perk.randomizerMenuStrings = new string[]{
						$"+{Core.TT("Weapon Armaments")} {Core.TT("Upgrade")}",
						$"+{Core.TT("Close-In Weapon Systems")} {Core.TT("Upgrade")}",
						$"{perk.randomizerResources.credits.minValue} {Core.TT("Credits")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"{perk.randomizerResources.metals.minValue} {Core.TT("Metals")}",
						$"{perk.randomizerResources.synthetics.minValue} {Core.TT("Synthetics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 20;
					break;
					case 610158979: //Perk Exception extra hitpoints
					perk.displayName = Core.TT($"Carbonated Exotics Diet");
					perk.description = Core.TT($"Living parts of the Exception can be augmented by feeding it a special diet of carbon and exotics. As result ship's living tissue will acquire exotic properties and grow more resistant to every type of damage.");
					perk.addShipMaxHealth = 100;
					perk.addShipDeflectPercent = 5;
					perk.addShipEvasionPercent = 5;
					perk.addShipAccuracyPercent = 0;
					perk.randomizerResources.organics = FFU_BE_Defs.NewExactValue(-2500);
					perk.randomizerResources.fuel = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.metals = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.synthetics = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.explosives = FFU_BE_Defs.NewExactValue();
					perk.randomizerResources.exotics = FFU_BE_Defs.NewExactValue(-100);
					perk.randomizerResources.credits = FFU_BE_Defs.NewExactValue();
					perk.randomizerMenuStrings = new string[]{
						$"+{perk.addShipMaxHealth} {Core.TT("Ship Max Hitpoints")}",
						$"+{perk.addShipDeflectPercent}% {Core.TT("Ship Deflection")}",
						$"+{perk.addShipEvasionPercent}°/ₘ {Core.TT("Ship Evasion")}",
						$"{perk.randomizerResources.organics.minValue} {Core.TT("Organics")}",
						$"{perk.randomizerResources.exotics.minValue} {Core.TT("Exotics")}" };
					perk.isUnlockedByDefault = true;
					perk.repCost = 5;
					break;
					default: //Perks Fallback
					string perkData = FFU_BE_Defs.dumpObjectDatas ? "" : "[NEW PERK] ";
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
					if (FFU_BE_Defs.dumpObjectDatas) perksData += perkData + "\n\n";
					if (!FFU_BE_Defs.dumpObjectDatas) Debug.LogWarning(perkData);
					break;
				}
				if (!perk.isUnlockedByDefault) FFU_BE_Defs.unlockablePerkList.Add(perk);
				FFU_BE_Defs.prefabPerkList.Add(perk);
			}
			AssignNewSpriteToPerkID(754443567, storedPerkSprites["Deal_Handshake_Sprite"]);
			AssignNewSpriteToPerkID(889458515, storedPerkSprites["Random_Module_Sprite"]);
			AssignNewSpriteToPerkID(272967497, storedPerkSprites["Deal_Handshake_Sprite"]);
			AssignNewSpriteToPerkID(1332005888, storedPerkSprites["Leftover_Module_Sprite"]);
			AssignNewSpriteToPerkID(28078182, storedPerkSprites["Imperial_Crate_Sprite"]);
			AssignNewSpriteToPerkID(1633476255, storedPerkSprites["Security_Drone_Sprite"]);
			AssignNewSpriteToPerkID(1137508603, storedPerkSprites["Drone_Army_Sprite"]);
			AssignNewSpriteToPerkID(285860403, storedPerkSprites["Random_Nuke_Sprite"]);
			AssignNewSpriteToPerkID(1461582440, storedPerkSprites["Red_Ripper_Crew_Sprite"]);
			AssignNewSpriteToPerkID(462414045, storedPerkSprites["Random_Module_Sprite"]);
			AssignNewSpriteToPerkID(260900693, storedPerkSprites["Deal_Handshake_Sprite"]);
			if (FFU_BE_Defs.dumpObjectDatas) Debug.LogWarning(perksData);
		}
		private static GameObject GetPrefabIDCrewGO(int PrefabID, int BackupID = 0) {
			GameObject CrewGO = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == PrefabID)?.gameObject;
			if (CrewGO == null) {
				if (BackupID > 0) {
					CrewGO = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == BackupID)?.gameObject;
					if (CrewGO != null) Debug.LogWarning($"Crewmember with Prefab ID #{PrefabID} not found, using crewmember with Backup ID #{BackupID} instead!");
					else {
						CrewGO = FFU_BE_Defs.prefabModdedCrewList.RandomElement().gameObject;
						Debug.LogWarning($"Crewmember with Prefab ID #{PrefabID} or Backup ID #{BackupID} not found, using random crewmember instead!");
					}
				} else {
					CrewGO = FFU_BE_Defs.prefabModdedCrewList.RandomElement().gameObject;
					Debug.LogWarning($"Crewmember with Prefab ID #{PrefabID}, nor Backup ID was specified, using random crewmember instead!");
				}
			}
			return CrewGO;
		}
		private static GameObject GetPrefabIDModuleGO(int PrefabID, int BackupID = 0, ShipModule.Type RandomType = ShipModule.Type.None) {
			GameObject ModuleGO = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == PrefabID)?.gameObject;
			if (ModuleGO == null) {
				if (BackupID > 0) {
					ModuleGO = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == BackupID)?.gameObject;
					if (ModuleGO != null) Debug.LogWarning($"Module with Prefab ID #{PrefabID} not found, using module with Backup ID #{BackupID} instead!");
					else {
						if (RandomType != ShipModule.Type.None) {
							ModuleGO = FFU_BE_Defs.prefabModdedModulesList.FindAll(x => x.type == RandomType).RandomElement().gameObject;
							Debug.LogWarning($"Module with Prefab ID #{PrefabID} or Backup ID #{BackupID} not found, using random module of {RandomType} type instead!");
						} else {
							ModuleGO = FFU_BE_Defs.prefabModdedModulesList.RandomElement().gameObject;
							Debug.LogWarning($"Module with Prefab ID #{PrefabID} or Backup ID #{BackupID} not found, nor type was specified, using random module instead!");
						}
					}
				} else {
					ModuleGO = FFU_BE_Defs.prefabModdedModulesList.RandomElement().gameObject;
					Debug.LogWarning($"Module with Prefab ID #{PrefabID}, nor Backup ID or type were specified, using random module instead!");
				}
			}
			return ModuleGO;
		}
		private static void AssignNewSpriteToPerkID(int perkID, Sprite newSprite) {
			bool perkExists = FFU_BE_Defs.prefabPerkList.Find(p => p.PrefabId == perkID) != null;
			if (perkExists) FFU_BE_Defs.prefabPerkList.Find(p => p.PrefabId == perkID).menuSprite = newSprite;
		}
		public class ProcessDLC {

		}
		public static void InitLockedPerksAllocation() {
			List<GameObject> unusedPerks = new List<GameObject>();
			List<GameObject> existingPerks = new List<GameObject>();
			foreach (Sector sector in Resources.FindObjectsOfTypeAll<Sector>()) {
				foreach (PrefabRef item in sector.otherUnlockablePerkPrefabRefs) if (!existingPerks.Contains(item.Prefab.gameObject)) existingPerks.Add(item.Prefab.gameObject);
				if (sector.sectorEndUnlockablePerkPoolRef.Prefab != null) foreach (PrefabRef item in sector.sectorEndUnlockablePerkPoolRef.Prefab.GetComponent<PrefabPool>()) if (item.Prefab != null) if (!existingPerks.Contains(item.Prefab)) existingPerks.Add(item.Prefab);
			}
			foreach (Perk perk in FFU_BE_Defs.unlockablePerkList) if (!existingPerks.Contains(perk.gameObject)) unusedPerks.Add(perk.gameObject);
			foreach (Sector sector in Resources.FindObjectsOfTypeAll<Sector>()) if (sector.sectorEndUnlockablePerkPoolRef.Prefab != null) foreach (GameObject item in unusedPerks) sector.sectorEndUnlockablePerkPoolRef.Prefab.GetComponent<PrefabPool>().items.Add(new PrefabRef {Prefab = item} );
		}
		public static void InitShipCoreCrewmembers() {
			foreach (AddCrewToShip crewSet in Resources.FindObjectsOfTypeAll<AddCrewToShip>()) {
				int shipPrefabID = 0;
				switch (crewSet.name) {
					case "01 Tigerfish": shipPrefabID = 516057105; break;
					case "02 Nuke Runner": shipPrefabID = 487234563; break;
					case "04 Rogue Rat": shipPrefabID = 578937222; break;
					case "The Exception": shipPrefabID = 66885230; break;
					case "06 Atlas": shipPrefabID = 2103659466; break;
					case "00 Easy Tiger": shipPrefabID = 1920692188; break;
					case "08 Roundship": shipPrefabID = 1251918188; break;
					case "03 Weirdship": shipPrefabID = 1809014558; break;
					case "Engiship": shipPrefabID = 853503871; break;
					case "07 Bluestar MK III scientific": shipPrefabID = 1772361532; break;
					case "05 Gardenship": shipPrefabID = 1106792042; break;
					case "BattleTiger": shipPrefabID = 1452660923; break;
					case "WarBug": shipPrefabID = 42388666; break;
					case "10 Endurance": shipPrefabID = 1939804939; break;
				}
				if (shipPrefabID > 0) {
					List<AddCrewToShip.Group> crewSetList = crewSet.groups.ToList();
					foreach (KeyValuePair<int, int> storedCrewSet in FFU_BE_Defs.startingCrew[shipPrefabID]) {
						AddCrewToShip.Group newCrewSet = new AddCrewToShip.Group();
						Crewmember refCrew = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.PrefabId == storedCrewSet.Key);
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
					case "The Exception":
					resSet.organics = FFU_BE_Defs.NewExactValue(6500);
					resSet.fuel = FFU_BE_Defs.NewExactValue(5000);
					resSet.metals = FFU_BE_Defs.NewExactValue(4000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(4000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(4000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(250);
					resSet.credits = FFU_BE_Defs.NewExactValue(30000);
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
					case "Engiship":
					resSet.organics = FFU_BE_Defs.NewExactValue(5000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(15000);
					resSet.metals = FFU_BE_Defs.NewExactValue(35000);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(15000);
					resSet.explosives = FFU_BE_Defs.NewExactValue(25000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(2000);
					resSet.credits = FFU_BE_Defs.NewExactValue(50000);
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
					case "WarBug":
					resSet.organics = FFU_BE_Defs.NewExactValue(15000);
					resSet.fuel = FFU_BE_Defs.NewExactValue(12500);
					resSet.metals = FFU_BE_Defs.NewExactValue(12500);
					resSet.synthetics = FFU_BE_Defs.NewExactValue(12500);
					resSet.explosives = FFU_BE_Defs.NewExactValue(15000);
					resSet.exotics = FFU_BE_Defs.NewExactValue(1500);
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
				switch (ship.PrefabId) {
					case 516057105: //01 Tigerfish
					ship.MaxHealthAdd = 300;
					ship.survivabilityText = "NO";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 150));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Industrial Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 24));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 487234563: //02 Nuke Runner
					ship.MaxHealthAdd = 250;
					ship.survivabilityText = "NO";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Security Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 30));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 578937222: //04 Rogue Rat
					ship.MaxHealthAdd = 280;
					ship.survivabilityText = "LOL";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 125));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Metal Scrap Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 66885230: //The Exception
					ship.MaxHealthAdd = 300;
					ship.survivabilityText = "LOL";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 100));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Membrane Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 2103659466: //06 Atlas
					ship.MaxHealthAdd = 470;
					ship.survivabilityText = "MEH";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 225));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Reinforced Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1920692188: //00 Easy Tiger
					ship.MaxHealthAdd = 450;
					ship.survivabilityText = "MEH";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 250));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Tactical Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1251918188: //08 Roundship
					ship.MaxHealthAdd = 420;
					ship.survivabilityText = "OK";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 200));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Carapace Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1809014558: //03 Weirdship
					ship.MaxHealthAdd = 330;
					ship.survivabilityText = "OK";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 75));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Organic Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 36));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 853503871: //Engiship
					ship.MaxHealthAdd = 550;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 425));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Silo Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 72));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1772361532: //07 Bluestar MK III scientific
					ship.MaxHealthAdd = 520;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 275));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "High-Tech Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1106792042: //05 Gardenship
					ship.MaxHealthAdd = 380;
					ship.survivabilityText = "GUD";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 175));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Pressure Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 42));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1452660923: //BattleTiger
					ship.MaxHealthAdd = 700;
					ship.survivabilityText = "EPIC";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 350));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Shielded Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 54));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 42388666: //WarBug
					ship.MaxHealthAdd = 800;
					ship.survivabilityText = "EPIC";
					FFU_BE_Defs.shipPrefabsDoorHealth.Add(new KeyValuePair<int, int>(ship.PrefabId, 375));
					FFU_BE_Defs.shipPrefabsDoorName.Add(new KeyValuePair<int, string>(ship.PrefabId, "Biofiber Door"));
					FFU_BE_Defs.shipPrefabsStorageSize.Add(new KeyValuePair<int, int>(ship.PrefabId, 48));
					FFU_BE_Defs.prefabShipsList.Add(ship);
					break;
					case 1939804939: //10 Endurance
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
		public static int SortAllShips(int shipPrefabID) {
			int idx = 0;
			if (shipPrefabID == 516057105) return idx; idx++; //Tigerfish
			if (shipPrefabID == 487234563) return idx; idx++; //Nuke Runner
			if (shipPrefabID == 578937222) return idx; idx++; //Rogue Rat
			if (shipPrefabID == 66885230) return idx; idx++; //Exception
			if (shipPrefabID == 2103659466) return idx; idx++; //Atlas
			if (shipPrefabID == 1920692188) return idx; idx++; //Easy Tiger
			if (shipPrefabID == 1251918188) return idx; idx++; //Roundship
			if (shipPrefabID == 1809014558) return idx; idx++; //Weirdship
			if (shipPrefabID == 853503871) return idx; idx++; //Engiship
			if (shipPrefabID == 1772361532) return idx; idx++; //Bluestar
			if (shipPrefabID == 1106792042) return idx; idx++; //Gardenship
			if (shipPrefabID == 1452660923) return idx; idx++; //BattleTiger
			if (shipPrefabID == 42388666) return idx; idx++; //WarBug
			if (shipPrefabID == 1939804939) return idx; idx++; //Endurance
			return idx + 100;
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
		[MonoModIgnore] private int seed;
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
						float startingBonusMult = FFU_BE_Defs.GetDifficultyStartMod();
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
					if (owner == Ownership.Owner.Me && me != null) {
						me.gameRunRecord.shipPrefabId = PrefabId;
						me.gameRunRecord.shipSeed = seed;
						me.gameRunRecord.shipSurvivabilityText = survivabilityText;
						me.gameRunRecord.beginner = WorldRules.Impermanent.beginnerStartingBonus;
						me.gameRunRecord.ironman = WorldRules.Impermanent.ironman;
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
					if (me2 != null) me2.gameRunRecord.shipsDestroyed++;
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
				List<ShipModule> droppedModulesList = Modules.FindAll((ShipModule m) => m != null && !m.IsDead && !m.IsImmovable && !FFU_BE_Defs.IsProhibitedModule(m));
				PlayerData me = PlayerDatas.Me;
				if (me != null) me.battleLoot += lootGet;
				foreach (ShipModule droppedModule in droppedModulesList) {
					if (FFU_BE_Defs.debugMode) Debug.Log("Dropped Module: [" + droppedModule.name + "] Health: " + droppedModule.Health + "/" + droppedModule.MaxHealth);
					bool wasDropped = (FFU_BE_Defs.intactModuleDropChance * FFU_BE_Defs.GetHealthPercent(droppedModule)) >= UnityEngine.Random.Range(0f, 1f);
					if (droppedModule.type == ShipModule.Type.Weapon_Nuke) wasDropped = FFU_BE_Defs.GetHealthPercent(droppedModule) >= UnityEngine.Random.Range(0f, 1f);
					if (droppedModule.type == ShipModule.Type.Other) wasDropped = true;
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
			if (module != null && FFU_BE_Defs.IsUnusableModule(module)) {
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
		[MonoModIgnore] private int health;
		[MonoModIgnore] private int maxHealth;
		[MonoModIgnore] private GoLinker goLinker;
		[MonoModIgnore] public int InstanceId { get; private set; }
		public bool Save(string filePrefix) {
		/// Save Custom Door Data
			if (!IsSaveable) return false;
			using (ES2Writer eS2Writer = SavegameManager.CreateWriter(filePrefix)) {
				eS2Writer.Write(InstanceId, "id");
				eS2Writer.Write(base.transform, "transform");
				eS2Writer.Write(displayName, "displayName");
				eS2Writer.Write(health, "health");
				eS2Writer.Write(maxHealth, "maxHealth");
				eS2Writer.Write(Locked, "locked");
				eS2Writer.Write(Closed, "closed");
				eS2Writer.Write(OnePointRepairProgress, "onePointRepairProgress");
				List<GameObject> list = new List<GameObject>();
				CrewAssignmentSpot[] array = repairSpots;
				foreach (CrewAssignmentSpot crewAssignmentSpot in array) {
					list.Add((crewAssignmentSpot.assignedCrewmember != null) ? crewAssignmentSpot.assignedCrewmember.gameObject : null);
				}
				GoLinker.SaveGoRefList(eS2Writer, list, "repairers");
				SavegameManager.SaveBlankFsm(eS2Writer, "Smart closed");
				SavegameManager.Save(filePrefix, eS2Writer, base.gameObject);
			}
			return true;
		}
		public void Load(string filePrefix) {
		/// Load Custom Door Data if Exists
			using (ES2Reader eS2Reader = SavegameManager.CreateReader(filePrefix)) {
				if (eS2Reader.TagExists("id")) InstanceId = eS2Reader.Read<int>("id");
				eS2Reader.ReadComponent("transform", base.gameObject);
				health = eS2Reader.Read<int>("health");
				if (eS2Reader.TagExists("maxHealth")) maxHealth = eS2Reader.Read<int>("maxHealth");
				if (eS2Reader.TagExists("displayName")) displayName = eS2Reader.Read<string>("displayName");
				if (eS2Reader.TagExists("locked")) {
					Locked = eS2Reader.Read<bool>("locked");
					Closed = eS2Reader.Read<bool>("closed");
				} else {
					string a = eS2Reader.TagExists("_a") ? eS2Reader.Read<string>("_a") : "";
					Locked = (a == "Locked");
					Closed = (Locked || a == "Smart closed");
				}
				OnePointRepairProgress = (eS2Reader.TagExists("onePointRepairProgress") ? eS2Reader.Read<float>("onePointRepairProgress") : 0f);
				goLinker = new GoLinker();
				if (eS2Reader.TagExists("repairers")) goLinker.LoadGoRefList(eS2Reader, "repairers");
				else goLinker.SetPathMapListItem("repairers", new List<string>());
			}
		}
	}
}
