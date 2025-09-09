using RimWorld;
using System.Collections.Generic;
using Verse;
using LoveyDoveySexWithRosaline;

namespace NikolaisIdeology_GenderWorks
{
    public class ThoughtWorker_Precept_NeutorPresent : ThoughtWorker_Precept
    {

        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (!ModsConfig.BiotechActive || !ModsConfig.IdeologyActive || !GenderUtilities.HasAnyReproductiveOrgan(p))
                return ThoughtState.Inactive;
            foreach (Pawn pawn in (IEnumerable<Pawn>)p.MapHeld.mapPawns.AllPawnsSpawned)
            {
                if (GenderUtilities.HasAnyReproductiveOrgan(pawn) && (!pawn.IsPrisonerOfColony && !pawn.IsSlaveOfColony && pawn.IsColonist))
                    return ThoughtState.ActiveDefault;
            }
            return ThoughtState.Inactive;
        }

    }
}