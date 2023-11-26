using HarmonyLib;

namespace TerminalClock.Patches
{
	[HarmonyPatch(typeof(HUDManager), "FillEndGameStats")]
	public static class OnFillEndGameStats
	{
		public static void Postfix()
		{
			Plugin._clockText.text = Plugin.configDisplayInSpace.Value ? "In Space" : "";
		}
	}
}
