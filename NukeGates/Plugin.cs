using Exiled.API.Enums;
using Exiled.API.Features;
using events = Exiled.Events.Handlers;

namespace NukeGates
{
	public class Plugin : Plugin<Config>
	{
		private Handlers.Server server;

		public override PluginPriority Priority { get; } = PluginPriority.Medium;

		public override void OnEnabled()
		{
			base.OnEnabled();
			server = new Handlers.Server( this );
			events.Warhead.Starting += server.OnWarheadStart;
			Log.Info( $"Successfully loaded." );
		}

		public override void OnDisabled()
		{
			base.OnDisabled();
			events.Warhead.Starting -= server.OnWarheadStart;
			server = null;
		}
	}
}
