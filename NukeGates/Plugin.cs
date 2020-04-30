using EXILED;

namespace NukeGates
{
	public class Plugin : EXILED.Plugin
	{
		public EventHandlers EventHandlers;

		public override void OnEnable()
		{
			EventHandlers = new EventHandlers( this );
			Events.WarheadStartEvent += EventHandlers.OnWarheadStart;
			Log.Info( $"Successfully loaded." );
		}

		public override void OnDisable()
		{
			Events.WarheadStartEvent -= EventHandlers.OnWarheadStart;
			EventHandlers = null;
		}

		public override void OnReload()
		{
			
		}

		public override string getName { get; } = "NukeGates";
	}
}
