using System;
using PulsarModLoader;
using PulsarModLoader.MPModChecks;
using PulsarModLoader.Utilities;

namespace PulsarBotIntegration
{
	public class Mod : PulsarMod
	{
		public override string HarmonyIdentifier() => "BadRyuner.PulsarBotIntegrations";
		public override string Author => "PulsarBot";
		public override string Name => "PulsarBot Integrations";
		public override string Version => "1.4";
		public override int MPRequirements => (int)MPRequirement.None;

		public Mod()
		{
			ModManager.Instance.OnAllModsLoaded += OnAllModsLoaded;
		}

		private static void OnAllModsLoaded()
		{
			FleetModIntegration = ModManager.Instance.IsModLoaded("FleetMod");
			Logger.Info($"FleetModIntegration is {FleetModIntegration}");
		}

		public override string VersionLink => "https://raw.githubusercontent.com/BadRyuner/PulsarBotIntegration/master/Version.json";

		public static bool FleetModIntegration;
		public static Wanted Wanted = Wanted.None;
	}
}
