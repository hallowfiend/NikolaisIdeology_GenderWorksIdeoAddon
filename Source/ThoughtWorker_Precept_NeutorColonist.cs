using Verse;
using RimWorld;
using LoveyDoveySexWithRosaline;

namespace NikolaisIdeology_GenderWorks
{
    public class ThoughtWorker_Precept_NeutorColonist : ThoughtWorker_Precept
    {
        protected override ThoughtState ShouldHaveThought(Pawn p)
        {
            if (!ModsConfig.BiotechActive || !ModsConfig.IdeologyActive || (!GenderUtilities.HasAnyReproductiveOrgan(p)) || p.Faction == null)
                return ThoughtState.Inactive;
            Ideo ideo = p.Ideo;
            bool flag = false;
            foreach (Pawn pawn in p.MapHeld.mapPawns.SpawnedPawnsInFaction(p.Faction))
            {
                if (!GenderUtilities.HasAnyReproductiveOrgan(pawn))
                {
                    flag = true;
                    Precept_Role role = pawn.Ideo?.GetRole(pawn);
                    if (role != null && role.ideo == p.Ideo && role.def == PreceptDefOf.IdeoRole_Moralist)
                        return ThoughtState.ActiveAtStage(2);
                }
            }
            return flag ? ThoughtState.ActiveAtStage(1) : ThoughtState.ActiveAtStage(0);
        }
    }
}

