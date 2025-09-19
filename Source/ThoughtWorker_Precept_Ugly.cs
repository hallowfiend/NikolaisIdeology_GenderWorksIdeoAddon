using RimWorld;
using Verse;

namespace NikolaisIdeology_GenderWorks
{
	public class ThoughtWorker_Precept_Ugly : ThoughtWorker_Precept_Social
	{
		protected override ThoughtState ShouldHaveThought(Pawn pawn, Pawn other)
		{
			if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
				return (ThoughtState)false;
			if (PawnUtility.IsBiologicallyOrArtificiallyBlind(pawn))
				return (ThoughtState)false;
			if (!pawn.story.CaresAboutOthersAppearance)
				return (ThoughtState)false;
			float statValue = other.GetStatValue(StatDefOf.PawnBeauty);
			if ((double)statValue <= -2.0)
				return ThoughtState.ActiveAtStage(1);
			return (double)statValue <= -1.0 ? ThoughtState.ActiveAtStage(0) : (ThoughtState)false;
		}
	}
}
