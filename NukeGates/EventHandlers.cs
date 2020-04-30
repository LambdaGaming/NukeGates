using EXILED;
using EXILED.Extensions;
using MEC;
using System.Collections.Generic;

namespace NukeGates
{
	public class EventHandlers
	{
		public Plugin plugin;
		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public IEnumerator<float> CloseGates()
		{
			yield return Timing.WaitForSeconds( 15.0f );
			foreach ( Door gate in Map.Doors )
			{
				if ( gate.DoorName == "GATE_A" || gate.DoorName == "GATE_B" )
				{
					gate.ChangeState( true );
				}
			}
		}

		public void OnWarheadStart( WarheadStartEvent ev )
		{
			//Log.Info( "Nuke started." );
			Timing.RunCoroutine( CloseGates() );
		}
	}
}
