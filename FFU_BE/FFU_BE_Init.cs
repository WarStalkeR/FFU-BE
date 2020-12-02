#pragma warning disable IDE1006
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0414
#pragma warning disable CS0108

using MonoMod;
using UnityEngine;
using FFU_Bleeding_Edge;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.EventSystems;

namespace RST.UI {
	public class patch_MenuPanel : MenuPanel {
		private extern void orig_Update();
		private extern void orig_OnEnable();
		private Text textNewGameButton => transform.GetChild(2).GetChild(2).GetChild(1).GetChild(1).GetComponent<Text>();
		private bool switchIDDQD = false;
		private void OnEnable() {
		/// Load Features + Rename Button
			FFU_BE_Defs.LoadModPropsAndFeatures();
			orig_OnEnable();
			if (textNewGameButton.text.Contains("New game")) textNewGameButton.text = Core.TT("New Game\n(Shift: IDDQD Mode)");
			else textNewGameButton.text = Core.TT("Retire\n(Shift: IDDQD Mode)");
		}
		private void Update() {
		/// Hold Shift to Switch Difficulties
			orig_Update();
			if (newGamePanel.activeSelf && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && !switchIDDQD) {
				newGamePanel.SetActive(false);
				newGamePanel.SetActive(true);
				switchIDDQD = true;
			} else if (newGamePanel.activeSelf && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift) && switchIDDQD) {
				newGamePanel.SetActive(false);
				newGamePanel.SetActive(true);
				switchIDDQD = false;
			}
		}
	}
}

namespace RST.UI
	{
	public class patch_GameLoader : GameLoader {
		[MonoModIgnore] private bool StartWaitingForGameLoad;
		[MonoModIgnore] private static bool WelcomeScreenShown;
		[MonoModReplace] private IEnumerator LoadSequence() {
			FFU_BE_Base.LoadModConfiguration();
			yield return null;
			if (!PrefabFinder.IsLoaded) {
				GameObject gameIsLoadingInstance = Instantiate(gameIsLoadingPrefab);
				yield return PrefabFinder.Load();
				Destroy(gameIsLoadingInstance);
			}
			if (FFU_BE_Defs.dumpAllPrefabs)
				foreach (var entry in PrefabFinder.PrefabDict)
					Debug.LogWarning($"Prefab: [{entry.Key}] {entry.Value.name}");
			FFU_BE_Defs.LoadBleedingEdgeWelcome();
			StartWaitingForGameLoad = false;
			yield return null;
			yield return null;
			yield return ScreenFader.FadeOut();
			if (!WelcomeScreenShown) {
				welcomeGroup.SetActive(!FFU_BE_Defs.advancedWelcomePopup);
				eaWelcomeGroup.SetActive(FFU_BE_Defs.advancedWelcomePopup);
				eaResetConfirmGroup.SetActive(false);
				yield return ScreenFader.FadeIn();
				while (!StartWaitingForGameLoad) yield return null;
				WelcomeScreenShown = true;
			}
			start.gameObject.SetActive(false);
			Instantiate(gameIsLoadingPrefab);
			SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
			Destroy(gameObject);
		}
		[MonoModReplace] private void ResetYesClicked() {
			eaResetConfirmGroup.SetActive(false);
			SavegameManager.DeleteAllSavedDataExceptProfileUID();
			Debug.LogWarning("Deleted all saved data and preferences");
			if (FFU_BE_Defs.restartUnlocksEverything) {
				Debug.LogWarning("All ships and perks are unlocked!");
				ES2.Save(FFU_BE_Base.allPerksList, "permanent.es2?tag=unlockedItemIds");
			} else {
				Debug.LogWarning("All available player ships are unlocked!");
				ES2.Save(FFU_BE_Base.allShipsList, "permanent.es2?tag=unlockedItemIds");
			}
			StartWaitingForGameLoad = true;
		}
		[MonoModReplace] private void DiscardPermanentlyClicked() {
			Debug.LogWarning("Top tier module crafting licenses granted!");
			FFU_BE_Defs.goFullASMD = true;
			StartWaitingForGameLoad = true;
		}
	}
}