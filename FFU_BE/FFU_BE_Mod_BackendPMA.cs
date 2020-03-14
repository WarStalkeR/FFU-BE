#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0169
#pragma warning disable CS0414
#pragma warning disable CS0114

using System;
using System.Text.RegularExpressions;
using HutongGames.PlayMaker;
using FFU_Bleeding_Edge;
using UnityEngine;
using MonoMod;
using RST.UI;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RST.PlaymakerAction {
	public class patch_ChoicePanel : ChoicePanel {
		private extern void orig_Start();
		//Increased Resource Numbers for Choices
		private void Start() {
			if (!FFU_BE_Defs.updatedChoices.Contains(GetHashCode())) {
				foreach (var choiceEntry in choiceText)
					if (Regex.Match(choiceEntry.Value, @"\d+").Success)
						foreach (string anchorWord in FFU_BE_Defs.choiceAnchorWords)
							if (Regex.Match(choiceEntry.Value, @"\d+ " + anchorWord).Success)
								foreach (var matchEntry in Regex.Matches(choiceEntry.Value, @"\d+ " + anchorWord))
									choiceEntry.Value = choiceEntry.Value.Replace(matchEntry.ToString(), (int.Parse(Regex.Match(matchEntry.ToString(), @"\d+").Value) * FFU_BE_Defs.resultNumbersMult).ToString() + " " + anchorWord);
				if (FFU_BE_Defs.debugMode) Debug.LogWarning("Choice Instance with Hash [" + GetHashCode() + "] was successfully modified.");
				FFU_BE_Defs.updatedChoices.Add(GetHashCode());
			}
			orig_Start();
		}
	}
	public class patch_ResultsPanel : ResultsPanel {
		[MonoModIgnore] private bool started;
		[MonoModIgnore] private PlayMakerFSM fsm;
		[MonoModIgnore] private AudioPlayWithFade.Ctx audioCtx;
		//Increased Resource Numbers for Results
		[MonoModReplace] private void Start() {
			started = true;
			fsm = CreateIfNeeded.Do(UISkin.Instance.resultsPrefab);
			FsmVariables fsmVariables = fsm.FsmVariables;
			POI current = POI.Current;
			fsmVariables.GetFsmString("title").Value = ChoicePanel.GetTitle(base.Fsm, title);
			fsmVariables.GetFsmObject("picture").Value = Pool<Sprite>.TakeRandomItem(picturePool.Value as SpritePool, picture.Value as Sprite, current);
			string text = Localization.TT(Pool<string>.TakeRandomItem(textPool.Value as StringPool, text2, current));
			fsmVariables.GetFsmString("text").Value = ChoicePanel.MakeReplacements(text, replacements);
			fsmVariables.GetFsmBool("resources given").Value = resourcesGiven;
			PlayerData pd = PlayerDatas.Me;
			Ship flagship = pd.Flagship;
			if (flagship != null) {
				int psMaxHealth = flagship.MaxHealth;
				int psHealth = flagship.HealthFast(psMaxHealth);
				int psHealthNum = WorldRules.Impermanent.PlayerShipsTakeMaxHpDamage ? (psHealth + psMaxHealth) : psHealth;
				int psMaxHealthNum = WorldRules.Impermanent.PlayerShipsTakeMaxHpDamage ? (psMaxHealth * 2) : psMaxHealth;
				int psHealthChange = ParseIntExpr(Health.Value, () => psMaxHealth - psHealth);
				psHealthChange = (healthNoKill.Value && -psHealthChange >= psHealthNum) ? (-psHealthNum + 1) : (Mathf.Clamp(psHealthNum + psHealthChange, 0, psMaxHealthNum) - psHealthNum);
				bool value = -psHealthChange >= psHealthNum;
				fsmVariables.GetFsmInt("health").Value = psHealthChange;
				fsmVariables.GetFsmBool("dead by ship").Value = value;
			}
			ResourceValueGroup battleLoot = pd.battleLoot;
			int fTotal = pd.Fuel.Total;
			int oTotal = pd.Organics.Total;
			int eTotal = pd.Explosives.Total;
			int xTotal = pd.Exotics.Total;
			int sTotal = pd.Synthetics.Total;
			int mTotal = pd.Metals.Total;
			int fAmount = ParseIntExpr(Fuel.Value, () => pd.Fuel.SoftMax - fTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.fuel;
			int oAmount = ParseIntExpr(Organics.Value, () => pd.Organics.SoftMax - oTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.organics;
			int eAmount = ParseIntExpr(Explosives.Value, () => pd.Explosives.SoftMax - eTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.explosives;
			int xAmount = ParseIntExpr(Exotics.Value, () => pd.Exotics.SoftMax - xTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.exotics;
			int sAmount = ParseIntExpr(Synthetics.Value, () => pd.Synthetics.SoftMax - sTotal) + (int)battleLoot.synthetics;
			int mAmount = ParseIntExpr(Metals.Value, () => pd.Metals.SoftMax - mTotal) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.metals;
			int cAmount = ParseIntExpr(Credits.Value, null) * FFU_BE_Defs.resultNumbersMult + (int)battleLoot.credits;
			if (cAmount >= 0 && addResearchCreditsBonus.Value) cAmount += WorldRules.Instance.scienceSkillEffects.EffectiveCreditsBonus(Ownership.Owner.Me);
			fsmVariables.GetFsmInt("fuel").Value = Mathf.Clamp(fTotal + fAmount, 0, int.MaxValue) - fTotal;
			fsmVariables.GetFsmInt("organics").Value = Mathf.Clamp(oTotal + oAmount, 0, int.MaxValue) - oTotal;
			fsmVariables.GetFsmInt("explosives").Value = Mathf.Clamp(eTotal + eAmount, 0, int.MaxValue) - eTotal;
			fsmVariables.GetFsmInt("exotics").Value = Mathf.Clamp(xTotal + xAmount, 0, int.MaxValue) - xTotal;
			fsmVariables.GetFsmInt("synthetics").Value = Mathf.Clamp(sTotal + sAmount, 0, int.MaxValue) - sTotal;
			fsmVariables.GetFsmInt("metals").Value = Mathf.Clamp(mTotal + mAmount, 0, int.MaxValue) - mTotal;
			fsmVariables.GetFsmInt("credits").Value = Mathf.Max(pd.Credits + cAmount, 0) - pd.Credits;
			int repAmount = ParseIntExpr(RepPoints.Value, null);
			fsmVariables.GetFsmInt("repPoints").Value = Mathf.Max(pd.RepPoints + repAmount, 0) - pd.RepPoints;
			bool deadByCrew = false;
			int crewHealth = ParseIntExpr(CrewHealth.Value, null);
			int crewHealthMax = ParseIntExpr(CrewMaxHealth.Value, null);
			if (crewHealth != 0 && crewHealthNoKill.Value) crewHealth *= FFU_BE_Defs.resultNumbersMult;
			int crewHealthCount = (crewHealth != 0 || crewHealthMax != 0) ? (string.IsNullOrEmpty(divideBetweenHowManyCrew.Value) ? 1000 : ParseIntExpr(divideBetweenHowManyCrew.Value, () => 1000)) : 0;
			if (crewHealth < 0 && !crewHealthNoKill.Value) {
				int crewHealthDist = 0;
				foreach (Crewmember cachedCrewmember in PerFrameCache.CachedCrewmembers)
					if (cachedCrewmember != null && UpdatePlayerData.CrewIsDeletable(cachedCrewmember) && cachedCrewmember.Ownership.GetOwner() == Ownership.Owner.Me)
						crewHealthDist += cachedCrewmember.Health;
				if (-crewHealth >= crewHealthDist) deadByCrew = true;
				if (crewHealthMax < 0) Debug.LogError("deadByCrew check can't be done if both crewMaxHealth<0 and crewHealth<0");
			}
			fsmVariables.GetFsmInt("crewHealth").Value = crewHealth;
			fsmVariables.GetFsmInt("crewHealthCrewCount").Value = crewHealthCount;
			fsmVariables.GetFsmBool("crewHealthNoKill").Value = crewHealthNoKill.Value;
			fsmVariables.GetFsmString("crewDeathMessage").Value = crewDeathMessage.IsNone ? "<default>" : crewDeathMessage.Value;
			fsmVariables.GetFsmInt("crewMaxHealth").Value = crewHealthMax;
			int crewCountNum = ParseIntExpr(CrewCount.Value, null);
			if (-crewCountNum >= pd.ControllableCrewCount) deadByCrew = true;
			fsmVariables.GetFsmBool("dead by crew").Value = deadByCrew;
			fsmVariables.GetFsmInt("crew").Value = crewCountNum;
			fsmVariables.GetFsmArray("crewmemberPool").CopyValues(crewmemberPool);
			fsmVariables.GetFsmString("crewNameOverride").Value = crewNameOverride.Value;
			fsmVariables.GetFsmString("crewDescriptionOverride").Value = crewDescriptionOverride.Value;
			int count = ParseIntExpr(ModuleCount.Value, null);
			List<ShipModule> modulePoolList = InstantiateFromPool.DoIt<ShipModule>(Array.ConvertAll(modulePool.Values, (object p) => (GameObject)p), modulePoolAllowDuplicates.Value, PlayerDatas.Instance?.transform, count);
			foreach (ShipModule item in modulePoolList) {
				item.transform.position = new Vector3(10000f, 0f, 0f);
				item.Ownership.SetOwner(Ownership.Owner.Inherit);
			}
			if (modulePoolList.Count > 0) PerFrameCache.InvalidateModuleCache();
			fsmVariables.GetFsmFloat("module dmg percent min").Value = moduleDmgPercentMin.Value;
			fsmVariables.GetFsmFloat("module dmg percent max").Value = moduleDmgPercentMax.Value;
			fsmVariables.GetFsmBool("dontDoLargeBg").Value = dontDoLargeBg.Value;
			fsmVariables.GetFsmBool("crewDidntDie").Value = crewDidntDie.Value;
			object[] array = fsmVariables.GetFsmArray("choiceTexts").Values = choiceTexts.stringValues;
			fsmVariables.GetFsmBool("tutorial mode").Value = noPopup.Value;
			fsmVariables.GetFsmString("reason to display").Value = reasonToDisplay.Value;
			audioCtx = AudioPlayWithFade.Enter(base.Fsm.GameObject, audioClip.Value as AudioClip, audioNoFade.Value);
		}
	}
	public class patch_GetOrphanedModules : GetOrphanedModules {
		//Damage Salvaged Modules
		[MonoModReplace] private void DoIt() {
			List<GameObject> list = new List<GameObject>();
			float salvageDamageMax = FFU_BE_Defs.GetDifficultyDamageMax();
			foreach (ShipModule cachedModule in PerFrameCache.CachedModules) {
				if (cachedModule != null && !cachedModule.IsPacked && cachedModule.Ownership.GetIsOrphan()) {
					if (cachedModule.Health == cachedModule.MaxHealth) cachedModule.TakeDamage(UnityEngine.Random.Range(Mathf.RoundToInt(cachedModule.MaxHealth * 0.1f), Mathf.RoundToInt(cachedModule.MaxHealth * salvageDamageMax) + 1));
					list.Add(cachedModule.gameObject);
				}
			}
			list.Sort((GameObject a, GameObject b) => a.name.CompareTo(b.name));
			object[] array2 = storeModuleGOs.Values = list.ToArray();
			storeModuleCount.Value = list.Count;
		}
	}
	public class patch_NewGamePanel : NewGamePanel {
		public extern void orig_NewGameBeginnerClicked();
		public extern void orig_NewGameChallengingClicked();
		public extern void orig_NewGameHardcoreClicked();
		private void NewGameBeginnerClicked() {
			FFU_BE_Defs.startingDifficulty = Core.Difficulty.Easy;
			orig_NewGameBeginnerClicked();
		}
		private void NewGameChallengingClicked() {
			FFU_BE_Defs.startingDifficulty = Core.Difficulty.Medium;
			orig_NewGameChallengingClicked();
		}
		private void NewGameHardcoreClicked() {
			FFU_BE_Defs.startingDifficulty = Core.Difficulty.Hard;
			orig_NewGameHardcoreClicked();
		}
	}
	public class patch_MothershipSelection : MothershipSelection {
		[MonoModIgnore] private int shipIndex;
		[MonoModIgnore] private List<Ship> ships;
		[MonoModIgnore] private string defaultShipName;
		[MonoModIgnore] private List<int> unlockedItems;
		[MonoModIgnore] private FloatMinMax CountStartingCrew(Ship s) { return default; }
		[MonoModIgnore] private void CountModuleSlots(Ship s, out int weaponSlots, out int nukeSlots, out int otherSlots) { weaponSlots = 0; nukeSlots = 0; otherSlots = 0; }
		//Modded Starting Bonuses
		[MonoModReplace] private void UpdateShipSelection() {
			if (ships.Count <= 0) {
				targetImage.sprite = null;
				targetDisplayNameInput.text = "";
				targetDescription.text = Localization.TT("No playable ships available. Broken install?");
				shipLockedIndicator.SetActive(false);
				shipNotAvailableIndicator.SetActive(false);
				shipStatsPanel.SetActive(false);
				doneButton.interactable = false;
				return;
			}
			shipIndex = Mathf.Clamp(shipIndex, 0, ships.Count - 1);
			Ship ship = ships[shipIndex];
			storeShip.Value = ship.gameObject;
			targetImage.sprite = ship.menuSprite;
			if (ship.menuSprite != null) {
				targetImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ship.menuSprite.texture.width);
				targetImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ship.menuSprite.texture.height);
			}
			targetDisplayNameInput.text = "";
			targetDisplayNameInput.placeholder.GetComponent<Text>().text = Localization.TT("Default name:") + " " + ship.displayName;
			defaultShipName = ship.displayName;
			storeShipDisplayName.Value = defaultShipName;
			targetDescription.text = Localization.TT(ship.description);
			CountModuleSlots(ship, out int weaponSlots, out int nukeSlots, out int otherSlots);
			WorldRules.StartingBonus startingBonus = WorldRules.Instance.beginnerStartingBonus;
			float startingBonusMult = FFU_BE_Defs.GetStartingModDiffMult();
			string valueSign = startingBonusMult > 0 ? "↑" : "↓";
			targetWeaponSlots.text = weaponSlots.ToString();
			targetNukeSlots.text = nukeSlots.ToString();
			targetOtherSlots.text = otherSlots.ToString();
			targetMaxHealthAdd.text = ship.MaxHealthAdd.ToString();
			targetCrew.text = CountStartingCrew(ship).ToString("0");
			targetAccuracyPercentAdd.text = ship.accuracyPercentAdd + "%";
			targetAccuracyStartingBonus.text = $" {valueSign}{Mathf.Abs(startingBonus.accuracyBonusPercent * startingBonusMult):0}";
			targetAccuracyStartingBonus.color = startingBonusMult > 0 ? Color.green : Color.red;
			targetAccuracyStartingBonus.gameObject.SetActive(startingBonusMult != 0);
			targetDeflection.text = RstUtil.FormatChanceValue(ship.deflectChance);
			targetDeflectionStartingBonus.text = $" {valueSign}{Mathf.Abs(startingBonus.deflectionBonusPercent * startingBonusMult):0}";
			targetDeflectionStartingBonus.color = startingBonusMult > 0 ? Color.green : Color.red;
			targetDeflectionStartingBonus.gameObject.SetActive(startingBonusMult != 0);
			targetEvasionPercentAdd.text = ship.evasionPercentAdd.ToString() + "°/ₘ";
			targetEvasionStartingBonus.text = $" {valueSign}{Mathf.Abs(startingBonus.evasionBonusPercent * startingBonusMult):0}";
			targetEvasionStartingBonus.color = startingBonusMult > 0 ? Color.green : Color.red;
			targetEvasionStartingBonus.gameObject.SetActive(startingBonusMult != 0);
			targetSurvivability.text = ship.survivabilityText;
			if (!rollingSelection.Value) {
				nextShipButton.interactable = shipIndex < ships.Count - 1;
				prevShipButton.interactable = shipIndex > 0;
			} else {
				nextShipButton.interactable = true;
				prevShipButton.interactable = true;
			}
			bool flag = !beginnerStartingBonus.Value || (beginnerStartingBonus.Value && !WorldRules.Instance.shipsNotAvailableInBeginner.Exists((PrefabRef p) => p.PrefabId == ship.PrefabId));
			shipNotAvailableIndicator.SetActive(!flag);
			shipNotAvailableText.text = Localization.TT("Available only in challenging/hardcore difficulties").ToUpperInvariant();
			bool flag2 = ship.IsUnlockedByDefault || unlockedItems.Contains(ship.PrefabId);
			if (flag) {
				shipLockedIndicator.SetActive(!flag2);
				shipLockedText.text = Localization.TT(ship.unlockText).ToUpperInvariant();
			} else {
				shipLockedIndicator.SetActive(false);
			}
			bool flag3 = flag2 && flag;
			targetImage.color = flag3 ? Color.white : shipLockedColor.Value;
			shipStatsPanel.SetActive(flag3);
			doneButton.interactable = flag3;
		}
	}
	public class patch_PerksSelection : PerksSelection {
		public extern void orig_OnEnter();
		[MonoModIgnore] private void FinishThisAction() { }
		[MonoModIgnore] private bool CanStartGame() { return false; }
		[MonoModIgnore] private void ChangeCrewName(Crewmember crew, string newName) { }
		[MonoModIgnore] private List<PerkUIGridElement> perkUiElements = new List<PerkUIGridElement>();
		[MonoModIgnore] private static Crewmember InstantiateCrewWithSeed(Crewmember crewPrefab, int seed, string matchingComment, Perk perkPrefab = null) { return null; }
		//Configurable Starting Fate
		public override void OnEnter() {
			firstRunFate.Value = FFU_BE_Defs.newStartingFateBonus;
			orig_OnEnter();
		}
		//Allow Modded Crewmembers to Spawn
		[MonoModReplace] private void ConfirmationYesClicked() {
			confirmationGroup.Value.SetActive(false);
			if (CanStartGame()) {
				FFU_BE_Defs.canSpawnCrew = true;
				FinishThisAction();
			}
		}
		//Usage of Data from Modded Variables
		[MonoModReplace] private void UpdateResourceAndBonusesDisplay() {
			Ship ship = chosenMothership.Value?.GetComponent<Ship>();
			if (ship == null) return;
			AddResourcesToShip[] componentsInChildren = ship.GetComponentsInChildren<AddResourcesToShip>();
			FloatMinMax baseMaxHP = new FloatMinMax(ship.MaxHealthAdd);
			FloatMinMax baseFuel = new FloatMinMax(0f);
			FloatMinMax baseOrganics = new FloatMinMax(0f);
			FloatMinMax baseExplosives = new FloatMinMax(0f);
			FloatMinMax baseExotics = new FloatMinMax(0f);
			FloatMinMax baseSynthetics = new FloatMinMax(0f);
			FloatMinMax baseMetals = new FloatMinMax(0f);
			FloatMinMax baseCredits = new FloatMinMax(0f);
			FloatMinMax coreFuel = new FloatMinMax(0f);
			FloatMinMax coreOrganics = new FloatMinMax(0f);
			FloatMinMax coreExplosives = new FloatMinMax(0f);
			FloatMinMax coreExotics = new FloatMinMax(0f);
			FloatMinMax coreSynthetics = new FloatMinMax(0f);
			FloatMinMax coreMetals = new FloatMinMax(0f);
			FloatMinMax coreCredits = new FloatMinMax(0f);
			FloatMinMax baseAccuracy = new FloatMinMax(ship.accuracyPercentAdd);
			FloatMinMax baseDefelection = new FloatMinMax(ship.deflectChance * 100f);
			FloatMinMax baseEvasion = new FloatMinMax(ship.evasionPercentAdd);
			AddResourcesToShip[] array = componentsInChildren;
			foreach (AddResourcesToShip addResourcesToShip in array) {
				if (addResourcesToShip.condition == AddResourcesToShip.Condition.Always || addResourcesToShip.condition == AddResourcesToShip.Condition.IfPlayer_NotTutorial) {
					coreFuel += addResourcesToShip.fuel;
					coreOrganics += addResourcesToShip.organics;
					coreExplosives += addResourcesToShip.explosives;
					coreExotics += addResourcesToShip.exotics;
					coreSynthetics += addResourcesToShip.synthetics;
					coreMetals += addResourcesToShip.metals;
					coreCredits += addResourcesToShip.credits;
					baseFuel += addResourcesToShip.fuel;
					baseOrganics += addResourcesToShip.organics;
					baseExplosives += addResourcesToShip.explosives;
					baseExotics += addResourcesToShip.exotics;
					baseSynthetics += addResourcesToShip.synthetics;
					baseMetals += addResourcesToShip.metals;
					baseCredits += addResourcesToShip.credits;
				}
			}
			int seed = StartGameCustomization.GetSeed();
			RstRandom.InitState(seed);
			AddCrewToShip[] initialShipCrew = ship.GetComponentsInChildren<AddCrewToShip>();
			List<Crewmember> list = new List<Crewmember>();
			for (int j = 0; j < initialShipCrew.Length; j++) {
				AddCrewToShip addCrewToShip = initialShipCrew[j];
				if (addCrewToShip.condition != AddResourcesToShip.Condition.Always && addCrewToShip.condition != AddResourcesToShip.Condition.IfPlayer_NotTutorial) continue;
				addCrewToShip.seed = Mathf.Abs(seed + j);
				StartGameCustomization.SaveAddCrewToShipSeed(addCrewToShip);
				RstRandom.InitState(addCrewToShip.seed);
				for (int k = 0; k < addCrewToShip.groups.Length; k++) {
					AddCrewToShip.Group group = addCrewToShip.groups[k];
					Color color = Color.white;
					if (group.matchCrewColor) RandomizeCrewmember.PickMatchedColor(group.Pool, out color);
					int randomInt = group.count.GetRandomInt();
					for (int l = 0; l < randomInt; l++) {
						Crewmember crewmember = GameObjectPool.TakeRandomPrefab<Crewmember>(group.Pool);
						if (crewmember != null) {
							int newSeed = Mathf.Abs(addCrewToShip.seed + k * 100 + l);
							Crewmember newCrewmember = InstantiateCrewWithSeed(crewmember, newSeed, group.chooseWithMatchingComment);
							if (group.matchCrewColor) newCrewmember.SetColor(color);
							list.Add(newCrewmember);
							UnityEngine.Object.Destroy(newCrewmember.gameObject);
						}
					}
				}
			}
			if (FFU_BE_Defs.crewTypesOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)].Length > 0 && FFU_BE_Defs.crewNumsOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)].Length > 0 && 
				FFU_BE_Defs.crewTypesOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)].Length == FFU_BE_Defs.crewNumsOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)].Length) {
				int amountPerType = 0;
				for (int t = 0; t < FFU_BE_Defs.crewTypesOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)].Length; t++) {
					int.TryParse(FFU_BE_Defs.crewNumsOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)][t], out amountPerType);
					if (amountPerType > 0 && !string.IsNullOrEmpty(FFU_BE_Defs.crewTypesOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)][t])) {
						Crewmember tempType = FFU_BE_Defs.prefabModdedCrewList.Find(x => x.name == FFU_BE_Defs.crewTypesOnStart[FFU_BE_Mod_Crewmembers.GetShipID(ship)][t]);
						if (tempType != null) {
							for (int n = 0; n < amountPerType; n++) {
								int newSeed = Mathf.Abs(seed + t * 100 + n);
								Crewmember newCrewmember = InstantiateCrewWithSeed(tempType, newSeed, null);
								list.Add(newCrewmember);
								UnityEngine.Object.Destroy(newCrewmember.gameObject);
							}
						}
					}
				}
			}
			int extraModules = 0;
			FFU_BE_Defs.perkModuleBlueprintIDs = new List<int>();
			for (int m = 0; m < perkUiElements.Count; m++) {
				PerkUIGridElement perkUIGridElement = perkUiElements[m];
				if (!perkUIGridElement.toggle.isOn) continue;
				baseMaxHP += perkUIGridElement.perkPrefab.addShipMaxHealth;
				baseFuel += perkUIGridElement.perkPrefab.randomizerResources.fuel;
				baseOrganics += perkUIGridElement.perkPrefab.randomizerResources.organics;
				baseExplosives += perkUIGridElement.perkPrefab.randomizerResources.explosives;
				baseExotics += perkUIGridElement.perkPrefab.randomizerResources.exotics;
				baseSynthetics += perkUIGridElement.perkPrefab.randomizerResources.synthetics;
				baseMetals += perkUIGridElement.perkPrefab.randomizerResources.metals;
				baseCredits += perkUIGridElement.perkPrefab.randomizerResources.credits;
				baseAccuracy += perkUIGridElement.perkPrefab.addShipAccuracyPercent;
				baseDefelection += perkUIGridElement.perkPrefab.addShipDeflectPercent;
				baseEvasion += perkUIGridElement.perkPrefab.addShipEvasionPercent;
				RstRandom.InitState(Mathf.Abs(seed + 5555 + perkUIGridElement.perkPrefab.name.GetHashCode()));
				for (int n = 0; n < perkUIGridElement.perkPrefab.extraCrew.Length; n++) {
					Crewmember crewmember3 = GameObjectPool.TakeRandomPrefab<Crewmember>(perkUIGridElement.perkPrefab.extraCrew[n].Prefabs);
					if (crewmember3 != null) {
						int seed3 = Mathf.Abs(seed + perkUIGridElement.perkPrefab.name.GetHashCode() + n);
						Crewmember crewmember4 = InstantiateCrewWithSeed(crewmember3, seed3, perkUIGridElement.perkPrefab.extraCrewChooseWithMatchingComment, perkUIGridElement.perkPrefab);
						list.Add(crewmember4);
						UnityEngine.Object.Destroy(crewmember4.gameObject);
					}
				}
				if (FFU_BE_Defs.perkStoredBlueprintIDs.ContainsKey(perkUIGridElement.perkPrefab.PrefabId))
					foreach (int moduleID in FFU_BE_Defs.perkStoredBlueprintIDs[perkUIGridElement.perkPrefab.PrefabId])
						FFU_BE_Defs.perkModuleBlueprintIDs.Add(moduleID);
				extraModules += perkUIGridElement.perkPrefab.extraModules.Length;
			}
			(shipHealth.Value as Text).text = baseMaxHP.ToString("0") + "/" + baseMaxHP.ToString("0");
			WorldRules.StartingBonus startingBonus = WorldRules.Instance.beginnerStartingBonus;
			SetResourceElementText(fuel, fuelWarning, baseFuel, Mathf.RoundToInt(coreFuel.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(organics, organicsWarning, baseOrganics, Mathf.RoundToInt(coreOrganics.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(explosives, explosivesWarning, baseExplosives, Mathf.RoundToInt(coreExplosives.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(exotics, exoticsWarning, baseExotics, Mathf.RoundToInt(coreExotics.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(synthetics, syntheticsWarning, baseSynthetics, Mathf.RoundToInt(coreSynthetics.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(metals, metalsWarning, baseMetals, Mathf.RoundToInt(coreMetals.min * FFU_BE_Defs.GetStartingResDiffMult()));
			SetResourceElementText(credits, creditsWarning, baseCredits, Mathf.RoundToInt(coreCredits.min * FFU_BE_Defs.GetStartingResDiffMult()));
			FFU_BE_Defs.initialResources.fuel = baseFuel.min + coreFuel.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.organics = baseOrganics.min + coreOrganics.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.explosives = baseExplosives.min + coreExplosives.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.exotics = baseExotics.min + coreExotics.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.synthetics = baseSynthetics.min + coreSynthetics.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.metals = baseMetals.min + coreMetals.min * FFU_BE_Defs.GetStartingResDiffMult();
			FFU_BE_Defs.initialResources.credits = baseCredits.min + coreCredits.min * FFU_BE_Defs.GetStartingResDiffMult();
			float startingBonusMult = FFU_BE_Defs.GetStartingModDiffMult();
			string bonusColor = startingBonusMult > 0 ? "lime" : "red";
			string valueSign = startingBonusMult > 0 ? "↑" : "↓";
			(shipAccuracyBonus.Value as Text).text = $"{baseAccuracy.ToString("0")}{(startingBonusMult != 0 ? $" <color={bonusColor}>{valueSign}{Mathf.Abs(startingBonus.accuracyBonusPercent * startingBonusMult):0}</color>" : null)}%";
			(shipDeflectionBonus.Value as Text).text = $"{baseDefelection.ToString("0")}{(startingBonusMult != 0 ? $" <color={bonusColor}>{valueSign}{Mathf.Abs(startingBonus.deflectionBonusPercent * startingBonusMult):0}</color>" : null)}%";
			(shipEvasionBonus.Value as Text).text = $"{baseEvasion.ToString("0")}{(startingBonusMult != 0 ? $" <color={bonusColor}>{valueSign}{Mathf.Abs(startingBonus.evasionBonusPercent * startingBonusMult):0}</color>" : null)}°/ₘ";
			int crewRegular = 0;
			int crewPets = 0;
			int crewDrones = 0;
			foreach (Crewmember item in list) {
				if (item != null) {
					switch (item.type) {
						case Crewmember.Type.Regular: crewRegular++; break;
						case Crewmember.Type.Pet: crewPets++; break;
						case Crewmember.Type.Drone: crewDrones++; break;
					}
				}
			}
			(crewCount.Value as Text).text = crewRegular.ToString();
			(petCount.Value as Text).text = crewPets.ToString();
			(droneCount.Value as Text).text = crewDrones.ToString();
			RstUtil.RebuildUiList(crewList.Value.transform, crewListItemProto.Value as CrewOnPerksSelectionListItem, list, delegate (CrewOnPerksSelectionListItem ui, Crewmember crew) {
				patch_PerksSelection perksSelection = this;
				ui.FillWithDataFrom(crew);
				ui.displayName.onEndEdit.RemoveAllListeners();
				ui.displayName.onEndEdit.AddListener(delegate (string newName) { perksSelection.ChangeCrewName(crew, newName); });
			});
			int storageSizeInShipPrefab = GetStorageSizeInShipPrefab(ship);
			(extraModulesCount.Value as Text).text = extraModules + "/" + storageSizeInShipPrefab;
			bool flag = extraModules > storageSizeInShipPrefab;
			if (extraModulesWarning.Value.activeSelf != flag) extraModulesWarning.Value.SetActive(flag);
		}
		//Storage Capacity from Modded Dictionary
		[MonoModReplace] private static int GetStorageSizeInShipPrefab(Ship shipPrefab) {
			if (FFU_BE_Defs.shipPrefabsStorageSize.ContainsKey(shipPrefab.PrefabId)) return FFU_BE_Defs.shipPrefabsStorageSize[shipPrefab.PrefabId];
			foreach (Transform item in shipPrefab.transform) {
				if (item.CompareTag("Module slot root")) {
					Instantiate moduleCreator = item.GetComponent<ModuleSlotRoot>().ModuleCreator;
					if (moduleCreator != null && moduleCreator.Prefab != null) {
						ShipModule component = moduleCreator.Prefab.GetComponent<ShipModule>();
						if (component != null && component.type == ShipModule.Type.Storage) {
							return component.GetComponent<StorageModule>().slotCount;
						}
					}
				}
			}
			return 0;
		}
		//Color base on Starting Bonus Amount
		private static void SetResourceElementText(FsmObject textObj, FsmGameObject warningGO, FloatMinMax value, int startingBonus) {
			string valueSign = startingBonus > 0 ? "↑" : "↓";
			bool notEnoughRes = value.min + startingBonus < 0f || value.max + startingBonus < 0f;
			(textObj.Value as Text).text = notEnoughRes ? $"<color=red>{value.ToString("0")} {(startingBonus != 0 ? $"{valueSign}{Mathf.Abs(startingBonus)}" : null)}</color>" : $"{value.ToString("0")} <color={(startingBonus > 0 ? "lime" : "red")}>{(startingBonus != 0 ? $"{valueSign}{Mathf.Abs(startingBonus)}" : null)}</color>";
			warningGO.Value.SetActive(notEnoughRes);
		}
	}
	public class patch_CrewOperatesModule : CrewOperatesModule {
		public extern void orig_OnEnter();
		public extern void orig_OnExit();
		[MonoModIgnore] private Crewmember crew;
		//Recalculate Ship's Signature on Crew's Entry
		public override void OnEnter() {
			orig_OnEnter();
			if (crew != null) if (crew.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Crew's Exit
		public override void OnExit() {
			orig_OnExit();
			if (crew != null) if (crew.Ownership.GetOwner() == Ownership.Owner.Me) FFU_BE_Defs.RecalculateEnergyEmission();
		}
	}
	public class patch_CrewResumeCmd : CrewResumeCmd {
		[MonoModIgnore] private Crewmember crew;
		//Allows Crewmembers to Operate Damaged Modules
		[MonoModReplace] public override void OnEnter() {
			Finish();
			GameObject ownerDefaultTarget = base.Fsm.GetOwnerDefaultTarget(gameObject);
			crew = ownerDefaultTarget?.GetComponent<Crewmember>();
			if (crew == null || crew.IsDead) return;
			Ownership.Owner crewOwner = crew.Ownership.GetOwner();
			if (prevTargetGo.Value == null) {
				crew.Idle(true);
				return;
			}
			ShipModule cModule = prevTargetGo.Value.GetComponent<ShipModule>();
			if (cModule != null) {
				Ownership.Owner moduleOwner = cModule.Ownership.GetOwner();
				if (crewOwner == moduleOwner) {
					if (cModule.HasFullHealth) crew.Operate(cModule, false, false);
					else if (crew.role == Crewmember.Role.RepairOfficer) crew.Repair(cModule, false, false);
					else if (FFU_BE_Defs.DamagedButWorking(cModule)) crew.Operate(cModule, false, false);
					else crew.Repair(cModule, false, false);
				} else if (crewOwner == Ownership.GetOpposite(moduleOwner)) crew.Attack(cModule.gameObject, false);
				return;
			}
			Crewmember cCrew = prevTargetGo.Value.GetComponent<Crewmember>();
			if (cCrew != null && crewOwner == Ownership.GetOpposite(cCrew.Ownership.GetOwner())) {
				crew.Attack(cCrew.gameObject, false);
				return;
			}
			DamageToken cDamage = prevTargetGo.Value.GetComponent<DamageToken>();
			if (cDamage != null) crew.Repair(cDamage, false, false);
			else crew.Idle(true);
		}
	}
}