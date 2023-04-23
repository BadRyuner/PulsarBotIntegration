using System;
using static UnityEngine.GUILayout;
using PulsarModLoader.CustomGUI;

namespace PulsarBotIntegration
{
	internal class Menu : ModSettingsMenu
	{
		public override string Name() => "PulsarBot Integrations";

		public override void Draw()
		{
			if (!PhotonNetwork.isMasterClient || !PhotonNetwork.inRoom)
			{
				Label("No features available for non-host players :(");
				return;
			}

			// bad CODE!!

			var prev = Mod.Wanted;

			if (Mod.FleetModIntegration && Button($"I{(Mod.Wanted.HasFlag(Wanted.Admiral) ? " don't" : null)} need an Admiral"))
				Mod.Wanted ^= Wanted.Admiral;
			if (Button($"I{(Mod.Wanted.HasFlag(Wanted.Pi) ? " don't" : null)} need a Pilot"))
				Mod.Wanted ^= Wanted.Pi;
			if (Button($"I{(Mod.Wanted.HasFlag(Wanted.Sci) ? " don't" : null)} need a Scientist"))
				Mod.Wanted ^= Wanted.Sci;
			if (Button($"I{(Mod.Wanted.HasFlag(Wanted.Weap) ? " don't" : null)} need a Weapons Spec."))
				Mod.Wanted ^= Wanted.Weap;
			if (Button($"I{(Mod.Wanted.HasFlag(Wanted.Eng) ? " don't" : null)} need an Enginner"))
				Mod.Wanted ^= Wanted.Eng;

			if (prev != Mod.Wanted)
			{
				var room = PhotonNetwork.room;
				var properties = room.CustomProperties;
				properties["wanted"] = Mod.Wanted;
				room.SetCustomProperties(properties);
			}
		}
	}
}
