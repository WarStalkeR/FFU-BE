#pragma warning disable IDE1006
#pragma warning disable IDE0044
#pragma warning disable IDE0002
#pragma warning disable CS0626
#pragma warning disable CS0649
#pragma warning disable CS0108
#pragma warning disable CS0169
#pragma warning disable CS0414
#pragma warning disable CS0114

using UnityEngine;
using System.Collections.Generic;
using FFU_Bleeding_Edge;
using UnityEngine.UI;
using System.Linq;
using MonoMod;

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
		//Consume Full Cost on Resource Pack From Action Panel
		[MonoModReplace] private bool ResPackCraftCheck(out int resToPack, out ResourceValueGroup cost, out ResourceValueGroup packValue, out bool hasUsableStorage, out bool hasEnoughForPayingCraftingCost, out bool craftNotDisabled) {
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
		//Spam Reduction Timers & Modified Interface
		private void Update() {
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
			for (int i = 0; i < researchCreditsBonus.transform.childCount; i++) researchCreditsBonus.transform.GetChild(i).gameObject.SetActive(false);
			researchCreditsBonus.text = FFU_BE_Mod_Technology.GetCraftChanceText().Replace("MK-", string.Empty).Replace(": ", string.Empty).Replace("I", string.Empty).Replace("V", string.Empty).Replace("X", string.Empty);
			shipEvasion.SetText(prevEvasion, ref newEvasion, (int i) => i.ToString() + $"°/ₘ");
		}
		//Update Research Pop-Up to Show Modified Data
		[MonoModReplace] private static string BuildResearchCreditsBonusHover(int researchCreditsBonus) {
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
		//Limit Interface Size and Reduce Text Spam
		private class ResourceBlock {
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
	public class patch_ModuleActionsPanel : ModuleActionsPanel {
		private extern void orig_StoreModule();
		private extern void orig_ModuleOvercharge();
		private extern void orig_PowerToggleChanged(bool newValue);
		//Recalculate Ship's Signature on Storing Module
		private void StoreModule() {
			orig_StoreModule();
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Overcharging Module
		private void ModuleOvercharge() {
			orig_ModuleOvercharge();
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
		//Recalculate Ship's Signature on Powering Module
		private void PowerToggleChanged(bool newValue) {
			orig_PowerToggleChanged(newValue);
			FFU_BE_Defs.RecalculateEnergyEmission();
		}
	}
	public class patch_StoragePanel : StoragePanel {
		[MonoModIgnore] private HoverableUI upgradeButtonHover;
		//Modified Max Storage Capacity Upgrade
		[MonoModReplace] public void UpdateUpgradeButton(Ownership.Owner resourcesGoTo) {
			PlayerData playerData = PlayerDatas.Get(resourcesGoTo);
			ResourceValueGroup r = (playerData != null) ? playerData.Resources : ResourceValueGroup.Empty;
			WorldRules instance = WorldRules.Instance;
			StorageModule storageModule = GetStorageModule(resourcesGoTo, false);
			bool canIncrease = storageModule != null && storageModule.slotCount < FFU_BE_Defs.maxStorageCapacity;
			bool hasResources = instance.storageUpgradeCost.CheckHasEnough(r);
			if (!canIncrease) upgradeButtonHover.hoverText = MonoBehaviourExtended.TT("Maximum slot count reached");
			else if (!hasResources) upgradeButtonHover.hoverText = MonoBehaviourExtended.TT("Not enough resources for upgrading");
			else upgradeButtonHover.hoverText = "";
			upgradeButton.interactable = storageModule != null && canIncrease && hasResources;
		}
		//Modified Max Storage Capacity Upgrade
		[MonoModReplace] public static void Upgrade() {
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
}