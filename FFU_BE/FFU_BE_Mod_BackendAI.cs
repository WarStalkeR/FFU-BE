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
using MonoMod;

namespace RST {
	public class patch_ShipAI : ShipAI {
		//Broken Modules Identification Fix
		public class ModuleCrewPair : AiStateItem, IAiStateItem, IHasAssociatedCrew, IHasAssociatedModule {
			public Crewmember Crew { get; private set; }
			public Vector2 CrewPos { get; private set; }
			public ShipModule Module { get; private set; }
			public Vector2 ModulePos { get; private set; }
			public bool ModuleBrokenButFullyRepairable { get; private set; }
			public float Score {
				get {
					ShipModule module = Module;
					Crewmember crew = Crew;
					if (module == null || crew == null) return 0f;
					float repScore = ModuleBrokenButFullyRepairable ? (crew.skills.repair * p.moduleRepImportanceWeight) : 0f;
					Crewmember.Skill requiredCrewSkillType = module.GetRequiredCrewSkillType();
					float opScore = (!module.CanOperate(crew, false)) ? (-5f) : (crew.GetEffectiveSkill(requiredCrewSkillType) * p.moduleOpImportanceWeight);
					float distScore = (ModulePos - CrewPos).magnitude * p.moduleDistanceWeight;
					return opScore * module.ImportanceToAI + repScore - distScore;
				}
			}
			public ModuleCrewPair(Crewmember c, ShipModule m, Priorities p) : base(p) {
				Crew = c;
				Module = m;
				if (m != null) {
					ModulePos = m.transform.position;
					ModuleBrokenButFullyRepairable = !FFU_BE_Defs.DamagedButWorking(m) && m.CanRepairFully;
				}
				if (c != null) CrewPos = c.transform.position;
			}
			public ModuleCrewPair(Crewmember crew, ShipModule module, bool moduleBrokenButFullyRepairable, Vector2 modulePos, Vector2 crewPos, Priorities p) : base(p) {
				Crew = crew;
				Module = module;
				ModuleBrokenButFullyRepairable = moduleBrokenButFullyRepairable;
				ModulePos = modulePos;
				CrewPos = crewPos;
			}
			public void RemoveFrom(List<IAiStateItem> stateItems) {
				stateItems.Remove(this);
				if (Crew != null && !stateItems.Exists((IAiStateItem i) => i is CrewWithCommand && (i as CrewWithCommand).Crew == Crew)) stateItems.Add(new CrewWithCommand(Crew, CrewPos, Crewmember.Command.Idle, p));
				if (Module != null && !stateItems.Exists((IAiStateItem i) => i is ModuleCrewPair && (i as ModuleCrewPair).Module == Module)) stateItems.Add(new ModuleWithoutCrew(Module, ModuleBrokenButFullyRepairable, ModulePos, p));
			}
			public override string ToString() {
				return string.Format("{0} ({1}, {2}. ModulePos {3}, Module broken {4}, CrewPos {5}): {6:0.00}", GetType().Name, (Crew != null) ? Crew.name : "null", (Module != null) ? Module.name : "null", ModulePos, ModuleBrokenButFullyRepairable, CrewPos, Score);
			}
			public string[] GetParamsForDisplay() {
				return new string[3] {
					(Module != null) ? (Module.name + " " + ModulePos) : "null",
					ModuleBrokenButFullyRepairable ? " rep" : null,
					"C: " + ((Crew != null) ? (Crew.name + " " + CrewPos) : "null")
				};
			}
		}
		//Broken Modules Identification Fix
		public class ModuleWithoutCrew : AiStateItem, IAiStateItem, IHasAssociatedModule {
			public ShipModule Module { get; private set; }
			public Vector2 ModulePos { get; private set; }
			public bool ModuleBrokenButFullyRepairable { get; private set; }
			public float Score {
				get {
					if (Module == null) return 0f;
					float moduleNoOpImportanceWeight = p.moduleNoOpImportanceWeight;
					float num = ModuleBrokenButFullyRepairable ? p.moduleNoRepImportanceWeight : 0f;
					return (0f - moduleNoOpImportanceWeight) * Module.ImportanceToAI - num;
				}
			}
			public ModuleWithoutCrew(ShipModule m, Priorities p) : base(p) {
				Module = m;
				if (m != null) {
					ModuleBrokenButFullyRepairable = !FFU_BE_Defs.DamagedButWorking(m) && m.CanRepairFully;
					ModulePos = m.transform.position;
				}
			}
			public ModuleWithoutCrew(ShipModule module, bool moduleBrokenButFullyRepairable, Vector2 modulePos, Priorities p) : base(p) {
				Module = module;
				ModuleBrokenButFullyRepairable = moduleBrokenButFullyRepairable;
				ModulePos = modulePos;
			}
			public void RemoveFrom(List<IAiStateItem> stateItems) {
				stateItems.Remove(this);
			}
			public override string ToString() {
				return string.Format("{0} ({1}. Broken {2}, ModulePos {3}): {4:0.00}", GetType().Name, (Module != null) ? Module.name : "null", ModuleBrokenButFullyRepairable, ModulePos, Score);
			}
			public string[] GetParamsForDisplay() {
				return new string[2] {
					(Module != null) ? Module.name : "null",
					ModuleBrokenButFullyRepairable ? "rep" : null
				};
			}
		}
		//Broken Modules Identification Fix
		public class WeaponWithoutOrTooOldTarget : AiStateItem, IAiStateItem, IHasAssociatedModule {
			public ShipModule Module { get; private set; }
			public bool ModuleBrokenButFullyRepairable { get; private set; }
			public Vector2 ModulePos { get; private set; }
			public float Score => 0f - p.weaponWithoutTargetWeight;
			public WeaponWithoutOrTooOldTarget(ShipModule m, Priorities p) : base(p) {
				Module = m;
				if (m != null) {
					ModuleBrokenButFullyRepairable = !FFU_BE_Defs.DamagedButWorking(m) && m.CanRepairFully;
					ModulePos = m.transform.position;
				}
			}
			public WeaponWithoutOrTooOldTarget(ShipModule module, bool moduleBrokenButFullyRepairable, Vector2 modulePos, Priorities p) : base(p) {
				Module = module;
				ModuleBrokenButFullyRepairable = moduleBrokenButFullyRepairable;
				ModulePos = modulePos;
			}
			public void RemoveFrom(List<IAiStateItem> stateItems) {
				stateItems.Remove(this);
			}
			public override string ToString() {
				return string.Format("{0} ({1}. Broken {2}, ModulePos {3}): {4:0.00}", GetType().Name, (Module != null) ? Module.name : "null", ModuleBrokenButFullyRepairable, ModulePos, Score);
			}
			public string[] GetParamsForDisplay() {
				return new string[1] {
					(Module != null) ? Module.name : "null"
				};
			}
		}
	}
}
