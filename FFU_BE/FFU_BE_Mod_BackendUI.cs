#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0169
#pragma warning disable CS0436
#pragma warning disable CS0414
#pragma warning disable CS0114

using UnityEngine;
using System.Collections.Generic;
using FFU_Bleeding_Edge;
using UnityEngine.UI;
using System.Linq;
using MonoMod;
using System;
using System.Text.RegularExpressions;
using HarmonyLib;
using ClickToBind;

namespace RST.UI {
	[ExecuteInEditMode]
	[RequireComponent(typeof(LayoutElement))]
	[MonoModReplace] public class UISetPreferredHeight : MonoBehaviour {
		[Tooltip("Height of heightSource is copied over to LayoutElement.preferredHeight on this GO")]
		public RectTransform heightSource;
		[Tooltip("Adds or substracts from calculated LayoutElement.preferredHeight")]
		public float heightOffset;
		[Tooltip("If set then LayoutElement.preferredHeight is kept below or equal to maxHeight")]
		public float maxHeight;
		public float minHeight;
		private LayoutElement le;
		private void OnEnable() {
			LateUpdate();
		}
		private void LateUpdate() {
			if (le == null) {
				le = GetComponent<LayoutElement>();
			}
			if (!(le == null) && !(heightSource == null)) {
				float num = heightSource.sizeDelta.y + heightOffset;
				if (minHeight > 0f && num < minHeight) num = minHeight;
				if (maxHeight > 0f && num > maxHeight) num = maxHeight;
				le.preferredHeight = num;
			}
		}
	}
	public class patch_ResourceActionsPanel : ResourceActionsPanel {
		[MonoModIgnore] private ShipModule resPackPrefab;
		[MonoModIgnore] private PlayerResource GetPlayerResource(PlayerData pd) { return null; }
		[MonoModReplace] private bool ResPackCraftCheck(out int resToPack, out ResourceValueGroup cost, out ResourceValueGroup packValue, out bool hasUsableStorage, out bool hasEnoughForPayingCraftingCost, out bool craftNotDisabled) {
		/// Consume Full Cost on Resource Pack From Action Panel
			PlayerData me = PlayerDatas.Me;
			PlayerResource playerResource = GetPlayerResource(me);
			resToPack = 0;
			packValue = default;
			cost = WorldRules.Instance.resourcePackCraftCost;
			switch (type) {
				case ResourceType.Fuel:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.fuel - cost.fuel));
				packValue.fuel = resToPack;
				break;
				case ResourceType.Organics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.organics - cost.organics));
				packValue.organics = resToPack;
				break;
				case ResourceType.Explosives:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.explosives - cost.explosives));
				packValue.explosives = resToPack;
				break;
				case ResourceType.Exotics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.exotics - cost.exotics));
				packValue.exotics = resToPack;
				break;
				case ResourceType.Synthetics:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.synthetics - cost.synthetics));
				packValue.synthetics = resToPack;
				break;
				case ResourceType.Metals:
				resToPack = Mathf.Min(playerResource.Total, (int)(resPackPrefab.scrapGet.metals - cost.metals));
				packValue.metals = resToPack;
				break;
			}
			cost += packValue;
			hasEnoughForPayingCraftingCost = cost.CheckHasEnough(me, 1f);
			hasUsableStorage = !WorldRules.Impermanent.StorageDisabled && StoragePanel.HasRoom(Ownership.Owner.Me);
			craftNotDisabled = !WorldRules.Impermanent.moduleCraftDisabled;
			return hasUsableStorage & hasEnoughForPayingCraftingCost & craftNotDisabled;
		}
	}
	public class patch_PlayerPanel : PlayerPanel {
		private extern void orig_Update();
		[MonoModIgnore] private int prevEvasion;
		private void Update() {
		/// Spam Reduction Timers & Modified Interface
			FFU_BE_Mod_Backend.timePassedOrganics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedFuel += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedMetals += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedSynthetics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedExplosives += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedExotics += Time.unscaledDeltaTime;
			FFU_BE_Mod_Backend.timePassedCredits += Time.unscaledDeltaTime;
			if (FFU_BE_Mod_Backend.timePassedOrganics > 10000f) FFU_BE_Mod_Backend.timePassedOrganics = 50f;
			if (FFU_BE_Mod_Backend.timePassedFuel > 10000f) FFU_BE_Mod_Backend.timePassedFuel = 50f;
			if (FFU_BE_Mod_Backend.timePassedMetals > 10000f) FFU_BE_Mod_Backend.timePassedMetals = 50f;
			if (FFU_BE_Mod_Backend.timePassedSynthetics > 10000f) FFU_BE_Mod_Backend.timePassedSynthetics = 50f;
			if (FFU_BE_Mod_Backend.timePassedExplosives > 10000f) FFU_BE_Mod_Backend.timePassedExplosives = 50f;
			if (FFU_BE_Mod_Backend.timePassedExotics > 10000f) FFU_BE_Mod_Backend.timePassedExotics = 50f;
			if (FFU_BE_Mod_Backend.timePassedCredits > 10000f) FFU_BE_Mod_Backend.timePassedCredits = 50f;
			orig_Update();
			int newEvasion = prevEvasion + 1;
			if (Time.frameCount % 30 == 0 && !WarningsVisualizer.EnemyShipsPresentWarning) FFU_BE_Defs.RecalculateEnergyEmission();
			for (int i = 0; i < researchCreditsBonus.transform.childCount; i++) researchCreditsBonus.transform.GetChild(i).gameObject.SetActive(false);
			researchCreditsBonus.text = FFU_BE_Mod_Technology.GetCraftChanceText().Replace("MK-", string.Empty).Replace(": ", string.Empty).Replace("I", string.Empty).Replace("V", string.Empty).Replace("X", string.Empty);
			shipEvasion.SetText(prevEvasion, ref newEvasion, (int i) => i.ToString() + $"°/ₘ");
		}
		[MonoModReplace] private static string BuildResearchCreditsBonusHover(int researchCreditsBonus) {
		/// Update Research Pop-Up to Show Modified Data
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 2 && Input.GetKeyDown(KeyCode.PageUp) && !Input.GetKeyDown(KeyCode.PageDown)) FFU_BE_Mod_Technology.RotateResearchListForward();
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 2 && !Input.GetKeyDown(KeyCode.PageUp) && Input.GetKeyDown(KeyCode.PageDown)) FFU_BE_Mod_Technology.RotateResearchListBackward();
			string currentEnergyEmission = "<b>Flagship Energy Emission</b>: " + string.Format("{0:0.#}", FFU_BE_Defs.energyEmission) + "m³" + "\n";
			string hostileAwarenessLevel = "<b>Local Forces Awareness Level</b>: " + FFU_BE_Mod_Discovery.GetHostileAwarnessLevel() + (FFU_BE_Defs.allStatProps ? " (" + string.Format("{0:0.###}", FFU_BE_Defs.distanceTraveledInPeace / FFU_BE_Mod_Discovery.GetCurrentScanFrequency() * 100f) + "%)" : "") + "\n";
			string hostileEnforcersStrength = "<b>Local Forces Military Strength</b>: " + FFU_BE_Mod_Discovery.GetHostileFleetsLevel() + (FFU_BE_Defs.allStatProps ? " (" + string.Format("{0:0.###}", FFU_BE_Mod_Discovery.GetKilledFleetsCount() / FFU_BE_Mod_Discovery.GetTopFleetsTrigger() * 100f) + "%)" : "") + "\n";
			string tierResearchProgress = "<b>Research Progress</b>: " + FFU_BE_Mod_Technology.GetCraftChanceText() + (FFU_BE_Defs.allStatProps ? " (" + string.Format("{0:0.###}", FFU_BE_Defs.researchProgress) + ")" : "") + "\n";
			string reverseEngineeringProgress = FFU_BE_Defs.unresearchedModuleIDs.ToList().Count == 0 ? "<b>Reverse Engineering</b>: (No Active Project)" : "<b>Reverse Engineering</b>: " +
				FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == FFU_BE_Defs.unresearchedModuleIDs.ToList().First()).displayName + " " +
				string.Format("{0:0}", FFU_BE_Defs.moduleResearchProgress / FFU_BE_Defs.moduleResearchGoal * 100f) + "%" + (FFU_BE_Defs.allStatProps ? " (" +
				string.Format("{0:0.###}", FFU_BE_Defs.moduleResearchProgress) + "/" + string.Format("{0:0}", FFU_BE_Defs.moduleResearchGoal) + ")" : "");
			string reverseEngineeringQueue = "";
			bool postfixShown = false;
			int totalQueueEntries = 0;
			int totalQueueEntriesMax = (int)((Screen.height - 500) / 35f);
			if (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count > 1) {
				reverseEngineeringQueue = "\n" + "<b>Reverse Engineering Queue</b>:";
				foreach (int unresearchedModuleID in FFU_BE_Defs.unresearchedModuleIDs.ToList()) {
					if (unresearchedModuleID != FFU_BE_Defs.unresearchedModuleIDs.ToList().First() && totalQueueEntries < totalQueueEntriesMax)
						reverseEngineeringQueue += "\n" + " > " + FFU_BE_Defs.prefabModdedModulesList.Find(x => x.PrefabId == unresearchedModuleID).displayName;
					else if (!postfixShown && totalQueueEntries > (totalQueueEntriesMax - 1)) {
						reverseEngineeringQueue += "\n" + "<b>...and " + (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count - totalQueueEntriesMax) +
							" module" + (FFU_BE_Defs.unresearchedModuleIDs.ToList().Count - totalQueueEntriesMax > 1 ? "s" : "") + " more in research queue...</b>";
						postfixShown = true;
					}
					totalQueueEntries++;
				}
			}
			return "<color=lime>" + currentEnergyEmission + hostileAwarenessLevel + hostileEnforcersStrength + tierResearchProgress + reverseEngineeringProgress + reverseEngineeringQueue + "</color>";
		}
		private class ResourceBlock {
		/// Limit Interface Size and Reduce Text Spam
			[MonoModIgnore] public int resouceChangeSize;
			[MonoModIgnore] public float animDuration;
			[MonoModIgnore] public Color textChangingColor;
			[MonoModIgnore] public AnimationCurve changingAnim;
			[MonoModIgnore] public float risingTextSpeed;
			[MonoModIgnore] public Color barColor;
			[MonoModIgnore] private int lastValue;
			[MonoModIgnore] private int lastMaxValue;
			[MonoModIgnore] private float timer;
			[MonoModIgnore] public int LastValue;
			[MonoModIgnore] public int LastMaxValue;
			[MonoModIgnore] public ResourceBlock(PlayerPanel ui, Color? barColor = null) { }
			[MonoModIgnore] public bool Show(PlayerResource r, Text text, GameObject changeShowPos) { return false; }
			[MonoModIgnore] public bool Show(PlayerResource r, Text text, GameObject changeShowPos, int ifCurValueLowerThanThisThenMakeItRed) { return false; }
			[MonoModIgnore] public bool Show(int curValue, Text text, GameObject changeShowPos, List<string> changeReasons, string name) { return false; }
			[MonoModIgnore] public bool Show(int curValue, int maxValue, Text text, GameObject changeShowPos, Image bar, LayoutElement maxBar, Texture2D specter, string name) { return false; }
			[MonoModIgnore] public bool Show(int curValue, int maxValue, Text text, GameObject changeShowPos, string name) { return false; }
			[MonoModReplace] private bool PrivateShow(int curValue, int maxValue, int ifCurValueLowerThanThisThenMakeItRed, Text text, GameObject changeShowPos, List<string> reasons, Image bar, LayoutElement maxBar, Texture2D specter, string name) {
				bool result = false;
				if (text != null) {
					if (lastValue != curValue || lastMaxValue != maxValue) {
						FireRaisingText(changeShowPos, curValue, lastValue, reasons, (!string.IsNullOrEmpty(name)) ? MonoBehaviourExtended.TT(name).ToLowerInvariant() : null);
						string valueText = (curValue < ifCurValueLowerThanThisThenMakeItRed) ? ("<color=red>" + curValue + "</color>") : curValue.ToString();
						text.text = (maxValue != int.MaxValue) ? (valueText + " / " + maxValue) : valueText;
						if (bar != null) {
							int shortCurValue = curValue / FFU_BE_Defs.pointsPerBarItem;
							float barWidthLimit = Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width;
							bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, shortCurValue * bar.sprite.rect.width > barWidthLimit ? barWidthLimit : (shortCurValue * bar.sprite.rect.width));
						}
						if (maxBar != null) {
							int shortMaxValue = maxValue / FFU_BE_Defs.pointsPerBarItem;
							float maxBarWidthLimit = Screen.width - 750 - (Screen.width - 750) % bar.sprite.rect.width;
							maxBar.preferredWidth = shortMaxValue * bar.sprite.rect.width > maxBarWidthLimit ? maxBarWidthLimit : (shortMaxValue * bar.sprite.rect.width);
						}
						timer = 0f;
						lastValue = curValue;
						lastMaxValue = maxValue;
						result = true;
					}
					Color uiColor = VisualSettings.Instance.uiColor;
					text.color = Color.Lerp(uiColor, textChangingColor, changingAnim.Evaluate(timer / animDuration));
					if (bar != null && specter != null) {
						Color pixelBilinear = specter.GetPixelBilinear(curValue / (float)maxValue, 0.5f);
						bar.color = Color.Lerp(pixelBilinear, barColor, changingAnim.Evaluate(timer / animDuration));
					}
					timer += Time.unscaledDeltaTime;
				}
				return result;
			}
			[MonoModReplace] private void FireRaisingText(GameObject posGO, int value, int lastValue, List<string> reasons, string name) {
				ResourceValueGroup pData = PlayerDatas.Me != null ? PlayerDatas.Me.Resources : ResourceValueGroup.Empty;
				switch (name) {
					case "organics":
					if (FFU_BE_Mod_Backend.timePassedOrganics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedOrganics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueOrganics;
						FFU_BE_Mod_Backend.lastValueOrganics = (int)pData.organics;
					} else return;
					break;
					case "fuel":
					if (FFU_BE_Mod_Backend.timePassedFuel >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedFuel = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueFuel;
						FFU_BE_Mod_Backend.lastValueFuel = (int)pData.fuel;
					} else return;
					break;
					case "metals":
					if (FFU_BE_Mod_Backend.timePassedMetals >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedMetals = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueMetals;
						FFU_BE_Mod_Backend.lastValueMetals = (int)pData.metals;
					} else return;
					break;
					case "synthetics":
					if (FFU_BE_Mod_Backend.timePassedSynthetics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedSynthetics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueSynthetics;
						FFU_BE_Mod_Backend.lastValueSynthetics = (int)pData.synthetics;
					} else return;
					break;
					case "explosives":
					if (FFU_BE_Mod_Backend.timePassedExplosives >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedExplosives = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueExplosives;
						FFU_BE_Mod_Backend.lastValueExplosives = (int)pData.explosives;
					} else return;
					break;
					case "exotics":
					if (FFU_BE_Mod_Backend.timePassedExotics >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedExotics = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueExotics;
						FFU_BE_Mod_Backend.lastValueExotics = (int)pData.exotics;
					} else return;
					break;
					case "credits":
					if (FFU_BE_Mod_Backend.timePassedCredits >= FFU_BE_Defs.timePassedCycle) {
						FFU_BE_Mod_Backend.timePassedCredits = 0f;
						lastValue = FFU_BE_Mod_Backend.lastValueCredits;
						FFU_BE_Mod_Backend.lastValueCredits = (int)pData.credits;
					} else return;
					break;
				}
				if (lastValue >= 0) {
					string text = "";
					if (reasons != null) {
						List<string> list = new List<string>();
						foreach (string reason in reasons) {
							string item = MonoBehaviourExtended.TT(reason);
							if (!list.Contains(item)) list.Add(item);
						}
						text = string.Join(", ", list.ToArray());
						reasons.Clear();
					}
					int num = value - lastValue;
					if (num != 0 && !string.IsNullOrEmpty(text)) {
						Vector2 dir = new Vector2(0f, 1f);
						string text2 = " <size=" + resouceChangeSize + ">" + num.ToString("+0;-0") + ((!string.IsNullOrEmpty(name)) ? (" " + name) : "") + " (" + text + ")</size>";
						RisingText risingText = RisingText.FireAndForget(posGO, Vector2.zero, text2, (num >= 0) ? Color.green : Color.red, RisingText.Space.UI, dir, true);
						risingText.lifetime = animDuration;
						risingText.speed = risingTextSpeed;
					}
				}
			}
		}
	}
	public class patch_StoragePanel : StoragePanel {
		[MonoModIgnore] private HoverableUI upgradeButtonHover;
		[MonoModReplace] public void UpdateUpgradeButton(Ownership.Owner resourcesGoTo) {
		/// Modified Max Storage Capacity Upgrade
			PlayerData playerData = PlayerDatas.Get(resourcesGoTo);
			ResourceValueGroup r = (playerData != null) ? playerData.Resources : ResourceValueGroup.Empty;
			WorldRules instance = WorldRules.Instance;
			StorageModule storageModule = GetStorageModule(resourcesGoTo, false);
			bool canIncrease = storageModule != null && storageModule.slotCount < FFU_BE_Defs.maxStorageCapacity;
			bool hasResources = instance.storageUpgradeCost.CheckHasEnough(r);
			if (!canIncrease) upgradeButtonHover.HoverText = MonoBehaviourExtended.TT("Maximum slot count reached");
			else if (!hasResources) upgradeButtonHover.HoverText = MonoBehaviourExtended.TT("Not enough resources for upgrading");
			else upgradeButtonHover.HoverText = "";
			upgradeButton.interactable = storageModule != null && canIncrease && hasResources;
		}
		[MonoModReplace] public static void Upgrade() {
		/// Modified Max Storage Capacity Upgrade
			PlayerData me = PlayerDatas.Me;
			StorageModule storageModule = GetStorageModule(Ownership.Owner.Me, false);
			if (me == null || storageModule == null) return;
			WorldRules instance = WorldRules.Instance;
			if (storageModule.slotCount < FFU_BE_Defs.maxStorageCapacity) {
				ResourceValueGroup storageUpgradeCost = WorldRules.Instance.storageUpgradeCost;
				if (storageUpgradeCost.ConsumeFrom(me, 1f, Localization.tt("storage upgrade"))) {
					FFU_BE_Defs.shipCurrentStorageCap = storageModule.slotCount + 1;
					storageModule.slotCount++;
				}
			}
		}
	}
	public class patch_MenuNewGamePanel : MenuNewGamePanel {
		public extern void orig_OnEnable();
		public extern void orig_NewGameBeginnerClicked();
		public extern void orig_NewGameChallengingClicked();
		public extern void orig_NewGameHardcoreClicked();
		public Transform buttonPanel => transform.GetChild(1).GetChild(0);
		public Transform buttonBeginner => buttonPanel.GetChild(2);
		public Transform buttonChallenging => buttonPanel.GetChild(3);
		public Transform buttonHardcore => buttonPanel.GetChild(4);
		public Text textTutorialButton => startTutorialButton.transform.GetChild(0).GetComponent<Text>();
		public Text textBeginnerButton => startBeginnerButton.transform.GetChild(0).GetComponent<Text>();
		public Text textChallengeButton => startChallengingButton.transform.GetChild(0).GetComponent<Text>();
		public Text textHardcoreButton => startHardcoreButton.transform.GetChild(0).GetComponent<Text>();
		public GameObject entryBeginnerItemsGO => buttonBeginner.GetChild(1).GetChild(2).GetChild(3).gameObject;
		public Text entryButtonBText1 => buttonBeginner.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>();
		public Text entryButtonBText2 => buttonBeginner.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>();
		public Text entryButtonBText3 => buttonBeginner.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
		public Text entryButtonCText1 => buttonChallenging.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>();
		public Text entryButtonCText2 => buttonChallenging.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>();
		public Text entryButtonCText3 => buttonChallenging.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
		public Text entryButtonHText1 => buttonHardcore.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>();
		public Text entryButtonHText2 => buttonHardcore.GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>();
		public Text entryButtonHText3 => buttonHardcore.GetChild(1).GetChild(2).GetChild(0).GetComponent<Text>();
		public Image entryButtonBSign1 => buttonBeginner.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>();
		public Image entryButtonBSign2 => buttonBeginner.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();
		public Image entryButtonBSign3 => buttonBeginner.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>();
		public Image entryButtonCSign1 => buttonChallenging.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>();
		public Image entryButtonCSign2 => buttonChallenging.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();
		public Image entryButtonCSign3 => buttonChallenging.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>();
		public Image entryButtonHSign1 => buttonHardcore.GetChild(1).GetChild(0).GetChild(2).GetComponent<Image>();
		public Image entryButtonHSign2 => buttonHardcore.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();
		public Image entryButtonHSign3 => buttonHardcore.GetChild(1).GetChild(2).GetChild(2).GetComponent<Image>();
		public Image entryButtonBColor1 => buttonBeginner.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
		public Image entryButtonBColor2 => buttonBeginner.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
		public Image entryButtonBColor3 => buttonBeginner.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
		public Image entryButtonCColor1 => buttonChallenging.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
		public Image entryButtonCColor2 => buttonChallenging.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
		public Image entryButtonCColor3 => buttonChallenging.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
		public Image entryButtonHColor1 => buttonHardcore.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
		public Image entryButtonHColor2 => buttonHardcore.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
		public Image entryButtonHColor3 => buttonHardcore.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
		public Image entryButtonBBackground => buttonBeginner.GetChild(0).GetChild(0).GetComponent<Image>();
		public Image entryButtonCBackground => buttonChallenging.GetChild(0).GetChild(0).GetComponent<Image>();
		public Image entryButtonHBackground => buttonHardcore.GetChild(0).GetChild(0).GetComponent<Image>();
		private bool isIDDQDmode;
		private void OnEnable() {
			orig_OnEnable();
			entryBeginnerItemsGO.SetActive(false);
			if (!FFU_BE_Defs.dataMenuSpritesLoaded) {
				FFU_BE_Defs.dataMenuSpritesSet.Add(entryButtonCSign1.sprite);
				FFU_BE_Defs.dataMenuSpritesSet.Add(entryButtonCSign3.sprite);
				FFU_BE_Defs.dataMenuSpritesSet.Add(entryButtonBBackground.sprite);
				FFU_BE_Defs.dataMenuSpritesSet.Add(entryButtonCBackground.sprite);
				FFU_BE_Defs.dataMenuSpritesSet.Add(entryButtonHBackground.sprite);
				FFU_BE_Defs.dataMenuSpritesLoaded = true;
			}
			textTutorialButton.text = Core.TT(Datas.diffTextTut);
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
				textBeginnerButton.text = Core.TT(Datas.diffTextBrut);
				textChallengeButton.text = Core.TT(Datas.diffTextIns);
				textHardcoreButton.text = Core.TT(Datas.diffTextNight);
				UpdateDifficultySprites(true);
				UpdateDifficultyHints(true);
				isIDDQDmode = true;
			} else {
				textBeginnerButton.text = Core.TT(Datas.diffTextEasy);
				textChallengeButton.text = Core.TT(Datas.diffTextMed);
				textHardcoreButton.text = Core.TT(Datas.diffTextHard);
				UpdateDifficultySprites(false);
				UpdateDifficultyHints(false);
				isIDDQDmode = false;
			}
		}
		private void NewGameBeginnerClicked() {
			if (isIDDQDmode) FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Brutal;
			else FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Easy;
			orig_NewGameBeginnerClicked();
		}
		private void NewGameChallengingClicked() {
			if (isIDDQDmode) FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Insane;
			else FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Medium;
			orig_NewGameChallengingClicked();
		}
		private void NewGameHardcoreClicked() {
			if (isIDDQDmode) FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Nightmare;
			else FFU_BE_Defs.chosenDifficulty = Core.Difficulty.Hard;
			orig_NewGameHardcoreClicked();
		}
		private void UpdateDifficultySprites(bool isDifficult) {
			if (isDifficult) {
				entryButtonBBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[3];
				entryButtonCBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[4];
				entryButtonHBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[4];
				entryButtonBSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonBSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonBSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonCSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonCSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonCSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonHSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonHSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonHSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonBColor1.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonBColor2.color = new Color { r = 1, g = 0.7f, b = 0, a = 1 };
				entryButtonBColor3.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonCColor1.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonCColor2.color = new Color { r = 1, g = 0.4f, b = 0, a = 1 };
				entryButtonCColor3.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonHColor1.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonHColor2.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonHColor3.color = new Color { r = 1, g = 0, b = 0, a = 1 };
			} else {
				entryButtonBBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[2];
				entryButtonCBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[2];
				entryButtonHBackground.sprite = FFU_BE_Defs.dataMenuSpritesSet[3];
				entryButtonBSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonBSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonBSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonCSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonCSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonCSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonHSign1.sprite = FFU_BE_Defs.dataMenuSpritesSet[0];
				entryButtonHSign2.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonHSign3.sprite = FFU_BE_Defs.dataMenuSpritesSet[1];
				entryButtonBColor1.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonBColor2.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonBColor3.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonCColor1.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonCColor2.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonCColor3.color = new Color { r = 1, g = 0, b = 0, a = 1 };
				entryButtonHColor1.color = new Color { r = 0, g = 1, b = 0, a = 1 };
				entryButtonHColor2.color = new Color { r = 1, g = 1, b = 0, a = 1 };
				entryButtonHColor3.color = new Color { r = 1, g = 0, b = 0, a = 1 };
			}
		}
		private void UpdateDifficultyHints(bool isDifficult) {
			if (isDifficult) {
				entryButtonBText1.text = Core.TT(Datas.diffPauseNo);
				entryButtonBText2.text = Core.TT(Datas.diffTechMed);
				entryButtonBText3.text = Core.TT(Datas.diffBonusBrut);
				entryButtonCText1.text = Core.TT(Datas.diffPauseNo);
				entryButtonCText2.text = Core.TT(Datas.diffTechHigh);
				entryButtonCText3.text = Core.TT(Datas.diffBonusIns);
				entryButtonHText1.text = Core.TT(Datas.diffPauseNo);
				entryButtonHText2.text = Core.TT(Datas.diffTechUltra);
				entryButtonHText3.text = Core.TT(Datas.diffBonusNight);
			} else {
				entryButtonBText1.text = Core.TT(Datas.diffPauseYes); 
				entryButtonBText2.text = Core.TT(Datas.diffTechNone);
				entryButtonBText3.text = Core.TT(Datas.diffBonusEasy);
				entryButtonCText1.text = Core.TT(Datas.diffPauseYes); 
				entryButtonCText2.text = Core.TT(Datas.diffTechNone);
				entryButtonCText3.text = Core.TT(Datas.diffBonusMed);
				entryButtonHText1.text = Core.TT(Datas.diffPauseYes);
				entryButtonHText2.text = Core.TT(Datas.diffTechLow);
				entryButtonHText3.text = Core.TT(Datas.diffBonusHard);
			}
		}
	}
	public class patch_TimePanelControls : TimePanelControls {
		[MonoModIgnore] private float lastTimeScale;
		[MonoModIgnore] private bool lastControlsDisabled;
		[MonoModIgnore] private bool lastPauseDisabled;
		[MonoModIgnore] private void DoFastForward() { }
		[MonoModIgnore] private void DoSlowMotion() { }
		[MonoModIgnore] private void DoPause() { }
		[MonoModIgnore] private void DoPlay() { }
		[MonoModReplace] private void Update() {
		/// Custom Difficulty Time Control
			if (lastTimeScale != RstTime.timeScale) {
				if (RstTime.IsPaused) DoPause();
				else if (RstTime.IsNormalSpeed) DoPlay();
				else if (RstTime.IsSlowMotion) DoSlowMotion();
				else if (RstTime.IsFastForward) DoFastForward();
				lastTimeScale = RstTime.timeScale;
			}
			if (!TimePanelControls.ControlsDisabled && KeyBindingManager.GetKeyUp(KeyAction.TimeToggle, KeyAction.TimeToggleAlt)) {
				if (RstTime.IsNormalSpeed) {
					if (!FFU_BE_Defs.GetDifficultyAllowPause()) slowMotionButton.onClick.Invoke();
					else pauseButton.onClick.Invoke();
				} else playButton.onClick.Invoke();
			}
			bool pauseDisabled = !FFU_BE_Defs.GetDifficultyAllowPause();
			if (lastPauseDisabled != pauseDisabled) {
				pauseButton.gameObject.SetActive(!pauseDisabled);
				pauseButton.GetComponent<HoverableUI>().HoverText = MonoBehaviourExtended.TT("Pause time") + ((!pauseDisabled) ? " [SPACE]" : "");
				slowMotionButton.GetComponent<HoverableUI>().HoverText = MonoBehaviourExtended.TT("Slow time") + (pauseDisabled ? " [SPACE]" : "");
				lastPauseDisabled = pauseDisabled;
			}
			bool flag = PerFrameCache.IsGoodSituation && IntviewCamera.Instance != null;
			if (visualizeGoodTime.activeSelf != flag) visualizeGoodTime.SetActive(flag);
		}
		public void SetSlowMo() => DoSlowMotion();
		public void SetPause() => DoPause();
	}
	public class patch_MenuProgressPanel : MenuProgressPanel {
		public HoverableUI GreenDiffHover => modeBeginner.GetComponent<HoverableUI>();
		public HoverableUI YellowDiffHover => modeChallenging.GetComponent<HoverableUI>();
		public HoverableUI RedDiffHover => modeHardcore.GetComponent<HoverableUI>();
		public Text GreenDiffText => modeBeginner.transform.GetChild(0).GetComponent<Text>();
		public Text YellowDiffText => modeChallenging.transform.GetChild(0).GetComponent<Text>();
		public Text RedDiffText => modeHardcore.transform.GetChild(0).GetComponent<Text>();
		public Text TutorialText => modeTutorial.transform.GetChild(0).GetComponent<Text>();
		private void Start() {
		/// Custom Difficulty Information
			PlayerData pData = PlayerDatas.Me;
			if (pData != null) {
				int number = Mathf.RoundToInt(pData.gameRunRecord.realTimePassed / 60f);
				sectorName.text = ((Sector.Instance != null) ? Sector.Instance.DisplayNameLocalized : "");
				playtime.text = Localization.TT(number, "minute|minutes");
				battlesSurvived.text = pData.gameRunRecord.battlesSurvived.ToString();
				shipsDestroyed.text = pData.gameRunRecord.shipsDestroyed.ToString();
				modulesFound.text = pData.gameRunRecord.modulesFound.ToString();
				planetsVisited.text = pData.gameRunRecord.planetsVisited.ToString();
				fatePoints.text = pData.RepPoints.ToString();
				UpdateInfo();
			}
		}
		public void UpdateInfo() {
			string nameText = ""; string descText = "";
			bool isTutorial = MainQuest.Instance != null && MainQuest.Instance.isTutorial;
			switch (FFU_BE_Defs.GetDifficultyIntValue()) {
				case 0: nameText = Datas.diffTextEasy; descText = $"{Core.TT(Datas.diffPauseYes)}\n{Core.TT(Datas.diffTechNone)}\n{Core.TT(Datas.diffBonusEasy)}"; break;
				case 1: nameText = Datas.diffTextMed; descText = $"{Core.TT(Datas.diffPauseYes)}\n{Core.TT(Datas.diffTechNone)}\n{Core.TT(Datas.diffBonusMed)}"; break;
				case 2: nameText = Datas.diffTextHard; descText = $"{Core.TT(Datas.diffPauseYes)}\n{Core.TT(Datas.diffTechLow)}\n{Core.TT(Datas.diffBonusHard)}"; break;
				case 3: nameText = Datas.diffTextBrut; descText = $"{Core.TT(Datas.diffPauseNo)}\n{Core.TT(Datas.diffTechMed)}\n{Core.TT(Datas.diffBonusBrut)}"; break;
				case 4: nameText = Datas.diffTextIns; descText = $"{Core.TT(Datas.diffPauseNo)}\n{Core.TT(Datas.diffTechHigh)}\n{Core.TT(Datas.diffBonusIns)}"; break;
				case 5: nameText = Datas.diffTextNight; descText = $"{Core.TT(Datas.diffPauseNo)}\n{Core.TT(Datas.diffTechUltra)}\n{Core.TT(Datas.diffBonusNight)}"; break;
			}
			GreenDiffHover.HoverText = descText;
			YellowDiffHover.HoverText = descText;
			RedDiffHover.HoverText = descText;
			GreenDiffText.text = nameText;
			YellowDiffText.text = nameText;
			RedDiffText.text = nameText;
			TutorialText.text = Core.TT(Datas.diffTextTut);
			modeTutorial.SetActive(isTutorial);
			if (FFU_BE_Defs.GetDifficultyIntValue() > 2) modeHardcore.SetActive(!isTutorial);
			else if (FFU_BE_Defs.GetDifficultyIntValue() > 0) modeChallenging.SetActive(!isTutorial);
			else modeBeginner.SetActive(!isTutorial);
		}
	}
}