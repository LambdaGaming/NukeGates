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
	}
}
