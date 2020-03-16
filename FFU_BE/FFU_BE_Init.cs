#pragma warning disable IDE1006
#pragma warning disable IDE0051
#pragma warning disable IDE0059
#pragma warning disable CS0626
#pragma warning disable CS0414

using MonoMod;
using UnityEngine;
using FFU_Bleeding_Edge;
using System.Collections;
using UnityEngine.SceneManagement;

namespace RST.UI {
	public class patch_MenuPanel : MenuPanel {
		private extern void orig_OnEnable();
		private void OnEnable() {
			FFU_BE_Defs.LoadModPropsAndFeatures();
			orig_OnEnable();
		}
	}
}

namespace RST {
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