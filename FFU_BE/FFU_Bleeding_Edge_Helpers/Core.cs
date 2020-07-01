using RST;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace FFU_Bleeding_Edge {
	public class Core {
		public static string TT(string localeString) {
			return Localization.TT(localeString);
		}
		public static int ParseIntExprMult(string inputValue, int multVar = 10) {
			if (string.IsNullOrEmpty(inputValue)) return 0;
			string[] array = inputValue.Split(new char[] { ',' });
			string text = array[RstRandom.Range(0, array.Length)].Trim();
			string[] array2 = text.Split(new string[] { ".." }, StringSplitOptions.None);
			if (array2.Length == 1) {
				if (int.TryParse(text, out int outputInt)) return outputInt * multVar;
			} else if (array2.Length == 2 && int.TryParse(array2[0], out int inputIntA) && int.TryParse(array2[1], out int inputIntB)) {
				if (inputIntA > inputIntB) {
					int inputIntC = inputIntA;
					inputIntA = inputIntB;
					inputIntB = inputIntC;
				}
				return RstRandom.Range(inputIntA, inputIntB + 1) * multVar;
			}
			string message = "Failed to parse int expression \"" + inputValue + "\". Returning 0";
			Debug.LogError(message);
			return 0;
		}
		public static string GetOriginalName(string strValue) {
			return strValue
			.Replace("(clone)", string.Empty)
			.Replace("(Clone)", string.Empty)
			.Replace("(None)", string.Empty)
			.Replace("(Sustained)", string.Empty)
			.Replace("(Reinforced)", string.Empty)
			.Replace("(Efficient)", string.Empty)
			.Replace("(Precise)", string.Empty)
			.Replace("(Rapid)", string.Empty)
			.Replace("(Enhanced)", string.Empty)
			.Replace("(Durable)", string.Empty)
			.Replace("(Persistent)", string.Empty)
			.Replace("(Unstable)", string.Empty)
			.Replace("(Fragile)", string.Empty)
			.Replace("(Inefficient)", string.Empty)
			.Replace("(Inhibited)", string.Empty)
			.Replace("(Disrupted)", string.Empty)
			.Replace("(Deficient)", string.Empty)
			.Replace("(Brittle)", string.Empty)
			.Replace("(Volatile)", string.Empty)
			.Replace("MK-X", string.Empty)
			.Replace("MK-IX", string.Empty)
			.Replace("MK-VIII", string.Empty)
			.Replace("MK-VII", string.Empty)
			.Replace("MK-VI", string.Empty)
			.Replace("MK-V", string.Empty)
			.Replace("MK-IV", string.Empty)
			.Replace("MK-III", string.Empty)
			.Replace("MK-II", string.Empty)
			.Replace("MK-I", string.Empty);
		}
		public static T RandomItemFromList<T>(List<T> genericList, T fallbackVar) {
			if (!genericList.Any()) return fallbackVar;
			int index = UnityEngine.Random.Range(0, genericList.Count);
			if (genericList.Count > 0) return genericList[index];
			else return fallbackVar;
		}
		public static T RandomItemFromList<T>(List<T> genericList) {
			if (!genericList.Any()) return default;
			if (genericList.Count > 1) return genericList[UnityEngine.Random.Range(0, genericList.Count)];
			else if (genericList.Count == 1) return genericList.First();
			else return default;
		}
		public enum CrewHitChance {
			None = 0,
			Low = 30,
			Medium = 60,
			High = 100
		}
		public enum FireIgniteChance {
			None = 0,
			Low = 20,
			Medium = 40,
			High = 100
		}
		public enum BonusType {
			Default,
			Average,
			Reduced,
			Minimal,
			Boosted,
			Extreme,
			Immense,
			Maximal
		}
		public enum BonusTier {
			NONE,
			MK_I,
			MK_II,
			MK_III,
			MK_IV,
			MK_V,
			MK_VI,
			MK_VII,
			MK_VIII,
			MK_IX,
			MK_X
		}
		public enum TechLevel {
			T1 = 0,
			T2 = 1500,
			T3 = 3500,
			T4 = 6000,
			T5 = 10000,
			T6 = 16000,
			T7 = 24000,
			T8 = 34000,
			T9 = 46000,
			TX = 60000
		}
		public enum BonusMod {
			None,
			Sustained, Unstable,
			Reinforced, Fragile,
			Efficient, Inefficient,
			Precise, Inhibited,
			Rapid, Disrupted,
			Enhanced, Deficient,
			Durable, Brittle,
			Persistent, Volatile
		}
		public enum PayloadPool {
			None,
			Squid,
			Pirate,
			Terran
		}
		public enum Difficulty {
			None,
			Easy,
			Medium,
			Hard,
			Brutal,
			Insane,
			Nightmare
		}
	}
}