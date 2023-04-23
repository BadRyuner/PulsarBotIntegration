using ExitGames.Client.Photon;
using HarmonyLib;
using System;

namespace PulsarBotIntegration
{
	[Flags]
	public enum Wanted : byte
	{
		None = 0,
		Pi = 1,
		Sci = 2,
		Weap = 4,
		Eng = 8,
		Admiral = 16
	}

	[HarmonyPatch(typeof(PhotonNetwork), "CreateRoom", new Type[] { typeof(string), typeof(RoomOptions), typeof(TypedLobby), typeof(string[]) })]
	static class WantedPatch
	{
		private static void Prefix(RoomOptions roomOptions) // https://github.com/PULSAR-Modders/pulsar-mod-loader/blob/master/PulsarModLoader/Patches/PhotonProperties.cs
		{
			// Key-Value pairs attached to room as metadata
			roomOptions.CustomRoomProperties.Merge(new Hashtable() {
				{ "wanted", Mod.Wanted }
			});
			// Keys of metadata exposed to public game list
			roomOptions.CustomRoomPropertiesForLobby = roomOptions.CustomRoomPropertiesForLobby.AddRangeToArray(new string[] {
				"wanted"
			});
		}
	}
}
