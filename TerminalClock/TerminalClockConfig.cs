using BepInEx;
using BepInEx.Configuration;

namespace TerminalClock
{
	public partial class Plugin
	{
		internal static ConfigEntry<bool> configDisplayInSpace;

		internal void SetupConfig()
		{
			configDisplayInSpace = Config.Bind("General", "showInSpace", true, "Whether or not to show 'In Space' when in space.");
		}
	}
}
