using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace NukeGates
{
	public class EventHandlers
	{
		private Plugin plugin;

		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public IEnumerator<float> CloseGates()
		{
			yield return Timing.WaitForSeconds( plugin.Config.CloseTime );
			foreach ( Door gate in Map.Doors )
			{
				if ( gate.DoorName == "GATE_A" || gate.DoorName == "GATE_B" )
					gate.ChangeState( true );
			}
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.RunCoroutine( CloseGates() );
		}
	}
}
