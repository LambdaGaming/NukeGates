using System.ComponentModel;
using Exiled.API.Interfaces;

namespace NukeGates
{
	public sealed class Config : IConfig
	{
		[Description( "Indicates whether the plugin is enabled or not" )]
		public bool IsEnabled { get; set; } = true;

		[Description( "Time in seconds before the gates close after the nuke starts." )]
		public float CloseTime { get; private set; } = 20.0f;
	}
}
