using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;

namespace NukeGates
{
	public class EventHandlers
	{
		private Plugin plugin;

		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void CloseGates()
		{
			foreach ( Door gate in Map.Doors )
			{
				if ( gate.DoorName == "GATE_A" || gate.DoorName == "GATE_B" )
					gate.ChangeState( true );
			}
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => CloseGates() );
		}
	}
}
