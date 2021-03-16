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
	public class patch_GameLinksUI : GameLinksUI {
		private extern void orig_Start();
		private void Start() {
			orig_Start();
			versionText.transform.parent.parent.GetChild(1).GetComponent<Text>().text = $"Modification Loaded";
			versionText.transform.parent.parent.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = "If you see this, it " +
			"means that <color=orange>Fight For Universe: Bleeding Edge</color> mod for <color=#4fd376>Shortest Trip to Earth</color> loaded successfully and you " +
			"can go full IDDQD, because original amount of <color=#cc0000>death and desperation</color> was not enough. Developed by <color=orange>WarStalkeR</color>. " +
			"Don't forget to read updated game manual (<color=orange>F1</color> hotkey) to find out about completely new features modded into the game! Enjoy!";
		}
		[MonoModReplace] public static string ReplaceVersionPlaceholders(string template) {
			return $"FFU: Bleeding Edge v{FFU_BE_Defs.modVersion}";
		}
	}
	public class patch_PersistentUI: PersistentUI {
		[MonoModReplace] private void OnEnable() {
			versionText.text = $"FFU:BE v{FFU_BE_Defs.modVersion}";
			versionText.rectTransform.sizeDelta = new Vector2 { x = 160f, y = 16f };
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
				welcomeGroup.SetActive(true);
				ProcessInitConfig();
				yield return ScreenFader.FadeIn();
				while (!StartWaitingForGameLoad) yield return null;
				WelcomeScreenShown = true;
			}
			start.gameObject.SetActive(false);
			Instantiate(gameIsLoadingPrefab);
			SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
			Destroy(gameObject);
		}
		private void ProcessInitConfig() {
			IniFile modConfig = new IniFile();
			string modConfigPath = FFU_BE_Base.appDataPath + FFU_BE_Base.modConfDir + FFU_BE_Base.modConfFile;
			modConfig.Load(modConfigPath);
			if (modConfig["InitConfig"]["fullGameReset"].ToBool(false)) {
				Debug.LogWarning("All persistent playthrough data was removed.");
				SavegameManager.DeleteAllSavedDataExceptProfileUID();
				if (modConfig["InitConfig"]["unlockShips"].ToBool(false)) {
					if (modConfig["InitConfig"]["unlockPerks"].ToBool(false)) {
						Debug.LogWarning("All ships and perks are unlocked!");
						ES2.Save(FFU_BE_Base.allPerksList, "permanent.es2?tag=unlockedItemIds");
					} else {
						Debug.LogWarning("All available player ships are unlocked!");
						ES2.Save(FFU_BE_Base.allShipsList, "permanent.es2?tag=unlockedItemIds");
					}
				}
			}
			if (modConfig["InitConfig"]["grantTopTech"].ToBool(false)) {
				Debug.LogWarning("Top tier module crafting licenses granted!");
				FFU_BE_Defs.goFullASMD = true;
			}
			modConfig["InitConfig"]["unlockShips"] = false;
			modConfig["InitConfig"]["unlockPerks"] = false;
			modConfig["InitConfig"]["grantTopTech"] = false;
			modConfig["InitConfig"]["fullGameReset"] = false;
			modConfig.Save(modConfigPath);
		}
	}
}