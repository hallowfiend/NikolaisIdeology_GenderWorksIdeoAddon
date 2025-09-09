using RimWorld;
using System.Collections.Generic;
using Verse;
using LoveyDoveySexWithRosaline;
namespace NikolaisIdeology_GenderWorks
{
    public class ThoughtWorker_Precept_AphrodorPresent : ThoughtWorker_Precept
    {

        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (!ModsConfig.BiotechActive || !ModsConfig.IdeologyActive || (GenderUtilities.HasMaleReproductiveOrgan(p) && GenderUtilities.HasFemaleReproductiveOrgan(p)))
                return ThoughtState.Inactive;
            foreach (Pawn pawn in (IEnumerable<Pawn>)p.MapHeld.mapPawns.AllPawnsSpawned)
            {
                if (GenderUtilities.HasMaleReproductiveOrgan(pawn) && GenderUtilities.HasFemaleReproductiveOrgan(pawn) && (!pawn.IsPrisonerOfColony && !pawn.IsSlaveOfColony && pawn.IsColonist))
                    return ThoughtState.ActiveDefault;
            }
            return ThoughtState.Inactive;
        }

    }
}