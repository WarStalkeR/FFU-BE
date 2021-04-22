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

namespace RST {
	[MonoModReplace] [RequireComponent(typeof(ShipModule))] public class MaterialsConverterModule : MonoBehaviourExtended, IHasModule, ILoadSave {
		public ResourceValueGroup consume;
		public ResourceValueGroup produce;
		public ResourceValueGroup[] consumeRecipes;
		public ResourceValueGroup[] produceRecipes;
		public float baseEfficiency = 0.25f;
		public float warmUpDissipation = 0.2f;
		public float maxWarmUpPoints = 100;
		public float currentWarmpUpPoints = 0;
		public float baseWarmUpPoints => maxWarmUpPoints * baseEfficiency;
		public float currentEfficiency => currentWarmpUpPoints / maxWarmUpPoints;
		[Localized] public string resourceConsumptionReason = "conversion";
		[Localized] public string resourceProductionReason = "conversion";
		public ShipModule Module => GetCachedComponent<ShipModule>(true);
		private void Awake() {
			currentWarmpUpPoints = baseWarmUpPoints;
		}
		private void Update() {
			if (!Module.IsPacked && Module.TurnedOnAndIsWorking) {
				if (currentWarmpUpPoints < baseWarmUpPoints) currentWarmpUpPoints = baseWarmUpPoints;
				if (currentWarmpUpPoints < maxWarmUpPoints) currentWarmpUpPoints += Time.deltaTime;
				if (currentWarmpUpPoints > maxWarmUpPoints) currentWarmpUpPoints = maxWarmUpPoints;
			} else if (Module.InStorage && currentWarmpUpPoints > baseWarmUpPoints) currentWarmpUpPoints = baseWarmUpPoints;
			else if (currentWarmpUpPoints > baseWarmUpPoints) currentWarmpUpPoints -= Time.deltaTime * warmUpDissipation;
		}
		public bool Convert(int convCount, int recipeNum) {
			/// Recipe-Based Resource Production
			if ((recipeNum + 1) > consumeRecipes.Length || (recipeNum + 1) > produceRecipes.Length) return false;
			PlayerData playerData = PlayerDatas.Get(Module.Ownership.GetOwner());
			if (playerData == null) return false;
			float convEff = Mathf.Clamp01(currentWarmpUpPoints / maxWarmUpPoints);
			if (consumeRecipes[recipeNum].ConsumeFrom(playerData, convCount, resourceConsumptionReason)) {
				if (Module.HasFullHealth) produceRecipes[recipeNum].ProduceTo(playerData, convCount * convEff, resourceProductionReason);
				else produceRecipes[recipeNum].ProduceTo(playerData, convCount * convEff * FFU_BE_Defs.GetHealthPercent(Module), resourceProductionReason);
				return true;
			}
			return false;
		}
		public bool Convert(int convCount) {
			/// Resource Production Amount from Damage
			PlayerData playerData = PlayerDatas.Get(Module.Ownership.GetOwner());
			if (playerData == null) return false;
			float convEff = Mathf.Clamp01(currentWarmpUpPoints / maxWarmUpPoints);
			if (consume.ConsumeFrom(playerData, convCount, resourceConsumptionReason)) {
				if (Module.HasFullHealth) produce.ProduceTo(playerData, convCount * convEff, resourceProductionReason);
				else produce.ProduceTo(playerData, convCount * convEff * FFU_BE_Defs.GetHealthPercent(Module), resourceProductionReason);
				return true;
			}
			return false;
		}
		public void Save(ES2Writer w) {
			w.Write(false, "MaterialsConverterModule.conversionInProgress");
			w.Write(0f, "MaterialsConverterModule.timer");
			w.Write(currentWarmpUpPoints, "MaterialsConverterModule.warmUpPoints");
			w.Write(warmUpDissipation, "MaterialsConverterModule.warmUpDissipation");
			w.Write(baseEfficiency, "MaterialsConverterModule.baseEfficiency");
		}
		public void Load(ES2Reader r) {
			if (r.TagExists("MaterialsConverterModule.warmUpPoints")) currentWarmpUpPoints = r.Read<float>("MaterialsConverterModule.warmUpPoints");
			if (r.TagExists("MaterialsConverterModule.warmUpDissipation")) warmUpDissipation = r.Read<float>("MaterialsConverterModule.warmUpDissipation");
			if (r.TagExists("MaterialsConverterModule.baseEfficiency")) baseEfficiency = r.Read<float>("MaterialsConverterModule.baseEfficiency");
		}
		public void Link() { }
	}
}

