using RimWorld;
using System.Collections.Generic;
using Verse;

namespace NikolaisIdeology.GenderWorks
{
    public class ThoughtWorker_Precept_NeutorPresent : ThoughtWorker_Precept
    {

        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (!ModsConfig.BiotechActive || !ModsConfig.IdeologyActive || p.IsAphrodor())
                return ThoughtState.Inactive;
            foreach (Pawn pawn in (IEnumerable<Pawn>)p.MapHeld.mapPawns.AllPawnsSpawned)
            {
                if (pawn.IsNeutor() && (!pawn.IsPrisonerOfColony && !pawn.IsSlaveOfColony && pawn.IsColonist))
                    return ThoughtState.ActiveDefault;
            }
            return ThoughtState.Inactive;
        }

    }
}