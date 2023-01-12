using Exiled.API.Features;
using Exiled.Events.EventArgs.Warhead;
using MEC;

namespace NukeGates
{
	public class EventHandlers
	{
		private Plugin plugin;
		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void CloseGates()
		{
			var gateA = Door.Get( "GATE_A" );
			var gateB = Door.Get( "GATE_B" );
			gateA.IsOpen = false;
			gateB.IsOpen = false;
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => CloseGates() );
		}
	}
}
