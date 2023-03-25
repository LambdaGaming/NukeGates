using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using events = Exiled.Events.Handlers;

namespace NukeGates
{
	public class Plugin : Plugin<Config>
	{
		private EventHandlers EventHandlers;
		public override Version Version { get; } = new Version( 1, 3, 0 );
		public override Version RequiredExiledVersion { get; } = new Version( 6, 1, 0 );
		public override PluginPriority Priority { get; } = PluginPriority.Medium;

		public override void OnEnabled()
		{
			base.OnEnabled();
			EventHandlers = new EventHandlers( this );
			events.Warhead.Starting += EventHandlers.OnWarheadStart;
			events.Player.InteractingDoor += EventHandlers.OnDoorUse;
			Log.Info( $"Successfully loaded." );
		}

		public override void OnDisabled()
		{
			base.OnDisabled();
			events.Warhead.Starting -= EventHandlers.OnWarheadStart;
			events.Player.InteractingDoor -= EventHandlers.OnDoorUse;
			EventHandlers = null;
		}
	}
}
