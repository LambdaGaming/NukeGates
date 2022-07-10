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
			var gateA = Exiled.API.Features.Door.Get( "GATE_A" );
			var gateB = Exiled.API.Features.Door.Get( "GATE_B" );
			gateA.IsOpen = false;
			gateB.IsOpen = false;
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => CloseGates() );
		}
	}
}
