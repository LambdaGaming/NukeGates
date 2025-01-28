using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Warhead;
using MEC;

namespace NukeGates
{
	public class EventHandlers
	{
		private Plugin plugin;
		public EventHandlers( Plugin plugin ) => this.plugin = plugin;

		public void SetGates( bool open )
		{
			var gateA = Door.Get( "GATE_A" );
			var gateB = Door.Get( "GATE_B" );
			gateA.IsOpen = open;
			gateB.IsOpen = open;
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => {
				if ( Warhead.IsInProgress )
					SetGates( false );
			} );
			if ( plugin.Config.ReopenTime > 0 )
			{
				Timing.CallDelayed( Warhead.DetonationTimer - plugin.Config.ReopenTime, () => {
					if ( Warhead.IsInProgress )
						SetGates( true );
				} );
			}
		}

		public void OnDoorUse( InteractingDoorEventArgs ev )
		{
			if ( ev.Player.IsScp && plugin.Config.CanScpsLeave && Warhead.IsInProgress && ev.Door.IsGate )
			{
				ev.IsAllowed = true;
				return;
			}
			if ( Warhead.IsInProgress && ev.Door.IsGate && plugin.Config.KeycardWhitelist.Length > 0 && ev.Player.CurrentItem != null )
			{
				if ( !plugin.Config.KeycardWhitelist.Contains( ev.Player.CurrentItem.Type ) )
				{
					ev.IsAllowed = false;
				}
			}
		}
	}
}
