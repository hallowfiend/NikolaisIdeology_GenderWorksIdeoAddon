using RimWorld;
using Verse;
using LoveyDoveySexWithRosaline;

namespace NikolaisIdeology_GenderWorks
{
    public class ThoughtWorker_Precept_Aphrodor_Social : ThoughtWorker_Precept_Social
    {
        protected override ThoughtState ShouldHaveThought(Pawn p, Pawn otherPawn)
        {
            return !ModsConfig.BiotechActive || !ModsConfig.IdeologyActive ? ThoughtState.Inactive : (ThoughtState)otherPawn.IsAphrodor();
        }
    }
}
