using HarmonyLib;

namespace TerminalClock.Patches
{
	[HarmonyPatch(typeof(HUDManager))]
	public static class OnFillEndGameStats
	{
		[HarmonyPatch("FillEndGameStats")]
		[HarmonyPostfix]
		public static void FillEndGameStats()
		{
			Plugin.ClockText.text = Plugin.configDisplayUnkownTime.Value ? Plugin.UNKOWNTIME : "";
		}
	}
}
