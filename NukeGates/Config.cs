using System.ComponentModel;
using Exiled.API.Interfaces;

namespace NukeGates
{
	public sealed class Config : IConfig
	{
		[Description( "Indicates whether the plugin is enabled or not" )]
		public bool IsEnabled { get; set; } = true;

		[Description( "Whether or not debug messages should be shown in the console." )]
		public bool Debug { get; set; } = false;

		[Description( "Time in seconds before the gates close after the nuke starts." )]
		public float CloseTime { get; set; } = 20.0f;

		[Description( "Time in seconds before the nuke detonates that the gates should re-open. Should be at least 10 so players can make it to the surface. Set to 0 to disable." )]
		public float ReopenTime { get; set; } = 0;

		[Description( "List of keycard itemtypes that can open the gates once they close. Leave blank to disable." )]
		public ItemType[] KeycardWhitelist { get; set; } = { ItemType.KeycardO5 };

		[Description( "Whether or not SCPs should be able to open closed gates." )]
		public bool CanScpsLeave { get; set; } = false;
	}
}
