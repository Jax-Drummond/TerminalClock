using BepInEx;
using BepInEx.Configuration;

namespace TerminalClock
{
	public partial class Plugin
	{
		internal static ConfigEntry<bool> configDisplayUnkownTime;

		internal void SetupConfig()
		{
			configDisplayUnkownTime = Config.Bind("General", "displayUnknown", true, "Whether or not to show '??:??' when the time is unkown.");
		}
	}
}