namespace RST.UI {
	[MonoModReplace] public class MaterialsConverterModuleUI : MonoBehaviourExtended {
		public Text displayName;
		public ResourceValueGroupUI consumeUi;
		public ResourceValueGroupUI produceUi;
		public ResourceValueGroupUI resRemainingUi;
		public ResourceValueGroupUI resSpentUi;
		public ResourceValueGroupUI toResUi;
		public Button minus;
		public Slider slider;
		public Button plus;
		public Button allocateExcessButton;
		public Button convButton;
		public GameObject excessWarning;
		public GameObject notUsableOverlay;
		private bool ignoreSliderChangedEvent;
		private int selectedCoversionRecipe;
		public MaterialsConverterModule Converter { get; private set; }
		public int ConvCount { get; private set; }
		public int MaxConvCount { get; private set; }
		public int MaxSurplusConvCount { get; private set; }
		public ResourceValueGroup SourceResAvail { get; private set; }
		public ResourceValueGroup SourceRes { get; private set; }
		public ResourceValueGroup TargetRes { get; private set; }
		private Image uiIcon => transform.GetChild(1).GetComponent<Image>();
		private Sprite sOrganicsImg => transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite;
		private Sprite sFuelImg => transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite;
		private Sprite sMetalsImg => transform.GetChild(2).GetChild(5).GetComponent<Image>().sprite;
		private Sprite sSyntheticsImg => transform.GetChild(2).GetChild(2).GetComponent<Image>().sprite;
		private Sprite sExplosivesImg => transform.GetChild(2).GetChild(3).GetComponent<Image>().sprite;
		private Sprite sExoticsImg => transform.GetChild(2).GetChild(4).GetComponent<Image>().sprite;
		private Sprite sCreditsImg => transform.GetChild(2).GetChild(6).GetComponent<Image>().sprite;
		public void FillWithDataFrom(MaterialsConverterModule converter, int recipeNum) {
			Converter = converter;
			selectedCoversionRecipe = recipeNum;
			string sName = converter.Module.DisplayNameLocalized;
			if (converter.produceRecipes[selectedCoversionRecipe].organics > 0) uiIcon.sprite = sOrganicsImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].fuel > 0) uiIcon.sprite = sFuelImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].metals > 0) uiIcon.sprite = sMetalsImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].synthetics > 0) uiIcon.sprite = sSyntheticsImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].explosives > 0) uiIcon.sprite = sExplosivesImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].exotics > 0) uiIcon.sprite = sExoticsImg;
			else if (converter.produceRecipes[selectedCoversionRecipe].credits > 0) uiIcon.sprite = sCreditsImg;
			sName = sName.Replace("<color=lime>", string.Empty);
			sName = sName.Replace("<color=red>", string.Empty);
			sName = sName.Replace("</color>", string.Empty);
			sName = Regex.Replace(sName, "\\(.*.\\) ", string.Empty);
			sName = Regex.Replace(sName, "<.*.>", string.Empty);
			displayName.horizontalOverflow = HorizontalWrapMode.Overflow;
			displayName.text = sName;
			consumeUi.Update(converter.consumeRecipes[selectedCoversionRecipe]);
			if (!converter.Module.HasFullHealth) produceUi.Update(converter.produceRecipes[selectedCoversionRecipe] * converter.currentEfficiency * FFU_BE_Defs.GetHealthPercent(converter.Module));
			else produceUi.Update(converter.produceRecipes[selectedCoversionRecipe] * converter.currentEfficiency);
			Refresh();
		}
		public void FillWithDataFrom(MaterialsConverterModule converter) {
			Converter = converter;
			selectedCoversionRecipe = -1;
			string sName = converter.Module.DisplayNameLocalized;
			sName = sName.Replace("<color=lime>", string.Empty);
			sName = sName.Replace("<color=red>", string.Empty);
			sName = sName.Replace("</color>", string.Empty);
			sName = Regex.Replace(sName, "\\(.*.\\) ", string.Empty);
			sName = Regex.Replace(sName, "<.*.>", string.Empty);
			displayName.horizontalOverflow = HorizontalWrapMode.Overflow;
			displayName.text = sName;
			consumeUi.Update(converter.consume);
			if (!converter.Module.HasFullHealth) produceUi.Update(converter.produce * converter.currentEfficiency * FFU_BE_Defs.GetHealthPercent(converter.Module));
			else produceUi.Update(converter.produce * converter.currentEfficiency);
			Refresh();
		}
		public void Refresh() {
		/// Show Reduced Output Numbers if Damaged
			ShipModule module = Converter.Module;
			bool isUsable = module != null && (module.HasFullHealth || FFU_BE_Defs.DamagedButWorking(module)) && !module.IsOverloaded && !module.IsJammed;
			if (notUsableOverlay.activeSelf != !isUsable) notUsableOverlay.SetActive(!isUsable);
			if (isUsable) {
				Calculate();
				bool hasSurplus = MaxSurplusConvCount > 0;
				if (allocateExcessButton.interactable != hasSurplus) allocateExcessButton.interactable = hasSurplus;
				bool hasEnough = isUsable && ConvCount > 0;
				if (convButton.interactable != hasEnough) convButton.interactable = hasEnough;
				ignoreSliderChangedEvent = true;
				if ((int)slider.maxValue != MaxConvCount) slider.maxValue = MaxConvCount;
				if ((int)slider.value != ConvCount) slider.value = ConvCount;
				ignoreSliderChangedEvent = false;
				if (selectedCoversionRecipe >= 0) {
					RenderResourceValueGroupWithZeros(resSpentUi, SourceRes, Converter.consumeRecipes[selectedCoversionRecipe]);
					RenderResourceValueGroupWithZeros(resRemainingUi, SourceResAvail - SourceRes, Converter.consumeRecipes[selectedCoversionRecipe]);
					RenderResourceValueGroupWithZeros(toResUi, TargetRes, Converter.produceRecipes[selectedCoversionRecipe]);
				} else {
					RenderResourceValueGroupWithZeros(resSpentUi, SourceRes, Converter.consume);
					RenderResourceValueGroupWithZeros(resRemainingUi, SourceResAvail - SourceRes, Converter.consume);
					RenderResourceValueGroupWithZeros(toResUi, TargetRes, Converter.produce);
				}
				PlayerData me = PlayerDatas.Me;
				bool hasSpace = me != null && !TargetRes.CheckHasEnoughFreeSpace(me, 1f);
				if (excessWarning.activeSelf != hasSpace) excessWarning.SetActive(hasSpace);
			}
		}
		private static void RenderResourceValueGroupWithZeros(ResourceValueGroupUI ui, ResourceValueGroup r, ResourceValueGroup consOrProdValue) {
		/// Shorten Big Resource Numbers
			r.fuel = (consOrProdValue.fuel == 0f) ? 0f : (r.fuel + 0.001f);
			r.organics = (consOrProdValue.organics == 0f) ? 0f : (r.organics + 0.001f);
			r.explosives = (consOrProdValue.explosives == 0f) ? 0f : (r.explosives + 0.001f);
			r.exotics = (consOrProdValue.exotics == 0f) ? 0f : (r.exotics + 0.001f);
			r.synthetics = (consOrProdValue.synthetics == 0f) ? 0f : (r.synthetics + 0.001f);
			r.metals = (consOrProdValue.metals == 0f) ? 0f : (r.metals + 0.001f);
			r.credits = (consOrProdValue.credits == 0f) ? 0f : (r.credits + 0.001f);
			ui.Update(r);
			string strNum = $"<size={ui.fuel.fontSize - 4}>K</size>";
			if (r.organics >= 1000f && r.organics < 10000f) ui.organics.text = $"{r.organics / 1000f:0.0}{strNum}"; else if (r.organics >= 10000f) ui.organics.text = $"{r.organics / 1000f:0}{strNum}";
			if (r.fuel >= 1000f && r.fuel < 10000f) ui.fuel.text = $"{r.fuel / 1000f:0.0}{strNum}"; else if (r.fuel >= 10000f) ui.fuel.text = $"{r.fuel / 1000f:0}{strNum}";
			if (r.metals >= 1000f && r.metals < 10000f) ui.metals.text = $"{r.metals / 1000f:0.0}{strNum}"; else if (r.metals >= 10000f) ui.metals.text = $"{r.metals / 1000f:0}{strNum}";
			if (r.synthetics >= 1000f && r.synthetics < 10000f) ui.synthetics.text = $"{r.synthetics / 1000f:0.0}{strNum}"; else if (r.synthetics >= 10000f) ui.synthetics.text = $"{r.synthetics / 1000f:0}{strNum}";
			if (r.explosives >= 1000f && r.explosives < 10000f) ui.explosives.text = $"{r.explosives / 1000f:0.0}{strNum}"; else if (r.explosives >= 10000f) ui.explosives.text = $"{r.explosives / 1000f:0}{strNum}";
			if (r.exotics >= 1000f && r.exotics < 10000f) ui.exotics.text = $"{r.exotics / 1000f:0.0}{strNum}"; else if (r.exotics >= 10000f) ui.exotics.text = $"{r.exotics / 1000f:0}{strNum}";
			if (r.credits >= 1000f && r.credits < 10000f) ui.credits.text = $"{r.credits / 1000f:0.0}{strNum}"; else if (r.credits >= 10000f) ui.credits.text = $"{r.credits / 1000f:0}{strNum}";
			ui.organics.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.fuel.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.metals.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.synthetics.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.explosives.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.exotics.horizontalOverflow = HorizontalWrapMode.Overflow;
			ui.credits.horizontalOverflow = HorizontalWrapMode.Overflow;
		}
		private void OnEnable() {
		/// Fixing UI Elements
			excessWarning.SetActive(false);
			slider.value = 0f;
			minus.onClick.AddListener(MinusClicked);
			slider.onValueChanged.AddListener(SliderChanged);
			plus.onClick.AddListener(PlusClicked);
			allocateExcessButton.onClick.AddListener(AllocateExcessClicked);
			convButton.onClick.AddListener(ConvertClicked);
			adjustPosition(transform.GetChild(3), -45, 0, 0);
			transform.GetChild(7).GetChild(4).GetComponent<Image>().sprite = transform.GetChild(3).GetChild(8).GetComponent<Image>().sprite;
		}
		private void OnDisable() {
			minus.onClick.RemoveListener(MinusClicked);
			slider.onValueChanged.RemoveListener(SliderChanged);
			plus.onClick.RemoveListener(PlusClicked);
			allocateExcessButton.onClick.RemoveListener(AllocateExcessClicked);
			convButton.onClick.RemoveListener(ConvertClicked);
		}
		private void MinusClicked() {
			slider.value = Mathf.Max(0f, slider.value - 1f);
		}
		private void PlusClicked() {
			slider.value = Mathf.Min(slider.maxValue, slider.value + 1f);
		}
		private void SliderChanged(float newValue) {
			if (!ignoreSliderChangedEvent) Refresh();
		}
		private void Calculate() {
			PlayerData me = PlayerDatas.Me;
			SourceResAvail = (me != null) ? me.Resources : ResourceValueGroup.Empty;
			ResourceValueGroup consume = selectedCoversionRecipe >= 0 ? Converter.consumeRecipes[selectedCoversionRecipe] : Converter.consume;
			ResourceValueGroup produce = selectedCoversionRecipe >= 0 ? Converter.produceRecipes[selectedCoversionRecipe] : Converter.produce;
			MaxConvCount = CalcMaxConvCount(SourceResAvail, consume);
			ConvCount = Mathf.Min((int)slider.value, MaxConvCount);
			int a = (me != null) ? CalcMaxConvCount(me.ResourceSurplus, consume) : 0;
			MaxSurplusConvCount = Mathf.Min(a, MaxConvCount);
			SourceRes = consume * ConvCount;
			if (!Converter.Module.HasFullHealth) TargetRes = produce * ConvCount * Converter.currentEfficiency * FFU_BE_Defs.GetHealthPercent(Converter.Module);
			else TargetRes = produce * ConvCount * Converter.currentEfficiency;
		}
		private static int CalcMaxConvCount(ResourceValueGroup available, ResourceValueGroup consume) {
			int mFuel = (consume.fuel > 0f) ? Mathf.FloorToInt(available.fuel / consume.fuel) : int.MaxValue;
			int mOrganics = (consume.organics > 0f) ? Mathf.FloorToInt(available.organics / consume.organics) : int.MaxValue;
			int mExplosives = (consume.explosives > 0f) ? Mathf.FloorToInt(available.explosives / consume.explosives) : int.MaxValue;
			int mExotics = (consume.exotics > 0f) ? Mathf.FloorToInt(available.exotics / consume.exotics) : int.MaxValue;
			int mSynthetics = (consume.synthetics > 0f) ? Mathf.FloorToInt(available.synthetics / consume.synthetics) : int.MaxValue;
			int mMetals = (consume.metals > 0f) ? Mathf.FloorToInt(available.metals / consume.metals) : int.MaxValue;
			int mCredits = (consume.credits > 0f) ? Mathf.FloorToInt(available.credits / consume.credits) : int.MaxValue;
			return Mathf.Min(mFuel, mOrganics, mExplosives, mExotics, mSynthetics, mMetals, mCredits);
		}
		public void ConvertClicked() {
		/// Conversion Based on Selected Recipe
			Calculate();
			if (selectedCoversionRecipe >= 0) { if (Converter.Convert(ConvCount, selectedCoversionRecipe)) slider.value = 0f; } else { if (Converter.Convert(ConvCount)) slider.value = 0f; }
		}
		private void AllocateExcessClicked() {
			Calculate();
			slider.value = MaxSurplusConvCount;
		}
		private void adjustPosition(Transform item, float x = 0f, float y = 0f, float z = 0f) {
			item.position = new Vector3() { x = item.position.x + x, y = item.position.y + y, z = item.position.z + z };
		}
		private void adjustPosition(Transform item, int x = 0, int y = 0, int z = 0) {
			item.position = new Vector3() { x = item.position.x + (x / 72f), y = item.position.y + (y / 72f), z = item.position.z + (z / 72f) };
		}
	}
	public class patch_MaterialsConverterPanel : MaterialsConverterPanel {
		[MonoModIgnore] private int prevItemsCount;
		[MonoModIgnore] public MaterialsConverterModuleUI itemProto;
		[MonoModIgnore] private List<MaterialsConverterModule> items;
		[MonoModIgnore] private List<MaterialsConverterModuleUI> uiItems;
		public class patch_BuiltinConverterUI : BuiltinConverterUI {
			[MonoModIgnore] private int step;
			[MonoModIgnore] private bool ignoreSliderChangedEvent;
			[MonoModIgnore] private void Calculate() { }
			[MonoModReplace] public void Update() {
			/// Shorten Big Resource Numbers
				Calculate();
				if (!ignoreSliderChangedEvent) {
					ignoreSliderChangedEvent = true;
					string strNum = $"<size=7>K</size>";
					if ((int)slider.maxValue != MaxTargetRes) slider.maxValue = MaxTargetRes;
					if ((int)slider.value != TargetRes) slider.value = TargetRes;
					if ((int)slider.value % step != 0) slider.value = (int)slider.value / step * step;
					if ((SourceResAvail - SourceRes) >= 1000f && (SourceResAvail - SourceRes) < 10000f) resRemaining.text = $"{(SourceResAvail - SourceRes) / 1000f:0.0}{strNum}";
					else if ((SourceResAvail - SourceRes) >= 10000f) resRemaining.text = $"{(SourceResAvail - SourceRes) / 1000f:0}{strNum}";
					else resRemaining.text = (SourceResAvail - SourceRes).ToString();
					resRemaining.horizontalOverflow = HorizontalWrapMode.Overflow;
					if (SourceRes >= 1000f && SourceRes < 10000f) resSpent.text = $"{SourceRes / 1000f:0.0}{strNum}";
					else if (SourceRes >= 10000f) resSpent.text = $"{SourceRes / 1000f:0}{strNum}";
					else resSpent.text = SourceRes.ToString();
					resSpent.horizontalOverflow = HorizontalWrapMode.Overflow;
					ignoreSliderChangedEvent = false;
				}
			}
		}
		[MonoModReplace] private void Update() {
		/// Use Multiple Recipes Per Converter
			PlayerData me = PlayerDatas.Me;
			if (!(me == null)) {
				builtinOrganicsConv.Update();
				builtinSyntheticsConv.Update();
				builtinExplosivesConv.Update();
				builtinExoticsConv.Update();
				int builtInProduce = builtinOrganicsConv.TargetRes + builtinSyntheticsConv.TargetRes + builtinExplosivesConv.TargetRes + builtinExoticsConv.TargetRes;
				builtinToFuel.text = builtInProduce.ToString();
				bool hasResourceSurplus = me.HasResourceSurplus;
				if (builtinAllocateExcessButton.interactable != hasResourceSurplus) {
					builtinAllocateExcessButton.interactable = hasResourceSurplus;
				}
				bool isBuiltInChosen = builtInProduce > 0;
				if (builtinConvButton.interactable != isBuiltInChosen) {
					builtinConvButton.interactable = isBuiltInChosen;
				}
				bool hasFreeSpace = builtInProduce > me.Fuel.FreeSpace;
				if (builtinExcessWarning.activeSelf != hasFreeSpace) {
					builtinExcessWarning.SetActive(hasFreeSpace);
				}
				items.Clear();
				List<IDictionary<MaterialsConverterModule, int>> convRecipeList = new List<IDictionary<MaterialsConverterModule, int>>();
				Ship flagship = me.Flagship;
				if (flagship != null) {
					foreach (ShipModule module in flagship.Modules) {
						if (module != null && module.type == ShipModule.Type.MaterialsConverter) {
							items.Add((module as patch_ShipModule).MaterialsConverter);
						}
					}
					if (!items.IsEmpty()) {
						items.Sort((MaterialsConverterModule a, MaterialsConverterModule b) => a.Module.DisplayNameLocalized.CompareTo(b.Module.DisplayNameLocalized));
						foreach (MaterialsConverterModule converter in items) {
							int availableRecipes = Mathf.Min(converter.produceRecipes.Length, converter.consumeRecipes.Length);
							for (int i = 0; i < availableRecipes; i++) {
								IDictionary<MaterialsConverterModule, int> newEntry = new Dictionary<MaterialsConverterModule, int>();
								newEntry.Add(new KeyValuePair<MaterialsConverterModule, int>(converter, i));
								convRecipeList.Add(newEntry);
							}
						}
					}
				}
				if (prevItemsCount != items.Count || uiItems.Exists((MaterialsConverterModuleUI p) => p == null || p.Converter == null)) {
					uiItems = RebuildConvertersUI(itemContainer.transform, itemProto, convRecipeList, delegate (MaterialsConverterModuleUI ui, MaterialsConverterModule item, int recipe) {
						ui.FillWithDataFrom(item, recipe);
					});
					prevItemsCount = items.Count;
				} else foreach (MaterialsConverterModuleUI uiItem in uiItems) uiItem.Refresh();
				float uiHeight = Mathf.Min(Mathf.RoundToInt(scrollContentRect.sizeDelta.y) + 12, (float)Screen.height / Settings.UiScale - (float)headroomPixels);
				if (preferredHeightCtrl.preferredHeight != uiHeight) preferredHeightCtrl.preferredHeight = uiHeight;
			}
		}
		public static List<MaterialsConverterModuleUI> RebuildConvertersUI<MaterialsConverterModule, MaterialsConverterModuleUI>(Transform container, MaterialsConverterModuleUI uiItemProto, List<IDictionary<MaterialsConverterModule, int>> items, System.Action<MaterialsConverterModuleUI, MaterialsConverterModule, int> updateUiElementCallback) where MaterialsConverterModuleUI : Component {
			List<MaterialsConverterModuleUI> list = new List<MaterialsConverterModuleUI>();
			IDictionary<MaterialsConverterModule, int>[] itemsArr = items.ToArray();
			int i = 0;
			for (i = 0; i < itemsArr.Length; i++) {
				MaterialsConverterModuleUI val;
				if (container.childCount <= i) {
					val = UnityEngine.Object.Instantiate(uiItemProto, container);
					val.gameObject.SetActive(true);
				} else val = container.GetChild(i).GetComponent<MaterialsConverterModuleUI>();
				list.Add(val);
				updateUiElementCallback(val, itemsArr[i].First().Key, itemsArr[i].First().Value);
			}
			for (; i < container.childCount; i++) UnityEngine.Object.Destroy(container.GetChild(i).gameObject);
			return list;
		}
	}
}