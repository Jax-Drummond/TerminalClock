using HarmonyLib;

namespace TerminalClock
{
	[HarmonyPatch(typeof(HUDManager))]
	public static class OnSetClock
	{
		[HarmonyPatch("SetClock")]
		[HarmonyPostfix]
		public static void SetClock(ref HUDManager __instance)
		{
			Plugin.ClockText.text = __instance.clockNumber.text.Replace('\n', ' ');
		}
	}
}
