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
			float salvageDamageMin = FFU_BE_Defs.GetDifficultyChanceMin();
			float salvageDamageMax = FFU_BE_Defs.GetDifficultyChanceMax();
			foreach (ShipModule cachedModule in PerFrameCache.CachedModules) {
				if (cachedModule != null && !cachedModule.IsPacked && cachedModule.Ownership.GetIsOrphan()) {
					if (cachedModule.Health == cachedModule.MaxHealth) cachedModule.TakeDamage(UnityEngine.Random.Range(Mathf.RoundToInt(cachedModule.MaxHealth * salvageDamageMin), Mathf.RoundToInt(cachedModule.MaxHealth * salvageDamageMax) + 1));
					list.Add(cachedModule.gameObject);
				}
			}
			list.Sort((GameObject a, GameObject b) => a.name.CompareTo(b.name));
			object[] array2 = storeModuleGOs.Values = list.ToArray();
			storeModuleCount.Value = list.Count;
		}
	}
	public class patch_PerksSelection : PerksSelection {
		public extern void orig_OnEnter();
		//Configurable Starting Fate
		public override void OnEnter() {
			firstRunFate.Value = FFU_BE_Defs.newStartingFateBonus;
			orig_OnEnter();
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