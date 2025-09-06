using LoveyDoveySexWithRosaline;
using NikolaisIdeology.GenderWorks;
using Verse;
using RimWorld;

namespace NikolaisIdeology.GenderWorks
{


	public class ThoughtWorker_Precept_IsAphrodor : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return !ModsConfig.BiotechActive || !ModsConfig.IdeologyActive ? ThoughtState.Inactive : (ThoughtState)p.IsAphrodor();
		}
	}
}
