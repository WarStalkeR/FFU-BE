#pragma warning disable IDE1006
#pragma warning disable CS0626
#pragma warning disable CS0414

using MonoMod;
using UnityEngine;
using FFU_Bleeding_Edge;

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
		[MonoModIgnore] private void ResetNoClicked() { }
		[MonoModIgnore] private void StartClicked() { }
		[MonoModIgnore] private void ResetClicked() { }
		private void OnEnable() {
			ES2.Save(true, "game.es2?tag=afterEaResetAvailable");
			FFU_BE_Base.LoadModConfiguration();
			FFU_BE_Defs.LoadBleedingEdgeWelcome();
			welcomeGroup.SetActive(!FFU_BE_Defs.advancedWelcomePopup);
			eaWelcomeGroup.SetActive(FFU_BE_Defs.advancedWelcomePopup);
			start.onClick.AddListener(StartClicked);
			eaStart.onClick.AddListener(StartClicked);
			eaDiscardPermanently.onClick.AddListener(DiscardPermanentlyClicked);
			eaReset.onClick.AddListener(ResetClicked);
			eaResetYes.onClick.AddListener(ResetYesClicked);
			eaResetNo.onClick.AddListener(ResetNoClicked);
		}
		private void ResetYesClicked() {
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
		private void DiscardPermanentlyClicked() {
			Debug.LogWarning("Top tier module crafting licenses granted!");
			FFU_BE_Defs.goFullASMD = true;
			StartWaitingForGameLoad = true;
		}
	}
}