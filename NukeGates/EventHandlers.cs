﻿using Exiled.API.Features;
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
			Exiled.API.Features.Door[] gates = {
				Map.GetDoorByName( "GATE_A" ),
				Map.GetDoorByName( "GATE_B" )
			};
			
			foreach ( Exiled.API.Features.Door gate in gates )
			{
				gate.Open = false;
			}
		}

		public void OnWarheadStart( StartingEventArgs ev )
		{
			Timing.CallDelayed( plugin.Config.CloseTime, () => CloseGates() );
		}
	}
}
