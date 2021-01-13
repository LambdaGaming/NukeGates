using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Interactables.Interobjects.DoorUtils;
using MEC;

namespace NukeGates
{
	public class EventHandlers
	{
		private Plugin plugin;

		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void CloseGates()
		{
			DoorVariant[] gates = {
				Map.GetDoorByName( "GATE_A" ),
				Map.GetDoorByName( "GATE_B" )
			};
			
			foreach ( DoorVariant gate in gates )
			{
				gate.NetworkTargetState = false;
				gate.ServerChangeLock( DoorLockReason.Warhead, true );
			}
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => CloseGates() );
		}
	}
}
