using BepInEx;
using HarmonyLib;
using System.Reflection;
using TMPro;
using UnityEngine;
using static TerminalApi.Events.Events;

namespace TerminalClock
{
	[BepInPlugin("atomic.terminalclock", "Terminal Clock", "1.0.5")]
	[BepInDependency("atomic.terminalapi", MinimumDependencyVersion: "1.2.0")]
	public partial class Plugin : BaseUnityPlugin
	{
		internal static GameObject _clock;
		internal static TextMeshProUGUI ClockText => _clock.GetComponent<TextMeshProUGUI>();
		internal const string UNKOWNTIME = "??:?? ??";
		private void Awake()
		{
			SetupConfig();
			Logger.LogInfo($"Plugin Terminal Clock is loaded!");
			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
			TerminalAwake += OnTerminalAwake;
		}
		

		private void OnTerminalAwake(object sender, TerminalEventArgs e)
		{
			Transform terminalMainContainer = e.Terminal.transform.parent.parent.Find("Canvas").Find("MainContainer");

			try
			{
				_clock = terminalMainContainer.Find("Clock").gameObject;
			}
			catch
			{
                _clock = Instantiate(terminalMainContainer.Find("CurrentCreditsNum").gameObject, terminalMainContainer);
                _clock.name = "Clock";
                _clock.transform.localPosition = new Vector3(255f, 200.6003f, -1.0003f);
                _clock.transform.localScale = new Vector3(0.9f, 0.9f, 1);
                ClockText.text = configDisplayUnkownTime.Value ? UNKOWNTIME : "";
            }
		
		}
	}
}