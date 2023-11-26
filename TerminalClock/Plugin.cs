using BepInEx;
using HarmonyLib;
using System.Reflection;
using TerminalApi.Events;
using TMPro;
using UnityEngine;
using static TerminalApi.Patches.TerminalAwakePatch;

namespace TerminalClock
{
	[BepInPlugin("atomic.terminalclock", "Terminal Clock", "1.0.0")]
	[BepInDependency("atomic.terminalapi", MinimumDependencyVersion: "1.1.0")]
	public partial class Plugin : BaseUnityPlugin
	{
		internal static GameObject _clock;
		internal static TextMeshProUGUI _clockText => _clock.GetComponent<TextMeshProUGUI>();
		private void Awake()
		{
			SetupConfig();
			Logger.LogInfo($"Plugin Terminal Clock is loaded!");
			Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
			TerminalAwake += OnTerminalAwake;
		}

		private void OnTerminalAwake(object sender, TerminalAwakeEventArgs e)
		{
			Transform terminalMainContainer = e.Terminal.transform.parent.parent.Find("Canvas").Find("MainContainer");
			_clock = Instantiate(terminalMainContainer.Find("CurrentCreditsNum").gameObject, terminalMainContainer);
			_clock.name = "Clock";
			_clock.transform.localPosition = new Vector3(255f, 200.6003f, -1.0003f);
			_clock.transform.localScale = new Vector3(0.9f, 0.9f, 1);
			_clockText.text = configDisplayInSpace.Value ? "In Space" : "";
		}
	}
}