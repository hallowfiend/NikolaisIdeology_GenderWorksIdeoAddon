using Verse;
using RimWorld;
namespace NikolaisIdeology_GenderWorks
{

	public class ThoughtWorker_Precept_IsNeutor : ThoughtWorker_Precept
	{
		protected override ThoughtState ShouldHaveThought(Pawn p)
		{
			return !ModsConfig.BiotechActive || !ModsConfig.IdeologyActive ? ThoughtState.Inactive : (ThoughtState)p.IsNeutor();
		}
	}
}
