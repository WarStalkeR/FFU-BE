using RST;
using HarmonyLib;
using UnityEngine;

namespace FFU_Bleeding_Edge {
	public class FFU_BE_Prefab_Converters {
		public static int SortModules(string moduleName) {
			int idx = 0;
			if (moduleName == "explosives combinator diy") return idx; idx++;
			if (moduleName == "fuel combinator 1A old") return idx; idx++;
			if (moduleName == "oilcake converter") return idx; idx++;
			if (moduleName == "fuel processor 1B") return idx; idx++;
			if (moduleName == "synthetics cooker 1") return idx; idx++;
			if (moduleName == "explosives combinator 1") return idx; idx++;
			if (moduleName == "biotech explosives recycler") return idx; idx++;
			if (moduleName == "fuel processor 2") return idx; idx++;
			if (moduleName == "explosives combinator tiger") return idx; idx++;
			return idx + 100;
		}
		public static void UpdateConverterModule(ShipModule shipModule, bool initItemData) {
			string colorFactory = "dbc470";
			var shipModule_maxHealth = AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth");
			var refModuleName = string.Empty;
			if (!initItemData) refModuleName = FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == shipModule.PrefabId)?.name;
			if (string.IsNullOrEmpty(refModuleName)) refModuleName = Core.GetOriginalName(shipModule.name);
			switch (refModuleName) {
				case "explosives combinator diy":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1);
				shipModule.displayName = "Makeshift <color=#" + colorFactory + "ff>Chemical Reactor</color>";
				shipModule.description = "Makeshift chemical factory. Has horrible efficiency and performance, but when there are no other options, it is still best possible solution and solace of hope in this dark and unforgiving universe.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 100f, metals = 500f, synthetics = 250f, exotics = 3f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 115f, synthetics = 115f },
					new ResourceValueGroup { organics = 230f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 200f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.15f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 1.0f;
				shipModule.powerConsumed = 4;
				shipModule_maxHealth = 20;
				break;
				case "fuel combinator 1A old":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 1, 2, 3);
				shipModule.displayName = "Ancient <color=#" + colorFactory + "ff>Industrial Refinery</color>";
				shipModule.description = "A very ancient industrial factory that was used centuries ago. Usable even to these days, but constant leaks and permanent cracks hold starship and all crewmembers under pressure of danger.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 200f, metals = 1000f, synthetics = 500f, exotics = 6f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 110f, synthetics = 110f },
					new ResourceValueGroup { organics = 220f },
					new ResourceValueGroup { synthetics = 159f, explosives = 59f, exotics = 2f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 250f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.2f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 1.25f;
				shipModule.powerConsumed = 6;
				shipModule_maxHealth = 30;
				break;
				case "oilcake converter":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 2, 3, 4);
				shipModule.displayName = "Emporium <color=#" + colorFactory + "ff>Chemical Reactor</color>";
				shipModule.description = "An attempt of Rat Empire to reverse engineer end create their own industrial factory that anyway resulted in chemical factory that miraculously can convert starfuel into properly consumable organics.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 300f, metals = 1500f, synthetics = 750f, exotics = 9f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 100f },
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { organics = 105f, synthetics = 105f },
					new ResourceValueGroup { organics = 210f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 300f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.15f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.6f;
				shipModule.powerConsumed = 8;
				shipModule_maxHealth = 40;
				break;
				case "fuel processor 1B":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 3, 4, 5);
				shipModule.displayName = "Modern <color=#" + colorFactory + "ff>Industrial Refinery</color>";
				shipModule.description = "Modern and upgraded industrial factory that guarantees constant production of starfuel, synthetics and metals on your journey, as long as you can supply enough organics. Very fast efficiency dissipation.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 400f, metals = 1750f, synthetics = 1000f, exotics = 12f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 100f, synthetics = 100f },
					new ResourceValueGroup { organics = 200f },
					new ResourceValueGroup { synthetics = 149f, explosives = 49f, exotics = 2f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 400f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.2f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.75f;
				shipModule.powerConsumed = 11;
				shipModule_maxHealth = 50;
				break;
				case "synthetics cooker 1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 4, 5, 6);
				shipModule.displayName = "MarsCorp <color=#" + colorFactory + "ff>Military Refinery</color>";
				shipModule.description = "A military grade factory that allows to produce explosives in addition to base resources. Mediocrity at its finest. Can't be any more mediocre, but can at very least can produce explosives.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 500f, metals = 2000f, synthetics = 1250f, exotics = 15f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f },
					new ResourceValueGroup { explosives = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 95f, synthetics = 95f },
					new ResourceValueGroup { organics = 190f },
					new ResourceValueGroup { synthetics = 144f, explosives = 44f, exotics = 2f },
					new ResourceValueGroup { fuel = 55f, synthetics = 135f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 500f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.25f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.25f;
				shipModule.powerConsumed = 14;
				shipModule_maxHealth = 60;
				break;
				case "explosives combinator 1":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 5, 6, 7);
				shipModule.displayName = "TerraSec <color=#" + colorFactory + "ff>Military Refinery</color>";
				shipModule.description = "An improved military grade factory with improved explosives production and processing line. Has mediocre efficiency and parameters, but enough armored to stay intact after close-up reactor meltdown.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 750f, metals = 2500f, synthetics = 1750f, exotics = 20f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 100f },
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f },
					new ResourceValueGroup { explosives = 100f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 75f },
					new ResourceValueGroup { organics = 90f, synthetics = 90f },
					new ResourceValueGroup { organics = 180f },
					new ResourceValueGroup { synthetics = 139f, explosives = 39f, exotics = 2f },
					new ResourceValueGroup { fuel = 50f, synthetics = 130f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 600f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.3f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.2f;
				shipModule.powerConsumed = 17;
				shipModule_maxHealth = 150;
				break;
				case "biotech explosives recycler":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 6, 7, 8);
				shipModule.displayName = "GeneForce <color=#" + colorFactory + "ff>Biotic Refinery</color>";
				shipModule.description = "A unique factory of organic, but shady origin. Extremely efficient with organic related productivity and allow to use it instead of originally intended materials in some cases. Consumes almost no energy.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1000f, organics = 3000f, synthetics = 2000f, exotics = 25f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 100f },
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f },
					new ResourceValueGroup { explosives = 100f },
					new ResourceValueGroup { credits = 1000f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { explosives = 50f },
					new ResourceValueGroup { organics = 100f, synthetics = 50f },
					new ResourceValueGroup { organics = 150f },
					new ResourceValueGroup { synthetics = 84f, explosives = 34f, exotics = 2f, organics = 50f },
					new ResourceValueGroup { fuel = 45f, synthetics = 75f, organics = 50f },
					new ResourceValueGroup { exotics = 60f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 350f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.25f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.3f;
				shipModule.powerConsumed = 1;
				shipModule_maxHealth = 45;
				break;
				case "fuel processor 2":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 7, 8, 9);
				shipModule.displayName = "MicroProse <color=#" + colorFactory + "ff>Quantum Furnace</color>";
				shipModule.description = "Advanced factory that utilizes quantum entanglement technology to effectively resources. Has great initial warm-up output, but consumes serious amount of energy and has fast efficiency dissipation, when inactive.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1250f, metals = 4000f, synthetics = 2750f, exotics = 35f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f },
					new ResourceValueGroup { explosives = 100f },
					new ResourceValueGroup { exotics = 10f },
					new ResourceValueGroup { credits = 1000f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 80f, synthetics = 80f },
					new ResourceValueGroup { organics = 160f },
					new ResourceValueGroup { synthetics = 129f, explosives = 29f, exotics = 2f },
					new ResourceValueGroup { fuel = 40f, synthetics = 120f },
					new ResourceValueGroup { fuel = 75f, synthetics = 75f, metals = 75f, explosives = 75f },
					new ResourceValueGroup { exotics = 50f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 750f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.5f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.5f;
				shipModule.powerConsumed = 21;
				shipModule_maxHealth = 80;
				break;
				case "explosives combinator tiger":
				if (initItemData) FFU_BE_Defs.SetViableForSectors(shipModule.PrefabId, 8, 9, 10);
				shipModule.displayName = "StarFurnace <color=#" + colorFactory + "ff>Singularity Core</color>";
				shipModule.description = "Extremely advanced factory that uses active singularity to refine and process almost all types of resources with high efficiency. Consumes a lot of energy and has very long productivity warm-up time.";
				shipModule.craftCost = new ResourceValueGroup { fuel = 1500f, metals = 5000f, synthetics = 3500f, exotics = 50f };
				(shipModule as patch_ShipModule).MaterialsConverter.produceRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { fuel = 100f },
					new ResourceValueGroup { synthetics = 100f },
					new ResourceValueGroup { metals = 100f },
					new ResourceValueGroup { explosives = 100f },
					new ResourceValueGroup { exotics = 10f },
					new ResourceValueGroup { credits = 1000f }};
				(shipModule as patch_ShipModule).MaterialsConverter.consumeRecipes = new ResourceValueGroup[] {
					new ResourceValueGroup { organics = 75f, synthetics = 75f },
					new ResourceValueGroup { organics = 150f },
					new ResourceValueGroup { synthetics = 124f, explosives = 24f, exotics = 2f },
					new ResourceValueGroup { fuel = 35f, synthetics = 115f },
					new ResourceValueGroup { fuel = 50f, synthetics = 50f, metals = 50f, explosives = 50f },
					new ResourceValueGroup { exotics = 40f }};
				(shipModule as patch_ShipModule).MaterialsConverter.maxWarmUpPoints = 1000f;
				(shipModule as patch_ShipModule).MaterialsConverter.baseEfficiency = 0.1f;
				(shipModule as patch_ShipModule).MaterialsConverter.warmUpDissipation = 0.1f;
				shipModule.powerConsumed = 25;
				shipModule_maxHealth = 90;
				break;
				default:
				Debug.LogWarning($"[NEW CONVERTER] {FFU_BE_Mod_Information.GetSelectedModuleExactData(shipModule, false, true, false, false, false)}");
				shipModule.displayName = "(CONVERTER) " + shipModule.displayName;
				break;
			}
			AccessTools.FieldRefAccess<ShipModule, int>(shipModule, "maxHealth") = shipModule_maxHealth;
			FFU_BE_Mod_Modules.UpdateCommonStats(shipModule);
		}
	}
}
