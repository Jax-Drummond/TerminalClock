using HarmonyLib;

namespace TerminalClock
{
	[HarmonyPatch(typeof(HUDManager), "SetClock")]
	public static class OnSetClock
	{
		public static void Postfix(ref HUDManager __instance)
		{
			Plugin._clockText.text = __instance.clockNumber.text.Replace('\n', ' ');
		}
	}
}
