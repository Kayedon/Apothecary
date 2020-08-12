﻿using System;
using RimWorld;
using Verse;

namespace Apothecary
{
	// Token: 0x02000028 RID: 40
	public class ThoughtWorker_AYSoap : ThoughtWorker
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000050F4 File Offset: 0x000032F4
		protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
		{
			if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
			{
				return false;
			}
			if (!pawn.health.capacities.CapableOf(PawnCapacityDefOf.Breathing))
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if ((other?.health) == null)
			{
				return false;
			}
			HediffSet hediffSet;
			if (other == null)
			{
				hediffSet = null;
			}
			else
			{
				Pawn_HealthTracker health = other.health;
				hediffSet = (health?.hediffSet);
			}
			HediffSet hedSet = hediffSet;
			if ((hedSet?.GetFirstHediffOfDef(this.AYHedCheckLavSoap, false)) != null)
			{
				return ThoughtState.ActiveAtStage(1);
			}
			return false;
		}

		// Token: 0x04000050 RID: 80
		public HediffDef AYHedCheckLavSoap = ThoughtWorker_AYSoap.HediffDefAYSoaps.AYLavenderSoapHigh;

		// Token: 0x02000034 RID: 52
		[DefOf]
		public static class HediffDefAYSoaps
		{
			// Token: 0x0400005F RID: 95
			public static HediffDef AYLavenderSoapHigh;
		}
	}
}
