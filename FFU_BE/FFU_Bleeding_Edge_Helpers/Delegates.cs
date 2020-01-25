using RST.UI;
using System.Reflection;

namespace FFU_Bleeding_Edge {
	public delegate void Delegated_TPC_TC(TimePanelControls instance);
	public class Delegated {
		public static Delegated_TPC_TC dDoPause = (Delegated_TPC_TC)System.Delegate.CreateDelegate(typeof(Delegated_TPC_TC), typeof(TimePanelControls).GetMethod("DoPause", BindingFlags.NonPublic | BindingFlags.Instance));
		public static Delegated_TPC_TC dDoSlowMotion = (Delegated_TPC_TC)System.Delegate.CreateDelegate(typeof(Delegated_TPC_TC), typeof(TimePanelControls).GetMethod("DoSlowMotion", BindingFlags.NonPublic | BindingFlags.Instance));
	}
}
